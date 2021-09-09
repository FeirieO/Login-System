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
            con.Open();
            String Login = "SELECT * FROM tbl_User where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'";
            cmd = new OleDbCommand(Login, con);
            OleDbDataReader dbDataReader = cmd.ExecuteReader();

            if (dbDataReader.Read() == true)
            {
                new DashBoard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
