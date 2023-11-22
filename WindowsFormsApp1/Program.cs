using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static Semaphore semFull;
        public static Semaphore semEmpty;
        public static int size = 20;
        public static CircularBuffer<int> cBuffer;
        public static Random rand = new Random();
        public static Form1 mainForm;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize synchronization components
            Program.semFull = new Semaphore(Program.size, Program.size);
            Program.semEmpty = new Semaphore(0, Program.size);
            Program.cBuffer = new CircularBuffer<int>(Program.size);

            Thread teacherThread = new Thread(Teacher.teacher);
            Thread studentThread = new Thread(Student.student);

            Program.mainForm = new Form1();

            teacherThread.Start();
            studentThread.Start();

            Application.Run(Program.mainForm);
        }
    }
}
