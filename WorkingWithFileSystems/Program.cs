using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;



//static void WorkWithFiles()
//{
//    // define a directory path to output files 
//    string dir = Path.Combine(CurrentDirectory, "../../../NewFolder");

//    CreateDirectory(dir);

//    // define file paths
//    string textFile = Combine(dir, "Dummy.txt");
//    string backupfile = Combine(dir, "Dummy.bak");

//    // Check if a file exists
//    WriteLine($"Does it exist? {File.Exists (textFile)}");

//    // create a new text file and write a line to it
//    StreamWriter textWriter = File.CreateText(textFile);
//    textWriter.WriteLine("Hello, C#!");
//    textWriter.Close();

//    WriteLine($"Does it exist? {File.Exists(textFile)}");

//    // copy the file, and overwrite if it already exists
//    File.Copy(sourceFileName: textFile, destFileName: backupfile, overwrite: true);
//    WriteLine($"Does it exist? {File.Exists(backupfile)}");

//    // delete file
//    File.Delete(textFile);
//    WriteLine($"Does it exist? {File.Exists(textFile)}");

//    // read from the text file backup
//    WriteLine($"Reading contents of {backupfile}");
//    StreamReader textReader = File.OpenText(backupfile);
//    WriteLine(textReader.ReadToEnd());
//    textReader.Close();

//    // do NOT forget close textWrite and textReader
//}

//WorkWithFiles();


//static void WorkWithDirectories()
//{
//    // define a directory path for a new folder starting in the user's folder
//    string newFolder = Combine(CurrentDirectory,"NewFolder");

//    WriteLine($"Working with: {newFolder}");

//    // check if it exists
//    WriteLine($"Does it exist? {Exists(newFolder)}");

//    // create directory
//    WriteLine("Creating it...");
//    CreateDirectory(newFolder);
//    WriteLine($"Does it exist? {Exists(newFolder)};");
//    Write("Confirm the directory exists, and then press Enter: ");
//    ReadLine();

//    // delete directory
//    WriteLine("Deleting it...");
//    Delete(newFolder, recursive: true);
//    WriteLine($"Does it exist {Exists(newFolder)}");
//}

//WorkWithDirectories();  

//static void WorkWithDrives()
//{
//    WriteLine("{0, -30} | {1, -10} | {2, -7} | {3,18} | {4, 18}",
//        "NAME", "TYPE", "FORMAT", "SIZE(BYTE)", "FREE SPACE");

//    foreach (DriveInfo drive in DriveInfo.GetDrives())
//    {
//        if (drive.IsReady)
//        {
//            WriteLine("{0, -30} | {1, -10} | {2, -7} | {3,18:N0} | {4, 18:N0}",
//                    drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
//        }
//        else
//        {
//            WriteLine("{0, -30} | {1, -10}", drive.Name, drive.DriveType);
//        }
//    }
//}

//WorkWithDrives();

//static void OutputFileSystemInfo()
//{
//    WriteLine("{0,-33}{1}", arg0: "Path.PathSeparator", arg1: PathSeparator);
//    WriteLine("{0,-33}{1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
//    WriteLine("{0,-33}{1}", arg0: "Directory.GetCurrentDirectory", arg1: Directory.GetCurrentDirectory);
//    WriteLine("{0,-33}{1}", arg0: "Environment.CurrentDirectory", arg1: Environment.CurrentDirectory);    
//    WriteLine("{0,-33}{1}", arg0: "Environment.SystemDirectory", arg1: Environment.SystemDirectory);
//    WriteLine("{0,-33}{1}", arg0: "Path.GetTempPath()", arg1: Path.GetTempPath());

//    WriteLine("GetFolderPath(SpecialFolder)");

//    WriteLine("{0,-33}{1}", arg0: " .System", arg1: GetFolderPath(SpecialFolder.System));
//    WriteLine("{0,-33}{1}", arg0: " .ApplicationData", arg1: GetFolderPath(SpecialFolder.ApplicationData));
//    WriteLine("{0,-33}{1}", arg0: " .MyDocuments", arg1: GetFolderPath(SpecialFolder.MyDocuments));
//    WriteLine("{0,-33}{1}", arg0: " .Personal", arg1: GetFolderPath(SpecialFolder.Personal));
//}

//OutputFileSystemInfo();