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
    public partial class Form_Client_AutoRization : Form
    {
        public Form_Client_AutoRization()
        {
            InitializeComponent();
            using (dbContext = new Furry_CommunityEntities())
            {
                var allEmployees = from employees_table in dbContext.all_information
                                   select employees_table;
                ToolTip tooltip_1 = new ToolTip();
                tooltip_1.ShowAlways = true;
                tooltip_1.SetToolTip(label1,"Введи имя :Victor");
            }
        }
        Furry_CommunityEntities dbContext;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_login.Text != null || textBox_login.Text != "")
            {
              if(textBox_login.Text == "Victor")
                {
                    Form_Victor victor_form = new Form_Victor();
                    victor_form.Show();
                    this.Hide();
                    victor_form.FormClosing += VictorFormClosing;
                }
                else
                {
                    MessageBox.Show("Это прототип пока что введите в поле Victor и нажмите кнопку вход без пароля");
                }
            }
            else
            {
                MessageBox.Show("Вы ввели в поле не: \nVictor");
            }
        }
        public void VictorFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока что эта идея разрабатывается введие в поле логина:Victor\nзатем нажите кнпку вход без пароля");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
