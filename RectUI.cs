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

    protected int _printColor = 231;

    private RectUI _parent = null;
    public RectUI Parent => _parent;

    protected HorizonAlign _horizon;
    protected VerticalAlign _vertical;

    protected List<RectUI> _childs;
    protected bool _isPrint = true;

    public RectUI() { }

    public RectUI(Rect m_rect)
    {
        this._rect = m_rect;
    }

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

    /// <summary>
    /// 해당 UI 요소의 출력색상을 지정합니다.
    /// </summary>
    public RectUI SetColor(int m_colorCode)
    {
        this._printColor = m_colorCode;
        return this;
    }

    /// <summary>
    /// 부모 레이아웃을 기준으로 좌, 우 정렬
    /// </summary>
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
                SetPos((Parent.Left + Parent.Width/2 - Width/2), this.Top);
                break;
            case HorizonAlign.Right:
                SetPos(Parent.Right - this.Width, this.Top);
                break;
        }

        this._horizon = m_horizon;
        return this;
    }

    /// <summary>
    /// 부모 레이아웃 기준으로 상, 하 정렬
    /// </summary>
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
    /// UI 요소를 감춥니다.
    /// </summary>
    public void TurnOff()
    {
        int tempColor = _printColor;

        this._printColor = (int)ConsoleColor.Black;

        Print();

        this._printColor = tempColor;

        if (_childs == null)
            return;

        foreach (var child in _childs)
        {
            child.TurnOff();
        }
    }

    public void SetPrint(bool m_printable)
    {
        this._isPrint = m_printable;
    }

    /// <summary>
    /// UI 요소를 화면에 출력합니다.
    /// </summary>
    public virtual void Print()
    {
        if(_isPrint)
            PrintLogic();
        
        PrintChilds();
    }

    private void PrintChilds()
    {
        if (_childs == null)
            return;

        foreach (var child in _childs)
        {
            child.Print();
        }
    }

    protected abstract void PrintLogic();
}