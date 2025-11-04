using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        Task<OpenWeatherDto.Root> GetWeatherByCityName(string City);
    }
}
