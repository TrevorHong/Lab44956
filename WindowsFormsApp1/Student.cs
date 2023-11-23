using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Student
    {
        public static void student()
        {
            while (true) {
                Program.semEmpty.WaitOne();
                Thread.Sleep(Program.rand.Next(10) * 1000);
                int num = Program.cBuffer.Get();
                //Calls the StudentSolvedAssignment method in Form1.cs
                Program.mainForm.StudentSolvedAssignment(num);
                Program.semFull.Release();
            }
        }
    }
}
