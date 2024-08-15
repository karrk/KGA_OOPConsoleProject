using MiniCooked;

public class Customer
{
    private Layout _layout;

    private TextBox _imgTextBox;
    private TextBox _communicateBox;

    public Layout Layout => _layout;

    private int _selectMenu;
    public int SelectNumber => _selectMenu;

    private int _seatNumber;
    public int SeatNumber => _seatNumber;

    public Customer(RectUI m_baseUI,Rect m_layoutSize)
    {
        _layout = new Layout(m_layoutSize);
        _layout.SetParent(m_baseUI);
        _layout.SetPrint(false);

        CreateCommuiteBox();
        CreateImageBox();
    }

    private void CreateCommuiteBox()
    {
        _communicateBox = new TextBox("");
        _communicateBox.SetParent(_layout);

        _communicateBox.SetAlign(HorizonAlign.Center);
        _communicateBox.SetAlign(VerticalAlign.Top);
        _communicateBox.SetPos(0, -3, RectOption.Relative);
    }

    private void CreateImageBox()
    {
        _imgTextBox = SetImgBox();
        _imgTextBox.SetColor(ColorPrinter.GetRandomColorNumber());
        _imgTextBox.SetParent(_layout);
    }

    public void SetSeatNumber(int m_number)
    {
        this._seatNumber = m_number;
    }

    /// <summary>
    /// 선택한 메뉴번호를 결정 후 화면에 출력
    /// </summary>
    public void Order(int m_number)
    {
        _communicateBox.SetNewText($"{m_number}번 주 세 요");
        _communicateBox.SetAlign(HorizonAlign.Center);
        this._selectMenu = m_number;
    }

    private TextBox SetImgBox()
    {
        TextBox img =
           new TextBox("　　　██████████")
            .AddText("　　█　████　██ ", true)
            .AddText("　　█　████　██ ", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true);

        return img;
    }

    /// <summary>
    /// 출력된 손님 이미지를 감춥니다.
    /// </summary>
    public void Hide()
    {
        _layout.TurnOff();
    }
}