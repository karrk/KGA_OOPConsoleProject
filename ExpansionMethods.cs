public static class ExpansionMethods
{
    /// <summary>
    /// 배열요소중 랜덤한 요소를 반환
    /// </summary>
    public static int GetRandom(this int[] arr)
    {
        Random rand = new Random();
        return arr[rand.Next(0, arr.Length)];
    }
}