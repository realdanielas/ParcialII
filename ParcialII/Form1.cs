using System.Diagnostics.Metrics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Windows.Forms;

namespace ParcialII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Random alter = new Random();
        public List<int> myDataFi = new List<int>();
        public List<int> myDataPMi = new List<int>();
        public List<int> myDataPmiXfi = new List<int>();
        public List<int> myDataFreqAc = new List<int>();
        public List<string> myDataEstatura = new List<string>();
        public List<string> orden = new List<string>();

        
        private void button1_Click(object sender, EventArgs e)
        {
            //FOR ORDEN LIST
            orden.Add("1.");
            orden.Add("2.");
            orden.Add("3.");
            orden.Add("4.");
            orden.Add("5.");
            orden.Add("6.");
            orden.Add("7.");

            OrdenTextBox.Text = String.Join(Environment.NewLine, orden);

            //FOR MYDATAESTATURA LIST
            myDataEstatura.Add("150 - 154");
            myDataEstatura.Add("155 - 159");
            myDataEstatura.Add("160 - 164");
            myDataEstatura.Add("165 - 169");
            myDataEstatura.Add("170 - 174");
            myDataEstatura.Add("175 - 179");
            myDataEstatura.Add("180 - 184");

            EstaturaTextBox.Text = String.Join(Environment.NewLine, myDataEstatura);

            //FOR MYDATAPMI LIST
            int data0 = (150 + 154) / 2;
            int data1 = (155 + 159) / 2;
            int data2 = (160 + 164) / 2;
            int data3 = (165 + 169) / 2;
            int data4 = (170 + 174) / 2;
            int data5 = (175 + 179) / 2;
            int data6 = (180 + 184) / 2;

            myDataPMi.Add(data0);
            myDataPMi.Add(data1);
            myDataPMi.Add(data2);
            myDataPMi.Add(data3);
            myDataPMi.Add(data4);
            myDataPMi.Add(data5);
            myDataPMi.Add(data6);

            PMiTextBox.Text = String.Join(Environment.NewLine, myDataPMi);

            //FOR MYDATAFI LIST

            for (int i = 1; i <= 7; i++)
            {
                myDataFi.Add(alter.Next(1, 12));

            }

            foreach (int numero in myDataFi)
            {
                this.FiTextBox.Text += numero.ToString() + "\n\t";

            }

            int SumOfFi = myDataFi.Sum();
            Ntextbox.Text = SumOfFi.ToString(); //SHOWS N SUM

            //FOR FRECUENCIA ACUMULADA
            int FaValue0 = myDataFi.ElementAt(0);
            int FaValue1 = myDataFi.ElementAt(1);
            int FaValue2 = myDataFi.ElementAt(2);
            int FaValue3 = myDataFi.ElementAt(3);
            int FaValue4 = myDataFi.ElementAt(4);
            int FaValue5 = myDataFi.ElementAt(5);
            int FaValue6 = myDataFi.ElementAt(6);

            myDataFreqAc.Add(FaValue0); //1
            myDataFreqAc.Add(FaValue0 + FaValue1); //2
            myDataFreqAc.Add(FaValue0 + FaValue1 + FaValue2); //3
            myDataFreqAc.Add(FaValue0 + FaValue1 + FaValue2 + FaValue3); //4
            myDataFreqAc.Add(FaValue0 + FaValue1 + FaValue2 + FaValue3 + FaValue4); //5
            myDataFreqAc.Add(FaValue0 + FaValue1 + FaValue2 + FaValue3 + FaValue4 + FaValue5); //6
            myDataFreqAc.Add(FaValue0 + FaValue1 + FaValue2 + FaValue3 + FaValue4 + FaValue5 + FaValue6); //7

            FaTextBox.Text = String.Join(Environment.NewLine, myDataFreqAc);
            
            double intervaloMediana;
            intervaloMediana = double.Parse(Ntextbox.Text) / 2;
            IntervaloMedianaTextBox.Text = intervaloMediana.ToString();

            //FOR PMi X Fi 

            for (int i = 0; i < Math.Min(myDataPMi.Count, myDataFi.Count); i++)
            {
                myDataPmiXfi.Add(myDataPMi[i] * myDataFi[i]);
            }

            PMiXFiTextBox.Text = String.Join(Environment.NewLine, myDataPmiXfi);

            int SumOfPmiXfi = myDataPmiXfi.Sum();

            SumaPMiXFiTextBox.Text = SumOfPmiXfi.ToString();

            //MAX NUM IN FI

            int NumeroMayor = myDataFi.Max();
            this.NumeroMayorTextBox.Text = NumeroMayor.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //VALIDACIONES-----------------------------------------------------------------------------------
            if (string.IsNullOrEmpty(LiMedianaTextBox.Text) && string.IsNullOrEmpty(LiModaTextBox.Text))
            {
                MessageBox.Show("Debe completar los campos.", "FALTA DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                return;

            }
            /*else if (LiMedianaTextBox.Text == "0" && LiMedianaTextBox.Text == "-" && LiModaTextBox.Text == "0" && LiModaTextBox.Text == "-")
            {
                MessageBox.Show("Ingresar números enteros según el número de la fila correspondiente.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LiModaTextBox.Text = "";
                LiMedianaTextBox.Text = "";
                Mediatbox.Text = "";
                return;
            }
            else
            {
                MessageBox.Show("Ingresar números enteros según el número de la fila correspondiente.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LiModaTextBox.Text = "";
                LiMedianaTextBox.Text = "";
                return;
            }*/


            //MEDIA------------------------------------------------------------------------------------------

            if (double.TryParse(SumaPMiXFiTextBox.Text, out double PMixFi) && int.TryParse(Ntextbox.Text, out int nfinal))
            {
                var mediafinal = PMixFi / nfinal;

                Double mediafinalfinal = Math.Round((Double)mediafinal, 0);
                this.Mediatbox.Text = mediafinalfinal.ToString();
            }

            //MEDIANA --------------------------------------------------------------------------------------
            double intervaloMediana; // n/2
                intervaloMediana = double.Parse(Ntextbox.Text) / 2;
            int LiMediana;
            int A = 4;
            
            if (LiMedianaTextBox.Text == "2")
            {
                LiMediana = 155; //Límite inferior
                int FiValue1 = myDataFi.ElementAt(1); //Frecuencia
                int FaValue0 = myDataFreqAc.ElementAt(0); //Frecuencia Acumulada

                var resta = intervaloMediana - FaValue0;
                var division = resta / FiValue1;
                var mult = division * A;
                var MedianaFinal = mult + LiMediana;

                Double medianafinalredo = Math.Round((Double)MedianaFinal, 0);
                Medianatbox.Text = medianafinalredo.ToString();
            } 
            else if (LiMedianaTextBox.Text == "3")
            {
                LiMediana = 160; //Límite inferior
                int FiValue1 = myDataFi.ElementAt(2); //Frecuencia
                int FaValue0 = myDataFreqAc.ElementAt(1); //Frecuencia Acumulada

                var resta = intervaloMediana - FaValue0;
                var division = resta / FiValue1;
                var mult = division * A;
                var MedianaFinal = mult + LiMediana;

                Double medianafinalredo = Math.Round((Double)MedianaFinal, 0);
                Medianatbox.Text = medianafinalredo.ToString();

            }
            else if (LiMedianaTextBox.Text == "4")
            {
                LiMediana = 165; //Límite inferior
                int FiValue1 = myDataFi.ElementAt(3); //Frecuencia
                int FaValue0 = myDataFreqAc.ElementAt(2); //Frecuencia Acumulada

                var resta = intervaloMediana - FaValue0;
                var division = resta / FiValue1;
                var mult = division * A;
                var MedianaFinal = mult + LiMediana;

                Double medianafinalredo = Math.Round((Double)MedianaFinal, 0);
                Medianatbox.Text = medianafinalredo.ToString();

            }
            else if (LiMedianaTextBox.Text == "5")
            {
                LiMediana = 165; //Límite inferior
                int FiValue1 = myDataFi.ElementAt(4); //Frecuencia
                int FaValue0 = myDataFreqAc.ElementAt(3); //Frecuencia Acumulada

                var resta = intervaloMediana - FaValue0;
                var division = resta / FiValue1;
                var mult = division * A;
                var MedianaFinal = mult + LiMediana;

                Double medianafinalredo = Math.Round((Double)MedianaFinal, 0);
                Medianatbox.Text = medianafinalredo.ToString();

            }
            else if (LiMedianaTextBox.Text == "6")
            {
                LiMediana = 165; //Límite inferior
                int FiValue1 = myDataFi.ElementAt(5); //Frecuencia
                int FaValue0 = myDataFreqAc.ElementAt(4); //Frecuencia Acumulada

                var resta = intervaloMediana - FaValue0;
                var division = resta / FiValue1;
                var mult = division * A;
                var MedianaFinal = mult + LiMediana;

                Double medianafinalredo = Math.Round((Double)MedianaFinal, 0);
                Medianatbox.Text = medianafinalredo.ToString();

            }
            else if (LiMedianaTextBox.Text == "7")
            {
                LiMediana = 165; //Límite inferior
                int FiValue1 = myDataFi.ElementAt(6); //Frecuencia
                int FaValue0 = myDataFreqAc.ElementAt(5); //Frecuencia Acumulada

                var resta = intervaloMediana - FaValue0;
                var division = resta / FiValue1;
                var mult = division * A;
                var MedianaFinal = mult + LiMediana;

                Double medianafinalredo = Math.Round((Double)MedianaFinal, 0);
                Medianatbox.Text = medianafinalredo.ToString();

            }
            else
            {
                MessageBox.Show("Seleccionar el número según la lista de orden para Li.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Mediatbox.Text = "";
                LiMedianaTextBox.Text = "";
                LiModaTextBox.Text = "";
                return;
            }

            //MODA-------------------------------------------------------------------------------------------
            int NumeroMayor = myDataFi.Max(); //Fi
            int LiModa;
            

            if (LiModaTextBox.Text == "1")
            {
                LiModa = 150; //Li
                int FiMas1 = myDataFi.ElementAt(1);

                var restaNumerador = NumeroMayor - 0;
                var restaDeno1 = NumeroMayor - 0;
                var restaDeno2 = NumeroMayor - FiMas1;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();

            }
            else if (LiModaTextBox.Text == "2")
            {
                LiModa = 155; //Li
                int FiMenos1 = myDataFi.ElementAt(0);
                int FiMas1 = myDataFi.ElementAt(2);

                var restaNumerador = NumeroMayor - FiMenos1;
                var restaDeno1 = NumeroMayor - FiMenos1;
                var restaDeno2 = NumeroMayor - FiMas1;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();
            }
            else if (LiModaTextBox.Text == "3")
            {
                LiModa = 160; //Li
                int FiMenos1 = myDataFi.ElementAt(1);
                int FiMas1 = myDataFi.ElementAt(3);

                var restaNumerador = NumeroMayor - FiMenos1;
                var restaDeno1 = NumeroMayor - FiMenos1;
                var restaDeno2 = NumeroMayor - FiMas1;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();
            }
            else if (LiModaTextBox.Text == "4")
            {
                LiModa = 165; //Li
                int FiMenos1 = myDataFi.ElementAt(2);
                int FiMas1 = myDataFi.ElementAt(4);

                var restaNumerador = NumeroMayor - FiMenos1;
                var restaDeno1 = NumeroMayor - FiMenos1;
                var restaDeno2 = NumeroMayor - FiMas1;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();
            }
            else if (LiModaTextBox.Text == "5")
            {
                LiModa = 170; //Li
                int FiMenos1 = myDataFi.ElementAt(3);
                int FiMas1 = myDataFi.ElementAt(5);

                var restaNumerador = NumeroMayor - FiMenos1;
                var restaDeno1 = NumeroMayor - FiMenos1;
                var restaDeno2 = NumeroMayor - FiMas1;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();
            }
            else if (LiModaTextBox.Text == "6")
            {
                LiModa = 175; //Li
                int FiMenos1 = myDataFi.ElementAt(4);
                int FiMas1 = myDataFi.ElementAt(6);

                var restaNumerador = NumeroMayor - FiMenos1;
                var restaDeno1 = NumeroMayor - FiMenos1;
                var restaDeno2 = NumeroMayor - FiMas1;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();
            }
            else if (LiModaTextBox.Text == "7")
            {
                LiModa = 175; //Li
                int FiMenos1 = myDataFi.ElementAt(5);
                

                var restaNumerador = NumeroMayor - FiMenos1;
                var restaDeno1 = NumeroMayor - FiMenos1;
                var restaDeno2 = NumeroMayor - 0;

                var fraccion = restaNumerador / (restaDeno1 + restaDeno2);
                var multModa = fraccion * A;
                var Moda = LiModa + multModa;

                Double modaFinal = Math.Round((Double)Moda, 0);
                Modatbox.Text = modaFinal.ToString();
            }
            else
            {
                MessageBox.Show("Seleccionar el número según la lista de orden para Li.", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Mediatbox.Text = "";
                LiMedianaTextBox.Text = "";
                LiModaTextBox.Text = "";
                return;
            }

        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            myDataFi.Clear();
            myDataPMi.Clear();
            myDataEstatura.Clear();
            myDataPmiXfi.Clear();
            myDataFreqAc.Clear();
            orden.Clear();

            Mediatbox.Clear();
            Medianatbox.Clear();
            Modatbox.Clear();
            PMiTextBox.Clear();
            FiTextBox.Clear();
            Ntextbox.Clear();
            EstaturaTextBox.Clear();
            FaTextBox.Clear();
            PMiXFiTextBox.Clear();
            SumaPMiXFiTextBox.Clear();
            OrdenTextBox.Clear();
            IntervaloMedianaTextBox.Clear();
            LiMedianaTextBox.Clear();
            LiModaTextBox.Clear();
            NumeroMayorTextBox.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}