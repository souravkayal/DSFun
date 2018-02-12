using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{

    //Add all available file formats
    public enum FileFormat
    {
        Txt, PDF, GIF, ppt
    }

    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FileFormat FileFormat { get; set; }
        public double Size { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        //You may add more propertyes
    }

    public class Directory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Directory Parent { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }
    }

    public class Disk
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }
    }

    public interface IDirectoryOperation
    {
        void AddFile(File Item);
        void DeleteFile(File file);
        void Rename(string NewName);
        void DeleteDirectory(Directory Parent);
    }
    public class DirectoryOperation : IDirectoryOperation
    {
        Directory Directory;
        public DirectoryOperation(Directory WorkingDirectory)
        {
            this.Directory = WorkingDirectory;
        }
        public void AddFile(File Item)
        {
            this.Directory.Files.Add(Item);
        }

        public void DeleteDirectory(Directory Item)
        {
            this.Directory.Parent.Directories.Remove(Item);
        }

        public void DeleteFile(File file)
        {
            this.Directory.Files.Remove(file);
        }

        public void Rename(string NewName)
        {
            this.Directory.Name = NewName;
        }
    }

    //It should be similar to Directory Operation
    public interface IFileOperation
    {

    }

    public interface IDiskOperation
    { }
}
