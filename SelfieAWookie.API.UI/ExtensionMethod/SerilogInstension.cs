﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Debugging;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

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
            //logging.AddFile(pathSerilog, isJson: true); 
        }

    }
}
