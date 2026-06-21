
using System.Collections.Specialized;

namespace Resturants.Domain.Exceptions;

public class NotFoundExceptions(string type , string id) : Exception($"the {type} of {id} not found")
{
}
