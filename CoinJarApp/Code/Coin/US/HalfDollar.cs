﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Code.Coin.US
{
    public class HalfDollar : USCoin
    {
        public HalfDollar()
        {
            Volume = 3;
            Amount = 0.5m;
        }
    }
}
