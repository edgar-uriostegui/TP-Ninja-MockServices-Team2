﻿using ProductCatalogService.Domain.Models;


namespace ProductCatalogService.Repository.Repository.Persistance
{
    /// <summary>
    /// Interface for ProductRepository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Method that retrieves all products by db
        /// </summary>
        /// <returns></returns>
        List<ProductEntity> GetAllProducts();
    }
}