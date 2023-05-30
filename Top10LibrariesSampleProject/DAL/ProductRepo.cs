using Dapper;
using Microsoft.Win32;
using System.Data;
using Top10LibrariesSampleProject.DAL.Context;
using Top10LibrariesSampleProject.DAL.Interfaces;
using Top10LibrariesSampleProject.Model;

namespace Top10LibrariesSampleProject.DAL
{
    public class ProductRepo : IProduct
    {
        private DapperContext _context;
        public ProductRepo(DapperContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<GetProduct>> GetAllProducts()
        {
            IEnumerable<GetProduct> getProduct = null;
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var procedure = "GetAllProducts";

                    getProduct = await connection.QueryAsync<GetProduct>(procedure, null, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
               
            }
            return getProduct;
        }

        public async Task<int> AddUpdateProduct(AddUpdateProduct addUpdate)
        {
            int result = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var procedure = "GetAllProducts";
                    var values = new
                    {
                        ProductId=addUpdate.ProductId,
                        ProductName=addUpdate.ProductName,
                        ProductDescription=addUpdate.ProductDescription,
                        ProductCategory = addUpdate.ProductCategory,
                    };

                    result = await connection.QueryFirstOrDefaultAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}
