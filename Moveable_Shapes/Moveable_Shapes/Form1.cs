using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Moveable_Shapes
{
    public partial class Form1 : Form
    {
        private Panel inputPanel; // Declare the Panel control
        private string whichShape;

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
            string[] labels = { "x_Location", "y_Location", "Radius", "Color", "Filled" };
            whichShape = "Circle";
            ShowPopupWithInputFields(labels);

            Debug.WriteLine("Submitted inputs:");

        }

        //Rectangle button
        private void button3_Click(object sender, EventArgs e)
        {
            string[] labels = { "x_Location", "y_Location", "Color", "Filled", "Width", "Height" };
            whichShape = "Rectangle";
            ShowPopupWithInputFields(labels);
        }
        //Square button
        private void button2_Click(object sender, EventArgs e)
        {
            string[] labels = { "x_Location", "y_Location", "Color", "Filled", "Side" };
            whichShape = "Square";
            ShowPopupWithInputFields(labels);
        }
        /////////////////
        /// Create input fields for shapes
        private void ShowPopupWithInputFields(string[] labels)
        {
            // Create the pop-up form
            Form popupForm = new Form();
            popupForm.Text = "Input Form";
            popupForm.Size = new Size(700, 650);

            int topMargin = 20;

            Label textLabel = new Label()
            {
                Text = "You should fill inputs for creating shape! (every field is optional,they have default values)",
                Location = new Point(10, 15),
                Width = 610
            };
            popupForm.Controls.Add(textLabel);

            // Create input fields with labels
            for (int i = 0; i < labels.Length; i++)
            {
                Label label = new Label
                {
                    Text = labels[i],
                    Location = new Point(10, topMargin + ((i + 1) * 30)),
                    Width = 100
                };

                TextBox textBox = new TextBox
                {
                    Location = new Point(120, topMargin + ((i + 1) * 30)),
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
                Location = new Point(10, topMargin + labels.Length * 30 + 40),
                Width = 100,
                Height = 50
            };

            // Handle the submit button click event
            submitButton.Click += (sender, e) =>
            {
                string[] inputValues = new string[labels.Length];
                for (int i = 0; i < labels.Length; i++)
                {
                    TextBox textBox = (TextBox)popupForm.Controls["textBox" + i];

                    // create shape
                    if (textBox.Text.Equals(""))
                        inputValues[i] = "empty";
                    else
                        inputValues[i] = textBox.Text;
                }
                // Process the input values as needed


               // Shape createdShape = CreateShape(whichShape, inputValues);
              //  Debug.WriteLine(createdShape);

                popupForm.Close(); // Close the pop-up form when submission is complete
            };

            popupForm.Controls.Add(submitButton);

            popupForm.ShowDialog();
        }

    /*    private Shape CreateShape(string whichShape, string[] inputValues)
        {
            foreach (string inputValue in inputValues)
            {
                Debug.WriteLine(inputValue);
            }

            switch (whichShape)
            {
                case "Circle":
                    Circle circle = new Circle();
                    //setIfNotEmpty
                    circle.XLocation = int.Parse(inputValues[0]);

                    return circle;
                    break;
                case "Rectangle":
                    // Code to execute if expression matches value2
                    break;
                case "Square":
                    // Code to execute if expression matches value2
                    break;

                default:
                    Debug.WriteLine("Shape was not selected");
                    // return null;
                    break;
            }


        }

        private void setIfNotEmpty(string field , Shape shape) {
            
        }*/
        //
    }
}
