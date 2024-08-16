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

    private BurgerTable _burgerTable = new BurgerTable();
    private MenuSelector _menuSelector = new MenuSelector();

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

    
    // 씬이 계속 쌓이는 문제가 발생됨
    public void ProgramRun()
    {
        SceneManager.ChangedScene += ChangedScene;
        SceneManager.LoadOpenGameScene();
        SceneManager.LoadMainMenuScene();
    }

    private void ChangedScene(Scene m_scene)
    {
        RegistEvents(m_scene);
        _isFinished = false;

        switch (m_scene)
        {
            case Scene.OpenGame:
                MenuManager.Instance.Init();
                SettingManager.Instance.Init();
                LevelSystem.Instance.Init();
                UIManager.Instance.Init();
                CustomerContainer.Instance.Init();
                break;

            case Scene.MainMenu:

                UIManager.Instance.PrintMainMenuUI(true);
                _menuSelector.Init();

                _menuSelector.MainMenuTextSwitch();

                CurrentSceneRun();
                SceneFinish();

                _menuSelector.Select(m_scene);
                break;

            case Scene.MainGame:

                UIManager.Instance.PrintMainMenuUI(false);

                MenuManager.Instance.ResetOptions();
                LevelSystem.Instance.ResetOptions();
                UIManager.Instance.ResetOptions();
                CustomerContainer.Instance.ResetOptions();

                _playerGold = 0;
                AddGold(0);

                UIManager.Instance.PrintMainGameUI(true);
                _burgerTable.Init();

                CurrentSceneRun();
                
                StopMultiThreads();
                SceneFinish();
                UIManager.Instance.PrintMainGameUI(false);
                SceneManager.LoadResultScene();
                break;

            case Scene.Result:
                UIManager.Instance.PrintResult(true);

                _menuSelector.Init();
                _menuSelector.ResultWindowTextSwitch();

                CurrentSceneRun();

                SceneFinish();
                UIManager.Instance.PrintResult(false);
                _menuSelector.Select(m_scene);
                break;
        }
    }

    private void RegistEvents(Scene m_scene)
    {
        switch (m_scene)
        {
            case Scene.MainMenu:

                // - 화살표 결과창 텍스트 변경
                InputManager.Instance.InputedArrowKey -=
                    _menuSelector.ResultWindowTextSwitch;
                // + 메인메뉴 텍스트 변경
                InputManager.Instance.InputedArrowKey +=
                    _menuSelector.MainMenuTextSwitch;
                // + 스페이스키 씬종료
                InputManager.Instance.InputedSpaceKey +=
                    SceneFinish;

                break;

            case Scene.MainGame:

                // - 메인메뉴 텍스트 변경
                InputManager.Instance.InputedArrowKey -=
                    _menuSelector.MainMenuTextSwitch;
                // - 스페이스키 씬종료
                InputManager.Instance.InputedSpaceKey -=
                    SceneFinish;
                // - 스페이스키 씬종료 = 임시방편
                InputManager.Instance.InputedSpaceKey -=
                    SceneFinish;

                // + 수입발생시 골드 반영
                CustomerContainer.Instance.ChangedGold += AddGold;
                // + 대기 수 변동시 텍스트 반영
                CustomerContainer.Instance.ChangedWaiting +=
                    UIManager.Instance.RenewalWaitText;

                // + 숫자키 입력시 재료스택
                InputManager.Instance.InputedNumkey 
                    += _burgerTable.StackFoodElement;
                // + 스페이스키 입력시 서빙
                InputManager.Instance.InputedSpaceKey 
                    += _burgerTable.Serve;
                break;

            case Scene.Result:

                // - 수입발생시 골드 반영
                CustomerContainer.Instance.ChangedGold -= AddGold;
                // - 대기 수 변동시 텍스트 반영
                CustomerContainer.Instance.ChangedWaiting -=
                    UIManager.Instance.RenewalWaitText;
                // - 숫자키 입력시 재료스택
                InputManager.Instance.InputedNumkey
                    -= _burgerTable.StackFoodElement;
                // - 스페이스키 입력시 서빙
                InputManager.Instance.InputedSpaceKey
                    -= _burgerTable.Serve;

                // + 스페이스키 입력시 씬종료
                InputManager.Instance.InputedSpaceKey +=
                    SceneFinish;
                // + 방향키 입력시 결과창 텍스트 변경
                InputManager.Instance.InputedArrowKey +=
                    _menuSelector.ResultWindowTextSwitch;
                break;
        }
    }

    private void AddGold(int m_gold)
    {
        this._playerGold += m_gold;
        UIManager.Instance.RenewalGoldText(_playerGold);
    }

    private void StopMultiThreads()
    {
        _custContainer.StopThread();
    }

    public void CurrentSceneRun()
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

    public void SceneFinish()
    {
        this._isFinished = true;
    }

    public void MainGameClear()
    {
        _burgerTable.Init();
        CustomerContainer.Instance.ClearContainer();
        SceneFinish();
    }
}