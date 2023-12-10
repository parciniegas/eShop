namespace eShop.Common.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException(string s): base(s)
    {
    }
}