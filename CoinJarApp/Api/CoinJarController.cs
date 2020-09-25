using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinJarApp.Api.Model;
using CoinJarApp.Code.Coin;
using CoinJarApp.Code.Coin.US;
using CoinJarApp.Code.CoinJar;
using CoinJarApp.Code.CoinJar.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoinJarApp.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class CoinJarController : ControllerBase
    {
        [HttpGet]
        public ActionResult<decimal> GetTotalAmount()
        {
            return CoinJar.Current.Amount;
        }

        [HttpPost]
        public IActionResult AddCoin([FromBody]AddCoinModel input)
        {
            Type t = Type.GetType(typeof(Penny).Namespace + "." + input.CoinType);
            var coin = (ICoin)Activator.CreateInstance(t);

            try
            {
                CoinJar.Current.AddCoin(coin);
            }
            catch(CoinJarException cje)
            {
                return BadRequest(cje.Message);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Reset()
        {
            CoinJar.Current.Reset();
            return Ok();
        }


    }
}
