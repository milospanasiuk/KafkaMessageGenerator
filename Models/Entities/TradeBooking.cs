using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
using OrderKafkaMessageGenerator.Models.Enums;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class TradeBooking : Entity<long>
    {
        public string ClientOrderId { get; set; }
        public string MessageType { get; set; }
        public string Account { get; set; }
        public string BackOfficeAccount { get; set; }
        public string AccountNumber { get; set; }
        public string ExecutionId { get; set; }
        public string ExecutionType { get; set; }
        public decimal OrderQuantity { get; set; }
        public short AccountType { get; set; }
        public string Symbol { get; set; }
        public string SecurityId { get; set; }
        public decimal? ExecutedPrice { get; set; }
        public string Market { get; set; }
        public short? CommissionType { get; set; }
        public decimal? CommissionAmount { get; set; }
        public string OrderCapacity { get; set; }
        public string TransactionTime { get; set; }
        public string TradeDate { get; set; }
        public string SettleDate { get; set; }
        public string ClearingAccount { get; set; }
        public string DestinationCode { get; set; }
        public string ContraBroker { get; set; }
        public string Legend { get; set; }
        public string ExchangeCode { get; set; }
        public string MajorEnteringBroker { get; set; }
        public string OtherSideContraBroker { get; set; }
        public string LegRefId { get; set; }

        public decimal? TradeInterestAmount { get; set; }
        public string RepCode { get; set; }
        public string SideCode { get; set; }
        public string Source { get; set; }

        public bool? Review { get; set; }
        public string Remarks { get; set; }
        public DateTimeOffset TradeBookingDate { get; set; }
        public BookingStatus TradeBookingStatus { get; set; }
        public TradeBookingType TradeBookingType { get; set; }
        public string RejectReason { get; set; }
        public string P3TradeConfirmationNumber { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdateOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public long? RevisionNumber { get; set; }

        public long? OrderId { get; set; }
        public virtual Order Order { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<TradeBookingFee> TradeBookingFees { get; set; }
    }
}