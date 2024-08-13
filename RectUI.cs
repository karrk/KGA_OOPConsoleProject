using MiniCooked;

public abstract class RectUI
{
    protected Rect _rect;

    public int Top => _rect.StartY;
    public int Left => _rect.StartX;
    public int Right => _rect.EndX;
    public int Bottom => _rect.EndY;

    public int Width => _rect.EndX - _rect.StartX;
    public int Height => _rect.EndY - _rect.StartY;

    protected int _printColor = 231; // white

    private RectUI _parent = null;
    public RectUI Parent => _parent;

    protected HorizonAlign _horizon;
    protected VerticalAlign _vertical;

    public RectUI() { }

    public RectUI(Rect m_rect)
    {
        this._rect = m_rect;
    }

    public RectUI(RectUI m_source, RectCorner m_corner, int m_offsetX, int m_offsetY, Rect m_size)
    {
        if (m_size.StartX != 0 || m_size.StartY != 0)
            throw new Exception("Rect 객체 잘못된 생성 Width, Height 값을 통해 생성자 호출요망");

        int[] standard = m_source.GetCorner(m_corner);
        standard[0] += m_offsetX;
        standard[1] += m_offsetY;

        this._rect = new Rect(standard[0], standard[1],
            m_size.EndX, m_size.EndY);
    }

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

    public virtual RectUI SetPos(int m_posX, int m_posY)
    {
        _rect.EndX = _rect.EndX - _rect.StartX + m_posX;
        _rect.EndY = _rect.EndY - _rect.StartY + m_posY;

        _rect.StartX = m_posX;
        _rect.StartY = m_posY;

        return this;
    }

    public virtual RectUI SetPos(RectUI m_source, RectCorner m_corner, int m_offsetX, int m_offsetY)
    {
        int[] pivotPos = m_source.GetCorner(m_corner);

        pivotPos[0] += m_offsetX;
        pivotPos[1] += m_offsetY;

        return SetPos(pivotPos[0], pivotPos[1]);
    }

    public RectUI SetParent(RectUI m_parent)
    {
        this._parent = m_parent;
        return this;
    }

    public RectUI SetColor(int m_colorCode)
    {
        this._printColor = m_colorCode;
        return this;
    }

    public RectUI SetAlign(HorizonAlign m_horizon)
    {
        this._horizon = m_horizon;
        return this;
    }

    public RectUI SetAlign(VerticalAlign m_vertical)
    {
        this._vertical = m_vertical;
        return this;
    }

    public void TurnOff()
    {
        int tempColor = _printColor;

        this._printColor = (int)ConsoleColor.Black;

        Print();

        this._printColor = tempColor;
    }

    public abstract void Print();
}