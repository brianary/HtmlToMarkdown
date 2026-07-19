# Pester tests, see https://github.com/Pester/Pester/wiki
$psd1 = Resolve-Path ./src/bin/*/net*/publish/*.psd1
Import-LocalizedData -BindingVariable manifest -BaseDirectory (Split-Path $psd1) -FileName (Split-Path $psd1 -Leaf)
if(1 -lt ($psd1 |Measure-Object).Count) {throw "Too many module binaries found: $psd1"}
$module = Import-Module "$psd1" -PassThru -vb
$eol = [Environment]::NewLine

Describe $module.Name {
	Context 'Convert-HtmlToMarkdown cmdlet' -Tag Cmdlet,Convert-HtmlToMarkdown {
		It "Given HTML '<Html>', '<Expected>' should be returned." -TestCases @(
			@{ Html = '<p>Hello, world</p>'; Expected = 'Hello, world' }
			@{ Html = '<h1>On Board</h1><ul><li>Ford<li>Zaphod<li>Marvin</ul>'; Expected = "# On Board${eol}${eol}- Ford${eol}- Zaphod${eol}- Marvin" }
		) {
			Param($Html,$Expected)
			$Html |HtmlToMarkdown\Convert-HtmlToMarkdown |Should -BeExactly $Expected
		}
	}
}.GetNewClosure()
