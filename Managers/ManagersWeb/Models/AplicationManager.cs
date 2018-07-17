using ManagersWeb.DB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagersWeb.Models
{
        public class ApplicationManager : UserManager<ApplicationUser>
        {
            public ApplicationManager(IUserStore<ApplicationUser> store) : base(store)
            {
            }
            public static ApplicationManager Create(IdentityFactoryOptions<ApplicationManager> options,
                                                IOwinContext context)
            {
                DBContext db = context.Get<DBContext>();
                ApplicationManager apManager = new ApplicationManager(new UserStore<ApplicationUser>(db));
                return apManager;
            }
        }
    }

