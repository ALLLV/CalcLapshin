using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcLapshin
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

        bool move = false;
        char op;
        double firstV = 0;
        double secondV = 0;

        public static class IconHelper
        {
            [DllImport("user32.dll")]
            static extern int GetWindowLong(IntPtr hwnd, int index);

            [DllImport("user32.dll")]
            static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

            [DllImport("user32.dll")]
            static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                       int x, int y, int width, int height, uint flags);

            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hwnd, uint msg,
                       IntPtr wParam, IntPtr lParam);

            const int GWL_EXSTYLE = -20;
            const int WS_EX_DLGMODALFRAME = 0x0001;
            const int SWP_NOSIZE = 0x0001;
            const int SWP_NOMOVE = 0x0002;
            const int SWP_NOZORDER = 0x0004;
            const int SWP_FRAMECHANGED = 0x0020;
            const uint WM_SETICON = 0x0080;

            public static void RemoveIcon(Window window)
            {
                // Get this window's handle
                IntPtr hwnd = new WindowInteropHelper(window).Handle;

                // Change the extended window style to not show a window icon
                int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_DLGMODALFRAME);

                // Update the window's non-client area to reflect the changes
                SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE |
                      SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            }

        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }
        private void beginningZeroCheck()
        {
            if(tbMain.Text == "0") tbMain.Text = "";
            if (move) tbMain.Text = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbMain.Text = "0";
            secondV = 0;
            firstV = 0;
            move = false;
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "1";
            move = false;
        }
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "0";
            move = false;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "2";
            move = false;
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "3";
            move = false;
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "4";
            move = false;
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "5";
            move = false;
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "6";
            move = false;
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "7";
            move = false;
        }
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "8";
            move = false;
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            tbMain.Text += "9";
            move = false;
        }
        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            tbMain.Text = tbMain.Text.Remove(tbMain.Text.Length - 1);
            if (tbMain.Text == "") tbMain.Text = "0";
        }
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            beginningZeroCheck();
            if (!tbMain.Text.Contains(",")) tbMain.Text += ",";
        }
        private void btnSwitchOp_Click(object sender, RoutedEventArgs e)
        {
            double v = Double.Parse(tbMain.Text);
            
            if (v != 0)
            {
                v = v * -1;
                tbMain.Text = v.ToString();
            }
            else
            {
                tbMain.Text = "-";
            }
        }
        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            double result;
            secondV = Double.Parse(tbMain.Text);

            switch (op)
            {
                case '+':
                    result = firstV + secondV;
                    tbMain.Text = result.ToString();
                    break;
                case '-':
                    result = firstV - secondV;
                    tbMain.Text = result.ToString();
                    break;
                case '*':
                    result = firstV * secondV;
                    tbMain.Text = result.ToString();
                    break;
                case '/':
                    result = firstV / secondV;
                    tbMain.Text = result.ToString();
                    break;
            }

            result = Double.Parse(tbMain.Text);
            op = '0';
            move = false;
            firstV = 0;
        }
        private void btnSum_Click(object sender, RoutedEventArgs e)
        {
            op = '+';
            if (firstV == 0)
            {
                firstV = Double.Parse(tbMain.Text);

                move = true;
            }
            else
            {
                secondV = Double.Parse(tbMain.Text);
                double result = firstV + secondV;
                tbMain.Text = result.ToString();
                firstV = result;

                move = true;
            }
        }
        private void btnDiff_Click(object sender, RoutedEventArgs e)
        {
            op = '-';
            if (firstV == 0)
            {
                firstV = Double.Parse(tbMain.Text);

                move = true;
            }
            else
            {
                secondV = Double.Parse(tbMain.Text);
                double result = firstV - secondV;
                tbMain.Text = result.ToString();
                firstV = result;

                move = true;
            }
        }
        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            op = '*';
            if (firstV == 0)
            {
                firstV = Double.Parse(tbMain.Text);

                move = true;
            }
            else
            {
                secondV = Double.Parse(tbMain.Text);
                double result = firstV * secondV;
                tbMain.Text = result.ToString();
                firstV = result;

                move = true;
            }
        }
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            op = '/';
            if (firstV == 0)
            {
                firstV = Double.Parse(tbMain.Text);

                move = true;
            }
            else
            {
                secondV = Double.Parse(tbMain.Text);
                double result = firstV / secondV;
                tbMain.Text = result.ToString();
                firstV = result;

                move = true;
            }
        }
    }
}
