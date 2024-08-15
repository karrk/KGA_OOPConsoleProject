namespace MiniCooked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Init();

            gm.GameRun();
        }
    }

    
}
