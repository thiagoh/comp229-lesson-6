﻿using System;
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
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginButton_Click(object sender, EventArgs e) {

            // create a new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // search and create a new user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            // if a matches is found for the user
            if (user != null) {
                authenticate(user, userManager);
            } else {
                StatusLabel.Text = "Invalid username or password!";
                AlertFlash.Visible = true; 
            }
        }

        private void authenticate(IdentityUser user, UserManager<IdentityUser> userManager) {

            // authenticate and login the user

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            // sign in the user
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, userIdentity);

            // redirect to main menu
            Response.Redirect("~/Contoso/MainMenu.aspx");
        }
    }
}