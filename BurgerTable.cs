using MiniCooked;

public class BurgerTable
{
    private int _foodTotalScore;

    private int _stackLine;

    private List<TextBox> _stackedList 
        = new List<TextBox>(SettingManager.Instance.MaxStackLine);

    public void Init()
    {
        //for (int i = 0; i < SettingManager.Instance.MaxStackLine; i++)
        //{
        //    StackFoodElement(1);
        //}

        //TableClear();
        _stackedList.Clear();
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

        FoodElement element = MenuManager.Instance.GetElement(m_selectNumber - 1);
        DrawStackedElement(element);

        _stackLine++;
        _foodTotalScore += Burger.CalculateElementScore(element, _stackLine);
    }

    /// <summary>
    /// 현재 미리보기영역에 등록된 음식을 제시합니다.
    /// </summary>
    public void Serve()
    {
        if (_stackedList.Count <= 0)
            return;

        _foodTotalScore += _stackLine;

        _stackLine = 0;
        TableClear();
        _stackedList.Clear();
        CustomerContainer.Instance.SearchBurger(_foodTotalScore);
        _foodTotalScore = 0;
    }

    /// <summary>
    /// 테이블에 추가한 재료이미지를 화면에 출력합니다.
    /// </summary>
    private void DrawStackedElement(FoodElement m_element)
    {
        TextBox stackImg = new TextBox("");
        stackImg.SetParent(UIManager.Instance[UILayout.Preview]);
        stackImg.SetAlign(VerticalAlign.Bottom).SetAlign(HorizonAlign.Center);
        stackImg.SetColor(m_element.ColorNumber);

        for (int i = 0; i < SettingManager.Instance.TableStackCount; i++)
        {
            for (int j = 0; j < SettingManager.Instance.FoodsMaxCount; j++)
            {
                stackImg.AddText(m_element.FoodChar);
            }
            stackImg.AddText("", true);
        }

        stackImg.SetPos(-11, -_stackLine*2 - 6, RectOption.Relative);
        _stackedList.Add(stackImg);

        stackImg.Print();

        stackImg.SetParent(null);
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