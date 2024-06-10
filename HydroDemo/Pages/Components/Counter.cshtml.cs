using Hydro;
using HydroDemo.EventModels;
using Microsoft.Extensions.Caching.Memory;

namespace HydroDemo.Pages.Components
{
    public class Counter : HydroComponent
    {
        public string CacheKey { get; set; } = "Counter";
        public int Count { get; set; }

        private readonly IMemoryCache cache;

        public Counter(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public override void Mount()
        {
            Count = cache.Get<int>($"count-{CacheKey}");
            base.Mount();
        }

        public void Add()
        {
            Count++;
            cache.Set($"count-{CacheKey}", Count);
            DispatchGlobal(new CountChangedEvent(CacheKey, Count));
        }
    }
}
