using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;

static void WorkWithDirectories()
{
    // define a directory path for a new folder starting in the user's folder
    string newFolder = Combine(CurrentDirectory,"NewFolder");

    WriteLine($"Working with: {newFolder}");

    // check if it exists
    WriteLine($"Does it exist? {Exists(newFolder)}");

    // create directory
    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)};");
    Write("Confirm the directory exists, and then press Enter: ");
    ReadLine();

    // delete directory
    WriteLine("Deleting it...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exist {Exists(newFolder)}");
}

WorkWithDirectories();  

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