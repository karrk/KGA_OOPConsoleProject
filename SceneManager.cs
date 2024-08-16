public static class SceneManager
{
    public static event Action<Scene> ChangedScene;

    public static void LoadOpenGameScene()
    {
        ChangedScene?.Invoke(Scene.OpenGame);
    }

    public static void LoadMainMenuScene()
    {
        ChangedScene?.Invoke(Scene.MainMenu);
    }

    public static void LoadMainGameScene()
    {
        ChangedScene?.Invoke(Scene.MainGame);
    }

    public static void LoadResultScene()
    {
        ChangedScene?.Invoke(Scene.Result);

    }
}