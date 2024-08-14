using MiniCooked;

public class BurgerTable
{
    private static Layout _burgerTableLayout = null;
    private int _foodTotalNumber;

    private int _stackLine;
    private int _lastNumber;

    private List<TextBox> _stackedList 
        = new List<TextBox>(SettingManager.Instance.MaxStackLine);

    public void Init()
    {
        _foodTotalNumber = 0;
        _stackLine = 0;
    }

    public void StackFoodElement(int m_elementNumber)
    {
        FoodElement element = MenuManager.GetElement(m_elementNumber - 1);
        
        _foodTotalNumber += element.Number;
        _lastNumber = element.Number;

        StackElement(element);
    }

    public void Serve()
    {
        if (_stackedList.Count <= 0)
            return;

        _foodTotalNumber -= _lastNumber;
        _stackLine = 0;
        TableClear();
        _stackedList.Clear();
        CustomerContainer.SearchBurger(_foodTotalNumber);
        _foodTotalNumber = 0;
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