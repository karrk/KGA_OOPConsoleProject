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
    }
}
