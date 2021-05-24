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
    public partial class Form_run : Form
    {
        public Form_run()
        {
            InitializeComponent();
            
           
        }

        Form form2 = null;


        public void Form2Closing(object sender, CancelEventArgs e)
        {
            this.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
             form2 = new FormAdministratorOrClient();
            form2.FormClosing += Form2Closing;
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
