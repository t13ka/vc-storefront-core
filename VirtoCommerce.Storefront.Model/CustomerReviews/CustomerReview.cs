namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    using System;

    using VirtoCommerce.Storefront.Model.Common;

    public class CustomerReview : Entity
    {
        public string AuthorNickname { get; set; }

        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsActive { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ProductId { get; set; }

        public double? Rating { get; set; }
    }
}
