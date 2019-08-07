namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    using VirtoCommerce.Storefront.Model.CustomerReviews;

    using reviewDto = VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi.Models;

    public static class CustomerReviewConverter
    {
        public static CustomerReview ToCustomerReview(this reviewDto.CustomerReview itemDto)
        {
            var result = new CustomerReview
            {
                Id = itemDto.Id,
                AuthorNickname = itemDto.AuthorNickname,
                Content = itemDto.Content,
                CreatedBy = itemDto.CreatedBy,
                CreatedDate = itemDto.CreatedDate,
                IsActive = itemDto.IsActive,
                ModifiedBy = itemDto.ModifiedBy,
                ModifiedDate = itemDto.ModifiedDate,
                ProductId = itemDto.ProductId
            };

            return result;
        }

        public static reviewDto.CustomerReviewSearchCriteria ToSearchCriteriaDto(
            this CustomerReviewSearchCriteria criteria)
        {
            var result = new reviewDto.CustomerReviewSearchCriteria
            {
                IsActive = criteria.IsActive,
                ProductIds = criteria.ProductIds,
                Skip = criteria.Start,
                Take = criteria.PageSize,
                Sort = criteria.Sort
            };

            return result;
        }
    }
}
