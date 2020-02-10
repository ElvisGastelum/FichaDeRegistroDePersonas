using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Model;

namespace Controller
{
    public class MainController
    {
        private Persons persons;
        private readonly string path = Path.GetFullPath("./") + "PersonsData.txt";

        public MainController()
        {
            persons = new Persons();
        }

        public void SetList(BindingList<PersonModel> listOfPersonModels)
        {
            persons.ListOfPersonModels = listOfPersonModels;
            Save(persons, path);
        }
        public BindingList<PersonModel> GetList()
        {
            Persons readed = Read(path);
            if (readed != null)
            {
                persons = readed;
            }
            
            return persons.ListOfPersonModels;
        }

        public void Save(PersonModel person)
        {
            persons.ListOfPersonModels.Add(person);
            Save(persons, path);
        }
        private void Save(Persons person, string path)
        {
            try
            {
                XmlSerializer xmlDoc = new XmlSerializer(typeof(Persons));
                StreamWriter sw = new StreamWriter(path, false);
                xmlDoc.Serialize(sw, person);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private Persons Read(string path)
        {
            Persons result = new Persons();
            try
            {
                XmlSerializer xmlDoc = new XmlSerializer(typeof(Persons));
                StreamReader sw = new StreamReader(path);
                result = (Persons)xmlDoc.Deserialize(sw);
                sw.Close();
                if (result != null)
                {
                    persons = result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return persons;
        }

    }
}
