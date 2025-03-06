!!!! For this application to work you need to create the database.(you can use SQLQueries.sql after to create tables, indexes and procedures necessary for the database. Just copy and paste in a query windows in sql.).
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
