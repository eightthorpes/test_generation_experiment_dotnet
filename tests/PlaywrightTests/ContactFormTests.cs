using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

/// <summary>
/// TC-S1-010 to TC-S1-014: Contact Form tests for Sprint 1
/// Target: https://v1.practicesoftwaretesting.com
/// </summary>
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ContactFormTests : PageTest
{
    private const string BaseUrl = "https://v1.practicesoftwaretesting.com";
    // v1 uses hash-based routing
    private const string ContactHashUrl = $"{BaseUrl}/#/contact";

    [SetUp]
    public void SetUpAssertionTimeout()
    {
        Assertions.SetDefaultExpectTimeout(15_000);
    }

    private async Task NavigateToContactPage()
    {
        // v1 Angular app requires loading from root before hash routing works correctly
        await Page.GotoAsync(BaseUrl);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.Locator("[data-test='nav-contact']").ClickAsync();
        await Page.WaitForURLAsync("**/contact**", new() { Timeout = 15_000 });
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    /// <summary>TC-S1-010: Contact form is accessible via navigation</summary>
    [Test]
    public async Task ContactFormIsAccessibleViaNavigation()
    {
        await NavigateToContactPage();

        await Expect(Page.Locator("[data-test='first-name']")).ToBeVisibleAsync();
    }

    /// <summary>TC-S1-011: All required fields are present</summary>
    [Test]
    public async Task AllRequiredContactFormFieldsArePresent()
    {
        await NavigateToContactPage();

        await Expect(Page.Locator("[data-test='first-name']")).ToBeVisibleAsync();
        await Expect(Page.Locator("[data-test='last-name']")).ToBeVisibleAsync();
        await Expect(Page.Locator("[data-test='email']")).ToBeVisibleAsync();
        await Expect(Page.Locator("[data-test='subject']")).ToBeVisibleAsync();
        await Expect(Page.Locator("[data-test='message']")).ToBeVisibleAsync();
    }

    /// <summary>TC-S1-012: Subject dropdown contains all required options</summary>
    [Test]
    public async Task SubjectDropdownContainsAllRequiredOptions()
    {
        await NavigateToContactPage();

        var subject = Page.Locator("[data-test='subject']");
        await Expect(subject).ToBeVisibleAsync();

        // Read all rendered option text values at once
        var actualOptions = await subject.Locator("option").AllInnerTextsAsync();

        // Actual option texts on v1 (note: "Status of my order", not "Status of order")
        string[] expectedOptions =
        [
            "Customer service",
            "Webmaster",
            "Return",
            "Payments",
            "Warranty",
            "Status of my order",
        ];

        foreach (string expected in expectedOptions)
        {
            Assert.That(
                actualOptions.Any(o => o.Trim().Equals(expected, StringComparison.OrdinalIgnoreCase)),
                Is.True,
                $"Subject dropdown should contain: '{expected}'. Actual options: [{string.Join(", ", actualOptions.Select(o => o.Trim()))}]");
        }
    }

    /// <summary>TC-S1-013: Message under 50 characters shows validation error</summary>
    [Test]
    public async Task MessageUnder50CharactersShowsValidationError()
    {
        await NavigateToContactPage();

        await Page.Locator("[data-test='first-name']").FillAsync("Test");
        await Page.Locator("[data-test='last-name']").FillAsync("User");
        await Page.Locator("[data-test='email']").FillAsync("test@example.com");
        // Select by option value (e.g. "customer-service"), not label text
        await Page.Locator("[data-test='subject']").SelectOptionAsync("customer-service");

        // Enter a message shorter than 50 characters
        await Page.Locator("[data-test='message']").FillAsync("Too short");

        await Page.Locator("[data-test='contact-submit']").ClickAsync();

        // v1 shows: "Message must be minimal 50 characters"
        var validationError = Page.GetByText("must be minimal 50 characters", new() { Exact = false })
            .Or(Page.GetByText("at least 50", new() { Exact = false }));

        await Expect(validationError.First).ToBeVisibleAsync();
    }

    /// <summary>TC-S1-014: Successful form submission shows confirmation</summary>
    [Test]
    public async Task SuccessfulFormSubmissionShowsConfirmation()
    {
        await NavigateToContactPage();

        await Page.Locator("[data-test='first-name']").FillAsync("Test");
        await Page.Locator("[data-test='last-name']").FillAsync("User");
        await Page.Locator("[data-test='email']").FillAsync("test@example.com");
        await Page.Locator("[data-test='subject']").SelectOptionAsync("customer-service");

        // Message must be at least 50 characters
        await Page.Locator("[data-test='message']").FillAsync(
            "This is a valid test message that is definitely longer than fifty characters.");

        await Page.Locator("[data-test='contact-submit']").ClickAsync();

        // Confirmation message should appear after successful submission
        var confirmation = Page.GetByText("Thanks for your message", new() { Exact = false })
            .Or(Page.GetByText("successfully sent", new() { Exact = false }))
            .Or(Page.GetByText("message has been sent", new() { Exact = false }));

        await Expect(confirmation.First).ToBeVisibleAsync();
    }
}
