using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface
{
    public class IWeatherForecast
    {
        Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto Dto);
    }
}
