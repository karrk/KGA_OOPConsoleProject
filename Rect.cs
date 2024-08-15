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

    public Rect(int m_startX, int m_startY, int m_nextX, int m_nextY, RectOption m_option = RectOption.Relative)
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
