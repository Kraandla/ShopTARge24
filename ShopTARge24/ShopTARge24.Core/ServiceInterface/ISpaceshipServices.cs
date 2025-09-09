using ShopTARge24.ApplicationServices.Services.Dto;
using ShopTARge24.Core.Domain;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface ISpaceshipServices
    {
        Task<Spaceships> Create(SpaceshipDto dto);
    }
}
