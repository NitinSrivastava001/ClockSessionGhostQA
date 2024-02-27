

using ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Tests;
using System.Diagnostics;

namespace myersandstaufferframework
{
    public class VideoRecorder 
    {
        private Process ffmpegProcess;
        public static string basePath = GhostQAExecutor.Basepath;

        public void StartRecording()
        {
            var dateTime = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fffffffzzz");
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            var time = DateTime.Now.ToString("HH-mm-ss");

            String outputFile =  GhostQAExecutor.Basepath+date+"\\"+time+".mp4";
            String ffmpegPath = @"C:\ffmpeg-6.1.1-essentials_build\bin\ffmpeg.exe";
            // Example FFmpeg command to start recording
            string command = $"{ffmpegPath} -f gdigrab -framerate 30 -i desktop -c:v libx264rgb -preset ultrafast -qp 0 -f mp4 E:\\GhostQACode\\output1.mp4";

            // Start FFmpeg process
            ffmpegProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };
            ffmpegProcess.Start();
            Console.WriteLine("Recoridng Started....");

            // Send the FFmpeg command to cmd.exe
            ffmpegProcess.StandardInput.WriteLine(command);
            //ffmpegProcess.StandardInput.Flush();
            //ffmpegProcess.StandardInput.Close();
        }

        public void StopRecording()
        {
            Process[] processes = Process.GetProcessesByName("ffmpeg");
            foreach (Process process in processes)
            {
                process.CloseMainWindow();
                process.WaitForExit();
            }
            Console.WriteLine("Recording Stopped...");

        }
    }
}
