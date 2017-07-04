using Microsoft.VisualStudio.TestTools.UnitTesting;
using FastShop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastShop.Models;

namespace FastShop.Context.Tests
{
    [TestClass()]
    public class ProductContextTests
    {
        [TestMethod()]
        [Timeout(500)]
        public void AddTest()
        {
            int sizeBeforeAdd = ProductContext.Instance.List.Count;
            int expected = sizeBeforeAdd + 1;

            Product product = new Product();
            product.Nombre = "Café Test";
            product.Descripcion = "café testing";
            product.Categoria = 1;
            product.Precio = 100;
            product.ProductoNacional = true;
            product.Descontinuado = false;

            ProductContext.Instance.Add(product);

            int sizeAfterAdd = ProductContext.Instance.List.Count;

            Assert.AreEqual(expected, sizeAfterAdd);
        }

        [TestMethod()]
        [Timeout(500)]
        public void findTest()
        {
            int lastProductIndex = ProductContext.Instance.List.Count - 1;
            Product lastProduct = ProductContext.Instance.List[lastProductIndex];
            int expected = lastProduct.Id;

            Product findedProduct = ProductContext.Instance.find(lastProduct.Id);
            
            Assert.AreEqual(expected, findedProduct.Id);
        }

        [TestMethod()]
        [Timeout(500)]
        public void modifyTest()
        {
            // Last product
            Product product = ProductContext.Instance.find(ProductContext.Instance.List.Count - 1);

            product.Nombre = "Café Mod";
            product.Descripcion = "café modified";
            product.Categoria = 1;
            product.Precio = 100.5;
            product.ProductoNacional = true;
            product.Descontinuado = false;

            ProductContext.Instance.modify(product);
               
            Product productModified = ProductContext.Instance.find(product.Id);

            Assert.AreEqual(product.Id, productModified.Id);
            Assert.AreEqual(product.Nombre, productModified.Nombre);
            Assert.AreEqual(product.Categoria, productModified.Categoria);
            Assert.AreEqual(product.Precio, productModified.Precio);
            Assert.AreEqual(product.ProductoNacional, productModified.ProductoNacional);
            Assert.AreEqual(product.Descontinuado, productModified.Descontinuado);
        }

        [TestMethod()]
        [Timeout(500)]
        public void verifyUserTest()
        {
            bool expected = false;
            User user = new User();
            user.user = "admin";
            user.pass = "acmon";

            bool isValidUser = ProductContext.Instance.verifyUser(user);

            Assert.AreEqual(expected, isValidUser);
        }

        [TestMethod()]
        [Timeout(500)]
        public void deleteTest()
        {
            Product expected = null;
            // Last product (product to delete)
            Product product = ProductContext.Instance.find(ProductContext.Instance.List.Count - 1);
            int productId = product.Id;

            ProductContext.Instance.delete(product);

            Assert.AreEqual(expected, ProductContext.Instance.find(productId));
        }
    }
}