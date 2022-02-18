using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Scada_TM221_WaterFllow
{
    public class SingleCoilTM24 : INotifyPropertyChanged
    {
        private readonly bool[] m = new bool[15];
        public event PropertyChangedEventHandler PropertyChanged;

        public bool M1
        {
            get { return m[1]; }
            set { m[1] = value;  OnChangeProperty("M1"); }
        }
        public bool M2
        {
            get { return m[2]; }
            set { m[2] = value; OnChangeProperty("M2"); }
        }
        public bool M3
        {
            get { return m[3]; }
            set { m[3] = value; OnChangeProperty("M3"); }
        }
        public bool M4
        {
            get { return m[4]; }
            set { m[4] = value; OnChangeProperty("M4"); }
        }
        public bool M5
        {
            get { return m[5]; }
            set { m[5] = value; OnChangeProperty("M5"); }
        }
        public bool M6
        {
            get { return m[6]; }
            set { m[6] = value; OnChangeProperty("M6"); }
        }
        public bool M7
        {
            get { return m[7]; }
            set { m[7] = value; OnChangeProperty("M7"); }
        }
        public bool M8
        {
            get { return m[8]; }
            set { m[8] = value; OnChangeProperty("M8"); }
        }
        public bool M11
        {
            get { return m[11]; }
            set { m[11] = value; OnChangeProperty("M11"); }
        }
        public bool M12
        {
            get { return m[12]; }
            set { m[12] = value; OnChangeProperty("M12"); }
        }
        
        public void OnChangeProperty(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
