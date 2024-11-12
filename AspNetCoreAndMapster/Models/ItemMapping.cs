using Mapster;

using MapsterMapper;
using System.Reflection;

namespace AspNetCoreAndMapster.Models
{
    public static class ItemMapping
    {
        public static TypeAdapterConfig RegisterMappings()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            // Define mapping between Item and ItemDto
            config.NewConfig<Item, ItemDto>();

            return config;
        }
    }
}
