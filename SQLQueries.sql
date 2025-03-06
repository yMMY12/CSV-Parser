GO

/****** Object:  Table [dbo].[Facebook]    Script Date: 3/6/2025 3:49:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Facebook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Domain] [nvarchar](255) NULL,
	[Address] [nvarchar](500) NULL,
	[Categories] [nvarchar](500) NULL,
	[City] [nvarchar](100) NULL,
	[Country_Code] [char](2) NULL,
	[Country_Name] [nvarchar](100) NULL,
	[Description] [text] NULL,
	[Email] [nvarchar](255) NULL,
	[Link] [nvarchar](2083) NULL,
	[Name] [nvarchar](255) NULL,
	[Page_Type] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Phone_Country_Code] [char](2) NULL,
	[Region_Code] [char](4) NULL,
	[Region_Name] [nvarchar](100) NULL,
	[Zip_Code] [nvarchar](20) NULL,
 CONSTRAINT [PK_Facebook] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_domain]    Script Date: 3/6/2025 3:49:49 PM ******/
CREATE NONCLUSTERED INDEX [idx_domain] ON [dbo].[Facebook]
(
	[Domain] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_name]    Script Date: 3/6/2025 3:49:49 PM ******/
CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[Facebook]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_name_phone]    Script Date: 3/6/2025 3:49:49 PM ******/
CREATE NONCLUSTERED INDEX [idx_name_phone] ON [dbo].[Facebook]
(
	[Name] ASC,
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_phone]    Script Date: 3/6/2025 3:49:49 PM ******/
CREATE NONCLUSTERED INDEX [idx_phone] ON [dbo].[Facebook]
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Google](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[Category] [nvarchar](500) NULL,
	[City] [nvarchar](100) NULL,
	[Country_Code] [char](2) NULL,
	[Country_Name] [nvarchar](100) NULL,
	[Name] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[Phone_Country_Code] [char](2) NULL,
	[Raw_Address] [nvarchar](500) NULL,
	[Raw_Phone] [nvarchar](20) NULL,
	[Region_Code] [char](4) NULL,
	[Region_Name] [nvarchar](100) NULL,
	[Text] [text] NULL,
	[Zip_Code] [nvarchar](20) NULL,
	[Domain] [nvarchar](255) NULL,
 CONSTRAINT [PK_google] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_google_domain]    Script Date: 3/6/2025 3:50:11 PM ******/
CREATE NONCLUSTERED INDEX [idx_google_domain] ON [dbo].[Google]
(
	[Domain] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_google_name]    Script Date: 3/6/2025 3:50:11 PM ******/
CREATE NONCLUSTERED INDEX [idx_google_name] ON [dbo].[Google]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_google_name_phone]    Script Date: 3/6/2025 3:50:11 PM ******/
CREATE NONCLUSTERED INDEX [idx_google_name_phone] ON [dbo].[Google]
(
	[Name] ASC,
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_google_phone]    Script Date: 3/6/2025 3:50:11 PM ******/
CREATE NONCLUSTERED INDEX [idx_google_phone] ON [dbo].[Google]
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Website](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[root_domain] [nvarchar](255) NULL,
	[domain_suffix] [char](10) NULL,
	[language] [nvarchar](10) NULL,
	[legal_name] [nvarchar](255) NULL,
	[main_city] [nvarchar](100) NULL,
	[main_country] [nvarchar](100) NULL,
	[main_region] [nvarchar](100) NULL,
	[phone] [nvarchar](50) NULL,
	[site_name] [nvarchar](255) NULL,
	[tld] [char](10) NULL,
	[s_category] [nvarchar](500) NULL,
 CONSTRAINT [PK_website] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_website_legal_name]    Script Date: 3/6/2025 3:50:16 PM ******/
CREATE NONCLUSTERED INDEX [idx_website_legal_name] ON [dbo].[Website]
(
	[legal_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_website_legal_name_phone]    Script Date: 3/6/2025 3:50:16 PM ******/
CREATE NONCLUSTERED INDEX [idx_website_legal_name_phone] ON [dbo].[Website]
(
	[legal_name] ASC,
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_website_phone]    Script Date: 3/6/2025 3:50:16 PM ******/
CREATE NONCLUSTERED INDEX [idx_website_phone] ON [dbo].[Website]
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [idx_website_root_domain]    Script Date: 3/6/2025 3:50:16 PM ******/
CREATE NONCLUSTERED INDEX [idx_website_root_domain] ON [dbo].[Website]
(
	[root_domain] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AllInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[facebook_id] [int] NULL,
	[google_id] [int] NULL,
	[website_id] [int] NULL,
	[Name] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](500) NULL,
	[Category] [nvarchar](500) NULL,
	[City] [nvarchar](100) NULL,
	[Country_Code] [char](2) NULL,
	[Country_Name] [nvarchar](100) NULL,
	[Description] [text] NULL,
	[Email] [nvarchar](255) NULL,
	[Phone_Country_Code] [char](2) NULL,
	[Region_Code] [char](4) NULL,
	[Region_Name] [nvarchar](100) NULL,
	[Zip_Code] [nvarchar](20) NULL,
	[Domain] [nvarchar](255) NULL,
 CONSTRAINT [PK__AllInfo__3213E83FBFE077AF] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE PROCEDURE [dbo].[JoinByNameAndPhone]
AS
BEGIN
    INSERT INTO [dbo].[AllInfo] (
        facebook_id, google_id, website_id, Name, Phone, Address, Category, City, 
        Country_Code, Country_Name, Description, Email, Phone_Country_Code, 
        Region_Code, Region_Name, Zip_Code, Domain
    )
    SELECT 
        f.id AS facebook_id,
        g.id AS google_id,
        w.id AS website_id,
        COALESCE(f.Name, g.Name, w.legal_name) AS Name,
        COALESCE(f.Phone, g.Phone, w.phone) AS Phone,
        COALESCE(f.Address, g.Address, w.main_city) AS Address,
        COALESCE(f.Categories, g.Category, w.s_category) AS Category,
        COALESCE(f.City, g.City, w.main_city) AS City,
        COALESCE(f.Country_Code, g.Country_Code, null) AS Country_Code, -- Website doesn't have Country_Code.
        COALESCE(f.Country_Name, g.Country_Name, w.main_country) AS Country_Name,
        COALESCE(f.Description, g.Text) AS Description, -- Website doesn't have Description.
        COALESCE(f.Email, NULL) AS Email, -- Google and Website don't have Email
        COALESCE(f.Phone_Country_Code, g.Phone_Country_Code, null) AS Phone_Country_Code, -- Website doesn't have Phone_Country_Code
        COALESCE(f.Region_Code, g.Region_Code, null) AS Region_Code, -- Website doesn't have Region_Code
        COALESCE(f.Region_Name, g.Region_Name, w.main_region) AS Region_Name,
        COALESCE(f.Zip_Code, g.Zip_Code, NULL) AS Zip_Code, -- Website doesn't have Zip_Code
        COALESCE(f.Domain, g.Domain, w.root_domain) AS Domain
    FROM 
        (SELECT * FROM [dbo].[Facebook] 
         WHERE id NOT IN (SELECT facebook_id FROM [dbo].[AllInfo] WHERE facebook_id IS NOT NULL)) f
    INNER JOIN 
        (SELECT * FROM [dbo].[Google] 
         WHERE id NOT IN (SELECT google_id FROM [dbo].[AllInfo] WHERE google_id IS NOT NULL)) g 
        ON f.Name = g.Name AND f.Phone = g.Phone
    INNER JOIN 
        (SELECT * FROM [dbo].[Website] 
         WHERE id NOT IN (SELECT website_id FROM [dbo].[AllInfo] WHERE website_id IS NOT NULL)) w 
        ON (f.Name = w.legal_name OR g.Name = w.legal_name)
        AND (f.Phone = w.phone OR g.Phone = w.phone);
END;
GO


CREATE PROCEDURE [dbo].[JoinByName]
AS
BEGIN
    INSERT INTO [dbo].[AllInfo] (
        facebook_id, google_id, website_id, Name, Phone, Address, Category, City, 
        Country_Code, Country_Name, Description, Email, Phone_Country_Code, 
        Region_Code, Region_Name, Zip_Code, Domain
    )
SELECT 
        f.id AS facebook_id,
        g.id AS google_id,
        w.id AS website_id,
        COALESCE(f.Name, g.Name, w.legal_name) AS Name,
        COALESCE(f.Phone, g.Phone, w.phone) AS Phone,
        COALESCE(f.Address, g.Address, w.main_city) AS Address,
        COALESCE(f.Categories, g.Category, w.s_category) AS Category,
        COALESCE(f.City, g.City, w.main_city) AS City,
        COALESCE(f.Country_Code, g.Country_Code, null) AS Country_Code, -- Website doesn't have Country_Code.
        COALESCE(f.Country_Name, g.Country_Name, w.main_country) AS Country_Name,
        COALESCE(f.Description, g.Text) AS Description, -- Website doesn't have Description.
        COALESCE(f.Email, NULL) AS Email, -- Google and Website don't have Email
        COALESCE(f.Phone_Country_Code, g.Phone_Country_Code, null) AS Phone_Country_Code, -- Website doesn't have Phone_Country_Code
        COALESCE(f.Region_Code, g.Region_Code, null) AS Region_Code, -- Website doesn't have Region_Code
        COALESCE(f.Region_Name, g.Region_Name, w.main_region) AS Region_Name,
        COALESCE(f.Zip_Code, g.Zip_Code, NULL) AS Zip_Code, -- Website doesn't have Zip_Code
        COALESCE(f.Domain, g.Domain, w.root_domain) AS Domain
    FROM (SELECT * FROM [dbo].[Facebook] WHERE id NOT IN (SELECT facebook_id FROM [dbo].[AllInfo] WHERE facebook_id IS NOT NULL)) f
    INNER JOIN (SELECT * FROM [dbo].[Google] WHERE id NOT IN (SELECT google_id FROM [dbo].[AllInfo] WHERE google_id IS NOT NULL)) g 
        ON f.Name = g.Name 
    INNER JOIN (SELECT * FROM [dbo].[Website] WHERE id NOT IN (SELECT website_id FROM [dbo].[AllInfo] WHERE website_id IS NOT NULL)) w 
        ON f.Name = w.legal_name
END;
GO


CREATE PROCEDURE [dbo].[JoinByPhone]
AS
BEGIN
    INSERT INTO [dbo].[AllInfo] (
        facebook_id, google_id, website_id, Name, Phone, Address, Category, City, 
        Country_Code, Country_Name, Description, Email, Phone_Country_Code, 
        Region_Code, Region_Name, Zip_Code, Domain
    )
    SELECT 
        f.id AS facebook_id,
        g.id AS google_id,
        w.id AS website_id,
        COALESCE(f.Name, g.Name, w.legal_name) AS Name,
        COALESCE(f.Phone, g.Phone, w.phone) AS Phone,
        COALESCE(f.Address, g.Address, w.main_city) AS Address,
        COALESCE(f.Categories, g.Category, w.s_category) AS Category,
        COALESCE(f.City, g.City, w.main_city) AS City,
        COALESCE(f.Country_Code, g.Country_Code, null) AS Country_Code, -- Website doesn't have Country_Code.
        COALESCE(f.Country_Name, g.Country_Name, w.main_country) AS Country_Name,
        COALESCE(f.Description, g.Text) AS Description, -- Website doesn't have Description.
        COALESCE(f.Email, NULL) AS Email, -- Google and Website don't have Email
        COALESCE(f.Phone_Country_Code, g.Phone_Country_Code, null) AS Phone_Country_Code, -- Website doesn't have Phone_Country_Code
        COALESCE(f.Region_Code, g.Region_Code, null) AS Region_Code, -- Website doesn't have Region_Code
        COALESCE(f.Region_Name, g.Region_Name, w.main_region) AS Region_Name,
        COALESCE(f.Zip_Code, g.Zip_Code, NULL) AS Zip_Code, -- Website doesn't have Zip_Code
        COALESCE(f.Domain, g.Domain, w.root_domain) AS Domain
    FROM (SELECT * FROM [dbo].[Facebook] WHERE id NOT IN (SELECT facebook_id FROM [dbo].[AllInfo] WHERE facebook_id IS NOT NULL)) f
    INNER JOIN (SELECT * FROM [dbo].[Google] WHERE id NOT IN (SELECT google_id FROM [dbo].[AllInfo] WHERE google_id IS NOT NULL)) g 
        ON f.Phone = g.Phone
    INNER JOIN (SELECT * FROM [dbo].[Website] WHERE id NOT IN (SELECT website_id FROM [dbo].[AllInfo] WHERE website_id IS NOT NULL)) w 
        ON f.Phone = w.phone
END;
GO


CREATE PROCEDURE [dbo].[JoinByDomain]
AS
BEGIN
    INSERT INTO [dbo].[AllInfo] (
        facebook_id, google_id, website_id, Name, Phone, Address, Category, City, 
        Country_Code, Country_Name, Description, Email, Phone_Country_Code, 
        Region_Code, Region_Name, Zip_Code, Domain
    )
    SELECT 
        f.id AS facebook_id,
        g.id AS google_id,
        w.id AS website_id,
        COALESCE(f.Name, g.Name, w.legal_name) AS Name,
        COALESCE(f.Phone, g.Phone, w.phone) AS Phone,
        COALESCE(f.Address, g.Address, w.main_city) AS Address,
        COALESCE(f.Categories, g.Category, w.s_category) AS Category,
        COALESCE(f.City, g.City, w.main_city) AS City,
        COALESCE(f.Country_Code, g.Country_Code, null) AS Country_Code, -- Website doesn't have Country_Code.
        COALESCE(f.Country_Name, g.Country_Name, w.main_country) AS Country_Name,
        COALESCE(f.Description, g.Text) AS Description, -- Website doesn't have Description.
        COALESCE(f.Email, NULL) AS Email, -- Google and Website don't have Email
        COALESCE(f.Phone_Country_Code, g.Phone_Country_Code, null) AS Phone_Country_Code, -- Website doesn't have Phone_Country_Code
        COALESCE(f.Region_Code, g.Region_Code, null) AS Region_Code, -- Website doesn't have Region_Code
        COALESCE(f.Region_Name, g.Region_Name, w.main_region) AS Region_Name,
        COALESCE(f.Zip_Code, g.Zip_Code, NULL) AS Zip_Code, -- Website doesn't have Zip_Code
        COALESCE(f.Domain, g.Domain, w.root_domain) AS Domain
    FROM (SELECT * FROM [dbo].[Facebook] WHERE id NOT IN (SELECT facebook_id FROM [dbo].[AllInfo] WHERE facebook_id IS NOT NULL)) f
    INNER JOIN (SELECT * FROM [dbo].[Google] WHERE id NOT IN (SELECT google_id FROM [dbo].[AllInfo] WHERE google_id IS NOT NULL)) g 
        ON f.Domain = g.Domain
    INNER JOIN (SELECT * FROM [dbo].[Website] WHERE id NOT IN (SELECT website_id FROM [dbo].[AllInfo] WHERE website_id IS NOT NULL)) w 
        ON f.Domain = w.root_domain OR g.Domain = w.root_domain
END;
GO


CREATE PROCEDURE [dbo].[JoinNonMatchingData]
AS
BEGIN
    INSERT INTO [dbo].[AllInfo] (
        facebook_id, google_id, website_id, Name, Phone, Address, Category, City, 
        Country_Code, Country_Name, Description, Email, Phone_Country_Code, 
        Region_Code, Region_Name, Zip_Code, Domain
    )
    SELECT id AS facebook_id
      ,null AS google_id
      ,null AS website_id
      ,Name AS Name
      ,Phone AS Phone
      ,Address AS Address
      ,Categories AS Category
      ,City AS City
      ,Country_Code AS Country_Code
      ,Country_Name AS Country_Name
      ,Cast(Description as nvarchar(MAX)) AS Description
      ,Email AS Email
      ,Phone_Country_Code AS Phone_Country_Code
      ,Region_Code AS Region_Code
      ,Region_Name AS Region_Name
      ,Zip_Code AS Zip_Code
	  ,Domain AS Domain
  FROM [dbo].[Facebook] 
 WHERE id NOT IN (SELECT facebook_id FROM [dbo].[AllInfo] WHERE facebook_id IS NOT NULL)
UNION
SELECT null AS facebook_id
      ,id AS google_id
	  ,null AS website_id
      ,Name AS Name
      ,Phone AS Phone
      ,Address AS Address
	  ,Category AS Category
	  ,City AS City
	  ,Country_Code AS Country_Code
	  ,Country_Name AS Country_Name
	  ,Cast(Text as nvarchar(MAX)) AS Description
	  ,null AS Email -- Google doen't have Email
	  ,Phone_Country_Code AS Phone_Country_Code
	  ,Region_Code AS Region_Code
	  ,Region_Name AS Region_Name
	  ,Zip_Code AS Zip_Code
	  ,Domain AS Domain
  FROM [dbo].[Google]
 WHERE id NOT IN (SELECT google_id FROM [dbo].[AllInfo] WHERE google_id IS NOT NULL)
UNION
SELECT null AS facebook_id
      ,null AS google_id
      ,id AS website_id
      ,legal_name AS Name
      ,phone AS Phone
      ,main_city AS Address
      ,s_category AS Category
      ,main_city AS City
      ,null AS Country_Code -- Website doesn't have Country_Code
      ,main_country AS Country_Name
      ,NULL AS Description -- Website doesn't have Description
      ,NULL AS Email -- Website doesn't have Email
      ,NULL AS Phone_Country_Code -- Website doesn't have Phone_Country_code
      ,NULL AS Region_Code -- Website doesn't have Region_Code
      ,main_region AS Region_Name
      ,NULL AS Zip_Code -- Website doesn't have Zip_Code
      ,root_domain AS Domain
  FROM [dbo].[Website] 
 WHERE id NOT IN (SELECT website_id FROM [dbo].[AllInfo] WHERE website_id IS NOT NULL)
END;
GO


CREATE PROCEDURE [dbo].[ExecuteBigData]
AS
BEGIN
    BEGIN TRY
        PRINT 'Starting the Big Data execution process...';

        -- Execută procedura JoinByNameAndPhone
        PRINT 'Executing JoinByNameAndPhone...';
        EXEC JoinByNameAndPhone;

        -- Execută procedura JoinByName
        PRINT 'Executing JoinByName...';
        EXEC JoinByName;

        -- Execută procedura JoinByPhone
        PRINT 'Executing JoinByPhone...';
        EXEC JoinByPhone;

        -- Execută procedura JoinByDomain
        PRINT 'Executing JoinByDomain...';
        EXEC JoinByDomain;

        -- Execută procedura JoinNonMatchingData
        PRINT 'Executing JoinNonMatchingData...';
        EXEC JoinNonMatchingData;

        PRINT 'Big Data execution completed successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred during the execution of the Big Data process.';
        PRINT ERROR_MESSAGE();
    END CATCH
END;
GO


