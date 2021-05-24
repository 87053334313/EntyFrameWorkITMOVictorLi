using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurryCommunity
{
    public partial class FormAdministratorOrClient : Form
    {
        public FormAdministratorOrClient()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Admin_StartInformation form_admin = new Form_Admin_StartInformation();
            form_admin.Show();
            this.Hide();
            form_admin.FormClosing += Form_admin_Closing;
        }
        public void Form_admin_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Client_AutoRization formToClient = new Form_Client_AutoRization();
            formToClient.Show();
            this.Hide();
            formToClient.FormClosing += FormCLientClosing;
        }
        public void FormCLientClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
