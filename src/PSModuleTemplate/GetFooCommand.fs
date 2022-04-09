namespace ModuleName // use your module name for the namespace

open System.Management.Automation // PowerShell attributes come from this namespace

/// Describe cmdlet in /// comments
/// Cmdlet attribute takes verb names as strings or verb enums
/// Output type works the same as for PowerShell cmdlets
[<Cmdlet(VerbsCommon.Get, "Foo")>]
[<OutputType(typeof<string>)>]
type GetFooCommand () =
    inherit PSCmdlet ()

    // cmdlet parameters are properties of the class

    /// Describe property params in /// comments
    /// Parameter, Validate, and Alias attributes work the same as PowerShell params
    [<Parameter(Position=0)>]
    [<ValidateNotNullOrEmpty>]
    [<ValidatePattern(@"\w+")>]
    [<Alias("Key")>]
    member val Name : string = "" with get, set

    [<Parameter(ValueFromPipeline=true)>]
    [<ValidateNotNull>]
    member val InputObject : obj = null with get, set

    // optional: setup before pipeline input starts (e.g. Name is set, InputObject is not)
    override x.BeginProcessing () =
        base.BeginProcessing ()

    // optional: handle each pipeline value (e.g. InputObject)
    override x.ProcessRecord () =
        base.ProcessRecord ()

    // optional: finish after all pipeline input
    override x.EndProcessing () =
        x.WriteObject x.Name
        base.EndProcessing ()
