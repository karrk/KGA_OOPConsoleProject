public class MenuSelector
{
    private int _mainMenuSelected;
    private int _resultSelected;

    public void Init()
    {
        _mainMenuSelected = -1;
        _resultSelected = -1;
    }

    /// <summary>
    /// 해당 메서드 작동시 메인메뉴 텍스트 선택을 변경합니다.
    /// </summary>
    public void MainMenuTextSwitch()
    {
        _mainMenuSelected =
            (_mainMenuSelected + 1) % 2;

        UIManager.Instance.SwitchMainMenuText(_mainMenuSelected);
    }

    /// <summary>
    /// 해당 메서드 작동시 결과화면 텍스트 선택을 변경합니다.
    /// </summary>
    public void ResultWindowTextSwitch()
    {
        _resultSelected =
            (_resultSelected + 1) % 2;

        UIManager.Instance.SwitchResultWindownText(_resultSelected);
    }


    /// <summary>
    /// 씬마다 선택되어 있는 텍스트를 기반으로 동작을 결정합니다.
    /// </summary>
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