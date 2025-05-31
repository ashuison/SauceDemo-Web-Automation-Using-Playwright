using Microsoft.Playwright;

public class ProductsPage
{
  private readonly IPage _page;

  // Locators
  private const string BACKPACK_ADD_BUTTON = "#add-to-cart-sauce-labs-backpack";
  private const string BIKE_LIGHT_ADD_BUTTON = "#add-to-cart-sauce-labs-bike-light";
  private const string BACKPACK_REMOVE_BUTTON = "#remove-sauce-labs-backpack";
  private const string CART_BADGE = ".shopping_cart_badge";
  private const string CART_LINK = ".shopping_cart_link";

  public ProductsPage(IPage page)
  {
    _page = page;
  }

  public async Task AddBackpackToCart()
  {
    await _page.ClickAsync(BACKPACK_ADD_BUTTON);
  }

  public async Task AddBikeLightToCart()
  {
    await _page.ClickAsync(BIKE_LIGHT_ADD_BUTTON);
  }

  public async Task<int> GetCartItemCount()
  {
    var badge = await _page.TextContentAsync(CART_BADGE) ?? "0";
    return int.Parse(badge);
  }

  public async Task GoToCart()
  {
    await _page.ClickAsync(CART_LINK);
  }

  public async Task RemoveBackpack()
  {
    await _page.ClickAsync(BACKPACK_REMOVE_BUTTON);
  }
}