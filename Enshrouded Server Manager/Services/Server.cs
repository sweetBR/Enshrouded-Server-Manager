using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Enshrouded_Server_Manager.Services
{
    public class Server
    {
        private string _pathSteamCmdExe = @".\SteamCMD\steamcmd.exe";

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        /// <summary>
        /// Start Gameserver
        /// </summary>
        public void Start(String pathServerExe, String ServerName)
        {

            try
            {
                Process p = Process.Start(pathServerExe);
                Thread.Sleep(5000);
                SetWindowText(p.MainWindowHandle, $"ESM Server - {ServerName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Following error occured while starting the server: {ex.Message.ToString()}",
                    "Error while starting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Install/Validate/Update GameServer Files
        /// </summary>
        public void InstallUpdate(String SteamAppId, String Serverpath)
        {

            try
            {
                Process p = Process.Start(_pathSteamCmdExe, $"+force_install_dir {Serverpath} +login anonymous +app_update {SteamAppId} validate +quit");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Following error occured while updating the server: {ex.Message.ToString()}",
                    "Error while updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Stop Gameserver
        /// </summary>
        public void Stop()
        {

        }

    }

}
