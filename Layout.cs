using MiniCooked;

public class Layout : RectUI
{
    public Layout(Rect m_rect) : base(m_rect)
    {
    }

    public override void Print()
     {
        // 상, 하
        for (int i = 0; i < Width; i++)
        {
            ColorPrinter.Print(Left + i + 1, Top, _printColor, Fonts.LAYOUT_OUTLINE_HORIZON);
            ColorPrinter.Print(Left + i + 1, Bottom, _printColor, Fonts.LAYOUT_OUTLINE_HORIZON);
        }

        // 좌, 우
        for (int i = Top + 1; i < Bottom; i++)
        {
            ColorPrinter.Print(Left, i, _printColor, Fonts.LAYOUT_OUTLINE_VERTICAL);
            ColorPrinter.Print(Left + Width + 1, i, _printColor, Fonts.LAYOUT_OUTLINE_VERTICAL);
        }

        // 좌상, 우상 모서리
        ColorPrinter.Print(Left, Top, _printColor, Fonts.LAYOUT_OUTLINE_TOPLEFT);
        ColorPrinter.Print(Right+1, Top, _printColor, Fonts.LAYOUT_OUTLINE_TOPRIGHT);


        // 좌하, 우하 모서리
        ColorPrinter.Print(Left, Bottom, _printColor, Fonts.LAYOUT_OUTLINE_DOWNLEFT);
        ColorPrinter.Print(Right+1, Bottom, _printColor, Fonts.LAYOUT_OUTLINE_DOWNRIGHT);


        if (_childs != null)
        {
            for (int i = 0; i < _childs.Count; i++)
            {
                _childs[i].Print();
            }
        }

    }
}