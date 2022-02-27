using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw08_pham
{
    public partial class _default : System.Web.UI.Page
    {
        
        private ListItem[] buildAvailableCourseList()
        {
            ListItem[] tempList = { new ListItem("CS 1301-4", "CS 1301-4"),
                                new ListItem("CS 1302-4", "CS 1302-4"),
                                new ListItem("CS 1303-4", "CS 1303-4"),
                                new ListItem("CS 2202-2", "CS 2202-2"),
                                new ListItem("CS 2224-2", "CS 2224-2"),
                                new ListItem("CS 3300-3", "CS 3300-3"),
                                new ListItem("CS 3301-1", "CS 3301-1"),
                                new ListItem("CS 3302-1", "CS 3302-1"),
                                new ListItem("CS 3340-3", "CS 3340-3"),
                                new ListItem("CS 4321-3", "CS 4321-3"),
                                new ListItem("CS 4322-3", "CS 4322-3")
                              };
            return tempList;
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // For initial page creation
            {
                ListItem[] availableCourses = buildAvailableCourseList();
                lbxAvailableClasses.DataSource = availableCourses;
                lbxAvailableClasses.DataTextField = "Text";
                lbxAvailableClasses.DataValueField = "Value";
                lbxAvailableClasses.DataBind();

            }
        }
        // Add the course from Available list to register list after click Add button 
        protected void AddButton_Click(object sender, EventArgs e)
        {

          // course are added
            int limitHours = 19;
            int lastHoursValue = getTheLastCourseAdd(); // last course that add to the register
            int limit = HoursRegisteredFor() + lastHoursValue;

            if (limit >= limitHours)
            {
                foreach (ListItem li in lbxAvailableClasses.Items)
                {
                    if (li.Selected)
                    {
                        li.Selected = false;
                    }
                }
                error.Visible = true;
                error.Text = "You cannot register for more than 19 hours.";
            }
            else
            {
                Move(lbxAvailableClasses, lbxRegisterClasses);
                
            }
            

                
         
            
            
           

        }
        // Remove the course from register list and add item back to available list 
        protected void removeButton_Click(object sender, EventArgs e)
        {
            Move(lbxRegisterClasses, lbxAvailableClasses);
            if (error.Text != null)
            {
                error.Visible = false;
            }
           
        }
        // reset the page 
        protected void resetButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        // helper method
        private void Move(ListBox source, ListBox destination)
        {
            // add the courses to register list 
            error2.Visible = false;
            ListItem li = new ListItem();
            foreach ( ListItem l in source.Items)
            {
                if (l.Selected)
                {
                    string text = l.Value;
                    li.Text = l.Text;
                    li.Value = l.Value;
         
                    destination.Items.Add(li);
                }
                
            }
            
            // remove the course from available list 
            for (int i = source.Items.Count -1; i>=0; i--)
            {
                if (source.Items[i].Selected)
                {
                    source.Items.Remove(source.Items[i]);
                }
            }
            // CheckboxList added
            double costExtra = ExtraCost();
            
            //add total hours and total cost
            int hours = HoursRegisteredFor();
            double cost = hours * 100 + costExtra;
            lblHours.Text = "Total Hours: " + hours.ToString();
            
            lblCost.Text = "Total Cost: $" + cost.ToString();

           
        }
        // caculate the extra cost 
        private double ExtraCost()
        {
            double costExtra = 0;
            foreach (ListItem liCheck in extraCost.Items)
            {
                if (liCheck.Selected)
                {
                    costExtra += Double.Parse(liCheck.Value);
                }
            }
            return costExtra;
        }
      // get the last hour added to the register 
        private int getTheLastCourseAdd()
        {
            int hour = 0;
            foreach (ListItem li in lbxAvailableClasses.Items)
            {
                if (li.Selected)
                {
                    hour += li.Value[li.Value.Length - 1] - '0';
                }
            }
            return hour;
        }
        // caculate the register hours
        private int HoursRegisteredFor()
        {
            int totalHours = 0;
            ListBox lB = lbxRegisterClasses;
           
            foreach ( ListItem l in lB.Items)
            {


                string strs = l.Value;
                char hourString = strs[strs.Length - 1];
                int hour = hourString - '0';
                totalHours += hour;
                

            }
           
            return totalHours;
          
        }
        // make available course 
        protected void Button3_Click(object sender, EventArgs e)
        {
            string makeCourse = "CS " + classNumber.Text + "-" + creditNumber.Text;
            int numequal = findEqualCourse(makeCourse, lbxAvailableClasses);
            int numequalRegister = findEqualCourse(makeCourse, lbxRegisterClasses);
            if (numequal == 0 && numequalRegister == 0)
             {
                    addAvailableClass(makeCourse);
              
            }
           
            else
            {
                error2.Visible = true;
                error2.Text = "Not Added. Course already exist.";
            }


        }
        // add the class that made by user to available list 
        private void addAvailableClass(string makeCourse)
        {
            string classNum = classNumber.Text;
            string creditNum = creditNumber.Text;
            error2.Visible = false;


            if (!string.IsNullOrEmpty(classNum) && !string.IsNullOrEmpty(creditNum))
            {
                if (checkNumericCredit(classNum) == true && checkNumericCredit(creditNum) == true)
                    {
                        ListItem li = new ListItem();
                        li.Value = makeCourse;
                        li.Text = makeCourse;
                        lbxAvailableClasses.Items.Add(li);
                    }
            }
        }
            
        // check if the input is the number 
        private bool checkNumericCredit(String input)
           
        {
            double numericValue;
            bool isNumber = double.TryParse(input, out numericValue);

            return isNumber;
        }
      
        // remove the classess in available list
        protected void Button4_Click(object sender, EventArgs e)
        {
            string makeCourse = "CS " + classNumber.Text + "-" + creditNumber.Text;
            int numequal = findEqualCourse(makeCourse, lbxAvailableClasses);
            int numequalRegister = findEqualCourse(makeCourse, lbxRegisterClasses);

            if (numequal != 0)
                {
                    lbxAvailableClasses.Items.Remove(lbxAvailableClasses.Items[numequal-1]);
                }
            else if (numequalRegister != 0)
            {
                error2.Visible = true;
                error2.Text = "Not removed. Course is registered for.";
            }
            else
            {
                error2.Visible = true;
                error2.Text = "Course not found";
            }
           
        }
        
        // find any matching classes with user input
        private int findEqualCourse(String makeCourse, ListBox source)
        {

            int numequal = 0;
            int i = 1;
            foreach (ListItem li in source.Items)
            {
                string availableClass = li.Value;
                int indexOfC = 0;
                int indexOfDash = availableClass.IndexOf("-");
                string preString = "CS " + classNumber.Text;
                if (makeCourse.Equals(availableClass) || preString.Equals(availableClass.Substring(indexOfC, indexOfDash)))
                {
                    numequal=i;

                }
                i++;

            }
            return numequal;
        }
    }
}