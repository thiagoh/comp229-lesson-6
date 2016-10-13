using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace comp229_lesson_6 {
    public partial class Logout : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            // store session info and authentication methods in authenticationmanager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            authenticationManager.SignOut();

            // redirect
            Response.Redirect("~/Login.aspx");
        }
    }
}