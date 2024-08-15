public abstract class Food
{
    protected int _foodScore;

    public int FoodScore => _foodScore;
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
        this._foodScore = m_foodNum;
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

    public FoodElement this[int idx]
    {
        get
        {
            return _burgerStack[idx];
        }
    }

    /// <summary>
    /// 전달받은 score와 버거의 숫자가 같은지 확인합니다.
    /// </summary>
    public bool IsMatchFoodScore(int m_score)
    {
        return (this._foodScore & m_score) == this._foodScore;
    }

    /// <summary>
    /// 버거에 음식재료를 추가합니다.
    /// </summary>
    public void AddStack(FoodElement m_food)
    {
        _foodScore += m_food.FoodScore;
        _burgerStack.Add(m_food);
    }

    /// <summary>
    /// 버거를 마무리합니다.
    /// 마지막 스택은 Score에 추가하지 않습니다.
    /// </summary>
    public void CloseStack()
    {
        // 이진수를 활용해 점수를 비교하는 방식으로 접근하려 했으나 문제발생 - 같은재료가 여러개 나올시 비트가 넘어감
        _burgerStack.Add(_burgerStack.First());
    }
}