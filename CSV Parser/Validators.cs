using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using CSV_Parser.ImportHelpers;
using ISO3166;

namespace CSV_Parser.Validators
{
    public partial class Validator
    {
        public static string? ValidateDomain(string field)
        {
            if (string.IsNullOrWhiteSpace(field)) return null;
            else if (field.Length > 255) throw new ArgumentOutOfRangeException("Domain", field.Length, "Lenght of field exceeds 255 characters.");
            return DomainRegex().IsMatch(field) ? field.Trim() : null;
        }

        public static string? ValidateAddress(string field)
        {
            if (field.Length <= 500)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Address", field.Length, "Lenght of field exceeds 500 characters.");
            }
        }

        public static string? ValidateCategory(string field)
        {
            if (field.Length <= 500)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Category", field.Length, "Lenght of field exceeds 500 characters.");
            }
        }

        public static string? ValidateCity(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return null;
            field = CityRegex().Replace(field, "").Trim();
            if (field.Length <= 100)
            {
                return field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("City", field.Length, "Lenght of field exceeds 100 characters.");
            }
        }

        public static string? ValidateCountryCode(string field, string field1)
        {
            if (field == "001" || field == "1")
            {
                string a = field;
            }
            var countrylist = Country.List;
            string fieldUpper = field.ToUpper();
            var country = countrylist.FirstOrDefault(c => c.TwoLetterCode == fieldUpper.Trim());
            if (country == null)
            {
                TextInfo txt = CultureInfo.CurrentCulture.TextInfo;
                field1 = txt.ToTitleCase(field1);
                country = countrylist.FirstOrDefault(c => c.Name.Contains(field1.Trim()));
                if (country == null)
                {
                    field = string.Empty;
                }
                else
                {
                    field = country.TwoLetterCode;
                }
            }
            return field.Length <= 2 ? country != null ? field.Trim() : null : throw new ArgumentOutOfRangeException("Country Code", field.Length, "Lenght of field exceeds 2 characters.");

        }

        public static string? ValidateCountryName(string field)
        {
            if (field.Length <= 100)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Country Name", field.Length, "Lenght of field exceeds 100 characters.");
            }
        }

        public static string? ValidateEmail(string field)
        {
            if (string.IsNullOrWhiteSpace(field)) return null;
            else if (field.Length > 255) throw new ArgumentOutOfRangeException("Email", field.Length, "Lenght of field exceeds 255 characters.");
            try
            {
                var addr = new MailAddress(field);
                return addr.Address == field ? field.Trim() : null;
            }
            catch
            {
                return null; // if the email is not in the corect format, we don't have the email.
            }
        }

        public static string? ValidateUrl(string field)
        {
            if (string.IsNullOrWhiteSpace(field)) return null;
            else if (field.Length > 2083) throw new ArgumentOutOfRangeException("Url", field.Length, "Lenght of field exceeds 2083 characters.");
            return Uri.TryCreate(field, UriKind.Absolute, out _) ? field.Trim() : null;
        }

        public static string? ValidateName(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return null;
            field = ImportHelper.NormalizeStyledCharacters(field);
            return field.Length > 255 ? null : field.StartsWith("http", StringComparison.CurrentCultureIgnoreCase) ? null : field; // if name is larger than 255 chars or starts with http, we don't need the name.
        }

        public static string? ValidatePageType(string field)
        {
            if (field.Length <= 50)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Page Type", field.Length, "Lenght of field exceeds 50 characters.");
            }
        }

        public static string? ValidatePhone(string field)
        {
            if (string.IsNullOrWhiteSpace(field)) return null;
            else if (field.Length > 20) throw new ArgumentOutOfRangeException("Phone", field.Length, "Lenght of field exceeds 20 characters.");
            else
            {
                field = field.Trim();
                if (!field.StartsWith('+'))
                    field = "+" + field;
            }
            return PhoneRegex().IsMatch(field) ? field : null;
        }

        public static string? ValidateRegionCode(string field)
        {
            if (field.Length <= 4)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Region Code", field.Length, "Lenght of field exceeds 4 characters.");
            }
        }

        public static string? ValidateRegioName(string field)
        {
            if (field.Length <= 100)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Region Name", field.Length, "Lenght of field exceeds 100 characters.");
            }
        }

        public static string? ValidateZipCode(string field)
        {
            if (string.IsNullOrWhiteSpace(field)) return null;

            if (field.Length > 20)
            {
                // extracts zip code if it can.
                string? extractedZip = ExtractZipCode(field);
                if (extractedZip != null)
                {
                    return extractedZip;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

        public static string? ValidateLanguage(string field)
        {
            if (field.Length <= 2)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                return null;
            }
        }

        public static string? ValidateRawPhone(string field)
        {
            field = field.Replace(" ","").Replace("-","").Trim();
            if (field.Length <= 20)
            {
                return string.IsNullOrWhiteSpace(field) ? null : field;
            }
            else
            {
                throw new ArgumentOutOfRangeException("RawPhone", field.Length, "Lenght of field exceeds 20 characters");
            }
        }

        public static string? ValidateTLD(string tldField, string domainField)
        {
            string? extractedTLD = ExtractTLD(domainField); // extracting tld from domain, if possible.

            // if TLD is valid and identical to extracted tld from domain, return tldField
            if (!string.IsNullOrWhiteSpace(tldField) && extractedTLD == tldField.ToLower().Trim())
                return tldField.ToLower().Trim();

            // if extracted tld from domain is valid, return that
            if (!string.IsNullOrWhiteSpace(extractedTLD))
                return extractedTLD;

            // if we can't extract any tld, we validate the one we already have and return it or return null
            return (!string.IsNullOrWhiteSpace(tldField) && tldField.Length <= 10) ? tldField.ToLower().Trim() : null;
        }
    

        private static string? ExtractZipCode(string input)
        {
            Match match = ZipCodeRegex().Match(input);
            return match.Success ? match.Value.Trim() : null;
        }

        private static string? ExtractTLD(string? domain)
        {
            if (string.IsNullOrWhiteSpace(domain)) return null;

            // Regex for a extrage TLD-ul (maxim 10 caractere)
            Match match = TLDExtractRegex().Match(domain);
            return match.Success ? match.Groups[1].Value.ToLower().Trim() : null;
        }

        [GeneratedRegex(@"^(?!:\/\/)([a-zA-Z0-9-_]+\.)+[a-zA-Z]{2,6}$")]
        private static partial Regex DomainRegex();
        
        [GeneratedRegex(@"^\+?[0-9\s\-\(\)]{7,15}$")]
        private static partial Regex PhoneRegex();
        
        [GeneratedRegex(@"\s*\(.*?\)\s*")]
        private static partial Regex CityRegex();
        
        [GeneratedRegex(@"\.([a-zA-Z]{2,10})$", RegexOptions.IgnoreCase, "en-US")]
        private static partial Regex TLDExtractRegex();

        // regex for canada zip codes for now, this should be moved in app settings, and more regex for different countries added.
        [GeneratedRegex(@"\b[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d\b", RegexOptions.IgnoreCase, "en-US")]
        private static partial Regex ZipCodeRegex();
    }
}
