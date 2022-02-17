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

            Btplc40off.IsEnabled = false;
            Btplc24off.IsEnabled = false;
            BtEventer1off.IsEnabled = false;
            BtPumb1off.IsEnabled = false;

            BtEventer2off.IsEnabled = false;
            BtPumb2off.IsEnabled = false;

            BtPumb3off.IsEnabled = false;
            BtPumb4off.IsEnabled = false;
            BtPumb5off.IsEnabled = false;
            BtPumb6off.IsEnabled = false;

            Btnt1off.IsEnabled = false;
            Btnt2off.IsEnabled = false;
        }

        /// <summary>
        /// Switch Man
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManTM40(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(53, true);
            modbusClientTM40.WriteSingleCoil(54, false);
            BtMan.IsEnabled = false;
            BtAuto.IsEnabled = true;

            BtEventer1off.IsEnabled = true;
            BtEventer1on.IsEnabled = true;
            BtPumb1on.IsEnabled = true;
            BtPumb1off.IsEnabled = true;
            BtEventer2off.IsEnabled = true;
            BtEventer2on.IsEnabled = true;
            BtPumb2on.IsEnabled = true;
            BtPumb2off.IsEnabled = true;
            frequency1.IsEnabled = true;
            frequency2.IsEnabled = true;
            Boxfrequency1.IsEnabled = true;
            Boxfrequency2.IsEnabled = true;
        }

        /// <summary>
        /// Switch Auto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoTM40(object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(53, false);
            modbusClientTM40.WriteSingleCoil(54, true);
            BtAuto.IsEnabled = false;
            BtMan.IsEnabled = true;

            BtEventer1off.IsEnabled = false;
            BtEventer1on.IsEnabled = false;
            BtPumb1on.IsEnabled = false;
            BtPumb1off.IsEnabled = false;
            BtEventer2off.IsEnabled = false;
            BtEventer2on.IsEnabled = false;
            BtPumb2on.IsEnabled = false;
            BtPumb2off.IsEnabled = false;
            frequency1.IsEnabled = false;
            frequency2.IsEnabled = false;
            Boxfrequency1.IsEnabled = false;
            Boxfrequency2.IsEnabled = false;
        }

        /// <summary>
        /// Connected PLC TM221CE40R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectTM40(object sender, RoutedEventArgs e)
        {
            modbusClientTM40.Connect();
            Btplc40off.IsEnabled = true;
            Btplc40on.IsEnabled = false;
        }
        
        /// <summary>
        /// Disconnected PLC TM221CE40R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectTM40(object sender, RoutedEventArgs e)
        {
            modbusClientTM24.Disconnect();
            Btplc40on.IsEnabled = true;
            Btplc40off.IsEnabled = false;
        }

        /// <summary>
        /// Connected PLC TM221CE24R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectTM24(object sender, RoutedEventArgs e)
        {
            modbusClientTM40.Connect();
            Btplc24off.IsEnabled = true;
            Btplc24on.IsEnabled = false;
        }

        /// <summary>
        /// Disconnected PLC TM221CE24R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectTM24(object sender, RoutedEventArgs e)
        {
            modbusClientTM24.Disconnect();
            Btplc24on.IsEnabled = true;
            Btplc24off.IsEnabled = false;
        }

        /// <summary>
        /// Power Eventer 1 on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_1_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(21, true);
            BtEventer1on.IsEnabled = false;
            BtEventer1off.IsEnabled = true;
        }

        /// <summary>
        /// Power Eventer 1 off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_1_Off(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(21, false);
            BtEventer1off.IsEnabled = false;    
            BtEventer1on.IsEnabled = true;
        }

        /// <summary>
        /// Run pumb 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_1_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(20, true);
            BtPumb1on.IsEnabled = false;
            BtPumb1off.IsEnabled = true;
        }

        /// <summary>
        /// Stop pumb 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_1_Off(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(20, false);
            BtPumb1on.IsEnabled = true;
            BtPumb1off.IsEnabled = false;
        }

        /// <summary>
        /// Power Eventer 2 on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_2_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(23, true);
            BtEventer2on.IsEnabled = false;
            BtEventer2off.IsEnabled = true;
        }

        /// <summary>
        /// Power Eventer 2 off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_2_Off(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(23, false);
            BtEventer2off.IsEnabled = false;
            BtEventer2on.IsEnabled = true;
        }

        /// <summary>
        /// run pumb 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_2_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(22, true);
            BtPumb2on.IsEnabled = false;
            BtPumb2off.IsEnabled = true;
        }

        /// <summary>
        /// stop pumb 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_2_Off(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(22, false);
            BtPumb2on.IsEnabled = true;
            BtPumb2off.IsEnabled = false;
        }

        /// <summary>
        /// Run pumb javen 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_3_On(Object sender, RoutedEventArgs e)
        {
            BtPumb3on.IsEnabled = false;
            BtPumb3off.IsEnabled = true;
        }

        /// <summary>
        /// Stop pumb javen 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_3_Off(Object sender, RoutedEventArgs e)
        {
            BtPumb3on.IsEnabled = true;
            BtPumb3off.IsEnabled = false;

        }

        /// <summary>
        /// Run pumb javen 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_4_On(Object sender, RoutedEventArgs e)
        {
            BtPumb4on.IsEnabled = false;
            BtPumb4off.IsEnabled = true;
        }

        /// <summary>
        /// Stop pumb javen 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_4_Off(Object sender, RoutedEventArgs e)
        {
            BtPumb4on.IsEnabled = true;
            BtPumb4off.IsEnabled = false;
        }

        /// <summary>
        /// Run khuay 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_5_On(Object sender, RoutedEventArgs e)
        {
            BtPumb5on.IsEnabled = false;
            BtPumb5off.IsEnabled = true;
        }

        /// <summary>
        /// Stop khuay 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_5_Off(Object sender, RoutedEventArgs e)
        {
            BtPumb5on.IsEnabled = true;
            BtPumb5off.IsEnabled = false;

        }

        /// <summary>
        /// Run khuay 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_6_On(Object sender, RoutedEventArgs e)
        {
            BtPumb6on.IsEnabled = false;
            BtPumb6off.IsEnabled = true;
        }

        /// <summary>
        /// Stop khuay 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_6_Off(Object sender, RoutedEventArgs e)
        {
            BtPumb6on.IsEnabled = true;
            BtPumb6off.IsEnabled = false;
        }

        /// <summary>
        /// Run nuoc tho 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_1_On(object sender, RoutedEventArgs e)
        {
            Btnt1off.IsEnabled = true;
            Btnt1on.IsEnabled = false;
        }

        /// <summary>
        /// stop nuoc tho 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_1_Off(object sender, RoutedEventArgs e)
        {
            Btnt1off.IsEnabled = false;
            Btnt1on.IsEnabled = true;
        }

        /// <summary>
        /// Run nuoc tho 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_2_On(object sender, RoutedEventArgs e)
        {
            Btnt2off.IsEnabled = true;
            Btnt2on.IsEnabled = false;
        }

        /// <summary>
        /// Stop nuoc tho 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_2_Off(object sender, RoutedEventArgs e)
        {
            Btnt2off.IsEnabled = false;
            Btnt2on.IsEnabled = true;
        }

    }
}
