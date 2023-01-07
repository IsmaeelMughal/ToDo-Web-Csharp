using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDo_Web
{
    public partial class SignUp : System.Web.UI.Page
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

        protected void toLoginLbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            if (IsAnyEmptyField())
            {
                errorLbl.Text = "ERROR: Fields cannot be empty!!!";
                errorLbl.Visible = true;
                return;
            //    Response.Redirect("~/SignUp.aspx?message=" + errorLbl.Text);
            }
            else
            {
                if (isSamePasswords())
                {
                    if (isAdminemail())
                    {
                        errorLbl.Text = "ERROR: This email is reserverd!!!";
                        Response.Redirect("~/SignUp.aspx?message=" + errorLbl.Text);
                    }
                    else
                    {
                        BusinessLayer bll = new BusinessLayer();
                        if (bll.AddUser(signupNicknameTextBox.Text.Trim(),
                            signupEmailTextbox.Text.Trim(),
                            signupPasswordTextbox.Text.Trim()))
                        {
                            errorLbl.Text = "SUCCESS: User Added Successfully!!!";
                            Response.Redirect("~/SignUp.aspx?message=" + errorLbl.Text);
                        }
                        else
                        {
                            errorLbl.Text = "ERROR: Failed to Add User!!!";
                            Response.Redirect("~/SignUp.aspx?message=" + errorLbl.Text);
                        }
                    }
                }
                else
                {
                    errorLbl.Text = "ERROR: Password Dose'nt Match!!!";
                    Response.Redirect("~/SignUp.aspx?message=" + errorLbl.Text);
                }
            }
        }

        private bool isAdminemail()
        {
            if (signupEmailTextbox.Text.Trim().ToLower().Contains("admin"))
            {
                return true;
            }
            return false;
        }

        private bool isSamePasswords()
        {
            if (signupPasswordTextbox.Text == signupConfirmPasswordTextbox.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsAnyEmptyField()
        {
            if (signupNicknameTextBox.Text.Trim() == "" ||
            signupEmailTextbox.Text.Trim() == "" ||
            signupPasswordTextbox.Text.Trim() == "" ||
            signupConfirmPasswordTextbox.Text.Trim() == "")
            {
                return true;
            }
            return false;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            signupNicknameTextBox.Text = "";
            signupEmailTextbox.Text = "";
            signupPasswordTextbox.Text = "";
            signupConfirmPasswordTextbox.Text = "";
        }

        protected void signupNicknameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (errorLbl.Visible)
            {
                errorLbl.Visible = false;
            }
        }
    }
}