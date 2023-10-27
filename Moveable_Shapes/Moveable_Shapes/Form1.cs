using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;

namespace Moveable_Shapes
{
    public partial class Form1 : Form
    {
        private Panel inputPanel; // Declare the Panel control
        private string whichShape;
        private static Shape currentShape;
        private static Circle currentCircle;
        private static Rectangle currentRectangle;
        private static Square currentSquare;

        private List<Shape> shapes;
        private static Shape selectedShape;

        public Form1()
        {
            InitializeComponent();
            inputPanel = new Panel();
            inputPanel.Location = new Point(10, 50); // Adjust the location as needed
            inputPanel.Size = new Size(400, 800); // Adjust the size as needed
            this.Controls.Add(inputPanel); // Add the Panel to the form

            shapes = new List<Shape>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Circle button
        private void button1_Click(object sender, EventArgs e)
        {
            string[] labels = { "x_Location", "y_Location", "Color", "Filled", "Radius" };
            whichShape = "Circle";
            ShowPopupWithInputFields(labels);


            if (currentShape != null && currentShape is Circle currentCircle)
            {
                // Set up the Pen and Brush for drawing the circle
                Pen customPen = new Pen(Color.FromName(currentShape.Color));
                Brush customBrush = new SolidBrush(Color.FromName(currentShape.Color));

                // Draw the panel
                using (Graphics g = panel1.CreateGraphics())
                {
                    // Draw the circle on top of the panel
                    currentCircle.DrawOrFillShape(customBrush,customPen , g);

                }

                // Dispose of the Pen and Brush to release resources
                customPen.Dispose();
                customBrush.Dispose();

                shapes.Add(currentCircle);
            }

        }

        //Rectangle button
        private void button3_Click(object sender, EventArgs e)
        {
            string[] labels = { "x_Location", "y_Location", "Color", "Filled", "Width", "Height" };
            whichShape = "Rectangle";
            ShowPopupWithInputFields(labels);
            if (currentShape != null && currentShape is Rectangle currentRectangle)
            {
                // Set up the Pen and Brush for drawing the circle
                Pen customPen = new Pen(Color.FromName(currentShape.Color));
                Brush customBrush = new SolidBrush(Color.FromName(currentShape.Color));

                // Draw the panel
                using (Graphics g = panel1.CreateGraphics())
                {
                    // Draw the circle on top of the panel
                    currentRectangle.DrawOrFillShape(customBrush, customPen, g);

                }

                // Dispose of the Pen and Brush to release resources
                customPen.Dispose();
                customBrush.Dispose();

                shapes.Add(currentRectangle);
            }
        }
        //Square button
        private void button2_Click(object sender, EventArgs e)
        {
            string[] labels = { "x_Location", "y_Location", "Color", "Filled", "Side" };
            whichShape = "Square";
            ShowPopupWithInputFields(labels);

            if (currentShape != null && currentShape is Square currentSquare)
            {
                // Set up the Pen and Brush for drawing the circle
                Pen customPen = new Pen(Color.FromName(currentShape.Color));
                Brush customBrush = new SolidBrush(Color.FromName(currentShape.Color));

                // Draw the panel
                using (Graphics g = panel1.CreateGraphics())
                {
                    // Draw the circle on top of the panel
                    currentSquare.DrawOrFillShape(customBrush, customPen, g);
                }

                // Dispose of the Pen and Brush to release resources
                customPen.Dispose();
                customBrush.Dispose();

                shapes.Add(currentSquare);
            }
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
                    if (!textBox.Text.Equals(""))
                        inputValues[i] = textBox.Text;
                }

                CreateShape(whichShape, inputValues);


                popupForm.Close(); // Close the pop-up form when submission is complete
            };

            popupForm.Controls.Add(submitButton);

            popupForm.ShowDialog();
        }

        private static void CreateShape(string whichShape, string[] inputValues)
        {
            foreach (string inputValue in inputValues)
            {
                Debug.WriteLine(inputValue);
            }


            switch (whichShape)
            {
                case "Circle":
                    CreateCircle(inputValues);

                    break;
                case "Rectangle":
                    CreateRectangle(inputValues);
                    break;
                case "Square":
                    CreateSquare(inputValues);
                    break;

                default:
                    Debug.WriteLine("Shape was not selected");
                    break;
            }


        }

        private static void CreateSquare(string[] inputValues)
        {
            Square square = new Square(int.Parse(inputValues[4]), inputValues[2], bool.Parse(inputValues[3]));
            square.XLocation = int.Parse(inputValues[0]);
            square.YLocation = int.Parse(inputValues[1]);


            currentShape = square;
            currentSquare = square;
        }

        private static void CreateRectangle(string[] inputValues)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.XLocation = int.Parse(inputValues[0]);
            rectangle.YLocation = int.Parse(inputValues[1]);
            rectangle.Color = inputValues[2];
            rectangle.IsFilled = bool.Parse(inputValues[3]);
            rectangle.Width = int.Parse(inputValues[4]);
            rectangle.Length = int.Parse(inputValues[5]);

            currentShape = rectangle;
            currentRectangle = rectangle;
        }

        private static void CreateCircle(string[] inputValues)
        {
            Circle circle = new Circle();
            circle.XLocation = int.Parse(inputValues[0]);
            circle.YLocation = int.Parse(inputValues[1]);
            circle.Color = inputValues[2];
            circle.IsFilled = bool.Parse(inputValues[3]);
            circle.Radius = int.Parse(inputValues[4]);

            currentShape = circle;
            currentCircle = circle;

        }
      ////////

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X; 
            int mouseY = e.Y;          

            foreach (Shape shape in shapes)
            {
                if (shape is Circle) 
                {
                        Circle circle = (Circle)shape;
                    if (mouseX >= circle.XLocation &&
                    mouseX <= circle.XLocation + circle.Radius &&
                    mouseY >= circle.YLocation &&
                    mouseY <= circle.YLocation + circle.Radius)
                    { 
                    selectedShape = circle;
                    }
                }
                else if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    if (mouseX >= rectangle.XLocation &&
                    mouseX <= rectangle.XLocation + rectangle.Width &&
                    mouseY >= rectangle.YLocation &&
                    mouseY <= rectangle.YLocation + rectangle.Length)
                    {
                        selectedShape = rectangle;
                    }
                }
               else  if (shape is Square)
                {
                    Rectangle square = (Rectangle)shape;
                    if (mouseX >= square.XLocation &&
                    mouseX <= square.XLocation + square.Width &&
                    mouseY >= square.YLocation &&
                    ngth)
                    {
                        selectedShape = square;
                    }
                }
            }

            
            Debug.WriteLine(selectedShape);
            label1.Text = "Shape Information: \n" + selectedShape;
        }

         protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Up) {
                Debug.WriteLine("Worksss");

                Pen customPen = new Pen(Color.FromName(currentShape.Color));
                 using (Graphics g = panel1.CreateGraphics())
                {
                    // Draw the circle on top of the panel
                    currentShape.DeleteShape(customBrush,customPen , g);

                }

                currentShape.YLocation -=10;

                shapes.Remove(currentShape);

            using (Graphics g = panel1.CreateGraphics())
                {
                    // Draw the circle on top of the panel
                    currentRectangle.DrawOrFillShape(customBrush, customPen, g);

                }


                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
         }
        ///////
      /*  private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (exists)
            {
                g.FillRectangle(eb, x, y, size, size);
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        x -= 5;
                        break;
                    case Keys.Right:
                        x += 5; ;
                        break;
                    case Keys.Up:
                        y -= 5; ;
                        break;
                    case Keys.Down:
                        y += 5;
                        break;
                }
                g.FillRectangle(sb, x, y, size, size);
            }
        }
*/
    }
}
