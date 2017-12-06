using AutoMapper;

namespace BookShop.Common.Mapping
{
    public interface IHaveCustomMappings
    {
        void ConfigureMapping(Profile mapper);
    }
}
