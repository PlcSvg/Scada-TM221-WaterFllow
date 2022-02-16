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
using EasyModbus;

namespace Scada_TM221_WaterFllow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModbusClient modbusClientTM40 = new ModbusClient();
        ModbusClient modbusClientTM24 = new ModbusClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectTM40(object sender, RoutedEventArgs e)
        {
            modbusClientTM40.Connect();
        }

        private void DisconnectTM40(object sender, RoutedEventArgs e)
        {
            modbusClientTM40?.Disconnect();
        }


    }
}
