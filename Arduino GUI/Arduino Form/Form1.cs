using System.IO.Ports; // Add this line at the top of your file
using System.Windows.Forms;

namespace Arduino_Form
{
    public partial class Form1 : Form
    {
        SerialPort serialPort = new SerialPort("COM3", 9600); // Adjust COM port as needed

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            serialPort.Open(); // Make sure to handle exceptions if the port cannot be opened
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load event logic here
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
                // Change the seconds to 0 to stop the Arduino from blinking
                serialPort.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                string seconds = ChangeDelayTextbox.Text; // This is now interpreted directly as seconds
                serialPort.WriteLine(seconds);
            }
        }



    }
}