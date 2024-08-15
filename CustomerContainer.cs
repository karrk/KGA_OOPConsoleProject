using MiniCooked;

public static class CustomerContainer
{
    private static LinkedList<Customer> _customers = new LinkedList<Customer>();
    private static Thread _thread;
    private static Random _rand;

    /// <summary>
    /// 연결리스트의 마지막 요소로 추가합니다.
    /// </summary>
    public static void AddCustomer(Customer m_customer)
    {
        _customers.AddLast(m_customer);
    }

    /// <summary>
    /// 대상을 목록에서 제외합니다.
    /// </summary>
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

    /// <summary>
    /// 손님 목록 중 해당 Score에 적합한 손님이 있는지 확인하는 메서드
    /// </summary>
    public static void SearchBurger(int m_foodTotalScore)
    {
        LinkedListNode<Customer> node = _customers.First;

        while (true)
        {
            if (node == null)
                break;
            else if(MenuManager.GetBurgerScore(node.Value.SelectNumber) == m_foodTotalScore)
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