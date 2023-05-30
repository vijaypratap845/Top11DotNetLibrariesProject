﻿namespace Top10LibrariesSampleProject.DAL.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogTrace(string message);
    }
}
