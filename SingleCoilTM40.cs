using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Scada_TM221_WaterFllow
{
    public class SingleCoilTM40 : INotifyPropertyChanged
    {
        private readonly bool[] m;
        private readonly ushort[] mw;
        public SingleCoilTM40() { }
        public ushort MW0
        {
            get { return mw[0]; }
            set { mw[0] = value; OnChangeProperty("MW0"); }
        }
        public ushort MW1
        {
            get { return mw[1]; }
            set { mw[1] = value; OnChangeProperty("MW1"); }
        }
        public ushort MW2
        {
            get { return mw[2]; }
            set { mw[2] = value; OnChangeProperty("MW2"); }
        }
        public ushort MW3
        {
            get { return mw[3]; }
            set { mw[3] = value; OnChangeProperty("MW3"); }
        }
        public bool M0
        {
            get { return m[0]; }
            set { m[0] = value; OnChangeProperty("M0"); }
        }
        public bool M1
        {
            get { return m[1]; }
            set { m[1] = value; OnChangeProperty("M1"); }
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
        public bool M9
        {
            get { return m[9]; }
            set { m[9] = value; OnChangeProperty("M9"); }
        }
        public bool M10
        {
            get { return m[10]; }
            set { m[10] = value; OnChangeProperty("M10"); }
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
        public bool M13
        {
            get { return m[13]; }
            set { m[13] = value; OnChangeProperty("M13"); }
        }
        public bool M14
        {
            get { return m[14]; }
            set { m[14] = value; OnChangeProperty("M14"); }
        }
        public bool M15
        {
            get { return m[15]; }
            set { m[15] = value; OnChangeProperty("M15"); }
        }
        public bool M16
        {
            get { return m[16]; }
            set { m[16] = value; OnChangeProperty("M16"); }
        }
        public bool M17
        {
            get { return m[17]; }
            set { m[17] = value; OnChangeProperty("M17"); }
        }
        public bool M18
        {
            get { return m[18]; }
            set { m[18] = value; OnChangeProperty("M18"); }
        }
        public bool M19
        {
            get { return m[19]; }
            set { m[19] = value; OnChangeProperty("M19"); }
        }
        public bool M20
        {
            get { return m[20]; }
            set { m[20] = value; OnChangeProperty("M20"); }
        }
        public bool M21
        {
            get { return m[21]; }
            set { m[21] = value; OnChangeProperty("M21"); }
        }
        public bool M22
        {
            get { return m[22]; }
            set { m[22] = value; OnChangeProperty("M22"); }
        }
        public bool M23
        {
            get { return m[23]; }
            set { m[23] = value; OnChangeProperty("M23"); }
        }
        public bool M30
        {
            get { return m[30]; }
            set { m[30] = value; OnChangeProperty("M30"); }
        }
        public bool M31
        {
            get { return m[31]; }
            set { m[31] = value; OnChangeProperty("M31"); }
        }
        public bool M32
        {
            get { return m[32]; }
            set { m[32] = value; OnChangeProperty("M32"); }
        }
        public bool M33
        {
            get { return m[33]; }
            set { m[33] = value; OnChangeProperty("M33"); }
        }
        public bool M41
        {
            get { return m[41]; }
            set { m[41] = value; OnChangeProperty("M41"); }
        }
        public bool M42
        {
            get { return m[42]; }
            set { m[42] = value; OnChangeProperty("M42"); }
        }
        public bool M43
        {
            get { return m[43]; }
            set { m[43] = value; OnChangeProperty("M43"); }
        }
        public bool M44
        {
            get { return m[44]; }
            set { m[44] = value; OnChangeProperty("M44"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChangeProperty(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
