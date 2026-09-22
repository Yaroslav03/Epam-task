# EPAM Final Task — SauceDemo UI Tests

A browser-based UI test suite for the [SauceDemo](https://www.saucedemo.com/) shopping demo. It automates login and shopping-cart scenarios using Selenium WebDriver, NUnit, and the Page Object Model.

## Test scenarios

The test suite covers the requested user cases:

- **Login validation:** submit the login form with a username and an empty password, then check for the “Password is required” message.
- **Successful login:** sign in as the standard user and verify that the inventory page shows the menu button, “Swag Labs” logo, cart, sorting control, and product list.
- **Add a product to the cart:** open a product, add it to the cart, and check that the cart badge shows one item. This scenario is data-driven for multiple product names.

The login and product fixtures are configured to run with both Chrome and Firefox.

## Technology

| Component | Technology |
|---|---|
| Language | C# |
| Target framework | .NET 8 |
| Browser automation | Selenium WebDriver 4 |
| Test framework and runner | NUnit 3, NUnit3TestAdapter, Microsoft.NET.Test.Sdk |
| Assertions | FluentAssertions |
| Logging | NUnit test output via `TestContext.WriteLine` |
| Configuration | `appsettings.json` |

## Project structure

```text
Epam-task/
└── FinalTaskTests/
    ├── Drivers/
    │   └── DriverFactory.cs       # Creates Chrome and Firefox WebDriver instances
    ├── Pages/
    │   ├── BasePage.cs            # Shared page actions and waits
    │   ├── LoginPage.cs           # Login form interactions
    │   ├── InventoryPage.cs       # Inventory page interactions and checks
    │   └── ProductPage.cs         # Product and cart interactions
    ├── Tests/
    │   ├── BaseTest.cs            # Test setup, configuration, and cleanup
    │   ├── LoginTests.cs          # Login scenarios
    │   └── ProductTest.cs         # Add-to-cart scenario
    ├── appsettings.json           # Demo URL and standard-user credentials
    └── FinalTaskTests.csproj
```

## Requirements

- .NET 8 SDK
- Chrome and/or Firefox installed
- Internet access to reach SauceDemo
- A compatible browser driver. The project references ChromeDriver and GeckoDriver NuGet packages; if automatic driver setup is unavailable in your environment, install a driver compatible with your browser and ensure it is available on `PATH`.

## Run the tests

From the repository root:

```bash
dotnet restore FinalTaskTests/FinalTaskTests.csproj
dotnet test FinalTaskTests/FinalTaskTests.csproj
```

NUnit test output, including messages written with `TestContext.WriteLine`, is available in the test runner output. To see detailed command-line output:

```bash
dotnet test FinalTaskTests/FinalTaskTests.csproj --logger "console;verbosity=detailed"
```

## Configuration

The test URL and standard-user credentials are read from `FinalTaskTests/appsettings.json`. The checked-in values target the public SauceDemo test site. Update this file when running against another permitted test environment.

## Notes

- These are UI tests against a third-party demo site. Test results can be affected by network availability or changes to that site.
- Chrome and Firefox are selected through NUnit test fixtures in the test classes.
- The repository includes a task-description README inside `FinalTaskTests/`; this document provides an overview of the implementation and how to run it.
