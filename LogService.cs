using System;
using System.Collections.ObjectModel;

namespace AnimalApp.Services
{
    // Реализация логгера, который хранит строки лога в ObservableCollection<string>
    public class LogService : ILogService
    {
        public ObservableCollection<string> Entries { get; } = new ObservableCollection<string>();

        public void Log(string message)
        {
            var line = $"{DateTime.Now:HH:mm:ss} - {message}";
            Entries.Add(line);
        }
    }
}