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
        private readonly Random _rand = new Random();
        public ModbusClient modbusClientTM40 = new ModbusClient();
        public ModbusClient modbusClientTM24 = new ModbusClient();
        public SingleCoilTM40 singleCoilTM40 = new SingleCoilTM40();
        public SingleCoilTM24 singleCoilTM24 = new SingleCoilTM24();
        public MainWindow()
        {
            InitializeComponent();
            BeginEnableButton();


            sc1.DataContext = singleCoilTM40;
            sc2.DataContext = singleCoilTM40;
            sc3.DataContext = singleCoilTM40;
            sc4.DataContext = singleCoilTM40;
            sc5.DataContext = singleCoilTM40;
            sc6.DataContext = singleCoilTM40;
            sc7.DataContext = singleCoilTM40;

            //SourceControlTM24.DataContext = singleCoilTM24;
            //SourceStatusTM24.DataContext = singleCoilTM24;
            //SourceTM24.DataContext = singleCoilTM24;
        }





        /// <summary>
        /// Set Button off false when start app
        /// </summary>
        private void BeginEnableButton()
        {
            BtAutoOn.IsEnabled = false;
            BtAutoOff.IsEnabled = false;
            Btplc40off.IsEnabled = false;
            Btplc24off.IsEnabled = false;
            BtEventer1off.IsEnabled = false;
            BtEventer1on.IsEnabled = false;
            BtPumb1off.IsEnabled = false;
            BtPumb1on.IsEnabled = false;
            BtEventer2off.IsEnabled = false;
            BtEventer2on.IsEnabled = false;
            BtPumb2off.IsEnabled = false;
            BtPumb2on.IsEnabled = false;
            BtPumb3off.IsEnabled = false;
            BtPumb3on.IsEnabled = false;
            BtPumb4off.IsEnabled = false;
            BtPumb4on.IsEnabled = false;
            BtPumb5off.IsEnabled = false;
            BtPumb5on.IsEnabled = false;
            BtPumb6off.IsEnabled = false;
            BtPumb6on.IsEnabled = false;
            AnimationHightWaterTank.Color = Colors.LightGray;
            AnimationLowtWaterTank.Color = Colors.LightGray;
            AnimationErrorPhaseStation2.Color = Colors.LightGray;
            Btnt1off.IsEnabled = false;
            Btnt1on.IsEnabled = false;
            Btnt2off.IsEnabled = false;
            Btnt2on.IsEnabled = false;
            HightWaterRawAnimation.Color = Colors.LightGray;
            AnimationLowWater.Color = Colors.LightGray;
            ErrorPhaseAnimation.Color = Colors.LightGray;
        }

        /// <summary>
        /// Switch Man
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoTM40Off(Object sender, RoutedEventArgs e)
        {
            if(modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(53, true);
                modbusClientTM40.WriteSingleCoil(54, false);
                BtAutoOn.IsEnabled = true;
                BtAutoOff.IsEnabled = false;
                BtEventer1off.IsEnabled = false;
                BtEventer1on.IsEnabled = true;
                BtPumb1off.IsEnabled = false;
                BtPumb1on.IsEnabled = true;
                BtEventer2off.IsEnabled = false;
                BtEventer2on.IsEnabled = true;
                BtPumb2off.IsEnabled = false;
                BtPumb2on.IsEnabled = true;
                frequency1.IsEnabled = true;
                frequency2.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }

        }
        /// <summary>
        /// Switch Auto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoTM40On(object sender, RoutedEventArgs e)
        {
            if(modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(53, false);
                modbusClientTM40.WriteSingleCoil(54, true);
                BtAutoOn.IsEnabled = false;
                BtAutoOff.IsEnabled = true;
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
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }

        }
        /// <summary>
        /// Connected PLC TM221CE40R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectTM40(object sender, RoutedEventArgs e)
        {
            try
            {
                modbusClientTM40.Connect();
                Btplc40off.IsEnabled = true;
                Btplc40on.IsEnabled = false;
                BtAutoOn.IsEnabled = true;
                CompositionTarget.Rendering += OnTimedEventTM40;
            } catch {MessageBox.Show("Can't connect PLC TM221CE40R, You. Please check your hardware connection!!!");}
        }
        /// <summary>
        /// Disconnected PLC TM221CE40R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectTM40(object sender, RoutedEventArgs e)
        {
            BtAutoOn.IsEnabled = false;
            BtAutoOff.IsEnabled = false;
            Btplc40on.IsEnabled = true;
            Btplc40off.IsEnabled = false;
            BtEventer1off.IsEnabled = false;
            BtEventer1on.IsEnabled = false;
            BtPumb1off.IsEnabled = false;
            BtPumb1on.IsEnabled = false;
            BtEventer2off.IsEnabled = false;
            BtEventer2on.IsEnabled = false;
            BtPumb2off.IsEnabled = false;
            BtPumb2on.IsEnabled = false;
            BtPumb3off.IsEnabled = false;
            BtPumb3on.IsEnabled = false;
            BtPumb4off.IsEnabled = false;
            BtPumb4on.IsEnabled = false;
            BtPumb5off.IsEnabled = false;
            BtPumb5on.IsEnabled = false;
            BtPumb6off.IsEnabled = false;
            BtPumb6on.IsEnabled = false;
            modbusClientTM40.Disconnect();
        }
        /// <summary>
        /// Connected PLC TM221CE24R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// Timer request read single coil TM221CE40R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEventTM40(object sender, EventArgs e)
        {
            try
            {
                if (modbusClientTM40.Connected == true)
                {
                    singleCoilTM40.M0 = modbusClientTM40.ReadCoils(0, 1)[0];
                    if (singleCoilTM40.M0 == true)
                    {
                        AnimationErrorPhaseStation2.Color = Color.FromRgb((byte)_rand.Next(255), (byte)_rand.Next(255), (byte)_rand.Next(255));
                    }
                    else if (singleCoilTM40.M1 == false)
                    {
                        AnimationErrorPhaseStation2.Color = Colors.MediumSpringGreen;
                    }
                    singleCoilTM40.M1 = modbusClientTM40.ReadCoils(1, 1)[0];
                    if (singleCoilTM40.M1 == true)
                    {
                        AnimationHightWaterTank.Color = Colors.LightGray;
                        AnimationLowtWaterTank.Color = Color.FromRgb((byte)_rand.Next(255), (byte)_rand.Next(255), (byte)_rand.Next(255));
                    }
                    else if (singleCoilTM40.M1 == false)
                    {
                        AnimationHightWaterTank.Color = Colors.MediumSpringGreen;
                        AnimationLowtWaterTank.Color = Colors.LightGray;
                    }
                    singleCoilTM40.M2 = modbusClientTM40.ReadCoils(2, 1)[0];
                    singleCoilTM40.M3 = modbusClientTM40.ReadCoils(3, 1)[0];
                    singleCoilTM40.M4 = modbusClientTM40.ReadCoils(4, 1)[0];
                    singleCoilTM40.M5 = modbusClientTM40.ReadCoils(5, 1)[0];
                    if (singleCoilTM40.M5 == true)
                    {
                        BtEventer1on.IsEnabled = false;

                        BtEventer1off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M5 == false)
                    {
                        BtEventer1on.IsEnabled = true;
                        BtEventer1off.IsEnabled = false;
                    }
                    singleCoilTM40.M6 = modbusClientTM40.ReadCoils(6, 1)[0];
                    if (singleCoilTM40.M6 == true)
                    {
                        BtEventer2on.IsEnabled = false;

                        BtEventer2off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M6 == false)
                    {
                        BtEventer2on.IsEnabled = true;
                        BtEventer2off.IsEnabled = false;
                    }
                    singleCoilTM40.M7 = modbusClientTM40.ReadCoils(7, 1)[0];
                    if (singleCoilTM40.M7 == true)
                    {
                        BtPumb1on.IsEnabled = false;

                        BtPumb1off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M7 == false)
                    {
                        BtPumb1on.IsEnabled = true;
                        BtPumb1off.IsEnabled = false;
                    }
                    singleCoilTM40.M8 = modbusClientTM40.ReadCoils(8, 1)[0];
                    if (singleCoilTM40.M8 == true)
                    {
                        BtPumb2on.IsEnabled = false;

                        BtPumb2off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M8 == false)
                    {
                        BtPumb2on.IsEnabled = true;
                        BtPumb2off.IsEnabled = false;
                    }
                    singleCoilTM40.M9 = modbusClientTM40.ReadCoils(9, 1)[0];
                    if (singleCoilTM40.M9 == true)
                    {
                        BtPumb3on.IsEnabled = false;

                        BtPumb3off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M9 == false)
                    {
                        BtPumb3on.IsEnabled = true;
                        BtPumb3off.IsEnabled = false;
                    }
                    singleCoilTM40.M10 = modbusClientTM40.ReadCoils(10, 1)[0];
                    if (singleCoilTM40.M10 == true)
                    {
                        BtPumb4on.IsEnabled = false;

                        BtPumb4off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M10 == false)
                    {
                        BtPumb4on.IsEnabled = true;
                        BtPumb4off.IsEnabled = false;
                    }
                    singleCoilTM40.M11 = modbusClientTM40.ReadCoils(11, 1)[0];
                    if (singleCoilTM40.M11 == true)
                    {
                        BtPumb5on.IsEnabled = false;

                        BtPumb5off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M11 == false)
                    {
                        BtPumb5on.IsEnabled = true;
                        BtPumb5off.IsEnabled = false;
                    }
                    singleCoilTM40.M12 = modbusClientTM40.ReadCoils(12, 1)[0];
                    if (singleCoilTM40.M12 == true)
                    {
                        BtPumb6on.IsEnabled = false;

                        BtPumb6off.IsEnabled = true;
                    }
                    else if (singleCoilTM40.M12 == false)
                    {
                        BtPumb6on.IsEnabled = true;
                        BtPumb6off.IsEnabled = false;
                    }
                    singleCoilTM40.M14 = modbusClientTM40.ReadCoils(14, 1)[0];
                    singleCoilTM40.M15 = modbusClientTM40.ReadCoils(15, 1)[0];
                    singleCoilTM40.M16 = modbusClientTM40.ReadCoils(16, 1)[0];
                    singleCoilTM40.M17 = modbusClientTM40.ReadCoils(17, 1)[0];
                    singleCoilTM40.M18 = modbusClientTM40.ReadCoils(18, 1)[0];
                    singleCoilTM40.M19 = modbusClientTM40.ReadCoils(19, 1)[0];
                    singleCoilTM40.M53 = modbusClientTM40.ReadCoils(53, 1)[0];
                    singleCoilTM40.M54 = modbusClientTM40.ReadCoils(54, 1)[0];
                } else if (modbusClientTM40.Connected == false)
                {
                    Btplc40off.IsEnabled = false;
                    Btplc24off.IsEnabled = false;
                    BtEventer1off.IsEnabled = false;
                    BtEventer1on.IsEnabled = false;
                    BtPumb1off.IsEnabled = false;
                    BtPumb1on.IsEnabled = false;
                    BtEventer2off.IsEnabled = false;
                    BtEventer2on.IsEnabled = false;
                    BtPumb2off.IsEnabled = false;
                    BtPumb2on.IsEnabled = false;
                    BtPumb3off.IsEnabled = false;
                    BtPumb3on.IsEnabled = false;
                    BtPumb4off.IsEnabled = false;
                    BtPumb4on.IsEnabled = false;
                    BtPumb5off.IsEnabled = false;
                    BtPumb5on.IsEnabled = false;
                    BtPumb6off.IsEnabled = false;
                    BtPumb6on.IsEnabled = false;
                    AnimationHightWaterTank.Color = Colors.LightGray;
                    AnimationLowtWaterTank.Color= Colors.LightGray;
                    AnimationErrorPhaseStation2.Color = Colors.LightGray;
                }
            } catch
            {
                modbusClientTM40.Disconnect();
                MessageBox.Show("Can't connect PLC TM221CE24R, You. Please check your hardware connection!!!");
            }

        }

        /// <summary>
        /// Power Eventer 1 on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_1_On(Object sender, RoutedEventArgs e)
        {
            if(modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(22, true);
                BtEventer1on.IsEnabled = false;
                BtEventer1off.IsEnabled = true;
            } else MessageBox.Show("You are not connected to PLC TM221CE40R");
        }
        /// <summary>
        /// Power Eventer 1 off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_1_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(22, false);
                BtEventer1off.IsEnabled = false;    
                BtEventer1on.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Run pumb 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_1_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(21, true);
                BtPumb1on.IsEnabled = false;
                BtPumb1off.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Stop pumb 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_1_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(21, false);
                BtPumb1on.IsEnabled = true;
                BtPumb1off.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Power Eventer 2 on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_2_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(24, true);
                BtEventer2on.IsEnabled = false;
                BtEventer2off.IsEnabled = true;

            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Power Eventer 2 off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eventer_2_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(24, false);
                BtEventer2off.IsEnabled = false;
                BtEventer2on.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// run pumb 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_2_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(23, true);
                BtPumb2on.IsEnabled = false;
                BtPumb2off.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        } 
        /// <summary>
        /// stop pumb 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_2_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected || singleCoilTM40.M54 == true || singleCoilTM40.M53 == false)
            {
                modbusClientTM40.WriteSingleCoil(23, false);
                BtPumb2on.IsEnabled = true;
                BtPumb2off.IsEnabled = false;

            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Start pumb javen 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_3_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(41, true);
                BtPumb3on.IsEnabled = false;
                BtPumb3off.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Stop pumb javen 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_3_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(41, false);
                BtPumb3on.IsEnabled = true;
                BtPumb3off.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Start pumb javen 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_4_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(42, true);
                BtPumb4on.IsEnabled = false;
                BtPumb4off.IsEnabled = true;

            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Stop pumb javen 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Javen_4_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(42, false);
                BtPumb4on.IsEnabled = true;
                BtPumb4off.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }

        }
        /// <summary>
        /// Start pumb khuay 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_5_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(43, true);
                BtPumb5on.IsEnabled = false;
                BtPumb5off.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Stop pumb khuay 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_5_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(43, false);
                BtPumb5on.IsEnabled = true;
                BtPumb5off.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }
        /// <summary>
        /// Start pumb khuay 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_6_On(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(44, true);
                BtPumb6on.IsEnabled = false;
                BtPumb6off.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }

        }
        /// <summary>
        /// Stop pumb khuay 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_Khuay_6_Off(Object sender, RoutedEventArgs e)
        {
            if (modbusClientTM40.Connected)
            {
                modbusClientTM40.WriteSingleCoil(44, false);
                BtPumb6on.IsEnabled = true;
                BtPumb6off.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE40R"); }
        }



        private void ConnectTM24(object sender, RoutedEventArgs e)
        {
            try
            {
                modbusClientTM24.Connect();
                Btplc24off.IsEnabled = true;
                Btplc24on.IsEnabled = false;
                CompositionTarget.Rendering += OnTimedEventTM24;
            }
            catch { MessageBox.Show("Can't connect PLC TM221CE24R, You. Please check your hardware connection!!!"); }
        }
        /// <summary>
        /// Disconnected PLC TM221CE24R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectTM24(object sender, RoutedEventArgs e)
        {
            Btplc24on.IsEnabled = true;
            Btplc24off.IsEnabled = false;
            Btnt1on.IsEnabled = false;
            Btnt1off.IsEnabled = false;
            Btnt2on.IsEnabled = false;
            Btnt2off.IsEnabled = false;
            modbusClientTM24.Disconnect();
        }
        /// <summary>
        /// Timer request read single coil TM221CE24R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEventTM24(object sender, EventArgs e)
        {
            try
            { 
                if(modbusClientTM24.Connected == true)
                {
                    singleCoilTM24.M1 = modbusClientTM24.ReadCoils(1, 1)[0];
                    if (singleCoilTM24.M1 == true)
                    {
                        HightWaterRawAnimation.Color = Colors.LightGray;
                        AnimationLowWater.Color = Color.FromRgb((byte)_rand.Next(255), (byte)_rand.Next(255), (byte)_rand.Next(255));
                    } else if (singleCoilTM24.M1 == false) {
                        HightWaterRawAnimation.Color = Colors.MediumSpringGreen;
                        AnimationLowWater.Color = Colors.LightGray;
                    }
                        
                    singleCoilTM24.M2 = modbusClientTM24.ReadCoils(2, 1)[0];
                    singleCoilTM24.M3 = modbusClientTM24.ReadCoils(3, 1)[0];

                    singleCoilTM24.M4 = modbusClientTM24.ReadCoils(4, 1)[0];
                    if (singleCoilTM24.M4 == true)
                    {
                        ErrorPhaseAnimation.Color = Color.FromRgb((byte)_rand.Next(255), (byte)_rand.Next(255), (byte)_rand.Next(255));
                    }
                    else if (singleCoilTM24.M4 == false) 
                    {
                        ErrorPhaseAnimation.Color = Colors.MediumSpringGreen;
                    }

                    singleCoilTM24.M5 = modbusClientTM24.ReadCoils(5, 1)[0];
                    if (singleCoilTM24.M5 == true)
                    {
                        Btnt1on.IsEnabled = false;
                        Btnt1off.IsEnabled = true;
                    }
                    else if (singleCoilTM24.M5 == false)
                    {
                        Btnt1on.IsEnabled = true;
                        Btnt1off.IsEnabled = false;
                    }
                    singleCoilTM24.M6 = modbusClientTM24.ReadCoils(6, 1)[0];
                    if (singleCoilTM24.M6 == true)
                    {
                        Btnt2on.IsEnabled = false;

                        Btnt2off.IsEnabled = true;
                    }
                    else if (singleCoilTM24.M6 == false)
                    {
                        Btnt2on.IsEnabled = true;
                        Btnt2off.IsEnabled = false;
                    }
                    singleCoilTM24.M7 = modbusClientTM24.ReadCoils(7, 1)[0];
                    singleCoilTM24.M8 = modbusClientTM24.ReadCoils(8, 1)[0];
                } else if (modbusClientTM24.Connected == false)
                {
                    Btplc24on.IsEnabled = true;
                    Btplc24off.IsEnabled = false;
                    Btnt1on.IsEnabled = false;
                    Btnt1off.IsEnabled = false;
                    Btnt2on.IsEnabled = false;
                    Btnt2off.IsEnabled = false;
                    HightWaterRawAnimation.Color = Colors.LightGray;
                    AnimationLowWater.Color = Colors.LightGray;
                    ErrorPhaseAnimation.Color = Colors.LightGray;
                }
            } catch {
                modbusClientTM24.Disconnect();
                MessageBox.Show("Can't connect PLC TM221CE24R, You. Please check your hardware connection!!!"); 
            }
        }
        /// <summary>
        /// Start nuoc tho 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_1_On(object sender, RoutedEventArgs e)
        {
            if (modbusClientTM24.Connected)
            {
                modbusClientTM24.WriteSingleCoil(11, true);
                Btnt1off.IsEnabled = true;
                Btnt1on.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE24R");}
        }
        /// <summary>
        /// Stop nuoc tho 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_1_Off(object sender, RoutedEventArgs e)
        {
            if (modbusClientTM24.Connected)
            {
                modbusClientTM24.WriteSingleCoil(11, false);
                Btnt1off.IsEnabled = false;
                Btnt1on.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE24R"); }
        }
        /// <summary>
        /// Start nuoc tho 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_2_On(object sender, RoutedEventArgs e)
        {
            if (modbusClientTM24.Connected)
            {
                modbusClientTM24.WriteSingleCoil (12, true);
                Btnt2off.IsEnabled = true;
                Btnt2on.IsEnabled = false;
            } else { MessageBox.Show("You are not connected to PLC TM221CE24R"); }
        }
        /// <summary>
        /// Stop nuoc tho 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pumb_NT_2_Off(object sender, RoutedEventArgs e)
        {
            if (modbusClientTM24.Connected)
            {
                modbusClientTM24.WriteSingleCoil(12, false);
                Btnt2off.IsEnabled = false;
                Btnt2on.IsEnabled = true;
            } else { MessageBox.Show("You are not connected to PLC TM221CE24R"); }
        }
    }
}
