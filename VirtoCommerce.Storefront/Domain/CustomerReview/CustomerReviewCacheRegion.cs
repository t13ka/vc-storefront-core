namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;

    using Microsoft.Extensions.Primitives;

    using VirtoCommerce.Storefront.Model.Common.Caching;

    public class CustomerReviewCacheRegion : CancellableCacheRegion<CustomerReviewCacheRegion>
    {
        private static readonly ConcurrentDictionary<string, CancellationTokenSource> _customerReviewRegionTokenLookup = new ConcurrentDictionary<string, CancellationTokenSource>();

        public static IChangeToken CreateCustomerReviewChangeToken(string customerId)
        {
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            var tokenSource = new CancellationTokenSource();
            var cancellationTokenSource = _customerReviewRegionTokenLookup.GetOrAdd(customerId, tokenSource);

            var changeToken = CreateChangeToken();
            var cancellationChangeToken = new CancellationChangeToken(cancellationTokenSource.Token);
            var changeTokens = new[]
                               {
                                   changeToken, cancellationChangeToken
                               };

            return new CompositeChangeToken(changeTokens);
        }

        public static void ExpireCustomerCustomerReview(string customerId)
        {
            if (!string.IsNullOrEmpty(customerId)
                && _customerReviewRegionTokenLookup.TryRemove(customerId, out var token))
            {
                token.Cancel();
            }
        }
    }
}
