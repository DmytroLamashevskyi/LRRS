using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class FileUploadViewModel
    { 
        public string MemmoryLoaded { set; get; } 

        public List<FileOnFileSystemModel> FilesOnFileSystem { get; set; }
        public List<FileOnDatabaseModel> FilesOnDatabase { get; set; }

        public void UpdateDriverInformation()
        {
            DriveInfo cDrive = new DriveInfo(System.Environment.CurrentDirectory);
            double percents =1- (double)cDrive.TotalFreeSpace / cDrive.TotalSize;
            CultureInfo us = new CultureInfo("en-US");
            MemmoryLoaded = percents.ToString("P02", us);
        }
    }
}
