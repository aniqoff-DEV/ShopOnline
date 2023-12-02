using ShopOnline.API.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, 
                                                            IEnumerable<ProductCategory> productCategories) 
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name
                    }).ToList();
        }
    }
}
