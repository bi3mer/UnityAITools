﻿using UnityEngine.Assertions;
using System;

namespace AITools.NGram
{
    public static class NGramFactory<T> where T : Enum
    {
        public static IGram<T> InitializeGrammar(int n)
        {
            Assert.IsTrue(n >= 1);

            IGram<T> gram;
            if (n == 1)
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
