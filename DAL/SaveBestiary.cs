using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    /// <summary>
    /// Save both bestiaries when an instance is called
    /// </summary>
    
    [Serializable]
    public class SaveBestiary
    {
        private SaveBestiary()
        {
            SaveBestiaryAwake("bestiaryAwake.bin", BestiaryAwake.Instance);
            SaveBestiaryNonAwake("bestiaryNawake.bin", BestiaryNonAwake.Instance);
        }

        public static SaveBestiary Instance
        {
            get
            {
                return new SaveBestiary();
            }
        }

        /// <summary>
        /// Save the awake bestiary
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bestiary"></param>
        private void SaveBestiaryAwake(String path, BestiaryAwake bestiary)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream str = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(str, bestiary);
            }
        }

        /// <summary>
        /// Save the non awake bestiary
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bestiary"></param>
        private void SaveBestiaryNonAwake(String path, BestiaryNonAwake bestiary)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream str = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(str, bestiary);
            }
        }
    }
}
