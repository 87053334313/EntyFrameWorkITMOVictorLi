using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurryCommunity
{
    public partial class it_is_me
    {
       
        public it_is_me(string FirstName, string Second_Name, string Patrinymic, byte[] Photo, int id_how_to_contact , int id_reputation, string parol)
        {

            this.First_name = First_name;
            this.Second_name = Second_Name;
            this.Patronymic = Patronymic;
            this.Photo = Photo;
            this.ID_how_to_contact_me = id_how_to_contact;
            this.ID_reputation = id_reputation;


        }
        public it_is_me() { }
    }
}
