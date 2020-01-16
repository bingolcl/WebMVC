using Data;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        ILogService _logService;
        IUserService _userService;

        public AuthenticationService(ILogService logService, IUserService userService)
        {
            _logService = logService;
            _userService = userService;
        }

        public void SignIn(User user, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.AdUsername,
                now,
                now.Add(FormsAuthentication.Timeout),
                createPersistentCookie,
                user.AdUsername,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);

            //if (HttpContext.Current.Session != null)
            //{
            //    if (HttpContext.Current.Session["UserName"] == null)
            //    {
            //        HttpContext.Current.Session["UserName"] = user.AdUsername;
            //        HttpContext.Current.Session["Email"] = user.Email;
            //        HttpContext.Current.Session["IsAdministrator"] = user.Roles.Any(r => r.Name == "Administrator");
            //        HttpContext.Current.Session["IsSalesManager"] = user.Roles.Any(r => r.Name == "SalesManager");
            //        HttpContext.Current.Session["IsAccountant"] = user.Roles.Any(r => r.Name == "Accountant");
            //    }
            //}
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Clear();
        }

        public User GetAuthenticatedUser()
        {
            if (HttpContext.Current == null || HttpContext.Current.Request == null ||
                !HttpContext.Current.Request.IsAuthenticated || !(HttpContext.Current.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
            var user = GetAuthenticatedUserFromTicket(formsIdentity.Ticket);
            if (user != null && user.IsActive)
                return user;

            return null;
        }

        public User GetAuthenticatedUserFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var username = ticket.UserData;

            if (String.IsNullOrWhiteSpace(username))
                return null;
            var user = _userService.GetUserByADUserName(username);
            return user;
        }
    }
}
