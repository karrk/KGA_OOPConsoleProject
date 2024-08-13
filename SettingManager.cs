using System.Runtime.InteropServices;
using System.Text;

public class SettingManager
{
    private static SettingManager _instance = null;

    public static SettingManager Instance => _instance;

    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    public int FoodsMinCount => 10;
    public int FoodsMaxCount => 10;

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

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

    private static void SetConsole()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;

        var handle = GetStdHandle(STD_OUTPUT_HANDLE);
        GetConsoleMode(handle, out uint mode);
        SetConsoleMode(handle, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);

        // ANSI escape code for setting text color to bright red (color 196 in 256-color palette)
        //Console.WriteLine("\u001b[38;5;130mHello, 256-color world!\u001b[0m");
    }
}