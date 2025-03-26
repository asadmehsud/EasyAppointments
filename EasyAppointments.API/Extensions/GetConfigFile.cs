namespace EasyAppointments.API.Extensions
{
    public static class GetConfigFile
    {
        public static ConfigurationManager GetConfigurations(this ConfigurationManager configuration)
        {
            var configFilePath = Environment.GetEnvironmentVariable("ENV_Config", EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(configFilePath) && File.Exists(configFilePath))
            {
                configuration.AddJsonFile(configFilePath, optional: true, reloadOnChange: true);
            }
            return configuration;
        }
    }
}
