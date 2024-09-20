# TaskTracker

TaskTracker is a user-friendly time management tool for tracking tasks, recording time spent, and organizing projects efficiently.

## How to Use
1. Download the latest release from the [Releases](https://github.com/killer6oose/TaskTracker/releases) section of the GitHub repository.
2. Extract the downloaded zip file to a location on your local machine.
3. Double-click the Setup.exe file to start the installation
4. ??
5. profit!..or, something..

- You may choose to connect this application to a database of your choice. We've tested it with MySQL using remote and local databases (local install and local XAMPP tested on Windows 10/11)

## Features

- Track tasks and record time spent on a project
- Organize projects with ease
- User-friendly interface
- Saves all data to a .txt file in the %appdata% directory, or to a SQL database!
- - If a SQL connection is made then the "New" button will create a new table called "Projects" in the database of your choice and will start populating it with new projects/displaying them in the drop down!
- "Browse Projects" button on the Main Window will browse the file path of your .txt projects, or will open phpmyadmin for your database if one is connected

#### Main Window
![image](https://github.com/user-attachments/assets/b4ddd1ac-92da-4038-bf5f-1099f43c863b)

#### Help > Properties window
![image](https://github.com/user-attachments/assets/1a2944eb-bbd1-441c-a3e0-2bf3ff38826e)

## Future Plans
- Allow saving projects to BOTH a txt and database?
- Cleaner UI
- Better installation process

## Known Bugs
- Add SQL details and saving, after closing the window a new window pops up to add the DB details again
## License

This project is licensed under the GNU General Public License v3.0. See the [LICENSE](https://github.com/killer6oose/TaskTracker/blob/main/LICENSE) file for details.
