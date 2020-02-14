using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace FichaDeRegistro
{
    public partial class Main : Form
    {
        Controller.MainController mainController = new Controller.MainController();
        public Main()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            mainController.LoadMaskedTextBox(CodigoDeEmpleado, FechaDeNacimiento, toolTip1);
            sexoMasculino.Checked = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.DataSource = mainController.GetList();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            mainController.Save(
                new PersonModel(
                        Nombre.Text, ApellidoPaterno.Text, 
                        ApellidoMaterno.Text, FechaDeNacimiento.Text,
                        Cuidad.Text, EstadoDeNacimiento.Text,
                        Pais.Text, Nacionalidad.Text,
                        FormaMigratoria.Text, Sexo(),
                        TipoDeSangre.Text, Calle.Text,
                        NumeroExterior.Text, NumeroInterior.Text,
                        Colonia.Text, CodigoPostal.Text,
                        Municipio.Text, EstadoDeResidencia.Text,
                        TelefonoCelular.Text, TelefonoOficina.Text,
                        CorreoElectronico.Text, CodigoDeEmpleado.Text,
                        Curp.Text, NumeroDeSeguridadSocial.Text,
                        NumeroDeAfore.Text, InstitucionDeLaAfore.Text,
                        RFC.Text
                    )
                );
        }

        private string Sexo() { return sexoMasculino.Checked ? "Masculino" : "Femenino"; }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var List = (BindingList<PersonModel>)dataGridView1.DataSource;
                var SelectedRow = dataGridView1.SelectedRows[0].Index;

                if (SelectedRow < List.Count)
                {
                    List.RemoveAt(SelectedRow);
                    mainController.SetList(List);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mainController.GetList();
        }
    }
}
