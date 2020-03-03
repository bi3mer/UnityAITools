using System;

namespace AITools.NGram
{
    public interface IGram<T> where T : Enum
    {
        void AddData(T[] inData, T outData);
        void UpdateMemory(float percentRemembered);
        ICompiledGram<T> Compile();
    }
}
