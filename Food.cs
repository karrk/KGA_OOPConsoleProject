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
    public bool IsMatchFoodNumber(params int[] m_numbers)
    {
        return this._num == m_numbers.Sum();
    }
}