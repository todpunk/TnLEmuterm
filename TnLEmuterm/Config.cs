using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnLEmuterm
{
    public static class Config
    {
        public static string RecievedText;
        public static Boolean ShiftEnterSends;
        public static Boolean ClearEditor;
        public static SerialPort serialPort = new SerialPort();
    }
}
