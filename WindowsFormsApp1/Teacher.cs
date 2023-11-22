using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Teacher
    {
        public static void teacher()
        {
            int num = 0;
            while (true)
            {
                num++;

                Program.semFull.WaitOne();
                Thread.Sleep(Program.rand.Next(10) * 500);
                Program.cBuffer.Put(num);
                Program.mainForm.TeacherPostedAssignment(num);
                Program.semEmpty.Release();
                if (num > Program.size - 1)
                {
                    num = 0;
                }
            }
        }
    }
}
