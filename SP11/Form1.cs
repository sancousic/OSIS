using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                while (true)
                {
                    setL1();
                    Thread.Sleep(new TimeSpan(0,1,0));
                }
            });
            Task.Run(() =>
            {
                while (true)
                {
                    setL2();
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                }
            });
            Task.Run(() =>
            {
                while (true)
                {
                    setL3();
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                }
            });
        }
        void setL1()
        {
            label1.Invoke(new Action(() =>
            {
                label1.Text = DateTime.Now.Hour.ToString();
            }));
        }
        void setL2()
        {
            label1.Invoke(new Action(() =>
            {
                label2.Text = DateTime.Now.Minute.ToString();
            }));
        }
        void setL3()
        {
            label1.Invoke(new Action(() =>
            {
                label3.Text = DateTime.Now.Second.ToString();
            }));
        }
    }
}
