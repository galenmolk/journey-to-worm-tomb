namespace WormTomb.Utils
{
    public static class BoolExtensions
    {
        public static int ToSign(this bool value)
        {
            return value ? 1 : -1;
        }

        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }
    }
}
