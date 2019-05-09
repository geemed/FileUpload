using System.IO;
using System.Net.Http;

namespace FileUpload.Core.Providers {
    public static class StreamProvider {
        public static StreamContent GetStreamContent(HttpRequestMessage request) {
            var stream = request.Content.ReadAsStreamAsync().Result;
            var mem = new MemoryStream();

            stream.CopyTo(mem);
            mem.Seek(0, SeekOrigin.End);

            var writer = new StreamWriter(mem);

            writer.WriteLine();
            writer.Flush();
            mem.Position = 0;

            var content = new StreamContent(mem);
            foreach (var header in request.Content.Headers)
                content.Headers.Add(header.Key, header.Value);

            return content;
        }
    }
}
