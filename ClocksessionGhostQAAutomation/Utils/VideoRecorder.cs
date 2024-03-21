using ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Tests;
using OpenQA.Selenium;
using System.Diagnostics;

namespace ClocksessionGhostQAAutomation.Utils
{
    public class VideoRecorder
    {
        private static Process ffmpegProcess;
        public static string basePath = GhostQAExecutor.Basepath;
        public static string videoPath = Path.Combine(GhostQAExecutor.Basepath, "Recordings", DateTime.Now.ToString("dd-MM-yyyy"));
        public static string outputFile = string.Empty;
        public static string screenshotDirectory;
        
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
            if (ffmpegProcess != null && !ffmpegProcess.HasExited)
            {
                try
                {
                    // If StandardInput has been redirected, you can send the 'q' command to FFmpeg to gracefully stop recording
                    if (ffmpegProcess.StartInfo.RedirectStandardInput)
                    {
                        ffmpegProcess.StandardInput.WriteLine("q");
                    }
                    else
                    {
                        // If StandardInput is not redirected, attempt to close the process gently
                        ffmpegProcess.CloseMainWindow();
                        ffmpegProcess.Close();
                    }
                    ffmpegProcess.WaitForExit(5000); // Wait for 5 seconds for the process to exit
                    ffmpegProcess.Kill(); // If the process is still running, kill it (as a last resort)

                    Console.WriteLine("Recording stopped and file finalized.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error stopping the recording: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("FFmpeg process is not running or already stopped.");
            }
        }

        public static void ScreenShot(string step, string datetime)
        {
            
            string basePath = Path.Combine(VideoRecorder.basePath, "screenshot");
             screenshotDirectory = Path.Combine(basePath, datetime);

            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            string screenshotFile = Path.Combine(screenshotDirectory, step + ".png");
            Screenshot screenShot = ((ITakesScreenshot)Browser.Driver).GetScreenshot();
            screenShot.SaveAsFile(screenshotFile);
        }

        public static void CreateRecordingfromSC()
        {
            if (!Directory.Exists(videoPath))
            {
                Directory.CreateDirectory(videoPath);
            }

            outputFile = Path.Combine(videoPath, DateTime.Now.ToString("HH-mm-ss") + ".mp4");
            string[] screenshotFiles = System.IO.Directory.GetFiles(screenshotDirectory, "*.png");
            string inputFiles = "";
            foreach (string file in screenshotFiles)
            {
                inputFiles += $"-i \"{file}\" ";
            }

            string ffmpegPath = @"C:\ffmpeg-6.1.1-essentials_build\bin\ffmpeg.exe";
            string ffmpegArgs = $"-framerate 0.5 -i {screenshotDirectory}//step%d.png -c:v libx264 -r 0.5 -pix_fmt yuv420p {outputFile}";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = ffmpegArgs,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            startInfo.RedirectStandardError = true;
            using (Process process = Process.Start(startInfo))
            {
                string standardError = process.StandardError.ReadToEnd();
                process.WaitForExit();
                int exitCode = process.ExitCode;

                Console.WriteLine("Standard Error:");
                Console.WriteLine(standardError);

                if (exitCode == 0)
                {
                    Console.WriteLine("Video creation successful.");
                }
                else
                {
                    Console.WriteLine($"Error creating video. ffmpeg exited with code {exitCode}.");
                }
            }
        }
    }
}