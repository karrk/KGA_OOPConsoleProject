using MiniCooked;

public class Customer
{
    private Layout _layout;

    private TextBox _imgTextBox;
    private TextBox _communicateBox;

    public Layout Layout => _layout;

    private int _selectMenu;

    public Customer()
    {
        _layout = new Layout(new Rect(15, 9));
        _imgTextBox = (TextBox)SetImgBox().SetColor(ColorPrinter.GetRandomColorNumber());
        _layout.SetColor(0);

        _layout.AddText(_imgTextBox);
    }

    public void SetCommunity()
    {
        _communicateBox = (TextBox)new TextBox("1번 주 세 요")
            .SetPos(_layout, RectCorner.TopL, -15,10);
        _layout.AddText(_communicateBox);
    }

    private TextBox SetImgBox()
    {
        TextBox img =
(TextBox)new TextBox(" █████████")
            .AddText(" █　████　██ ", true)
            .AddText(" █　████　██ ", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .AddText("█████████████", true)
            .SetAlign(HorizonAlign.Center)
            .SetAlign(VerticalAlign.Bottom);

        return img;
    }
}