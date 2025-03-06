For this assignment I used .net8 wpf descktop application for normalizing and validating data from the CSV files, and SQL server for importing normalized and validated data from the CSV files.

!!!! For this application to work you need to create the database.(you can use SQLQueries.sql file after database creation to create tables, indexes and procedures necessary for the database. Just copy and paste in a query windows in sql.).
!!!! Also you need to update the connection string in the project file VeridionContext.cs
!!!! I made everything manual in this example, but everything can be automated very easily.


Description of the CSV Import and Processing Process

1. Data Import
The application imports CSV files containing raw data.
These files may contain errors, duplicates, or inconsistencies.
The data is stored in a temporary database for preprocessing.

2. Data Processing and Cleaning
Invalid data is removed or marked.
Formats are normalized (e.g., phone numbers, names).
Extra spaces and special characters are removed if necessary.

3. Loading the Normalized Data into the Database into Specific Tables
The cleaned and normalized data is then loaded into specific tables for each dataset in the database.

4. Join Process Between Datasets Using Stored Procedures
The imported data is progressively combined through a series of JOIN operations, using different keys for joining.
This is done through stored procedures in the database (the query.txt file contains all the necessary queries for the database, table creation, indexing on those tables, and finally the procedures in SQL Server).
a) First JOIN (on name and phone number)
Records with both the same name and phone number are combined.
Before performing this JOIN, all records that have already been associated are removed from the original datasets.
b) Second JOIN (on name only)
The remaining data is combined using name as the identifier.
Records that have already been associated in the previous step are filtered out.
c) Third JOIN (on phone number only)
The rest of the data is joined based on the phone number.
Data that has already been included in previous steps is removed.
d) Fourth JOIN (on domain)
A JOIN is performed based on the domain (probably from email or website).
The same filtering process as in the previous steps is applied.
e) Final UNION of Remaining Data
Data that hasn't been joined in any of the previous steps is combined into a single dataset.
This step ensures that all records are included, even if they couldn't be associated through the previous JOINs.

5. Efficiency Optimizations
Progressive Filtering – At each step, data that has already been processed is eliminated to reduce execution time and resource consumption.
Optimal Indexing – The keys used in the JOINs are indexed to speed up the process.
Use of Stored Procedures – The process is managed through SQL procedures for efficiency and modularity.



!!!! Application !!!!

Data Import Process Description
The data import process in this application is designed to handle CSV files containing information related to Facebook, Google, and Websites. The process includes several key steps, from selecting the CSV file to processing its contents and saving the valid data to the database.

Selecting the CSV File:

The user clicks the "Browse" button (BtnBrowse_Click) to open a file dialog for selecting a CSV file.
The selected file path is then displayed in a text box (txbCSVPath).
Verifying and Processing the CSV:

When the user clicks the "Verify CSV" button (BtnVerifyCSV_Click), the application first checks if the file exists at the provided path.
If the file exists, the ProcessCSV method is called to process the file. If the file is invalid or missing, the application prompts the user with an error message.
CSV Processing:

Determining File Type:
The ProcessCSV method reads the file name to determine the file type (either "facebook", "google", or "website"). The CSVProcessorFactory.GetProcessor() method is used to get the appropriate processor for the file type.
If the file type cannot be determined, it is moved to the "invalid file" folder and the user is notified.
Validating and Parsing the CSV Data:
The method reads the CSV file line by line and checks if the number of columns matches the expected number based on the first row.
The DetectDelimiter method helps identify the delimiter used in the CSV, and CountColumns determines the number of columns.
For each line, the application tries to validate and parse the data using the selected processor (ProcessRowValidator and ProcessRowToObject).
Error Handling:
If the row has incorrect data (e.g., missing columns or invalid values), the application tries to correct the line (CorrectErrors), re-validates it, and attempts to process it again.
Any invalid rows are logged into a separate file (saved in the "invalid rows" folder) with an error message.
If the row passes validation, it is added to the database using _dbcontext.
Saving Valid and Invalid Data:

Valid Rows: The valid rows are saved in a folder called "valid rows". The data is also processed and added to the database.
Invalid Rows: Invalid rows are written to an "invalid rows" CSV file for later review. The application also handles rows with too many columns or other structural issues.
The original CSV file is deleted after processing.
Database Operations:

After processing all rows, the _dbcontext.SaveChanges() method is called to commit the changes to the database.
This involves saving the data for the current file (Facebook, Google, or Website) into the corresponding tables.
Executing SQL Stored Procedure:

The user can also execute a stored procedure called ExecuteBigData by clicking the "Execute Procedure" button (BtnExecuteProcedure_Click).
The ExecuteBigData procedure is executed asynchronously via ExecuteSqlRawAsync, and the application waits for it to finish. After completion, the user is notified of the success and the data grid is refreshed to show the updated results.
Refreshing the Data Grid:

The RefreshDataGrid method is called whenever the user clicks the "Refresh Grid" button (BtnRefreshGrid_Click). It fetches data from the AllInfos table in the database and displays it in the data grid (grdAllInfo).
Code Design and Justification
CSV File Parsing and Validation:

The application uses the CSVProcessorFactory to abstract the logic of parsing the CSV data and processing it according to the file type. This makes the code modular and easier to extend if additional file types need to be supported.
The validation of rows ensures that only properly formatted data is imported, and any issues are logged for review. This avoids corrupting the database with incorrect data.
Error Handling:

The application ensures that errors during the CSV processing (such as invalid rows or file type mismatches) are handled gracefully. Invalid data is saved separately, and the user is notified accordingly.
This process helps ensure data integrity and provides a mechanism for troubleshooting and fixing problematic data entries.
Asynchronous SQL Execution:

The stored procedure execution is done asynchronously (ExecuteSqlRawAsync), preventing the UI from freezing while waiting for the procedure to finish. This ensures a responsive user experience even with large datasets.
Overall Process Flow
The user selects a CSV file for import.
The file type is determined, and the file is processed by the corresponding processor (Facebook, Google, or Website).
Data is validated and parsed, and any invalid rows are logged for later review.
Valid data is saved to the database.
If needed, the user can execute a stored procedure to further process the data.
The user can refresh the data grid to view the latest data from the database.

Conclusion
This application provides a comprehensive and user-friendly approach to importing CSV data, validating it, and saving it into a database. The error handling mechanisms and data validation ensure that only accurate and properly formatted data are stored, and any invalid entries are flagged for correction.



!!!! SQL SERVER

Process Description for Data Joining and Integration
The main goal of this process is to integrate data from multiple tables (Facebook, Google, Website) into a single table called AllInfo, which contains comprehensive information about the same entities (e.g., a company, a website, or a social media profile). Given the large volume of data, similarity algorithms such as Jaccard similarity or Levenshtein distance were not viable due to the time required for processing. Instead, we chose to use JOIN operations on specific columns that could help in correlating and identifying relevant data.

Explanation of the Process and the Chosen Approach:
Purpose of Joining and Selecting Relevant Columns: The goal of this process is to consolidate data from the Facebook, Google, and Website tables into the AllInfo table. Each of these tables contains information about the same entities, but from different sources. The tables include attributes such as name, phone number, address, category, city, and other contact details. Selecting the right columns for joining is essential to ensure the resulting data is clean, correct, and as accurate as possible.

Using Name and Phone Number for Joining:

Name: The first step is performing a JOIN on the Name column. This helps eliminate exact or very similar duplicate entries, as many companies may share common names, but the associated information will be different. For example, "Tech Solutions" on Facebook and "Tech Solutions" on Google may represent different entities. Joining on the name column helps reduce the chances of combining irrelevant data.

Phone Number: After the initial join on name, the next step is performing a JOIN on Phone. This is useful to exclude the possibility of associating information that has similar names but different phone numbers. This second layer of filtering helps eliminate false matches and adds an additional level of precision to the join process.

Eliminating False Matches:

By performing successive joins on the name and phone number, we significantly reduce the number of incorrect associations, such as those between different entities that happen to have similar names but are actually distinct.
These joins help eliminate false matches that might arise with domains like etsy.com or instagram.com, which are irrelevant in this context. For example, while the name and phone number might be similar, the domain is a unique identifier that would exclude entries that don't match correctly.
Final Outcome: After performing these successive joins to eliminate irrelevant records and reduce processing time, a much smaller and more accurate dataset remains. In the end, records that cannot be associated through the name and phone number are kept exactly as they are in the AllInfo table.

Why This Approach Was Chosen:

Performance: Unlike similarity algorithms like Jaccard or Levenshtein, which are very computationally expensive when working with large datasets, this JOIN-based method is much faster and more efficient.
Reliability: Using name and phone number as the primary identifiers is a tested and effective way to reduce join errors without sacrificing too much useful information.
Flexibility: This approach allows for easy expansion in the future, for example, by adding other identifying columns such as address or domain.
Conclusion:
In conclusion, the process of joining data from the Facebook, Google, and Website tables into a single AllInfo table uses a JOIN operation based on name and phone number to eliminate false matches and reduce the dataset size. This method was chosen to improve performance and accuracy, given the large volume of data, and to ensure that the integrated information is relevant and correct.
