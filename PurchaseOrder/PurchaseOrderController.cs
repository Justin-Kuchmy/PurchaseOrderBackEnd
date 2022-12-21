using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.PurchaseOrders;
using System.Numerics;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController : Controller
{
    //PurchaseOrder controller gets from the repo and the repo class gets from DBContext
    private readonly PurchaseOrderRepository _PurchaseOrderRepository;
    private readonly VendorAndProductsDBContext _db;
    public PurchaseOrderController(PurchaseOrderRepository PurchaseOrderRepo, VendorAndProductsDBContext db)
    {
        _PurchaseOrderRepository = PurchaseOrderRepo;
        _db = db;
    }
    [HttpGet]
    [Route("/api/PurchaseOrders")]
    public async Task<IActionResult> findAll()
    {
        var PurchaseOrders = await _PurchaseOrderRepository.findAll();
        return Ok(PurchaseOrders);
    }
    [HttpPut]
    [Route("/api/PurchaseOrders")]
    public Task<bool> updateOne(PurchaseOrder PurchaseOrder)
    {
        var updatedPurchaseOrder = _PurchaseOrderRepository.updateOne(PurchaseOrder);
        return updatedPurchaseOrder;
    }
    [HttpPost]
    [Route("/api/PurchaseOrders")]
    public Task<PurchaseOrder?> addOne(PurchaseOrder PurchaseOrder)
    {
        var updatedPurchaseOrder = _PurchaseOrderRepository.addOne(PurchaseOrder);
        return updatedPurchaseOrder;
    }
    [HttpDelete]
    [Route("/api/PurchaseOrders/{id}")]
    public async Task<IActionResult> deleteOne([FromRoute] int id)
    {
        var updatedPurchaseOrder = await _PurchaseOrderRepository.deleteOne(id);
        return Ok(updatedPurchaseOrder);
    }
}