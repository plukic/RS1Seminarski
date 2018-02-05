using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ConstructionDiary.BR.Documents.Interfaces
{
    public interface IDocumentsService
    {
       Task<Document> Store(IFormFile file, string type);
       Task<Document> Update(Document document, IFormFile contractFile);
    }
}
