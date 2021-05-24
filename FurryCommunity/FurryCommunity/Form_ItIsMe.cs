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
    public partial class Form_ItIsMe : Form
    {
        
        public Form_ItIsMe()
        {
            InitializeComponent();
            this.FormClosing += FormClosingDispose;
            try
            {

                  dbContext = new Furry_CommunityEntities();
                var zapros = from table in dbContext.it_is_me
                             select table;
                dataGridView1.DataSource = zapros.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Furry_CommunityEntities dbContext;
        private void FormClosingDispose(object sender,FormClosingEventArgs e )
        {
            if (dbContext != null)
                dbContext.Dispose();
            
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Add_New_PersonaData form_3 = new Form_Add_New_PersonaData();
            form_3.Show();
            this.Hide();
            form_3.FormClosed += Form_Add_Person_Closing;
        }

        public void Form_Add_Person_Closing(object sender,FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
               
             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            using (Furry_CommunityEntities dbcontext = new Furry_CommunityEntities())
            {
                try
                {
                    int number = (int)id_del.Value;
                    it_is_me UdalitID = dbContext.it_is_me.Where(i => i.ID_I == number).FirstOrDefault();
                    dbContext.it_is_me.Remove(UdalitID);
                    dbContext.SaveChanges();
                    MessageBox.Show("Все удалено перезагрузи страницу");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                dbContext = new Furry_CommunityEntities();
                var zapros = from table in dbContext.it_is_me
                             select table;
                dataGridView1.DataSource = zapros.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
