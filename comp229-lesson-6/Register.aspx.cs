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
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void CancelButton_Click(object sender, EventArgs e) {

            Response.Redirect("~/Default.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e) {

            // create a new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // search and create a new user object
            var user = new IdentityUser {
                UserName = UserNameTextBox.Text,
                PhoneNumber= PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text,
            };

            //create a new user in the db and store the results
            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            // check if successfully registered?

            if (result.Succeeded) {

                // authenticate and login the user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                // redirect to main menu
                Response.Redirect("~/Contoso/MainMenu.aspx");

            } else {

                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
        }
    }
}