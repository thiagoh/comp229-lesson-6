using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required for EF DB access
using comp229_lesson_6.Models;
using System.Web.ModelBinding;


namespace comp229_lesson_6 {
    public partial class StudentDetails : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack && Request.QueryString.Count > 0) {

                getStudent();
            }
        }

        private void getStudent() {

            int studentId = Convert.ToInt32(Request.QueryString.Get("StudentID"));

            using (ContosoContext db = new ContosoContext()) {

                Student student = (from students in db.Students
                                   where students.StudentID == studentId
                                   select students).FirstOrDefault();

                if (student != null) {
                    LastNameTextBox.Text = student.LastName;
                    FirstNameTextBox.Text = student.FirstMidName;
                    EnrollmentDateTextBox.Text = student.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e) {
            // Redirect back to the students page
            Response.Redirect("~/Contoso/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            // Use EF to conect to the server
            using (ContosoContext db = new ContosoContext()) {
                // use the student model to create a new student object and 
                // save a new record

                Student newStudent = new Student();

                int studentId = 0;

                if (Request.QueryString.Count > 0) // our URL has a STUDENTID in it
                {
                    // get the id from the URL
                    studentId = Convert.ToInt32(Request.QueryString.Get("StudentID"));
                    newStudent = (from student in db.Students
                                  where student.StudentID == studentId
                                  select student).FirstOrDefault();
                }

                // add form data to the new student record
                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                // use LINQ to ADO.NET to add / insert new student into the db

                if (studentId == 0) {
                    db.Students.Add(newStudent);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Contoso/Students.aspx");
            }
        }
    }
}