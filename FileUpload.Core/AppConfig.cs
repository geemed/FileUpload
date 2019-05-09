using System;
using System.Configuration;

namespace FileUpload.Core {
    public static class AppConfig {
        public static string GetAppSetting(string key) {
            try {
                return ConfigurationManager.AppSettings[key].ToString();
            } catch { }

            return string.Empty;
        }

        public static string GetUploadDirectory() {
            var dirName = GetAppSetting("UploadDirectoryName");

            if (string.IsNullOrEmpty(dirName))
                dirName = "Uploads";

            return $"{AppDomain.CurrentDomain.BaseDirectory}{dirName}\\";
        }
    }
}
