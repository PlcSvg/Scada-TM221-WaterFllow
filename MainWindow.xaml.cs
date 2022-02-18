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
        public ModbusClient modbusClientTM40 = new ModbusClient();
        public ModbusClient modbusClientTM24 = new ModbusClient();
        public SingleCoilTM40 singleCoilTM40 = new SingleCoilTM40();
        public MainWindow()
        {
            InitializeComponent();
            BeginEnableButton();
            modbusClientTM40.Connect();
            SourceSingleCoilTM40.DataContext = singleCoilTM40;
            CompositionTarget.Rendering += OnTimedEventTM40;
        }

        /// <summary>
        /// Timer request read single coil TM221CE40R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEventTM40(object sender, EventArgs e)
        {
            singleCoilTM40.M0 = modbusClientTM40.ReadCoils(0, 1)[0];
            singleCoilTM40.M1 = modbusClientTM40.ReadCoils(1, 1)[0];
            singleCoilTM40.M2 = modbusClientTM40.ReadCoils(2, 1)[0];
            singleCoilTM40.M3 = modbusClientTM40.ReadCoils(3, 1)[0];
            singleCoilTM40.M4 = modbusClientTM40.ReadCoils(4, 1)[0];
            singleCoilTM40.M5 = modbusClientTM40.ReadCoils(5, 1)[0];
            singleCoilTM40.M6 = modbusClientTM40.ReadCoils(6, 1)[0];
            singleCoilTM40.M7 = modbusClientTM40.ReadCoils(7, 1)[0];
            singleCoilTM40.M8 = modbusClientTM40.ReadCoils(8, 1)[0];
            singleCoilTM40.M9 = modbusClientTM40.ReadCoils(9, 1)[0];
            singleCoilTM40.M10 = modbusClientTM40.ReadCoils(10, 1)[0];
            singleCoilTM40.M11 = modbusClientTM40.ReadCoils(11, 1)[0];
            singleCoilTM40.M12 = modbusClientTM40.ReadCoils(12, 1)[0];
            singleCoilTM40.M14 = modbusClientTM40.ReadCoils(14, 1)[0];
            singleCoilTM40.M15 = modbusClientTM40.ReadCoils(15, 1)[0];
            singleCoilTM40.M16 = modbusClientTM40.ReadCoils(16, 1)[0];
            singleCoilTM40.M17 = modbusClientTM40.ReadCoils(17, 1)[0];
            singleCoilTM40.M18 = modbusClientTM40.ReadCoils(18, 1)[0];
            singleCoilTM40.M19 = modbusClientTM40.ReadCoils(19, 1)[0];
        }

        /// <summary>
        /// Set Button off false when start app
        /// </summary>
        private void BeginEnableButton()
        {
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
            modbusClientTM40.WriteSingleCoil(43, true);
            modbusClientTM40.WriteSingleCoil(44, false);
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
            //Boxfrequency1.IsEnabled = true;
            //Boxfrequency2.IsEnabled = true;
        }

        /// <summary>
        /// Switch Auto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoTM40(object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(43, false);
            modbusClientTM40.WriteSingleCoil(44, true);
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
            //Boxfrequency1.IsEnabled = false;
            //Boxfrequency2.IsEnabled = false;
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
        /// Start pumb javen 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_3_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(41, true);
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
            modbusClientTM40.WriteSingleCoil(41, false);
            BtPumb3on.IsEnabled = true;
            BtPumb3off.IsEnabled = false;
        }
        /// <summary>
        /// Start pumb javen 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_4_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(42, true);
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
            modbusClientTM40.WriteSingleCoil(42, false);
            BtPumb4on.IsEnabled = true;
            BtPumb4off.IsEnabled = false;
        }
        /// <summary>
        /// Start pumb khuay 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_5_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(43, true);
            BtPumb5on.IsEnabled = false;
            BtPumb5off.IsEnabled = true;
        }
        /// <summary>
        /// Stop pumb khuay 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_5_Off(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(43, false);
            BtPumb5on.IsEnabled = true;
            BtPumb5off.IsEnabled = false;

        }
        /// <summary>
        /// Start pumb khuay 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_6_On(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(44, true);
            BtPumb6on.IsEnabled = false;
            BtPumb6off.IsEnabled = true;
        }
        /// <summary>
        /// Stop pumb khuay 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_6_Off(Object sender, RoutedEventArgs e)
        {
            modbusClientTM40.WriteSingleCoil(44, false);
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
