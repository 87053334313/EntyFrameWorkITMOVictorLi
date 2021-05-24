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
    public partial class Form_Add_New_PersonaData : Form
    {


        public Form_Add_New_PersonaData()
        {
            InitializeComponent();
            this.FormClosing += FormClosingDispose;
        }

        public void FormClosingDispose(object sender, FormClosingEventArgs e)
        {
            if(mydatas != null)
            {
                mydatas.Dispose();
            }
        }
        Furry_CommunityEntities mydatas;
        byte[] photo;
        bool zagruzhenoLiPhoto = false;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(dialog.OpenFile());
                ImageConverter converter = new ImageConverter();
                photo = (byte[])converter.ConvertTo(bm, typeof(byte[]));
                zagruzhenoLiPhoto = true;
                checkBox_ExplainPhoto.Checked = zagruzhenoLiPhoto;
                MessageBox.Show("фотография была успешно добавлена в массив байтов на форме ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Furry_CommunityEntities dbContext = new Furry_CommunityEntities())
            {
                try
                {

                    string name = textBox_Name.Text;
                    string lastname = textBox_LastName.Text;
                    string thirdname = textBox_ThirdName.Text;
                    int how_to_contact_me_foreignKey = 1;
                    int reputation_foreignKey = 1;
                    byte[] Photo;
                    if (photo!=null)
                    {
                        Photo = photo;
                    }
                    else
                    {
                        Photo = null;
                    }

                    string Parol = textBox_Parol.Text;
                    var classItIsMe = new it_is_me();
                    classItIsMe.Photo = Photo;
                    classItIsMe.First_name = name;
                    classItIsMe.Second_name = lastname;
                    classItIsMe.Patronymic = thirdname;
                    classItIsMe.ID_reputation = 1;
                    classItIsMe.ID_how_to_contact_me = 1;
                    classItIsMe.Parol = Parol;
                    dbContext.it_is_me.Add(classItIsMe);

                    //var person1 = new it_is_me() {First_name = "alex" , Second_name = "Tolstoy", Patronymic ="Fyodorocivh", ID_how_to_contact_me = 1, ID_reputation = 1 };
                    // dbContext.it_is_me.Add(person1);
                    dbContext.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void textBox_Parol_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
             mydatas = new Furry_CommunityEntities();
            var result = from table in mydatas.it_is_me
                         select table;
            dataGridView1.DataSource = result.ToList();
        }

        private void Form_Add_New_PersonaData_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
