# see https://docs.microsoft.com/powershell/scripting/developer/module/how-to-write-a-powershell-module-manifest
# and https://docs.microsoft.com/powershell/module/microsoft.powershell.core/new-modulemanifest
@{
RootModule = 'HtmlToMarkdown.dll'
ModuleVersion = '1.1.2'
CompatiblePSEditions = @('Core','Desktop')
GUID = 'b9799ff4-2f34-4787-8e26-5f6f4db55e60'
Author = 'Brian Lalonde'
# CompanyName = 'Unknown'
Copyright = '(c) Brian Lalonde. All rights reserved.'
Description = 'Converts HTML to Markdown/CommonMark.'
PowerShellVersion = '5.1'
FunctionsToExport = @()
CmdletsToExport = @(
    'Convert-HtmlToMarkdown'
)
VariablesToExport = @()
AliasesToExport = @()
FileList = @(
    'HtmlToMarkdown.dll'
    'HtmlToMarkdown.dll-Help.xml'
)
PrivateData = @{
    PSData = @{
        Tags = @(
            'Markdown'
            'CommonMark'
            'HTML'
            'Windows'
            'Linux'
            'macOS'
        )
        LicenseUri = 'https://github.com/brianary/HtmlToMarkdown/LICENSE'
        ProjectUri = 'https://github.com/brianary/HtmlToMarkdown/'
        IconUri = 'http://webcoder.info/images/HtmlToMarkdown.svg'
        # ReleaseNotes = ''
    }
}
}
