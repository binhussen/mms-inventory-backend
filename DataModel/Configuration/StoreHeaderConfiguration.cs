using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class StoreHeaderConfiguration : IEntityTypeConfiguration<StoreHeader>
    {
        public void Configure(EntityTypeBuilder<StoreHeader> builder)
        {
            builder.HasData
            (
                new StoreHeader
                {
                    id = 1,
                    itemNoInExpenditureRegister = "no. 1",
                    noOfEntryInTheRegisterOfIncomingGoods = "10 items",
                    donor = "የኢትዮጵያ መከላከያ"
                },
                new StoreHeader
                {
                    id = 2,
                    itemNoInExpenditureRegister = "no. 2",
                    noOfEntryInTheRegisterOfIncomingGoods = "10 items",
                    donor = "የኢትዮጵያ መከላከያ"
                }
            );
        }
    }
}
