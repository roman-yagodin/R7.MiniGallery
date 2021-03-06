-- NOTE: To manually execute this script you must 
-- replace {databaseOwner} and {objectQualifier} with real values. 
-- Defaults is "dbo." for database owner and "" for object qualifier 

-- Create tables

IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'{databaseOwner}[{objectQualifier}MiniGallery_Images]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images] 
	(
		[ImageID] [int] IDENTITY(1,1) NOT NULL,
		[ModuleID] [int] NOT NULL,
		[ImageFileID] [int] NOT NULL,
		[Alt] [nvarchar](255) NOT NULL,
		[Title] [nvarchar](255) NULL,
		[URL] [nvarchar](255) NULL,
		[SortIndex] [int] NOT NULL,
		[IsPublished] [bit] NOT NULL,
		[CreatedOnDate] [datetime] NOT NULL,
		[CreatedByUserID] [int] NULL,
		[LastModifiedOnDate] [datetime] NOT NULL,
		[LastModifiedByUserID] [int] NULL,
	)

	ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images]
		ADD CONSTRAINT [PK_{objectQualifier}MiniGallery_Images] PRIMARY KEY CLUSTERED ([ImageID])
	
	CREATE NONCLUSTERED INDEX [IX_{objectQualifier}MiniGallery_Images_Modules] 
		ON {databaseOwner}[{objectQualifier}MiniGallery_Images] ([ModuleID])

	ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images]
		WITH CHECK ADD CONSTRAINT [FK_{objectQualifier}MiniGallery_Images_{objectQualifier}Files] 
			FOREIGN KEY([ImageFileID]) REFERENCES {databaseOwner}[{objectQualifier}Files] ([FileId])
				ON DELETE CASCADE

	ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images] 
		CHECK CONSTRAINT [FK_{objectQualifier}MiniGallery_Images_{objectQualifier}Files]

	ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images]
		WITH CHECK ADD CONSTRAINT [FK_{objectQualifier}MiniGallery_Images_{objectQualifier}Modules] 
			FOREIGN KEY([ModuleID]) REFERENCES {databaseOwner}[{objectQualifier}Modules] ([ModuleID])
				ON DELETE CASCADE

	ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images] 
		CHECK CONSTRAINT [FK_{objectQualifier}MiniGallery_Images_{objectQualifier}Modules]

END
GO
