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
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;

namespace Login_System
{
    public partial class Frm_Register : Form
    {

        public Frm_Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region
            string to, from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = txtEmail.Text;
            from = "janeaustinasia@gmail.com";
            pass = "feirie1999";
            messageBody = txtEmail.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "From : " + " Message : " + messageBody;
            message.Subject = txtEmail.Text;     
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(from, pass);
            #endregion
            //to add a new user
            Db_Context db = new Db_Context();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `email`, `password`, `confirm password`) VALUES (@email, @usn, @pass, @conpass)", db.getConnection());

            command.Parameters.Add("@email", MySqlDbType.Text).Value = txtEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUser.Text;
            command.Parameters.Add("pass", MySqlDbType.VarChar).Value = txtPassword.Text;
            command.Parameters.Add("conpass", MySqlDbType.VarChar).Value = txtComPassword.Text;

            //open account connection
            db.openConnection();

            //execute the query
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account Created Successfully");
            }
            else
            {
                MessageBox.Show("Error");
            }
            //close account connection
            db.closeConnection();

           
            //if (txtEmail.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            //{
            //    MessageBox.Show("Username and Password Fiels are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //    MessageBox.Show("Your Account has Successfully Been Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Password does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPassword.Text = "";
            //    txtComPassword.Text = "";
            //    txtPassword.Focus();
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
                //Hides Textbox password
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
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

        private void txtComPassword_TextChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
            else
            {
                //Hides Textbox password
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
        }
        
    }
}
