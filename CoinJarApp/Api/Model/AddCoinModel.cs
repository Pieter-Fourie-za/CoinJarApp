using CoinJarApp.Api.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Api.Model
{
    public class AddCoinModel
    {
        [USCoinType]
        public string CoinType { get; set; }
    }
}
