using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class CrudContrato : Form
    {
        public CrudContrato()
        {
            InitializeComponent();
        }


        CN_Contratos objetoCN = new CN_Contratos();
        private string idContrato = null;
        private bool Editar = false;
        String fechaIncorporacion;
        String fechaMeta;
        String fechaFinal;



        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar.ValidaTextBoxVacios(this))
            {
                //INSERTAR
                if (Editar == false)
                {
                    if (Validar.ValidaComboBox(this))
                    {
                        try
                        {

                            fechaIncorporacion = dateTimePicker1.Value.ToShortDateString();
                            fechaFinal = dateTimePicker2.Value.ToShortDateString();
                            fechaMeta = dateTimePicker3.Value.ToShortDateString();
                            objetoCN.InsertarContrato(fechaIncorporacion, fechaMeta, montoMeta.Text, fechaFinal, montoActual.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                            MessageBox.Show("se inserto correctamente");
                            MostrarContratos();
                            //limpiarForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("no se pudo insertar los datos por: " + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Favor seleccionar item de la lista");
                    }
                }
                //EDITAR
                if (Editar == true)
                {

                    try
                    {
                        fechaIncorporacion = dateTimePicker1.Value.ToShortDateString();
                        fechaFinal = dateTimePicker2.Value.ToShortDateString();
                        fechaMeta = dateTimePicker3.Value.ToShortDateString();
                        objetoCN.EditarContrato(idContrato,fechaIncorporacion, fechaMeta, montoMeta.Text, fechaFinal, montoActual.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        MessageBox.Show("se edito correctamente");
                        MostrarContratos();
                        //limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo editar los datos por: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor llenar todos los campos");
            }
        }

        private void MostrarContratos()
        {

            CN_Contratos objeto = new CN_Contratos();
            dataGridView1.DataSource = objeto.MostrarContratos();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            //fechaIncorporacion = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            //fechaMeta = dateTimePicker2.Value;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
           
            //fechaFinal = dateTimePicker3.Value;
            
        }

        

        private void CargarCombo()
        {

            CN_Usuarios objeto1 = new CN_Usuarios();

            comboBox2.DataSource = objeto1.MostrarUser();
            comboBox2.DisplayMember = "nombre_usuario";
            comboBox2.ValueMember = "id_usuario";
            comboBox2.Text = "Seleccione";

            CN_Colegios objeto2 = new CN_Colegios();

            comboBox1.DataSource = objeto2.MostrarColegio();
            comboBox1.DisplayMember = "razon_social_colegio";
            comboBox1.ValueMember = "id_colegio";
            comboBox1.Text = "Seleccione";

            CN_EstadoContrato objeto3 = new CN_EstadoContrato();

            comboBox3.DataSource = objeto3.MostrarEstadoContrato();
            comboBox3.DisplayMember = "descripcion";
            comboBox3.ValueMember = "id_contrato";
            comboBox3.Text = "Seleccione";


        }

        private void CrudContrato_Load(object sender, EventArgs e)
        {
            CargarCombo();
            MostrarContratos();
           dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd-MM-yyyy";

        }

        private void montoMeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void montoActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                montoMeta.Text = dataGridView1.CurrentRow.Cells["MONTO_META"].Value.ToString();
                montoActual.Text = dataGridView1.CurrentRow.Cells["MONTO_ACTUAL_CONTRATO"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["FECHA_INCORPORACION"].Value.ToString();
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["FECHA_META"].Value.ToString();
                dateTimePicker3.Text = dataGridView1.CurrentRow.Cells["FECHA_FINAL"].Value.ToString();
                //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FECHA_INCORPORACION"].Value);
                //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[2].Value);
                //dateTimePicker2.Text = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value.ToString);
                //dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value);
                //txtCorreoEnc.Text = dataGridView1.CurrentRow.Cells["email_encargado_colegio"].Value.ToString();
                // idColegio = dataGridView1.CurrentRow.Cells["id_colegio"].Value.ToString();
                idContrato = dataGridView1.CurrentRow.Cells["ID_CONTRATO"].Value.ToString();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
