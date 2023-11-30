using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WebStoreApp.DataAccess.Repository.Concracts;
using WebStoreApp.Dto;
using WebStoreApp.Services.Contract;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController: ControllerBase
    {
        public readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<SellerDto>> GetById(int id) 
        {
            return await _sellerService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] SellerDto seller)
        {
            return await _sellerService.Create(seller);
        }

        [HttpGet]
        public async Task<ActionResult<List<SellerDto>>> GetAll()
        {
            return await _sellerService.GetAll();
        }
    }
}
