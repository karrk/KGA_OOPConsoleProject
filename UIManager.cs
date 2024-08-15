using MiniCooked;

public class UIManager
{
    private static UIManager _instance = null;

    public static UIManager Instance => _instance;

    private Layout _mainLayout = null;

    private TextBox _goldTextBox = null;

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
        
        DrawMainGameTitle();
        _goldTextBox = new TextBox(string.Empty);

        InitLayouts();

        _mainLayout.Print();
    }

    private void InitLayouts()
    {
        AddOrderLayout();
        AddPreviewLayout();
        AddSelectLayout();
        AddMenuLayout();
        AddSpaceBarLayout();
    }

    /// <summary>
    /// Gold 텍스트를 수정하여 출력합니다.
    /// </summary>
    public void RenewalGold(int m_gold)
    {
        _goldTextBox.TurnOff();
        _goldTextBox.SetNewText($"수 입 : {m_gold}원");
        _goldTextBox.SetAlign(HorizonAlign.Right);
        _goldTextBox.SetAlign(VerticalAlign.Top);

        _goldTextBox.Print();
    }

    /// <summary>
    /// 좌측,상단 커스터머영역 레이아웃
    /// </summary>
    private void AddOrderLayout()
    {
        Layout orderLayout = new Layout(new Rect(120, 16));
        orderLayout.SetParent(_mainLayout);
        orderLayout.SetPos(10, 10, RectOption.Relative);

        _goldTextBox.SetParent(orderLayout);

        RenewalGold(0);
        
        Customer c = new Customer(orderLayout);
        Layout cLayout = c.Layout;

        Customer d = new Customer(orderLayout);
        d.Layout.SetPos(c.Layout, RectCorner.TopR, 4, 0);

        Customer e = new Customer(orderLayout);
        e.Layout.SetPos(d.Layout, RectCorner.TopR, 4, 0);

        Customer f = new Customer(orderLayout);
        f.Layout.SetPos(e.Layout, RectCorner.TopR, 4, 0);

        CustomerContainer.AddCustomer(c);
        CustomerContainer.AddCustomer(d);
        CustomerContainer.AddCustomer(e);
        CustomerContainer.AddCustomer(f);
    }

    /// <summary>
    /// 좌측,하단 미리보기 영역 레이아웃
    /// </summary>
    private void AddPreviewLayout()
    {
        Layout previewLayout = new Layout(new Rect(40, 30));
        previewLayout.SetParent(_mainLayout);
        previewLayout.SetAlign(VerticalAlign.Bottom);
        previewLayout.SetPos(10, -3, RectOption.Relative);

        TextBox tableText = new TextBox("테 이 블");
        TextBox tableImg1 = new TextBox(" █████████████████████████████████████████");
        TextBox tableImg2 = new TextBox(" █████████████████████████████████████████");
        TextBox tableImg3 = new TextBox(" █████████████████████████████████████████");

        tableText.SetParent(previewLayout);
        tableImg1.SetParent(previewLayout);
        tableImg2.SetParent(previewLayout);
        tableImg3.SetParent(previewLayout);

        tableText.SetAlign(VerticalAlign.Top);
        tableImg1.SetAlign(VerticalAlign.Bottom);
        tableImg2.SetAlign(VerticalAlign.Bottom);
        tableImg3.SetAlign(VerticalAlign.Bottom);

        tableText.SetAlign(HorizonAlign.Left);
        tableImg1.SetAlign(HorizonAlign.Center);
        tableImg2.SetAlign(HorizonAlign.Center);
        tableImg3.SetAlign(HorizonAlign.Center);

        tableText.SetPos(2, 0, RectOption.Relative);
        tableImg1.SetPos(0, -4, RectOption.Relative);
        tableImg2.SetPos(0, -3, RectOption.Relative);
        tableImg3.SetPos(0, -2, RectOption.Relative);

        tableImg1.SetColor(52);
        tableImg2.SetColor(88);
        tableImg3.SetColor(196);

        BurgerTable.SetTableLayout(previewLayout);
    }

    /// <summary>
    /// 중앙,하단 음식재료, 키패드버튼 영역 레이아웃
    /// </summary>
    private void AddSelectLayout()
    {
        Layout btnAreaLayout = new Layout(new Rect(70, 26));
        btnAreaLayout.SetParent(_mainLayout);
        btnAreaLayout.SetAlign(HorizonAlign.Center);
        btnAreaLayout.SetAlign(VerticalAlign.Bottom);
        btnAreaLayout.SetPos(-6, -7, RectOption.Relative);

        TextBox elementText = new TextBox("재 료");

        elementText.SetParent(btnAreaLayout);
        elementText.SetAlign(HorizonAlign.Center);
        elementText.SetAlign(VerticalAlign.Top);

        Rect btnSize = new Rect(18, 5);

        int intervalX = 4;
        int intervalY = 3;

        int width = btnSize.EndX;
        int height = btnSize.EndY;

        int count = 0;

        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                Layout btn = new Layout(btnSize);
                btn.SetParent(btnAreaLayout);
                btn.SetAlign(VerticalAlign.Bottom).SetAlign(HorizonAlign.Left);
                btn.SetPos(intervalX * j + (width * (j - 1)),
                    -intervalY * i - (height * (i - 1)), RectOption.Relative);

                MenuManager.RegistElementBtn(btn,count++);
            }
        }
    }

    /// <summary>
    /// 중앙, 하단부 스페이스바 레이아웃
    /// </summary>
    private void AddSpaceBarLayout()
    {
        Layout spaceBarLayout = new Layout(new Rect(50, 3));
        spaceBarLayout.SetParent(_mainLayout);
        spaceBarLayout.SetAlign(VerticalAlign.Bottom);
        spaceBarLayout.SetAlign(HorizonAlign.Center);
        spaceBarLayout.SetPos(-5, -3, RectOption.Relative);

        TextBox spaceText = new TextBox($"SpaceBar : 서 빙");
        spaceText.SetParent(spaceBarLayout);
        spaceText.SetAlign(VerticalAlign.Center);
        spaceText.SetAlign(HorizonAlign.Center);
        spaceText.SetColor(51);
    }

    /// <summary>
    /// 우측 메뉴 레시피 레이아웃
    /// </summary>
    private void AddMenuLayout()
    {
        Layout menuBaseLayout = new Layout(new Rect(50, 58));
        menuBaseLayout.SetParent(_mainLayout);
        menuBaseLayout.SetAlign(VerticalAlign.Center);
        menuBaseLayout.SetAlign(HorizonAlign.Right);
        menuBaseLayout.SetPos(-10, 0, RectOption.Relative);

        TextBox menuText = new TextBox("= 메 뉴 레 시 피 =");
        menuText.SetParent(menuBaseLayout);
        menuText.SetAlign(VerticalAlign.Top).SetAlign(HorizonAlign.Center);
        menuText.SetPos(0, 3, RectOption.Relative);

        Rect menuSize = new Rect(40, 12);


        // 버거 1
        Layout menu1Layout = new Layout(menuSize);
        menu1Layout.SetParent(menuBaseLayout);
        menu1Layout.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Top);
        menu1Layout.SetPos(0, 10, RectOption.Relative);

        TextBox menu1Text = new TextBox("1번");
        menu1Text.SetParent(menu1Layout);
        menu1Text.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        menu1Text.SetPos(2, 0, RectOption.Relative);

        AddBurgerImage(menu1Layout, MenuManager.Burgers[0]);


        // 버거 2
        Layout menu2Layout = new Layout(menuSize);
        menu2Layout.SetParent(menuBaseLayout);
        menu2Layout.SetPos(menu1Layout, RectCorner.BotL, 0, 4);

        TextBox menu2Text = new TextBox("2번");
        menu2Text.SetParent(menu2Layout);
        menu2Text.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        menu2Text.SetPos(2, 0, RectOption.Relative);

        AddBurgerImage(menu2Layout, MenuManager.Burgers[1]);


        // 버거 3
        Layout menu3Layout = new Layout(menuSize);
        menu3Layout.SetParent(menuBaseLayout);
        menu3Layout.SetPos(menu2Layout, RectCorner.BotL, 0, 4);

        TextBox menu3Text = new TextBox("3번");
        menu3Text.SetParent(menu3Layout);
        menu3Text.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        menu3Text.SetPos(2, 0, RectOption.Relative);

        AddBurgerImage(menu3Layout, MenuManager.Burgers[2]);

    }

    /// <summary>
    /// 해당 레이아웃내에 버거의 이미지를 출력합니다.
    /// </summary>
    private void AddBurgerImage(RectUI m_baseLayout,Burger m_burger)
    {
        for (int i = 0; i < m_burger.Count; i++)
        {
            char elementChar = m_burger[i].FoodChar;

            TextBox elementImg = new TextBox(elementChar.ToString());

            for (int j = 0; j < SettingManager.Instance.FoodsMinCount; j++)
            {
                elementImg.AddText(elementChar);
            }

            elementImg.SetColor(m_burger[i].ColorNumber);
            elementImg.SetParent(m_baseLayout);
            elementImg.SetAlign(VerticalAlign.Center).SetAlign(HorizonAlign.Center);
            elementImg.SetPos(-5, -i + m_burger.Count+1, RectOption.Relative);
        }

        TextBox priceText = new TextBox($"가 격 : {m_burger.Price.ToString()}원");
        priceText.SetParent(m_baseLayout);
        priceText.SetAlign(HorizonAlign.Right).SetAlign(VerticalAlign.Top);

    }

    /// <summary>
    /// 메인게임의 좌측 상단의 게임타이틀 작성
    /// </summary>
    private void DrawMainGameTitle()
    {
        TextBox title = new TextBox
            (" #     #   #   ##    #  #   ###   ###   ###   #  #  ")
   .AddText ("### ###       # #   #     #     #   # #   #  # #",true)
   .AddText ("#  #  #   #   #  #  #  #  #     #   # #   #  ##",true)
   .AddText ("#     #   #   #   # #  #  #     #   # #   #  # #",true)
   .AddText ("#     #   #   #    ##  #   ###   ###   ###   #  #",true);

        title.SetColor(202);
        title.SetParent(_mainLayout);
        title.SetAlign(VerticalAlign.Top).SetAlign(HorizonAlign.Left);
        title.SetPos(12, 1, RectOption.Relative);
    }
}