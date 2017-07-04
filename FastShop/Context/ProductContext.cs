using FastShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FastShop.Context
{
    public class ProductContext
    {

        public static ProductContext instance;
        private ProductContext() {

            List = new List<Product>();
            User obj = new User();
            obj.user = "admin";
            obj.pass = "admin";
            ListUser = new List<User>();
            ListUser.Add(obj);


            // Default values
            Product product = new Product();
            product.Nombre = "Café Exp";
            product.Descripcion = "café experimentos";
            product.Categoria = 1;
            product.Precio = 12;
            product.ProductoNacional = true;
            product.Descontinuado = true;
            Add(product);

            product = new Product();
            product.Nombre = "Café Pru";
            product.Descripcion = "café pruebas";
            product.Categoria = 1;
            product.Precio = 10;
            product.ProductoNacional = true;
            product.Descontinuado = false;
            Add(product);

            product = new Product();
            product.Nombre = "Café Yab";
            product.Descripcion = "café yaba";
            product.Categoria = 1;
            product.Precio = 1;
            product.ProductoNacional = false;
            product.Descontinuado = true;
            Add(product);

            product = new Product();
            product.Nombre = "Café CS";
            product.Descripcion = "café cishar";
            product.Categoria = 1;
            product.Precio = 0.5;
            product.ProductoNacional = false;
            product.Descontinuado = true;
            Add(product);
        }

        public static ProductContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductContext();
                }
                return instance;
            }
        }


        public void Add(Product product) {
            product.Id = 1;
            if (List.Any())
                product.Id = List[List.Count - 1].Id + 1;
            List.Add(product);
        }

        public Product find(int? id) {

            return List.Find(x => x.Id ==id);
        }

        public void modify(Product producto) {


            var itemIndex = List.FindIndex(x => x.Id == producto.Id);
            var item = List.ElementAt(itemIndex);
            List.RemoveAt(itemIndex);
            item.Id = producto.Id;
            item.Categoria = producto.Categoria;
            item.Descontinuado = producto.Descontinuado;
            item.Descripcion = producto.Descripcion;
            item.Nombre = producto.Nombre;
            item.Precio = producto.Precio;
            item.ProductoNacional = producto.ProductoNacional;
            List.Insert(itemIndex, item);

        }

        public bool verifyUser(User user) {

            User userObj =  ListUser.Find(x => x.user == user.user && x.pass == user.pass);
            if (userObj == null)
                return false;
            else
                return true;

        }

        public void delete(Product product)
        {
            var itemIndex = List.FindIndex(x => x.Id == product.Id);           
            List.RemoveAt(itemIndex);
        }
        public List<Product> List { get; set; }
        public List<User> ListUser { get; set; }




    }
}