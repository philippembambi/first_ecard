using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.Models;

namespace First.Ecard.Presentation.UI.Components.interfaces
{
    public interface ILoginService
    {
        Task<HttpResponseMessage> LoginAsync(LoginRequest request);
        Task LogoutAsync();
    }
}