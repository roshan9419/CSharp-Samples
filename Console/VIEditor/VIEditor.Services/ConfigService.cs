using System;
using System.Collections.Generic;
using System.IO;
using VIEditor.Converters;
using VIEditor.FileManager;
using VIEditor.Services.Models;

namespace VIEditor.Services
{
    /// <summary>
    /// This is a config service used for any configuration changes
    /// </summary>
    public sealed class ConfigService
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        private ConfigService()
        {
            string file = Path.Combine(FileUtils.CurrentDirectory(), @"Resources\config.json");
            _config = JsonParser<Config>.JsonToObject(file);
            _log.Info("ConfigService initialized");
        }

        private static readonly Lazy<ConfigService> _instance = new(() => new ConfigService());
        private readonly Config _config;

        /// <summary>
        /// Returns the instance of ConfigService
        /// </summary>
        public static ConfigService GetInstance
        {
            get { return _instance.Value; }
        }

        /// <summary>
        /// Returns the file editing termination commands
        /// </summary>
        public List<string> EOFCommands
        {
            get { return _config.EOFCommands; }
        }

        /// <summary>
        /// Returns the list of supported file extensions
        /// </summary>
        public List<string> SupportedFileExtensions
        {
            get { return _config.SupportedFileExtensions; }
        }

        /// <summary>
        /// The default file extension which is to be added when extension not provided
        /// </summary>
        public string DefaultFileExtension
        {
            get { return _config.DefaultFileExtension; }
        }
    }
}
