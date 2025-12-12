using Xunit;
using LinqAdvancedLab.Domain.Entities;
using System.Linq;
using System;

namespace LinqAdvancedLab.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Can_Add_And_Get_Product_From_InMemory_Db()
        {
            // 1. Arrange (Preparar)
            var dbName = Guid.NewGuid().ToString(); // Nombre único para este test
            using var context = TestHelper.GetInMemoryContext(dbName);

            var product = new Product { ProductName = "Queso Lojano", Discontinued = false };
            context.Products.Add(product);
            context.SaveChanges();

            // 2. Act (Ejecutar)
            var savedProduct = context.Products.FirstOrDefault(p => p.ProductName == "Queso Lojano");

            // 3. Assert (Verificar)
            Assert.NotNull(savedProduct);
            Assert.Equal("Queso Lojano", savedProduct.ProductName);
        }
    }
}