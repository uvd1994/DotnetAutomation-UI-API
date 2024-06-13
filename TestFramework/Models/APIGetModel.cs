using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestFramework.Models
{
    public class ResponseModel
    {
        public bool IsAdult { get; set; }
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

    }
}
