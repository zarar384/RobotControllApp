using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace ComputerToArduino
{

    public partial class Form1 : Form

    {
        bool isUp = false;
        bool isConnected = false;
        String[] ports;
        SerialPort port;



        public Form1()
        {
            InitializeComponent();
            disableControls();
            getAvailableComPorts();
            MessageBox.Show("Welcome!");
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();

            }
            else
            {
                disconnectFromArduino();
            }

        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {

            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 1000000, Parity.None, 8, StopBits.One);
            port.Open();

            button1.Text = "STOP";
            enableControls();
            button1.BackColor = Color.Red;
            label1.Text = ("Welcome!");
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Write("#STOP\n");
            port.Close();
            button1.Text = "START";
            disableControls();
            button1.BackColor = Color.Lime;
            label1.Text = ("");
        }

        private void enableControls()
        {
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
        }

        private void disableControls()
        {
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED6ON\n");

            }
            else
            {
                port.Write("#LED6OF\n");
            }
            label1.Text = ("Move left");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED3ON\n");
            }
            else
            {
                port.Write("#LED3OF\n");
            }
            label1.Text = ("Forward movement");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED4ON\n");
            }
            else
            {
                port.Write("#LED4OF\n");
            }
            label1.Text = ("Downward movement");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED7ON\n");
            }
            else
            {
                port.Write("#LED7OF\n");
            }
            label1.Text = ("Move to the right");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = ("Draw a circle");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED1ON\n");

            }

            else
            {
                port.Write("#LED1OF\n");
            }
            label1.Text = ("Draw a square");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED2ON\n");

            }
            else
            {
                port.Write("#LED2OF\n");
            }
            label1.Text = ("Draw a triangle");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED5ON\n");

            }
            else
            {
                port.Write("#LED5OF\n");
            }
            label1.Text = ("Stop");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED8ON\n");

            }
            else
            {
                port.Write("#LED8OF\n");
            }
            label1.Text = ("Left diagonal down");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LEDAON\n");

            }
            else
            {
                port.Write("#LEDAOF\n");
            }
            label1.Text = ("Right diagonal up");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED9ON\n");

            }
            else
            {
                port.Write("#LED9OF\n");
            }
            label1.Text = ("Right diagonal down");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LEDBON\n");

            }
            else
            {
                port.Write("#LEDBOF\n");
            }
            label1.Text = ("Left diagonal up");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!isUp)
            {
                toUp();

                port.Write("#LEDCON\n");

            }
            else
            {
                toDown();
                port.Write("#LEDDON\n");
            }
        }
        private void toUp()
        {
            isUp = true;
            button15.BackgroundImage = new Bitmap(@"..\12.png");
            label1.Text = ("Down the pen");

        }
        private void toDown()
        {
            isUp = false;
            button15.BackgroundImage = new Bitmap(@"C:\Users\user\Desktop\3k\Morozov\program\ass\11.png");
            label1.Text = ("Up the pen");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = ("Draw a rectangle");
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space)
            {
                MessageBox.Show("Easter egg");
            }
        }

    }
}
