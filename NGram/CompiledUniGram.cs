using System.Collections.Generic;
using System;

using AITools.Utility;

namespace AITools.NGram
{
    public class CompiledUniGram<T> : ICompiledGram<T> where T : Enum
    {
        private readonly Dictionary<T, float> grammar = 
            new Dictionary<T, float>();

        private readonly List<T> keys;

        public CompiledUniGram(Dictionary<T, float> grammar)
        {
            float total = 0;
            foreach (float val in grammar.Values)
            {
                total += val;
            }

            foreach (KeyValuePair<T, float> pair in grammar)
            {
                this.grammar.Add(pair.Key, pair.Value / total);
            }

            keys = new List<T>(grammar.Keys);
        }

        /// <summary>
        /// inData is not used again to facillitate better intreface. I'm not
        /// sure the best way to avoid this problem but it is fine for now.
        /// </summary>
        /// <param name="inData"></param>
        /// <returns></returns>
        public T Get(T[] inData)
        {
            keys.Shuffle();

            float minVal = UtilityRandom.RandFloat(0f, 1f);
            float total = 0;
            T outVal = keys[keys.Count - 1];

            foreach(T key in keys)
            {
                total += grammar[key];

                if(total >= minVal)
                {
                    outVal = key;
                    break;
                }
            }

            return outVal;
        }
    }
}
