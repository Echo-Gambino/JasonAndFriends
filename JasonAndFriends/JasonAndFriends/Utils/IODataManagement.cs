namespace JasonAndFriends.Utils
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class IODataManagement
    {
        public const string FOLDER_NAME = "Data";

        public const string BACKUP_PATH = @"C:\ProgramData\JasonAndFriends";

        /// <summary>
        /// Loads information to main memory from the file 
        /// that has the same name as <paramref name="filename"/>.
        /// </summary>
        /// <param name="filename">The name of the file that is going to be read</param>
        /// <returns>A string (empty or non-empty) on success, null on failure</returns>
        public static string LoadFromFile(string filename)
        {
            // Attempt to access the designated save directory
            string dataDir = TryAccessSaveDir();
            // If the given save directory is null, return null
            if (dataDir == null) return null;

            // Generate the path to the saveFile ( {dataDir}\filename )
            string saveFile = string.Format("{0}\\{1}", dataDir, filename);
            // IF the file doesn't already exist, return null
            if (!File.Exists(saveFile)) return null;

            // Attempts to get the output of File.ReadAllText, 
            // (non-empty if on success, null on failure)
            string output;
            try
            {
                output = File.ReadAllText(saveFile);
            }
            catch (Exception ex)
            {
                GenGenericErrorMsg(ex);

                output = null;
            }

            return output;
        }

        /// <summary>
        /// Saves <paramref name="data"/> into a file with the same name of <paramref name="filename"/>
        /// </summary>
        /// <param name="filename">The name of the file that is going to be read</param>
        /// <param name="data">The data that will be written into the file</param>
        /// <returns>true on success, false on failure</returns>
        public static bool SaveToFile(string filename, string data)
        {
            // Attempt to access the designated save directory
            string dataDir = TryAccessSaveDir();
            // If the given save directory is null, return false
            if (dataDir == null) return false;

            // Generate the path to the saveFile ( {dataDir}\filename )
            string saveFile = string.Format("{0}\\{1}", dataDir, filename);

            // Attempts to write the data input the saveFile by File.WriteAllText()
            // (true on success, false on failure)
            try
            {
                File.WriteAllText(saveFile, data);
            }
            catch (Exception ex)
            {
                GenGenericErrorMsg(ex);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Attempt to access the save directory to help determine
        /// the save file that will be read from or written on.
        /// </summary>
        /// <returns>The file path to locate the save directory, null on failure</returns>
        private static string TryAccessSaveDir()
        {
            string dataDir;
            while (true)
            {
                string curDir = Directory.GetCurrentDirectory();
                try
                {
                    dataDir = CheckAndGetDataDir(curDir);
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Typical exception that can be caused by the OS (Windows) 
                    // not allowing any files to be read/written within the installed directory.
                    // So, we must set up a new working directory that has a higher chance of allowing
                    // the program to store and read data.

                    if (curDir == BACKUP_PATH)
                    {
                        throw new TaskCanceledException("Backup directory failed to grant access.");
                    }

                    Directory.CreateDirectory(BACKUP_PATH);

                    Directory.SetCurrentDirectory(BACKUP_PATH);

                    // Have the program reattempt the directory access after it has finished setting up a new directory
                    continue;
                }
                catch (Exception ex)
                {
                    GenGenericErrorMsg(ex);

                    return null;
                }

                break;
            }

            return dataDir;
        }

        /// <summary>
        /// Gets the working directory, adds a set folder name on it, 
        /// creates the folder if it doesn't exist, and returns the path to that folder
        /// </summary>
        /// <param name="workingDir">The working directory where the save directory is located</param>
        /// <returns>The path to the save directory (which is within the given working directory)</returns>
        private static string CheckAndGetDataDir(string workingDir)
        {
            string dataDir;

            dataDir = string.Format("{0}\\{1}", workingDir, FOLDER_NAME);

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            return dataDir;
        }

        /// <summary>
        /// Helper method to generate a generic error message to help with debugging.
        /// </summary>
        /// <param name="ex"></param>
        private static void GenGenericErrorMsg(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            string output = string.Format(
                "{0}\n\n{1}\n\n{2}",
                ex.GetType().ToString(),    // Get the exception Type
                ex.Message,                 // Get the exception Message
                ex.StackTrace               // Get the exception StackTrace
                );

            string title = string.Format("{0} Error!", ex.Source);

            MessageBox.Show(output, title);
        }

    }
}
