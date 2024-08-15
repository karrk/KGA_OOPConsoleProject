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
    private MenuManager         _menu = new MenuManager();

    private int _playerGold;
    public int PlayerGold => _playerGold;
    private bool _isFinished;

    public GameManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        _menu.Init();
        _setting.Init();
        _level.Init();
        _ui.Init();
        _custContainer.Init();

        _isFinished = false;
        BurgerTable bTable = new BurgerTable();

        _custContainer.ChangedGold += AddGold;
        _input.InputedNumkey += bTable.StackFoodElement;
        _input.InputedSpaceKey += bTable.Serve;
    }

    public void AddGold(int m_gold)
    {
        this._playerGold += m_gold;
        UIManager.Instance.RenewalGoldText(_playerGold);
    }

    private void StopMultiThreads()
    {
        _custContainer.StopThread();
    }

    public void GameRun()
    {
        while(true)
        {
            if (_isFinished)
                break;

            Input();
        }
    }

    private void Input()
    {
        _input.CheckInput();
    }

    public void GameClear()
    {
        this._isFinished = true;
        StopMultiThreads();
    }

    private void OpenLobby()
    {

    }

    private void OpenMainGame()
    {

    }

    public void OpenResult()
    {

    }
}