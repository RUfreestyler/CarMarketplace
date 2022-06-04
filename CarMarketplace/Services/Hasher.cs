namespace CarMarketplace.Services
{
    public static class Hasher
    {
        public static int GetHashCode(string input)
        {
            var result = 0;
            for (int i = input.Length - 1, j = 1; i >= 0;i--, j++)
            {
                result += input[i] * (int)Math.Pow(3, j); 
            }
            return result;
        }
    }
}
