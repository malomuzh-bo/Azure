using System.Text.Json;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace hw0903.Models
{
    public class Lot
    {
        public string Currency { get; set; }
        public decimal Sum { get; set; }
        public string UserName { get; set; }
    }
}
