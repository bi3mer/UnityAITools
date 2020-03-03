using System.Collections.Generic;
using System;

namespace AITools.NGram
{
    public class CompiledNGram<T> : ICompiledGram<T> where T : Enum
    {
        private readonly Dictionary<string, ICompiledGram<T>> grammar = 
            new Dictionary<string, ICompiledGram<T>>();

        public CompiledNGram(Dictionary<string, UniGram<T>> grammar)
        {
            foreach (KeyValuePair<string, UniGram<T>> pair in grammar)
            {
                this.grammar[pair.Key] = pair.Value.Compile();
            }
        }

        public T Get(T[] inData)
        {
            return grammar[string.Join(",", inData)].Get(null);
        }
    }
}
