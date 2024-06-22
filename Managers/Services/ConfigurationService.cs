using Entities.Util;

namespace Managers.Services
{
    public class ConfigurationService
    {
        private readonly Dictionary<string, string> config = new Dictionary<string, string>();

        public bool LoadConfig(string filePath)
        {
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to load config file: {ex.Message}");
                return false;
            }
        }

        public string GetValue(string key)
        {
            return config.TryGetValue(key, out var value) ? value : null;
        }
    }
}
