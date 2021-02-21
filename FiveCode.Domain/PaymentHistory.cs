namespace FiveCode.Domain
{
    public class PaymentHistory
    {
        public int ID { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }

        public PaymentStatus PaymentStatus;
    }

    public enum PaymentStatus
    {
        Processed,
        Pending,
        Failed
    }
}