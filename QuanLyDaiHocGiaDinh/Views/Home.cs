using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;
using QuanLyDaiHocGiaDinh.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDaiHocGiaDinh
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        private int AccountId = 0;
        private string userName = "";
        private string role = "";
        public Home()
        {
            InitializeComponent();
            txtUserName.Select();
            setVisibleFormAldreadyLogin(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            role = Login(txtUserName.Text, txtPassword.Text);
            openFormWithRole(role);
        }

        String Login(string user, string password)
        {
            string accountRole = "";
            bool isCorrect = false;
            AccountServices accountServices = new AccountServices();
            List<Account> accounts = accountServices.GetAllAccounts();
            accounts.ForEach(x =>
            {
                if (String.Compare(x.UserName.Trim(), user.Trim(), true) == 0)
                {
                    if (String.Compare(x.Password.Trim(), password.Trim(), true) == 0)
                    {
                        isCorrect = true;
                        accountRole = x.Role;
                        userName = x.UserName;
                        AccountId = x.AccountId;
                    }
                }
            });
            if (isCorrect == true)
            {
                return accountRole;
            }
            return accountRole;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            isLoginAdready(false, "Đăng nhập");
        }

        private void isLoginAdready(bool isLogin, string userName)
        {
            if (isLogin == true)
            {
                setVisibleFormLogin(false);
                setVisibleFormAldreadyLogin(true);
                laTitle.Text = "Hi, " + userName;
            }
            else
            {
                setVisibleFormLogin(true);
                setVisibleFormAldreadyLogin(false);
                laTitle.Text = "Đăng nhập";
            }
           
        }

        private void setVisibleFormAldreadyLogin(bool status)
        {
            btnLogout.Visible = status;
            btnComback.Visible = status;
        }

        private void setVisibleFormLogin(bool status)
        {
            txtPassword.Visible = status;
            txtUserName.Visible = status;
            btnLogin.Visible = status;
            btnExit.Visible = status;
        }

        private void openFormWithRole(string role)
        {
            if (String.Compare(role.Trim(), "employee", true) == 0)
            {
                UserHome userHome = new UserHome(AccountId);
                userHome.ShowDialog();
                isLoginAdready(true, userName);
            }
            else if (String.Compare(role.Trim(), "manage", true) == 0)
            {
                AdminHome adminHome = new AdminHome(AccountId);
                adminHome.ShowDialog();
                isLoginAdready(true, userName);
            }
            else
            {
                laNotice.Text = "Sai tài khoản hoặc mật khẩu";
            }
        }
        private void txtUserName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            laNotice.Text = "";
        }

        private void txtPassword_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            laNotice.Text = "";
        }

        private void btnComback_Click(object sender, EventArgs e)
        {
            openFormWithRole(role);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            btnLogin.Focus();
        }
    }
}
