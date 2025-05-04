
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NCalc;
namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            pantalla.Text = "0";
        }

        private void condicion(object sender, TextCompositionEventArgs e)
        {
            //esta es la expresion regular para que sea solo numero
            e.Handled = !Regex.IsMatch(e.Text,"^[0-9.]$");
        }

        private void positivosnegativos(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(pantalla.Text,out int numero))
            {
                numero *= -1;
                pantalla.Text= numero.ToString();
            }  
        }

        private void tantoporciento(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(pantalla.Text, out double numero))
            {
                numero = numero/100;
                pantalla.Text = numero.ToString();
            }
         
        }

        private void potenci(object sender, RoutedEventArgs e)

        {
            if (double.TryParse(pantalla.Text, out double numero))
            {
                numero=Math.Pow(numero,2);
                pantalla.Text = numero.ToString();
            }

        }

        private void raiz(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(pantalla.Text, out double numero))
            {
                numero = (double)Math.Sqrt(numero);
                pantalla.Text = numero.ToString();
            }
        }

        private void sietes(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "7"; 
            }
            else
            {
                pantalla.Text += "7";
            }
        }

        private void ochos(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "8";
            }
            else
            {
                pantalla.Text += "8";
            }
        }

        private void nueves(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "9";
            }
            else
            {
                pantalla.Text += "9";
            }
        }

        private void sei(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "6";
            }
            else
            {
                pantalla.Text += "6";
            }
        }

        private void cinc(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "5";
            }
            else
            {
                pantalla.Text += "5";
            }
        }

        private void cuatr(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "4";
            }
            else
            {
                pantalla.Text += "4";
            }
        }

        private void un(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "1";
            }
            else
            {
                pantalla.Text += "1";
            }
        }

        private void doss(object sender, RoutedEventArgs e)
        {
            if (pantalla.Text == "0")
            {
                pantalla.Text = "2";
            }
            else
            {
                pantalla.Text += "2";
            }
        }

        private void tre(object sender, RoutedEventArgs e)
        {
             if (pantalla.Text == "0")
            {
                pantalla.Text = "3"; 
            }
            else
            {
                pantalla.Text += "3";
            }
        }

        private void ceros1(object sender, RoutedEventArgs e)
        {
            pantalla.Text = "0";
        }

        private void ceros2(object sender, RoutedEventArgs e)
        {
            pantalla.Text = "0";
        }

        private void atra(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(pantalla.Text))
            {
                pantalla.Text=pantalla.Text.Substring(0,pantalla.Text.Length-1);
            }
        }

        private void ceros(object sender, RoutedEventArgs e)
        {
            pantalla.Text += "0";
        }

        private void puntos(object sender, RoutedEventArgs e)
        {
            pantalla.Text += ".";
        }

        private void multipli(object sender, RoutedEventArgs e)
        {
            pantalla.Text += "*";
        }

        private void menos(object sender, RoutedEventArgs e)
        {
            pantalla.Text += "-";
        }

        private void mas(object sender, RoutedEventArgs e)
        {
            pantalla.Text += "+";
        }

        private void dividi(object sender, RoutedEventArgs e)
        {
            pantalla.Text += "/";
        }

        private async Task resultadoAsync(object sender, RoutedEventArgs e)
        {
            //la expresion es el texboxt pantalla
            string expresion = pantalla.Text;
            //la en el texbox pantalla reemplaza la coma por el punto
            expresion = expresion.Replace(',', '.');
            if (expresion.Contains("/0"))
            {
                pantalla.Text = "no se puede dividir entre 0";
            }
            else {
                try
                {
                    
                    //se crea el objeto expression que es una cadena de texto con una formula matematica
                    NCalc.Expression expression = new NCalc.Expression(expresion);
                    //se llama al metodo evaluate de expresion que almacena el resultado en la variable resultado
                    object resultado = expression.Evaluate();
                    //y lo muestra
                    pantalla.Text = resultado.ToString();
                }
                catch (Exception)
                {
                    pantalla.Text = "Error";
                }
            }
        }

        private async void resultadoss(object sender, RoutedEventArgs e)
        {
            await resultadoAsync(sender, e);
        }

        private void funciones(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(pantalla.Text, out double numero))
            {
                numero = 1/numero;
                pantalla.Text = numero.ToString();
            }
        }
    }
}
