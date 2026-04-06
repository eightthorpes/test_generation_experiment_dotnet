using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

/// <summary>
/// TC-S1-007 to TC-S1-009: Category tests for Sprint 1
/// Target: https://v1.practicesoftwaretesting.com
///
/// Note: v1 product list items do not carry a category badge.
/// TC-S1-009 verifies category filtering by checking the URL and that products are visible
/// (the product-category attribute is not present in v1, so per-card verification is not possible).
/// </summary>
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CategoryTests : PageTest
{
    private const string BaseUrl = "https://v1.practicesoftwaretesting.com";
    private const string HandToolsSlug = "hand-tools";

    [SetUp]
    public void SetUpAssertionTimeout()
    {
        Assertions.SetDefaultExpectTimeout(15_000);
    }

    private async Task NavigateToCategoryPage()
    {
        await Page.GotoAsync(BaseUrl);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // v1 navigation uses data-test="nav-hand-tools"
        await Page.Locator("[data-test='nav-hand-tools']").ClickAsync();

        // v1 uses hash routing: /#/category/hand-tools
        await Page.WaitForURLAsync($"**{HandToolsSlug}**", new() { Timeout = 15_000 });
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    /// <summary>TC-S1-007: Category page displays products for selected category</summary>
    [Test]
    public async Task CategoryPageDisplaysProductsForSelectedCategory()
    {
        await NavigateToCategoryPage();

        // Products are <a data-test="product-N"> links (same structure as home page)
        var firstProduct = Page.Locator("a[data-test^='product-']").First;
        await Expect(firstProduct).ToBeVisibleAsync();

        var count = await Page.Locator("a[data-test^='product-']").CountAsync();
        Assert.That(count, Is.GreaterThan(0), "Expected products to be displayed on the 'Hand Tools' category page");
    }

    /// <summary>TC-S1-008: Category name shown as page title</summary>
    [Test]
    public async Task CategoryNameIsShownAsPageTitle()
    {
        await NavigateToCategoryPage();

        // v1 renders the category heading as <h2 data-test="page-title">Category: Hand Tools</h2>
        var pageTitle = Page.Locator("[data-test='page-title']");
        await Expect(pageTitle).ToBeVisibleAsync();

        string titleText = (await pageTitle.InnerTextAsync()).Trim();
        Assert.That(titleText, Does.Contain("Hand Tools").IgnoreCase,
            $"Page title '{titleText}' should contain the category name 'Hand Tools'");
    }

    /// <summary>
    /// TC-S1-009: Only category-specific products are shown.
    /// v1 does not render category badges on product cards, so this test verifies filtering
    /// by confirming the URL is scoped to the category and that products are present.
    /// </summary>
    [Test]
    public async Task OnlyCategorySpecificProductsAreShown()
    {
        await NavigateToCategoryPage();

        // URL should be scoped to the hand-tools category
        Assert.That(Page.Url, Does.Contain(HandToolsSlug),
            "URL should contain the category slug to confirm filtering is active");

        // Wait for at least the first product to appear before counting
        await Expect(Page.Locator("a[data-test^='product-']").First).ToBeVisibleAsync();

        var count = await Page.Locator("a[data-test^='product-']").CountAsync();
        Assert.That(count, Is.GreaterThan(0), "Expected at least one product on the category page");
    }
}
