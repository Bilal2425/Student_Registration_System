using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Registration_System.Models;
using System;
using System.Text;


namespace Student_Registration_System.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Registration? RegistrationModel { get; set; }

        private readonly HttpClient? _httpClient;

        public RegisterModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://yourapi.com/"); // Update with your API base URL
        }

        public void OnGet()
        {
            // Optional: Logic to perform when the page is requested (HTTP GET)
        }

        public IActionResult OnPost()
        {
            return OnPost(RegistrationModel);
        }

        public IActionResult OnPost(Registration? registrationModel)
        {
            // Logic to perform when the form is submitted (HTTP POST)
            if (ModelState.IsValid)
            {
                try
                {
                    // Process the registration using RegistrationModel
                    // E.g., save to the database, perform authentication, etc.

                    // For demonstration purposes, let's just print the registration details to the console
                    Console.WriteLine(value: $"User registered: {registrationModel?.UserName}, {registrationModel?.Password}");

                    // You can add your database interaction or authentication logic here

                    // Return appropriate ActionResult, such as redirecting to another page
                    return RedirectToPage("/Index"); // Change "/SuccessPage" to the actual page you want to redirect to
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., database errors)
                    ModelState.AddModelError("", "An error occurred while processing your registration. Please try again later.");
                    return Page();
                }
            }

            // If ModelState is not valid, return to the same page with validation errors
            return Page();
        }

        public Task<IActionResult> OnPostAsync()
        {
            return OnPostAsync(_httpClient);
        }

        public async Task<IActionResult> OnPostAsync(HttpClient? _httpClient)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Construct form data
                var formData = new List<KeyValuePair<string?, string?>>();
                formData.Add(new KeyValuePair<string?, string?>("UserName", RegistrationModel?.UserName));
                formData.Add(new KeyValuePair<string?, string?>("Password", RegistrationModel?.Password));

                // Encode the form data
                var encodedFormData = new FormUrlEncodedContent(formData);

                // Send POST request with form data
                var response = await _httpClient!.PostAsync("api/Registration/RegisterStudent", encodedFormData);

                if (response.IsSuccessStatusCode)
                {
                    // Registration successful, redirect to the index page
                    return RedirectToPage("/Index");
                }
                else
                {
                    // Handle HTTP error response
                    ModelState.AddModelError("", "An error occurred while processing your registration. Please try again later.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ModelState.AddModelError("", "An error occurred while processing your registration. Please try again later.");
                return Page();
            }
        }

    }
}
