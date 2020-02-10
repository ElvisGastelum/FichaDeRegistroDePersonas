using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace Model
{
    [Serializable]
    public class Persons
    {
        public BindingList<PersonModel> ListOfPersonModels { get; set; }

        public Persons(BindingList<PersonModel> listOfPersonModels)
        {
            ListOfPersonModels = listOfPersonModels;
        }

        public Persons()
        {
            ListOfPersonModels = new BindingList<PersonModel>();
        }
    }
}
