using CoinJarApp.Code.CoinJar;
using CoinJarApp.Controllers;
using CoinJarApp.Api.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinJarApp.Code.Coin.US;
using System;
using System.Linq;
using CoinJarApp.Code.Coin;

namespace CoinJarUnitTest
{
    [TestClass]
    public class CoinJarControllerUnitTest
    {
        private CoinJarController controller { get; set; }

        public CoinJarControllerUnitTest()
        {
            controller = new CoinJarController();
        }

        [TestMethod]
        public void GetTotalAmount()
        {
            Assert.AreEqual(controller.GetTotalAmount().Value, 0);
        }

        [TestMethod]
        public void AddCoin()
        {
            var baseType = typeof(USCoin);
            //Get all subclass of type USCoin which would be valid coins
            var allCoinTypes = AppDomain.CurrentDomain.GetAssemblies()
                             .SelectMany(assembly => assembly.GetTypes())
                             .Where(type => type.IsSubclassOf(baseType));

            decimal expectedTotalAmount = 0;
            decimal expectedTotalVolume = 0;
            ICoin tempCoin;
            foreach(var coinType in allCoinTypes)
            {
                tempCoin = (ICoin)Activator.CreateInstance(coinType);

                expectedTotalAmount += tempCoin.Amount;
                expectedTotalVolume += tempCoin.Volume;

                AddCoin(coinType.Name);
            }

            Assert.AreEqual(expectedTotalAmount, CoinJar.Current.Amount);
            Assert.AreEqual(expectedTotalVolume, CoinJar.Current.Volume);
        }

        public void AddCoin(string CoinType)
        {
            controller.AddCoin(new AddCoinModel()
            {
                CoinType = CoinType
            });
        }

        [TestMethod]
        public void Reset()
        {
            controller.Reset();

            Assert.AreEqual(CoinJar.Current.Amount, 0);
            Assert.AreEqual(CoinJar.Current.Volume, 0);
        }
    }
}
