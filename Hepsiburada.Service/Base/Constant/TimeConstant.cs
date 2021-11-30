namespace Hepsiburada.Service.Base.Constant
{
    public class TimeConstant
    {
        private static int time = 0;
        private static readonly object forLock = new object();
        public static int Time => GetTime();

        private static int GetTime()
        {
            return time;
        }

        public static void Increase(int add)
        {
            lock (forLock)
            {
                time += add;
            }
        }
    }
}
