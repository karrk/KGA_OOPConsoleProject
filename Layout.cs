using MiniCooked;

public class Layout
{
    private int _posX;
    private int _posY;

    private int _width;
    private int _height;

    public int Top => _posY;
    public int Left => _posX;
    public int Right => _posX + _width;
    public int Bottom => _posY + _height;

    public int Width => _width;
    public int Height => _height;

    private int _sortingOrder;

    private List<Layout> _innerLayouts;
    private List<TextBox> _textBoxes;

    public Layout(int m_startX, int m_startY, int m_width, int m_height)
    {
        this._posX = m_startX;
        this._posY = m_startY;

        this._width = m_width;
        this._height = m_height;
    }

    public void AddLayout(Layout m_layout)
    {
        if (_innerLayouts == null)
            _innerLayouts = new List<Layout>();

        _innerLayouts.Add(m_layout);
    }

    public void AddLayout(int m_startX, int m_startY, int m_width, int m_height)
    {
        if (_innerLayouts == null)
            _innerLayouts = new List<Layout>();

        _innerLayouts.Add(new Layout(m_startX, m_startY, m_width, m_height));
    }

    public void SetSortingOrder(int m_sort)
    {
        this._sortingOrder = m_sort;
    }



    public void AddText(TextBox m_text)
    {
        if (_textBoxes == null)
            _textBoxes = new List<TextBox>();

        _textBoxes.Add(m_text);
        m_text.ParentLayout = this;
    }

    public void PrintLayout()
    {
        Console.SetCursorPosition(_posX, _posY);


        //상단 테두리
        Console.Write(Fonts.LAYOUT_OUTLINE_TOPLEFT);

        for (int i = _posX; i < _posX + _width - 2; i++)
        {
            Console.Write(Fonts.LAYOUT_OUTLINE_HORIZON);
        }

        Console.WriteLine(Fonts.LAYOUT_OUTLINE_TOPRIGHT);


        //좌우
        for (int i = _posY + 1; i < _posY + _height; i++)
        {
            Console.SetCursorPosition(_posX, i);
            Console.Write(Fonts.LAYOUT_OUTLINE_VERTICAL);
            Console.SetCursorPosition(_posX + _width - 1, i);
            Console.Write(Fonts.LAYOUT_OUTLINE_VERTICAL);
        }

        //하단부
        Console.SetCursorPosition(_posX, _height + _posY);

        Console.Write(Fonts.LAYOUT_OUTLINE_DOWNLEFT);

        for (int i = _posX; i < _posX + _width - 2; i++)
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