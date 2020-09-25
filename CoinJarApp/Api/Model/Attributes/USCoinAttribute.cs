using CoinJarApp.Code.Coin.US;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarApp.Api.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class USCoinTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputValue = value as string;
            var t = Type.GetType(typeof(Penny).Namespace + "." + inputValue);
            var baseT = typeof(USCoin);

            if (t == null || !t.IsSubclassOf(baseT))
            {
                //Return all possible US coin types which are the derived classes of USCoin
                return new ValidationResult(
                    "Invalid CoinType specified. Specify one of these types: " +
                    string.Join(", ", AppDomain.CurrentDomain.GetAssemblies()
                             .SelectMany(assembly => assembly.GetTypes())
                             .Where(type => type.IsSubclassOf(baseT))
                             .Select(a => a.Name)
                             .ToArray())
                    );
            }


            return ValidationResult.Success;
        }
    }
}
