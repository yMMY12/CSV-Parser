using System;
using System.Collections.Generic;

namespace CSV_Parser.Models;

public partial class Website
{
    public int Id { get; set; }

    public string? RootDomain { get; set; }

    public string? DomainSuffix { get; set; }

    public string? Language { get; set; }

    public string? LegalName { get; set; }

    public string? MainCity { get; set; }

    public string? MainCountry { get; set; }

    public string? MainRegion { get; set; }

    public string? Phone { get; set; }

    public string? SiteName { get; set; }

    public string? Tld { get; set; }

    public string? SCategory { get; set; }
}
