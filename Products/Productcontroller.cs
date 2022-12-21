using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.Vendors;
using System.Numerics;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller 
{
    private readonly ProductRepository _productRepository;
    private readonly VendorAndProductsDBContext _db;

    public ProductController(ProductRepository productRepository, VendorAndProductsDBContext db)
    {
        this._productRepository = productRepository;
        _db = db;
    }

    [HttpGet]
    [Route("/api/Products/{id}")]
    public async Task<IActionResult> findAllByVendor([FromRoute] int id)
    {
        var Products = await _productRepository.findAllByVendor(id);
        return Ok(Products);
    }
    [HttpPut]
    [Route("/api/Products")]
    public Task<bool> updateOne(Product product)
    {
        var updatedProduct = _productRepository.updateOne(product);
        return updatedProduct;
    }
    [HttpPost]
    [Route("/api/Products")]
    public Task<Product?> addOne(Product product)
    {
        var updatedProduct = _productRepository.addOne(product);
        return updatedProduct;
    }
    [HttpDelete]
    [Route("/api/Products/{id}")]
    public async Task<IActionResult> deleteOne([FromRoute] string id)
    {
        var updatedProduct = await _productRepository.deleteOne(id);
        return Ok(updatedProduct);
    }
}