using Microsoft.Playwright;

public class CompletePage
{
  private readonly IPage _page;

  // Locators
  private const string COMPLETE_HEADER = ".complete-header";

  public CompletePage(IPage page)
  {
    _page = page;
  }

  public async Task<string> GetConfirmationMessage()
  {
    return await _page.TextContentAsync(COMPLETE_HEADER) ?? string.Empty;
  }
}