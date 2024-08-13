namespace MiniCooked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            GameManager.Instance.Init();
            SettingManager.Instance.Init();
            UIManager.Instance.Init();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("한글자 ");
            //Console.WriteLine(sb.Length);

            while (true)
            {

            }
        }
    }

    public enum HorizonAlign
    {
        Left,
        Center,
        Right,
    }

    public enum VerticalAlign
    {
        Top,
        Center,
        Bottom,
    }

    public static class ColorPrinter
    {
        // colorCodeURL = https://en.wikipedia.org/wiki/ANSI_escape_code#8-bit
        public const string COLOR_CODE_FRONT = "\u001b[38;5;";
        public const string COLOR_CODE_MIDDLE = "m";
        public const string COLOR_CODE_BACK = "\u001b[0m";

        public static void Print(int m_cursorX, int m_cursorY, int m_color,string text)
        {
            Console.SetCursorPosition(m_cursorX, m_cursorY);
            Console.Write($"{COLOR_CODE_FRONT}{m_color}{COLOR_CODE_MIDDLE}{text}{COLOR_CODE_BACK}");
        }

        public static void Print(int m_cursorX, int m_cursorY, int m_color, char text)
        {
            Console.SetCursorPosition(m_cursorX, m_cursorY);
            Console.Write($"{COLOR_CODE_FRONT}{m_color}{COLOR_CODE_MIDDLE}{text}{COLOR_CODE_BACK}");
        }

        public static void PrintLine(int m_cursorX, int m_cursorY, int m_color, string text)
        {
            Console.SetCursorPosition(m_cursorX, m_cursorY);
            Console.WriteLine($"{COLOR_CODE_FRONT}{m_color}{COLOR_CODE_MIDDLE}{text}{COLOR_CODE_BACK}");
        }
        public static void PrintLine(int m_cursorX, int m_cursorY, int m_color, char text)
        {
            Console.SetCursorPosition(m_cursorX, m_cursorY);
            Console.WriteLine($"{COLOR_CODE_FRONT}{m_color}{COLOR_CODE_MIDDLE}{text}{COLOR_CODE_BACK}");
        }
    }

    public static class CharContoroller
    {
        public static char HalfToFull(char m_half)
        {
            if (m_half > 0x21 && m_half <= 0x7e)

                m_half += (char)0xfee0;

            else if (m_half == 0x20)

                m_half = (char)0x3000;

            return m_half;
        }

        public static bool isHalf(char m_half)
        {
            return (m_half >= 0x20 && m_half <= 0x7E);
        }
    }

    public static class Fonts
    {
        public const char LAYOUT_OUTLINE_HORIZON = '\u2501';
        public const char LAYOUT_OUTLINE_VERTICAL = '\u2503';
        public const char LAYOUT_OUTLINE_TOPLEFT = '\u250F';
        public const char LAYOUT_OUTLINE_TOPRIGHT = '\u2513';
        public const char LAYOUT_OUTLINE_DOWNLEFT = '\u2517';
        public const char LAYOUT_OUTLINE_DOWNRIGHT = '\u251B';

        public const char EMPTY = '\u0020';

        public const char BREAD1 = '\u0150';
        public const char BREAD2 = '\u014C';
        public const char BREAD3 = '\u0277';
        public const char BREAD4 = '\u0276';

        public const char BEEF1 = '\u0B24';
        public const char BEEF2 = '\u0C5A';
        public const char BEEF3 = '\u0F36';
        public const char BEEF4 = '\u0F36';

        public const char OPTION1 = '\u07D8';
        public const char OPTION2 = '\u0B24';
        public const char OPTION3 = '\u16E5';
        public const char OPTION4 = '\u2180';

        public const string CUSTOMERHEAD = "\u0020\u0020\u0020█████";
        public const string CUSTOMERBODY = "████████████";
    }
}
