using Microsoft.EntityFrameworkCore;
using CSV_Parser.Models;
using CSV_Parser.Validators;
using Microsoft.IdentityModel.Tokens;

namespace CSV_Parser.Processors
{
    public interface IRowProcessor
    {
        string[] ProcessRowValidator(string[] fields);
        void ProcessRowToObject(string[] fields, VeridionContext dbcontext);
    }

    public class FacebookCSVProcessor : IRowProcessor
    {
        public string[] ProcessRowValidator(string[] fields)
        {
            string[] validatedRow = new string[fields.Length];

            try
            {
                validatedRow[0] = Validator.ValidateDomain(fields[0]);
                validatedRow[1] = Validator.ValidateAddress(fields[1]);
                validatedRow[2] = Validator.ValidateCategory(fields[2]);
                validatedRow[3] = Validator.ValidateCity(fields[3]);
                validatedRow[4] = Validator.ValidateCountryCode(fields[4], fields[5]);
                validatedRow[5] = Validator.ValidateCountryName(fields[5]);
                validatedRow[6] = fields[6].IsNullOrEmpty() ? null : fields[6];
                validatedRow[7] = Validator.ValidateEmail(fields[7]);
                validatedRow[8] = Validator.ValidateUrl(fields[8]);
                validatedRow[9] = Validator.ValidateName(fields[9]);
                validatedRow[10] = Validator.ValidatePageType(fields[10]);
                validatedRow[11] = Validator.ValidatePhone(fields[11]);
                validatedRow[12] = Validator.ValidateCountryCode(fields[12], fields[5]);
                validatedRow[13] = Validator.ValidateRegionCode(fields[13]);
                validatedRow[14] = Validator.ValidateRegioName(fields[14]);
                validatedRow[15] = Validator.ValidateZipCode(fields[15]);
            }
            catch
            {
                throw;
            }

            return validatedRow;
        }

        public void ProcessRowToObject(string[] fields, VeridionContext dbcontext)
        {
            Facebook row = new()
            {
                Domain = fields[0],
                Address = fields[1],
                Categories = fields[2],
                City = fields[3],
                CountryCode = fields[4],
                CountryName = fields[5],
                Description = fields[6],
                Email = fields[7],
                Link = fields[8],
                Name = fields[9],
                PageType = fields[10],
                Phone = fields[11],
                PhoneCountryCode = fields[12],
                RegionCode = fields[13],
                RegionName = fields[14],
                ZipCode = fields[15]
            };
            dbcontext.Add(row);
        }
    }

    public class GoogleCSVProcessor : IRowProcessor
    {
        public string[] ProcessRowValidator(string[] fields)
        {
            string[] validatedRow = new string[fields.Length];

            try
            {
                validatedRow[0] = Validator.ValidateAddress(fields[0]);
                validatedRow[1] = Validator.ValidateCategory(fields[1]);
                validatedRow[2] = Validator.ValidateCity(fields[2]);
                validatedRow[3] = Validator.ValidateCountryCode(fields[3], fields[4]);
                validatedRow[4] = Validator.ValidateCountryName(fields[4]);
                validatedRow[5] = Validator.ValidateName(fields[5]);
                validatedRow[6] = Validator.ValidatePhone(fields[6]);
                validatedRow[7] = Validator.ValidateCountryCode(fields[7], fields[4]);
                validatedRow[8] = Validator.ValidateAddress(fields[8]);
                validatedRow[9] = Validator.ValidateRawPhone(fields[9]);
                validatedRow[10] = Validator.ValidateRegionCode(fields[10]);
                validatedRow[11] = Validator.ValidateRegioName(fields[11]);
                validatedRow[12] = fields[12].IsNullOrEmpty() ? null : fields[12];
                validatedRow[13] = Validator.ValidateZipCode(fields[13]);
                validatedRow[14] = Validator.ValidateDomain(fields[14]);
            }
            catch
            {
                throw;
            }

            return validatedRow;
        }

        public void ProcessRowToObject(string[] fields, VeridionContext dbcontext)
        {
            Google row = new()
            {
                Address = fields[0],
                Category = fields[1],
                City = fields[2],
                CountryCode = fields[3],
                CountryName = fields[4],
                Name = fields[5],
                Phone = fields[6],
                PhoneCountryCode = fields[7],
                RawAddress = fields[8],
                RawPhone = fields[9],
                RegionCode = fields[10],
                RegionName = fields[11],
                Text = fields[12],
                ZipCode = fields[13],
                Domain = fields[14]
            };
            dbcontext.Add(row);
        }
    }

    public class WebsiteCSVProcessor : IRowProcessor
    {
        public string[] ProcessRowValidator(string[] fields)
        {
            string[] validatedRow = new string[fields.Length];
            try
            {
                validatedRow[0] = Validator.ValidateDomain(fields[0]);
                validatedRow[1] = Validator.ValidateTLD(fields[1], fields[0]);
                validatedRow[2] = Validator.ValidateLanguage(fields[2]);
                validatedRow[3] = Validator.ValidateName(fields[3]);
                validatedRow[4] = Validator.ValidateCity(fields[4]);
                validatedRow[5] = Validator.ValidateCountryName(fields[5]);
                validatedRow[6] = Validator.ValidateRegioName(fields[6]);
                validatedRow[7] = Validator.ValidatePhone(fields[7]);
                validatedRow[8] = Validator.ValidateName(fields[8]);
                validatedRow[9] = Validator.ValidateTLD(fields[9], fields[0]);
                validatedRow[10] = Validator.ValidateCategory(fields[10]);
            }
            catch
            {
                throw;
            }

            return validatedRow;
        }

        public void ProcessRowToObject(string[] fields, VeridionContext dbcontext)
        {
            Website row = new()
            {
                RootDomain = fields[0],
                DomainSuffix = fields[1],
                Language = fields[2],
                LegalName = fields[3],
                MainCity = fields[4],
                MainCountry = fields[5],
                MainRegion = fields[6],
                Phone = fields[7],
                SiteName = fields[8],
                Tld = fields[9],
                SCategory = fields[10],
            };
            dbcontext.Add(row);
        }
    }
}
