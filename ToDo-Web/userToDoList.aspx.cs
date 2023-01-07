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
    public partial class userToDoList : System.Web.UI.Page
    {
        public List<TodoTasks> todos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isUserLogin"] != null)
            {
                usrEmailLabel.Text = "Email: " + Session["email"].ToString();
                userNicknameLabel.Text = "Nickname: " + Session["nickname"].ToString();
                updateDataGridView(Session["email"].ToString());
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
                Response.Redirect("~/login.aspx");
            }
        }
        private void updateDataGridView(String e)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            todos = businessLayer.GetAlltodosOfUser(e);
        }

        protected void SignOutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }

        private bool isTitleExists()
        {
            foreach (var task in todos)
            {
                if (task.Title.Trim() == titleTextbox.Text.Trim())
                {
                    return true;
                }
            }
            return false;
        }


        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            if (titleTextbox.Text.Equals(string.Empty))
            {
                errorLbl.Text = "ERROR: Title Cannot be Empty!!!";
                Response.Redirect("~/userToDoList.aspx?message=" + errorLbl.Text);
            }
            else
            {
                if (isTitleExists())
                {
                    BusinessLayer businessLayer = new BusinessLayer();
                    bool flag = businessLayer.DeleteTaskForUser(titleTextbox.Text.Trim(), descriptionTextbox.Text.Trim(), Session["email"].ToString());
                    if (flag)
                    {
                        errorLbl.Text = "SUCCESS: Task DELETED Successfully!!!";
                        Response.Redirect("~/userToDoList.aspx?message=" + errorLbl.Text);
                    }
                    else
                    {
                        errorLbl.Text = "ERROR: Task Not DELETED!!!";
                        Response.Redirect("~/userToDoList.aspx?message=" + errorLbl.Text);
                    }

                }
                else
                {
                    errorLbl.Text = "ERROR: Title Does'nt Match!!! Please Enter Correct Title to Delete!!!!";
                    Response.Redirect("~/userToDoList.aspx?message=" + errorLbl.Text);
                }
            }
        }
    }
}