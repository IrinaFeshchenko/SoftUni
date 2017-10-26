namespace SimpleMvcFramework.Contracts
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}
