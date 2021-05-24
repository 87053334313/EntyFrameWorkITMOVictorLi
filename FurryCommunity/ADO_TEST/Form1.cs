using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Furry_Community;Data Source=DESKTOP-4UPDGGT\SQLEXPRESS");
                SqlCommand command = new SqlCommand(" update  [engineering].[it_is_me] set photo=@ImageData where ID_I =1   ", connection);
                command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);
                string filename = @"C:\Users\VictorLi\Pictures\Spider.jpg";
                byte[] ImageData;
                using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open))
                {
                    ImageData = new byte[fs.Length];
                    fs.Read(ImageData, 0, ImageData.Length);
                }
                command.Parameters["@ImageData"].Value = ImageData;
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Вся логика успешна отработана");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            Furry_CommunityEntities dbContext = new Furry_CommunityEntities();
            var stroki = from table in dbContext.it_is_me
                         select table;
            dataGridView1.DataSource = stroki.ToList();
        }
    }
}
