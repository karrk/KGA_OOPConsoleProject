using System.Text;

public class TextBox
{
    // colorCodeURL = https://en.wikipedia.org/wiki/ANSI_escape_code#8-bit
    public const string COLOR_CODE_FRONT = "\u001b[38;5;";
    public const string COLOR_CODE_MIDDLE = "m";
    public const string COLOR_CODE_BACK = "\u001b[0m";

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

    private int _colorCode = 231;

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

    public void AddText(char m_text, bool m_lineMode = false)
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

    public TextBox SetLine(int m_line)
    { 
        this._printLine = m_line;
        return this;
    }

    public TextBox SetColor(int m_colorCode)
    {
        this._colorCode = m_colorCode;
        return this;
    }

    public TextBox SetAlign(TextHorizonAlign m_horizon)
    {
        this._horizonAlign = m_horizon;
        return this;
    }

    public TextBox SetAlign(TextVerticalAlign m_vertical)
    {
        this._verticalAlign = m_vertical;
        return this;
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
                row = (int)(ParentLayout.Right - Length*1.5f);
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

            Console.Write($"{COLOR_CODE_FRONT}{_colorCode}{COLOR_CODE_MIDDLE}{_sb[i]}{COLOR_CODE_BACK}");
        }
    }
}