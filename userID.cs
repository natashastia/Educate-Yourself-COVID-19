using System.Data;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserRegis
{
    public partial class Form
    {
        string connectionString = @"Data Source = (local)\sqle2012; Initial Catalog = UserRegistrationDB; Integrated Security= True;";
        public Form1()
        {
            InitialComponent ();
        }
        private vpid btnSubmit_Click (object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Tolong isi bagian wajib");
            else if (txtPassword.Text != textConfirmPassword.Text)
                MessageBow.Show("Password salah"); 
            else 
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCommand sqlCmd = new sqlCommand("UserAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@First Name", txtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Registration is successfull");
                Clear();
            }
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtUsername.Text = txtPassword.Text = txtConfirmPassword.Text = "";
        }
    }
}