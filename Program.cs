using System.Text;

namespace MiniCooked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SettingManager.Init();

            Layout layout = new Layout(1,1,200,60);
            Layout orderLayout = new Layout(14,2,124,26);
            Layout previewLayout = new Layout(10, 30, 50, 30);
            Layout selectLayout = new Layout(70, 30, 70, 26);
            Layout menuLayout = new Layout(145,2,50,58);
            Layout spaceBarLayout = new Layout(80, 57, 50, 3);

            layout.AddLayout(orderLayout);
            layout.AddLayout(previewLayout);
            layout.AddLayout(menuLayout);
            layout.AddLayout(selectLayout);
            layout.AddLayout(spaceBarLayout);

            TextBox spaceText = new TextBox($"SpaceBar : 서빙");
            spaceText.SetAlign(TextBox.TextHorizonAlign.Center);
            spaceText.SetAlign(TextBox.TextVerticalAlign.Center);

            spaceBarLayout.AddText(spaceText);

            Layout btn1 = new Layout(75,48,20,7);
            Layout btn2 = new Layout(75+20,48,20,7);
            Layout btn3 = new Layout(75+40,48,20,7);

            Layout btn4 = new Layout(75, 40, 20, 7);
            Layout btn5 = new Layout(75 + 20, 40, 20, 7);
            Layout btn6 = new Layout(75 + 40, 40, 20, 7);

            Layout btn7 = new Layout(75 , 32, 20, 7);
            Layout btn8 = new Layout(75 + 20, 32, 20, 7);
            Layout btn9 = new Layout(75 + 40, 32, 20, 7);

            selectLayout.AddLayout(btn1);
            btn1.AddText(new TextBox(" Num1"));
            selectLayout.AddLayout(btn2);
            btn2.AddText(new TextBox(" Num2"));
            selectLayout.AddLayout(btn3);
            btn3.AddText(new TextBox(" Num3"));

            selectLayout.AddLayout(btn4);
            btn4.AddText(new TextBox(" Num4"));
            selectLayout.AddLayout(btn5);
            btn5.AddText(new TextBox(" Num5"));
            selectLayout.AddLayout(btn6);
            btn6.AddText(new TextBox(" Num6"));

            selectLayout.AddLayout(btn7);
            btn7.AddText(new TextBox(" Num7"));
            selectLayout.AddLayout(btn8);
            btn8.AddText(new TextBox(" Num8"));
            selectLayout.AddLayout(btn9);
            btn9.AddText(new TextBox(" Num9"));

            TextBox tb = new TextBox($"메뉴{Fonts.EMPTY}레시피");
            tb.SetAlign(TextBox.TextHorizonAlign.Center);
            tb.SetLine(1);
            tb.SetAlign(TextBox.TextVerticalAlign.Top);

            tb.AddText(" 가나다",true);

            menuLayout.AddText(tb);

            layout.PrintLayout();

            Console.WriteLine();
        }
    }

    public interface IManager
    {
        public void Init();
    }

    public class SettingManager
    {
        public static void Init()
        {
            SetConsole();
        }

        private static void SetConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
        }
    }

    public class GameManager
    {

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
