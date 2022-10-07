using System;
using System.CommandLine;
using System.IO;
using System.Text.RegularExpressions;
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
            BloodHoundData bloodHoundData = ParseJSONFiles(extractedZip);

        },
            fileOption);

        return await rootCommand.InvokeAsync(args);
    }

    static DirectoryInfo ExtractZipFile(FileInfo file)
    {
        string newDirectoryName = file.Name.Split('.')[0] + "_extract";
        DirectoryInfo newDirectoryPath = new DirectoryInfo(Path.Combine(file.Directory.ToString(), newDirectoryName.ToString()));

        // If the path doesn't exist, extract
        if (!newDirectoryPath.Exists)
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(file.ToString(), newDirectoryPath.ToString());
        }
        
        return newDirectoryPath;
    }

    static BloodHoundData ParseJSONFiles(DirectoryInfo directory) 
    {
        // Extract the date from the directory
        Regex pattern = new Regex(@"([0-9]){14}");
        Match date = pattern.Match(directory.ToString());

        // Read in all the JSON files
        string computersFilePath = Path.Combine(directory.ToString(), date + "_computers.json");
        FileInfo computersFile = new FileInfo(computersFilePath);
        string computersFileContents = System.IO.File.ReadAllText(computersFile.ToString());

        string containersFilePath = Path.Combine(directory.ToString(), date + "_containers.json");
        FileInfo containersFile = new FileInfo(containersFilePath);
        string containersFileContents = System.IO.File.ReadAllText(containersFile.ToString());

        string domainsFilePath = Path.Combine(directory.ToString(), date + "_domains.json");
        FileInfo domainsFile = new FileInfo(domainsFilePath);
        string domainsFileContents = System.IO.File.ReadAllText(domainsFile.ToString());

        string groupPoliciesFilePath = Path.Combine(directory.ToString(), date + "_gpos.json");
        FileInfo groupPoliciesFile = new FileInfo(groupPoliciesFilePath);
        string groupPoliciesFileContents = System.IO.File.ReadAllText(groupPoliciesFile.ToString());

        string groupsFilePath = Path.Combine(directory.ToString(), date + "_groups.json");
        FileInfo groupsFile = new FileInfo(groupsFilePath);
        string groupsFileContents = System.IO.File.ReadAllText(groupsFile.ToString());

        string organizationalUnitsFilePath = Path.Combine(directory.ToString(), date + "_ous.json");
        FileInfo organizationalUnitsFile = new FileInfo(organizationalUnitsFilePath);
        string organizationalUnitsFileContents = System.IO.File.ReadAllText(organizationalUnitsFile.ToString());

        string usersFilePath = Path.Combine(directory.ToString(), date + "_users.json");
        FileInfo usersFile = new FileInfo(usersFilePath);
        string usersFileContents = System.IO.File.ReadAllText(usersFile.ToString());
   
        // Deserialize all the data
        //BloodHoundJSONWrapper<Computer> computerObjects = JsonConvert.DeserializeObject<BloodHoundJSONWrapper<Computer>>(computersFileContents);
        object containerObjects = JsonConvert.DeserializeObject<object>(containersFileContents);
        //object domainObjects = JsonConvert.DeserializeObject<object>(domainsFileContents);
        //object groupPolicyObjects = JsonConvert.DeserializeObject<object>(groupPoliciesFileContents);
        //object groupObjects = JsonConvert.DeserializeObject<object>(groupsFileContents);
        //object organizationalUnitObjects = JsonConvert.DeserializeObject<object>(organizationalUnitsFileContents);
        //object userObjects = JsonConvert.DeserializeObject<object>(usersFileContents);

        // Convert it to BloodHound Data
        BloodHoundData bloodhoundData = new BloodHoundData();//computerObjects, containerObjects, domainObjects, groupPolicyObjects, groupObjects, organizationalUnitObjects, userObjects);

        return bloodhoundData;

    }
}



class Blake
{

}


