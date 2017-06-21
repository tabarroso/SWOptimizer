using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class LoadAdministrators
    {
        private static LoadAdministrators lb = new LoadAdministrators();
        private LoadAdministrators()
        {
            Administrators.Instance = loadAdministrators("administrators.bin");
        }
        public static LoadAdministrators Instance
        {
            get
            {
                return lb;
            }
        }

        /// <summary>
        /// Load the administrator list
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The member list</returns>
        public Administrators loadAdministrators(String path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream flux = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.Open, FileAccess.Read))
                {
                    return (Administrators)formatter.Deserialize(flux);
                }
            }
            catch
            {
                return default(Administrators);
            }
        }
    }
}
