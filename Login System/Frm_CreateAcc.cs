using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Login_System
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        OleDbConnection dbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_User.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtConPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtConPassword.Text)
            {
                dbConnection.Open();
                string register = "INSERT INTO tbl_User Values ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                cmd = new OleDbCommand(register, dbConnection);
                cmd.ExecuteNonQuery();
                dbConnection.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConPassword.Text = "";

                MessageBox.Show("Your Account Has Been Successfully Created", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Does Not Match", "Please Re-Enter Password",, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConPassword.Text = "";
                txtPassword.Focus();
               
            }
        }

        private void checkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '.';
                txtConPassword.PasswordChar = '.';
            }
        }
    }
}
