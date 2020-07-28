using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class GameUser
    {
        private string nume;
        private int idAvatar;

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public int AvatarID
        {
            get { return idAvatar; }
            set { idAvatar = value; }
        }
    }
}
