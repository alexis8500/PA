using System;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;

namespace P9
{
    static class Students
    {
        public static string[] students = { "Alexis", "Mario", "Sara", "PauPau", "Guillermo" };
    }
    class Program
    {
        static void Main(string[] args)
        {
            OutputSystemFileInfo();
            WriteLine();
            WorkWithDrivers();
            WriteLine();
            WorkWithDirectories();
            WriteLine();
            WorkWithFiles();
            WriteLine();
            WorkWithXml();
        }

        static void OutputSystemFileInfo()
        {
            WriteLine("{0, -33} {1}", arg0: "Path.PathSeparator", arg1: PathSeparator);
            WriteLine("{0, -33} {1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
            WriteLine("{0, -33} {1}", arg0: "Directory.CurrentDirectory", arg1: CurrentDirectory);
            WriteLine("{0, -33} {1}", arg0: "Directory.GetCurrentDirectory", arg1: GetCurrentDirectory());
            WriteLine("{0, -33} {1}", arg0: "Directory.SystemDirectory", arg1: GetTempPath());
            WriteLine("{0, -33} {1}", arg0: "GetFolderPath(SpecialFolder)", arg1: GetFolderPath(SpecialFolder.System));
            WriteLine("{0, -33} {1}", arg0: "GetFolderPath(ApplicationData)", arg1: GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0, -33} {1}", arg0: "GetFolderPath(MyDocuments)", arg1: GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0, -33} {1}", arg0: "GetFolderPath(Personal)", arg1: GetFolderPath(SpecialFolder.Personal));
        }

        static void WorkWithDrivers()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE(BITES)", "FREE SPACE");
            foreach (var drive in DriveInfo.GetDrives())
            {
                //always check if device is avaible
                if (drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }

        static void WorkWithDirectories()
        {
            //C:\Users\AngelBrambila\Documents\7B\Alexis
            //C:\Users\AngelBrambila\Documents\7B\

            string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "7B", "Alexis");
            WriteLine($"Working With : {newFolder}");
            WriteLine($"Does it Exist? {Exists(newFolder)}");
            ReadLine();
            WriteLine("Creating it");
            CreateDirectory(newFolder);
            WriteLine($"Does it Exist? {Exists(newFolder)}");
        }

        static void WorkWithFiles()
        {
            string dir = Combine(GetFolderPath(SpecialFolder.Personal), "7B", "Mario");
            CreateDirectory(dir);
            string textFile = Combine(dir, "Mario.txt");
            string backupFile = Combine(dir, "BackupMario.bak");
            WriteLine($"Working with {textFile}");
            WriteLine($"Does it exists? {File.Exists(textFile)}");
            // Streamsw
            StreamWriter textwriter = File.CreateText(textFile);
            textwriter.WriteLine("Hello Mario!");
            // ALNAYS CLOSE THE F%&^%$$%ing Files
            textwriter.Close();
            WriteLine($"Does it exists? {File.Exists(textFile)}");
            ReadLine();
            WriteLine("Deleting it");
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
            WriteLine($"Does back Up File Exists? {Exists(backupFile)}");
            ReadLine();
            File.Delete(textFile);
            WriteLine($"Does it exists? {File.Exists(textFile)}");
            WriteLine("Reading BAck Up File");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            // ALNAYS CLOSE THE F@!#@!$@!ing File
            textReader.Close();
        }
    
        static void WorkWithXml()
        {
            string xmlFile = Combine(CurrentDirectory, "streams.xml");
            FileStream xmlStreamFile = File.Create(xmlFile);
            // Working with real XML
            XmlWriter xml = XmlWriter.Create(xmlStreamFile, new XmlWriterSettings {Indent = true});
            xml.WriteStartDocument();
            xml.WriteStartElement("Students");
            foreach (string item in Students.students)
            {
                xml.WriteElementString("student", item);
            }
            xml.WriteEndElement();
            xml.Close();
            xmlStreamFile.Close();
        }
    }
}