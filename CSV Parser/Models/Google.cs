using System;
using System.Collections.Generic;

namespace CSV_Parser.Models;

public partial class Google
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? Category { get; set; }

    public string? City { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? PhoneCountryCode { get; set; }

    public string? RawAddress { get; set; }

    public string? RawPhone { get; set; }

    public string? RegionCode { get; set; }

    public string? RegionName { get; set; }

    public string? Text { get; set; }

    public string? ZipCode { get; set; }

    public string? Domain { get; set; }
}
