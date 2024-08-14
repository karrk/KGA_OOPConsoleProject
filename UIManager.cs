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
        _mainLayout = new Layout(new Rect(1, 1, 200, 60));
        _mainLayout.SetColor(120);
        InitLayouts();

        _mainLayout.Print();
    }

    private void InitLayouts()
    {
        AddOrderLayout();
        //AddPreviewLayout();
        //AddSelectLayout();
        //AddMenuLayout();
        //AddSpaceBarLayout();
    }

    private void AddOrderLayout()
    {
        Layout orderLayout = new Layout(new Rect(0, 0, 120, 20));
        orderLayout.SetParent(_mainLayout);
        orderLayout.SetPos(10, 10, RectOption.Relative);

        TextBox goldText = new TextBox("수 입 : ");
        goldText.SetParent(orderLayout);
        goldText.SetAlign(HorizonAlign.Right);
        goldText.SetAlign(VerticalAlign.Top);
        
        Customer c = new Customer(orderLayout);
        Layout cLayout = c.Layout;

        Customer d = new Customer(orderLayout);
        d.Layout.SetPos(c.Layout, RectCorner.TopR, 4, 0);

        Customer e = new Customer(orderLayout);
        e.Layout.SetPos(d.Layout, RectCorner.TopR, 4, 0);

        Customer f = new Customer(orderLayout);
        f.Layout.SetPos(e.Layout, RectCorner.TopR, 4, 0);
    }

    private void AddPreviewLayout()
    {
        //Layout previewLayout = new Layout(new Rect(10, 30, 50, 30));
        //_mainLayout.AddLayout(previewLayout);

        //previewLayout.AddText(new TextBox("테 이 블"));

        //TextBox test =
        // (TextBox)
        // new TextBox(" ██████████████████████████████████████████████████")
        //    .AddText("██████████████████████████████████████████████████", true)
        //    .AddText("██████████████████████████████████████████████████", true)
        //    .SetColor(166)
        //    .SetAlign(VerticalAlign.Bottom)
        //    .SetAlign(HorizonAlign.Center);

        //previewLayout.AddText(test);
    }

    private void AddSelectLayout()
    {
        //Layout BtnSetup(Layout m_btn, string m_btnTitle, char m_img, int m_color)
        //{
        //    m_btn.AddText(new TextBox($" {m_btnTitle}"));

        //    TextBox imgBox = (TextBox)new TextBox(string.Empty)
        //        .SetColor(m_color)
        //        .SetAlign(HorizonAlign.Center)
        //        .SetAlign(VerticalAlign.Center);

        //    for (int i = 0; i < SettingManager.Instance.FoodsMinCount; i++)
        //    {
        //        imgBox.AddText(m_img);
        //    }

        //    m_btn.AddText(imgBox);

        //    return m_btn;
        //}

        //Layout selectLayout = new Layout(new Rect(70, 30, 70, 26));
        //_mainLayout.AddLayout(selectLayout);

        //selectLayout.AddText(new TextBox("재 료"));

        //Rect boxSize = new Rect(20, 6);

        //Layout btn7 = new Layout(selectLayout, RectCorner.TopL, 4, 3, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn7, "Num7", Fonts.OPTION1,100));

        //Layout btn8 = new Layout(btn7, RectCorner.TopR, 2, 0, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn8, "Num8", Fonts.OPTION2,110));

        //Layout btn9 = new Layout(btn8, RectCorner.TopR, 2, 0, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn9, "Num9", Fonts.OPTION3,120));


        //Layout btn4 = new Layout(btn7, RectCorner.BotL, 0, 2, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn4, "Num4", Fonts.BEEF1, 140));

        //Layout btn5 = new Layout(btn4, RectCorner.TopR, 2, 0, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn5, "Num5", Fonts.BEEF2, 160));

        //Layout btn6 = new Layout(btn5, RectCorner.TopR, 2, 0, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn6, "Num6", Fonts.BEEF3, 200));


        //Layout btn1 = new Layout(btn4, RectCorner.BotL, 0, 2, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn1, "Num1", Fonts.BREAD1, 80));

        //Layout btn2 = new Layout(btn1, RectCorner.TopR, 2, 0, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn2, "Num2", Fonts.BREAD2, 210));

        //Layout btn3 = new Layout(btn2, RectCorner.TopR, 2, 0, boxSize);
        //selectLayout.AddLayout(BtnSetup(btn3, "Num3", Fonts.BREAD3, 240));
    }

    private void AddSpaceBarLayout()
    {
        //Layout spaceBarLayout = new Layout(new Rect(80, 57, 50, 3));
        //_mainLayout.AddLayout(spaceBarLayout);

        //TextBox spaceText = new TextBox($"SpaceBar : 서 빙");
        //spaceText.SetAlign(HorizonAlign.Center);
        //spaceText.SetAlign(VerticalAlign.Center);
        //spaceText.SetColor(159);

        //spaceBarLayout.AddText(spaceText);
    }

    private void AddMenuLayout()
    {
        //Layout menuLayout = new Layout(new Rect(145, 2, 50, 58));
        //_mainLayout.AddLayout(menuLayout);

        //TextBox tb = new TextBox($"메 뉴 레 시 피");
        //tb.SetAlign(HorizonAlign.Center);
        //tb.SetAlign(VerticalAlign.Top);

        //menuLayout.AddText(tb);

        //Layout menu1 = new Layout(new Rect(150, 8, 40, 12));

        //menuLayout.AddLayout(menu1);
        //menu1.AddText(new TextBox("메 뉴 1"));
        //menu1.AddText((TextBox)new TextBox("가 격 : 500 원").SetAlign(HorizonAlign.Right));

        //Layout menu2 = new Layout(new Rect(150, 22, 40, 12));

        //menuLayout.AddLayout(menu2);
        //menu2.AddText(new TextBox("메 뉴 2"));
        //menu2.AddText((TextBox)new TextBox("가 격 : 800 원").SetAlign(HorizonAlign.Right));

        //Layout menu3 = new Layout(new Rect(150, 36, 40, 12));

        //menuLayout.AddLayout(menu3);
        //menu3.AddText(new TextBox("메 뉴 3"));
        //menu3.AddText((TextBox)new TextBox("가 격 : 1000 원").SetAlign(HorizonAlign.Right));
    }
}