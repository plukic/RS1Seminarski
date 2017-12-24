﻿using ConstructionDiary.BR.Documents.Interfaces;
using ConstructionDiary.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ConstructionDiary.BR.Documents.Implementation
{
    public class DocumentsService: IDocumentsService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository<Document> _documentsRepository;


        public DocumentsService(
            IHostingEnvironment hostingEnvironment,
            IRepository<Document> documentsRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _documentsRepository = documentsRepository;

        }
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public async Task<Document> Store(IFormFile file, string type)
        {
            var fileName = GetUniqueName(file.FileName);
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            Document document = new Document()
            {
                Location = filePath,
                Date = DateTime.Now,
                Type = type
            };
            _documentsRepository.Add(document);
            return document;
        }
    }
}
