namespace MakeChange
{
    public static class Program
    {
        public static int MakeChange(int amount)
        {
            var units = new[] { 100, 50, 20, 10, 5, 1 };
            var result = 0;
            while (amount > 0)
            {
                foreach (var unit in units)
                {
                    if (amount - unit < 0) continue;

                    amount -= unit;
                    result++;
                    break;
                }
            }
            return result;
        }
    }
}
