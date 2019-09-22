﻿using System;
using log4net;
using ORM.Core.Abstractions;

namespace ORM.Implementations
{
    public class LoggerService : ILoggerService
    {
        private readonly ILog logger;

        public LoggerService(ILog logger)
        {
            this.logger = logger;
        }

        public void Error(Exception ex)
        {
            logger.Error(ex);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void RunWithExceptionLogging(Action actionToRun, bool isSilent = false)
        {
            try
            {
                actionToRun();
            }
            catch (Exception ex)
            {
                logger.Error("Error: ", ex);

                if (isSilent) return;

                throw;
            }
        }

        public T RunWithExceptionLogging<T>(Func<T> functionToRun, bool isSilent = false)
        {
            try
            {
                return functionToRun();
            }
            catch (Exception ex)
            {
                logger.Error("Error: ", ex);

                if (isSilent) return default(T);

                throw;
            }
        }
    }
}
