using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using System.Data.Linq;
using QuanLyDaiHocGiaDinh.Model;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class UserHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int AccountId = 0;
        public UserHome()
        {
            InitializeComponent();
            setVisibleScheduleRibbonPage(false);
            this.scheduleTableAdapter.Fill(this.giaDinhUniversityDataSet.Schedule, AccountId);
        }

        public UserHome(int AccountNo)
        {
            AccountId = AccountNo;
            InitializeComponent();
            setVisibleScheduleRibbonPage(false);
            this.scheduleTableAdapter.Fill(this.giaDinhUniversityDataSet.Schedule, AccountId);
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
            if (navigationFrame.SelectedPageIndex == 0)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleHomeRibbonPage(true);
            }
            else if (navigationFrame.SelectedPageIndex == 1)
            {
                setVisibleScheduleRibbonPage(true);
                setVisibleHomeRibbonPage(false);
            }
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void schedulerDataStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            scheduleTableAdapter.Update(giaDinhUniversityDataSet);
            giaDinhUniversityDataSet.AcceptChanges();
        }

        private void schedulerControl_InitNewAppointment(object sender, AppointmentEventArgs e)
        {
            e.Appointment.CustomFields["AccountId"] = AccountId;
        }

        private void setVisibleScheduleRibbonPage(bool status)
        {
            fileScheduleRibbonPage.Visible = status;
            homeScheduleRibbonPage.Visible = status;
            viewScheduleRibbonPage.Visible = status;
        }

        private void setVisibleHomeRibbonPage(bool status)
        {
            homeRibbonPage.Visible = status;
        }


        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {
       

            using (Model.LinQDataContext db =new Model.LinQDataContext())
            {
                dataGridView1.DataSource = from u in db.Employees select u;
                Services.AccountServices accountServices = new Services.AccountServices();
                    List<Account> accounts = accountServices.GetAllAccounts();
                accounts.ForEach(x =>
                {


                    txtEmployeeID.DataBindings.Clear();
                    txtEmployeeID.DataBindings.Add("TEXT", dataGridView1.DataSource, "EmployeeId").ToString();

                    txtFirstName.DataBindings.Clear();
                    txtFirstName.DataBindings.Add("TEXT", dataGridView1.DataSource, "FirstName").ToString();

                    txtLastName.DataBindings.Clear();
                    txtLastName.DataBindings.Add("TEXT", dataGridView1.DataSource, "LastName").ToString();

                    txtFullName.DataBindings.Clear();
                    txtFullName.DataBindings.Add("TEXT", dataGridView1.DataSource, "FullName").ToString();

                    txtPhoneNumber.DataBindings.Clear();
                    txtPhoneNumber.DataBindings.Add("TEXT", dataGridView1.DataSource, "PhoneNumber").ToString();

                    txtAddress.DataBindings.Clear();
                    txtAddress.DataBindings.Add("TEXT", dataGridView1.DataSource, "Address").ToString();

                    txtCity.DataBindings.Clear();
                    txtCity.DataBindings.Add("TEXT", dataGridView1.DataSource, "City").ToString();

                    txtDistrict.DataBindings.Clear();
                    txtDistrict.DataBindings.Add("TEXT", dataGridView1.DataSource, "District").ToString();

                    txtEmail.DataBindings.Clear();
                    txtEmail.DataBindings.Add("TEXT", dataGridView1.DataSource, "Email").ToString();

                    txtHireDate.DataBindings.Clear();
                    txtHireDate.DataBindings.Add("TEXT", dataGridView1.DataSource, "HireDate").ToString();

                    txtStatus.DataBindings.Clear();
                    txtStatus.DataBindings.Add("TEXT", dataGridView1.DataSource, "Status").ToString();

                    txtWard.DataBindings.Clear();
                    txtWard.DataBindings.Add("TEXT", dataGridView1.DataSource, "Ward").ToString();
                });

            }

        }
        
       

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

  

        private void btnUpdates_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserHomeUpdate userupdate = new UserHomeUpdate();
            userupdate.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangesPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserHomeChangePassword userHomeChangePassword = new UserHomeChangePassword();
            userHomeChangePassword.ShowDialog();
        }
    }
}