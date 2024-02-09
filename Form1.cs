using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace TaskTracker
{
    public partial class Form1 : Form
    {
        //projects folder path
        private readonly string ProjectsFolderPath;

        // Bring to the front every hour
        private readonly Timer hourlyTimer;

        // Declare timeZoneInfo variable at the class level
        private TimeZoneInfo timeZoneInfo;

        //timer
        private readonly Timer timer;
        private DateTime startTime;
        private bool isTimerRunning;
        private string selectedFilePath;


        public Form1()
        {
            InitializeComponent();

            // Set the projects folder path
            ProjectsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".TrackYoShtuff");

            // Ensure Projects folder exists
            if (!Directory.Exists(ProjectsFolderPath))
            {
                Directory.CreateDirectory(ProjectsFolderPath);
            }

            // Populate dropdown with project files
            LoadProjectFiles();

            // Initialize the hourly timer
            hourlyTimer = new Timer
            {
                Interval = (int)TimeSpan.FromHours(1).TotalMilliseconds // 1 hour interval
            };
            hourlyTimer.Tick += HourlyTimer_Tick;
            hourlyTimer.Start(); // Start the timer

            // Populate the ComboBox with system time zones
            foreach (TimeZoneInfo timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                Timezones.Items.Add(timezone.DisplayName);
            }

            // Set default timezone to US Eastern Standard Time
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            // Set the default text of the button to "START TIMER"
            StartTimer.Text = "START TIMER";
            // Disable the start button by default
            StartTimer.Enabled = false;
            // Initialize the timer
            timer = new Timer
            {
                Interval = 1000 // 1 second
            };
            timer.Tick += Timer_Tick;
            isTimerRunning = false;
        }
        private void LoadProjectFiles()
        {
            // Clear existing items
            ProjectDropdown.Items.Clear();

            // Get all .txt files in the Projects folder
            string[] projectFiles = Directory.GetFiles(ProjectsFolderPath, "*.txt");

            // Add project file names to dropdown
            foreach (string projectFile in projectFiles)
            {
                ProjectDropdown.Items.Add(Path.GetFileName(projectFile));
            }
        }

        private void HourlyTimer_Tick(object sender, EventArgs e)
        {
            // Check if the current hour is the desired hour (e.g., 12:00 PM)
            if (DateTime.Now.Hour == 12) // Adjust to the desired hour
            {
                // Bring the form to the topmost view
                this.TopMost = true;
                this.TopMost = false;
            }
        }
        private void Timezones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the timezone information based on the selected item in the ComboBox
            string selectedTimezone = Timezones.SelectedItem.ToString();
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(selectedTimezone);
        }

        private void PrjSelectBrowseBtn_Click(object sender, EventArgs e)
        {

        }

        private void TimeZoneField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a file or create a new project first.");
                return;
            }

            if (isTimerRunning)
            {
                // End the timer
                timer.Stop();
                isTimerRunning = false;

                // Calculate the elapsed time
                TimeSpan elapsedTime = DateTime.Now - startTime;

                // Calculate the total minutes rounded to the nearest quarter hour
                int totalMinutes = (int)Math.Round(elapsedTime.TotalMinutes / 15.0) * 15;

                // Convert total minutes to hours and minutes
                int hours = totalMinutes / 60;
                int minutes = totalMinutes % 60;

                // Output the elapsed time to the selected file
                using (StreamWriter writer = new StreamWriter(selectedFilePath, true))
                {
                    writer.WriteLine($"Start Time: {startTime}");
                    writer.WriteLine($"End Time: {DateTime.Now}");
                    writer.WriteLine($"Elapsed Time: {hours} hours and {minutes} minutes");

                    // Append notes from the Records field
                    if (!string.IsNullOrWhiteSpace(Records.Text))
                    {
                        writer.WriteLine($"Notes: {Records.Text}");
                    }

                    writer.WriteLine(new string('_', 50)); // Separator line
                }

                // Clear the Records field after appending notes to the file
                Records.Clear();
            }
            else
            {
                // Start the timer
                startTime = DateTime.Now;
                timer.Start();
                isTimerRunning = true;
            }

            // Update the button text
            UpdateButtonText();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the button text while the timer is running
            UpdateButtonText();
        }

        private void UpdateButtonText()
        {
            // Update the button text based on the timer state
            if (isTimerRunning)
            {
                StartTimer.Text = "End Timer";
            }
            else
            {
                StartTimer.Text = "Start Timer";
            }
        }

        private void FilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProjectDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProjectDropdown.SelectedItem != null)
            {
                // Enable the "Start Timer" button when a project is selected
                StartTimer.Enabled = true;

                // Load selected project file into text editor
                string selectedProjectFile = Path.Combine(ProjectsFolderPath, ProjectDropdown.SelectedItem.ToString());

                if (File.Exists(selectedProjectFile))
                {
                    Records.Text = File.ReadAllText(selectedProjectFile);

                    // Set the selected file path
                    selectedFilePath = selectedProjectFile;
                }
                else
                {
                    Records.Text = ""; // Clear text box if file doesn't exist
                }
            }
            else
            {
                // Disable the "Start Timer" button if no project is selected
                StartTimer.Enabled = false;

                // Clear text box
                Records.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewPrj_Click(object sender, EventArgs e)
        {
            // Prompt the user for the project name
            string projectName = Microsoft.VisualBasic.Interaction.InputBox("Enter the project name:", "New Project", "");

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                // Generate a new project file name
                string newProjectFileName = Path.Combine(ProjectsFolderPath, $"{projectName}_{DateTime.Now:yyyyMMdd}.txt");

                // Create the new project file
                File.WriteAllText(newProjectFileName, "");

                // Add the new project file to the dropdown
                ProjectDropdown.Items.Add(Path.GetFileName(newProjectFileName));

                // Select the new project file in the dropdown
                ProjectDropdown.SelectedItem = Path.GetFileName(newProjectFileName);

                // Set the selected file path
                selectedFilePath = newProjectFileName;
            }
        }

        private void AdditionalNotesLabel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display information in a popup
            MessageBox.Show("Author Name: Andrew Hatton\nVersion: 1.0.0\nWebsite: https://github.com/killer6oose/TaskTracker",
                            "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the URL in the default web browser
            Process.Start("https://github.com/killer6oose/TaskTracker");
        }
    }
}