using System.Collections.Generic;
using System;

using UnityEngine.Assertions;

namespace AITools.NGram
{
    public class UniGram<T> : IGram<T> where T : Enum
    {
        private Dictionary<T, float> grammar = new Dictionary<T, float>();

        /// <summary>
        /// InData is not used for this. There is likely a better way to do this
        /// that still keeps the interface but I haven't come up with one. 
        /// </summary>
        /// <param name="inData">Not used</param>
        /// <param name="outData"></param>
        public void AddData(T[] inData, T outData)
        {
            if (grammar.ContainsKey(outData) == false)
            {
                grammar.Add(outData, 1);
            }
            else
            {
                grammar[outData] += 1;
            }
        }

        public void UpdateMemory(float percentRemembered)
        {
            Assert.IsTrue(percentRemembered >= 0);
            Assert.IsTrue(percentRemembered <= 1);

            foreach (T key in grammar.Keys)
            {
                grammar[key] *= percentRemembered;
            }
        }

        public ICompiledGram<T> Compile()
        {
            return new CompiledUniGram<T>(grammar);
        }
    }
}
