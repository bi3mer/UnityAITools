using System.Collections.Generic;

namespace AITools.NGram
{
    public class CompiledNGram : ICompiledGram 
    {
        private readonly Dictionary<string, ICompiledGram> grammar = 
            new Dictionary<string, ICompiledGram>();

        public CompiledNGram(Dictionary<string, UniGram> grammar)
        {
            foreach (KeyValuePair<string, UniGram> pair in grammar)
            {
                this.grammar[pair.Key] = pair.Value.Compile();
            }
        }

        public string Get(string[] inData)
        {
            return grammar[string.Join(",", inData)].Get(null);
        }
    }
}
