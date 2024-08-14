using MiniCooked;

public class GameManager
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    private UIManager _ui;
    private SettingManager _setting;

    public GameManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        _ui = new UIManager();
        _setting = new SettingManager();
        MenuManager.Init();
    }
}