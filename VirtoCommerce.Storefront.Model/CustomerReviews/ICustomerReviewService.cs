namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    using System.Threading.Tasks;

    using PagedList.Core;

    public interface ICustomerReviewService
    {
        IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria);

        Task<IPagedList<CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria);
    }
}
