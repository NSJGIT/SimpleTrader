using SimpleTrader.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingAPI.Services
{
    public class MockStockPriceProvider : IStockPriceService
    {
        private static readonly Dictionary<string, double> _mockPrices = new()
    {
        { "AAPL", 172.43 },
        { "MSFT", 312.56 },
        { "TSLA", 688.90 },
        { "GOOG", 1310.25 }
    };

        public Task<double> GetPriceAsync(string symbol)
        {
            if (_mockPrices.TryGetValue(symbol.ToUpper(), out double price))
                return Task.FromResult(price);

            // Return a random fake price for unknown symbols
            var random = new Random();
            return Task.FromResult(100 + random.NextDouble() * 50);
        }
    }
}

