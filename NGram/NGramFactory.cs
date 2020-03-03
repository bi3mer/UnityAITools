using UnityEngine.Assertions;
using System;

namespace AITools.NGram
{
    public static class NGramFactory<T> where T : Enum
    {
        public static IGram<T> InitializeGramamr(int n)
        {
            Assert.IsTrue(n >= 0);

            IGram<T> gram;
            if (n == 0)
            {
                gram = new UniGram<T>();
            }
            else
            {
                gram = new NGram<T>(n);
            }

            return gram;
        }
    }
}
