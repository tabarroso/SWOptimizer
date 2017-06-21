using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Administrator : Member
    {
        public Administrator(string login, string password) : base(login, password) { }

        public Administrator() : base() { }
    }
}
