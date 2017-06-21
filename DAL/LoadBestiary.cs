using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    /// <summary>
    /// This class is used to load both bestiaries, and it's a singelton
    /// </summary>
    public sealed class LoadBestiary
    {
        private static LoadBestiary lb = new LoadBestiary();
        private LoadBestiary()
        {
            BestiaryAwake.Instance = LoadBestiaryAwake("bestiaryAwake.bin");
            BestiaryNonAwake.Instance = LoadBestiaryNonAwake("bestiaryNawake.bin");
        }

        public static LoadBestiary Instance
        {
            get
            {
                return lb;
            }
        }

        /// <summary>
        /// This method load the BestiaryAwake
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bestiary"></param>
        /// <returns>the bestiary awake</returns>
        public BestiaryAwake LoadBestiaryAwake(String path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream flux = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.Open, FileAccess.Read))
                {
                    BestiaryAwake ba = (BestiaryAwake)formatter.Deserialize(flux);
                    foreach (MonsterAwake monster in ba.ListBestiary)
                    {
                        monster.ImagePath = Path.GetFullPath(Path.Combine("photos/", monster.Name + ".png"));
                    }
                    return ba;
                }
            }
            catch
            {
                return BestiaryAwake.Instance;
            }
        }

        /// <summary>
        /// This method load the BestiaryNonAwake
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The BestiaryNonAwake</returns>
        public BestiaryNonAwake LoadBestiaryNonAwake(String path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream flux = new FileStream(Path.GetFullPath(Path.Combine("Save/", path)), FileMode.Open, FileAccess.Read))
                {
                    BestiaryNonAwake bn = (BestiaryNonAwake)formatter.Deserialize(flux);
                    foreach (MonsterNonAwake monster in bn.ListBestiary)
                    {
                        monster.ImagePath = Path.GetFullPath(Path.Combine("photos/", monster.MonsterN + monster.Attribute + ".png"));
                    }
                    return bn;
                }
            }
            catch
            {
                return BestiaryNonAwake.Instance;
            }
        }
    }
}
