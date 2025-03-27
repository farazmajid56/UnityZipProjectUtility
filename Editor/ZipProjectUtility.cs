using UnityEditor;
using UnityEngine;
using System.IO;
using System.IO.Compression;

public class ZipProjectUtility : EditorWindow
{
    static string GetProjectName()
    {
        // Get the path to the Assets folder
        string dataPath = Application.dataPath;

        // Extract the project name from the path
        string[] pathParts = dataPath.Split('/');
        string projectName = pathParts[pathParts.Length - 2];

        return projectName;
    }

    [MenuItem("Tools/Zip Project")]
    public static void ZipProject()
    {
        Debug.Log("Zip Project option selected.");

        // Path to save the zip file
        string projectPath = Directory.GetCurrentDirectory();
        string zipFileName = $"{GetProjectName()}.zip";
        string zipFilePath = Path.Combine(projectPath, zipFileName);

        // Folders to include in the zip
        string[] includeFolders = { "Assets", "ProjectSettings", "Packages" };

        try
        {
            // Delete existing zip file if it exists
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }

            using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                int totalFiles = 0;
                foreach (string folder in includeFolders)
                {
                    string folderPath = Path.Combine(projectPath, folder);
                    if (Directory.Exists(folderPath))
                    {
                        totalFiles += Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Length;
                    }
                }

                int processedFiles = 0;

                foreach (string folder in includeFolders)
                {
                    string folderPath = Path.Combine(projectPath, folder);
                    if (Directory.Exists(folderPath))
                    {
                        string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
                        foreach (string file in files)
                        {
                            string relativePath = file.Substring(folderPath.Length + 1);
                            string entryName = Path.Combine(folder, relativePath).Replace("\\", "/");
                            archive.CreateEntryFromFile(file, entryName);

                            // Update progress bar
                            processedFiles++;
                            float progress = (float)processedFiles / totalFiles;
                            EditorUtility.DisplayProgressBar("Zipping Project", $"Processing {entryName}", progress);
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Folder not found: {folder}");
                    }
                }
            }

            Debug.Log($"Project zipped successfully to {zipFilePath}");
            EditorUtility.RevealInFinder(zipFilePath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to zip project: {ex.Message}");
        }
        finally
        {
            // Clear the progress bar
            EditorUtility.ClearProgressBar();
        }
    }
}
