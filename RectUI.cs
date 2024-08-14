using MiniCooked;
using System.Reflection;

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

    protected List<RectUI> _childs;

    public RectUI() { }

    public RectUI(Rect m_rect)
    {
        this._rect = m_rect;
    }

    // 좌표지정에 혼동이 생김, 명확한 단계설정이 필요해보임
    //public RectUI(RectUI m_source, RectCorner m_corner, int m_offsetX, int m_offsetY, Rect m_size)
    //{
    //    if (m_size.StartX != 0 || m_size.StartY != 0)
    //        throw new Exception("Rect 객체 잘못된 생성 Width, Height 값을 통해 생성자 호출요망");

    //    int[] standard = m_source.GetCorner(m_corner);

    //    this._rect = new Rect(
    //        standard[0] + m_offsetX, 
    //        standard[1] + m_offsetY,
    //        m_offsetX + m_size.EndX, 
    //        m_offsetY + m_size.EndY);

    //}

    /// <summary>
    /// UI 요소의 꼭지점 좌표를 반환합니다.
    /// </summary>
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

    /// <summary>
    /// UI 요소를 해당 좌표로 변경시킵니다.
    /// Absolute = 지정한 위치로 변경
    /// Realative = 현재위치에서 상대변경
    /// </summary>
    public virtual RectUI SetPos(int m_posX, int m_posY, RectOption m_option = RectOption.Absolute)
    {
        if (m_option == RectOption.Absolute) // 현위치와 상관없이 절대좌표로 이동
        {
            _rect.EndX = _rect.EndX - _rect.StartX + m_posX;
            _rect.EndY = _rect.EndY - _rect.StartY + m_posY;

            _rect.StartX = m_posX;
            _rect.StartY = m_posY;

        }
        else // 현재 위치에서 오프셋
        {
            _rect.EndX += m_posX;
            _rect.StartX += m_posX;

            _rect.EndY += m_posY;
            _rect.StartY += m_posY;
        }

        if (_childs != null)
        {
            for (int i = 0; i < _childs.Count; i++)
            {
                _childs[i].SetPos(m_posX, m_posY, m_option);
            }
        }

        return this;
    }

    /// <summary>
    /// 좌표를 대상 UI 의 꼭지점지점으로부터 상대변경
    /// </summary>
    public virtual RectUI SetPos(RectUI m_source, RectCorner m_corner, int m_offsetX, int m_offsetY)
    {
        int[] pivotPos = m_source.GetCorner(m_corner);

        pivotPos[0] -= Left;
        pivotPos[1] -= Top;

        return SetPos(pivotPos[0] + m_offsetX, pivotPos[1] + m_offsetY,RectOption.Relative);
    }

    /// <summary>
    /// UI의 부모를 지정합니다.
    /// </summary>
    public RectUI SetParent(RectUI m_parent)
    {
        if (m_parent._childs == null)
            m_parent._childs = new List<RectUI>();

        m_parent._childs.Add(this);

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
        if (Parent == null)
            throw new Exception("부모 객체가 없습니다.");

        switch (m_horizon)
        {
            case HorizonAlign.Left:
                SetPos(Parent.Left, this.Top);
                break;
            case HorizonAlign.Center:
                //SetPos(Parent.Left + (Parent.Width - this.Right) / 2, this.Top);
                SetPos((Parent.Left + Parent.Width/2 - Width/2), this.Top);
                break;
            case HorizonAlign.Right:
                SetPos(Parent.Right - this.Width, this.Top);
                break;
        }

        this._horizon = m_horizon;
        return this;
    }

    public RectUI SetAlign(VerticalAlign m_vertical)
    {
        if (Parent == null)
            throw new Exception("부모 객체가 없습니다.");

        switch (m_vertical)
        {
            case VerticalAlign.Top:
                SetPos(this.Left, Parent.Top);
                break;
            case VerticalAlign.Center:
                SetPos(this.Left, (Parent.Height / 2) + Parent.Top - this.Height/2);
                break;
            case VerticalAlign.Bottom:
                SetPos(this.Left, Parent.Bottom-Height);
                break;
        }

        this._vertical = m_vertical;
        return this;
    }

    /// <summary>
    /// UI 요소를 잠시 꺼둡니다.
    /// </summary>
    public void TurnOff()
    {
        int tempColor = _printColor;

        this._printColor = (int)ConsoleColor.Black;

        Print();

        this._printColor = tempColor;
    }

    /// <summary>
    /// UI 요소를 화면에 출력합니다.
    /// </summary>
    public abstract void Print();
}