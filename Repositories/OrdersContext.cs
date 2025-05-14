using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderKafkaMessageGenerator.Models.Entities;
using OrderKafkaMessageGenerator.Models.Enums;

namespace OrderKafkaMessageGenerator.Repositories
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Side> Sides { get; set; }
        public virtual DbSet<HandlingInstruction> HandlingInstructions { get; set; }
        public virtual DbSet<IdSource> IdSources { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<OrderCapacity> OrderCapacities { get; set; }
        public virtual DbSet<CommissionType> CommissionTypes { get; set; }
        public virtual DbSet<TimeInForce> TimeInForces { get; set; }
        public virtual DbSet<SettlementType> SettlementTypes { get; set; }
        public virtual DbSet<SellerCode> SellerCodes { get; set; }
        public virtual DbSet<SpecialInstruction> SpecialInstructions { get; set; }
        public virtual DbSet<SecurityType> SecurityTypes { get; set; }
        public virtual DbSet<OrderCommission> OrderCommissions { get; set; }
        public virtual DbSet<ExecutionDestination> ExecutionDestinations { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLot> OrderLots { get; set; }
        public virtual DbSet<OrderOption> OrderOptions { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }

        public virtual DbSet<TradeBooking> TradeBookings { get; set; }
        public virtual DbSet<TradeBookingAudit> TradeBookingAudits { get; set; }
        public virtual DbSet<TradeBookingFee> TradeBookingFees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("AccountType_Id");

                entity.ToTable("AccountType", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<Side>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Side_Id");

                entity.ToTable("Side", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<HandlingInstruction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_HandlingInstruction_Id");

                entity.ToTable("HandlingInstruction", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<IdSource>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdSource_Id");

                entity.ToTable("IdSource", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrderType_Id");

                entity.ToTable("OrderType", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<OrderCapacity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrderCapacity_Id");

                entity.ToTable("OrderCapacity", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<CommissionType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("CommissionType_Id");

                entity.ToTable("CommissionType", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<TimeInForce>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_TimeInForce_Id");

                entity.ToTable("TimeInForce", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<SecurityType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_SecurityType_Id");

                entity.ToTable("SecurityType", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<SellerCode>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SellerCode_Id");

                entity.ToTable("SellerCode", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.LocateBroker).HasMaxLength(10);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<SettlementType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SettlementType_Id");

                entity.ToTable("SettlementType", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<SpecialInstruction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SpecialInstruction_Id");

                entity.ToTable("SpecialInstruction", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<OrderCommission>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrderCommission_Id");

                entity.ToTable("OrderCommission", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.CommissionScheduleName).HasMaxLength(50);
                entity.Property(e => e.CommissionTypeValue).HasPrecision(18, 4);
                entity.Property(e => e.EstimatedCommission).HasPrecision(18, 4);
                entity.Property(e => e.ActualCommission).HasPrecision(18, 4);
                entity.Property(e => e.EntityId).HasMaxLength(20);
                entity.Property(e => e.OfficeId).HasMaxLength(20);
                entity.Property(e => e.AccountValue).HasPrecision(18, 4);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<ExecutionDestination>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ExecutionDestination_Id");

                entity.ToTable("ExecutionDestination", "db");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Order_Id");

                entity.ToTable("Order", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Active).HasMaxLength(10);
                entity.Property(e => e.AveragePrice).HasPrecision(18, 9);
                entity.Property(e => e.Channel).HasMaxLength(20);
                entity.Property(e => e.ClientId).HasMaxLength(20);
                entity.Property(e => e.ClientOrderId)
                    .IsRequired()
                    .HasMaxLength(48)
                    .HasComputedColumnSql("\nCASE\n    WHEN (\"SterlingOrderId\" IS NULL) THEN ((((((((((date_part('year'::text, timezone('UTC'::text, \"CreatedOn\")))::text || '-'::text) || (date_part('month'::text, timezone('UTC'::text, \"CreatedOn\")))::text) || '-'::text) || (date_part('day'::text, timezone('UTC'::text, \"CreatedOn\")))::text) || '-'::text) || (COALESCE(\"RepCode\", ''::character varying))::text) || '-'::text) || COALESCE((\"OrderSequenceNumber\")::text, ''::text)))::character varying\n    ELSE \"SterlingOrderId\"\nEND", true);
                entity.Property(e => e.CountryOfDomicile).HasMaxLength(10);
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("now()");
                entity.Property(e => e.Currency).HasMaxLength(3);
                entity.Property(e => e.Cusip).HasMaxLength(30);
                entity.Property(e => e.ExchangeOfLastFill).HasMaxLength(10);
                entity.Property(e => e.ExecutedPriceOfLastFill).HasPrecision(18, 9);
                entity.Property(e => e.ExecutedQuantity).HasPrecision(18, 5);
                entity.Property(e => e.ExecutionDestination).HasMaxLength(50);
                entity.Property(e => e.LeavesQuantity).HasPrecision(18, 5);
                entity.Property(e => e.LimitPrice).HasPrecision(18, 9);
                entity.Property(e => e.LocateBroker).HasMaxLength(10);
                entity.Property(e => e.MessageType)
                    .IsRequired()
                    .HasMaxLength(2);
                entity.Property(e => e.MiscText).HasMaxLength(100);
                entity.Property(e => e.OrderLotMethodology).HasMaxLength(10);
                entity.Property(e => e.OrderQuantity).HasPrecision(18, 5);
                entity.Property(e => e.OrderSequenceNumber)
                    .ValueGeneratedOnAdd()
                    .HasIdentityOptions(null, null, 111111L, 999999L, true, null);
                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.OriginalClientOrderId).HasMaxLength(48);
                entity.Property(e => e.Price).HasPrecision(18, 9);
                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(e => e.RepCode)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(e => e.SecurityId).HasMaxLength(50);
                entity.Property(e => e.Source).HasMaxLength(1);
                entity.Property(e => e.SterlingOrderId).HasMaxLength(30);
                entity.Property(e => e.StopPrice).HasPrecision(18, 9);
                entity.Property(e => e.Symbol).HasMaxLength(30);
                entity.Property(e => e.PreferredSymbolPrefix).HasMaxLength(30);
                entity.Property(e => e.PreferredSymbolSuffix).HasMaxLength(30);
                entity.Property(e => e.SymbolDescription).HasMaxLength(100);
                entity.Property(e => e.Trader).HasMaxLength(20);
                entity.Property(e => e.TTORep)
                    .HasMaxLength(10);
                entity.Property(e => e.UpdateBy).HasMaxLength(60);

                var orderSubmissionStatusConverter = new EnumToStringConverter<OrderSubmissionStatus>();

                entity
                    .Property(p => p.OrderStatus)
                    .HasConversion(orderSubmissionStatusConverter);

                var productConverter = new EnumToStringConverter<Product>();

                entity
                    .Property(p => p.Product)
                    .HasConversion(productConverter);

                var channelConverter = new EnumToStringConverter<OrderChannel>();

                entity
                    .Property(e => e.Channel)
                    .HasConversion(channelConverter);

                var activeConverter = new EnumToStringConverter<OrderActive>();

                entity
                    .Property(p => p.Active)
                    .HasConversion(activeConverter);

                //entity.Ignore("MutualFundOrderId");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<OrderLot>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrderLot_Id");

                entity.ToTable("OrderLot", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("now()");
                entity.Property(e => e.LotId)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.LotPrice).HasPrecision(18, 9);
                entity.Property(e => e.LotQuantity).HasPrecision(18, 5);
                entity.Property(e => e.UpdateBy).HasMaxLength(60);
                entity.Property(e => e.VssPurchaseQuantity).HasPrecision(18, 5);

                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<OrderOption>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("OrderOption_Id");

                entity.ToTable("OrderOption", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.ExchangeOfLastFill).HasMaxLength(10);
                entity.Property(e => e.ExecutedPriceOfLastFill).HasPrecision(18, 9);
                entity.Property(e => e.ExecutedQuantity).HasPrecision(18, 5);
                entity.Property(e => e.LeavesQuantity).HasPrecision(18, 5);
                entity.Property(e => e.OrderStatus).HasMaxLength(50);
                entity.Property(e => e.MaturityDay)
                    .HasMaxLength(2)
                    .IsFixedLength();
                entity.Property(e => e.MaturityYearMonth)
                    .HasMaxLength(6)
                    .IsFixedLength();
                entity.Property(e => e.OSISymbol)
                    .HasMaxLength(50);
                entity.Property(e => e.OpenClose)
                    .HasMaxLength(1);
                entity.Property(e => e.PutCall)
                    .HasMaxLength(1);
                entity.Property(e => e.StrikePrice).HasPrecision(18, 9);
                entity.Property(e => e.Ratio).HasPrecision(18, 5);
                entity.Property(e => e.LegProduct).IsRequired().HasMaxLength(20);

                var productConverter = new EnumToStringConverter<Product>();

                entity
                    .Property(p => p.LegProduct)
                    .HasConversion(productConverter);

                var orderSubmissionStatusConverter = new EnumToStringConverter<OrderSubmissionStatus>();

                entity
                    .Property(p => p.OrderStatus)
                    .HasConversion(orderSubmissionStatusConverter);

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("OrderHistory_Id");

                entity.ToTable("OrderHistory", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.CancelReplaceClientOrderId).HasMaxLength(48);
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(e => e.LimitPrice).HasPrecision(18, 9);
                entity.Property(e => e.OrderQuantity).HasPrecision(18, 5);
                entity.Property(e => e.OriginalClientOrderId)
                    .IsRequired()
                    .HasMaxLength(48);
                entity.Property(e => e.StopPrice).HasPrecision(18, 9);
                entity.Property(e => e.Price).HasPrecision(18, 9);

                var converter = new EnumToStringConverter<OrderSubmissionStatus>();

                entity
                    .Property(p => p.OrderStatus)
                    .HasConversion(converter);

                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<TradeBooking>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_TradeBooking_Id");

                entity.ToTable("TradeBooking", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.AccountNumber).HasMaxLength(100);
                entity.Property(e => e.BackOfficeAccount).HasMaxLength(100);
                entity.Property(e => e.ClearingAccount).HasMaxLength(100);
                entity.Property(e => e.ClientOrderId)
                    .IsRequired()
                    .HasMaxLength(48);
                entity.Property(e => e.CommissionAmount).HasPrecision(18, 4);
                entity.Property(e => e.ContraBroker).HasMaxLength(100);
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("now()");
                entity.Property(e => e.DestinationCode).HasMaxLength(5);
                entity.Property(e => e.ExchangeCode).HasMaxLength(10);
                entity.Property(e => e.ExecutedPrice).HasPrecision(18, 9);
                entity.Property(e => e.ExecutionId)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.ExecutionType)
                    .IsRequired()
                    .HasMaxLength(1);
                entity.Property(e => e.Legend).HasMaxLength(20);
                entity.Property(e => e.MajorEnteringBroker).HasMaxLength(10);
                entity.Property(e => e.Market).HasMaxLength(1);
                entity.Property(e => e.MessageType).HasMaxLength(1);
                entity.Property(e => e.OrderCapacity).HasMaxLength(1);
                entity.Property(e => e.OrderQuantity).HasPrecision(18, 5);
                entity.Property(e => e.OtherSideContraBroker).HasMaxLength(10);
                entity.Property(e => e.P3TradeConfirmationNumber).HasMaxLength(50);
                entity.Property(e => e.Remarks).HasMaxLength(200);
                entity.Property(e => e.SecurityId).HasMaxLength(50);
                entity.Property(e => e.SettleDate).HasMaxLength(8);
                entity.Property(e => e.Symbol)
                    .HasMaxLength(30);
                entity.Property(e => e.TradeBookingStatus)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.TradeBookingType)
                    .HasMaxLength(20)
                    .IsFixedLength();
                entity.Property(e => e.TradeDate).HasMaxLength(8);
                entity.Property(e => e.TransactionTime)
                    .IsRequired()
                    .HasMaxLength(30);
                entity.Property(e => e.UpdateBy).HasMaxLength(60);

                var bookingStatusConverter = new EnumToStringConverter<BookingStatus>();

                entity
                    .Property(p => p.TradeBookingStatus)
                    .HasConversion(bookingStatusConverter);

                var bookingTypeConverter = new EnumToStringConverter<TradeBookingType>();

                entity
                    .Property(p => p.TradeBookingType)
                    .HasConversion(bookingTypeConverter);

                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<TradeBookingAudit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_TradeBookingAudit_Id");

                entity.ToTable("TradeBookingAudit", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(60);
                entity.Property(e => e.ExecutionId)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.P3TradeConfirmationNumber).HasMaxLength(50);
                entity.Property(e => e.RejectReason).HasMaxLength(50);
                entity.Property(e => e.TradeBookingMessage).IsRequired();

                var channelConverter = new EnumToStringConverter<TradeBookingChannel>();

                entity.Property(e => e.Channel)
                    .HasConversion(channelConverter);

                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });

            modelBuilder.Entity<TradeBookingFee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_TradeBookingFee_Id");

                entity.ToTable("TradeBookingFee", "db");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(e => e.Fee).HasPrecision(18, 4);
                entity.Property(e => e.FeeTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.P3Code)
                    .HasMaxLength(20)
                    .HasColumnName("P3Code");

                entity.Ignore("CreatedBy");
                entity.Ignore("CreatedOn");
                entity.Ignore("UpdateBy");
                entity.Ignore("UpdateOn");
                entity.Ignore("IsDeleted");
                entity.Ignore("DeletedBy");
                entity.Ignore("DeletedOn");
                entity.Ignore("RowVersion");
            });
        }
    }
}
