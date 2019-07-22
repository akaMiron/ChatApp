using System;
using System.Linq;

namespace CA.Domain.Entities
{
    public partial class User
    {
        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            return rolesArray.Select(role => this.Role.Any(p => string.Compare(p.Name, role, StringComparison.OrdinalIgnoreCase) == 0)).Any(hasRole => hasRole);
        }
    }
}
