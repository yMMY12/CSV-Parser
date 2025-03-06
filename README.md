!!!! For this application to work you need to create the database.(you can use query.txt after to create tables, indexes and procedures necessary for the database. Just copy and paste in a query windows in sql.).
!!!! Also you need to update the connection string in the project file VeridionContext.cs


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
