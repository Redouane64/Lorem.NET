using System;
using System.Threading;

namespace LoremNET
{
    /*
     * http://stackoverflow.com/a/1785821/234132
     */
    public static class RandomHelper
    {
        private static int seedCounter = new Random().Next();
		private static int? customSeed = null;

        [ThreadStatic]
        private static Random rng;

        public static Random Instance
        {
            get
            {
                if (rng == null)
                {
                    int seed = Interlocked.Increment(ref seedCounter);
                    rng = new Random(customSeed ?? seed);
                }
                return rng;
            }
        }

		public static void SetCustomSeed(int seed) => customSeed = seed;
    }
}