using System;
using System.CommandLine;
using System.IO;
using Newtonsoft.Json;

namespace Blake;

class Program
{
    public static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The BloodHound ZIP file to ingest and replicate");
        var domain = new Option<string>(
            name: "--domain",
            description: "Target Domain to replicate the source data into");

        var rootCommand = new RootCommand("Blake will take the output of BloodHound zip file and then create all the AD objects to give you a cloned AD environment");
        rootCommand.AddOption(fileOption);
        rootCommand.AddOption(domain);

        rootCommand.SetHandler((file) =>
        {
            
            DirectoryInfo extractedZip = ExtractZipFile(file!);


        },
            fileOption);

        return await rootCommand.InvokeAsync(args);
    }

    static DirectoryInfo ExtractZipFile(FileInfo file)
    {
        string newDirectoryName = file.Name.Split('.')[0] + "_extract";
        DirectoryInfo newDirectoryPath = new DirectoryInfo(Path.Combine(file.Directory.ToString(), newDirectoryName.ToString()));

        //System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
        System.IO.Compression.ZipFile.ExtractToDirectory(file.ToString(), newDirectoryPath.ToString());

        return newDirectoryPath;
    }

    static void ParseJSONFiles(DirectoryInfo directory) 
    {
        // Read in all the JSON files
        FileInfo computersFile = new FileInfo(directory.FullName);
        string computersFileContents = System.IO.File.ReadAllText(computersFile.ToString());

        FileInfo containersFile = new FileInfo(directory.FullName);
        string containersFileContents = System.IO.File.ReadAllText(containersFile.ToString());

        FileInfo domainsFile = new FileInfo(directory.FullName);
        string domainsFileContents = System.IO.File.ReadAllText(domainsFile.ToString());

        FileInfo groupPoliciesFile = new FileInfo(directory.FullName);
        string groupPoliciesFileContents = System.IO.File.ReadAllText(groupPoliciesFile.ToString());

        FileInfo groupsFile = new FileInfo(directory.FullName);
        string groupsFileContents = System.IO.File.ReadAllText(groupsFile.ToString());

        FileInfo organizationalUnitsFile = new FileInfo(directory.FullName);
        string organizationalUnitsFileContents = System.IO.File.ReadAllText(organizationalUnitsFile.ToString());

        FileInfo usersFile = new FileInfo(directory.FullName);
        string usersFileContents = System.IO.File.ReadAllText(usersFile.ToString());
   

        List<Computer> computerObjects = JsonConvert.DeserializeObject<List<Computer>>(computersFileContents);

    }
}



class Blake
{

}


