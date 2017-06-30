using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FastShop.Models
{
    public class Product
    {   
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public double Precio { get; set; }
        public bool ProductoNacional { get; set; }
        public bool Descontinuado { get; set; }

        //public Product(int id,  string nombre,
        //      string descripcion,   int categoria,
        //      double precio,   bool productoNacional,
        //      bool descontinuado)
        //{

        //    this.Id = id;
        //    this.Nombre = nombre;
        //    this.Descripcion = descripcion;
        //    this.Categoria = categoria;
        //    this.Precio = precio;
        //    this.ProductoNacional = productoNacional;
        //    this.Descontinuado = descontinuado;
        //}

        //public class ProductDBContext : DbContext
        //{
        //    public DbSet<Product> Product { get; set; }
        //}

    }
}