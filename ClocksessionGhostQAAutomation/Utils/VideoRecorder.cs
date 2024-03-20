using ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Tests;
using System.Diagnostics;

namespace ClocksessionGhostQAAutomation.Utils
{
    public class VideoRecorder
    {
        private static Process ffmpegProcess;
        public static string basePath = GhostQAExecutor.Basepath;
        public static string videoPath = Path.Combine(GhostQAExecutor.Basepath, "Recordings", DateTime.Now.ToString("dd-MM-yyyy"));
        public static string outputFile = string.Empty;

        public static void StartRecording()
        {
            if (!Directory.Exists(videoPath))
            {
                Directory.CreateDirectory(videoPath);
            }

            outputFile = Path.Combine(videoPath, DateTime.Now.ToString("HH-mm-ss") + ".mp4");

            string ffmpegPath = @"C:\ffmpeg-6.1.1-essentials_build\bin\ffmpeg.exe";

            // Example FFmpeg command to start recording
            string command = $"-f gdigrab -framerate 30 -i desktop -c:v libx264rgb -preset ultrafast -qp 0 -f mp4 \"{outputFile}\"";

            // Start FFmpeg process
            ffmpegProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = command,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };

            try
            {
                ffmpegProcess.Start();
                Console.WriteLine("Recording started...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting recording: {ex.Message}");
            }

            // Send the FFmpeg command to cmd.exe
            ffmpegProcess.StandardInput.WriteLine(command);
        }

        public static void StopRecording()
        {
            Process[] processes = Process.GetProcessesByName("ffmpeg");
            ffmpegProcess.Kill();
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
            Console.WriteLine("Recording Stopped...");
        }
    }
}