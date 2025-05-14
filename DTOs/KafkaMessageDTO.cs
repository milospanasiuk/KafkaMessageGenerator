using System;
using System.Text.Json.Serialization;

namespace OrderKafkaMessageGenerator.DTOs
{
    public class KafkaMessageDTO
    {
        [JsonPropertyName("8")]
        public string Header8 { get; set; }

        [JsonPropertyName("49")]
        public string Header49 { get; set; }

        [JsonPropertyName("56")]
        public string Header56 { get; set; }

        public string ExecID { get; set; }
        public string ExecTransType { get; set; }
        public string ExecType { get; set; }
        public string MsgType { get; set; }

        public string ExDestination { get; set; }
        public string ClientID { get; set; }

        public DateTimeOffset SendingTime { get; set; }
        public DateTimeOffset TransactionTime { get; set; }

        public string Account { get; set; }
        public string ClientOrderID { get; set; }
        public string OriginalClientOrderID { get; set; }

        public string LeavesQty { get; set; }
        public long SequenceNumber { get; set; }
        public string OrderID { get; set; }
        public string OrderQuantity { get; set; }
        public string OrdStatus { get; set; }
        public string OrderType { get; set; }
        public string SecurityType { get; set; }
        public decimal? Price { get; set; }
        public int Side { get; set; }
        public string Symbol { get; set; }
        public int TimeInForce { get; set; }

        public string AveragePrice { get; set; }
        public string StrikePrice { get; set; }
        public string CumQty { get; set; }

        public decimal? LastFill { get; set; }
        public decimal? LastPrice { get; set; }

        // options related
        public string MaturityMonthYear { get; set; }
        public string MaturityDay { get; set; }
        public string PutOrCall { get; set; }
        public string OpenClose { get; set; }
        public KafkaMessageNumberOfLegs NoLegs { get; set; }

        public string ErrorMessage { get; set; }

        public KafkaMessageDTO()
        {
            Header8 = "FIX.4.2";
            Header49 = "STT";
            Header56 = "WEDBUSH";

            ExecTransType = "0";

            var today = DateTimeOffset.Now;

            SendingTime = today;
            TransactionTime = today;

            ExDestination = "SMART";
            ClientID = "DSEC";

            MsgType = "8";
        }
    }

    public class KafkaMessageNumberOfLegs
    {
        public string LegRefID { get; set; }
    }
}
