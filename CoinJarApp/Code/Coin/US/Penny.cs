using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Code.Coin.US
{
    public class Penny : USCoin
    {
        public Penny()
        {
            Volume = 1;
            Amount = 0.01m;
        }
    }
}
