using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Tiles_Game
{
    public class Profile
    {
        public string Name { get; set; }

        public string AvatarDestination { get; set; }

        public Profile(string name, string avatarDestination)
        {
            Name = name;
            AvatarDestination = avatarDestination;
        }
    }
}
