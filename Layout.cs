using MiniCooked;

public class Layout : RectUI
{
    public Layout(Rect m_rect) : base(m_rect)
    {
    }

    //public Layout(RectUI m_source, RectCorner m_corner, int m_offsetX, int m_offsetY, Rect m_size) : base(m_source, m_corner, m_offsetX, m_offsetY, m_size)
    //{
    //}

    //public Layout AddLayout(Layout m_layout)
    //{
    //    if (_innerElement == null)
    //        _innerElement = new List<RectUI>();

    //    m_layout.SetParent(this);
    //    _innerElement.Add(m_layout);

    //    return this;
    //}

    //public Layout AddText(TextBox m_text)
    //{
    //    if (_innerElement == null)
    //        _innerElement = new List<RectUI>();

    //    _innerElement.Add(m_text);
    //    m_text.SetParent(this);

    //    return this;
    //}

    public int[] GetCorner(RectCorner m_corner)
    {
        switch (m_corner)
        {
            case RectCorner.TopL:
                return new int[] { Left, Top };
            case RectCorner.TopR:
                return new int[] { Right, Top };
            case RectCorner.BotL:
                return new int[] { Left, Bottom };
            case RectCorner.BotR:
                return new int[] { Right, Bottom };
        }

        return null;
    }

    public override void Print()
     {
        for (int i = 0; i < Width; i++)
        {
            ColorPrinter.Print(Left + i + 1, Top, _printColor, Fonts.LAYOUT_OUTLINE_HORIZON);
            ColorPrinter.Print(Left + i + 1, Bottom, _printColor, Fonts.LAYOUT_OUTLINE_HORIZON);
        }

        for (int i = Top + 1; i < Bottom; i++)
        {
            ColorPrinter.Print(Left, i, _printColor, Fonts.LAYOUT_OUTLINE_VERTICAL);
            ColorPrinter.Print(Left + Width + 1, i, _printColor, Fonts.LAYOUT_OUTLINE_VERTICAL);
        }

        ColorPrinter.Print(Left, Top, _printColor, Fonts.LAYOUT_OUTLINE_TOPLEFT);

        ColorPrinter.Print(Right+1, Top, _printColor, Fonts.LAYOUT_OUTLINE_TOPRIGHT);

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