using ShopTARge24.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface ICocktailServices
    {
        Task<Root> GetDrink(string strDrink);
    }
}
