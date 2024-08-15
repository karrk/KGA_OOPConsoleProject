public class LevelSystem
{
    private static LevelSystem _instance = null;
    public static LevelSystem Instance => _instance;

    private List<int[]> _levels = new List<int[]>();
    private Random _rand = new Random();

    public LevelSystem()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        InitLevel();
    }

    public int this[int level] => _levels[level].GetRandom();

    public int GetPrice(int m_elementStackCount)
    {
        int price = _rand.Next(SettingManager.Instance.MinPricePerElement,
            SettingManager.Instance.MaxPricePerElement);

        return price * m_elementStackCount * 100;
    }

    private void InitLevel()
    {
        int count;
        int level = SettingManager.Instance.MinStackLine;
        int temp = SettingManager.Instance.MaxStackLine - level+1;

        for (int i = SettingManager.Instance.MaxLevel; i > 0 ; i--)
        {
            count = temp / i;
            int[] arr = new int[count];

            for (int j = 0; j < count; j++)
            {
                arr[j] = level++;
                temp--;
            }

            _levels.Add(arr);
        }
    }

}

public static class CustomMethod
{
    public static int GetRandom(this int[] arr)
    {
        Random rand = new Random();
        return arr[rand.Next(0, arr.Length)];
    }
}