using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]

public class Tests : PageTest
{
    [Test]
    public async Task FirstTest()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [Test]
    public async Task SecondTest()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();
        
        // Expects page to have a heading with the name of Installation.
        await Expect(Page
            .GetByRole(AriaRole.Heading, new() { Name = "Installation" }))
            .ToBeVisibleAsync();
    }
    
    [Test]
    public async Task CanFieldBeFound()

    {

        await Page.GotoAsync("https://demo.playwright.dev/todomvc/");

        var inputField = Page.GetByPlaceholder("What needs to be done?");
        

        await Expect(inputField).ToBeVisibleAsync();
        

    }
    
    [Test]
    public async Task LocatingElements()

    {

        await Page.GotoAsync("https://demo.playwright.dev/todomvc/");

        var test1 = Page.GetByRole(AriaRole.Heading, new() { Name = "todos" });
        var test2 = Page.GetByText("This is just a demo of TodoMVC for testing, not the real TodoMVC app.");
        var test3 = Page.GetByRole(AriaRole.Link, new() { Name = "TodoMVC", Exact = true });
        
        //Make Assertions

        
        await Expect(test1).ToBeVisibleAsync();
        await Expect(test2).ToBeVisibleAsync();
        await Expect(test3).ToBeVisibleAsync();
        

    }

    [Test]
    public async Task ActionsOnPage()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc/");

        var testInput = "testTodo";
        
        await Page.GetByPlaceholder("What needs to be done?").ClickAsync();

        await Page.GetByPlaceholder("What needs to be done?").FillAsync(testInput);

        await Page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");
        
        //Make Assertions
        
        await Expect(Page.GetByText(testInput)).ToBeVisibleAsync();
    }
    
    [TestCase("Todo item 1 string here")]
    [TestCase("Todo item 2 string here")]
    public async Task InlinedTest(string todoString)
    {

        await Page.GotoAsync("https://demo.playwright.dev/todomvc/");
        
        await Page.GetByPlaceholder("What needs to be done?").ClickAsync();

        await Page.GetByPlaceholder("What needs to be done?").FillAsync(todoString);

        await Page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");
        
        //Make Assertions
        
        await Expect(Page.GetByText(todoString)).ToBeVisibleAsync();

    }
    
    [TestCase("Todo item 1 string here")]
    [TestCase("Todo item 2 string here")]
    public async Task InlinedTestAndViewPort(string todoString)
    {

        await Page.SetViewportSizeAsync(8, 6);
        
        await Page.GotoAsync("https://demo.playwright.dev/todomvc/");
        
        await Page.GetByPlaceholder("What needs to be done?").ClickAsync();

        await Page.GetByPlaceholder("What needs to be done?").FillAsync(todoString);

        await Page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");
        
        //Make Assertions
        
        await Expect(Page.GetByText(todoString)).ToBeVisibleAsync();

    }
    
    
}