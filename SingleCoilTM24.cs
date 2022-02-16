using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Scada_TM221_WaterFllow
{
    internal class SingleCoilTM24 : INotifyPropertyChanged
    {
        /// <summary>
        /// Low water
        /// </summary>
        private bool m1;
        /// <summary>
        /// Mode Auto
        /// </summary>
        private bool m2;
        /// <summary>
        /// Mode Man
        /// </summary>
        private bool m3;
        /// <summary>
        /// Protect phase
        /// </summary>
        private bool m4;
        /// <summary>
        /// Run Soft stater 1
        /// </summary>
        private bool m5;
        /// <summary>
        /// Run soft stater 2
        /// </summary>
        private bool m6;
        /// <summary>
        /// Error pumb 1
        /// </summary>
        private bool m7;
        /// <summary>
        /// Error pumb 2
        /// </summary>
        private bool m8;

        public bool M1
        {
            get { return m1; }
            set { m1 = value;  OnChangeProperty("M1"); }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChangeProperty(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
