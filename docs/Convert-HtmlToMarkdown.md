---
external help file: HtmlToMarkdown.dll-Help.xml
Module Name: HtmlToMarkdown
online version:
schema: 2.0.0
---

# Convert-HtmlToMarkdown

## SYNOPSIS
Converts HTML to Markdown.

## SYNTAX

```
Convert-HtmlToMarkdown -Html <String> [-DefaultCodeBlockLanguage <String>] [-GithubFlavored]
 [-ListBulletChar <Char>] [-RemoveComments] [-SmartHrefHandling] [-UnknownTags <UnknownTagsOption>]
 [-PassThroughTags <String[]>] [-WhitelistUriSchemes <String[]>]
 [-TableWithoutHeaderRowHandling <TableWithoutHeaderRowHandlingOption>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> '<h1>On Board</h1><ul><li>Ford<li>Zaphod<li>Marvin</ul>' |Convert-HtmlToMarkdown
```

```output
# On Board

- Ford
- Zaphod
- Marvin
```

## PARAMETERS

### -DefaultCodeBlockLanguage
Option to set the default code block language for Github style markdown if class based language markers are not available.

```yaml
Type: String
Parameter Sets: (All)
Aliases: CodeDefault

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GithubFlavored
Github style markdown for br, pre and table.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: GFM

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Html
HTML to convert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: InputObject, OuterHtml

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ListBulletChar
Sets the bullet character to use for unordered lists.

```yaml
Type: Char
Parameter Sets: (All)
Aliases: Bullets

Required: False
Position: Named
Default value: '-'
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThroughTags
Pass a list of tags to pass through as-is without any processing.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: PassThroughElements, KeepTags, KeepElements

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveComments
Remove comment tags with text.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: StripComments

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmartHrefHandling
Outputs link as auto-linking text (not an explicit link) when the text matches the link.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: AutoLink

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableWithoutHeaderRowHandling
What to do about tables without a header row. Default: first row will be used as header row. EmptyRow: an empty header row is created.

```yaml
Type: TableWithoutHeaderRowHandlingOption
Parameter Sets: (All)
Aliases: TableHeaderDefault
Accepted values: Default, EmptyRow

Required: False
Position: Named
Default value: Default
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnknownTags
What to do with unknown tags: PassThrough includes it as is, Drop removes it, Bypass ignores it, and Raise throws an exception.

```yaml
Type: UnknownTagsOption
Parameter Sets: (All)
Aliases: UnknownElements
Accepted values: PassThrough, Drop, Bypass, Raise

Required: False
Position: Named
Default value: PassThrough
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhitelistUriSchemes
Specify which schemes (without trailing colon) are to be allowed for links and images. Empty string allows unknown schemes.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: AllowlistUriSchemes

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
