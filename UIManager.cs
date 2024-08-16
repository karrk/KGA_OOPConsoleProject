using MiniCooked;

public class UIManager
{
    private static UIManager _instance = null;

    public static UIManager Instance => _instance;

    private TextBox _goldTextBox = null;
    private TextBox _waitTextBox = null;

    private Layout[] _layouts = new Layout[(int)UILayout.Size];
    public Layout this[UILayout m_layout] => _layouts[(int)m_layout];

    private TextBox[] _selectTexts = new TextBox[(int)SelectText.Size];

    public UIManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        _goldTextBox = new TextBox(string.Empty);
        _waitTextBox = new TextBox(string.Empty);
        
        InitLayouts();
        CreateSelectTexts();
    }

    public void ResetOptions()
    {
        SettingBtnImage();
        SettingMenuImage();
    }

    public void PrintMainMenuUI(bool m_print)
    {
        if (m_print)
        {
            _layouts[(int)UILayout.MainMenuPage].SetPrint(true);
            _layouts[(int)UILayout.MainMenuPage].Print();
        }
        else
        {
            _layouts[(int)UILayout.MainMenuPage].TurnOff();
            _layouts[(int)UILayout.MainMenuPage].SetPrint(false);
        }
    }

    public void PrintMainGameUI(bool m_print)
    {
        if(m_print)
        {
            _layouts[(int)UILayout.Main].Print();
        }
        else
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    public void PrintResult(bool m_print)
    {
        if(m_print)
        {
            _layouts[(int)UILayout.ResultPage].SetPrint(true);
            SettingTotalGoldToResult();
            _layouts[(int)UILayout.ResultPage].Print();
        }
        else
        {
            _layouts[(int)UILayout.ResultPage].TurnOff();
            _layouts[(int)UILayout.ResultPage].SetPrint(false);
        }
    }

    private void InitLayouts()
    {
        CreateLayouts();
        SetLayouts();
    }

    #region MainGameScene

    private void CreateLayouts()
    {
        _layouts[(int)UILayout.Main] = new Layout(new Rect(1, 1, 200, 60));

        _layouts[(int)UILayout.MainMenuPage] = new Layout(new Rect(1, 1, 50, 10));

        _layouts[(int)UILayout.Order] = new Layout(new Rect(120, 16));
        _layouts[(int)UILayout.Preview] = new Layout(new Rect(40, 30));
        _layouts[(int)UILayout.Elements] = new Layout(new Rect(70, 26));
        _layouts[(int)UILayout.SpaceBar] = new Layout(new Rect(50, 3));
        _layouts[(int)UILayout.Menus] = new Layout(new Rect(50, 58));

        _layouts[(int)UILayout.ResultPage] = new Layout(new Rect(60, 25));
    }

    private void SetLayouts()
    {
        Layout tempLayout;

        // 메인 레이아웃
        tempLayout = _layouts[(int)UILayout.Main];
        tempLayout.SetColor(120);
        SettingMainGameTitle();

        // 메인메뉴 레이아웃
        tempLayout = _layouts[(int)UILayout.MainMenuPage];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Center);
        tempLayout.SetColor(0);
        SettingMainGameTitleImage();
        //SettingMainMenuText(0);

        // Customer 프린트 영역 레이아웃
        tempLayout = _layouts[(int)UILayout.Order];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetPos(10, 10, RectOption.Relative);
        _goldTextBox.SetParent(tempLayout);
        _waitTextBox.SetParent(tempLayout);

        // 미리보기 영역 레이아웃
        tempLayout = _layouts[(int)UILayout.Preview];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetAlign(VerticalAlign.Bottom);
        tempLayout.SetPos(10, -3, RectOption.Relative);
        SettingPreviewTableImage();

        // 재료버튼 영역 레이아웃
        tempLayout = _layouts[(int)UILayout.Elements];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetAlign(HorizonAlign.Center);
        tempLayout.SetAlign(VerticalAlign.Bottom);
        tempLayout.SetPos(-6, -7, RectOption.Relative);
        SettingElemenetText();
        
        // 스페이스바 영역 레이아웃
        tempLayout = _layouts[(int)UILayout.SpaceBar];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetAlign(VerticalAlign.Bottom).SetAlign(HorizonAlign.Center);
        tempLayout.SetPos(-5, -3, RectOption.Relative);
        SettingSpaceBarText();

        // 메뉴레시피 영역 레이아웃
        tempLayout = _layouts[(int)UILayout.Menus];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetAlign(VerticalAlign.Center).SetAlign(HorizonAlign.Right);
        tempLayout.SetPos(-10, 0, RectOption.Relative);
        SettingMenuRecipeText();

        // 결과창 영역 레이아웃
        tempLayout = _layouts[(int)UILayout.ResultPage];
        tempLayout.SetParent(_layouts[(int)UILayout.Main]);
        tempLayout.SetAlign(VerticalAlign.Center).SetAlign(HorizonAlign.Center);
        tempLayout.SetPrint(false);
    }

    private void CreateSelectTexts()
    {
        TextBox tempBox;

        tempBox = _selectTexts[(int)SelectText.Menu_Start] = new TextBox("게 임 시 작");
        tempBox.SetParent(_layouts[(int)UILayout.MainMenuPage]);
        tempBox.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Top);
        tempBox.SetPos(0, 8, RectOption.Relative);

        tempBox = _selectTexts[(int)SelectText.Menu_Escape] = new TextBox("나 가 기");
        tempBox.SetParent(_layouts[(int)UILayout.MainMenuPage]);
        tempBox.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Bottom);
        tempBox.SetPos(0, 2, RectOption.Relative);

        tempBox = _selectTexts[(int)SelectText.Result_GotoMenu] = new TextBox("메 뉴 로  돌 아 가 기");
        tempBox.SetParent(_layouts[(int)UILayout.ResultPage]);
        tempBox.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Bottom);
        tempBox.SetPos(0, -5, RectOption.Relative);

        tempBox = _selectTexts[(int)SelectText.Result_Escape] = new TextBox("게 임 종 료");
        tempBox.SetParent(_layouts[(int)UILayout.ResultPage]);
        tempBox.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Bottom);
        tempBox.SetPos(0, -3, RectOption.Relative);
    }


    /// <summary>
    /// 메인게임의 좌측 상단의 게임타이틀 작성
    /// </summary>
    private void SettingMainGameTitle()
    {
        TextBox title = new TextBox
          (" ## ## # ## # #  ##  ##   ##  # #  ")
   .AddText("## ##   ## #   #   #  # #  # ## ", true)
   .AddText("# # # # # ## # #   #  # #  # ##", true)
   .AddText("#   # # # ## # #   #  # #  # # #", true)
   .AddText("#   # # # ## #  ##  ##   ##  # #", true);

        title.SetColor(202);
        title.SetParent(_layouts[(int)UILayout.Main]);
        title.SetAlign(VerticalAlign.Top).SetAlign(HorizonAlign.Left);
        title.SetPos(40, 1, RectOption.Relative);
    }

    #region 메인메뉴 추가설정

    public void SwitchMainMenuText(int m_select)
    {
        TextBox startText = _selectTexts[(int)SelectText.Menu_Start];
        TextBox escapeText = _selectTexts[(int)SelectText.Menu_Escape];
        int red = 196;
        int white = 231;

        if(m_select == 0)
        {
            startText.SetColor(red);
            escapeText.SetColor(white);
        }
        else
        {
            startText.SetColor(white);
            escapeText.SetColor(red);
        }

        startText.Print();
        escapeText.Print();
    }

    /// <summary>
    /// 메인메뉴의 게임타이틀 작성
    /// </summary>
    private void SettingMainGameTitleImage()
    {
        TextBox titleImage = new TextBox
            (" ")
   .AddText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠠⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", true)
   .AddText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⡀⢀⠄⡠⠄⠢⠌⠂⠄⠱⡀⠴⡨⢉⡉⠑⢊⠒⠂⠦⠤⠤⣀⣀⡀⠀⠀⠀⠀", true)
   .AddText("⠀⠀⠀⠀⠀⡀⢀⠠⡀⠄⠂⠌⡘⠠⢁⠊⠔⠠⢌⡐⠠⠡⡘⡤⢑⣤⣤⣡⣜⡡⢊⡔⡡⢂⠔⡠⢄⡰⢜⠀⠀⠀", true)
   .AddText("⠀⠀⠰⡘⢂⠡⢈⠐⢠⣈⣁⣢⣤⣥⣤⣼⣾⢃⢖⣬⣵⣭⣷⡜⢸⡧⢿⡽⣞⣿⣿⡞⣷⣿⡞⣷⣮⣶⣼⡂⠀", true)
   .AddText("⠠⠤⠶⡴⢶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣍⢺⣟⡼⣽⣯⡷⢉⡿⠹⠚⢽⣾⣳⡿⣷⢻⡌⠁⠀⠀⣿⡡⠀", true)
   .AddText("⠀⠀⠐⠰⠠⡌⢍⠻⢿⣿⡟⡩⢉⡍⢻⢿⣿⡌⢿⣮⣳⢻⣾⡗⠌⡇⠀⡀⢸⣷⣻⣽⣿⣸⡇⢄⠈⠀⣿⡑⠀", true)
   .AddText("⠀⠀⠨⢡⢡⠼⢮⡽⣮⣽⡤⢥⢳⡼⣧⣯⣿⡜⣻⠳⢏⠻⡝⣧⠘⣍⠳⠑⠚⡉⠏⡙⢋⠓⠲⠘⠦⠥⠻⠥⠃", true)
   .AddText("⠀⠀⢈⣖⣻⢾⡽⣶⢧⣼⣹⢧⡯⢷⡶⣆⣿⡜⣱⡌⣢⣓⣜⠇⡸⢼⡩⢓⠣⠲⠤⡔⡠⡄⣡⣈⠄⡤⢠⠄⣄⢠⢀⡀⢀⡀⠀⠀", true)
   .AddText("⠀⠀⠠⠌⡉⡉⠽⡩⠯⠿⢇⡉⣙⣫⣽⣹⣿⢜⠃⠌⠠⣀⠰⡘⢄⡛⡰⣁⢦⣙⡒⡤⣑⡸⠔⢮⣞⡱⠧⡞⡜⣦⡓⣬⠣⢜⣉⡇", true)
   .AddText("⠀⠀⢸⡼⡽⢿⠿⣿⢿⡿⣿⠿⣿⣟⡿⢿⡿⣞⡯⢟⡿⡽⣻⣽⢫⣿⣽⣭⣯⣝⣯⢷⢯⡗⡡⠘⣿⢸⡷⢾⡶⣶⡵⣮⠗⠈⣿⠅", true)
   .AddText("⠀⠀⢸⡳⣽⣿⣿⢮⣟⡶⣭⢧⡽⣤⡝⣦⡽⣼⡱⣎⡵⣱⢳⡞⣿⣿⣿⢟⠿⣿⣾⢯⡟⡷⢐⠛⡛⣘⡛⣛⢛⣓⣛⢋⢇⡛⡙⠆⠀ ", true)
   .AddText("⠀⢺⣋⠓⣿⣿⣽⣎⠗⡛⡙⢋⠛⡓⢛⠳⠛⠳⡙⠎⠷⠭⠳⢻⣿⡿⣽⠯⢷⡹⣿⣿⣹⣭⣯⣯⣽⣥⣯⣽⣯⣽⣭⡿⣮⣽⢽⣳⡆  ", true)
   .AddText("⠀⠀⠀⠈⠀⢛⠯⣟⣿⣿⣿⡏⠹⢿⠯⠉⠛⢓⣹⣯⣾⣶⣧⣿⡟⣟⣿⣿⣾⣳⣿⣿⡽⣟⣿⣻⠟⢯⣷⣻⣾⣽⣯⡟⠋⠋⠋⠉⠁⠀  ", true)
   .AddText("⠀⠀⠀⠀⠀⠘⠿⠾⠿⠿⠟⠀⠀⠀⠀⠀⠀⠁⠀⠙⠒⠛⠛⠋⠀⢸⣮⣟⣷⣻⣿⠃⠀⠀⠁⠀⠀⠀⠻⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀     ", true)
   .AddText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠚⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀         ", true)
   .AddText(" ", true)
   .AddText(" ", true)
   .AddText(" ", true)
   .AddText("⠀⠀⠀⠀⠀⠀⠀⠀⠀-⠀⠀M⠀I⠀N⠀I⠀C⠀O⠀O⠀K⠀⠀-", true);

        titleImage.SetColor(152);
        titleImage.SetParent(_layouts[(int)UILayout.MainMenuPage]);
        titleImage.SetAlign(VerticalAlign.Top).SetAlign(HorizonAlign.Left);
        titleImage.SetPos(0, -20, RectOption.Relative);
    }

    #endregion

    #region 미리보기 영역 추가설정

    private void SettingPreviewTableImage()
    {
        TextBox tableText = new TextBox("테 이 블");
        TextBox tableImg1 = new TextBox(" █████████████████████████████████████████");
        TextBox tableImg2 = new TextBox(" █████████████████████████████████████████");
        TextBox tableImg3 = new TextBox(" █████████████████████████████████████████");

        tableText.SetParent(_layouts[(int)UILayout.Preview]);
        tableImg1.SetParent(_layouts[(int)UILayout.Preview]);
        tableImg2.SetParent(_layouts[(int)UILayout.Preview]);
        tableImg3.SetParent(_layouts[(int)UILayout.Preview]);

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
    }

    #endregion

    #region 재료버튼 영역 추가 설정

    private void SettingElemenetText()
    {
        TextBox elementText = new TextBox("재 료");

        elementText.SetParent(_layouts[(int)UILayout.Elements]);
        elementText.SetAlign(HorizonAlign.Center);
        elementText.SetAlign(VerticalAlign.Top);
    }

    private void SettingBtnImage()
    {
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
                btn.SetParent(_layouts[(int)UILayout.Elements]);
                btn.SetAlign(VerticalAlign.Bottom).SetAlign(HorizonAlign.Left);
                btn.SetPos(intervalX * j + (width * (j - 1)),
                    -intervalY * i - (height * (i - 1)), RectOption.Relative);

                MenuManager.Instance.RegistElementBtn(btn, count++);
            }
        }
    }
    #endregion

    #region 스페이스바 영역 추가설정

    private void SettingSpaceBarText()
    {
        TextBox spaceText = new TextBox($"SpaceBar : 서 빙");
        spaceText.SetParent(_layouts[(int)UILayout.SpaceBar]);
        spaceText.SetAlign(VerticalAlign.Center);
        spaceText.SetAlign(HorizonAlign.Center);
        spaceText.SetColor(51);
    }

    #endregion

    #region 메뉴레시피영역 추가설정

    private void SettingMenuRecipeText()
    {
        TextBox menuText = new TextBox("= 메 뉴 레 시 피 =");
        menuText.SetParent(_layouts[(int)UILayout.Menus]);
        menuText.SetAlign(VerticalAlign.Top).SetAlign(HorizonAlign.Center);
        menuText.SetPos(0, 3, RectOption.Relative);
    }

    private void SettingMenuImage()
    {
        Rect menuSize = new Rect(40, 12);

        // 버거 1 레이아웃
        Layout menu1Layout = new Layout(menuSize);
        menu1Layout.SetParent(_layouts[(int)UILayout.Menus]);
        menu1Layout.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Top);
        menu1Layout.SetPos(0, 10, RectOption.Relative);

        TextBox menu1Text = new TextBox("1번");
        menu1Text.SetParent(menu1Layout);
        menu1Text.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        menu1Text.SetPos(2, 0, RectOption.Relative);

        // 버거 2 레이아웃
        Layout menu2Layout = new Layout(menuSize);
        menu2Layout.SetParent(_layouts[(int)UILayout.Menus]);
        menu2Layout.SetPos(menu1Layout, RectCorner.BotL, 0, 4);

        TextBox menu2Text = new TextBox("2번");
        menu2Text.SetParent(menu2Layout);
        menu2Text.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        menu2Text.SetPos(2, 0, RectOption.Relative);

        // 버거 3 레이아웃
        Layout menu3Layout = new Layout(menuSize);
        menu3Layout.SetParent(_layouts[(int)UILayout.Menus]);
        menu3Layout.SetPos(menu2Layout, RectCorner.BotL, 0, 4);

        TextBox menu3Text = new TextBox("3번");
        menu3Text.SetParent(menu3Layout);
        menu3Text.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        menu3Text.SetPos(2, 0, RectOption.Relative);

        AddBurgerImage(menu1Layout, MenuManager.Instance.Burgers[0]);
        AddBurgerImage(menu2Layout, MenuManager.Instance.Burgers[1]);
        AddBurgerImage(menu3Layout, MenuManager.Instance.Burgers[2]);
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

    #endregion

    #region 결과화면 추가설정

    public void SwitchResultWindownText(int m_select)
    {
        TextBox goMainMenuText = _selectTexts[(int)SelectText.Result_GotoMenu];
        TextBox escapeText = _selectTexts[(int)SelectText.Result_Escape];
        int red = 196;
        int white = 231;

        if (m_select == 0)
        {
            goMainMenuText.SetColor(red);
            escapeText.SetColor(white);
        }
        else
        {
            goMainMenuText.SetColor(white);
            escapeText.SetColor(red);
        }

        goMainMenuText.Print();
        escapeText.Print();
    }

    private void SettingTotalGoldToResult()
    {
        TextBox result = new TextBox($"총 수 입 : {GameManager.Instance.PlayerGold}");
        result.SetParent(_layouts[(int)UILayout.ResultPage]);
        result.SetColor(120);
        result.SetAlign(HorizonAlign.Center).SetAlign(VerticalAlign.Top);
        result.SetPos(0, 5,RectOption.Relative);
    }

    #endregion

    /// <summary>
    /// Gold 텍스트를 수정하여 출력합니다.
    /// </summary>
    public void RenewalGoldText(int m_gold)
    {
        _goldTextBox.TurnOff();
        _goldTextBox.SetNewText($"수 입 : {m_gold}원");
        _goldTextBox.SetAlign(HorizonAlign.Right);
        _goldTextBox.SetAlign(VerticalAlign.Top);

        _goldTextBox.Print();
    }

    /// <summary>
    /// 대기 인원수 텍스트를 수정하여 출력합니다.
    /// </summary>
    public void RenewalWaitText(int m_count)
    {
        _waitTextBox.TurnOff();
        _waitTextBox.SetNewText($" 대 기 인 원 : {m_count}명");
        _waitTextBox.SetAlign(HorizonAlign.Center);
        _waitTextBox.SetAlign(VerticalAlign.Top);

        _waitTextBox.Print();
    }

    #endregion
}