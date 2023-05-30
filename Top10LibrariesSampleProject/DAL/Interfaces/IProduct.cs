using Top10LibrariesSampleProject.Model;

namespace Top10LibrariesSampleProject.DAL.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProduct
    {
        Task<IEnumerable<GetProduct>> GetAllProducts();
        Task<int> AddUpdateProduct(AddUpdateProduct addUpdate);
    }
}
