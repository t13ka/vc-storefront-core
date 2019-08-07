namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    using System.Collections.Specialized;

    using VirtoCommerce.Storefront.Model.Common;

    public class CustomerReviewSearchCriteria : PagedSearchCriteria
    {
        public CustomerReviewSearchCriteria()
            : base(new NameValueCollection(), DefaultPageSize)
        {
        }

        public CustomerReviewSearchCriteria(NameValueCollection queryString)
            : base(queryString, DefaultPageSize)
        {
        }

        public static int DefaultPageSize
        {
            get;
            set;
        } = 20;

        public bool? IsActive { get; set; }

        public string[] ProductIds { get; set; }

        public string Sort { get; set; }
    }
}
