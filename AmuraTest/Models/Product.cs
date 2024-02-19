using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmuraTest.Models
{
    public class Product
	{
        public int id { get; set; }

		public string title { get; set; }

		public string description { get; set; }

		public int price { get; set; }

		public string discountPercentage { get; set; }

		public decimal rating { get; set; }

		public int stock { get; set; }

		public string brand { get; set; }

		public string category { get; set; }

		public string thumbnail { get; set; }

		public string[] images { get; set; }

	}
}
