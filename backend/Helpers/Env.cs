// load and set environment variables from .env file
// the .env file is located in the root dir of the project
// the .env file has the following format: KEY=VALUE

using System.Text.RegularExpressions;

public static class Env
{
    public static void Load(string filename = ".env")
    {
        // the path to the .env file is in the root dir of the project
        var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", filename);
        if (!File.Exists(envPath))
        {
            return;
        }

        var lines = File.ReadAllLines(envPath);
        var regex = new Regex(@"^([a-zA-Z_]+)=(.*)$");

        foreach (var line in lines)
        {
            var match = regex.Match(line);

            if (!match.Success)
            {
                continue;
            }

            var key = match.Groups[1].Value;
            var value = match.Groups[2].Value;

            Environment.SetEnvironmentVariable(key, value);
        }
    }
}
