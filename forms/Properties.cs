using MySql.Data.MySqlClient; // MySQL Library
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TaskTracker.Properties;

namespace TaskTracker.forms
{
    public partial class PropertiesWindow : Form
    {
        // Configuration Variables
        private string encryptionKey = "hxcrlYe6RIEX4Ep0MmiOqjHff955nSeR"; // Replace with a secure encryption key
        private string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TaskTracker", "dbConfig.txt");
        private MySqlConnection dbConnection;
        private MySqlConnection connection;
        private bool isConnected = false;
        public PropertiesWindow()
        {
            InitializeComponent();

            LoadConnectionDetails();
        }

        // Encrypt sensitive data
        private string Encrypt(string data, string key)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // Zero IV for simplicity, change if needed

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(dataBytes, 0, dataBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // Decrypt sensitive data
        private string Decrypt(string data, string key)
        {
            byte[] dataBytes = Convert.FromBase64String(data);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16]; // Zero IV for simplicity, change if needed

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream(dataBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        private void LoadConnectionDetails()
        {
            // Load saved details from application settings
            dbAddress.Text = Properties.Settings.Default.dbAddress;
            dbPort.Text = Properties.Settings.Default.dbPort;
            dbName.Text = Properties.Settings.Default.dbName;
            dbUser.Text = Properties.Settings.Default.dbUser;
            dbPassword.Text = Properties.Settings.Default.dbPassword;
        }

        // Test MySQL connection
        private void testDBConn_Click(object sender, EventArgs e)
        {
            // Build the connection string from the UI fields
            string connectionString = $"Server={dbAddress.Text};Port={dbPort.Text};Database={dbName.Text};User Id={dbUser.Text};Password={dbPassword.Text};";

            try
            {
                // Create a new MySQL connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connection successful!");
                }
            }
            catch (MySqlException ex)
            {
                // Show error message if connection fails
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }

        // Save database details securely
        private void dbDetailsSave_Click(object sender, EventArgs e)
        {
            // Save the database details to application settings
            Properties.Settings.Default.dbAddress = dbAddress.Text;
            Properties.Settings.Default.dbPort = dbPort.Text;
            Properties.Settings.Default.dbName = dbName.Text;
            Properties.Settings.Default.dbUser = dbUser.Text;
            Properties.Settings.Default.dbPassword = dbPassword.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("Database connection details saved successfully.");
        }


        // Connect to the database using saved details
        private void dbConnect_Click(object sender, EventArgs e)
        {
            string connectionString = BuildConnectionString();

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                isConnected = true;
                MessageBox.Show("Database connected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Run SQL script to initialize the database if needed
                InitializeDatabase();

                this.Close(); // Close the form after successful connection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildConnectionString()
        {
            return $"Server={dbAddress.Text};Port={dbPort.Text};Database={dbName.Text};User Id={dbUser.Text};Password={dbPassword.Text};";
        }

        private void InitializeDatabase()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                var commandText = @"
                --Drop the table if it already exists
                DROP TABLE IF EXISTS `PROJECTS`;
                CREATE TABLE `PROJECTS` (
                    `ID` int(10) NOT NULL AUTO_INCREMENT,
                    `UUID` varchar(36) NOT NULL,
                    `isActive` tinyint(1) NOT NULL DEFAULT 1,
                    `projName` varchar(100) NOT NULL,
                    `startDateTime` datetime NOT NULL,
                    `endDateTime` datetime DEFAULT NULL,
                    `Notes` varchar(1000) DEFAULT NULL,
                    PRIMARY KEY(`ID`),
                    UNIQUE KEY `UUID` (`UUID`)
                ) ENGINE = InnoDB DEFAULT CHARSET = latin1 COLLATE = latin1_swedish_ci;
                COMMIT;";

                if (MessageBox.Show("This will delete all data in the PROJECTS table. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (var command = new MySqlCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        // Function to create a new table in the MySQL database
        private void CreateNewTable(string tableName)
        {
            if (!File.Exists(configFilePath))
            {
                MessageBox.Show("Database details are not saved. Please configure and save the details first.");
                return;
            }

            // Read and decrypt the saved database details
            string encryptedData = File.ReadAllText(configFilePath);
            string decryptedData = Decrypt(encryptedData, encryptionKey);

            string[] dbDetails = decryptedData.Split(',');
            string connectionString = $"Server={dbDetails[2]};Port={dbDetails[3]};Database={dbDetails[4]};User Id={dbDetails[0]};Password={dbDetails[1]};";

            string createTableQuery = @"
                -- Table 1: Projects
                CREATE TABLE IF NOT EXISTS `Projects` (
                    `UUID` CHAR(32) NOT NULL,  -- 32-character UUID without dashes
                    `ProjectName` VARCHAR(100) NOT NULL UNIQUE,  -- Unique project name
                    `isActive` BOOLEAN NOT NULL DEFAULT 1,  -- Active status
                    PRIMARY KEY (`UUID`)
                ) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

                -- Table 2: ProjectEntries
                CREATE TABLE IF NOT EXISTS `ProjectEntries` (
                    `EntryID` INT(10) NOT NULL AUTO_INCREMENT,  -- Auto-incrementing entry ID
                    `UUID` CHAR(32) NOT NULL,  -- Entry's UUID (generated like project UUID)
                    `ParentLinkID` CHAR(32) NOT NULL,  -- Link to Projects UUID
                    `StartDateTime` DATETIME NOT NULL,  -- Start date and time
                    `EndDateTime` DATETIME DEFAULT NULL,  -- End date and time
                    `Notes` VARCHAR(1000) DEFAULT NULL,  -- Up to 1000 characters of notes
                    PRIMARY KEY (`EntryID`),
                    FOREIGN KEY (`ParentLinkID`) REFERENCES `Projects`(`UUID`)  -- Foreign key to Projects table
                ) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Table '{tableName}' created successfully.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error creating table: {ex.Message}");
            }
        }
        private string GenerateUUID()
        {
            return Guid.NewGuid().ToString("N");  // Generates a 32-character UUID without dashes
        }

        private void startWAMP_Click(object sender, EventArgs e)
        {
            try
            {
                // Construct the path to the .bat file
                string batchFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CTECH", "WAMP", "wamp.bat");

                // Ensure the batch file exists before trying to run it
                if (File.Exists(batchFilePath))
                {
                    // Create a new process to start the batch file
                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = batchFilePath,  // Set the batch file path
                        UseShellExecute = true,    // To run it as an external process
                        CreateNoWindow = true      // Optional: Whether to show the console window
                    };

                    // Start the process
                    Process.Start(processInfo);
                    MessageBox.Show("WAMP started successfully.");
                }
                else
                {
                    MessageBox.Show("WAMP batch file not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during process start
                MessageBox.Show($"An error occurred while starting WAMP: {ex.Message}");
            }
        }
    }
}
