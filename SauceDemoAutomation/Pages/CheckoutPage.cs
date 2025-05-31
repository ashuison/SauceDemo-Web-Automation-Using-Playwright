using Microsoft.Playwright;

public class CheckoutPage
{
  private readonly IPage _page;

  // Locators
  private const string FIRST_NAME_FIELD = "#first-name";
  private const string LAST_NAME_FIELD = "#last-name";
  private const string POSTAL_CODE_FIELD = "#postal-code";
  private const string CONTINUE_BUTTON = "#continue";
  private const string FINISH_BUTTON = "#finish";

  public CheckoutPage(IPage page)
  {
    _page = page;
  }

  public async Task EnterInformation(string firstName, string lastName, string zip)
  {
    await _page.FillAsync(FIRST_NAME_FIELD, firstName);
    await _page.FillAsync(LAST_NAME_FIELD, lastName);
    await _page.FillAsync(POSTAL_CODE_FIELD, zip);
    await _page.ClickAsync(CONTINUE_BUTTON);
  }

  public async Task FinishCheckout()
  {
    await _page.ClickAsync(FINISH_BUTTON);
  }
}