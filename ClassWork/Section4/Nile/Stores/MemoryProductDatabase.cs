﻿/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Provides an implementation of <see cref="IProductDatabase"/> using a memory collection.</summary>
    public class MemoryProductDatabase : ProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            if (newProduct.Id <= 0)
                newProduct.Id = _nextId++;
            else if (newProduct.Id >= _nextId)
                _nextId = newProduct.Id + 1;

            return CopyProduct(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        protected override Product GetCore ( int id )
        {            
            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : throw new Exception("Product not in memory.");
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            return from item in _products
                   select CopyProduct(item);

            //foreach (var product in _products)
              //  yield return CopyProduct(product);            
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product product )
        {
            //Find and remove existing product
            existing = FindProduct(product.Id);
            _products.Remove(existing);
            
            //Add a copy of the new product
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            return CopyProduct(newProduct);
        }

        //Copies one product to another
        private Product CopyProduct( Product product )
        {
            if (product == null)
                return null;

            var newProduct = new Product() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsDiscontinued = product.IsDiscontinued
            };

            return newProduct;
        }

        //Find a product by ID
        private Product FindProduct ( int id )
        {
            //LINQ syntax
            return (from product in _products
                    where product.Id == id
                    select product).FirstOrDefault();

            //Using the extension methods
            //return _products.Where( p => p.Id == id )
            //                .Select( p => p )
            //                .FirstOrDefault();
            
            //foreach (var product in _products)
            //{
            //    if (product.Id == id)
            //        return product;
            //};

            //return null;
        }

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}
