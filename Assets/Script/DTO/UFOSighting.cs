using System;
using System.Collections.Generic;

[Serializable]
public class UFOSighting
{
    public string Date { get; set; }
    public string Time { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Shape { get; set; }
    public double Duration { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}