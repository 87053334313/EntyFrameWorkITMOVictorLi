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
    public partial class Form_Shelter_House : Form
    {
        public Form_Shelter_House()
        {
            InitializeComponent();
        }
        Furry_CommunityEntities dbcontext;
        private void Form_Shelter_House_Load(object sender, EventArgs e)
        {
            try
            {
                dbcontext = new Furry_CommunityEntities();

                var collect_Shelters = from table in dbcontext.id_shelter
                                       select table;
                dataGridView1.DataSource = collect_Shelters.ToList();
                
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FormClosing += ThisFormClosing;
            }
          
            
        }
        public void ThisFormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
