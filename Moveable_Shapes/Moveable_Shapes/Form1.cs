using System;
using System.Windows.Forms;

namespace Moveable_Shapes
{
    public partial class Form1 : Form
    {
        private Panel inputPanel; // Declare the Panel control

        public Form1()
        {
            InitializeComponent();
            inputPanel = new Panel();
            inputPanel.Location = new Point(10, 50); // Adjust the location as needed
            inputPanel.Size = new Size(400, 800); // Adjust the size as needed
            this.Controls.Add(inputPanel); // Add the Panel to the form
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Circle button
        private void button1_Click(object sender, EventArgs e)
        {
            string[] labels = { "x Location", "y Location", "Radius" };
            ShowPopupWithInputFields(labels);
        }

        //Rectangle button
        private void button3_Click(object sender, EventArgs e)
        {
            string[] labels = { "x Location", "y Location", "Width","Height" };
            ShowPopupWithInputFields(labels);
        }
        //Square button
        private void button2_Click(object sender, EventArgs e)
        {
            string[] labels = { "x Location", "y Location", "Width" };
            ShowPopupWithInputFields(labels);
        }
        /////////////////
        /// Create input fields for shapes
        private void ShowPopupWithInputFields(string[] labels)
        {
            // Create the pop-up form
            Form popupForm = new Form();
            popupForm.Text = "Input Form";
            popupForm.Size = new Size(500, 300);

            int topMargin = 10;

            // Create input fields with labels
            for (int i = 0; i < labels.Length; i++)
            {
                Label label = new Label
                {
                    Text = labels[i],
                    Location = new Point(10, topMargin + i * 30),
                    Width = 100
                };

                TextBox textBox = new TextBox
                {
                    Location = new Point(120, topMargin + i * 30),
                    Name = "textBox" + i,
                    Width = 200
                };

                popupForm.Controls.Add(label);
                popupForm.Controls.Add(textBox);
            }

            // Create a submit button
            Button submitButton = new Button
            {
                Text = "Submit",
                Location = new Point(10, topMargin + labels.Length * 30),
                Width = 100,
                Height = 50
            };

            // Handle the submit button click event
            submitButton.Click += (sender, e) =>
            {
                string[] inputValues = new string[labels.Length];
                for (int i = 0; i < labels.Length; i++)
                {
                    inputValues[i] = (popupForm.Controls["textBox" + i] as TextBox).Text;
                }
                // Process the input values as needed

                popupForm.Close(); // Close the pop-up form when submission is complete
            };

            popupForm.Controls.Add(submitButton);

            popupForm.ShowDialog();
        }

       
    }
}
