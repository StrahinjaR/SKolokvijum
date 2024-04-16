using DataLayer;
using DataLayer.Model;

namespace BusinessLayer
{
    public class BusinessProduct : IBusinessProduct
    {
        private readonly IProductRepository _productRepository;
        public BusinessProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetAll()
        {
            var products = _productRepository.GetAll();
            if(products.Count>0 )
            {
                return products;
            }
            return new List<Product>();
        }

        public List<Product> GetInterval(decimal price1, decimal price2)
        {
            return _productRepository.GetAll().FindAll(item=>item.Price>=price1 && item.Price<=price2);
        }

        public bool Insert(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Description) || product.Price == 0)
            {
                return false;
            }
            return _productRepository.Insert(product);
        }

    }
}
