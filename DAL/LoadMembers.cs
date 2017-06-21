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
    /// <summary>
    /// This class is used to load the member list
    /// </summary>
    public sealed class LoadMembers
    {
        private static LoadMembers lb = new LoadMembers();
        private LoadMembers()
        {
            Members.Instance = loadMembers("Members.bin");
        }
        public static LoadMembers Instance
        {
            get
            {
                return lb;
            }
        }

        /// <summary>
        /// Load the member list
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The member list</returns>
        public Members loadMembers(String path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream flux = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.Open, FileAccess.Read))
                {
                    return (Members)formatter.Deserialize(flux);
                }
            }
            catch
            {
                return default(Members);
            }
        }
    }
}
