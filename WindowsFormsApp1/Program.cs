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

            semFull = new Semaphore(size, size);
            semEmpty = new Semaphore(0, size);
            cBuffer = new CircularBuffer<int>(size);

            Thread teacherThread = new Thread(Teacher.teacher);
            Thread studentThread = new Thread(Student.student);

            mainForm = new Form1();

            teacherThread.Start();
            studentThread.Start();

            Application.Run(mainForm);
        }
    }
}
