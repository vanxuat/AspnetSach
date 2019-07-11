using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Plus.v1;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websach.Areas.Admin.Controllers
{
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        // GET: Admin/AuthCallback
        protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
        {
            get { return new AppFlowMetadata(); }
        }
    }
    public class AppFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "599368181223-n75l5qrkvaeh40o09642pnphec9u5cbk.apps.googleusercontent.com",
                    ClientSecret = "RfyaY65ziQMc65XCt4YTW30T"
                },
                Scopes = new[] { PlusService.Scope.UserinfoEmail,
                    PlusService.Scope.UserinfoProfile,
                    PlusService.Scope.PlusMe

                },
                DataStore = new FileDataStore(HttpContext.Current.Server.MapPath("~/App_Data"), true)
            });

        public override string GetUserId(Controller controller)
        {
            // In this sample we use the session to store the user identifiers.
            // That's not the best practice, because you should have a logic to identify
            // a user. You might want to use "OpenID Connect".
            // You can read more about the protocol in the following link:
            // https://developers.google.com/accounts/docs/OAuth2Login.
            var user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
                controller.Session["user"] = user;
            }
            return user.ToString();

        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}