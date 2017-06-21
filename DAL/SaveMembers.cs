using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Save the member list when an istance is called
    /// </summary>
    public class SaveMembers
    {
        private SaveMembers()
        {
            saveMembers("Members.bin", Members.Instance);
        }
        public static SaveMembers Instance
        {
            get
            {
                return new SaveMembers();
            }
        }

        /// <summary>
        /// Save the member list
        /// </summary>
        /// <param name="path"></param>
        /// <param name="members"></param>
        private void saveMembers(string path, Members members)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream str = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(str, members);
            }
        }
    }
}
