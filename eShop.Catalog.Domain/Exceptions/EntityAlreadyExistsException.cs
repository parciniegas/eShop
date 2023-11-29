namespace eShop.Catalog.Domain.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException(string s): base(s)
    {
    }
}