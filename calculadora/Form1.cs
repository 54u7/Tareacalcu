using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{

    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Modulo = 5
    }
    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        Operacion operador = Operacion.NoDefinida;
        bool NumeroLeido = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void LeerNum(string num)
        {
            NumeroLeido = true;
            if (cajaResultado.Text == "0" && cajaResultado.Text != null)
            {
                cajaResultado.Text = num;
            }
            else
            {
                cajaResultado.Text += num;
            }
        }

        private double EjecutarOperacion()
        {
            double resultado = 0;
            switch (operador)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Division:
                    {
                        if (valor2 == 0)
                        {
                            //MessageBox.Show("No se puede dividir entre 0");
                            lblHistorial.Text = "No se puede dividir entre 0";
                            resultado = 0;                        
                        }
                        else
                        {
                            resultado = valor1 / valor2;
                        }
                    }
                    
                    
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Modulo:
                    resultado = valor1 % valor2;
                    break;
            }
            return resultado;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            NumeroLeido = true;
            if (cajaResultado.Text == "0")
            {
                return;
            }
            else
            {
                cajaResultado.Text += 0;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            LeerNum("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            LeerNum("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            LeerNum("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            LeerNum("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            LeerNum("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            LeerNum("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            LeerNum("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            LeerNum("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            LeerNum("9");
        }

        private void ObtenerValor(string operador)
        {
            valor1 = Convert.ToDouble(cajaResultado.Text);
            lblHistorial.Text = cajaResultado.Text + operador;
            cajaResultado.Text = "0";
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            ObtenerValor("+");
            
        }
        private void btnRestar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            ObtenerValor("-");
        }
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            ObtenerValor("x");
        }


        private void btnDividir_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            ObtenerValor("/");
        }
        private void btnModulo_Click(object sender, EventArgs e)
        {
            operador = Operacion.Modulo;
            ObtenerValor("%");
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            if (valor2 == 0 && NumeroLeido)
            {
                valor2 = Convert.ToDouble(cajaResultado.Text);
                lblHistorial.Text += valor2 + " = ";
                double resultado = EjecutarOperacion();
                valor1 = 0;
                valor2 = 0;
                NumeroLeido = false;
                cajaResultado.Text = Convert.ToString(resultado);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cajaResultado.Text = "0";
            lblHistorial.Text = "";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (cajaResultado.Text.Length > 1)
            {
                string txtResultado = cajaResultado.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if (txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    cajaResultado.Text = "0";
                }
                else
                {
                    cajaResultado.Text = txtResultado;
                }

                
            }
            else
            {
                cajaResultado.Text = "0";
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (cajaResultado.Text.Contains("."))
            {
                return;
            }
            else
            {
                cajaResultado.Text += ".";
            }
        }
    }
}
