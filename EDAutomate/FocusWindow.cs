using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EDAutomate
{
    class FocusWindow
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);


        public static void FocusOnEliteWindow(dynamic vaProxy)
        {

            IntPtr hWndElite = IntPtr.Zero;
            IntPtr hWndVA = IntPtr.Zero;
            Process[] processes = Process.GetProcesses();
            //vaProxy.WriteToLog($"DEBUG: Processes: {processes.Length}", "orange");
            foreach (var process in processes)
            {
                //vaProxy.WriteToLog($"DEBUG: Processe: {process.ProcessName}", "orange");
                if (process.ProcessName == "EliteDangerous64")
                {
                    //vaProxy.WriteToLog($"DEBUG: Process: {process.ProcessName}", "orange");
                    hWndElite = process.MainWindowHandle;
                }
                if (process.ProcessName == "VoiceAttack")
                {
                    //vaProxy.WriteToLog($"DEBUG: Process: {process.ProcessName}", "orange");
                    hWndVA = process.MainWindowHandle;
                }
            }
            if (hWndElite != IntPtr.Zero || hWndVA != IntPtr.Zero)
            {
                uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);

                uint appThread = GetCurrentThreadId();

                const uint SW_SHOW = 5;

                if (foreThread != appThread)

                {

                    AttachThreadInput(foreThread, appThread, true);

                    BringWindowToTop(hWndElite);

                    ShowWindow(hWndElite, SW_SHOW);

                    AttachThreadInput(foreThread, appThread, false);

                }

                else

                {

                    BringWindowToTop(hWndElite);

                    ShowWindow(hWndElite, SW_SHOW);

                }
            }

        }


    }
}
