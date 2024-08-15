using MiniCooked;

public class GameManager
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    private UIManager           _ui = new UIManager();
    private SettingManager      _setting = new SettingManager();
    private InputManager        _input = new InputManager();
    private LevelSystem         _level = new LevelSystem();
    private CustomerContainer   _custContainer = new CustomerContainer();

    private int _playerGold;
    public int PlayerGold => _playerGold;

    public GameManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        BurgerTable bTable = new BurgerTable();
        
        MenuManager.Init(); // 스태틱 => 변환
        _setting.Init();
        _level.Init();
        _ui.Init();
        _custContainer.Init();

        _custContainer.ChangedGold += AddGold;
        _input.InputedNumkey += bTable.StackFoodElement;
        _input.InputedSpaceKey += bTable.Serve;
    }

    public void AddGold(int m_gold)
    {
        this._playerGold += m_gold;
    }

    public void StopMutieThreads()
    {
        _custContainer.StopThread();
    }

    public void GameRun()
    {
        while(true)
        {
            Input();
        }
    }

    private void Input()
    {
        _input.CheckInput();
    }
}