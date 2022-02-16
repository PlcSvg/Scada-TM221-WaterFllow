using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Scada_TM221_WaterFllow
{
    internal class SingleCoilTM40: INotifyPropertyChanged
    {
        /// <summary>
        /// status Digital input PLC TM221T40R; Map Memory %M1~M19
        /// </summary>
        private bool m1;
        private bool m2;
        private bool m3;
        private bool m4;
        private bool m5;
        private bool m6;
        private bool m7;
        private bool m8;
        private bool m9;
        private bool m10;
        private bool m11;
        private bool m12;
        private bool m13;
        private bool m14;
        private bool m15;
        private bool m16;
        private bool m17;
        private bool m18;
        private bool m19;

        /// <summary>
        /// Mode Remote Pumb and Inventer 22kw; Map Memory %M20~%M23
        /// </summary>
        private bool m20;
        private bool m21;
        private bool m22;
        private bool m23;

        /// <summary>
        /// Mode Auto Pumb and Inventer 22kw; Map Memory %M30~%M33
        /// </summary>
        private bool m30;
        private bool m31;
        private bool m32;
        private bool m33;

        /// <summary>
        /// Protect P1: %m51; Protect P2: %m52; Mode Remote %m53; Mode Auto %m54
        /// </summary>
        private bool m51;
        private bool m52;
        private bool m53;
        private bool m54;

        /// <summary>
        /// ######################################################################################################
        /// </summary>
        public bool M1
        {
            get { return m1; }
            set { m1 = value; OnChangeProperty("M1"); }
        }

        public bool M2
        {
            get { return m2; }
            set { m2 = value; OnChangeProperty("M2"); }
        }

        public bool M3
        {
            get { return m3; }
            set { m3 = value; OnChangeProperty("M3"); }
        }

        public bool M4
        {
            get { return m4; }
            set { m4 = value; OnChangeProperty("M4"); }
        }

        public bool M5
        {
            get { return m5; }
            set { m5 = value; OnChangeProperty("M5"); }
        }

        public bool M6
        {
            get { return m6; }
            set { m6 = value; OnChangeProperty("M6"); }
        }

        public bool M7
        {
            get { return m7; }
            set { m7 = value; OnChangeProperty("M7"); }
        }

        public bool M8
        {
            get { return m8; }
            set { m8 = value; OnChangeProperty("M8"); }
        }

        public bool M9
        {
            get { return m9; }
            set { m9 = value; OnChangeProperty("M9"); }
        }

        public bool M10
        {
            get { return m10; }
            set { m10 = value; OnChangeProperty("M10"); }
        }

        public bool M11
        {
            get { return m11; }
            set { m11 = value; OnChangeProperty("M11"); }
        }

        public bool M12
        {
            get { return m12; }
            set { m12 = value; OnChangeProperty("M12"); }
        }

        public bool M13
        {
            get { return m13; }
            set { m13 = value; OnChangeProperty("M13"); }
        }

        public bool M14
        {
            get { return m14; }
            set { m14 = value; OnChangeProperty("M14"); }
        }

        public bool M15
        {
            get { return m15; }
            set { m15 = value; OnChangeProperty("M15"); }
        }

        public bool M16
        {
            get { return m16; }
            set { m16 = value; OnChangeProperty("M16"); }
        }

        public bool M17
        {
            get { return m17; }
            set { m17 = value; OnChangeProperty("M17"); }
        }

        public bool M18
        {
            get { return m18; }
            set { m18 = value; OnChangeProperty("M18"); }
        }

        public bool M19
        {
            get { return m19; }
            set { m19 = value; OnChangeProperty("M19"); }
        }

        /// <summary>
        /// ######################################################################################################
        /// </summary>
        public bool M20
        {
            get { return m20; }
            set { m20 = value; OnChangeProperty("M20"); }
        }

        public bool M21
        {
            get { return m21; }
            set { m21 = value; OnChangeProperty("M21"); }
        }

        public bool M22
        {
            get { return m22; }
            set { m22 = value; OnChangeProperty("M22"); }
        }

        public bool M23
        {
            get { return m23; }
            set { m23 = value; OnChangeProperty("M23"); }
        }

        /// <summary>
        /// ######################################################################################################
        /// </summary>
        public bool M30
        {
            get { return m30; }
            set { m30 = value; OnChangeProperty("M30"); }
        }

        public bool M31
        {
            get { return m31; }
            set { m31 = value; OnChangeProperty("M31"); }
        }

        public bool M32
        {
            get { return m32; }
            set { m32 = value; OnChangeProperty("M32"); }
        }

        public bool M33
        {
            get { return m33; }
            set { m33 = value; OnChangeProperty("M33"); }
        }

        /// <summary>
        /// ######################################################################################################
        /// </summary>
        public bool M51
        {
            get { return m51; }
            set { m51 = value; OnChangeProperty("M51"); }
        }

        public bool M52
        {
            get { return m52; }
            set { m52 = value; OnChangeProperty("M52"); }
        }

        public bool M53
        {
            get { return m53; }
            set { m53 = value; OnChangeProperty("M53"); }
        }

        public bool M54
        {
            get { return m54; }
            set { m54 = value; OnChangeProperty("M54"); }
        }

        /// <summary>
        /// ######################################################################################################
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChangeProperty(string info)
        {
            PropertyChanged?.Invoke(PropertyChanged, new PropertyChangedEventArgs(info));
        }
    }
}
