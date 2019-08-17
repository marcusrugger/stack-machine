using System;
using System.Collections.Generic;

namespace StackMachine
{
    class Machine
    {
        public Stack<Number> Stack { get; } = new Stack<Number>();

        public const int MAX_MEMORIES = 16;
        public List<Number> Memory { get; } = new List<Number>(MAX_MEMORIES);

        public Machine()
        {
            for (int a = 0; a < MAX_MEMORIES; a++)
                Memory.Add(new NumberInteger(0));
        }
    }
}