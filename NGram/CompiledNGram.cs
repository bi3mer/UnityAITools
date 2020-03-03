using System.Collections.Generic;
using System;

using UnityEngine.Assertions;

namespace AITools.NGram
{
    public class CompiledNGram<T> : ICompiledGram<T> where T : Enum
    {
        private readonly Dictionary<T[], ICompiledGram<T>> grammar = 
            new Dictionary<T[], ICompiledGram<T>>();

        public CompiledNGram(Dictionary<T[], UniGram<T>> grammar)
        {
            foreach (KeyValuePair<T[], UniGram<T>> pair in grammar)
            {
                this.grammar[pair.Key] = pair.Value.Compile();
            }
        }

        public T Get(T[] inData)
        {
            Assert.IsTrue(grammar.ContainsKey(inData));
            return grammar[inData].Get(null);
        }
    }
}
