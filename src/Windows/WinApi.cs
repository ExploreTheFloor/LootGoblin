using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LootGoblin.Windows
{
    public class WinApi
    {

        /// <summary>Allows for foreground hardware keyboard key presses</summary>
        /// <param name="nInputs">The number of inputs in pInputs</param>
        /// <param name="pInputs">A Input structure for what is to be pressed.</param>
        /// <param name="cbSize">The size of the structure.</param>
        /// <returns>A message.</returns>
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern uint SendInput(uint nInputs, ref Messaging.Input pInputs, int cbSize);

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern nint FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(nint hWnd);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(nint hWnd, nint ProcessId);

        public static List<Process> GetProcessByName(string processName)
        {
            return Process.GetProcesses()
                .Where(x => x.ProcessName.StartsWith(processName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
