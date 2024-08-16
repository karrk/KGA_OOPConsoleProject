using MiniCooked;

public class InputManager
{
    private static InputManager _instance = null;
    public static InputManager Instance => _instance;

    private ConsoleKeyInfo _inputKey;
    
    public event Action<int> InputedNumkey;
    public event Action InputedSpaceKey;
    public event Action InputedArrowKey;

    public InputManager()
    {
        if (_instance != null)
            throw new Exception("이미 생성된 인스턴스를 갱신하려합니다.");
        else
            _instance = this;
    }

    /// <summary>
    /// 키패드 1부터 제한키 입력감지,
    /// 스페이스바,엔터키 입력감지,
    /// 방향키 위, 아래 입력감지,
    /// </summary>
    public void CheckInput()
    {
        _inputKey = Console.ReadKey(true);

        if(ConsoleKey.NumPad1 <= _inputKey.Key &&(int)_inputKey.Key <= SettingManager.Instance.LimitInputNumber)
        {
            InputedNumkey?.Invoke(_inputKey.Key - ConsoleKey.NumPad0);
        }
        else if(ConsoleKey.Spacebar == _inputKey.Key ||
            ConsoleKey.Enter == _inputKey.Key)
        {
            InputedSpaceKey?.Invoke();
        }
        else if(ConsoleKey.UpArrow == _inputKey.Key ||
            ConsoleKey.DownArrow == _inputKey.Key)
        {
            InputedArrowKey?.Invoke();
        }
    }
}