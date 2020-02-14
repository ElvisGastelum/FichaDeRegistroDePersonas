using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

namespace Controller
{
    public class MainController
    {
        private Persons persons;
        private readonly string path = Path.GetFullPath("./") + "PersonsData.txt";
        private MaskedTextBox maskedTextBox1, maskedTextBox2;
        private ToolTip toolTip1;

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

        public void LoadMaskedTextBox(MaskedTextBox tb1, MaskedTextBox tb2, ToolTip tp1)
        {
            maskedTextBox1 = tb1;
            maskedTextBox2 = tb2;
            toolTip1 = tp1;
            maskedTextBox1.Mask = "0 0 0 0 0 0 0 0 0 0";

            maskedTextBox1.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
            maskedTextBox1.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);

            maskedTextBox2.Mask = "00 / 00 / 0000";

            maskedTextBox2.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
            maskedTextBox2.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);
        }
        void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (((MaskedTextBox)sender).Equals(maskedTextBox1))
            {
                ToolTipBridge(maskedTextBox1, e);
            }
            else
            {
                ToolTipBridge(maskedTextBox2, e);
            }
            
        }

        private void ToolTipBridge(MaskedTextBox maskedTextBox1, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                toolTip1.ToolTipTitle = "Ingreso excesivo";
                toolTip1.Show("No se pueden ingresar mas caracteres", maskedTextBox1, 0, -20, 5000);
            }
            else if (e.Position == maskedTextBox1.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Ingreso excesivo";
                toolTip1.Show("No se pueden agregar mas caracteres al final de la linea", maskedTextBox1, 0, -20, 5000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Ingreso incorrecto";
                toolTip1.Show("Solo puedes agregar numeros (0-9) en esta celda", maskedTextBox1, 0, -20, 5000);
            }
        }

        void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((MaskedTextBox)sender).Equals(maskedTextBox1))
            {
                toolTip1.Hide(maskedTextBox1);
            }
            else
            {
                toolTip1.Hide(maskedTextBox2);
            }
        }

    }
}
