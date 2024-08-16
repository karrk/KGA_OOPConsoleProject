public static class ExpansionMethods
{
    public static int GetRandom(this int[] arr)
    {
        Random rand = new Random();
        return arr[rand.Next(0, arr.Length)];
    }
}