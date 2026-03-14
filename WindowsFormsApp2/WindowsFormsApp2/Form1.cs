using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Globalization;



namespace WindowsFormsApp2
{
    public partial class frmMain : Form
    {
        string formattedDate;
        string searchDate;
        string sourcePath;
        string destPath;
        string indexPath;
        string statementPath;
        string folderSource;
        string folderTarget;
        string fullIndexPath;
        string fullStatementPath;
        string folderYear;

        public frmMain()
        {
            InitializeComponent();
            changeAndReplace();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeAndReplace();

        }


        private void changeAndReplace()
            {
            try
            {
                //MessageBox.Show("OK");

                //Directory.Move("d:\\xx11", "d:\\yyy");
                //MessageBox.Show("OK");
                CultureInfo cultureInfo = CultureInfo.CurrentCulture;

                // Get the calendar associated with the current culture
                Calendar calendar = cultureInfo.DateTimeFormat.Calendar;

                // Display the calendar type
                Console.WriteLine($"Calendar type: {calendar.GetType().Name}");


                // If you need more details about the calendar, you can use different properties or methods
                // For example, if it's the Gregorian calendar:
                if (calendar is GregorianCalendar)
                {
                    //Console.WriteLine("Using the Gregorian Calendar.");
                    int currentYear = calendar.GetYear(DateTime.Now);
                    int thaiBuddhistYear = currentYear + 543;

                    String currentdate = DateTime.Now.ToString("yyMMDD");
                    DateTime sysDate = DateTime.Now;
                    formattedDate = sysDate.ToString("YYMMdd");
                    formattedDate = thaiBuddhistYear.ToString().Substring(2, 2) + formattedDate.Substring(2, 4);
                    destPath = formattedDate;
                    sourcePath = currentYear.ToString().Substring(2, 2) + formattedDate.Substring(2, 4);
                    folderYear = thaiBuddhistYear.ToString().Substring(2, 2);
                }
                else
                {
                    Console.WriteLine("Using a different calendar.");
                }

                //MessageBox.Show("OK");
                searchDate = formattedDate;
                // Get the application path
                string appPath = Application.StartupPath;

                string masterpath = "";
                string replacepath = "";

                //MessageBox.Show(appPath);
                Console.WriteLine(appPath);
                // Define the config file name
                string configFileName = "config.cfg";

                // Combine the app path with the config file name
                string configPath = Path.Combine(appPath, configFileName);

                // Check if the file exists
                if (File.Exists(configPath))
                {
                    // Read the content of the config file
                    string[] lines = File.ReadAllLines(configPath);


                    string[] tempstring = lines[0].Split('=');

                    //get statement path

                    statementPath = tempstring[1];
                    //MessageBox.Show(indexPath);

                    //get index path
                    tempstring = lines[1].Split('=');
                    indexPath = tempstring[1];

                    //MessageBox.Show(statementPath);

                    //get master path
                    tempstring = lines[2].Split('=');

                    masterpath = tempstring[1];
                    //MessageBox.Show(masterpath);

                    //get replace path
                    tempstring = lines[3].Split('=');

                    replacepath = tempstring[1];
                    //MessageBox.Show(replacepath);

                }
                else
                {
                    Console.WriteLine($"Config file not found: {configPath}");
                }

                //MessageBox.Show("OK");

                //rename folder and replace string of index file
                // ตรวจสอบว่าโฟลเดอร์ต้นทางมีอยู่หรือไม่
                //MessageBox.Show(indexPath + '\\' + sourcePath);
                if (Directory.Exists(indexPath + '\\' + sourcePath))
                {
                    // เปลี่ยนชื่อโฟลเดอร์
                    //MessageBox.Show("OK");
                    sourcePath = indexPath + '\\' + sourcePath;
                    destPath = indexPath + '\\' + destPath;
                    Directory.Move(sourcePath, destPath);
                    Console.WriteLine("โฟลเดอร์ถูกเปลี่ยนชื่อสำเร็จ!");
                }
                else
                {
                    Console.WriteLine("โฟลเดอร์ต้นทางไม่มีอยู่." + indexPath + '\\' + sourcePath);
                }

                // Find folder with sysdate format YYMMDD
                var folders = Directory.GetDirectories(indexPath, "*" + searchDate + "*");
                Console.WriteLine(indexPath+"\\"+ searchDate);
                if (!folders.Any())
                {
                    Console.WriteLine("No folders found for today's date.");
                    //return;
                }

                foreach (var folder in folders)
                {
                    // Get all files in the folder
                    var files = Directory.GetFiles(folder);

                    foreach (var file in files)
                    {
                        // Replace content in each file
                        string content = File.ReadAllText(file);
                        string updatedContent = content.Replace(masterpath, replacepath);

                        File.WriteAllText(file, updatedContent);
                    }
                }


                // ค้นหาโฟลเดอร์ที่ขึ้นต้นด้วย "DD"
                //fullStatementPath = statementPath;
                //D:\@Work\@Other Project\rename_folder_bat\OUTPUT\STATEMENT
                string[] subfolders = Directory.GetDirectories(statementPath + "\\" + folderYear);
                foreach (string folder in subfolders)
                {
                    // รับชื่อโฟลเดอร์
                    string folderName = Path.GetFileName(folder);

                    string[] subfolders1 = Directory.GetDirectories(statementPath + "\\" + folderYear + "\\" + folderName);
                    foreach (string folder1 in subfolders1)
                    {
                        // เปลี่ยนชื่อจาก "DD..." เป็น "xx..."
                        string folderName1 = Path.GetFileName(folder1);
                        if (folderName1.StartsWith("DD"))
                        {
                            if (folderName1.Equals("DD11"))
                            {
                                folderTarget = folderName1.Replace("DD11", "04");
                            }
                            if (folderName1.Equals("DD12"))
                            {
                                folderTarget = folderName1.Replace("DD12", "08");
                            }
                            if (folderName1.Equals("DD13"))
                            {
                                folderTarget = folderName1.Replace("DD13", "12");
                            }
                            if (folderName1.Equals("DD14"))
                            {
                                folderTarget = folderName1.Replace("DD14", "16");
                            }
                            if (folderName.Equals("DD15"))
                            {
                                folderTarget = folderName1.Replace("DD15", "20");
                            }
                            if (folderName1.Equals("DD16"))
                            {
                                folderTarget = folderName1.Replace("DD16", "24");
                            }
                            if (folderName1.Equals("DD17"))
                            {
                                folderTarget = folderName1.Replace("DD17", "28");
                            }
                            if (folderName1.Equals("DD18"))
                            {
                                folderTarget = folderName1.Replace("DD18", "01");
                            }

                            //MessageBox.Show(statementPath);
                            // DD11-DD18
                            string oriFolderPath = Path.Combine(statementPath + "\\" + folderYear + "\\" + folderName, folder1);
                            //convert to 01-28
                            string newFolderPath = Path.Combine(statementPath + "\\" + folderYear + "\\" + folderName, folderTarget);

                            Console.WriteLine(folderTarget + '|' + newFolderPath);
                            if (Directory.Exists(newFolderPath))
                            {
                                // เปลี่ยนชื่อโฟลเดอร์
                                Console.WriteLine("Dup");
                                // คัดลอกไฟล์ในโฟลเดอร์ต้นทาง
                                foreach (string file in Directory.GetFiles(oriFolderPath))
                                {
                                    string fileName = Path.GetFileName(file);
                                    string destFile = Path.Combine(newFolderPath, fileName);
                                    File.Copy(file, destFile, overwrite: true);
                                }

                                Directory.Delete(oriFolderPath);
                                // คัดลอกโฟลเดอร์ย่อยในโฟลเดอร์ต้นทาง
                                //foreach (string subDir in Directory.GetDirectories(oriFolderPath))
                                //{
                                //    string subDirName = Path.GetFileName(subDir);
                                //    string destSubDir = Path.Combine(newFolderPath, subDirName);
                                //    CopyFolderContents(subDir, destSubDir);
                                //}
                                //Directory.Move(folder, newFolderPath);
                            }
                            else
                            {
                                Console.WriteLine("โฟลเดอร์ต้นทางไม่มีอยู่. rename folder" + newFolderPath);
                                Directory.Move(folder, newFolderPath);
                                Console.WriteLine($"เปลี่ยนชื่อโฟลเดอร์ {folderName} เป็น {folderTarget}");
                                Console.WriteLine("โฟลเดอร์ถูกเปลี่ยนชื่อสำเร็จ!" + newFolderPath);
                            }
                        }
                    }
                }


                Console.WriteLine("Processing completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        /// <summary>
        /// คัดลอกข้อมูลจากโฟลเดอร์ต้นทางไปยังปลายทาง
        /// </summary>
        /// <param name="sourcePath">Path ของโฟลเดอร์ต้นทาง</param>
        /// <param name="destinationPath">Path ของโฟลเดอร์ปลายทาง</param>
        static void CopyFolderContents(string sourcePath, string destinationPath)
        {
            // สร้างโฟลเดอร์ปลายทางหากยังไม่มี
            Directory.CreateDirectory(destinationPath);

            // คัดลอกไฟล์ในโฟลเดอร์ต้นทาง
            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationPath, fileName);
                File.Copy(file, destFile, overwrite: true);
            }

            // คัดลอกโฟลเดอร์ย่อยในโฟลเดอร์ต้นทาง
            foreach (string subDir in Directory.GetDirectories(sourcePath))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destinationPath, subDirName);
                CopyFolderContents(subDir, destSubDir);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }

}
