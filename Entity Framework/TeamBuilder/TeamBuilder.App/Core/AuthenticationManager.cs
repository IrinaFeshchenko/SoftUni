﻿
namespace TeamBuilder.App.Core
{
    using Models;
    using System;
    using Utilities;

    public static class AuthenticationManager
    {
        private static User currentUser;

        public static void Login(User user)
        {
            currentUser = user;
        }

        public static void Logout()
        {
            currentUser = null;
        }

        public static void Authorize()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static User GetCurrentUser()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.UserNotFound);
            }

            return currentUser;
        }
    }
}
