namespace LSQ.OOPs
{
    // Extensions
    static class Utils
    {
        // Checks if the number is positive or not
        public static bool IsPositive(this int data)
        {
            return data > 0;
        }

        // Checks if the value is not null and is not empty
        public static bool IsValid(this string data)
        {
            return data != null && data.Length != 0;
        }
    }
}
