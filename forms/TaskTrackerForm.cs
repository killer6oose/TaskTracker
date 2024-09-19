using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TaskTracker.forms; 

namespace TaskTracker
{
    public partial class TaskTrackerForm : Form
    {
        //projects folder path
        private readonly string ProjectsFolderPath;

        // Bring to the front every hour
        private readonly Timer HourlyTimer;

        private bool isDatabaseConnected = false;
        private MySqlConnection dbConnection = null;

        // Declare timeZoneInfo variable at the class level
        private TimeZoneInfo TimeZoneInfo;

        //timer
        private readonly Timer timer;

        private DateTime StartTime;
        private bool IsTimerRunning;
        private string SelectedFilePath;

        public TaskTrackerForm()
        {
            InitializeComponent();

            // Set the projects folder path
            ProjectsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".TrackYourTasks");

            // Ensure Projects folder exists
            if (!Directory.Exists(ProjectsFolderPath))
            {
                Directory.CreateDirectory(ProjectsFolderPath);
            }

            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;

            // Populate dropdown with project files
            LoadProjectFiles();

            // Initialize the hourly timer
            HourlyTimer = new Timer
            {
                Interval = (int)TimeSpan.FromHours(1).TotalMilliseconds // 1 hour interval
            };
            HourlyTimer.Tick += HourlyTimer_Tick;
            HourlyTimer.Start(); // Start the timer

            // Populate the ComboBox with system time zones
            foreach (TimeZoneInfo timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                Timezones.Items.Add(timezone.DisplayName);
            }

            // Set default timezone to US Eastern Standard Time
            TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

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
            IsTimerRunning = false;
        }
        public void SetDatabaseConnection(MySqlConnection connection)
        {
            dbConnection = connection;
            isDatabaseConnected = true;
        }
        private void LoadDatabaseProjects()
        {
            if (isDatabaseConnected && dbConnection != null)
            {
                try
                {
                    // Clear existing items
                    ProjectDropdown.Items.Clear();

                    // Query to get active projects (tables)
                    string query = "SHOW TABLES;";
                    using (var command = new MySqlCommand(query, dbConnection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);

                            // Check if the table has the isActive column set to true
                            string checkActiveQuery = $"SELECT COUNT(*) FROM {tableName} WHERE isActive = 1;";
                            using (var checkCommand = new MySqlCommand(checkActiveQuery, dbConnection))
                            {
                                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                                if (count > 0)
                                {
                                    ProjectDropdown.Items.Add(tableName);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Fallback to file-based projects if no database connection
                LoadProjectFiles();
            }
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
            string SelectedTimezone = Timezones.SelectedItem.ToString();
            TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(SelectedTimezone);
        }

        private void PrjSelectBrowseBtn_Click(object sender, EventArgs e)
        {
        }

        private void TimeZoneField_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedFilePath))
            {
                MessageBox.Show("Please select a file or create a new project first.");
                return;
            }

            if (IsTimerRunning)
            {
                // End the timer
                timer.Stop();
                IsTimerRunning = false;

                // Calculate the elapsed time
                TimeSpan elapsedTime = DateTime.Now - StartTime;

                // Calculate the total minutes rounded to the nearest quarter hour
                int totalMinutes = (int)Math.Round(elapsedTime.TotalMinutes / 15.0) * 15;

                // Convert total minutes to hours and minutes
                int hours = totalMinutes / 60;
                int minutes = totalMinutes % 60;

                // Output the elapsed time to the selected file
                using (StreamWriter writer = new StreamWriter(SelectedFilePath, true))
                {
                    writer.WriteLine($"Start Time: {StartTime}");
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
                StartTime = DateTime.Now;
                timer.Start();
                IsTimerRunning = true;
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
            if (IsTimerRunning)
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
        private void LoadProjectsIntoDropdown()
        {
            string connectionString = BuildConnectionString();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT projName FROM PROJECTS";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            ProjectDropdown.Items.Clear();
                            while (reader.Read())
                            {
                                string projectName = reader.GetString("projName");
                                ProjectDropdown.Items.Add(projectName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    SelectedFilePath = selectedProjectFile;
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
        private string GenerateUUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private string BuildConnectionString()
        {
            // Assuming you have a method to build the connection string
            return $"Server={Properties.Settings.Default.dbAddress};Port={Properties.Settings.Default.dbPort};Database={Properties.Settings.Default.dbName};User Id={Properties.Settings.Default.dbUser};Password={Properties.Settings.Default.dbPassword};";
        }
        private void NewPrj_Click(object sender, EventArgs e)
        {
            // Get the project name from a textbox or input field
            string projectName = Microsoft.VisualBasic.Interaction.InputBox("Enter the project name:", "New Project", "");

            if (string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Please enter a project name.");
                return;
            }

            string connectionString = BuildConnectionString();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO PROJECTS (UUID, projName) VALUES (@UUID, @projName)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UUID", Guid.NewGuid().ToString());
                        command.Parameters.AddWithValue("@projName", projectName);

                        command.ExecuteNonQuery();
                        MessageBox.Show("New project created successfully!");
                    }
                }

                // Refresh the dropdown to show new project
                LoadProjectsIntoDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create new project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProjectsDropdown()
        {
            string connectionString = BuildConnectionString();

            string query = "SELECT ProjectName FROM Projects WHERE isActive = 1;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Populate the dropdown (assuming you have a ComboBox named 'projectsDropdown')
                        ProjectDropdown.Items.Add(reader["ProjectName"].ToString());
                    }
                }
            }
        }

        private void CreateNewProject(string projectName)
        {
            string connectionString = BuildConnectionString();

            // Check if the project already exists
            string checkQuery = "SELECT COUNT(*) FROM Projects WHERE ProjectName = @ProjectName;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@ProjectName", projectName);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("A project with this name already exists. Please choose a different name.");
                    return;
                }

                // Create a new project if it doesn't exist
                string uuid = GenerateUUID();
                string insertQuery = "INSERT INTO Projects (UUID, ProjectName, isActive) VALUES (@UUID, @ProjectName, 1);";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@UUID", uuid);
                insertCmd.Parameters.AddWithValue("@ProjectName", projectName);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("New project created successfully.");
            }
        }

        private void AdditionalNotesLabel_Click(object sender, EventArgs e)
        {
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display information in a popup
            MessageBox.Show("Author Name: Andrew Hatton\nVersion: 1.2.0",
                            "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the URL in the default web browser
            Process.Start("https://github.com/killer6oose/TaskTracker");
        }

        private void BrowseProjectTextFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if there is a saved DB connection
            if (!string.IsNullOrEmpty(Properties.Settings.Default.dbAddress))
            {
                // If a DB connection exists, open phpMyAdmin in the default browser
                string dbAddress = Properties.Settings.Default.dbAddress;

                // Build the URL to phpMyAdmin (assuming it's hosted on dbAddress)
                string phpMyAdminUrl = $"http://{dbAddress}/phpmyadmin";

                try
                {
                    // Open phpMyAdmin in the default web browser
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = phpMyAdminUrl,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to open phpMyAdmin: {ex.Message}");
                }
            }
            else
            {
                // No DB connection saved, continue to open the local text files folder
                try
                {
                    Process.Start("explorer.exe", ProjectsFolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to open folder: {ex.Message}");
                }
            }
        }


        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fully qualify the PropertiesWindow form to avoid namespace collision
            var propertiesForm = new TaskTracker.forms.PropertiesWindow();

            // Show the properties form modally (blocking until it is closed)
            propertiesForm.ShowDialog(); // or .Show() for non-modal behavior
        }

    }
}