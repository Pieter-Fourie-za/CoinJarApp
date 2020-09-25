using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Code.CoinJar.Exception
{
    public class CoinJarException : System.Exception
    {
        public CoinJarException(string message)
            : base (message)
        {

        }
    }
}
