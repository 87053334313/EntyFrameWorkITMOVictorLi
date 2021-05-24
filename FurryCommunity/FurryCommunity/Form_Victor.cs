using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FurryCommunity
{
    public partial class Form_Victor : Form
    {
        public Form_Victor()
        {
            try
            {
                InitializeComponent();
                using (dbcontext = new Furry_CommunityEntities())
                {
                    var zaprosVicorLi = (from allVictor_from_ItIsME in dbcontext.it_is_me
                                         where allVictor_from_ItIsME.First_name == "Victor"
                                         select allVictor_from_ItIsME).ToList();
                    foreach (var VictorDatas in zaprosVicorLi)
                    {
                        label_first_name.Text = VictorDatas.First_name;
                        myPhoto = VictorDatas.Photo;
                        textBox_FirstName.Text = VictorDatas.First_name;
                        textBox_otchestvo.Text = VictorDatas.Patronymic;
                        textBox_parol.Text = VictorDatas.Parol;
                        id_how_to_contact = VictorDatas.ID_how_to_contact_me;
                        textBox_SecondName.Text = VictorDatas.Second_name;
                        id_Victor = VictorDatas.ID_I;
                    }


                    var privateDatas = (from table in dbcontext.how_to_contact_me
                                        where table.ID_how_to_contact_me ==  id_how_to_contact
                                        select table).ToList();

                    textBox_telephone.Text =privateDatas[0].tepelhone;
                    textBox_email.Text = privateDatas[0].email;
                }
                pictureBox1.Image = ByteToImage(myPhoto);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        int id_Victor;
        int id_how_to_contact;
        Furry_CommunityEntities dbcontext;
        byte[] myPhoto;
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData,0,Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void button_ChangePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if(diag.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(diag.OpenFile());
                ImageConverter converter = new ImageConverter();
                myPhoto = (byte[])converter.ConvertTo(bm,typeof(byte[]));
                pictureBox1.Image = ByteToImage(myPhoto);
            }
        }

        private void textBox_parol_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Furry_CommunityEntities dbContext = new Furry_CommunityEntities())
            {
                try
                {
                    var Person = (from table in dbContext.it_is_me
                                  where table.ID_I == id_Victor
                                  select table).ToList();
                    Person[0].First_name = this.textBox_FirstName.Text;
                    Person[0].Second_name = this.textBox_SecondName.Text;
                    Person[0].Photo = this.myPhoto;
                    Person[0].Patronymic = this.textBox_otchestvo.Text;
                    Person[0].Parol = this.textBox_parol.Text;

                    var how_toContact = dbContext.how_to_contact_me.Where(x => x.ID_how_to_contact_me == 1).FirstOrDefault();
                    how_toContact.tepelhone = this.textBox_telephone.Text;
                    how_toContact.email = this.textBox_email.Text;
                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранились на сервере");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
