using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestProjectRazor.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public ILogger<IndexModel> Logger { get; } = logger;
    public string Message { get; set; } = null!;

    public void OnGet()
    {
        Message = "Hello, World!";
    }
}
