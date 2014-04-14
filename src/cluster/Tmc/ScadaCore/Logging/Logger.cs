﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tmc.Scada.Core
{
    public enum LogStrategy
    {
        File,
        //Database,
        All
    }

    public sealed class Logger
    {
        private static Logger _instance;
        private List<ILogProvider> _logProviders;

        public LogStrategy Strategy { get; set; }
        public readonly LogStrategy DefaultStrategy;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        private Logger()
        {
            var appSettings = ConfigurationManager.AppSettings;
            //var filename = ConfigurationManager.AppSettings["logfile"].ToString();
            var filename = appSettings["LogFile"];
            _logProviders = new List<ILogProvider>();
            _logProviders.Add(new FileLogProvider(filename.ToString()));
            DefaultStrategy = LogStrategy.All;
            Strategy = DefaultStrategy;
        }

        public void Write(string message)
        {
            foreach (var p in _logProviders)
            {
                if (MatchesStrategy(p))
                {
                    p.Write(message);
                }
            }
        }

        public void Write(string message, LogType level)
        {
            foreach (var p in _logProviders)
            {
                if (MatchesStrategy(p))
                {
                    p.Write(message, level);
                }
            }
        }

        public void Write(LogEntry message)
        {
            foreach (var p in _logProviders)
            {
                if (MatchesStrategy(p))
                {
                    p.Write(message);
                }
            }
        }

        private bool MatchesStrategy(ILogProvider p)
        {
            return (Strategy == LogStrategy.All || Strategy == p.ProvidedStrategy);
        }
    }
}