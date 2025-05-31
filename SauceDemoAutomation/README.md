# 🧪 SauceDemo Web Automation - Playwright + C#

Automated end-to-end UI testing of [SauceDemo](https://www.saucedemo.com/) using **Microsoft Playwright** in **C#**.  
This project follows the **Page Object Model (POM)** structure for better readability and maintainability.

---

## 🚀 Features

- ✅ Login functionality validation
- ✅ Product listing and cart operations
- ✅ Checkout process with user details
- ✅ Order confirmation validation
- ✅ Page Object Model (POM) structure
- ✅ Supports Headless & Headed modes
- ✅ Compatible with Chromium, Firefox, and WebKit

---

## 🛠 Tech Stack

| Tool/Library         | Description                         |
|----------------------|-------------------------------------|
| C#                   | Main programming language           |
| Microsoft.Playwright | Web automation library              |
| NUnit / xUnit        | Testing framework (if used)         |
| .NET Core / .NET 6+  | Runtime environment                 |

---

## 📂 Project Structure
SauceDemoAutomation/
├── Pages/
│   └── LoginPage.cs
│   └── ProductPage.cs
│   └── CheckoutPage.cs
├── Tests/
│   └── SauceDemoTests.cs
├── SauceDemoAutomation.csproj
├── README.md


---

## 🔧 Setup Instructions

1. Clone the repository
git clone https://github.com/your-username/saucedemo-playwright-csharp.git
cd saucedemo-playwright-csharp

2. Install dependencies
dotnet restore
dotnet tool install --global Microsoft.Playwright.CLI
playwright install

3. Run the tests
dotnet build
dotnet run
