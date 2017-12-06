using AutoMapper;

namespace BookShop.Commons.Mapping
{
    public interface IHaveCustomMappings
    {
        void ConfigureMapping(Profile mapper);
    }
}
