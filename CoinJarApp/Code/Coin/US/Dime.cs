using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Code.Coin.US
{
    public class Dime : USCoin
    {
        public Dime()
        {
            Volume = 1;
            Amount = 0.1m;
        }
    }
}
