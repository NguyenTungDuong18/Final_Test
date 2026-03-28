using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Seller;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class SellerController:ControllerBase
{
    private readonly IService _sellerService;

    public SellerController(IService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpPost("CreateSeller")]
    public  async Task<IActionResult> CreateSeller(Request.CreateSellerRequest request)
    {
        var result = await _sellerService.CreateSeller(request);
        return Ok(result);
    }
}