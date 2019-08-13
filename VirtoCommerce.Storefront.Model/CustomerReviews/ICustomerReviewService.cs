namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    using System.Threading.Tasks;

    using PagedList.Core;

    public interface ICustomerReviewService
    {
        Task<CustomerReview> AddCustomerReview(CustomerReview customerReview);

        Task<string> GetProductRating(string productId);

        IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria);

        Task<IPagedList<CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria);
    }
}
