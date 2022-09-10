using Application.Exceptions;
using Application.Interface;
using AutoMapper;
using CsvHelper;
using Domain;
using System.Data;
using System.Globalization;
using System.Xml.Serialization;

namespace Application.Services
{
    public class CreateModelsFromImportFileRequest
    {
        public Stream FileStream { get;}
        public string FileName { get;}
        public CreateModelsFromImportFileRequest(Stream fileStream, string fileName)
        {
            FileStream = fileStream;
            FileName = fileName;
        }
    }
    public class FileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
             _fileRepository = fileRepository;
        }

        public async Task<int> ImportFileAsync(CreateModelsFromImportFileRequest request)
        {
            using var reader = new StreamReader(request.FileStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var fileExtention = Path.GetExtension(request.FileName);
            if(fileExtention != ".csv")
            {
                throw new WrongFileExtentionException("This is not csv file");
            }
            csv.Context.RegisterClassMap<ModelMap>();
            var organizationList = csv.GetRecords<Model>().ToList();
            await _fileRepository.AddManyAsync(organizationList);
            return await _fileRepository.SaveChangesAsync();
        }

        public Stream ExportModelsToXml()
        {
            var models = _fileRepository.GetAll().ToList();
            var serializer = new XmlSerializer(typeof(List<Model>));
            var path = Path.Combine("wwwroot", $"{DateTime.UtcNow.Year}_{DateTime.UtcNow.Month}_{DateTime.UtcNow.Day}_{DateTime.UtcNow.Second}.xml");
            var writer = new StreamWriter(path);
            serializer.Serialize(writer, models);
            writer.Close();
            var fileStream = File.Open(path, FileMode.Open);
            return fileStream;
        }
    }
}
