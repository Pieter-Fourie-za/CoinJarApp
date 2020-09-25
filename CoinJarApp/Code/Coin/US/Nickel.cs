using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Code.Coin.US
{
    public class Nickel : USCoin
    {
        public Nickel()
        {
            Volume = 1.5m;
            Amount = 0.05m;
        }
    }
}
