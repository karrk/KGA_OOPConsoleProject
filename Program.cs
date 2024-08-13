using System.Text;

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

            //Console.WriteLine($"{Fonts.BREAD1}{Fonts.BREAD1}{Fonts.BREAD1}{Fonts.BREAD1}{Fonts.BREAD1}{Fonts.BREAD1}");
            //Console.WriteLine($"{Fonts.BREAD2}{Fonts.BREAD2}{Fonts.BREAD2}{Fonts.BREAD2}{Fonts.BREAD2}{Fonts.BREAD2}");
            //Console.WriteLine($"{Fonts.BREAD3}{Fonts.BREAD3}{Fonts.BREAD3}{Fonts.BREAD3}{Fonts.BREAD3}{Fonts.BREAD3}");
            //Console.WriteLine($"{Fonts.BREAD4}{Fonts.BREAD4}{Fonts.BREAD4}{Fonts.BREAD4}{Fonts.BREAD4}{Fonts.BREAD4}");

            //Console.WriteLine();
            //Console.WriteLine($"{Fonts.BEEF1}{Fonts.BEEF1}{Fonts.BEEF1}{Fonts.BEEF1}{Fonts.BEEF1}{Fonts.BEEF1}");
            //Console.WriteLine($"{Fonts.BEEF2}{Fonts.BEEF2}{Fonts.BEEF2}{Fonts.BEEF2}{Fonts.BEEF2}{Fonts.BEEF2}");
            //Console.WriteLine($"{Fonts.BEEF3}{Fonts.BEEF3}{Fonts.BEEF3}{Fonts.BEEF3}{Fonts.BEEF3}{Fonts.BEEF3}");
            //Console.WriteLine($"{Fonts.BEEF4}{Fonts.BEEF4}{Fonts.BEEF4}{Fonts.BEEF4}{Fonts.BEEF4}{Fonts.BEEF4}");

            //Console.WriteLine();

            //Console.WriteLine($"{Fonts.OPTION1}{Fonts.OPTION1}{Fonts.OPTION1}");
            //Console.WriteLine($"{Fonts.OPTION2}{Fonts.OPTION2}{Fonts.OPTION2}");
            //Console.WriteLine($"{Fonts.OPTION3}{Fonts.OPTION3}{Fonts.OPTION3}");
            //Console.WriteLine($"{Fonts.OPTION4}{Fonts.OPTION4}{Fonts.OPTION4}");

            Console.SetCursorPosition(0, 0);
            //Console.WriteLine(Fonts.CUSTOMERHEAD);
            //Console.WriteLine(Fonts.CUSTOMERHEAD);
            //Console.WriteLine(Fonts.CUSTOMERBODY);
            //Console.WriteLine(Fonts.CUSTOMERBODY);
            //Console.WriteLine(Fonts.CUSTOMERBODY);
            //Console.WriteLine(Fonts.CUSTOMERBODY);
            //Console.WriteLine(Fonts.CUSTOMERBODY);

            while (true)
            {

            }
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
