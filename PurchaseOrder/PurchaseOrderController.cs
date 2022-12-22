using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.PurchaseOrders;
using PurchaseOrderBackEnd.Products;
using System.Numerics;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController : Controller
{
    //PurchaseOrder controller gets from the repo and the repo class gets from DBContext
    private readonly PurchaseOrderRepository _PurchaseOrderRepository;
    private readonly ProductRepository _ProductRepository;
    private readonly PurchaseOrderDAO _purchaseOrderDAO;
    private readonly VendorAndProductsDBContext _db;
    public PurchaseOrderController(PurchaseOrderRepository PurchaseOrderRepo, VendorAndProductsDBContext db, ProductRepository prodRepo, PurchaseOrderDAO po_DAO)
    {
        _PurchaseOrderRepository = PurchaseOrderRepo;
        _purchaseOrderDAO = po_DAO;
        _ProductRepository = prodRepo;
        _db = db;
    }
    [HttpGet]
    [Route("/api/pos")]
    public async Task<IActionResult> findAll()
    {
        var PurchaseOrders = await _PurchaseOrderRepository.findAll();
        return Ok(PurchaseOrders);
    }
    [HttpPut]
    [Route("/api/pos")]
    public Task<bool> updateOne([FromBody] PurchaseOrders PurchaseOrder)
    {
        var updatedPurchaseOrder = _PurchaseOrderRepository.updateOne(PurchaseOrder);
        return updatedPurchaseOrder;
    }
    [HttpPost]
    [Route("/api/pos")]
    public async Task<PurchaseOrders?> addOne([FromBody] PurchaseOrders purchaseOrder)
    {
        var newPO = await _purchaseOrderDAO.create(purchaseOrder, _ProductRepository);
        var updatedPurchaseOrder = _PurchaseOrderRepository.addOne(newPO);
        return updatedPurchaseOrder.Result;
    }
    [HttpDelete]
    [Route("/api/pos/{id}")]
    public async Task<IActionResult> deleteOne([FromRoute] int id)
    {
        var updatedPurchaseOrder = await _PurchaseOrderRepository.deleteOne(id);
        return Ok(updatedPurchaseOrder);
    }
}