namespace SimpleMvcFramework.Contracts.Generic
{
    public interface IRenderable<TModel> : IRenderable
    {
        TModel Model { get; set; }
    }
}
