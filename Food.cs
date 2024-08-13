public abstract class Food
{
    protected int _num;

    public int Number => _num;
}

public class FoodElement : Food
{
    private ConsoleColor _color;
}

public class Burger : Food
{
    private List<int> _burgerStack = new List<int>();

    public bool IsMatchFoodNumber(params int[] m_numbers)
    {
        return this._num == m_numbers.Sum();
    }

    public void AddStack(Food m_food)
    {
        _burgerStack.Add(m_food.Number);
    }

    public void AddStack(int m_foodNum)
    {
        _burgerStack.Add(m_foodNum);
    }
}