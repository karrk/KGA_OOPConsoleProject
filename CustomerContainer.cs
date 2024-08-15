using MiniCooked;

public class CustomerContainer
{
    private static CustomerContainer _instance = null;
    public static CustomerContainer Instance => _instance;

    private LinkedList<Customer> _customers = new LinkedList<Customer>();
    private Random _rand = new Random();
    private Customer[] _seat = new Customer[SettingManager.Instance.PrintableCustomer];
    private int _waitCount;
    private Thread _thread;
    private bool _isThreadRunning;

    private Layout _custStandardLayout;
    private Layout _containerLayout;

    public event Action<int> ChangedWaiting;
    public event Action<int> ChangedGold;

    private int _popedCount;

    private Rect _customerRect = new Rect(15, 9);

    public CustomerContainer()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        _containerLayout = UIManager.Instance[UILayout.Order];
        CreateCustomerStandard();
        SetWaitCount();

        _thread = new Thread(ThreadRun);
        _thread.Start();
    }

    /// <summary>
    /// 설정된 주기마다 Customer를 생성합니다.
    /// </summary>
    private void ThreadRun()
    {
        _isThreadRunning = true;

        while (true)
        {
            if (!_isThreadRunning || _popedCount >= 0)
                break;

            Thread.Sleep(SettingManager.Instance.CustomerSpawnDelay * 1000);

            int seat = GetEmptySeat();

            if (seat != -1)
            {
                AddCustomer(new Customer(_containerLayout, _customerRect), seat);
                _popedCount++;
            }
        }
    }

    private void CreateCustomerStandard()
    {
        _custStandardLayout = new Layout(_customerRect);
        _custStandardLayout.SetParent(UIManager.Instance[UILayout.Order]);
        _custStandardLayout.SetAlign(HorizonAlign.Left);
        _custStandardLayout.SetAlign(VerticalAlign.Center);

        _custStandardLayout.SetPos(4, 2, RectOption.Relative);
        _custStandardLayout.SetPrint(false);
    }

    /// <summary>
    /// 반복문으로 작동중인 스레드를 중단합니다.
    /// </summary>
    public void StopThread()
    {
        _isThreadRunning = false;
    }

    /// <summary>
    /// 연결리스트의 마지막 요소로 추가합니다.
    /// </summary>
    private void AddCustomer(Customer m_customer)
    {
        int seatNum = GetEmptySeat();

        if (seatNum == -1)
            return;

        AddCustomer(m_customer, seatNum);
    }

    /// <summary>
    /// 연결리스트의 마지막 요소로 추가합니다.
    /// </summary>
    private void AddCustomer(Customer m_customer, int m_seatNumber)
    {
        _customers.AddLast(m_customer);
        _seat[m_seatNumber] = m_customer;
        m_customer.SetSeatNumber(m_seatNumber);

        m_customer.Layout.SetPos(_custStandardLayout, RectCorner.TopL, (_custStandardLayout.Width + 4) * m_seatNumber, 0);

        m_customer.Order(MenuManager.Instance.RandomMenuNum);
        m_customer.Layout.Print();
    }

    /// <summary>
    /// 대상을 목록에서 제외합니다.
    /// </summary>
    public void RemoveCustomer(Customer m_customer)
    {
        LinkedListNode<Customer> node = _customers.First;

        while (true)
        {
            if (node == null)
                throw new Exception("찾을 수 없는 노드");

            else if(node.Value.Equals(m_customer))
            {
                _customers.Remove(m_customer);
                m_customer.Hide();
                break;
            }
                
            node = node.Next;
        }

        SetEmptySeat(m_customer.SeatNumber);
    }

    /// <summary>
    /// 설정매니저에 저장된 
    /// </summary>
    private void SetWaitCount()
    {
        this._waitCount = _rand.Next(SettingManager.Instance.MinWaitCount,
            SettingManager.Instance.MaxWaitCount);
        _popedCount = _waitCount * -1;

        ChangedWaiting?.Invoke(_waitCount);
    }

    /// <summary>
    /// 웨이팅카운트를 하나씩 줄입니다.
    /// </summary>
    private void DecreaseWaitCount()
    {
        _waitCount--;
        ChangedWaiting?.Invoke(_waitCount);

        if (_waitCount <= 0)
            GameManager.Instance.GameClear();
    }

    /// <summary>
    /// 비어있는 시트번호를 반환받습니다.
    /// </summary>
    /// <returns>-1 = 빈자리가 없음</returns>
    private int GetEmptySeat()
    {
        for (int i = 0; i < _seat.Length; i++)
        {
            if (_seat[i] == null)
                return i;
        }

        return -1;
    }

    /// <summary>
    /// 선택한 시트를 null 로 비워냅니다.
    /// </summary>
    private void SetEmptySeat(int m_idx)
    {
        _seat[m_idx] = null;
    }

    /// <summary>
    /// 손님 목록 중 해당 Score에 적합한 손님이 있는지 확인하는 메서드
    /// </summary>
    public void SearchBurger(int m_foodTotalScore)
    {
        LinkedListNode<Customer> node = _customers.First;

        while (true)
        {
            if (node == null)
            {
                ChangedGold?.Invoke(LevelSystem.Instance.ReduceGold);
                break;
            }
                
            else if(MenuManager.Instance.GetBurgerScore(node.Value.SelectNumber) == m_foodTotalScore)
            {
                ChangedGold?.Invoke(MenuManager.Instance.Burgers[node.Value.SelectNumber - 1].Price);
                RemoveCustomer(node.Value);
                DecreaseWaitCount();
                break;
            }

            node = node.Next;
        }
    }

}