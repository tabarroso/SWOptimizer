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
    public class SaveAdministrators
    {
        private SaveAdministrators()
        {
            saveAdministrators("Administrators.bin", Administrators.Instance);
        }
        public static SaveAdministrators Instance
        {
            get
            {
                return new SaveAdministrators();
            }
        }

        /// <summary>
        /// Save the member list
        /// </summary>
        /// <param name="path"></param>
        /// <param name="administrators"></param>
        private void saveAdministrators(String path, Administrators administrators)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream str = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(str, administrators);
            }
        }
    }
}
