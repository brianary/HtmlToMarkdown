# see https://docs.microsoft.com/powershell/scripting/developer/module/how-to-write-a-powershell-module-manifest
# and https://docs.microsoft.com/powershell/module/microsoft.powershell.core/new-modulemanifest
@{
RootModule = 'PSModuleTemplate.dll'
ModuleVersion = '1.0.0'
CompatiblePSEditions = @('Core','Desktop')
GUID = 'f5c914f0-8410-48a6-8321-6fe8b4e80cf3'
Author = 'AuthorName'
CompanyName = 'Unknown'
Copyright = '(c) AuthorName. All rights reserved.'
Description = 'A description of this module template.'
PowerShellVersion = '5.1'
FunctionsToExport = @()
CmdletsToExport = @(
    'Get-Foo'
)
VariablesToExport = @()
AliasesToExport = @()
FileList = @(
    'PSModuleTemplate.dll'
    'PSModuleTemplate.dll-Help.xml'
)
PrivateData = @{
    PSData = @{
        Tags = @(
            'Foo'
            'Windows'
            'Linux'
            'macOS'
        )
        # LicenseUri = ''
        # ProjectUri = ''
        # IconUri = ''
        # ReleaseNotes = ''
    }
}
}
