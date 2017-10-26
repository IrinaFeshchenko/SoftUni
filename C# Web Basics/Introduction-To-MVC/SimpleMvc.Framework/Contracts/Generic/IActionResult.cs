namespace SimpleMvcFramework.Contracts.Generic
{
    public interface IActionResult<TModel> : IInvocable
    {
        IRenderable<TModel> Action { get; set; }
    }
}
