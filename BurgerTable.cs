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

    public void StackFoodElement(int m_elementNumber)
    {
        FoodElement element = MenuManager.GetElement(m_elementNumber - 1);
        
        _foodTotalScore += element.FoodScore;
        _lastScore = element.FoodScore;

        StackElement(element);
    }

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

    public static void SetTableLayout(Layout m_layout)
    {
        _burgerTableLayout = m_layout;
    }

    private void StackElement(FoodElement m_element)
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

    private void TableClear()
    {
        foreach (var e in _stackedList)
        {
            e.TurnOff();
        }
    }
}