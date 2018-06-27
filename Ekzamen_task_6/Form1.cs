using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// =======================================================
// Разработать программу, 
// которая по таймеру с периодичностью 1 сек. проверяет, 
// запущен ли процесс "spy", и если запущен, убивает его.
// =======================================================
namespace Ekzamen_task_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(tick);
            timer.Enabled = true;
            timer.Start();
        }

        private void tick(object Sender, EventArgs e)
        {
            string LogText = "";
            var FindProcess = Process.GetProcessesByName("calc");
            if (FindProcess.Length != 0)
            {
                Process pr = FindProcess[0];
                pr.CloseMainWindow();
                LogText = "Убийство spy \n";
            }
            else
            {
                LogText = "spy не найден \n";
            }  
                         
            this.labelLog.Text += LogText;
        }
    }
}
