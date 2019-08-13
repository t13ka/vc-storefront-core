namespace VirtoCommerce.Storefront.Controllers.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using VirtoCommerce.Storefront.Infrastructure;
    using VirtoCommerce.Storefront.Model;
    using VirtoCommerce.Storefront.Model.Common;
    using VirtoCommerce.Storefront.Model.CustomerReviews;

    [StorefrontApiRoute("customerReview")]
    public class ApiCustomerReviewsController : StorefrontControllerBase
    {
        private readonly ICustomerReviewService _customerReviewService;

        public ApiCustomerReviewsController(
            IWorkContextAccessor workContextAccessor,
            IStorefrontUrlBuilder urlBuilder,
            ICustomerReviewService customerReviewService)
            : base(workContextAccessor, urlBuilder)
        {
            _customerReviewService = customerReviewService;
        }

        [HttpPost("search")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<IEnumerable<CustomerReview>>> GetCustomerReviews(
            [FromBody] CustomerReviewSearchCriteria searchCriteria)
        {
            var reviews = await _customerReviewService.SearchReviewsAsync(searchCriteria);
            return reviews.ToList();
        }

        [HttpGet("rating")]
        public async Task<ActionResult<string>> GetProductRating(string productId)
        {
            return await _customerReviewService.GetProductRating(productId);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReview>> AddCustomerReview([FromBody] CustomerReview customerReviewDto)
        {
            var review = await _customerReviewService.AddCustomerReview(customerReviewDto);
            return review;
        }
    }
}
