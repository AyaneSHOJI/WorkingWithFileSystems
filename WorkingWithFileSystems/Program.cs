using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;
using System.Xml;
using System.IO.Compression;
using System.Text;


WriteLine("Encondings \n[1] ASCII \n[2] UTF-7 \n[3] UTF-8 \n[4] UTF-16(Unicode) \n[5] UTF-32 \n[any other key] Default");

// choose an encoding
Write("Press a number to choose an encoding: ");
ConsoleKey number = ReadKey(intercept: false).Key;
// ReadKey Summary:
//     Obtains the next character or function key pressed by the user. The pressed key
//     is optionally displayed in the console window.
//
// Parameters:
//   intercept:
//     Determines whether to display the pressed key in the console window. true to
//     not display the pressed key; otherwise, false.
//
// Returns:
//     An object that describes the System.ConsoleKey constant and Unicode character,
//     if any, that correspond to the pressed console key. The System.ConsoleKeyInfo
//     object also describes, in a bitwise combination of System.ConsoleModifiers values,
//     whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously
//     with the console key.
//
WriteLine();
WriteLine();


Encoding encoder = number switch
{
ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
ConsoleKey.D2 or ConsoleKey.NumPad2 => Encoding.UTF7,
ConsoleKey.D3 or ConsoleKey.NumPad3 => Encoding.UTF8,
ConsoleKey.D4 or ConsoleKey.NumPad4 => Encoding.Unicode,
ConsoleKey.D5 or ConsoleKey.NumPad5 => Encoding.UTF32,
_ => Encoding.Default
};

// define a string to encode
string message = "Café cost : £4.39";

//encode the string into a byte array
byte[] encoded = encoder.GetBytes(message);

// check how many bytes the coding needed
WriteLine("{0} uses {1:N0} bytes.", encoder.GetType().Name, encoded.Length);
WriteLine();

// enumerate each byte
WriteLine($" BYTE HEX CHAR");
foreach (byte b in encoded)
{
WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,4}");
}

// decode the byte array back into a string and display it
string decoded = encoder.GetString(encoded);
WriteLine(decoded);



static void WorkWithCompression()
{
string fileExt = "gzip";
// compress the XML output
string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");

FileStream file = File.Create(filePath);

Stream compressor = new GZipStream(file, CompressionMode.Compress);

using (compressor)
{
using (XmlWriter xml = XmlWriter.Create(compressor))
{
xml.WriteStartDocument();
xml.WriteStartElement("callsigns");

foreach (string item in Viper.Callsigns)
{
xml.WriteElementString("callsign", item);
}

// the normal call to WriteEndElement is not necessary 
}
}

// output all the contents of the compressed file
WriteLine("{0} contains {1:N0} bytes",
        arg0: filePath,
        arg1: new FileInfo(filePath).Length);

WriteLine($"The compressed contents : {File.ReadAllText(filePath)}");

WriteLine("Reading the compressed XML file:");
file = File.Open(filePath, FileMode.Open);

Stream decompressor = new GZipStream((Stream)file, CompressionMode.Decompress);
using (decompressor)
{
using (XmlReader reader = XmlReader.Create(decompressor))
{
while (reader.Read())
{
// check if we are on an element node named callsign
if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
{
reader.Read();
WriteLine($"{reader.Value}");
}
}
}
}
}

// Comparaison result : file 322 bytes, compressed file 150 bytes

// XML is a software- and hardware-independent tool for storing and transporting data.
static void WorkWithXml()
{

FileStream? xmlfileStream = null;
XmlWriter? xml = null;

try
{
// define a file to write to
string xmlFile = Combine(CurrentDirectory, "streams.xml");

// create a file strem
xmlfileStream = File.Create(xmlFile);

// wrap the file stream in an XML writer helper and automatically indent nested elements
xml = XmlWriter.Create(xmlfileStream, new XmlWriterSettings() { Indent = true });

// write the XML declaratoin
xml.WriteStartDocument();

// write a root element
xml.WriteStartElement("callsigns");

// enumerate the string writing each one to the stream
foreach (string item in Viper.Callsigns)
{
xml.WriteElementString("callsign", item);
}

// write the close root element
xml.WriteEndElement();

// close helper and stream
xml.Close();
xmlfileStream.Close();

// output all the contents of the file
WriteLine("{0} contains {1:N0} bytes",
    arg0: xmlFile,
    arg1: new FileInfo(xmlFile).Length);

WriteLine(File.ReadAllText(xmlFile));
}
catch (Exception ex)
{
// if the path doesn't exist the exception will be caught
WriteLine($"{ex.GetType()} says {ex.Message}");
}
finally
{
if (xml != null)
{
xml.Dispose();
WriteLine("The XML writer's unmanaged resources have been disposed.");
if (xml != null)
{
xmlfileStream.Dispose();
WriteLine("The file stream's unmanages resources have been disposed.");
}
}
}
}

WorkWithXml();
WorkWithCompression();

static void WorkWithText()
{
// define a file to write to
string textFile = Combine(CurrentDirectory, "streams.txt");

// create a text file and return a helper writer
StreamWriter text = File.CreateText(textFile);

// enumerate the strings, writing each one to the stream on a separate line
foreach (string item in Viper.Callsigns)
{
text.WriteLine(item);
}
text.Close();

// output the contents of the file
WriteLine("{0} containes {1:N0} bytes.",
    arg0: textFile,
    arg1: new FileInfo(textFile).Length);

WriteLine(File.ReadAllText(textFile));
}

//WorkWithText();
static class Viper
{
    // define an array of Viper pilot call signs
    public static string[] Callsigns = new string[]
    {
        "Husker", "Starbuck", "Appollo", "Boomer", "Bulldog",  "Athena",  "Helo",  "Racertrack"
    };
}



static void WorkWithFiles()
{
    // define a directory path to output files 
    string dir = Path.Combine(CurrentDirectory, "../../../NewFolder");

    CreateDirectory(dir);

    // define file paths
    string textFile = Combine(dir, "Dummy.txt");
    string backupfile = Combine(dir, "Dummy.bak");

    // Check if a file exists
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    // create a new text file and write a line to it
    StreamWriter textWriter = File.CreateText(textFile);
    textWriter.WriteLine("Hello, C#!");
    textWriter.Close();

    WriteLine($"Does it exist? {File.Exists(textFile)}");

    // copy the file, and overwrite if it already exists
    File.Copy(sourceFileName: textFile, destFileName: backupfile, overwrite: true);
    WriteLine($"Does it exist? {File.Exists(backupfile)}");

    // delete file
    File.Delete(textFile);
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    // read from the text file backup
    WriteLine($"Reading contents of {backupfile}");
    StreamReader textReader = File.OpenText(backupfile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();

    // test for getting parent
    string parentInfo = GetParent(dir).ToString();
    // do NOT forget close textWrite and textReader

    WriteLine($"Folder Name : {GetDirectoryName(textFile)}");
    WriteLine($"File Name : {GetFileName(textFile)}");

    FileInfo info = new(backupfile);
    WriteLine($"{backupfile} containes {info.Length} bytes. Last accessed {info.LastAccessTime}. Has readonly set to {info.IsReadOnly}");
}

WorkWithFiles();


static void WorkWithDirectories()
{
    // define a directory path for a new folder starting in the user's folder
    string newFolder = Combine(CurrentDirectory, "NewFolder");

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

static void WorkWithDrives()
{
    WriteLine("{0, -30} | {1, -10} | {2, -7} | {3,18} | {4, 18}",
        "NAME", "TYPE", "FORMAT", "SIZE(BYTE)", "FREE SPACE");

    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if (drive.IsReady)
        {
            WriteLine("{0, -30} | {1, -10} | {2, -7} | {3,18:N0} | {4, 18:N0}",
                    drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
        }
        else
        {
            WriteLine("{0, -30} | {1, -10}", drive.Name, drive.DriveType);
        }
    }
}

WorkWithDrives();

static void OutputFileSystemInfo()
{
    WriteLine("{0,-33}{1}", arg0: "Path.PathSeparator", arg1: PathSeparator);
    WriteLine("{0,-33}{1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
    WriteLine("{0,-33}{1}", arg0: "Directory.GetCurrentDirectory", arg1: Directory.GetCurrentDirectory);
    WriteLine("{0,-33}{1}", arg0: "Environment.CurrentDirectory", arg1: Environment.CurrentDirectory);
    WriteLine("{0,-33}{1}", arg0: "Environment.SystemDirectory", arg1: Environment.SystemDirectory);
    WriteLine("{0,-33}{1}", arg0: "Path.GetTempPath()", arg1: Path.GetTempPath());

    WriteLine("GetFolderPath(SpecialFolder)");

    WriteLine("{0,-33}{1}", arg0: " .System", arg1: GetFolderPath(SpecialFolder.System));
    WriteLine("{0,-33}{1}", arg0: " .ApplicationData", arg1: GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0,-33}{1}", arg0: " .MyDocuments", arg1: GetFolderPath(SpecialFolder.MyDocuments));
    WriteLine("{0,-33}{1}", arg0: " .Personal", arg1: GetFolderPath(SpecialFolder.Personal));
}

OutputFileSystemInfo();