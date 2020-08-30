using DynamicMachine.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace DynamicMachine.plugin
{
    public class DynamicMachineLimited : IDynamicMachine
    {
        public IEnumerable Change()
        {
            return new List<int>();
        }

    }
}
