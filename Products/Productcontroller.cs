using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.Queries;
using PurchaseOrderBackEnd.Vendors;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
    [Route("/api/Products")]
    public async Task<IActionResult> findAll([FromQuery] ProductQueryParameters queryParams)
    {
        IQueryable<Products> dbSet = _productRepository.findAllFromQuery();

        if (queryParams.MinPrice != null)
        {
            dbSet = dbSet.Where(
                p => p.costprice >= queryParams.MinPrice.Value);
        }

        if (queryParams.MaxPrice != null)
        {
            dbSet = dbSet.Where(
                p => p.costprice <= queryParams.MaxPrice.Value);
        }

        if (!string.IsNullOrEmpty(queryParams.Products_id))
        {
            dbSet = dbSet.Where(
                p => p.products_Id == queryParams.Products_id);
        }

        if (!string.IsNullOrEmpty(queryParams.Name))
        {
            dbSet = dbSet.Where(
                p => p.name.ToLower().Contains(
                    queryParams.Name.ToLower()));
        }

        dbSet = dbSet.Skip(queryParams.Size * (queryParams.Page - 1)).Take(queryParams.Size);
        return Ok(await dbSet.ToArrayAsync());
    }
    [HttpGet]
    [Route("/api/Products/{id}")]
    public async Task<IActionResult> findAllByVendor([FromRoute] int id)
    {
        var Products = await _productRepository.findAllByVendor(id);
        return Ok(Products);
    }
    [HttpPut]
    [Route("/api/Products/{id}")]
    public async Task<IActionResult> updateOne([FromRoute]string id, Products product)
    {
        var updatedProduct = await _productRepository.updateOne(id, product);
        return Ok(updatedProduct);
    }
    [HttpPost]
    [Route("/api/Products")]
    public Task<Products?> addOne(Products product)
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