using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LootGoblin.Services
{
    public class LogMonitor
    {
        /// <summary>
        /// Called when a message (such as a whisper or disconnect) is received.
        /// This may be invoked on a thread separate from the UI thread.
        /// </summary>
        public event Action<string?> MessageReceived;

        /// <summary>
        /// Gets the path to the log file being monitored.
        /// </summary>
        private string LogPath { get; set; }

        /// <summary>
        /// Indicates if the LogMonitor is currently monitoring LogPath for changes.
        /// </summary>
        public bool IsMonitoring { get; private set; }

        /// <summary>
        /// Creates a new LogMonitor without immediately starting to monitor changes.
        /// </summary>
        public LogMonitor(string logPath)
        {
            LogPath = logPath;
        }

        /// <summary>
        /// Begins monitoring the log file for changes.
        /// </summary>
        public void BeginMonitoring()
        {
            if (IsMonitoring)
                throw new InvalidOperationException("Already monitoring for changes.");
            IsMonitoring = true;
            _logStream = new FileStream(LogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _logStream.Seek(0, SeekOrigin.End);
            // Instead of proper async handling, take the lazy way and ReadLine in a new thread.
            _logThread = new Thread(RunReadLoop) { IsBackground = true };
            _logThread.Start();
        }

        /// <summary>
        /// Stops monitoring the log file for changes.
        /// If any messages are currently being processed, they may still be dispatched.
        /// </summary>
        public void StopMonitoring()
        {
            if (!IsMonitoring)
                throw new InvalidOperationException("Not currently monitoring.");
            IsMonitoring = false;
            _logThread.Join();
            _logStream.Dispose();
        }

        private void RunReadLoop()
        {
            var reader = new StreamReader(_logStream);
            while (IsMonitoring)
            {
                if (_logStream.Length != _logStream.Position)
                {
                    string? line = reader.ReadLine();
                    Action<string?> ev = MessageReceived;
                    ev?.Invoke(line);
                    continue;
                }
                Thread.Sleep(50);
            }
        }

        private FileStream _logStream;
        private Thread _logThread;
    }
}
