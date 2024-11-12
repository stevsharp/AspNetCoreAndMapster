using Mapster;

namespace AspNetCoreAndMapster.Models
{
    public static class ItemMapping
    {
        public static TypeAdapterConfig RegisterMappings()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<Item, ItemDto>();

            return config;
        }
    }
}
