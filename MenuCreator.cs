public static class MenuManager
{
    private static Burger _burger1;
    private static Burger _burger2;
    private static Burger _burger3;

    private static Random _rand = new Random();
    private static int _randomElementNum => _rand.Next(0, Fonts.OptionCharList.Count);

    private static List<Burger> _burgers = new List<Burger>();
    public static List<Burger> Burgers => _burgers;

    public static void Init()
    {
        BurgerGenerate();
    }

    private static void BurgerGenerate()
    {
        _burger1 = new Burger(500);

        FoodElement fe1 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1<<0);
        fe1.SetColor(60);
        FoodElement fe2 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1<<1);
        fe2.SetColor(80);
        FoodElement fe3 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1<<2);
        fe3.SetColor(80);

        _burger1.AddStack(fe1);
        _burger1.AddStack(fe2);
        _burger1.CloseStack();
        _burgers.Add(_burger1);


        _burger2 = new Burger(1000);

        FoodElement fe11 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 0);
        fe11.SetColor(40);
        FoodElement fe21 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 1);
        fe21.SetColor(100);
        FoodElement fe31 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 2);
        fe31.SetColor(140); 
        FoodElement fe41 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 2);
        fe41.SetColor(160);

        _burger2.AddStack(fe11);
        _burger2.AddStack(fe21);
        _burger2.AddStack(fe31);
        _burger2.AddStack(fe41);
        _burger2.CloseStack();
        _burgers.Add(_burger2);



        _burger3 = new Burger(5000);

        FoodElement fe111 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 0);
        fe111.SetColor(140);
        FoodElement fe222 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 1);
        fe222.SetColor(138);
        FoodElement fe333 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 2);
        fe333.SetColor(136);
        FoodElement fe444 = new FoodElement(Fonts.OptionCharList[_randomElementNum], 1 << 2);
        fe444.SetColor(100);

        _burger3.AddStack(fe111);
        _burger3.AddStack(fe222);
        _burger3.AddStack(fe333);
        _burger3.AddStack(fe444);
        _burger3.CloseStack();
        _burgers.Add(_burger3);
    }
}