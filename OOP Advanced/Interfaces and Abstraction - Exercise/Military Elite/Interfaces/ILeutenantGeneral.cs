using System.Collections.Generic;

namespace Military_Elite
{
    public interface ILeutenantGeneral : IPrivate
    {
        IList<ISoldier> Soldiers { get; }
    }
}