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
    public partial class Form_all_reputation : Form
    {
        ToolTip toolTip_forLinkedLabel = new ToolTip();
        public Form_all_reputation()
        {
            InitializeComponent();
            using (Furry_CommunityEntities dbContext = new Furry_CommunityEntities())
            {
                var all_reputation = from _reputations in dbContext.reputation
                                     select _reputations;
                 foreach(reputation rep in all_reputation)
                {
                    comboBox_fromDataBase.Items.Add(rep.acheivements.ToString());
                }

            }
            toolTip_forLinkedLabel.ShowAlways = true;
            toolTip_forLinkedLabel.SetToolTip(this.linkLabel1, "Рекомендуется добавлять роли только администраторам");
        }



        private void button_confirm_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach(String _str in checkedListBox_All_Animals.CheckedItems)
            {
                str = str + _str+"  ";  
            }
            MessageBox.Show("Ваши любимые жмвотные это :" + str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Furry_CommunityEntities dbContext  = new Furry_CommunityEntities())
            {
                try
                {
                    string str_toAdd = textBox1.Text;
                    reputation newReputaionAchivement = new reputation() { acheivements = str_toAdd };
                    dbContext.reputation.Add(newReputaionAchivement);
                    dbContext.SaveChanges();
                    MessageBox.Show("Данная роль была успешна добавлена на сервер");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"произошла ошибка!!!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox_fromDataBase.Items.Clear();
            using (Furry_CommunityEntities dbContext = new Furry_CommunityEntities())
            {
                var all_reputation = from _reputations in dbContext.reputation
                                     select _reputations;
                foreach (reputation rep in all_reputation)
                {
                    comboBox_fromDataBase.Items.Add(rep.acheivements.ToString());
                }

            }
        }
    }
}
