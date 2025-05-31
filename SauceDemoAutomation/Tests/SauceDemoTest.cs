using Microsoft.Playwright;

public class SauceDemoTest
{
  public static async Task Main()
  {
    using var playwright = await Playwright.CreateAsync();
    var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
    var context = await browser.NewContextAsync();
    var page = await context.NewPageAsync();

    // Maximize the window
    await page.SetViewportSizeAsync(1920, 1080);

    await page.GotoAsync("https://www.saucedemo.com/");
    await Task.Delay(1000); // 1 second delay

    // Login
    var loginPage = new LoginPage(page);
    await loginPage.Login("standard_user", "secret_sauce");
    await Task.Delay(1000); // 1 second delay

    // Add to cart
    var productsPage = new ProductsPage(page);
    await productsPage.AddBackpackToCart();
    await Task.Delay(1000); // 1 second delay
    await productsPage.AddBikeLightToCart();
    await Task.Delay(1000); // 1 second delay

    var count = await productsPage.GetCartItemCount();
    Console.WriteLine($"Cart Count After Adding: {count}");

    // Assert cart count == 2
    if (count != 2)
      throw new Exception("Cart count mismatch after adding!");

    // Remove 1 item
    await productsPage.RemoveBackpack();
    await Task.Delay(1000); // 1 second delay

    count = await productsPage.GetCartItemCount();
    Console.WriteLine($"Cart Count After Removing: {count}");

    // Assert cart count == 1
    if (count != 1)
      throw new Exception("Cart count mismatch after removing!");

    // Go to cart
    await productsPage.GoToCart();
    await Task.Delay(1000); // 1 second delay

    var cartPage = new CartPage(page);
    var isPresent = await cartPage.IsItemPresent("Sauce Labs Bike Light");
    if (!isPresent)
      throw new Exception("Expected item not found in cart!");

    // Checkout
    await cartPage.ProceedToCheckout();
    await Task.Delay(1000); // 1 second delay

    var checkoutPage = new CheckoutPage(page);
    await checkoutPage.EnterInformation("Ashutosh", "Sharma", "560001");
    await Task.Delay(1000); // 1 second delay

    // Finish order
    await checkoutPage.FinishCheckout();
    await Task.Delay(1000); // 1 second delay

    var completePage = new CompletePage(page);
    var message = await completePage.GetConfirmationMessage();

    // Assert confirmation message
    if (message != "Thank you for your order!")
      throw new Exception("Confirmation message incorrect!");
    else
      Console.WriteLine("Order completed successfully!");


    Console.WriteLine("Test completed successfully!");
    await Task.Delay(2000); // 2 second delay at the end
  }
}