using System.Collections.Concurrent;

namespace pay2.Pages
{
    static class PaymentStorage
    {
        private static volatile int _id = 0;

        public static ConcurrentDictionary<int, QueryData> Payments { get; } = new ConcurrentDictionary<int, QueryData>();

        public static int GetNextId() => _id++;
    }
}
