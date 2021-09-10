﻿using System;
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
            

        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
           
        }
//        con.Open();
//            string to, from, pass, messageBody;
//        MailMessage message = new MailMessage();
//        to = txtEmail.Text;
//            from = "janeaustinasia@gmail.com";
//            pass = "Favzy1999";
//            messageBody = txtEmail.Text;
//            message.To.Add(to);
//            message.From = new MailAddress(from);
//        message.Body = "From : " + " Message : " + messageBody;
//            message.Subject = txtEmail.Text;
//            message.IsBodyHtml = true;
//            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
//        smtp.EnableSsl = true;
//            smtp.Port = 587;
//            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
//            smtp.Credentials = new NetworkCredential(from, pass);

//            try
//            {
//                smtp.Send(message);
//                DialogResult code = MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

//                if(code == DialogResult.OK)
//                {
//                    txtEmail.Clear();
//                    txtPassword.Clear();
//                    new DashBoard().Show();
//                    this.Show();
//    }

//}
//            catch (Exception ex)
//{
//    MessageBox.Show(ex.Message);
//}
    }
}
