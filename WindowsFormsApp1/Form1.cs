﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.semFull = new Semaphore(Program.size, Program.size);
            Program.semEmpty = new Semaphore(0, Program.size);
            Program.cBuffer = new CircularBuffer<int>(Program.size);
            Thread teacherThread = new Thread(Teacher.teacher);
            Thread studentThread = new Thread(Student.student);
            teacherThread.Start();
            studentThread.Start();
        }

        //Used to update the text box, since it is on a different thread it requires the invoke method because
        //otherwise it will throw an exception when the the non-UI thread tries to access it
        private void UpdateTextBox(string message)
        {
            if (InvokeRequired) {
                Invoke(new Action<string>(UpdateTextBox), message);
            }
            else {
                listBox1.Items.Add(message + Environment.NewLine);
            }
        }

        public void StudentSolvedAssignment(int num)
        {
            UpdateTextBox("Student solved assignment " + num);
        }

        public void TeacherPostedAssignment(int num)
        {
            UpdateTextBox("Teacher posted assignment " + num);
        }
    }

}
