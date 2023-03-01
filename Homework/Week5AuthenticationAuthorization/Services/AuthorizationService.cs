using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Week5AuthenticationAuthorization.Services
{
    public class AuthorizationService
    {
        public bool IsAuthorized(string page, User user)
        {
            bool isAuthorized = false;

            switch (page)
            {
                case "Index":
                    isAuthorized = IndexAuth(user);
                    break;
                case "Create":
                    isAuthorized = CreateAuth(user);
                    break;
                case "Delete":
                    isAuthorized = DeleteAuth(user);
                    break;
                case "Edit":
                    isAuthorized = EditAuth(user);
                    break;
                case "Details":
                    isAuthorized = DetailsAuth(user);
                    break;
                default:
                    break;
            }

            return isAuthorized;
        }

        private bool IndexAuth(User user)
        {
            if(user.Role == "User" || user.Role == "Admin" || user.Role == "Super Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CreateAuth(User user)
        {
            if (user.Role == "Admin" || user.Role == "Super Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EditAuth(User user)
        {
            if (user.Role == "Admin" || user.Role == "Super Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DeleteAuth(User user)
        {
            if ( user.Role == "Super Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DetailsAuth(User user)
        {
            if (user.Role == "Admin" || user.Role == "Super Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}