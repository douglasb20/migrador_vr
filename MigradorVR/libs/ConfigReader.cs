using Salaros.Configuration;
using System;
using System.IO;

namespace MigradorRP
{
    public static class ConfigReader
    {
        private static ConfigParser config;
        private static string filePath;
        public static string sistema = null;
        public static string tipoImportacao = null;

        public static void LoadConfig(string fileName)
        {

            try
            {
                if (!File.Exists(fileName))
                {
                    throw new Exception("Arquivo de config.conf não localizado");
                }

                config = new ConfigParser(fileName);
                filePath = fileName;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static void ReloadConfig()
        {
            config = new ConfigParser(filePath);
        }

        public static void SaveConfig()
        {
            config.Save();
        }

        public static void SetConfigValue(string section, string key, string value)
        {
            config.SetValue(section, key, value);
        }

        public static string GetConfigValue(string section, string key)
        {
            String value = config.GetValue(section, key);
            return value;
        }

    }
}
