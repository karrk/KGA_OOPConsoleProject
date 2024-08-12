using MiniCooked;

public class UIManager
{
    private static UIManager _instance = null;

    public static UIManager Instance => _instance;

    private Layout _mainLayout = null;

    public UIManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        _mainLayout = new Layout(1, 1, 200, 60);
        InitLayouts();

        _mainLayout.PrintLayout();
    }

    private void InitLayouts()
    {
        AddOrderLayout();
        AddPreviewLayout();
        AddSelectLayout();
        AddMenuLayout();
        AddSpaceBarLayout();
    }

    private void AddOrderLayout()
    {
        Layout orderLayout = new Layout(14, 2, 124, 26);
        _mainLayout.AddLayout(orderLayout);
    }

    private void AddPreviewLayout()
    {
        Layout previewLayout = new Layout(10, 30, 50, 30);
        _mainLayout.AddLayout(previewLayout);
    }

    private void AddSelectLayout()
    {
        Layout selectLayout = new Layout(70, 30, 70, 26);
        _mainLayout.AddLayout(selectLayout);

        Layout btn1 = new Layout(75, 48, 20, 7);
        Layout btn2 = new Layout(75 + 20, 48, 20, 7);
        Layout btn3 = new Layout(75 + 40, 48, 20, 7);

        Layout btn4 = new Layout(75, 40, 20, 7);
        Layout btn5 = new Layout(75 + 20, 40, 20, 7);
        Layout btn6 = new Layout(75 + 40, 40, 20, 7);

        Layout btn7 = new Layout(75, 32, 20, 7);
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
    }

    private void AddSpaceBarLayout()
    {
        Layout spaceBarLayout = new Layout(80, 57, 50, 3);
        _mainLayout.AddLayout(spaceBarLayout);

        TextBox spaceText = new TextBox($"SpaceBar : 서빙");
        spaceText.SetAlign(TextBox.TextHorizonAlign.Center);
        spaceText.SetAlign(TextBox.TextVerticalAlign.Center);

        spaceBarLayout.AddText(spaceText);
    }

    private void AddMenuLayout()
    {
        Layout menuLayout = new Layout(145, 2, 50, 58);
        _mainLayout.AddLayout(menuLayout);

        TextBox tb = new TextBox($"메뉴{Fonts.EMPTY}레시피");
        tb.SetAlign(TextBox.TextHorizonAlign.Center);
        tb.SetLine(1);
        tb.SetAlign(TextBox.TextVerticalAlign.Top);

        tb.AddText(" 가나다", true);

        menuLayout.AddText(tb);
    }
}