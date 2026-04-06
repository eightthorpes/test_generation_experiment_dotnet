# Test Plan: Practice Software Testing (practicesoftwaretesting.com)

**Application:** https://practicesoftwaretesting.com/  
**Framework:** Playwright (Python)  
**Total Test Cases:** 123  
**Last Updated:** 2026-04-01  

---

## Overview

This test plan covers the full e-commerce Toolshop application across five sprints. Each sprint incrementally adds features; tests are organized to mirror this progression. All Playwright tests target the hosted versions:

| Sprint | URL |
|--------|-----|
| Sprint 1 | https://v1.practicesoftwaretesting.com |
| Sprint 2 | https://v2.practicesoftwaretesting.com |
| Sprint 3 | https://v3.practicesoftwaretesting.com |
| Sprint 4 | https://v4.practicesoftwaretesting.com |
| Sprint 5 | https://practicesoftwaretesting.com |

**Default Test Accounts:**

| Role | Email | Password |
|------|-------|----------|
| Admin | admin@practicesoftwaretesting.com | welcome01 |
| Customer | customer@practicesoftwaretesting.com | welcome01 |
| Customer 2 | customer2@practicesoftwaretesting.com | welcome01 |

---

## Sprint 1 — Product Catalog Foundation

**Scope:** Product overview, product detail, category browsing, basic contact form.  
**Target URL:** https://v1.practicesoftwaretesting.com

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S1-001 | Product Overview | Product grid is displayed on home page | High | Navigate to home page | 1. Open https://v1.practicesoftwaretesting.com | A grid of product cards is visible | AC1 |
| TC-S1-002 | Product Overview | Each product card shows image, name, and price | High | Home page loaded | 1. Inspect product cards in the grid | Each card displays: product image, product name, product price | AC2 |
| TC-S1-003 | Product Overview | Clicking product card navigates to detail page | High | Home page loaded with product grid | 1. Click on any product card | User is navigated to the product detail page for that product | AC3 |
| TC-S1-004 | Product Detail | Product detail page displays all required information | High | Navigate to any product detail page | 1. Click a product from the overview | Page shows: image, name, description, price, category badge, brand badge | AC2 |
| TC-S1-005 | Product Detail | Related products section is shown | Medium | Product detail page loaded | 1. Scroll to the bottom of the product detail page | A related products section is visible below main product info | AC3 |
| TC-S1-006 | Product Detail | Clicking related product navigates to its detail page | Medium | Product detail page with related products visible | 1. Click any related product | User is navigated to that related product's detail page | AC3 |
| TC-S1-007 | Category | Category page displays products for selected category | High | Home page loaded | 1. Click on a category name in navigation | A page with products belonging to that category is displayed | AC1 |
| TC-S1-008 | Category | Category name shown as page title | Medium | Category page loaded | 1. Navigate to any category page | The category name is shown as the page title | AC2 |
| TC-S1-009 | Category | Only category-specific products are shown | High | Category page loaded | 1. Navigate to a specific category | Only products that belong to the selected category are displayed | AC3 |
| TC-S1-010 | Contact Form | Contact form is accessible via navigation | High | Home page loaded | 1. Click Contact in the navigation | A contact form is displayed on the contact page | AC1 |
| TC-S1-011 | Contact Form | All required fields are present | High | Contact page loaded | 1. Inspect the contact form fields | Fields present: First name, Last name, Email, Subject (dropdown), Message | AC2 |
| TC-S1-012 | Contact Form | Subject dropdown contains all required options | Medium | Contact page loaded | 1. Click on the Subject dropdown | Options include: Customer service, Webmaster, Return, Payments, Warranty, Status of order | AC3 |
| TC-S1-013 | Contact Form | Message under 50 characters shows validation error | High | Contact page loaded | 1. Enter a message fewer than 50 characters 2. Attempt to submit | Validation error shown: message must be at least 50 characters | AC4 |
| TC-S1-014 | Contact Form | Successful form submission shows confirmation | High | Contact page loaded | 1. Fill all required fields with valid data 2. Click Submit | Confirmation message is displayed and form is hidden | AC5 |

---

## Sprint 2 — Search, Filter & Sort

**Scope:** Pagination, search, category/brand filtering, sorting added to product overview and category pages.  
**Target URL:** https://v2.practicesoftwaretesting.com  
**Note:** All Sprint 1 tests still apply.

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S2-001 | Pagination | Pagination controls appear when products exceed one page | High | Home page loaded with many products | 1. Observe the bottom of the product grid | Pagination controls are displayed | AC3 |
| TC-S2-002 | Pagination | Clicking a page number updates the product grid | High | Pagination controls visible | 1. Click page 2 (or any page number) | Product grid updates to show that page's products; clicked page is highlighted | AC4 |
| TC-S2-003 | Search | Search input is visible on product overview | High | Home page loaded | 1. Inspect the product overview page | A search input field is displayed | AC5 |
| TC-S2-004 | Search | Search with fewer than 3 characters triggers validation | High | Home page with search input | 1. Type 2 characters in the search box 2. Submit search | Validation error is shown | AC6 |
| TC-S2-005 | Search | Search input accepts maximum 40 characters | Medium | Home page with search input | 1. Attempt to type more than 40 characters | Input is limited to 40 characters | AC7 |
| TC-S2-006 | Search | Valid search filters the product grid | High | Home page with search input | 1. Enter a valid product name (3–40 chars) 2. Submit | Product grid updates to show only matching products | AC8 |
| TC-S2-007 | Search | Search resets all active filters | High | Home page with category filter applied | 1. Apply a category filter 2. Perform a search | Category, brand, and sort filters are all reset; grid shows search results | AC9 |
| TC-S2-008 | Category Filter | Category filter shows as checkboxes in sidebar | Medium | Home page loaded | 1. Inspect the sidebar | Categories are listed as checkboxes | AC10 |
| TC-S2-009 | Category Filter | Categories display in parent/child tree hierarchy | Medium | Home page with category filter | 1. Inspect category filter structure | Categories are shown in a tree with parent/child relationships | AC11 |
| TC-S2-010 | Category Filter | Checking parent category checks all child categories | High | Home page with category filter | 1. Click on a parent category checkbox | All child categories are checked and product grid updates | AC12 |
| TC-S2-011 | Category Filter | Unchecking all children unchecks the parent | Medium | Parent category and all children checked | 1. Uncheck each child category one by one | When last child is unchecked, the parent is also unchecked | AC13 |
| TC-S2-012 | Brand Filter | Brand filter shows as checkboxes in sidebar | Medium | Home page loaded | 1. Inspect the sidebar | Brands are listed as checkboxes | AC14 |
| TC-S2-013 | Brand Filter | Selecting a brand filters products to that brand | High | Home page with brand filter | 1. Check a brand checkbox | Product grid updates to show only products from that brand | AC15 |
| TC-S2-014 | Combined Filters | Category and brand filters can be used together | High | Home page with filters | 1. Select a category 2. Select a brand | Product grid shows products matching both category AND brand | AC16 |
| TC-S2-015 | Sorting | Sort dropdown is visible on product overview | Medium | Home page loaded | 1. Inspect the product overview | A sort dropdown is displayed | AC17 |
| TC-S2-016 | Sorting | Name A-Z sorting orders products alphabetically | High | Home page with sort dropdown | 1. Select "Name (A-Z)" from sort dropdown | Products are ordered from A to Z by name | AC18/19 |
| TC-S2-017 | Sorting | Name Z-A sorting orders products reverse alphabetically | High | Home page with sort dropdown | 1. Select "Name (Z-A)" from sort dropdown | Products are ordered from Z to A by name | AC18/19 |
| TC-S2-018 | Sorting | Price High-Low sorting orders products by descending price | High | Home page with sort dropdown | 1. Select "Price (High-Low)" from sort dropdown | Products are ordered from highest to lowest price | AC18/19 |
| TC-S2-019 | Sorting | Price Low-High sorting orders products by ascending price | High | Home page with sort dropdown | 1. Select "Price (Low-High)" from sort dropdown | Products are ordered from lowest to highest price | AC18/19 |

---

## Sprint 3 — Checkout Flow & Rentals

**Scope:** Add to cart, quantity selector, rental products, cart review, billing address, basic payment.  
**Target URL:** https://v3.practicesoftwaretesting.com  
**Note:** All Sprint 1–2 tests still apply.

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S3-001 | Product Detail | Quantity selector with +/- buttons is shown | High | Product detail page loaded | 1. Navigate to any in-stock product | Quantity selector with + and - buttons is visible; default is 1 | AC2/AC3 |
| TC-S3-002 | Product Detail | Plus button increases quantity by 1 | High | Product detail page with quantity = 1 | 1. Click the + button once | Quantity increments to 2 | AC3 |
| TC-S3-003 | Product Detail | Minus button decreases quantity by 1 | High | Product detail page with quantity = 2 | 1. Set quantity to 2 2. Click the - button | Quantity decrements to 1 | AC4 |
| TC-S3-004 | Product Detail | Minimum quantity cannot go below 1 | High | Product detail page with quantity = 1 | 1. Click the - button | Quantity stays at 1; does not go to 0 | AC5 |
| TC-S3-005 | Product Detail | Add to Cart shows success message | High | In-stock product detail page | 1. Click "Add to Cart" | Success message: "Product added to shopping cart." | AC7 |
| TC-S3-006 | Product Detail | Out of stock product disables Add to Cart | High | Navigate to an out-of-stock product | 1. Inspect the Add to Cart button | Button is disabled and "Out of stock" is shown in red | AC8 |
| TC-S3-007 | Rentals | Rentals page is accessible | Medium | Home page loaded | 1. Navigate to /rentals | All rental products are listed | AC1 |
| TC-S3-008 | Rentals | Rental product cards show image, name, description | Medium | Rentals page loaded | 1. Inspect rental product cards | Each rental card shows an image, name, and description | AC2 |
| TC-S3-009 | Rentals | Rental detail shows duration slider (1–10 hours) | High | Rental product detail page loaded | 1. Navigate to a rental product detail | A duration slider from 1 to 10 hours is displayed | AC3 |
| TC-S3-010 | Rentals | Rental total price calculates correctly by duration | High | Rental product detail with slider | 1. Move the slider to 3 hours 2. Observe total price | Total = hourly rate × selected duration | AC3 |
| TC-S3-011 | Rentals | Rental items are marked in cart | Medium | Rental product added to cart | 1. Add a rental product to cart 2. Open cart | Rental item is marked as "This is a rental item" | AC4 |
| TC-S3-012 | Cart Review | Cart table shows correct columns | High | At least one product in cart; navigate to checkout | 1. Open cart review step | Table shows: Item, Quantity, Price, Total, Actions | AC1 |
| TC-S3-013 | Cart Review | Updating quantity recalculates cart totals | High | Cart with at least one item | 1. Change quantity of an item 2. Confirm | Item total and cart total are recalculated; confirmation message shown | AC2 |
| TC-S3-014 | Cart Review | Deleting an item removes it from cart | High | Cart with at least two items | 1. Click delete on one item | Item is removed; cart total is recalculated | AC3 |
| TC-S3-015 | Cart Review | Empty cart shows appropriate message | Medium | Empty shopping cart | 1. Navigate to cart review with no items | Message: "Your shopping cart is empty" | AC4 |
| TC-S3-016 | Cart Review | Proceed button requires at least one item | High | Empty cart | 1. Navigate to checkout with empty cart | Proceed button is disabled or user cannot advance | AC5 |
| TC-S3-017 | Billing Address | All required billing fields are present | High | Cart with item; advance to billing address step | 1. Inspect the billing address form | Required fields present: Street, City, State, Country, Postal code | AC1 |
| TC-S3-018 | Billing Address | Empty required fields prevent proceeding | High | Billing address step | 1. Leave all fields empty 2. Click Proceed | Fields are highlighted as invalid; Proceed is disabled | AC2 |
| TC-S3-019 | Billing Address | Valid billing address allows proceeding to payment | High | Billing address step | 1. Fill all required fields with valid data 2. Click Proceed | User advances to the payment step | AC3 |
| TC-S3-020 | Payment | Payment method dropdown contains all options | High | Payment step of checkout | 1. Click the payment method dropdown | Options: Bank Transfer, Cash on Delivery, Credit Card, Buy Now Pay Later, Gift Card | AC1 |
| TC-S3-021 | Payment | Selecting a payment method shows relevant fields | High | Payment step with method selected | 1. Select "Bank Transfer" 2. Observe form | Account name and account number fields are displayed | AC2 |
| TC-S3-022 | Payment | Successful order shows confirmation with invoice number | High | Payment step; all info filled in | 1. Complete checkout with valid payment info 2. Submit | Confirmation message shown with invoice number; cart is cleared | AC3 |

---

## Sprint 4 — Authentication & Customer Account

**Scope:** User login/register/forgot password, customer account (profile, favorites, invoices, messages), favorites on product detail, checkout login step.  
**Target URL:** https://v4.practicesoftwaretesting.com  
**Note:** All Sprint 1–3 tests still apply.

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S4-001 | Favorites | Add to Favorites button shown on product detail | Medium | Logged-in user on product detail page | 1. Navigate to any product detail page | "Add to Favorites" button is visible | AC10 |
| TC-S4-002 | Favorites | Logged-in user can add product to favorites | High | Logged-in user; product not yet favorited | 1. Click "Add to Favorites" | Message: "Product added to your favorites list." | AC11 |
| TC-S4-003 | Favorites | Already favorited product shows duplicate message | Medium | Logged-in user; product already in favorites | 1. Click "Add to Favorites" on already-favorited product | Message: "Product already in your favorites list." | AC12 |
| TC-S4-004 | Favorites | Guest cannot add product to favorites | High | Not logged in; on product detail page | 1. Click "Add to Favorites" | Message: "Unauthorized, can not add product to your favorite list." | AC13 |
| TC-S4-005 | Checkout Login | Login step is displayed for guest users | High | Not logged in; item in cart; at cart review step | 1. Click Proceed from cart review | A login step is shown before billing address | AC1 |
| TC-S4-006 | Checkout Login | Login form contains email and password fields | High | Checkout login step displayed | 1. Inspect the checkout login form | Email and password fields and submit button are present | AC2 |
| TC-S4-007 | Checkout Login | Successful login during checkout proceeds to billing | High | Checkout login step; valid credentials | 1. Enter valid email and password 2. Submit | User is authenticated and advances to the billing address step | AC3 |
| TC-S4-008 | Checkout Login | Already logged-in message shown in checkout | Medium | Logged-in user at checkout | 1. Navigate to checkout login step while logged in | Message: "You are already signed in as [First Name] [Last Name]" | AC4 |
| TC-S4-009 | Registration | Registration page is accessible when logged out | High | Not logged in | 1. Navigate to /auth/register | Registration form is displayed | AC1 |
| TC-S4-010 | Registration | All required registration fields are present | High | Registration page loaded | 1. Inspect the registration form | Required fields: First name, Last name, Date of birth, Address, Postcode, City, State, Country, Phone, Email, Password | AC2 |
| TC-S4-011 | Registration | Email must be in valid format | High | Registration page loaded | 1. Enter an invalid email format (e.g., "notanemail") 2. Submit | Email validation error is displayed | AC3 |
| TC-S4-012 | Registration | Password must be 6–40 characters | High | Registration page loaded | 1. Enter a password of 5 characters 2. Submit | Password length validation error is displayed | AC4 |
| TC-S4-013 | Registration | Duplicate email shows error | High | Registration page; email already in use | 1. Register with email customer@practicesoftwaretesting.com | Error: "Email is already in use." | AC5 |
| TC-S4-014 | Registration | Successful registration redirects to login | High | Registration page with all valid data | 1. Fill all fields with valid unique data 2. Submit | Account is created; user is redirected to login page | AC6 |
| TC-S4-015 | Login | Login form is accessible | High | Not logged in | 1. Navigate to /auth/login | Login form with email and password fields is displayed | AC1 |
| TC-S4-016 | Login | Email field requires valid format | High | Login page loaded | 1. Enter invalid email format 2. Submit | Email format validation error shown | AC2 |
| TC-S4-017 | Login | Password field is required | High | Login page loaded | 1. Leave password empty 2. Submit | Password required error is shown | AC3 |
| TC-S4-018 | Login | Valid credentials authenticate user and redirect | High | Login page; valid credentials available | 1. Enter customer@practicesoftwaretesting.com / welcome01 2. Submit | User is authenticated and redirected to account dashboard | AC4 |
| TC-S4-019 | Login | Invalid credentials show error message | High | Login page loaded | 1. Enter invalid email/password 2. Submit | Error: "Invalid email or password" | AC5 |
| TC-S4-020 | Forgot Password | Forgot password form is accessible | Medium | Login page loaded | 1. Click "Forgot password" link | Forgot password form with email input is displayed | AC1 |
| TC-S4-021 | Forgot Password | Email format is validated | Medium | Forgot password page loaded | 1. Enter invalid email format 2. Submit | Email format validation error shown | AC2 |
| TC-S4-022 | Forgot Password | Registered email shows confirmation | High | Forgot password page | 1. Enter customer@practicesoftwaretesting.com 2. Submit | Confirmation message is displayed and fades after 3 seconds | AC3 |
| TC-S4-023 | Forgot Password | Unregistered email shows error | Medium | Forgot password page | 1. Enter unknown@example.com 2. Submit | Error message is displayed | AC4 |
| TC-S4-024 | Customer Profile | Profile page shows current user info | High | Logged in as customer | 1. Navigate to account profile | Current profile information is displayed | AC1 |
| TC-S4-025 | Customer Profile | Profile fields are editable | High | Profile page loaded | 1. Modify first name, last name, phone, address 2. Save | Fields accept new values and save button is enabled | AC2 |
| TC-S4-026 | Customer Profile | Email field is read-only | Medium | Profile page loaded | 1. Attempt to click on and edit the email field | Email field cannot be edited | AC3 |
| TC-S4-027 | Customer Profile | Saving valid profile shows success message | High | Profile page with modified data | 1. Fill valid data in editable fields 2. Click Save | Success message is displayed | AC4 |
| TC-S4-028 | Change Password | Wrong current password shows error | High | Logged in; change password section on profile | 1. Enter incorrect current password 2. Submit | Error: "Your current password does not matches with the password." | AC2 |
| TC-S4-029 | Change Password | New password same as current shows error | High | Logged in; change password section | 1. Enter correct current password and same password as new 2. Submit | Error: "New Password cannot be same as your current password." | AC3 |
| TC-S4-030 | Change Password | Mismatched new passwords show error | High | Logged in; change password section | 1. Enter new password and different confirm password 2. Submit | Error: "Passwords do not match." | AC4 |
| TC-S4-031 | Change Password | Successful password change logs out after 5 seconds | High | Logged in; change password section | 1. Enter valid current + new password (confirmed) 2. Submit | Success message shown; user is logged out after 5 seconds | AC5 |
| TC-S4-032 | Favorites List | Favorites page shows favorited products | High | Logged in; at least one product favorited | 1. Navigate to /account/favorites | Favorited products shown with image, name, description (truncated to 250 chars) | AC1 |
| TC-S4-033 | Favorites List | Empty favorites shows a message | Medium | Logged in; no favorited products | 1. Navigate to /account/favorites | Appropriate empty state message is shown | AC2 |
| TC-S4-034 | Favorites List | Deleting a favorite removes it from the list | High | Logged in; favorites page with items | 1. Click delete on a favorited product | Product is removed from the list; list refreshes | AC3 |
| TC-S4-035 | Invoices | Invoice list is paginated | Medium | Logged in with past orders | 1. Navigate to /account/invoices | Paginated table with invoice number, billing street, date, total, details link | AC1 |
| TC-S4-036 | Invoices | Invoice detail shows full order information | High | Logged in; navigate to a specific invoice | 1. Click details on an invoice | Detail shows: number, date, total, billing address, payment method, line items with qty/name/price | AC2 |
| TC-S4-037 | Invoices | Non-existent or unauthorized invoice shows not found | Medium | Logged in | 1. Navigate to an invoice ID belonging to another user | "Not found" error message is displayed | AC3 |
| TC-S4-038 | Messages | Messages list shows paginated contact messages | Medium | Logged in; has sent contact messages | 1. Navigate to /account/messages | Paginated table with subject, message preview (50 chars), status badge, date, details link | AC1 |
| TC-S4-039 | Messages | Message detail shows full message and reply history | High | Logged in; on messages list | 1. Click details on a message | Shows sender, subject, status, full text, timestamp, and replies in chronological order | AC2 |
| TC-S4-040 | Messages | User can reply to a message | High | Logged in; message detail page | 1. Enter reply text 2. Submit | Reply is added to the thread; list is updated | AC3 |

---

## Sprint 5 — Full Platform

**Scope:** Advanced checkout, enhanced security (TOTP, account locking, social login), admin dashboard, chat widget, geo-location discounts, multi-language, privacy policy, PDF invoices, advanced contact form.  
**Target URL:** https://practicesoftwaretesting.com  
**Note:** All Sprint 1–4 tests still apply.

### Product & Catalog

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-001 | Product Overview | Price range slider is visible and functional | High | Home page loaded | 1. Inspect product overview sidebar | Price range slider defaulting to $1–$100 is displayed; adjusting it filters products | S5 AC |
| TC-S5-002 | Product Overview | Discount badge shown on discounted products | Medium | Home page loaded; discounted products exist | 1. Browse product grid | Products with active discounts show a discount badge | S5 AC |
| TC-S5-003 | Product Overview | Out-of-stock indicator shown on unavailable products | Medium | Home page with out-of-stock products | 1. Browse product grid | Out-of-stock products show an out-of-stock indicator | S5 AC |

### Checkout — Enhancements

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-004 | Cart Review | Discount badge and price breakdown shown for discounted items | High | Cart with a discounted item | 1. Open cart review | Discount badge visible; original price and discounted price both shown | AC6 |
| TC-S5-005 | Cart Review | Combination discount applied for mixed rental/non-rental cart | High | Cart with both a rental and a non-rental item | 1. Open cart review | Cart shows: subtotal, 15% discount amount, final total | AC7 |
| TC-S5-006 | Cart Review | Combination discount removed when cart becomes single-type | High | Cart with combination discount active | 1. Remove all rental items from cart | 15% combination discount is removed; totals recalculated | AC8 |
| TC-S5-007 | Checkout Login | TOTP required when 2FA is enabled | High | Guest with TOTP-enabled account; item in cart | 1. Reach checkout login step 2. Enter valid email and password | TOTP prompt appears asking for 6-digit code | S5 AC3 |
| TC-S5-008 | Billing Address | Address pre-filled for logged-in users | High | Logged-in user with saved address; at billing step | 1. Proceed to billing address step | Address fields are pre-populated from account details | AC4 |
| TC-S5-009 | Payment (Advanced) | Bank Transfer fields validate correctly | High | Payment step; Bank Transfer selected | 1. Enter bank name with numbers 2. Submit | Validation error: bank name must be letters and spaces only | AC2 |
| TC-S5-010 | Payment (Advanced) | Credit card number must match XXXX-XXXX-XXXX-XXXX format | High | Payment step; Credit Card selected | 1. Enter card number without dashes 2. Submit | Validation error: card number format invalid | AC3 |
| TC-S5-011 | Payment (Advanced) | Past expiration date on credit card shows error | High | Payment step; Credit Card selected | 1. Enter an expired date (e.g., 01/2020) 2. Submit | Error: "Expiration date must be in the future." | AC4 |
| TC-S5-012 | Payment (Advanced) | CVV must be 3 or 4 digits | High | Payment step; Credit Card selected | 1. Enter a 2-digit CVV 2. Submit | CVV validation error is shown | AC3 |
| TC-S5-013 | Payment (Advanced) | Buy Now Pay Later shows installments dropdown | High | Payment step; Buy Now Pay Later selected | 1. Inspect the payment form | Monthly installments dropdown shows: 3, 6, 9, 12 | AC5 |
| TC-S5-014 | Payment (Advanced) | Gift Card shows card number and validation code fields | High | Payment step; Gift Card selected | 1. Inspect the payment form | Gift card number and validation code (both alphanumeric) fields shown | AC6 |
| TC-S5-015 | Payment (Advanced) | Cash on Delivery shows no additional fields | Medium | Payment step; Cash on Delivery selected | 1. Select Cash on Delivery 2. Inspect form | No additional payment fields are shown | AC7 |
| TC-S5-016 | Payment (Advanced) | Switching payment method resets form | High | Payment step; one method already selected with data | 1. Switch to a different payment method | Previous form inputs are cleared | AC8 |
| TC-S5-017 | Payment (Advanced) | Successful order sends confirmation email | High | All checkout steps completed with valid data | 1. Complete checkout 2. Check email | Order confirmation with invoice number shown; confirmation email received | AC9 |

### Authentication — Enhancements

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-018 | Registration | Password requires uppercase, lowercase, number, special char | High | Registration page loaded | 1. Enter a password with only lowercase letters 2. Submit | Password strength validation error shown; requirements listed | S5 AC2 |
| TC-S5-019 | Registration | Password strength indicator shows correct level | High | Registration page loaded | 1. Enter passwords of varying complexity | Indicator updates: Weak → Moderate → Strong → Very Strong → Excellent | S5 AC4 |
| TC-S5-020 | Registration | Successful registration sends confirmation email | Medium | Registration page; valid unique data | 1. Complete registration 2. Check email | Account created; confirmation email received; redirected to login | S5 AC6 |
| TC-S5-021 | Login | Google Sign In button is visible | Medium | Login page loaded | 1. Inspect the login form | "Sign in with Google" button is displayed | AC1 |
| TC-S5-022 | Login | Account locks after 3 consecutive failed attempts | High | Login page; non-admin account | 1. Enter invalid credentials 3 times | Error: "Account locked, too many failed attempts. Please contact the administrator." | AC4 |
| TC-S5-023 | Login | Admin account is not locked after failed attempts | High | Login page; admin credentials | 1. Enter incorrect password 4+ times for admin account | Account remains unlocked; error remains "Invalid email or password" | AC5 |
| TC-S5-024 | Login | Disabled account cannot log in | High | Login page; disabled user account | 1. Attempt to log in with disabled account | Error: "Account disabled." | AC6 |
| TC-S5-025 | Login | TOTP prompt shown after valid credentials if 2FA enabled | High | Login page; user with TOTP configured | 1. Enter valid email and password for TOTP-enabled user | TOTP input prompt is shown | AC7 |
| TC-S5-026 | Login | Valid TOTP authenticates user | High | TOTP prompt shown | 1. Enter valid 6-digit TOTP code | User is fully authenticated and redirected to account page | AC8 |
| TC-S5-027 | Login | Invalid TOTP shows error | High | TOTP prompt shown | 1. Enter an invalid 6-digit code | Error: "Invalid TOTP" | AC9 |
| TC-S5-028 | Two-Factor Auth | TOTP setup section visible on profile page | High | Logged in; on profile page | 1. Inspect the profile page | "Setup two factor authentication" section is displayed | AC1 |
| TC-S5-029 | Two-Factor Auth | QR code is displayed for scanning | High | Profile page with TOTP section | 1. Open TOTP setup section | QR code for authenticator app is displayed | AC2 |
| TC-S5-030 | Two-Factor Auth | Secret key is shown as text for manual entry | Medium | Profile page with TOTP section | 1. Open TOTP setup section | Secret key is displayed as plaintext | AC3 |
| TC-S5-031 | Two-Factor Auth | Valid TOTP code enables 2FA | High | Profile page; TOTP setup with QR code scanned | 1. Enter valid 6-digit code 2. Click Verify TOTP | Success: "TOTP verified and enabled successfully." | AC4 |
| TC-S5-032 | Two-Factor Auth | Invalid TOTP code shows error | High | Profile page; TOTP setup | 1. Enter invalid 6-digit code 2. Click Verify TOTP | Error message shown | AC5 |
| TC-S5-033 | Two-Factor Auth | Specific accounts cannot configure TOTP | High | Logged in as customer@practicesoftwaretesting.com | 1. Navigate to TOTP setup | Error: "Access denied: If you want to configure TOTP, please create your own account." | AC6 |

### Account — Enhancements

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-034 | Customer Profile | Profile includes address fields (Street, Postal, City, State, Country) | High | Logged in; on profile page | 1. Inspect the profile form | Address fields Street, Postal code, City, State, Country are editable | S5 AC2 |
| TC-S5-035 | Customer Profile | Success message fades after 5 seconds | Low | Profile page; saved successfully | 1. Save a profile change | Success message is displayed and fades after 5 seconds | S5 AC4 |
| TC-S5-036 | Change Password | Password strength indicator shown on new password | Medium | Logged in; change password section | 1. Type a new password of varying complexity | Strength indicator updates through 5 levels | S5 AC2 |
| TC-S5-037 | Invoices | Invoice with discount shows subtotal, discount, final total | High | Logged in; invoice with discounted item | 1. Open an invoice with a discount | Invoice shows: subtotal, discount %, discount amount, final total | AC4 |
| TC-S5-038 | Invoices | Discounted line items show strikethrough original price | Medium | Invoice page with discounted items | 1. Inspect line items | Original price shown with strikethrough; discounted price shown below | AC5 |
| TC-S5-039 | Invoices | PDF download button present on invoice detail | High | Logged in; on invoice detail page | 1. Inspect the invoice detail page | A PDF download button is visible | AC6 |
| TC-S5-040 | Invoices | PDF download button is disabled while generating | High | Invoice detail page; PDF generation started | 1. Click PDF download button 2. Observe button state | Button becomes disabled; status is checked every 20 seconds | AC7 |
| TC-S5-041 | Invoices | PDF downloads when generation is complete | High | Invoice detail; PDF generation complete | 1. Wait for PDF to be ready 2. Click download | PDF file is downloaded | AC8 |

### Contact Form (Advanced)

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-042 | Contact Form | Logged-in user has name/email auto-filled and hidden | High | Logged in; contact page loaded | 1. Navigate to /contact | Name and email fields are auto-filled; "Known user, [Full Name]" shown; name/email fields hidden | AC1 |
| TC-S5-043 | Contact Form | Guest must fill name and email fields | High | Not logged in; contact page loaded | 1. Navigate to /contact | First name, last name, and email fields are required and visible | AC2 |
| TC-S5-044 | Contact Form | File attachment only accepts .txt extension | High | Contact page loaded | 1. Attempt to upload a .pdf or .jpg file as attachment | Error: "File should have a txt extension." | AC5 |
| TC-S5-045 | Contact Form | File attachment must be exactly 0 KB | High | Contact page loaded; valid .txt file selected | 1. Upload a .txt file with content (non-empty) | Error: "File should be empty." | AC6 |
| TC-S5-046 | Contact Form | Successful submission sends confirmation email | High | Contact page; all fields valid; valid 0-KB .txt file | 1. Fill all fields 2. Attach valid .txt 3. Submit | Confirmation message shown; confirmation email sent to provided address | AC7 |

### Admin Dashboard

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-047 | Admin | Admin dashboard shows sales chart and recent invoices | High | Logged in as admin | 1. Navigate to /admin/dashboard | Bar chart of total sales by year is displayed; paginated recent invoices shown | AC1 |
| TC-S5-048 | Admin | Admin can create, edit, and delete products | High | Logged in as admin | 1. Navigate to product management 2. Create, edit, delete a product | All CRUD operations succeed | AC2 |
| TC-S5-049 | Admin | Admin can manage categories with optional parent | High | Logged in as admin | 1. Navigate to category management 2. Create category with and without parent | Category CRUD works; parent category is optional | AC3 |
| TC-S5-050 | Admin | Admin can manage brands | High | Logged in as admin | 1. Navigate to brand management 2. Create, edit, delete a brand | Brand CRUD operations succeed | AC4 |
| TC-S5-051 | Admin | Admin can view orders and update status | High | Logged in as admin; orders exist | 1. Navigate to order management 2. Open an order 3. Update status | Status updates to: AWAITING_FULFILLMENT, ON_HOLD, AWAITING_SHIPMENT, SHIPPED, or COMPLETED | AC5 |
| TC-S5-052 | Admin | Admin can view, edit, and delete user accounts | High | Logged in as admin | 1. Navigate to user management 2. View, edit, delete a user | User CRUD operations succeed | AC6 |
| TC-S5-053 | Admin | Admin can disable a user account | High | Logged in as admin; non-admin user exists | 1. Find a user account 2. Toggle Enabled to disabled | User account is disabled; that user cannot log in immediately | AC7 |
| TC-S5-054 | Admin | Admin can re-enable a disabled user account | High | Logged in as admin; disabled user exists | 1. Find disabled user 2. Toggle Enabled to enabled | User account is re-enabled; that user can log in again | AC7 |
| TC-S5-055 | Admin | Admin can view and reply to contact messages | High | Logged in as admin; messages exist | 1. Navigate to message management 2. Open a message 3. Reply | Reply is sent; message thread updated | AC8 |
| TC-S5-056 | Admin | Admin can view reports (monthly sales, weekly sales, statistics) | Medium | Logged in as admin | 1. Navigate to reports section | Monthly sales, weekly sales, and general statistics reports are displayed | AC9 |

### Chat Widget

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-057 | Chat Widget | Chat widget toggle button visible in bottom-right | Medium | Any page loaded | 1. Inspect bottom-right corner of page | Toggle button is visible | AC1 |
| TC-S5-058 | Chat Widget | Opening chat shows main menu options | Medium | Chat widget button visible | 1. Click toggle button | Chat opens with menu: Find Product, Order Product, Checkout, Support | AC1 |
| TC-S5-059 | Chat Widget | Find Product returns up to 5 matching product cards | High | Chat widget open | 1. Select "Find Product" 2. Enter a search query | Up to 5 matching product cards displayed; "View Product" navigates to detail page | AC2 |
| TC-S5-060 | Chat Widget | Order Product adds item to cart | High | Chat widget open | 1. Select "Order Product" 2. Search for product 3. Select quantity 4. Confirm | Product is added to cart | AC3 |
| TC-S5-061 | Chat Widget | Checkout via chat completes full flow | High | Chat widget open; item in cart | 1. Select "Checkout" 2. Follow chat prompts through cart, address, payment | Order is confirmed with invoice number | AC4 |
| TC-S5-062 | Chat Widget | Checkout with empty cart shows message | Medium | Chat widget open; cart is empty | 1. Select "Checkout" | Message: "Your cart is empty" | AC5 |
| TC-S5-063 | Chat Widget | Support via chat submits a message | High | Chat widget open | 1. Select "Support" 2. Provide subject, message (50+ chars), optional .txt file (if logged out, also name/email) | Confirmation message is displayed | AC6 |

### Discounts & Localization

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-064 | Geo-Location | Geo-location discount applied for supported city | High | Browsing from or simulating location in New York | 1. Browse eligible products | Discounted price shown (5% for New York); original price struck through | AC1/AC2 |
| TC-S5-065 | Geo-Location | No discount applied for unsupported location | Medium | Browsing from unsupported location | 1. Browse products | No geo-location discount applied; original price shown | AC3 |
| TC-S5-066 | Geo-Location | Discounted price used in cart line item | High | Geo-location discount applied to product | 1. Add discounted product to cart 2. View cart | Cart uses the discounted price for the line item | AC4 |
| TC-S5-067 | Combination Discount | 15% discount shown for mixed rental/non-rental cart | High | Cart with both rental and non-rental items | 1. Open cart review | Cart shows: subtotal, 15% discount %, discount amount, final total | AC2 |
| TC-S5-068 | Combination Discount | 15% discount shown on invoice | High | Placed order with combination discount | 1. Open invoice for that order | Invoice shows: subtotal, 15% discount amount, final total | AC4 |

### Multi-Language & Privacy

| Test ID | Feature | Test Case Name | Priority | Pre-Conditions | Steps | Expected Result | AC Ref |
|---------|---------|----------------|----------|---------------|-------|-----------------|--------|
| TC-S5-069 | Multi-Language | App auto-detects supported browser language | Medium | Browser set to German (de) | 1. Open app for first time (clear localStorage) | App is displayed in German | AC1 |
| TC-S5-070 | Multi-Language | Unsupported browser language defaults to English | Medium | Browser set to Japanese (ja) | 1. Open app for first time (clear localStorage) | App defaults to English | AC2 |
| TC-S5-071 | Multi-Language | Language selector in navigation bar | Medium | App loaded | 1. Inspect navigation bar | Language selector showing DE, EN, ES, FR, NL, TR is visible | AC3 |
| TC-S5-072 | Multi-Language | Selecting a language updates all UI elements | High | App loaded; language selector visible | 1. Select "FR" (French) | All labels, messages, and UI text update to French | AC4 |
| TC-S5-073 | Multi-Language | Language preference persists across sessions | Medium | Language switched to Spanish | 1. Reload or close and reopen app | App remains in Spanish; localStorage preference is used | AC5 |
| TC-S5-074 | Privacy Policy | Privacy policy page is accessible at /privacy | Low | App loaded | 1. Navigate to /privacy | Privacy policy page is displayed | AC1 |
| TC-S5-075 | Privacy Policy | Privacy policy covers required content sections | Low | Privacy policy page loaded | 1. Inspect the page content | Page includes: Google Sign-In, data collection, automatic data removal, third-party services, data security, contact info | AC1 |

---

## Test Summary by Sprint

| Sprint | New Test Cases | Cumulative Total | Key Features Added |
|--------|---------------|------------------|--------------------|
| Sprint 1 | 14 | 14 | Product catalog, category browsing, contact form |
| Sprint 2 | 19 | 33 | Pagination, search, category/brand filters, sorting |
| Sprint 3 | 22 | 55 | Add to cart, quantity selector, rentals, checkout flow |
| Sprint 4 | 40 | 95 | Auth (login/register/forgot), customer account, favorites, invoices, messages |
| Sprint 5 | 75 | 123 | Advanced checkout, TOTP/2FA, account locking, admin, chat widget, discounts, i18n, PDF invoices |

---

## Test Types & Coverage

| Test Type | Count | Description |
|-----------|-------|-------------|
| Functional | 95 | Core feature behavior per acceptance criteria |
| Validation | 18 | Form validation and input boundary tests |
| Navigation | 7 | Page routing and redirects |
| Security (functional) | 3 | Auth controls (TOTP, account locking, authorization checks) |

---

## Notes

- **Test Isolation:** Each test should use fresh data or clean up after itself. Use the `/refresh` API endpoint (POST) to reset the database between test runs during development.
- **Authentication:** Tests requiring login should use the `customer@practicesoftwaretesting.com` / `welcome01` account by default, except where admin or a specific state is needed.
- **TOTP Tests:** Require a separate test account with TOTP configured; the seed accounts (`customer@` and `admin@`) explicitly block TOTP setup.
- **Geo-Location Tests:** May need to mock or stub geolocation in Playwright to simulate different cities without relying on actual IP location.
- **PDF Generation:** Tests for PDF invoice polling should account for asynchronous behavior; use appropriate waits rather than fixed sleeps.
- **Email Tests:** Sprint 5 tests that verify confirmation emails should integrate with an email testing service or use MailHog in a local environment.
