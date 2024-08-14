using MiniCooked;

public class Customer
{
    private Layout _layout;

    private TextBox _imgTextBox;
    private TextBox _communicateBox;

    public Layout Layout => _layout;

    private int _selectMenu;
    public int SelectNumber => _selectMenu;
    
    public Customer(RectUI m_baseUI)
    {
        _layout = new Layout(new Rect(0,0,15,9));
        _layout.SetParent(m_baseUI);

        _imgTextBox = SetImgBox();
        _imgTextBox.SetColor(ColorPrinter.GetRandomColorNumber());
        _imgTextBox.SetParent(_layout);

        _communicateBox = new TextBox("");
        _communicateBox.SetParent(_layout);

        _layout.SetAlign(HorizonAlign.Left);
        _layout.SetAlign(VerticalAlign.Center);
        _communicateBox.SetAlign(HorizonAlign.Center);
        _communicateBox.SetAlign(VerticalAlign.Top);

        _layout.SetPos(5, 2, RectOption.Relative);
        _communicateBox.SetPos(0, -3, RectOption.Relative);

        _layout.SetColor(0);

        Order(MenuManager.RandomMenuNum);
    }

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

    public void Hide()
    {
        _layout.TurnOff();
    }
}