using Microsoft.AspNetCore.Identity;

namespace DoAnLapTrinhWeb.Model
{
	public class Order
	{
		public string OrderId { set; get; }
		public string UserId { set; get; }

		public virtual IdentityUser User { set; get; }
		public string ServiceId { set; get; }

		public virtual Service Service { set; get; }
		public DateTime OrderDate { set; get; }
		public DateTime OrderDue { set; get; }
		public string PriceId { set; get; }

		public virtual Price Price { set; get; }
		public decimal DiscountPercent { set; get; }
		public decimal Discount { set; get; }
		public DeliveryStatus DeliverStatus { set; get; }
	}

	public enum DeliveryStatus
	{
		PENDING,
		ACCEPTED,
		REJECTED,
		INCOMMING,
		DILIVERED
	}
}
