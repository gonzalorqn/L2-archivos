using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Clase15
{
    public partial class FrmPrincipal : Form
    {
        string rutaArchivo = "";
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "miArchivo.txt";
            string path = "";
            if(this.rutaArchivo != "")
            {
                path = this.rutaArchivo;
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "miArchivo.txt";
            }            
            string texto = this.txtValor.Text;
            try
            {
                StreamWriter sw = new StreamWriter(path, true); //string path, true = agrega info al archivo o false = sobrescribe el archivo
                sw.WriteLine(texto);
                sw.Close();
                MessageBox.Show("Archivo creado/sobrescrito correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo no se pudo crear/sobrescribir: " + ex.Message);
            }
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "miArchivo.txt";
            string texto = "";
            try
            {
                StreamReader sr = new StreamReader(path);
                //texto += sr.ReadToEnd();
                //MessageBox.Show(texto);
                while(!sr.EndOfStream) //while( (texto = sr.ReadLine()) != null)
                {
                    texto = sr.ReadLine();
                    this.lstVisor.Items.Add(texto);
                    //MessageBox.Show(texto);
                }
                sr.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(this.openFileDialog1.FileName);
                this.rutaArchivo = this.openFileDialog1.FileName;
                this.btnEnviar_Click(sender, e);
            }
            else
            {
                this.rutaArchivo = "";
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.openFileDialog1.Title = "Seleccione un archivo";
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.DefaultExt = ".txt";
            this.openFileDialog1.AddExtension = true;
            this.openFileDialog1.Filter = "Archivos (*.txt)|*.txt";
        }
    }
}
