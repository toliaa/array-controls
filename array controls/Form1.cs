using System;
using System.Linq;
using System.Windows.Forms;

namespace ArrayOperationsApp
{
    public partial class ArrayOperationsForm : Form
    {
        private Label arrayLabel;
        private TextBox textBoxArray;
        private Button calculateButton;
        private Label label1;
        private Label resultLabel;

        public ArrayOperationsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrayOperationsForm));
            this.arrayLabel = new System.Windows.Forms.Label();
            this.textBoxArray = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // arrayLabel
            // 
            this.arrayLabel.AutoSize = true;
            this.arrayLabel.Location = new System.Drawing.Point(12, 23);
            this.arrayLabel.Name = "arrayLabel";
            this.arrayLabel.Size = new System.Drawing.Size(272, 16);
            this.arrayLabel.TabIndex = 0;
            this.arrayLabel.Text = "Enter array elements (separated by comma):";
            this.arrayLabel.Click += new System.EventHandler(this.arrayLabel_Click);
            // 
            // textBoxArray
            // 
            this.textBoxArray.Location = new System.Drawing.Point(264, 20);
            this.textBoxArray.Name = "textBoxArray";
            this.textBoxArray.Size = new System.Drawing.Size(200, 22);
            this.textBoxArray.TabIndex = 1;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(301, 48);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(110, 23);
            this.calculateButton.TabIndex = 2;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(20, 80);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 16);
            this.resultLabel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "© 2024 Tolia Driapak";
            // 
            // ArrayOperationsForm
            // 
            this.ClientSize = new System.Drawing.Size(496, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arrayLabel);
            this.Controls.Add(this.textBoxArray);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resultLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArrayOperationsForm";
            this.Text = "One-dimensional Array - Calculation and Transformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the input array from the text box
                double[] array = textBoxArray.Text.Split(',').Select(double.Parse).ToArray();
                int n = array.Length;

                // Calculate the number of negative elements
                int negativeCount = array.Count(x => x < 0);

                // Find the minimum absolute value element
                double minAbsoluteValue = array.Select(Math.Abs).Min();

                // Calculate the sum of absolute values of elements after the minimum absolute value element
                int minIndex = Array.IndexOf(array, array.FirstOrDefault(x => Math.Abs(x) == minAbsoluteValue));
                double sumAfterMinAbsolute = array.Skip(minIndex + 1).Select(Math.Abs).Sum();

                // Replace negative elements with their squares and sort the array
                for (int i = 0; i < n; i++)
                {
                    if (array[i] < 0)
                    {
                        array[i] *= array[i];
                    }
                }
                Array.Sort(array);

                // Display the results on the screen
                resultLabel.Text = $"Number of negative elements: {negativeCount}\n" +
                                   $"Sum of absolute values of elements after the minimum absolute value element: {sumAfterMinAbsolute}\n" +
                                   $"Array after replacing negative elements with their squares and sorting in ascending order:\n" +
                                   string.Join(", ", array);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arrayLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
