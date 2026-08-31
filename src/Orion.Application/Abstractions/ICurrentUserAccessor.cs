using Orion.Core.Auth;

namespace Orion.Application.Abstractions;

public interface ICurrentUserAccessor
{
    CurrentUser User { get; }
}
