using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_System
{
    public partial class frm_Login : Form
    {
        public frm_Login(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private string username;
        private void label6_Click(object sender, EventArgs e)
        {
            new Frm_Register().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db_Context db = new Db_Context();

            String Username = txtEmail.Text;
            String Password = txtPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE username` = @usn and `password` = @pass", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            //if the user exists or doesn't exist
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful");
            }
            else
            {
                MessageBox.Show("Invalid Email or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
