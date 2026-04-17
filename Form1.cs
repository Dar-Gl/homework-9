using System;
using System.Drawing;
using System.Windows.Forms;

namespace DateHandling
{
    public class Form1 : Form
    {
        // Controls
        private Label lblFutureDate;
        private TextBox txtFutureDate;
        private Button btnCalculateDays;

        private Label lblBirthDate;
        private TextBox txtBirthDate;
        private Button btnCalculateAge;

        private Button btnExit;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form settings
            this.Text = "Date Handling";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(460, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Future Date Label
            lblFutureDate = new Label();
            lblFutureDate.Text = "Future date:";
            lblFutureDate.Location = new Point(35, 35);
            lblFutureDate.AutoSize = true;

            // Future Date TextBox
            txtFutureDate = new TextBox();
            txtFutureDate.Location = new Point(130, 32);
            txtFutureDate.Size = new Size(120, 23);

            // Calculate Days Button
            btnCalculateDays = new Button();
            btnCalculateDays.Text = "Calculate Due Days";
            btnCalculateDays.Location = new Point(270, 30);
            btnCalculateDays.Size = new Size(140, 30);
            btnCalculateDays.Click += btnCalculateDays_Click;

            // Birth Date Label
            lblBirthDate = new Label();
            lblBirthDate.Text = "Birth date:";
            lblBirthDate.Location = new Point(35, 85);
            lblBirthDate.AutoSize = true;

            // Birth Date TextBox
            txtBirthDate = new TextBox();
            txtBirthDate.Location = new Point(130, 82);
            txtBirthDate.Size = new Size(120, 23);

            // Calculate Age Button
            btnCalculateAge = new Button();
            btnCalculateAge.Text = "Calculate Age";
            btnCalculateAge.Location = new Point(270, 80);
            btnCalculateAge.Size = new Size(140, 30);
            btnCalculateAge.Click += btnCalculateAge_Click;

            // Exit Button
            btnExit = new Button();
            btnExit.Text = "E&xit";
            btnExit.Location = new Point(335, 130);
            btnExit.Size = new Size(75, 30);
            btnExit.Click += btnExit_Click;

            // Add controls to form
            this.Controls.Add(lblFutureDate);
            this.Controls.Add(txtFutureDate);
            this.Controls.Add(btnCalculateDays);
            this.Controls.Add(lblBirthDate);
            this.Controls.Add(txtBirthDate);
            this.Controls.Add(btnCalculateAge);
            this.Controls.Add(btnExit);
        }

        // Calculate Due Days
        private void btnCalculateDays_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Today;
            DateTime futureDate = Convert.ToDateTime(txtFutureDate.Text);

            TimeSpan timeRemaining = futureDate - currentDate;

            MessageBox.Show(
                "Current date: " + currentDate.ToShortDateString() + "\n" +
                "Future date: " + futureDate.ToShortDateString() + "\n" +
                "Days until due: " + timeRemaining.Days,
                "Due Days Calculation"
            );
        }

        // Calculate Age
        private void btnCalculateAge_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Today;
            DateTime birthDate = Convert.ToDateTime(txtBirthDate.Text);

            int age = currentDate.Year - birthDate.Year;

            if (currentDate < birthDate.AddYears(age))
            {
                age--;
            }

            MessageBox.Show(
                "Current date: " + currentDate.ToLongDateString() + "\n" +
                "Birth date: " + birthDate.ToLongDateString() + "\n" +
                "Age: " + age,
                "Age Calculation"
            );
        }

        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}