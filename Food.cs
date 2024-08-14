public abstract class Food
{
    protected int _num;

    public int Number => _num;
}

public class FoodElement : Food
{
    private char _foodChar;
    private int _colorNumber;

    public char FoodChar => _foodChar;
    public int ColorNumber => _colorNumber;
    
    public FoodElement(char m_char, int m_foodNum)
    {
        this._foodChar = m_char;
        this._num = m_foodNum;
    }

    public void SetColor(int m_colorNumber)
    {
        this._colorNumber = m_colorNumber;
    }

    public FoodElement Copy()
    {
        FoodElement copy = new FoodElement(this._foodChar,_num);
        copy.SetColor(this._colorNumber);

        return copy;
    }
}

public class Burger : Food
{
    private List<FoodElement> _burgerStack = new List<FoodElement>();

    public int Count => _burgerStack.Count;

    private int _price;
    public int Price => _price;

    public Burger(int m_price)
    {
        this._price = m_price;
    }

    public FoodElement this[int idx]
    {
        get
        {
            return _burgerStack[idx];
        }
    }

    public bool IsMatchFoodNumber(int m_numbers)
    {
        return (this._num & m_numbers) == this._num;
    }

    public void AddStack(FoodElement m_food)
    {
        _num += m_food.Number;
        _burgerStack.Add(m_food);
    }

    // 마지막 스택은 값추가 안함
    public void CloseStack()
    {
        _burgerStack.Add(_burgerStack.First());
    }
}