
using System.Collections;

namespace DynamicMachine.Contracts
{
    public interface IDynamicMachine
    {
        public IEnumerable Change(IEnumerable coins, int value, IEnumerable limit, int nCoins);
    }
}
