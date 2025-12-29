using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.Models;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class UserSessionService
    {
        public LoginResponse? CurrentUser {get; private set;}
        public bool IsAuthenticated => CurrentUser != null;

        public void Setuser(LoginResponse user)
        {
            CurrentUser = user;
        }

        public void Clear()
        {
            CurrentUser = null;
        }
    }
}