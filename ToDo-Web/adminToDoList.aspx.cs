using BLL;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDo_Web
{
    public partial class adminToDoList : System.Web.UI.Page
    {
        public List<TodoTasks> todos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isUserLogin"] != null)
            {
                BusinessLayer businessLayer = new BusinessLayer();
                List<User> usrs = businessLayer.GetAllUsers();
                if (usrs != null)
                {
                    if(!IsPostBack)
                    {
                        usersCombobox.DataSource = usrs;
                        usersCombobox.DataTextField = "Email";
                        usersCombobox.DataValueField = "Email";
                        usersCombobox.DataBind();
                    }
                    if (Session["cbxSelectedUser"] != null)
                    {
                        usersCombobox.SelectedIndex = Convert.ToInt32(Session["cbxSelectedUser"]);
                    }
                    updateDataGridView();

                    if (Request.QueryString["message"] != null)
                    {
                        errorLbl.Text = Request.QueryString["message"];
                        if (errorLbl.Text.Contains("SUCCESS"))
                        {
                            errorLbl.CssClass = "text-success fw-bold";
                        }
                        else
                        {
                            errorLbl.CssClass = "text-danger fw-bold";
                        }
                        errorLbl.Visible = true;
                    }
                }
                else
                {
                    errorLbl.Text = "ERROR: Failed To Get Users Data!!!";
                    Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        private void updateDataGridView()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            todos = businessLayer.GetAllTodos();
        }

        protected void usersCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cbxSelectedUser"] = usersCombobox.SelectedIndex;
            
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (titleTextbox.Text.Equals(string.Empty))
            {
                errorLbl.Text = "ERROR: Title Cannot be Empty!!!";
                Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
            }
            else
            {
                if (isUniqueTitle())
                {
                    BusinessLayer businessLayer = new BusinessLayer();
                    bool flag = businessLayer.AddTaskForUser(titleTextbox.Text.Trim(), descriptionTextbox.Text.Trim(), usersCombobox.SelectedItem.ToString());
                    if (flag)
                    {
                        errorLbl.Text = "SUCCESS: Task Added Successfully!!!";
                        Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text); 
                    }
                    else
                    {
                        errorLbl.Text = "ERROR: Task Not Added!!!";
                        Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                    }
                }
                else
                {
                    errorLbl.Text = "ERROR: Title Must Be Unique!!!";
                    Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                }
            }
        }

        private bool isUniqueTitle()
        {
            foreach (var item in todos)
            {
                if(item.Title.ToLower() == titleTextbox.Text.ToLower().Trim() && item.UserEmail == usersCombobox.SelectedItem.ToString())
                {
                    return false;
                }
            }
            return true;
        }
        private bool isTitleExists()
        {
            foreach (var task in todos)
            {
                if (task.Title.Trim() == titleTextbox.Text.Trim() && task.UserEmail == usersCombobox.SelectedItem.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (titleTextbox.Text.Equals(string.Empty))
            {
                errorLbl.Text = "ERROR: Title Cannot be Empty!!!";
                Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text + Session["cbxSelectedUser"].ToString());
            }
            else
            {
                if (isTitleExists())
                {
                    BusinessLayer businessLayer = new BusinessLayer();
                    bool flag = businessLayer.UpdateTaskForUser(titleTextbox.Text.Trim(), descriptionTextbox.Text.Trim(), usersCombobox.SelectedValue.ToString());
                    if (flag)
                    {
                        errorLbl.Text = "SUCCESS: Task UPDATED Successfully!!!";
                        Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                    }
                    else
                    {
                        errorLbl.Text = "ERROR: Task Not Added!!!";
                        Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                    }
                }
                else
                {
                    errorLbl.Text = "ERROR: Title Does'nt Match!!! Please Enter Correct Title to Update!!!!";
                    Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                }
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (titleTextbox.Text.Equals(string.Empty))
            {
                errorLbl.Text = "ERROR: Title Cannot be Empty!!!";
                Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text + Session["cbxSelectedUser"].ToString());
            }
            else
            {
                if (isTitleExists())
                {
                    BusinessLayer businessLayer = new BusinessLayer();
                    bool flag = businessLayer.DeleteTaskForUser(titleTextbox.Text.Trim(), descriptionTextbox.Text.Trim(), usersCombobox.SelectedValue.ToString());
                    if (flag)
                    {
                        errorLbl.Text = "SUCCESS: Task DELETED Successfully!!!";
                        Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                    }
                    else
                    {
                        errorLbl.Text = "ERROR: Task Not DELETED!!!";
                        Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                    }

                }
                else
                {
                    errorLbl.Text = "ERROR: Title Does'nt Match!!! Please Enter Correct Title to Delete!!!!";
                    Response.Redirect("~/adminToDoList.aspx?message=" + errorLbl.Text);
                }
            }
        }

        protected void SignOutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}