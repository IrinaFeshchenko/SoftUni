namespace CameraBazaar.App.Infrastructure.Extensions
{
    using CameraBazaar.Data.Models;

    public static class LightMeteringTypeExtensions
    {
        public static bool Contains(this LightMeteringType keys, LightMeteringType flag)
        {
            return (keys & flag) != 0;
        }
    }
}
