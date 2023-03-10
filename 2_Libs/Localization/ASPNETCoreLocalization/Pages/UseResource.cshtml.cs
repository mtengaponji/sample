namespace ASPNETCoreLocalization.Pages;

internal class UseResourceModel : PageModel
{
    private readonly IStringLocalizer _localizer;
    private readonly IStringLocalizer _sharedLocalizer;
    public UseResourceModel(IStringLocalizer<UseResourceModel> localizer, IStringLocalizer<Program> sharedLocalizer)
    {
        _localizer = localizer;
        _sharedLocalizer = sharedLocalizer;
    }

    public void OnGet()
    {
        var feature = HttpContext.Features.Get<IRequestCultureFeature>() ?? 
            throw new InvalidOperationException($"{nameof(IRequestCultureFeature)} not available");
        RequestCulture requestCulture = feature.RequestCulture;
        Message1 = _localizer["Message1"];
        Message2 = _localizer.GetString("Message2", feature.RequestCulture.Culture, feature.RequestCulture.UICulture);
        Message3 = _sharedLocalizer.GetString("SharedText");
    }

    public string? Message1 { get; private set; }
    public string? Message2 { get; private set; }
    public string? Message3 { get; private set; }
}
