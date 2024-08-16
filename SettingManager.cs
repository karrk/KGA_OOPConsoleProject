using System.Runtime.InteropServices;
using System.Text;

public class SettingManager
{
    #region Color 설정 관련
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
    #endregion

    private static SettingManager _instance = null;

    public static SettingManager Instance => _instance;

    // 콘솔창 사이즈 
    public const int WINDOW_WIDTH = 205;
    public const int WINDOW_HEIGHT = 62;

    // 재료당 출력되어야 할 문자열 길이
    public int ElementTextMinCount => 10;
    public int ElementTextMaxCount => 25;
    // 미리보기 영역에서 재료스택시 재료의 사이즈
    public int ElementPrintHeigh => 2;
    // 생성되는 버거의 최소,최대 스택카운트
    public int MinStackLine => 3;
    public int MaxStackLine => 12;
    // 게임내에 제시되는 버거 수
    public int MaxBurgerCount => 3;
    // 게임의 최대 난이도
    public int MaxLevel => 3;
    // 버거당 최소,최대가격
    public int MinPrice => 2;
    public int MaxPrice => 7;
    // 오더레이아웃 영역내에서 출력될 수 있는 Customer 수
    public int PrintableCustomer => 6;
    // 한 게임당 최소,최대 대기자 수
    public int MinWaitCount => 6;
    public int MaxWaitCount => 10;
    // Customer 스폰 딜레이 초단위(s)
    public int CustomerSpawnDelay = 4;

    private int _limitInputNumber = (int)ConsoleKey.NumPad9;
    public int LimitInputNumber => _limitInputNumber;

    public SettingManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    public void Init()
    {
        SetConsole();
    }

    /// <summary>
    /// 콘솔 환경을 설정합니다.
    /// </summary>
    private void SetConsole()
    {
        Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;

        var handle = GetStdHandle(STD_OUTPUT_HANDLE);
        GetConsoleMode(handle, out uint mode);
        SetConsoleMode(handle, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);
    }

    /// <summary>
    /// 진행되는 라운드에 필요이상의 숫자키 입력을 방지합니다.
    /// </summary>
    public void SetLimitKey(int m_keyNumber)
    {
        if(1 <= m_keyNumber && m_keyNumber <= 9)
        {
            _limitInputNumber = (int)(m_keyNumber + ConsoleKey.NumPad0);
        }
    }
}