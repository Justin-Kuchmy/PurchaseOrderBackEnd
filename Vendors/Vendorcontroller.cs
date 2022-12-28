using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Vendors;
using System.Numerics;

[ApiController]
[Route("api/[controller]")]
public class VendorController : Controller
{
    //vendor controller gets from the repo and the repo class gets from DBContext
    private readonly VendorRepository _vendorRepository;
    private readonly VendorAndProductsDBContext _db;
    public VendorController(VendorRepository vendorRepo, VendorAndProductsDBContext db)
    {
        _vendorRepository = vendorRepo;
        _db = db;
    }
    [HttpGet]
    [Route("/api/vendors")]
    public async Task<IActionResult> findAll()
    {
        var vendors = await _vendorRepository.findAll();
        return Ok(vendors);
    }
    [HttpPut]
    [Route("/api/vendors/{id}")]
    public async Task<IActionResult> updateOne([FromRoute] int id, Vendors updateVendorRequest)
    {
      
        var updatedVendor = await _vendorRepository.updateOne(id, updateVendorRequest);
        return Ok(updatedVendor);
    }
    [HttpPost]
    [Route("/api/vendors")]
    public Task<Vendors?> addOne(Vendors vendor)
    {
        var updatedVendor = _vendorRepository.addOne(vendor);
        return updatedVendor;
    }
    [HttpDelete]
    [Route("/api/vendors/{id}")]
    public async Task<IActionResult> deleteOne([FromRoute] int id)
    {
        var updatedVendor = await _vendorRepository.deleteOne(id);
        return Ok(updatedVendor);
    }
}