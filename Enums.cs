public enum HorizonAlign
{
    Left,
    Center,
    Right,
}

public enum VerticalAlign
{
    Top,
    Center,
    Bottom,
}

public enum RectOption
{
    Relative,
    Absolute,
}

public enum RectCorner
{
    TopL,
    TopR,
    BotL,
    BotR,
}

public enum UILayout
{
    Main,

    #region MainMenu

    MainMenuPage,

    #endregion

    #region MainGame

    Order,
    Preview,
    Elements,
    SpaceBar,
    Menus,

    #endregion

    #region Result

    ResultPage,

    #endregion

    Size,
}

public enum SelectText
{
    Menu_Start,
    Menu_Escape,
    Result_GotoMenu,
    Result_Escape,
    Size,
}

public enum Scene
{
    OpenGame,
    MainMenu,
    MainGame,
    Result,
}