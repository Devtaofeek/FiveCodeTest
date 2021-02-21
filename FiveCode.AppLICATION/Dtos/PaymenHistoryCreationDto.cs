using FiveCode.Domain;

namespace FiveCode.Application.Dtos
{
    public class PaymenHistoryCreationDto
    {
        public int PaymentID { get; set; }

        public PaymentStatus PaymentStatus;
    }
}