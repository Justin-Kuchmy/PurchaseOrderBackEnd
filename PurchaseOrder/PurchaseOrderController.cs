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
    private readonly PurchaseOrderLineItemRepository _PurchaseOrderLineItemRepository;
    private readonly PurchaseOrderDAO _purchaseOrderDAO;
    private readonly VendorAndProductsDBContext _db;
    public PurchaseOrderController(PurchaseOrderRepository PurchaseOrderRepo, VendorAndProductsDBContext db, ProductRepository prodRepo, PurchaseOrderLineItemRepository poLineItemRepo, PurchaseOrderDAO po_DAO)
    {
        _PurchaseOrderRepository = PurchaseOrderRepo;
        _purchaseOrderDAO = po_DAO;
        _ProductRepository = prodRepo;
        _PurchaseOrderLineItemRepository = poLineItemRepo;
        _db = db;
    }
    [HttpGet]
    [Route("/api/pos")]
    public async Task<IActionResult> findAll()
    {
        var PurchaseOrders = await _PurchaseOrderRepository.findAll();
        return Ok(PurchaseOrders);
    }
    [HttpPost]
    [Route("/api/pos")]
    public async Task<PurchaseOrders?> addOne([FromBody] PurchaseOrders purchaseOrder)
    {
        var newPO = await _purchaseOrderDAO.create(purchaseOrder, _ProductRepository, _PurchaseOrderLineItemRepository, _db);
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