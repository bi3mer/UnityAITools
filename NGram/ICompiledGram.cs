using System;

namespace AITools.NGram
{
    public interface ICompiledGram<T> where T : Enum
    {
        T Get(T[] inData);
    }
}
