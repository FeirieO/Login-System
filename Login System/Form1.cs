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

            OleDbConnection Con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_User.mdb"); 
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adap = new OleDbDataAdapter();
        }
    }
}
