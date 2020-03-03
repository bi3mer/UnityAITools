using System.Collections.Generic;
using System;

using UnityEngine.Assertions;

namespace AITools.NGram
{
    public class NGram<T> : IGram<T> where T : Enum
    {
        private readonly Dictionary<T[], UniGram<T>> grammar = new Dictionary<T[], UniGram<T>>();

        public int N { get; private set; }

        public NGram(int n)
        {
            N = n;
        }

        public void AddData(T[] inData, T outData)
        {
            Assert.IsTrue(inData.Length == N - 1);

            if (grammar.ContainsKey(inData))
            {
                grammar[inData].AddData(null, outData);
            }
            else
            {
                UniGram<T> uniGram = new UniGram<T>();
                uniGram.AddData(null, outData);
                grammar[inData] = uniGram;
            }
        }

        public void UpdateMemory(float percentRemembered)
        {
            foreach (T[] key in grammar.Keys)
            {
                grammar[key].UpdateMemory(percentRemembered);
            }
        }

        public ICompiledGram<T> Compile()
        {
            return new CompiledNGram<T>(grammar);
        }
    }
}
