
namespace InventoryManagement.Constants
{
    public class SqlQueries
    {
        /// <summary>
        /// [admin].GetProductDetails(@productId INT = 0, @categoryId INT = 0, @storeId INT= 0)
        /// </summary>
        public const string GetProductDetails = "[admin].GetProductDetails {0},{1},{2}";
        /// <summary>
        /// [admin].GetRelatedProducts(@pid INT)
        /// </summary>
        public const string GetRelatedProducts = "[admin].GetRelatedProducts {0}";
        /// <summary>
        ///  Admin.GetCategories(@categoryId INT=0, @pin varchar(6)='')
        /// </summary>
        public const string GetCategories = "Admin.GetCategories {0},{1}";
    }
}
