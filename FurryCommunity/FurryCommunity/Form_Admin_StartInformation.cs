using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurryCommunity;

namespace FurryCommunity
{
    public partial class Form_Admin_StartInformation : Form
    {
      
        public Form_Admin_StartInformation()
        {
            InitializeComponent();
        }

        private void ItIsMeButton_Click(object sender, EventArgs e)
        {
            Form formItIsMe = new Form_ItIsMe();
            formItIsMe.Show();
            this.Hide();
            formItIsMe.FormClosing += FormItISMECLosing;
        }
        public void FormItISMECLosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

       

        private void Form_StartInformation_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_all_reputation formReputaions = new Form_all_reputation();
            formReputaions.Show();
            this.Hide();
            formReputaions.FormClosing += FormReputationClosing;
        }
        public void FormReputationClosing(object sender,FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Shelter_House formShelter = new Form_Shelter_House();
            formShelter.Show();
            this.Hide();
            formShelter.FormClosing += FormShelterClosing;
        }
        public void FormShelterClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
