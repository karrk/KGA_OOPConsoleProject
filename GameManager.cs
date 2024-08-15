using MiniCooked;

public class GameManager
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    private UIManager       _ui = new UIManager();
    private SettingManager  _setting = new SettingManager();
    private InputManager    _input = new InputManager();
    private LevelSystem     _level = new LevelSystem();

    private int _gold;

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
       
        _input.InputedNumkey += bTable.StackFoodElement;
        _input.InputedSpaceKey += bTable.Serve;

        _gold = 0;
    }

    public void AddGold(int m_gold)
    {
        _gold += m_gold;
        UIManager.Instance.RenewalGold(_gold);
    }

    public void GameRun()
    {
        while(true)
        {
            Render();
            Input();
        }
    }

    private void Render()
    {

    }

    private void Input()
    {
        _input.CheckInput();
    }
}