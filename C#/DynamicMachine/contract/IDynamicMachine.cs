
using System;
using System.Collections;
using System.Threading.Tasks;

namespace DynamicMachine.Contracts
{
    public interface IDynamicMachine
    {
        public IEnumerable Change(IEnumerable coins, int value, IEnumerable limit, int nCoins);
        public IEnumerable ChangeParallel(IEnumerable coins, int value, IEnumerable limit, int nCoins);
    }
}
