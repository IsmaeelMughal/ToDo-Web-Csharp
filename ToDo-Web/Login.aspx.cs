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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void toSignupLbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUp.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (isAnyFeildEmpty())
            {
                errorLbl.Text = "ERROR: Fields cannot be empty!!!";
                Response.Redirect("~/Login.aspx?message=" + errorLbl.Text);
            }
            else
            {
                if (LoginEmailTextbox.Text == "admin@gmail.com" && LoginPasswordTextbox.Text == "admin")
                {
                    Session["isUserLogin"] = true;
                    Session["email"] = LoginEmailTextbox.Text;
                    Response.Redirect("~/adminToDoList.aspx");
                }
                else
                {
                    BusinessLayer businessLayer = new BusinessLayer();
                    User u = businessLayer.IsUserExist(LoginEmailTextbox.Text.Trim(), LoginPasswordTextbox.Text.Trim());
                    if (u != null)
                    {
                        Session["isUserLogin"] = true;
                        Session["email"] = LoginEmailTextbox.Text;
                        Session["nickname"] = u.Nickname;
                        Response.Redirect("~/userToDoList.aspx");
                    }
                    else
                    {
                        errorLbl.Text = "ERROR: Invalid email or password!!!";
                        Response.Redirect("~/Login.aspx?message=" + errorLbl.Text);
                    }

                }
            }
        }

        private bool isAnyFeildEmpty()
        {
            if (LoginEmailTextbox.Text.Trim() == "" ||
            LoginPasswordTextbox.Text.Trim() == "")
            {
                return true;
            }
            return false;
        }
    }
}