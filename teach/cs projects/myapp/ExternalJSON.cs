using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
/*
"POCO" stands for plain old CLR object. 
A POCO is a .NET type that doesn't depend on any framework-specific types, 
for example, through inheritance or attributes.

link ref: https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-core-3-1
*/
public class WeatherForecastWithPOCOs
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; }
    public string SummaryField;
    public IList<DateTimeOffset> DatesAvailable { get; set; }
    public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
    public string[] SummaryWords { get; set; }
}

public class HighLowTemps
{
    public int High { get; set; }
    public int Low { get; set; }
}

class ExternalJSON
{
    WeatherForecastWithPOCOs weatherForecast = new WeatherForecastWithPOCOs();
    string fileName = "weather.json";

    public void WriteToJSON(bool encrypt = false)
    {
        Console.WriteLine("WRITING...");
        FillData();
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        var jsonString = JsonSerializer.Serialize<WeatherForecastWithPOCOs>(weatherForecast,options);
        //encrypt
        if(encrypt) jsonString = Encrypter.Encrypt(jsonString);

        File.WriteAllText(fileName, jsonString);
    }

    public void ReadFromJSON(bool decrypt = false)
    {
        Console.WriteLine("READING.....");
        var jsonString = File.ReadAllText(fileName);
        //decypt
        if(decrypt) jsonString = Encrypter.Decrypt(jsonString);
        var forecastDE = JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(jsonString);

        Console.WriteLine("TemperatureCelsius: "+ forecastDE.TemperatureCelsius);
        Console.Write("Summary Words: ");
        var length = forecastDE.SummaryWords.Length;
        for (int i =0;i<length; i++)
        {
            if(i == length-1)
            {
                Console.Write(forecastDE.SummaryWords[i]);
            }
            else
            {
                Console.Write(forecastDE.SummaryWords[i] + ", ");
            }
        }
    }

    void FillData()
    {
        weatherForecast.Date = DateTimeOffset.Now;
        weatherForecast.TemperatureCelsius = 25;
        weatherForecast.Summary = "Hot";
        weatherForecast.DatesAvailable = new List<DateTimeOffset>();
        DateTimeOffset today = new DateTimeOffset(DateTime.Now);
        weatherForecast.DatesAvailable.Add(today);
        weatherForecast.DatesAvailable.Add(today.AddDays(2));

        HighLowTemps hotTemps = new HighLowTemps();
        hotTemps.High = 60;
        hotTemps.Low = 20;

        HighLowTemps coldTemps = new HighLowTemps();
        coldTemps.High = 20;
        coldTemps.Low = -10;
        
        weatherForecast.TemperatureRanges = new Dictionary<string, HighLowTemps>();
        weatherForecast.TemperatureRanges.Add("Hot", hotTemps);
        weatherForecast.TemperatureRanges.Add("Cold", coldTemps);

        weatherForecast.SummaryWords = new string[] {"Cool","Windy","Humid"};
    }
}