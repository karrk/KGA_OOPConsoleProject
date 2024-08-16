public abstract class Food
{
    protected int _foodScore;

    public int FoodScore => _foodScore;

    public void SetFoodScore(int m_score)
    {
        this._foodScore = m_score;
    }
}

public class FoodElement : Food
{
    private char _foodChar;
    private int _colorNumber;

    public char FoodChar => _foodChar;
    public int ColorNumber => _colorNumber;

    public FoodElement(char m_char, int m_foodScore)
    {
        this._foodChar = m_char;
        this._foodScore = m_foodScore;
    }

    public void SetColor(int m_colorNumber)
    {
        this._colorNumber = m_colorNumber;
    }

    /// <summary>
    /// ( FE1 = FE2.Copy() )
    /// FE1으로 얕은복사 진행
    /// </summary>
    public FoodElement Copy()
    {
        FoodElement copy = new FoodElement(this._foodChar,_foodScore);
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

    public FoodElement this[int idx] => _burgerStack[idx];

    /// <summary>
    /// 재료번호와 현재 층에 맞는 계산된 Score를 반환합니다.
    /// </summary>
    public static int CalculateElementScore(FoodElement m_element,int m_stackLine)
    {
        return (m_element.FoodScore / m_stackLine) + 1;
    }

    /// <summary>
    /// 버거에 음식재료를 추가합니다.
    /// </summary>
    public void AddStack(FoodElement m_food)
    {
        //_foodScore += m_food.FoodScore;

        _burgerStack.Add(m_food);
        //_foodScore += (m_food.FoodScore / _burgerStack.Count)+1;
        _foodScore += CalculateElementScore(m_food, _burgerStack.Count);
    }

    /// <summary>
    /// 버거를 마무리합니다.
    /// </summary>
    public void CloseStack()
    {
        AddStack(_burgerStack.First());
        _foodScore += _burgerStack.Count;
    }
}