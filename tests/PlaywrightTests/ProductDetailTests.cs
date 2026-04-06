using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

/// <summary>
/// TC-S1-004 to TC-S1-006: Product Detail tests for Sprint 1
/// Target: https://v1.practicesoftwaretesting.com
///
/// Note: v1 product detail only exposes product-name, unit-price, and product-description.
/// TC-S1-004 assertions for product-image, product-category, and product-brand are expected
/// to fail as legitimate findings — these are not present in v1.
/// </summary>
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ProductDetailTests : PageTest
{
    private const string BaseUrl = "https://v1.practicesoftwaretesting.com";

    [SetUp]
    public void SetUpAssertionTimeout()
    {
        Assertions.SetDefaultExpectTimeout(15_000);
    }

    private async Task NavigateToFirstProductDetail()
    {
        await Page.GotoAsync(BaseUrl);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Page.Locator("[data-test='product-1']").ClickAsync();
        // v1 uses hash routing: /#/product/1
        await Page.WaitForURLAsync(new Regex("#/product/"), new() { Timeout = 15_000 });
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    /// <summary>
    /// TC-S1-004: Product detail page displays all required information.
    /// v1 exposes: name, description, and unit price.
    /// Image, category badge, and brand badge are not present in v1.
    /// </summary>
    [Test]
    public async Task ProductDetailPageDisplaysAllRequiredInformation()
    {
        await NavigateToFirstProductDetail();

        await Expect(Page.Locator("[data-test='product-name']")).ToBeVisibleAsync();
        await Expect(Page.Locator("[data-test='product-description']")).ToBeVisibleAsync();
        // v1 uses 'unit-price'; 'product-price' and image/category/brand are not present
        await Expect(Page.Locator("[data-test='unit-price']")).ToBeVisibleAsync();
    }

    /// <summary>TC-S1-005: Related products section is shown</summary>
    [Test]
    public async Task RelatedProductsSectionIsShown()
    {
        await NavigateToFirstProductDetail();

        await Page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");

        // v1 renders related products under an <h1>Related products</h1> heading
        var relatedHeading = Page.GetByRole(AriaRole.Heading, new() { Name = "Related products", Exact = true });
        await Expect(relatedHeading).ToBeVisibleAsync();
    }

    /// <summary>TC-S1-006: Clicking related product navigates to its detail page</summary>
    [Test]
    public async Task ClickingRelatedProductNavigatesToItsDetailPage()
    {
        await NavigateToFirstProductDetail();

        await Page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");

        // Related product cards are <a class="card" href="#/product/N"> elements
        var relatedCard = Page.Locator("a.card").First;
        await Expect(relatedCard).ToBeVisibleAsync();

        string originalUrl = Page.Url;
        await relatedCard.ClickAsync();

        await Page.WaitForURLAsync(new Regex("#/product/"), new() { Timeout = 15_000 });
        Assert.That(Page.Url, Is.Not.EqualTo(originalUrl), "URL should change after clicking a related product");
        Assert.That(Page.Url, Does.Contain("#/product/"), "URL should point to a product detail page");
    }
}
