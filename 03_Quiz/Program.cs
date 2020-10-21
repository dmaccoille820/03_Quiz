using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Quiz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Login());
        }

        public static void SaveObject(PlayerCollection thisObject)
        {

            //Saving an object
            Stream sw;
            BinaryFormatter bf = new BinaryFormatter();
            sw = File.Open("mydata.bin", FileMode.Create);
            bf.Serialize(sw, thisObject);
            sw.Close();
        }
        public static void LoadObject(ref PlayerCollection thisObject)
        {
            //loading an object
            Stream sr;
            BinaryFormatter bf = new BinaryFormatter();
            sr = File.OpenRead("mydata.bin");
            thisObject = (PlayerCollection)bf.Deserialize(sr);
            sr.Close();
        }
    }
}
