using CoinJarApp.Code.Coin;
using CoinJarApp.Code.CoinJar.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CoinJarApp.Code.CoinJar
{
    public class CoinJar : ICoinJar
    {
        public static CoinJar Current { get; private set; } = new CoinJar();
        public const decimal MAX_VOLUME = 42;
        public decimal Amount { get; private set; }
        public decimal Volume { get; private set; }

        private CoinJar()
        {
            Amount = 0;
            Volume = 0;
        }

        public void AddCoin(ICoin coin)
        {
            var tempVolume = Volume + coin.Volume;
            if (tempVolume > MAX_VOLUME)
                throw new CoinJarException($"Coin Jar doesn't have enough space. Current Volume: {Volume}, Max Volume: {MAX_VOLUME}, Coin Volume: {coin.Volume}");

            Amount += coin.Amount;
            Volume = tempVolume;
        }

        public decimal GetTotalAmount()
        {
            return Amount;
        }

        public void Reset()
        {
            Amount = 0;
            Volume = 0;
        }
    }
}
