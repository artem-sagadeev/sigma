namespace Sigma.Web.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string messae) : base(messae) {}
}