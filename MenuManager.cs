public static class MenuManager
{
    private static Random _rand = new Random();
    private static int _randomElementNum => _rand.Next(0, Fonts.ElementCharList.Count);
    private static int _randomColorNum => _rand.Next(90, 191);
    public static int RandomMenuNum => _rand.Next(1, _burgers.Count+1);

    private static List<Burger> _burgers = new List<Burger>();
    public static List<Burger> Burgers => _burgers;

    private static List<FoodElement> _elements = new List<FoodElement>();

    private static int _lastFoodNumber = 1;

    public static void Init()
    {
        RegistBurger();
        SettingManager.Instance.SetLimitKey(_elements.Count);
    }

    /// <summary>
    /// 재료를 반환받습니다. 재료 목록은 중복이 없습니다.
    /// </summary>
    public static FoodElement GetElement(int m_idx)
    {
        return _elements[m_idx];
    }

    /// <summary>
    /// 재료목록에 해당 char 데이터가 있는지 확인합니다.
    /// </summary>
    /// <param name="element"> 재료가 있다면 출력받습니다. 없다면 null</param>
    private static bool isContainChar(char m_ch,out FoodElement element)
    {
        foreach (var e in _elements)
        {
            if (m_ch == e.FoodChar)
            {
                element = e.Copy();

                return true;
            }
        }

        element = null;
        return false;
    }

    /// <summary>
    /// 임의의 버거를 생성합니다.
    /// </summary>
    /// <param name="m_stackCount">몇층의 버거인지 확인하기 위한 매개변수</param>
    private static Burger CreateRandomBurger(int m_price, int m_stackCount)
    {
        Burger burger = new Burger(m_price);

        for (int i = 0; i < m_stackCount-1; i++)
        {
            char tempChar = Fonts.ElementCharList[_randomElementNum];
            FoodElement element;

            if(!isContainChar(tempChar,out element))
            {
                element = new FoodElement(tempChar, _lastFoodNumber << 1);
                element.SetColor(_randomColorNum);
                _lastFoodNumber = _lastFoodNumber << 1;
                _elements.Add(element);
            }

            burger.AddStack(element);
        }

        burger.CloseStack();

        return burger;
    }

    // 임시 메서드
    private static void RegistBurger()
    {
        _burgers.Add(CreateRandomBurger(200, 4));
        _burgers.Add(CreateRandomBurger(1000, 6));
        _burgers.Add(CreateRandomBurger(4000, 8));
    }

    /// <summary>
    /// 키패드 버튼과 음식재료를 동기화 하기위한 함수
    /// 해당 레이아웃으로 선택한 음식재료정보가 등록됩니다.
    /// </summary>
    public static void RegistElementBtn(Layout m_baseBtn, int m_elementIdx)
    {
        if (m_elementIdx >= _elements.Count)
            return;

        TextBox btnText = new TextBox($"Num{m_elementIdx + 1}");
        TextBox elementImg = new TextBox(string.Empty);


        btnText.SetParent(m_baseBtn);
        elementImg.SetParent(m_baseBtn);

        btnText.SetAlign(HorizonAlign.Left).SetAlign(VerticalAlign.Top);
        elementImg.SetColor(_elements[m_elementIdx].ColorNumber);
        elementImg.SetAlign(HorizonAlign.Center)
            .SetAlign(VerticalAlign.Center);

        for (int i = 0; i < SettingManager.Instance.FoodsMinCount; i++)
        {
            elementImg.AddText(_elements[m_elementIdx].FoodChar);
        }

        btnText.SetPos(3, 0, RectOption.Relative);
    }

    /// <summary>
    /// N번째 버거의 총 Score를 가져옵니다.
    /// </summary>
    public static int GetBurgerTotalNumber(int m_burgerIdx)
    {
        return _burgers[m_burgerIdx-1].FoodScore;
    }
}