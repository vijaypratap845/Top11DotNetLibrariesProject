namespace Top10LibrariesSampleProject.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class GetProduct
    {
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; } 
        public string ProductCategory { get; set; } = string.Empty;      
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddUpdateProduct
    {
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public string ProductCategory { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime Updateddate { get; set; }   
        public bool IsActive { get; set; }
    }
    public class AddUpdateProductDTO
    {
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public string ProductCategory { get; set; } = string.Empty;
    }
}
