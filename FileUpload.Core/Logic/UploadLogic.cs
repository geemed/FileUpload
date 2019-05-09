using FileUpload.Core.Providers;
using FileUpload.Model;
using FileUpload.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileUpload.Core.Logic {
    public class UploadLogic {
        private readonly ModelContext _context;

        public UploadLogic() {
            _context = new ModelContext();
        }

        public async Task<IEnumerable<Upload>> UploadFile(HttpRequestMessage request) {
            var provider = new CustomMultipartFormDataProvider(AppConfig.GetUploadDirectory());
            var stream = StreamProvider.GetStreamContent(request);
            await stream.ReadAsMultipartAsync(provider);


            var files = new List<Upload>();
            var uploads = provider.FileData.Select(s => new Upload {
                Name = s.Headers.ContentDisposition.FileName.Replace("\"", ""),
                ContentType = s.Headers.ContentType.MediaType.Replace("\"", ""),
                Path = Path.GetDirectoryName(s.LocalFileName),
                CreateDate = DateTime.Now
            });

            foreach (var u in uploads) {
                var upload = _context.Uploads.Add(u);
                var result = await _context.SaveChangesAsync();

                files.Add(upload);
            }

            return files;
        }

        public async Task<bool> DeleteFile(int id) {
            var upload = await _context.Uploads.FirstOrDefaultAsync(s => s.Id == id);

            if (upload == null)
                return false;

            _context.Uploads.Remove(upload);

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
