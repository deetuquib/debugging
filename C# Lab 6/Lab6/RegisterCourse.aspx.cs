using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6.Models
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        // on page load
        protected void Page_Load(object sender, EventArgs e)
        {
            // error message initial visibility
            errorMessage.Visible = false;
            //disable panel2 visibility
            confirmationPanel.Visible = false;

            if (!IsPostBack)
            {
                // populating checklist
                foreach (Course c in Helper.GetAvailableCourses())
                {
                    courseChecklist.Items.Add(new ListItem($"{c.Title} - {c.WeeklyHours} hours per week", c.Code));
                }
            }
        }


        // on button click
        protected void button_Click(object sender, EventArgs e)
        {
            // initializing variables
            int sumWeeklyHours = 0;
            int sumCoursesSelected = 0;
            bool containsErrors = true;


            // if student name is empty
            if (string.IsNullOrEmpty(studentName.Text))
            {
                errorMessage.Visible = true;
                errorMessage.Text = "Please enter your name.";
            }


            // if status is not selected
            else if (studentStatusList.SelectedValue == "")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "Please select your status.";
            }


            // if all good
            else
            {

                foreach (ListItem listItem in courseChecklist.Items)
                {

                    if (listItem.Selected == true)
                    {
                        Course course = Helper.GetCourseByCode(listItem.Value);
                        sumWeeklyHours += course.WeeklyHours;
                        sumCoursesSelected++;

                        // error for full time - max 16 hours
                        if (studentStatusList.SelectedValue == "Full Time" && sumWeeklyHours > 16)
                        {
                            errorMessage.Visible = true;
                            errorMessage.Text = "Limit Exceeded: Full time students can only have up to 16 hours per week!";
                            containsErrors = true;
                        }

                        // error for part time - max 3 courses
                        else if (studentStatusList.SelectedValue == "Part Time" && sumCoursesSelected > 3)
                        {
                            errorMessage.Visible = true;
                            errorMessage.Text = "Limit Exceeded: Part time students can only have up to 3 courses!";
                            containsErrors = true;
                        }

                        // error for co-op students - max 4 hours
                        else if (studentStatusList.SelectedValue == "Co-op" && sumWeeklyHours > 4)
                        {
                            errorMessage.Visible = true;
                            errorMessage.Text = "Limit Exceeded: Co-op students can only have up 4 hours per week!";
                            containsErrors = true;
                        }

                        // error for co-op students - max 2 courses
                        else if (studentStatusList.SelectedValue == "Co-op" && sumCoursesSelected > 2)
                        {
                            errorMessage.Visible = true;
                            errorMessage.Text = "Limit Exceeded: Co-op students can only have up to 2 courses!";
                            containsErrors = true;
                        }

                        // no error
                        else
                        {
                            containsErrors = false;
                            errorMessage.Visible = false;

                            label.Text = studentName.Text + " has enrolled the following courses: ";

                            // add row
                            TableRow newRow = new TableRow();
                            confirmationTable.Rows.Add(newRow);

                            // add code
                            TableCell cell = new TableCell();
                            newRow.Cells.Add(cell);
                            cell.Text = course.Code.ToString();

                            // add title
                            cell = new TableCell();
                            newRow.Cells.Add(cell);
                            cell.Text = course.Title.ToString();

                            // add weekly hours
                            cell = new TableCell();
                            newRow.Cells.Add(cell);
                            cell.Text = course.WeeklyHours.ToString();
                        }
                    }

                    else //if (listItem.Selected == false)
                    {
                        errorMessage.Visible = true;
                        errorMessage.Text = "Please select at least one (1) course!";
                    }
                }

                // after foreach loop
                if (!containsErrors)
                {
                    // display panel2
                    confirmationPanel.Visible = true;

                    // disable text box, radio buttons, and panel1, other error message
                    studentName.Enabled = false;
                    studentStatusList.Enabled = false;
                    chooseCourses.Visible = false;
                    errorMessage.Visible = false;

                    // row
                    TableRow tableRow = new TableRow();
                    confirmationTable.Rows.Add(tableRow);

                    // cell 1 - colspan 2
                    TableCell cell = new TableCell();
                    tableRow.Cells.Add(cell);

                    cell.ColumnSpan = 2;
                    cell.Text = "Total";
                    cell.HorizontalAlign = HorizontalAlign.Right;

                    // cell 2
                    cell = new TableCell();
                    tableRow.Cells.Add(cell);
                    cell.Text = sumWeeklyHours.ToString();
                }
            }
        }
    }
}
