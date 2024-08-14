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

        private static Random _rand = new Random();

        public static int GetRandomColorNumber()
        {
            return _rand.Next(90, 196);
        }

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

    
}
