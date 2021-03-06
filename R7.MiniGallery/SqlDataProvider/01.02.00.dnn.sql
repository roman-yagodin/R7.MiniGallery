-- NOTE: To manually execute this script you must 
-- replace {databaseOwner} and {objectQualifier} with real values. 
-- Defaults is "dbo." for database owner and "" for object qualifier 

IF EXISTS (select * from {databaseOwner}[{objectQualifier}ModuleDefinitions] where DefinitionName = N'R7.MiniGallery')
BEGIN
    -- Rename old definition
    UPDATE {databaseOwner}[{objectQualifier}ModuleDefinitions]
        SET DefinitionName = N'R7_MiniGallery' WHERE DefinitionName = N'R7.MiniGallery'
END
GO

IF NOT EXISTS (select * from sys.columns where object_id = object_id(N'{databaseOwner}[{objectQualifier}MiniGallery_Images]') and name = N'StartDate')
    ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images]
        ADD StartDate datetime NULL,
            EndDate datetime NULL
GO

IF EXISTS (select * from sys.columns where object_id = object_id(N'{databaseOwner}[{objectQualifier}MiniGallery_Images]') and name = N'IsPublished')
BEGIN
    UPDATE {databaseOwner}[{objectQualifier}MiniGallery_Images]
        SET EndDate = GETDATE()
        WHERE IsPublished = 0

    ALTER TABLE {databaseOwner}[{objectQualifier}MiniGallery_Images]
        DROP COLUMN IsPublished
END
GO

IF EXISTS (select * from {databaseOwner}[{objectQualifier}TabModuleSettings] where settingName = N'MiniGallery_StyleSet' and (settingValue = N'Auto' or settingValue = N'Fixed'))
BEGIN
    UPDATE {databaseOwner}[{objectQualifier}TabModuleSettings]
        SET SettingValue = N'Default'
        WHERE SettingName = N'MiniGallery_StyleSet' AND SettingValue = N'Auto'

    UPDATE {databaseOwner}[{objectQualifier}TabModuleSettings]
        SET SettingValue = N'Columns'
        WHERE SettingName = N'MiniGallery_StyleSet' AND SettingValue = N'Fixed'
END
GO

IF EXISTS (select * from {databaseOwner}[{objectQualifier}TabModuleSettings] where settingName = N'MiniGallery_UseScrollbar')
    DELETE FROM {databaseOwner}[{objectQualifier}TabModuleSettings]
        WHERE SettingName = N'MiniGallery_UseScrollbar'
GO

IF EXISTS (select * from {databaseOwner}[{objectQualifier}TabModuleSettings] where settingName = N'MiniGallery_MaxHeight')
    DELETE FROM {databaseOwner}[{objectQualifier}TabModuleSettings]
        WHERE SettingName = N'MiniGallery_MaxHeight'
GO

IF EXISTS (select * from {databaseOwner}[{objectQualifier}TabModuleSettings] where settingName = N'MiniGallery_ShowInfo')
    DELETE FROM {databaseOwner}[{objectQualifier}TabModuleSettings]
        WHERE SettingName = N'MiniGallery_ShowInfo'
GO

IF EXISTS (select * from {databaseOwner}[{objectQualifier}TabModuleSettings] where settingName = N'MiniGallery_ExpandColumns')
    DELETE FROM {databaseOwner}[{objectQualifier}TabModuleSettings]
        WHERE SettingName = N'MiniGallery_ExpandColumns'
GO