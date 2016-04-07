using Microsoft.Build.Utilities;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SonarQube.MSBuild.Tasks
{
    public class AttachBuildWrapper : Task
    {
        // FIXME(Godin): hard-coded paths

        #region Input properties

        //[Microsoft.Build.Framework.Required]
        //public string OutputDirectoryPath { get; set; }

        #endregion Input properties

        public override bool Execute()
        {
            return Attach("C:\\Users\\vagrant\\Source\\Repos\\build-wrapper\\ng\\bin\\win-x86-64");
        }

        #region Private methods

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        private bool Attach(string BuildWrapper)
        {
            string DLL = BuildWrapper + "\\interceptor.dll";
            IntPtr h = GetModuleHandle(DLL);
            if (h != IntPtr.Zero)
            {
                Console.WriteLine("Already attached");
                return true;
            }
            var CurrentPID = Process.GetCurrentProcess().Id;
            Console.WriteLine("Requesting attach to " + CurrentPID);
            Process process = new Process();
            process.StartInfo.FileName = BuildWrapper + "\\monitor.exe";
            process.StartInfo.Arguments = CurrentPID.ToString();
            process.Start();

            // TODO(Godin): improve waiting of a ready state
            System.Threading.Thread.Sleep(3000);

            return true;
        }

        #endregion Private methods
    }
}
