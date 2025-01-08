using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin
{
    internal class ProcessHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private bool IsWindowActive(string processName)
        {
            var hWndFg = GetForegroundWindow();
            GetWindowThreadProcessId(hWndFg, out var pid);
            var foregroundProcess = Process.GetProcessById((int)pid);
            return foregroundProcess.ProcessName.ToLower().Contains(processName.ToLower());
        }

        /// <summary>
        /// Helper function to try and get the PoE process, if it's currently running.
        /// </summary>
        public static Process? GetProcess(string processName, string windowName)
        {
            // This doesn't belong in Main, but oh well.
            Func<Process, bool> matchingProcess = c =>
                c.MainWindowTitle.Equals(windowName, StringComparison.InvariantCultureIgnoreCase) &&
                c.ProcessName.ToLower().Contains(processName.ToLower());
            return Process.GetProcesses().FirstOrDefault(matchingProcess);
        }

        public static Process? GetProcess(string processName)
        {
            var proc = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.ToLower().Contains(processName));
            if (proc == null || proc.MainWindowHandle.Equals(IntPtr.Zero))
                return null;
            return proc;
        }
    }
}