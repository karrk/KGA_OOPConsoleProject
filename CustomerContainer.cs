using MiniCooked;

public static class CustomerContainer
{
    private static LinkedList<Customer> _customers = new LinkedList<Customer>();
    private static Thread _thread;
    private static Random _rand;

    public static void AddCustomer(Customer m_customer)
    {
        _customers.AddLast(m_customer);
    }

    public static void RemoveCustomer(Customer m_customer)
    {
        LinkedListNode<Customer> node = _customers.First;

        while (true)
        {
            if (node == null)
                throw new Exception("찾을 수 없는 노드");

            else if(node.Value.Equals(m_customer))
            {
                node.Value.Hide();
                _customers.Remove(m_customer);
                break;
            }
                
            node = node.Next;
        }
    }

    public static void SearchBurger(int m_foodTotalNumber)
    {
        LinkedListNode<Customer> node = _customers.First;

        while (true)
        {
            if (node == null)
                break;
            else if(MenuManager.GetBurgerTotalNumber(node.Value.SelectNumber) == m_foodTotalNumber)
            {
                GameManager.Instance.AddGold(
                    MenuManager.Burgers[node.Value.SelectNumber-1].Price);

                RemoveCustomer(node.Value);
                break;
            }

            node = node.Next;
        }
    }

}