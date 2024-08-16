public class LevelSystem
{
    private static LevelSystem _instance = null;
    public static LevelSystem Instance => _instance;

    public int this[int level] => _levels[level].GetRandom();
    private List<int[]> _levels = new List<int[]>();
    private Random _rand = new Random();

    private int _reduceGold;
    public int ReduceGold
    {
        get
        {
            if (GameManager.Instance.PlayerGold < _reduceGold * -1)
                return GameManager.Instance.PlayerGold * -1;

            return _reduceGold;
        }
    }

    public LevelSystem()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        _reduceGold = (SettingManager.Instance.MaxPrice
                             - SettingManager.Instance.MinPrice) / 2 * -100;
    }


    public void ResetOptions()
    {
        SettingLevel();
    }

    /// <summary>
    /// 설정된 레벨에 맞게 레벨테이블을 설정합니다.
    /// </summary>
    private void SettingLevel()
    {
        int count;
        int level = SettingManager.Instance.MinStackLine;
        int temp = SettingManager.Instance.MaxStackLine - level + 1;

        for (int i = SettingManager.Instance.MaxLevel; i > 0; i--)
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