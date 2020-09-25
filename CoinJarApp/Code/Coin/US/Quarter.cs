using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Code.Coin.US
{
    public class Quarter : USCoin
    {
        public Quarter()
        {
            Volume = 2;
            Amount = 0.25m;
        }
    }
}
