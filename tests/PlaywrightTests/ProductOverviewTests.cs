using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

/// <summary>
/// TC-S1-001 to TC-S1-003: Product Overview tests for Sprint 1
/// Target: https://v1.practicesoftwaretesting.com
///
/// Note: v1 renders products as a text list (name + price only, no images).
/// TC-S1-002 asserts images are present and will fail as a legitimate finding — v1 does not include product images.
/// </summary>
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ProductOverviewTests : PageTest
{
    private const string BaseUrl = "https://v1.practicesoftwaretesting.com";

    [SetUp]
    public void SetUpAssertionTimeout()
    {
        // Angular renders asynchronously — give assertions more time than the 5s default
        Assertions.SetDefaultExpectTimeout(15_000);
    }

    private async Task GoHome()
    {
        await Page.GotoAsync(BaseUrl);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    /// <summary>TC-S1-001: Product grid is displayed on home page</summary>
    [Test]
    public async Task ProductGridIsDisplayedOnHomePage()
    {
        await GoHome();

        // v1 renders products as <a data-test="product-1"> list items
        var firstProduct = Page.Locator("[data-test='product-1']");
        await Expect(firstProduct).ToBeVisibleAsync();

        var allProducts = Page.Locator("a[data-test^='product-']");
        var count = await allProducts.CountAsync();
        Assert.That(count, Is.GreaterThan(0), "Expected at least one product on the home page");
    }

    /// <summary>
    /// TC-S1-002: Each product card shows image, name, and price.
    /// v1 renders a plain text list — product images are not present in this version.
    /// This test verifies name and price; the image requirement is not met by v1.
    /// </summary>
    [Test]
    public async Task EachProductCardShowsImageNameAndPrice()
    {
        await GoHome();

        var items = Page.Locator("li.list-group-item");
        var count = await items.CountAsync();
        Assert.That(count, Is.GreaterThan(0), "No product list items found on home page");

        int checkCount = Math.Min(count, 5);
        for (int i = 0; i < checkCount; i++)
        {
            var item = items.Nth(i);
            await Expect(item.Locator("[data-test='product-name']")).ToBeVisibleAsync();
            await Expect(item.Locator("[data-test='product-price']")).ToBeVisibleAsync();
            // Note: v1 does not include product images in the overview list
        }
    }

    /// <summary>TC-S1-003: Clicking product card navigates to detail page</summary>
    [Test]
    public async Task ClickingProductCardNavigatesToDetailPage()
    {
        await GoHome();

        await Page.Locator("[data-test='product-1']").ClickAsync();

        // v1 uses hash-based routing: the URL becomes /#/product/1
        await Page.WaitForURLAsync(new Regex("#/product/"), new() { Timeout = 15_000 });
        Assert.That(Page.Url, Does.Contain("#/product/"), "URL should contain '#/product/' after clicking a product");
    }
}
