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
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace Login_System
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_User.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adap = new OleDbDataAdapter();

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Frm_Register().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db_Context db = new Db_Context();

            String Email = txtEmail.Text;
            String Password = txtPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @usn and `password` = @pass");
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Email;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            //if the user exists or doesn't exist
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("YES");
            }
            else
            {
                MessageBox.Show("NO");
            }

           
            //if (dbDataReader.Read() == true)
            //{
            //    new DashBoard().Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtEmail.Text = "";
            //    txtPassword.Text = "";
            //    txtEmail.Focus();
            //}
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
