<#
.Synopsis
    Renames the template content from PSModuleTemplate to the name of the new repo.
#>

#Requires -Version 3
[CmdletBinding()] Param()

$NewName = (Split-Path (git remote get-url origin) -Leaf) -replace '\.git\z',''
if($NewName -eq 'PSModuleTemplate')
{
    Stop-ThrowError.ps1 'Run this script once you have created a new repo from this template.' `
        -OperationContext (git remote get-url origin)
}

Push-Location $PSScriptRoot
Get-ChildItem -Filter PSModuleTemplate* -Recurse |
    where { $_.FullName -notmatch '\\bin\\|\\obj\\|\\\.git\\' } |
    foreach {Rename-Item $_.FullName ($_.Name -replace '\APSModuleTemplate',$NewName)}
Get-ChildItem -File -Recurse |
    where { $_.FullName -notmatch '\\bin\\|\\obj\\|\\\.git\\' } |
    Select-String -Pattern '\bPSModuleTemplate' -List |
    Set-RegexReplace.ps1 -Replacement $NewName
Get-ChildItem -File -Filter *.sln -Recurse |Add-Utf8Signature
Remove-Item .\docs\Get-Foo.md -Force
Pop-Location
Remove-Item $PSCommandPath -Force
