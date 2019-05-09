using System.Net.Http;
using System.Net.Http.Headers;

namespace FileUpload.Core.Providers {
    public class CustomMultipartFormDataProvider : MultipartFileStreamProvider {
        public CustomMultipartFormDataProvider(string path) : base(path) { }

        public override string GetLocalFileName(HttpContentHeaders headers) {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }
}
