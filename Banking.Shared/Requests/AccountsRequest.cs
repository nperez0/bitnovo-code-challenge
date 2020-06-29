using System.Collections.Generic;

namespace Bitnovo.Banking.Shared.Requests
{
    public class AccountsRequest
    {
        public IEnumerable<int> CustomerIds { get; set; }
    }
}
