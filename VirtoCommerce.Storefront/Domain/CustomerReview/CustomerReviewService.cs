namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Caching.Memory;

    using PagedList.Core;

    using VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi;
    using VirtoCommerce.Storefront.Infrastructure;
    using VirtoCommerce.Storefront.Model.Caching;
    using VirtoCommerce.Storefront.Model.Common.Caching;
    using VirtoCommerce.Storefront.Model.CustomerReviews;

    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly IApiChangesWatcher _apiChangesWatcher;

        private readonly ICustomerReviews _customerReviewsApi;

        private readonly IStorefrontMemoryCache _memoryCache;

        public CustomerReviewService(
            ICustomerReviews customerReviewsApi,
            IStorefrontMemoryCache memoryCache,
            IApiChangesWatcher apiChangesWatcher)
        {
            _customerReviewsApi = customerReviewsApi;
            _memoryCache = memoryCache;
            _apiChangesWatcher = apiChangesWatcher;
        }

        public IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria)
        {
            return SearchReviewsAsync(criteria).GetAwaiter().GetResult();
        }

        public async Task<IPagedList<CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria)
        {
            var cacheKey = CacheKey.With(GetType(), nameof(SearchReviewsAsync), criteria.GetCacheKey());
            return await _memoryCache.GetOrCreateExclusiveAsync(
                cacheKey,
                async cacheEntry =>
                {
                    var reviewsChangeToken = CustomerReviewCacheRegion.CreateChangeToken();
                    cacheEntry.AddExpirationToken(reviewsChangeToken);

                    var apiChangeToken = _apiChangesWatcher.CreateChangeToken();
                    cacheEntry.AddExpirationToken(apiChangeToken);

                    var searchCriteriaDto = criteria.ToSearchCriteriaDto();
                    var foundCustomerReviews = await _customerReviewsApi.SearchCustomerReviewsAsync(searchCriteriaDto);
                    var totalCount = foundCustomerReviews.TotalCount ?? 0;

                    var customerReviews =
                        foundCustomerReviews.Results.Select(customerReview => customerReview.ToCustomerReview());
                    return new StaticPagedList<CustomerReview>(
                        customerReviews,
                        criteria.PageNumber,
                        criteria.PageSize,
                        totalCount);
                });
        }
    }
}
