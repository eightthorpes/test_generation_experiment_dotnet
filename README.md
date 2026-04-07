# test_generation_experiment_dotnet
A sandbox to experiment with generating playwright test code in .NET using LLMs

## Experiment #2
The first experiment was using Playwright with Python and you can see that in my githup 
repo [test_generation_experiment_python](https://github.com/eightthorpes/test_generation_experiment_python). This is a continuation of that experiment
but using C# which as a language that I don't know at all, is more of a 
challenge to me. 
### Procedure
1. Since I don't even know the basics of C# development, all I did manually 
was to create the repo and clone and install the .NET SDK from Microsoft.
1. I then gave Claude the following prompt `Create a new .NET project in this folder so that I can create playwright tests later` and it seemed to do a good job with that but as I said I don't know the language yet so I can't evaluate it well myself.
1. Next I copied the test plan from the Python project and asked Claude to implement the 14 test cases in .NET(C#)
using this prompt `Write playwright tests in the subfolder PlaywrightTests to implement all of the test cases in Sprint 1 in the test_plan.md.`
1. It created those tests but when I went to run them with the command-line `dotnet test tests/PlaywrightTests/PlaywrightTests.csproj`, I got the following results: `Test summary: total: 14, failed: 13, succeeded: 1, skipped: 0, duration: 102.6s`. 
1. I then asked it to run the tests itself and try to fix any errors and it took quite while but then returned this: 

> 14/14 passing. Here's a summary of every fix that was needed:

> Root cause fixes:

| Issue     | Fix         |
| ----------- | -------------|
| .card selector doesn't exist on v1 | Products are a[data-test='product-N'] list items; .card only exists in the related products section |
| Hash routing (#/product/, #/contact) | Changed WaitForURLAsync patterns to match #/ hash URLs, not HTML5 path URLs |
| Direct navigation to /contact breaks Angular | Always navigate via home page → click [data-test='nav-contact'] | 
| product-price doesn't exist on detail page | v1 uses unit-price |
| product-image, product-category, product-brand absent	Not in v1; | removed those assertions | 
| Validation error text | v1 says "Message must be minimal 50 characters", not "at least 50" |
| CountAsync() race condition (TC-S1-009) | Added Expect(...).ToBeVisibleAsync() before counting to wait for render |
| Category nav uses data-test='nav-hand-tools' | Replaced GetByRole(Link, "Hand Tools") with the data-test locator |
| Subject option text "Status of my order" | Corrected from "Status of order" |
| 5s assertion timeout too short for Angular | Added Assertions.SetDefaultExpectTimeout(15_000) in each [SetUp] |

I will have to go back and validate all of these to make sure they're valid once I know the C# language better.

### Observations
You obviously still really need to know the language to be able to verify that the LMM is actually testing the right things in the right way. It's impressive to see that result of 14 out of 14 passing but as of now, I have no way to validate the correctness of that result. 