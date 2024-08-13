using MiniCooked;

public enum RectOption
{
    Relative,
    Absolute,
}

public enum LayoutCorner
{
    TopL,
    TopR,
    BotL,
    BotR,
}

public struct Rect
{
    public int StartX;
    public int StartY;
    public int EndX;
    public int EndY;

    public Rect(int m_width, int m_height)
    {
        EndX = m_width;
        EndY = m_height;
    }

    public Rect(int m_startX, int m_startY, int m_nextX, int m_nextY,RectOption m_option = RectOption.Relative)
    {
        if (m_option == RectOption.Absolute && (m_startX >= m_nextX || m_startY >= m_nextY))
            throw new Exception("범위가 제대로 설정되지 않음");

        StartX = m_startX;
        StartY = m_startY;

        switch (m_option)
        {
            case RectOption.Relative:
                {
                    EndX = m_startX + m_nextX;
                    EndY = m_startY + m_nextY;
                    break;
                }
            case RectOption.Absolute:
                {
                    EndX = m_nextX;
                    EndY = m_nextY;
                    break;
                }
        }
    }
}

public class Layout
{
    private Rect _rect;

    public int Top => _rect.StartY;
    public int Left => _rect.StartX;
    public int Right => _rect.EndX;
    public int Bottom => _rect.EndY;

    public int Width => _rect.EndX - _rect.StartX;
    public int Height => _rect.EndY - _rect.StartY;

    private List<Layout> _innerLayouts;
    private List<TextBox> _textBoxes;

    public Layout(Rect m_rect)
    {
        this._rect = m_rect;
    }

    public Layout(int m_startX, int m_startY, int m_nextX, int m_nextY, RectOption m_option = RectOption.Relative)
    {
        this._rect = new Rect(m_startX,m_startY,m_nextX,m_nextY,m_option);
    }

    public Layout(Layout m_sourceLayout, LayoutCorner m_corner, int m_offsetX, int m_offsetY,Rect m_size)
    {
        if (m_size.StartX != 0 || m_size.StartY != 0)
            throw new Exception("Rect 객체 잘못된 생성 Width, Height 값을 통해 생성자 호출요망");

        int[] standard = m_sourceLayout.GetCorner(m_corner);
        standard[0] += m_offsetX;
        standard[1] += m_offsetY;

        this._rect = new Rect(standard[0], standard[1],
            m_size.EndX, m_size.EndY);
    }

    public Layout AddLayout(Layout m_layout)
    {
        if (_innerLayouts == null)
            _innerLayouts = new List<Layout>();

        _innerLayouts.Add(m_layout);

        return this;
    }

    //public Layout AddLayout(int m_startX, int m_startY, int m_width, int m_height)
    //{
    //    if (_innerLayouts == null)
    //        _innerLayouts = new List<Layout>();

    //    _innerLayouts.Add(new Layout(m_startX, m_startY, m_width, m_height));

    //    return this;
    //}

    public Layout AddText(TextBox m_text)
    {
        if (_textBoxes == null)
            _textBoxes = new List<TextBox>();

        _textBoxes.Add(m_text);
        m_text.ParentLayout = this;

        return this;
    }

    public int[] GetCorner(LayoutCorner m_corner)
    {
        switch (m_corner)
        {
            case LayoutCorner.TopL:
                return new int[] { Left, Top };
            case LayoutCorner.TopR:
                return new int[] { Right, Top };
            case LayoutCorner.BotL:
                return new int[] { Left, Bottom };
            case LayoutCorner.BotR:
                return new int[] { Right, Bottom };
        }

        return null;
    }

    public void PrintLayout()
    {
        Console.SetCursorPosition(Left, Top);

        //상단 테두리
        Console.Write(Fonts.LAYOUT_OUTLINE_TOPLEFT);

        for (int i = Left; i < Right - 2; i++)
        {
            Console.Write(Fonts.LAYOUT_OUTLINE_HORIZON);
        }

        Console.WriteLine(Fonts.LAYOUT_OUTLINE_TOPRIGHT);


        //좌우
        for (int i = Top + 1; i < Bottom; i++)
        {
            Console.SetCursorPosition(Left, i);
            Console.Write(Fonts.LAYOUT_OUTLINE_VERTICAL);
            Console.SetCursorPosition(Left + Width - 1, i);
            Console.Write(Fonts.LAYOUT_OUTLINE_VERTICAL);
        }

        //하단부
        Console.SetCursorPosition(Left, Bottom);

        Console.Write(Fonts.LAYOUT_OUTLINE_DOWNLEFT);

        for (int i = Left; i < Right - 2; i++)
        {
            Console.Write(Fonts.LAYOUT_OUTLINE_HORIZON);
        }

        Console.Write(Fonts.LAYOUT_OUTLINE_DOWNRIGHT);

        if (_innerLayouts != null)
        {
            for (int i = 0; i < _innerLayouts.Count; i++)
            {
                _innerLayouts[i].PrintLayout();
            }
        }

        if (_textBoxes != null)
        {
            for (int i = 0; i < _textBoxes.Count; i++)
            {
                _textBoxes[i].PrintText();
            }
        }

    }
    
    
}