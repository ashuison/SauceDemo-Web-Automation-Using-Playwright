using Microsoft.Playwright;

public class LoginPage
{
  private readonly IPage _page;

  public LoginPage(IPage page)
  {
    _page = page;
  }

  public async Task Login(string username, string password)
  {
    await _page.FillAsync("#user-name", username);
    await _page.FillAsync("#password", password);
    await _page.ClickAsync("#login-button");
  }
}