namespace MiniCooked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Init();

            gm.Run();
        }
    }

    public static class CharContoroller
    {
        public static char HalfToFull(char m_half)
        {
            if (m_half > 0x21 && m_half <= 0x7e)

                m_half += (char)0xfee0;

            else if (m_half == 0x20)

                m_half = (char)0x3000;

            return m_half;
        }

        public static bool isHalf(char m_half)
        {
            return (m_half >= 0x20 && m_half <= 0x7E);
        }
    }

    
}
