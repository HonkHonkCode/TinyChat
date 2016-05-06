using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyChat.src.Models;
using System.Xml.Serialization;
using System.IO;

namespace TinyChat.settings
{
    public class ApplicationSettings
    {
        protected string saveLocation = "";
        public List<Account> SavedAccounts = new List<Account>();


        public void save()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());

            StreamWriter writer = new StreamWriter("settings.xml");
            serializer.Serialize(writer, this);

            writer.Close();
        }

        public static ApplicationSettings load()
        {
            ApplicationSettings copySettings = new ApplicationSettings();
            if (File.Exists("settings.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
                StreamReader reader = new StreamReader("settings.xml");

                copySettings = (ApplicationSettings)serializer.Deserialize(reader);
                reader.Close();
                
            }

            return copySettings;
        }
    }
}
