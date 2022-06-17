using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.File;
using LRRS.Data.Model.Entity.Identity;
using LRRS.Queries.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public FileController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            fileuploadViewModel.UpdateDriverInformation();
            return View(fileuploadViewModel);
        }

        private async Task<FileUploadViewModel> LoadAllFiles()
        {
            var viewModel = new FileUploadViewModel();
            viewModel.FilesOnDatabase = await context.FilesOnDB.ToListAsync();

            viewModel.FilesOnDatabase.ForEach(f => { f.Owner = _userManager.FindByIdAsync(f.OwnerId).Result; });

            viewModel.FilesOnFileSystem = await context.FilesOnServer.ToListAsync();
            viewModel.FilesOnFileSystem.ForEach(f => { f.Owner = _userManager.FindByIdAsync(f.OwnerId).Result; });

            viewModel.UpdateDriverInformation();
            return viewModel;
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files, string description)
        {

            foreach (var file in files)
            { 
                if ((file.Length / 1048576.0) > 3)
                {
                    UploadToServer(file, description);
                }
                else
                {
                    UploadToDataBase(file, description);
                }
            }

            context.SaveChanges();
            TempData["Message"] = "Files successfully uploaded.";
            return RedirectToAction("Index"); 
        }
         

        private void UploadToServer(IFormFile file, string description)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
            bool basePathExists = System.IO.Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);

            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            fileName = fileName + "_" + GuidString;
            var filePath = Path.Combine(basePath, fileName);
            var extension = Path.GetExtension(file.FileName);
            if (!System.IO.File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
                var fileModel = new FileOnFileSystemModel
                {
                    CreatedDate = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description = description,
                    FilePath = filePath,
                    OwnerId = _userManager.GetUserId(User)
                };
                context.FilesOnServer.Add(fileModel);
            }

        } 
        private void UploadToDataBase(IFormFile file, string description)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var fileModel = new FileOnDatabaseModel
            {
                CreatedDate = DateTime.UtcNow,
                FileType = file.ContentType,
                Extension = extension,
                Name = fileName,
                Description = description,
                 OwnerId = _userManager.GetUserId(User)

            };
            using (var dataStream = new MemoryStream())
            {
                file.CopyToAsync(dataStream);
                fileModel.Data = dataStream.ToArray();
            }
            context.FilesOnDB.Add(fileModel);  
        }
       
        [DisableRequestSizeLimit]
        public async Task<IActionResult> DownloadFileFromFileSystem(string id)
        {
            var file = await context.FilesOnServer.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
        }
        public async Task<IActionResult> DeleteFileFromFileSystem(string id)
        {
            var file = await context.FilesOnServer.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            file.IsDeleted = true;
            file.DeletedDate = DateTime.Now;
            context.FilesOnServer.Update(file);
            context.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from File System.";
            return RedirectToAction("Index");
        }
         

        public async Task<IActionResult> DownloadFileFromDatabase(string id)
        {
            var file = await context.FilesOnDB.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }

        public async Task<IActionResult> DeleteFileFromDatabase(string id)
        {
            var file = await context.FilesOnDB.Where(x => x.Id == id).FirstOrDefaultAsync();
            file.IsDeleted = true;
            context.FilesOnDB.Update(file);
            context.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from Database.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RestoreFileFromDatabase(string id)
        {
            var file = await context.FilesOnDB.Where(x => x.Id == id).FirstOrDefaultAsync();
            file.IsDeleted = false;
            context.FilesOnDB.Update(file);
            context.SaveChanges();
            TempData["Message"] = $"Restore {file.Name + file.Extension} successfully from Database.";
            return RedirectToAction("Index");
        }

    }
}
