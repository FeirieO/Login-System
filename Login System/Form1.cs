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
    public partial class Frm_Register : Form
    {
        public Frm_Register()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_User.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adap = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and Password Fiels are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                con.Open();
                String Register = "INSERT INTO tbl_User Values {" + txtEmail.Text + " , " + txtPassword.Text + ")";
                cmd = new OleDbCommand(Register, con);
                OleDbDataReader dbDataReader = cmd.ExecuteReader();
                con.Close();

                txtEmail.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your Account has Successfully Been Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '0';
                txtComPassword.PasswordChar = '0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frm_Login().Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            new frm_Login().Show();
            this.Show();
        }

        private void Frm_Register_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "  Email")
            {
                txtEmail.Clear();
                txtEmail.ForeColor = Color.FromArgb(83, 179, 233);

            }

        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.ForeColor = Color.FromArgb(200, 200, 200);
                txtEmail.Text = "   Email";
            }
        }
    }
}
