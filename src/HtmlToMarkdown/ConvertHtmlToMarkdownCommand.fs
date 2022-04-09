namespace HtmlToMarkdown

open System.Management.Automation

open ReverseMarkdown

/// Converts HTML to Markdown.
[<Cmdlet(VerbsData.Convert, "HtmlToMarkdown")>]
[<OutputType(typeof<string>)>]
[<Alias("Convert-HtmlToCommonMark")>]
type ConvertHtmlToMarkdownCommand () =
    inherit PSCmdlet ()

    /// HTML to convert.
    [<Parameter(Mandatory=true,ValueFromPipeline=true,ValueFromPipelineByPropertyName=true)>]
    [<ValidateNotNullOrEmpty>]
    [<Alias("InputObject","OuterHtml")>]
    member val Html : string = null with get, set

    /// Option to set the default code block language for Github style markdown if class based language markers are not available.
    [<Parameter>]
    [<ValidateNotNullOrEmpty>]
    [<Alias("CodeDefault")>]
    member val DefaultCodeBlockLanguage : string = null with get, set

    /// Github style markdown for br, pre and table.
    [<Parameter>]
    [<Alias("GFM")>]
    member val GithubFlavored : SwitchParameter = SwitchParameter false with get, set

    /// Sets the bullet character to use for unordered lists.
    [<Parameter>]
    [<Alias("Bullets")>]
    member val ListBulletChar : char = '-' with get, set

    /// Remove comment tags with text.
    [<Parameter>]
    [<Alias("StripComments")>]
    member val RemoveComments : SwitchParameter = SwitchParameter false with get, set

    /// Outputs link as auto-linking text (not an explicit link) when the text matches the link.
    [<Parameter>]
    [<Alias("AutoLink")>]
    member val SmartHrefHandling : SwitchParameter = SwitchParameter false with get, set

    /// What to do with unknown tags: PassThrough includes it as is, Drop removes it, Bypass ignores it, and Raise throws an exception.
    [<Parameter>]
    [<Alias("UnknownElements")>]
    member val UnknownTags : Config.UnknownTagsOption = Config.UnknownTagsOption.PassThrough with get, set

    /// Pass a list of tags to pass through as-is without any processing.
    [<Parameter>]
    [<ValidateNotNullOrEmpty>]
    [<Alias("PassThroughElements","KeepTags","KeepElements")>]
    member val PassThroughTags : string[] = Array.empty with get, set

    /// Specify which schemes (without trailing colon) are to be allowed for links and images. Empty string allows unknown schemes.
    [<Parameter>]
    [<Alias("AllowlistUriSchemes")>]
    member val WhitelistUriSchemes : string[] = Array.empty with get, set

    /// What to do about tables without a header row. Default: first row will be used as header row. EmptyRow: an empty header row is created.
    [<Parameter>]
    [<Alias("TableHeaderDefault")>]
    member val TableWithoutHeaderRowHandling : Config.TableWithoutHeaderRowHandlingOption =
        Config.TableWithoutHeaderRowHandlingOption.Default with get, set

    member val Converter : Converter = null with get, set

    // optional: setup before pipeline input starts (e.g. Name is set, InputObject is not)
    override x.BeginProcessing () =
        base.BeginProcessing ()
        x.Converter
            <- Converter
                <| Config(DefaultCodeBlockLanguage      = x.DefaultCodeBlockLanguage,
                          GithubFlavored                = x.GithubFlavored,
                          ListBulletChar                = x.ListBulletChar,
                          RemoveComments                = x.RemoveComments,
                          SmartHrefHandling             = x.SmartHrefHandling,
                          UnknownTags                   = x.UnknownTags,
                          PassThroughTags               = x.PassThroughTags,
                          WhitelistUriSchemes           = x.WhitelistUriSchemes,
                          TableWithoutHeaderRowHandling = x.TableWithoutHeaderRowHandling)

    // optional: handle each pipeline value (e.g. InputObject)
    override x.ProcessRecord () =
        base.ProcessRecord ()
        x.Converter.Convert(x.Html) |> x.WriteObject

    // optional: finish after all pipeline input
    override x.EndProcessing () =
        base.EndProcessing ()
