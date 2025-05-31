using Microsoft.Playwright;

public class CartPage
{
  private readonly IPage _page;

  // Locators
  private const string CHECKOUT_BUTTON = "#checkout";

  public CartPage(IPage page)
  {
    _page = page;
  }

  public async Task<bool> IsItemPresent(string itemName)
  {
    var item = await _page.Locator($"text={itemName}").IsVisibleAsync();
    return item;
  }

  public async Task ProceedToCheckout()
  {
    await _page.ClickAsync(CHECKOUT_BUTTON);
  }
}