using MiniCooked;

public class BurgerTable
{
    private static Layout _burgerTableLayout = null;
    private int _foodTotalScore;

    private int _stackLine;
    private int _lastScore;

    private List<TextBox> _stackedList 
        = new List<TextBox>(SettingManager.Instance.MaxStackLine);

    public void Init()
    {
        _foodTotalScore = 0;
        _stackLine = 0;
    }
    
    /// <summary>
    /// 미리보기영역(테이블)에 음식재료를 추가합니다.
    /// </summary>
    public void StackFoodElement(int m_selectNumber)
    {
        if (_stackLine >= SettingManager.Instance.MaxStackLine)
            return;

        FoodElement element = MenuManager.GetElement(m_selectNumber - 1);
        
        _foodTotalScore += element.FoodScore;
        _lastScore = element.FoodScore;

        DrawStackedElement(element);
    }

    /// <summary>
    /// 현재 미리보기영역에 등록된 음식을 제시합니다.
    /// </summary>
    public void Serve()
    {
        if (_stackedList.Count <= 0)
            return;

        _foodTotalScore -= _lastScore;
        _stackLine = 0;
        TableClear();
        _stackedList.Clear();
        CustomerContainer.SearchBurger(_foodTotalScore);
        _foodTotalScore = 0;
    }

    /// <summary>
    /// 버거테이블로 지정할 기준레이아웃을 설정합니다.
    /// </summary>
    public static void SetTableLayout(Layout m_layout)
    {
        _burgerTableLayout = m_layout;
    }

    /// <summary>
    /// 테이블에 추가한 재료이미지를 화면에 출력합니다.
    /// </summary>
    private void DrawStackedElement(FoodElement m_element)
    {
        TextBox stackImg = new TextBox("");
        stackImg.SetParent(_burgerTableLayout);
        stackImg.SetParent(_burgerTableLayout);
        stackImg.SetAlign(VerticalAlign.Bottom).SetAlign(HorizonAlign.Center);
        stackImg.SetColor(m_element.ColorNumber);

        for (int i = 0; i < SettingManager.Instance.TableStackCount; i++)
        {
            for (int j = 0; j < SettingManager.Instance.FoodsMaxCount; j++)
            {
                stackImg.AddText(m_element.FoodChar);
            }
            stackImg.AddText("", true);
            _stackLine++;
        }

        stackImg.SetPos(-11, -_stackLine - 4, RectOption.Relative);
        _stackedList.Add(stackImg);

        stackImg.Print();
    }

    /// <summary>
    /// 테이블내 모든재료를 감춥니다.
    /// </summary>
    private void TableClear()
    {
        foreach (var e in _stackedList)
        {
            e.TurnOff();
        }
    }
}