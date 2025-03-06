using CSV_Parser.Factories;
using CSV_Parser.ImportHelpers;
using CSV_Parser.Models;
using CSV_Parser.Processors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace CSV_Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VeridionContext _dbcontext;

        public MainWindow()
        {
            InitializeComponent();

            _dbcontext = new VeridionContext();
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Select a CSV file"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txbCSVPath.Text = openFileDialog.FileName;
            }
        }

        private void BtnVerifyCSV_Click(object sender, RoutedEventArgs e)
        {
            string filePath = txbCSVPath.Text;
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Select a valid CSV file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ProcessCSV(filePath);
        }

        private void ProcessCSV(string filePath)
        {
            CSVProcessorFactory factory = new();
            string directory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string validFolder = Path.Combine(directory, "valid rows");
            string invalidFolder = Path.Combine(directory, "invalid rows");
            string invalidFileFolder = Path.Combine(directory, "invalid file");
            string filetype = string.Empty;

            string validFile = Path.Combine(validFolder, fileName + "_valid.csv");
            string invalidFile = Path.Combine(invalidFolder, fileName + "_invalid.csv");
            string invalidFileType = Path.Combine(invalidFileFolder, fileName + "_invalidFileType.csv");


            IRowProcessor processor;

            switch (fileName.ToLower())
            {
                case var _ when fileName.Contains("facebook"):
                    processor = CSVProcessorFactory.GetProcessor("facebook");
                    break;

                case var _ when fileName.Contains("google"):
                    processor = CSVProcessorFactory.GetProcessor("google");
                    break;

                case var _ when fileName.Contains("website"):
                    processor = CSVProcessorFactory.GetProcessor("website");
                    break;

                default:
                    Directory.CreateDirectory(invalidFileFolder);
                    File.Move(filePath, invalidFileType);
                    MessageBox.Show($"File type was not recognized!!!\nInvalid file was saved in: {invalidFileType}", "Fail", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
            }

            List<string> validRows = [];
            List<string> invalidRows = [];

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2)
            {
                MessageBox.Show("The CSV file is empty or missing data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            char delimiter = ImportHelper.DetectDelimiter(lines[0]);
            int expectedColumns = ImportHelper.CountColumns(lines[0], delimiter);

            validRows.Add(lines[0]);
            invalidRows.Add(lines[0] + ",ErrorMessage");

            string accumulatedLine = "";
            foreach (var line in lines.Skip(1))
            {
                accumulatedLine += (accumulatedLine == "" ? "" : "\n") + line;
                string[] fields = ImportHelper.ParseCsvLine(accumulatedLine, delimiter).Select(f => f.TrimStart(delimiter)).ToArray();

                if (fields.Length == expectedColumns)
                {
                    try
                    {
                        string[] validatedRow = processor.ProcessRowValidator(fields);
                        processor.ProcessRowToObject(validatedRow, _dbcontext);
                    }
                    catch (Exception ex)
                    {
                        invalidRows.Add(accumulatedLine + "," + ex.Message.Replace("\r\n", ". "));
                    }
                    accumulatedLine = "";
                    continue;
                }
                else if (fields.Length >= expectedColumns)
                {
                    string correctedLine = ImportHelper.CorrectErrors(accumulatedLine, delimiter);
                    string[] correctedFields = ImportHelper.ParseCsvLine(correctedLine, delimiter).Select(f => f.TrimStart(delimiter)).ToArray();

                    if (correctedFields.Length == expectedColumns && !correctedFields.Any(f => f.Length > 10000))
                    {
                        try
                        {
                            string[] validatedRow = processor.ProcessRowValidator(correctedFields);
                            processor.ProcessRowToObject(validatedRow, _dbcontext);
                        }
                        catch (Exception ex)
                        {
                            invalidRows.Add(accumulatedLine + ex.Message.Replace("\r\n", ". "));
                        }
                    }
                    else
                    {
                        invalidRows.Add(accumulatedLine + ", Too manny columns");
                    }
                    accumulatedLine = "";
                }
                else
                {
                    continue;
                }

            }

            _dbcontext.SaveChanges();

            if (invalidRows.Count > 1)
            {
                Directory.CreateDirectory(invalidFolder);
                File.WriteAllLines(invalidFile, invalidRows);
            }

            File.Delete(filePath);

            MessageBox.Show($"CSV file processed successfully!\nValid rows saved in: {validFolder}\nInvalid rows saved in: {invalidFolder}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void BtnExecuteProcedure_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnExecuteProcedure.IsEnabled = false;
                _dbcontext.Database.SetCommandTimeout(300);
                await _dbcontext.Database.ExecuteSqlRawAsync("EXEC ExecuteBigData");
                MessageBox.Show("Procedure finished executing successfully.", "Finished!!", MessageBoxButton.OK, MessageBoxImage.Information);

                RefreshDataGrid();
                btnExecuteProcedure.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefreshGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            var allinfo = _dbcontext.AllInfos.Select(ai => new { ai.Category, ai.Address, ai.City, ai.RegionName, ai.CountryName, ai.Phone, ai.Name }).ToList();
            grdAllInfo.ItemsSource = allinfo;
        }
    }
}