# SpecFlow Selenium Automation Project

This is a basic SpecFlow test automation project built using the Page Object Model (POM) design pattern.

The project is based on a public e-commerce website, with tests designed to mimic real-life user scenarios such as searching for products, adding items to a wishlist, and managing user actions.

The aim of this project is to demonstrate:
- Behaviour-Driven Development (BDD) using SpecFlow
- UI test automation with Selenium WebDriver
- Clean test structure using Page Object Model
- Maintainable and readable automated tests

---

## Tech Stack

- .NET 6
- SpecFlow + NUnit
- Selenium WebDriver
- ChromeDriver

---

## Project Structure

- **Pages**  
  Contains page classes that encapsulate element locators, WebDriver interactions, and page-specific actions.

- **Hooks**  
  Contains SpecFlow hooks for test setup and teardown (BeforeScenario / AfterScenario), including WebDriver initialisation and cleanup.

- **Features**  
  Contains Gherkin feature files that describe test scenarios in a readable, business-focused format.

- **StepDefinitions**  
  Contains step definition classes that implement the logic behind the Gherkin steps and interact with the page objects.

---

## How to Run the Tests

### Prerequisites
- .NET 6 SDK installed
- Google Chrome installed
- Visual Studio 2022 (recommended) or .NET CLI

### Run tests using Visual Studio
1. Open the solution in Visual Studio
2. Restore NuGet packages
3. Open **Test Explorer**
4. Click **Run All Tests**

### Run tests using command line
From the project root directory:

```bash
dotnet test

