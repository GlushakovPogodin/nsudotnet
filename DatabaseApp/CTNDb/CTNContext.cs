using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTNDb
{
    public class CTNContext : DbContext
    {
        public virtual DbSet<CTN> CTNSet { get; set; }
        public virtual DbSet<ATSType> ATSTypeSet { get; set; }
        public virtual DbSet<ATS> ATSSet { get; set; }
        public virtual DbSet<Address> AddressSet { get; set; }
        public virtual DbSet<PhoneType> PhoneTypeSet { get; set; }
        public virtual DbSet<Phone> PhoneSet { get; set; }
        public virtual DbSet<SubscriberType> SubscriberTypeSet { get; set; }
        public virtual DbSet<IntercityStatus> IntercityStatusSet { get; set; }
        public virtual DbSet<Subscriber> SubscriberSet { get; set; }
        public virtual DbSet<QueueType> QueueTypeSet { get; set; }
        public virtual DbSet<Queue> QueueSet { get; set; }
        public virtual DbSet<IntercityConversation> IntercityConversationSet { get; set; }
        public virtual DbSet<BalanceChangeType> BalanceChangeTypeSet { get; set; }
        public virtual DbSet<Balance> BalanceSet { get; set; }

        public CTNContext(string connectionString) : base(connectionString)
        {
            
        }
        public CTNContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ATSType>()
                .HasMany(e => e.ATS)
                .WithRequired(e => e.ATSType)
                .HasForeignKey(e => e.ATSTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<BalanceChangeType>()
                .HasMany(e => e.Balance)
                .WithRequired(e => e.BalanceChangeType)
                .HasForeignKey(e => e.BalanceChangeTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PhoneType>()
                .HasMany(e => e.Phone)
                .WithRequired(e => e.PhoneType)
                .HasForeignKey(e => e.PhoneTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<QueueType>()
                .HasMany(e => e.Queue)
                .WithRequired(e => e.QueueType)
                .HasForeignKey(e => e.QueueTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SubscriberType>()
                .HasMany(e => e.Subscriber)
                .WithRequired(e => e.SubscriberType)
                .HasForeignKey(e => e.SubscriberTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Phone>()
                .HasMany(e => e.Balance)
                .WithRequired(e => e.Phone)
                .HasForeignKey(e => e.PhoneId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Phone>()
                .HasMany(e => e.IntercityConversation)
                .WithRequired(e => e.Phone)
                .HasForeignKey(e => e.PhoneId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CTN>()
                .HasMany(e => e.IntercityConversation)
                .WithRequired(e => e.ExteriorCTN)
                .HasForeignKey(e => e.ExteriorCTNId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscriber>()
                .HasMany(e => e.Phone)
                .WithRequired(e => e.Subscriber)
                .HasForeignKey(e => e.SubscriberId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Phone)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.AddressId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Queue)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.AddressId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CTN>()
                .HasMany(e => e.ATS)
                .WithRequired(e => e.CTN)
                .HasForeignKey(e => e.CTNId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ATS>()
                .HasMany(e => e.Phone)
                .WithRequired(e => e.ATS)
                .HasForeignKey(e => e.ATSId)
                .WillCascadeOnDelete(true);
        }

    }
}
