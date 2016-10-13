﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace comp229_lesson_6 {
    public partial class Site : System.Web.UI.MasterPage {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                // check is a user is logged in

                if (HttpContext.Current.User.Identity.IsAuthenticated) {

                    ContosoPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                } else {

                    ContosoPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }
            }

            SetActivePage();
        }

        private void SetActivePage() {
            switch (Page.Title) {
                case "Home":
                    home.Attributes.Add("class", "active");
                    break;
                case "Students":
                    students.Attributes.Add("class", "active");
                    break;
                case "Courses":
                    courses.Attributes.Add("class", "active");
                    break;
                case "Departments":
                    departments.Attributes.Add("class", "active");
                    break;
                case "About":
                    about.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}