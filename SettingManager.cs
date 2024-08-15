using System.Runtime.InteropServices;
using System.Text;

public class SettingManager
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    private static SettingManager _instance = null;

    public static SettingManager Instance => _instance;

    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    public int FoodsMinCount => 10;
    public int FoodsMaxCount => 25;

    private int _limitInputNumber = (int)ConsoleKey.NumPad9;
    public int LimitInputNumber => _limitInputNumber;

    public int TableStackCount => 2;
    public int MaxStackLine => 11;

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

    private void SetConsole()
    {
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