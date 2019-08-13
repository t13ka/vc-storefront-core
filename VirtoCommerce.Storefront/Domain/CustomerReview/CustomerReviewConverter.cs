namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    using VirtoCommerce.Storefront.Model.CustomerReviews;

    using Api = VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi.Models;

    public static class CustomerReviewConverter
    {
        public static CustomerReview ToCustomerReview(this Api.CustomerReview itemDto)
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
                ProductId = itemDto.ProductId,
                Rating = itemDto.Rating
            };

            return result;
        }

        public static Api.CustomerReview ToApiModel(this CustomerReview itemDto)
        {
            var result = new Api.CustomerReview
            {
                Id = itemDto.Id,
                AuthorNickname = itemDto.AuthorNickname,
                Content = itemDto.Content,
                CreatedBy = itemDto.CreatedBy,
                CreatedDate = itemDto.CreatedDate,
                IsActive = itemDto.IsActive,
                ModifiedBy = itemDto.ModifiedBy,
                ModifiedDate = itemDto.ModifiedDate,
                ProductId = itemDto.ProductId,
                Rating = itemDto.Rating
            };

            return result;
        }

        public static Api.CustomerReviewSearchCriteria ToApiSearchCriteria(this CustomerReviewSearchCriteria criteria)
        {
            var result = new Api.CustomerReviewSearchCriteria
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
