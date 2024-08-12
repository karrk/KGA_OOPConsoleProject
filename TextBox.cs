using System.Text;

public class TextBox
{
    public enum TextHorizonAlign
    {
        Left,
        Center,
        Right,
    }

    public enum TextVerticalAlign
    {
        Top,
        Center,
        Bottom,
    }

    private StringBuilder _sb;
    public int Length => _sb.Length;

    private int _posX;
    private int _posY;

    private int _printLine;

    public int PrintLine => _printLine;

    private TextHorizonAlign _horizonAlign;
    private TextVerticalAlign _verticalAlign;

    public Layout ParentLayout;

    public TextBox(string m_text)
    {
        this._sb = new StringBuilder();
        this._sb.Append(m_text);
    }

    public void AddText(string m_text, bool m_lineMode = false)
    {
        if (m_lineMode)
            _sb.AppendLine();

        _sb.Append(m_text);
    }

    public void SetNewText(string m_text)
    {
        _sb.Clear();
        _sb.Append(m_text);
    }

    public void SetPos(int m_posX, int m_posY)
    {
        this._posX = m_posX;
        this._posY = m_posY;
    }

    public void SetLine(int m_line)
    { this._printLine = m_line; }

    public void SetAlign(TextHorizonAlign m_horizon)
    {
        this._horizonAlign = m_horizon;
    }

    public void SetAlign(TextVerticalAlign m_vertical)
    {
        this._verticalAlign = m_vertical;
    }

    public void PrintText()
    {
        int row = ParentLayout.Left + 1;
        int column = ParentLayout.Top + _printLine + 1;


        switch (_horizonAlign)
        {
            case TextHorizonAlign.Center:
                row = ParentLayout.Right - (ParentLayout.Width / 2) - Length / 2;
                break;
            case TextHorizonAlign.Right:
                row = ParentLayout.Right - Length * 2 - 1;
                break;
        }

        switch (_verticalAlign)
        {
            case TextVerticalAlign.Center:
                column = ParentLayout.Bottom - (ParentLayout.Height / 2);
                break;
            case TextVerticalAlign.Bottom:
                column = ParentLayout.Bottom - _printLine - 1;
                break;
        }

        Console.SetCursorPosition(row, column);

        for (int i = 0; i < _sb.Length; i++)
        {
            if (_sb[i] == '\n')
            {
                Console.WriteLine();
                Console.SetCursorPosition(row, ++column);
                continue;
            }

            Console.Write(_sb[i]);
        }
    }
}