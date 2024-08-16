public class MenuSelector
{
    private int _mainMenuSelected;
    private int _resultSelected;

    public void Init()
    {
        _mainMenuSelected = -1;
        _resultSelected = -1;
    }

    public void MainMenuTextSwitch()
    {
        _mainMenuSelected =
            (_mainMenuSelected + 1) % 2;

        UIManager.Instance.SwitchMainMenuText(_mainMenuSelected);
    }

    public void ResultWindowTextSwitch()
    {
        _resultSelected =
            (_resultSelected + 1) % 2;

        UIManager.Instance.SwitchResultWindownText(_resultSelected);
    }

    public void Select(Scene m_scene)
    {
        switch (m_scene)
        {
            case Scene.MainMenu:
                if (_mainMenuSelected == 0)
                    SceneManager.LoadMainGameScene();
                else
                    Environment.Exit(0);

                break;

            case Scene.Result:
                if (_resultSelected == 0)
                    SceneManager.LoadMainMenuScene();
                else
                    Environment.Exit(0);
                break;
        }
    }
}