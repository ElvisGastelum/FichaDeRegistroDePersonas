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
            LoadMaskedTextBox();
            sexoMasculino.Checked = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.DataSource = mainController.GetList();
        }

        private void LoadMaskedTextBox()
        {
            CodigoDeEmpleado.Mask = "0 0 0 0 0 0 0 0 0 0";

            CodigoDeEmpleado.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
            CodigoDeEmpleado.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);

            FechaDeNacimiento.Mask = "00 / 00 / 0000";

            FechaDeNacimiento.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
            FechaDeNacimiento.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);
        }

        void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (CodigoDeEmpleado.MaskFull)
            {
                toolTip1.ToolTipTitle = "Ingreso excesivo";
                toolTip1.Show("No se pueden ingresar mas caracteres", CodigoDeEmpleado, 0, -20, 5000);
            }
            else if (e.Position == CodigoDeEmpleado.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Ingreso excesivo";
                toolTip1.Show("No se pueden agregar mas caracteres al final de la linea", CodigoDeEmpleado, 0, -20, 5000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Ingreso incorrecto";
                toolTip1.Show("Solo puedes agregar numeros (0-9) en esta celda", CodigoDeEmpleado, 0, -20, 5000);
            }
        }

        void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(CodigoDeEmpleado);
        }

        private void LoadTable()
        {
            mainController.SetList(((BindingList<PersonModel>)dataGridView1.DataSource));
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
            LoadTable();
        }

        private string Sexo() { return sexoMasculino.Checked ? "Masculino" : "Femenino"; }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Index < ((BindingList<PersonModel>)dataGridView1.DataSource).Count)
                {
                    ((BindingList<PersonModel>)dataGridView1.DataSource).RemoveAt(dataGridView1.SelectedRows[0].Index);
                    mainController.SetList(((BindingList<PersonModel>)dataGridView1.DataSource));
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
