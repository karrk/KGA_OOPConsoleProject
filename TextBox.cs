using MiniCooked;
using System.Text;

public class TextBox : RectUI
{
    private StringBuilder _sb = new StringBuilder();
    //[][][]
    //c c c
    //cw[sb[1]] cw[sb[2]]
    private int _tempIdx = 0;
    private int _lineCount = 0;

    private List<int> _lineRange = new List<int>();

    public TextBox(Rect m_rect) : base(m_rect)
    {
    }

    //public TextBox(RectUI m_source, RectCorner m_corner, int m_offsetX, int m_offsetY, Rect m_size) : base(m_source, m_corner, m_offsetX, m_offsetY, m_size)
    //{
    //}

    public TextBox(string m_text)
    {
        SetNewText(m_text);
    }

    public void SetNewText(string m_text)
    {
        _lineRange.Clear();
        _lineRange.Add(0);
        _tempIdx = 0;
        _sb.Clear();
        _lineCount = 1;

        int count = 0;

        for (int i = 0; i < m_text.Length; i++)
        {
            _sb.Append(m_text[i]);
            count++;

            if (CharContoroller.isHalf(m_text[i]))
            {
                _sb.Append(' '); // 반각 문자는 공백 추가로 2칸 차지하게 함
                count++;
            }
        }

        _rect.EndX = _rect.StartX + count;
        _lineRange.Add(count);
    }

    public TextBox AddText(string m_text, bool m_lineMode = false)
    {
        if (m_lineMode)
        {
            _sb.AppendLine();
            _tempIdx = _sb.Length;
            _rect.EndY++;
            _lineCount++;
            _lineRange.Add(_lineRange[_lineRange.Count - 1]);
        }

        int count = 0;

        for (int i = 0; i < m_text.Length; i++)
        {
            _sb.Append(m_text[i]);
            count++;

            if (CharContoroller.isHalf(m_text[i]))
            {
                _sb.Append(' '); // 반각 문자 뒤에 공백 추가
                count++;
            }
        }

        _tempIdx += count;
        _lineRange[_lineRange.Count - 1] = _tempIdx;

        if (_rect.EndY < _tempIdx)
            _rect.EndY = _tempIdx;

        return this;
    }

    public TextBox AddText(char m_text, bool m_lineMode = false)
    {
        return AddText(m_text.ToString(), m_lineMode);
    }

    public override void Print()
    {
        int standardX = Left;
        int standardY = Top;
        int strLength;

        for (int i = 1; i <= _lineCount; i++)
        {
            strLength = _lineRange[i] - _lineRange[i - 1];

            int start = _lineRange[i - 1];

            for (int j = 0; j < strLength; j++)
            {
                ColorPrinter.Print(standardX + j, standardY+i, _printColor, _sb[start + j]);
            }
        }
    }
}