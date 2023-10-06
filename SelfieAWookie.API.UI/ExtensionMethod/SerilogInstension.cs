namespace SelfieAWookie.API.UI.ExtensionMethod
{
    public static class SerilogInstension
    {
        /// <summary>
        /// ajout du système de log pour l'application - enregistrement des logs dans un fichier selon la date de création
        /// pour ajuster le log voir les le fichier appsettings.json
        /// </summary>
        /// <param name="logging"></param>
        /// <param name="environment"></param>
        public static void AddFileInstension(this ILoggingBuilder logging, IWebHostEnvironment environment)
        {
            string pathSerilog = Path.Combine(environment.ContentRootPath, "Logs/suivie-de-selfieAWookies-{Date}.txt");
            logging.AddFile(pathSerilog, isJson: true); 
        }

        /// <summary>
        /// enregistre le log au niveau du fichier 
        /// problème avec le Serilog extension File - il utilise d'ancienne version du package
        /// IO etc
        /// </summary>
        /// <param name="logging"></param>
        /// <param name="path">chemin du fichier</param>
        /// <param name="isJson">format d'enregistremnt en json</param>
        public static void AddFile (this ILoggingBuilder logging, string path, bool isJson)
        {
            // je ne vais pas l'utiliser pour le moment - programmer la chose
            // git du projet https://github.com/serilog/serilog-extensions-logging-file
        }
    }
}
