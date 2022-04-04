using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        enum Operations
        {
            NONE,
            SUM,
            SUBST,
            MULT,
            DIV,
            X_SQR_Y,
            SIN,
            COS,
            SQR,
            DIV_X,
            SQRT,
            EQUAL
        }

        int n = 0;
        double a;
        double b;
        double c;
        bool flag = false;
        Operations operation;
        Operations operation_memory;

        private void Equals()
        {
            switch (operation)
            {
                case Operations.SUM:
                    tb2.Text = a.ToString() + "+" + b.ToString() + "=";
                    a = a + b;
                    break;
                case Operations.SUBST:
                    tb2.Text = a.ToString() + "-" + b.ToString() + "=";
                    a = a - b;
                    break;
                case Operations.MULT:
                    tb2.Text = a.ToString() + "*" + b.ToString() + "=";
                    a = a * b;
                    break;
                case Operations.DIV:
                    tb2.Text = a.ToString() + "/" + b.ToString() + "=";
                    a = a / b;
                    break;
                case Operations.X_SQR_Y:
                    tb2.Text = a.ToString() + "^" + b.ToString() + "=";
                    a = Math.Pow(a, b);
                    break;
                case Operations.DIV_X:
                    tb2.Text = "1/" + a.ToString() + "=";
                    a = 1 / a;
                    break;
                case Operations.SQR:
                    tb2.Text =  a.ToString() + "^2" + "=";
                    a = a * a;
                    break;
                case Operations.SIN:
                    tb2.Text = "sin(" + a.ToString() + ") =";
                    a = Math.Sin(a);
                    break;
                case Operations.COS:
                    tb2.Text = "cos(" + a.ToString() + ") =";
                    a = Math.Sin(a);
                    break;
                case Operations.SQRT:
                    tb2.Text = "sqrt(" + a.ToString() + ") =";
                    a = Math.Sqrt(a);
                    break;

            }
            c = b;
            b = 0;
            tb.Text = a.ToString();
            operation_memory = operation;
            operation = Operations.EQUAL;
        }
        private void Click_zero()
        {
            if (operation == Operations.NONE && !flag)
            {
                a = a * 10;
                tb.Text = a.ToString();

            }
            else if (flag)
            {
                n++;
                tb.Text += "0";
            }

            else
            {
                b = b * 10;
                tb.Text = b.ToString();
            }
        }
        private void Click_One(int x)
        {
            if (operation == Operations.NONE && !flag)
            {
                if (a >= 0)
                    a = a * 10 + x;
                else
                    a = a * 10 - x;

                tb.Text = a.ToString();
            }
            else if ((operation == Operations.NONE || operation == Operations.EQUAL) && flag)
            {
                n++;
                if (a >= 0)
                    a = a + x / Math.Pow(10, n);
                else
                    a = a - x / Math.Pow(10, n);
                tb.Text = a.ToString();

            }
            else if (operation == Operations.EQUAL)
            {
                a = 0;
                if (a >= 0)
                    a = a * 10 + x;
                else
                    a = a * 10 - x;
                tb.Text = a.ToString();
                operation = Operations.NONE;
            }
            else if (operation != Operations.NONE && flag)
            {
                n++;
                if (b >= 0)
                    b = b + x / Math.Pow(10, n);
                else
                    b = b - x / Math.Pow(10, n);
                tb.Text = b.ToString();

            }
            else
            {
                if (b >= 0)
                    b = b * 10 + x;
                else
                    b = b * 10 - x;
                tb.Text = b.ToString();
            }
        }
        private void Button_0(object sender, RoutedEventArgs e)
        {
            Click_zero();
        }

        private void Button_1(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(((Button)sender).Content.ToString());
            Click_One(x);
        }

        private void Button_equals(object sender, RoutedEventArgs e)
        {
            if (operation == Operations.EQUAL)
            {
                b = c;
                operation = operation_memory;
            }

            Equals();
            flag = false;
            n = 0;
        }

        private void Button_minus(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();
 
            tb.Text = "0";
            tb2.Text = a.ToString() + "-";
            operation = Operations.SUBST;

            flag = false;
            n = 0;
        }

        private void Button_plus(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();
          
            tb.Text = "0";
            tb2.Text = a.ToString() + "+";
            operation = Operations.SUM;

            flag = false;
            n = 0;
        }
        
        private void Button_divide(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb.Text = "0";
            tb2.Text = a.ToString() + "/";
            operation = Operations.DIV;

            flag = false;
            n = 0;
        }

        private void Button_multiply(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb.Text = "0";
            tb2.Text = a.ToString() + "*";
            operation = Operations.MULT;

            flag = false;
            n = 0;
        }

        private void Button_1x(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb2.Text = "1/" + a.ToString();
            tb.Text = "0";
            operation = Operations.DIV_X;

            flag = false;
            n = 0;
        }

        private void Button_x2(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb2.Text = a.ToString() + "^2";
            tb.Text = "0";
            operation = Operations.SQR;

            flag = false;
            n = 0;
        }

        private void Button_xy(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb2.Text = a.ToString() + "^";
            tb.Text = "0";
            operation = Operations.X_SQR_Y;

            flag = false;
            n = 0;
        }

        private void Button_comma(object sender, RoutedEventArgs e)
        {
            flag = true;
            tb.Text += ",";
        }

        private void Button_change_sign(object sender, RoutedEventArgs e)
        {
            if (operation == Operations.EQUAL || operation == Operations.NONE)
            {
                a = a * (-1);
                tb.Text = a.ToString();
            }
            else
            {
                b = b * (-1);
                tb.Text = b.ToString();
            }
           
        }

        private void Button_sin(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb2.Text = "sin(" + a.ToString() + ")";
            tb.Text = "0";
            operation = Operations.SIN;

            flag = false;
            n = 0;
        }

        private void Button_cos(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb2.Text = "cos(" + a.ToString() + ")";
            tb.Text = "0";
            operation = Operations.COS;

            flag = false;
            n = 0;
        }

        private void Button_sqrt(object sender, RoutedEventArgs e)
        {
            if (operation != Operations.EQUAL || operation != Operations.NONE)
                Equals();

            tb2.Text = "sqrt(" + a.ToString() + ")";
            tb.Text = "0";
            operation = Operations.SQRT;

            flag = false;
            n = 0;
        }

        private void Button_C(object sender, RoutedEventArgs e)
        {
            a = 0;
            b = 0;
            tb.Text = "0";
            tb2.Text = "";
            operation = Operations.NONE;
            flag = false;
            n = 0;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter converter = new KeyConverter();
            string key = converter.ConvertToString(e.Key);

            if (Int32.TryParse(key, out int x))
            {
                if (x == 0)
                    Click_zero();
                else
                    Click_One(x);
            }
            else
            {
                
                switch (e.Key)
                {
                    case Key.Add :

                        if (operation != Operations.EQUAL || operation != Operations.NONE)
                            Equals();

                        tb.Text = "0";
                        tb2.Text = a.ToString() + "+";
                        operation = Operations.SUM;

                        flag = false;
                        n = 0;
                        break;
                    case Key.Divide:

                        if (operation != Operations.EQUAL || operation != Operations.NONE)
                            Equals();

                        tb.Text = "0";
                        tb2.Text = a.ToString() + "/";
                        operation = Operations.DIV;

                        flag = false;
                        n = 0;
                        break;
                    case Key.Multiply:

                        if (operation != Operations.EQUAL || operation != Operations.NONE)
                            Equals();

                        tb.Text = "0";
                        tb2.Text = a.ToString() + "*";
                        operation = Operations.MULT;

                        flag = false;
                        n = 0;
                        break;
                    case Key.Subtract:
                        if (operation != Operations.EQUAL || operation != Operations.NONE)
                            Equals();

                        tb.Text = "0";
                        tb2.Text = a.ToString() + "-";
                        operation = Operations.SUBST;

                        flag = false;
                        n = 0;
                        break;
                    case Key.OemPlus:

                        if (operation == Operations.EQUAL)
                        {
                            b = c;
                            operation = operation_memory;
                        }

                        Equals();
                        flag = false;
                        n = 0;
                        break;
                    case Key.OemComma:
                        flag = true;
                        tb.Text += ",";
                        break;

                }
            }
        }
    }
}
