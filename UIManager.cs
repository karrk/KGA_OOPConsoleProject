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
        Layout orderLayout = new Layout(14, 4, 124, 24);
        _mainLayout.AddLayout(orderLayout);

        orderLayout.AddText(
            new TextBox("수입 :\t\t\t\t\t\t\t\t\t")
            .SetAlign(TextBox.TextHorizonAlign.Right)
            );
    }

    private void AddPreviewLayout()
    {
        Layout previewLayout = new Layout(10, 30, 50, 30);
        _mainLayout.AddLayout(previewLayout);

        previewLayout.AddText(new TextBox("  테이블"));

        previewLayout.AddText(
            new TextBox("█████████████████████████████████████████████████").SetColor(166)
            .SetAlign(TextBox.TextVerticalAlign.Bottom).SetLine(2));

        previewLayout.AddText(
            new TextBox("█████████████████████████████████████████████████").SetColor(167)
            .SetAlign(TextBox.TextVerticalAlign.Bottom).SetLine(1));
        
        previewLayout.AddText(
            new TextBox("█████████████████████████████████████████████████").SetColor(168)
            .SetAlign(TextBox.TextVerticalAlign.Bottom));
    }

    private void AddSelectLayout()
    {
        Layout BtnSetup(Layout m_btn, string m_btnTitle, char m_img, int m_color)
        {
            m_btn.AddText(new TextBox($" {m_btnTitle}"));
            
            TextBox imgBox = new TextBox(null)
                .SetColor(m_color)
                .SetAlign(TextBox.TextHorizonAlign.Center)
                .SetAlign(TextBox.TextVerticalAlign.Center);

            for (int i = 0; i < SettingManager.Instance.FoodsMinCount; i++)
            {
                imgBox.AddText(m_img);
            }

            m_btn.AddText(imgBox);

            return m_btn;
        }

        Layout selectLayout = new Layout(70, 30, 70, 26);
        _mainLayout.AddLayout(selectLayout);

        selectLayout.AddText(new TextBox("  재료"));

        Rect boxSize = new Rect(20, 6);

        Layout btn7 = new Layout(selectLayout, LayoutCorner.TopL, 4, 3, boxSize);
        selectLayout.AddLayout(BtnSetup(btn7, "Num7", Fonts.OPTION1,100));

        Layout btn8 = new Layout(btn7, LayoutCorner.TopR, 1, 0, boxSize);
        selectLayout.AddLayout(BtnSetup(btn8, "Num8", Fonts.OPTION2,110));

        Layout btn9 = new Layout(btn8, LayoutCorner.TopR, 1, 0, boxSize);
        selectLayout.AddLayout(BtnSetup(btn9, "Num9", Fonts.OPTION3,120));


        Layout btn4 = new Layout(btn7, LayoutCorner.BotL, 0, 2, boxSize);
        selectLayout.AddLayout(BtnSetup(btn4, "Num4", Fonts.BEEF1, 140));

        Layout btn5 = new Layout(btn4, LayoutCorner.TopR, 1, 0, boxSize);
        selectLayout.AddLayout(BtnSetup(btn5, "Num5", Fonts.BEEF2, 160));

        Layout btn6 = new Layout(btn5, LayoutCorner.TopR, 1, 0, boxSize);
        selectLayout.AddLayout(BtnSetup(btn6, "Num6", Fonts.BEEF3, 200));


        Layout btn1 = new Layout(btn4, LayoutCorner.BotL, 0, 2, boxSize);
        selectLayout.AddLayout(BtnSetup(btn1, "Num1", Fonts.BREAD1, 80));

        Layout btn2 = new Layout(btn1, LayoutCorner.TopR, 1, 0, boxSize);
        selectLayout.AddLayout(BtnSetup(btn2, "Num2", Fonts.BREAD2, 210));

        Layout btn3 = new Layout(btn2, LayoutCorner.TopR, 1, 0, boxSize);
        selectLayout.AddLayout(BtnSetup(btn3, "Num3", Fonts.BREAD3, 240));
    }

    private void AddSpaceBarLayout()
    {
        Layout spaceBarLayout = new Layout(80, 57, 50, 3);
        _mainLayout.AddLayout(spaceBarLayout);

        TextBox spaceText = new TextBox($"SpaceBar : 서빙");
        spaceText.SetAlign(TextBox.TextHorizonAlign.Center);
        spaceText.SetAlign(TextBox.TextVerticalAlign.Center);
        spaceText.SetColor(159);

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

        menuLayout.AddText(tb);

        Layout menu1 = new Layout(150,8,40,12);

        menuLayout.AddLayout(menu1);
        menu1.AddText(new TextBox("  메뉴 1"));
        menu1.AddText(new TextBox("가격 : 500 원").SetAlign(TextBox.TextHorizonAlign.Right));

        Layout menu2 = new Layout(150, 22, 40, 12);

        menuLayout.AddLayout(menu2);
        menu2.AddText(new TextBox("  메뉴 2"));
        menu2.AddText(new TextBox("가격 : 800 원").SetAlign(TextBox.TextHorizonAlign.Right));

        Layout menu3 = new Layout(150, 36, 40, 12);

        menuLayout.AddLayout(menu3);
        menu3.AddText(new TextBox("  메뉴 3"));
        menu3.AddText(new TextBox("가격 : 1000 원").SetAlign(TextBox.TextHorizonAlign.Right));
    }
}