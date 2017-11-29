using System;

namespace CameraBazaar.Data.Models
{
    [Flags]
    public enum LightMeteringType
    {
        spot = 1,
        centerWeighted = 2,
        evaluative = 4
    }
}
