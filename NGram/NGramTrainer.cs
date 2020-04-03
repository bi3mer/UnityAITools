using System.Collections.Generic;

namespace AITools.NGram
{
    public static class NGramTrainer
    {
        public static void Train(IGram grammar, List<string> tokens)
        {
            if (grammar.GetN() == 1)
            {
                TrainUniGram(grammar, tokens);
            }
            else
            {
                TrainNGram(grammar, tokens);
            }
        }

        private static void TrainUniGram(IGram grammar, List<string> tokens)
        {
            foreach (string token in tokens)
            {
                grammar.AddData(null, token);
            }
        }

        private static void TrainNGram(IGram grammar, List<string> tokens)
        {
            int capacity = grammar.GetN() - 1;
            Queue<string> queue = new Queue<string>(capacity);

            foreach (string token in tokens)
            {
                if (queue.Count == capacity)
                {
                    grammar.AddData(queue.ToArray(), token);
                    queue.Dequeue();
                }

                queue.Enqueue(token);
            }
        }
    }
}