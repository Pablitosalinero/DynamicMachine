using DynamicMachine.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace DynamicMachine.plugin
{
    public class DynamicMachineLimited : IDynamicMachine
    {
        public IEnumerable Change(IEnumerable coins, int value, IEnumerable limit, int nCoins)
        {
            ArrayList coinsList = coins as ArrayList;
            ArrayList limitList = limit as ArrayList;
            ArrayList res = new ArrayList();
            if (value == 0){
                for (int i = 0; i < nCoins; i++)
                {
                    res.Add(0);
                }
                return res;
            }
            if(value < 0)
            {
                for (int i = 0; i < nCoins; i++)
                {
                    res.Add(Int32.MaxValue);
                }
                return res;
            }
            if (coinsList.Count == 1)
            {
                if((int)value/(int)coinsList[coinsList.Count - 1] <= (int)limitList[coinsList.Count - 1])
                {
                    res.Add((int)value / (int)coinsList[coinsList.Count - 1]);
                } else
                {
                    res.Add(Int32.MaxValue);
                }
                for (int i = 0; i < nCoins - 1; i++)
                {
                    res.Add(0);
                }
                return res;
            }

            ArrayList res1 = Change(coinsList, value - (int)coinsList[^1], limitList, nCoins) as ArrayList;
            ArrayList coinsListForNext = coinsList.Clone() as ArrayList;
            coinsListForNext.RemoveAt(coinsList.Count - 1);
            ArrayList res2 = Change(coinsListForNext, value, limitList, nCoins) as ArrayList;
            ArrayList res3 = Change(coinsListForNext, value - ((int)limitList[coinsList.Count - 1] * (int)coinsList[^1]), limit, nCoins) as ArrayList;
            res1[coinsList.Count - 1] = (int)res1[coinsList.Count - 1] + 1;
            res3[coinsList.Count - 1] = (int)res3[coinsList.Count - 1] + (int)limitList[coinsList.Count - 1];

            int sum1 = Int32.MaxValue, sum2 = Int32.MaxValue, sum3 = Int32.MaxValue;
            if (!res1.Contains(Int32.MaxValue))
            {
                sum1 = 0;
                foreach (var elem in res1)
                {
                    sum1 += (int)elem;
                }
            }

            if (!res2.Contains(Int32.MaxValue))
            {
                sum2 = 0;
                foreach (var elem in res2)
                {
                    sum2+= (int)elem;
                }
            }

            if (!res3.Contains(Int32.MaxValue))
            {
                sum3 = 0;
                foreach (var elem in res3)
                {
                    sum3 += (int)elem;
                }
            }

            if ((int)res1[coinsList.Count - 1] > (int)limitList[coinsList.Count - 1])
            {
                if (sum2 <= sum3) return res2;
                else return res3;
            } else {
                if (sum1 <= sum2) return res1;
                else return res2;
            }
        }

        public async Task<IEnumerable> ChangeAsync(IEnumerable coins, int value, IEnumerable limit, int nCoins)
        {
            ArrayList coinsList = coins as ArrayList;
            ArrayList limitList = limit as ArrayList;
            ArrayList res = new ArrayList();
            if (value == 0)
            {
                for (int i = 0; i < nCoins; i++)
                {
                    res.Add(0);
                }
                return res;
            }
            if (value < 0)
            {
                for (int i = 0; i < nCoins; i++)
                {
                    res.Add(Int32.MaxValue);
                }
                return res;
            }
            if (coinsList.Count == 1)
            {
                if ((int)value / (int)coinsList[coinsList.Count - 1] <= (int)limitList[coinsList.Count - 1])
                {
                    res.Add((int)value / (int)coinsList[coinsList.Count - 1]);
                }
                else
                {
                    res.Add(Int32.MaxValue);
                }
                for (int i = 0; i < nCoins - 1; i++)
                {
                    res.Add(0);
                }
                return res;
            }

            Task<IEnumerable> taskRes1 = ChangeAsync(coinsList, value - (int)coinsList[^1], limitList, nCoins);
            ArrayList coinsListForNext = coinsList.Clone() as ArrayList;
            coinsListForNext.RemoveAt(coinsList.Count - 1);
            Task<IEnumerable> taskRes2 = ChangeAsync(coinsListForNext, value, limitList, nCoins);
            Task<IEnumerable> taskRes3 = ChangeAsync(coinsListForNext, value - ((int)limitList[coinsList.Count - 1] * (int)coinsList[^1]), limit, nCoins);
            ArrayList res1 = await taskRes1 as ArrayList;
            ArrayList res2 = await taskRes2 as ArrayList;
            res1[coinsList.Count - 1] = (int)res1[coinsList.Count - 1] + 1;
            int sum1 = Int32.MaxValue, sum2 = Int32.MaxValue, sum3 = Int32.MaxValue;
            if ((int)res1[coinsList.Count - 1] > (int)limitList[coinsList.Count - 1])
            {
                ArrayList res3 = taskRes3.Result as ArrayList;
                res3[coinsList.Count - 1] = (int)res3[coinsList.Count - 1] + (int)limitList[coinsList.Count - 1];
                if (!res3.Contains(Int32.MaxValue))
                {
                    sum3 = 0;
                    foreach (var elem in res3)
                    {
                        sum3 += (int)elem;
                    }
                }
                    if (!res2.Contains(Int32.MaxValue))
                {
                    sum2 = 0;
                    foreach (var elem in res2)
                    {
                        sum2 += (int)elem;
                    }
                }
                if (sum2 <= sum3) return res2;
                else return res3;
            }
            else
            {
                if (!res2.Contains(Int32.MaxValue))
                {
                    sum2 = 0;
                    foreach (var elem in res2)
                    {
                        sum2 += (int)elem;
                    }
                }
                if (!res1.Contains(Int32.MaxValue))
                {
                    sum1 = 0;
                    foreach (var elem in res1)
                    {
                        sum1 += (int)elem;
                    }
                }
                if (sum1 <= sum2) return res1;
                else return res2;
            }
        }
    }
}
