using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class StoreItemConfiguration : IEntityTypeConfiguration<StoreItem>
    {
        public void Configure(EntityTypeBuilder<StoreItem> builder)
        {
            builder.HasData
            (
                new StoreItem
                {
                    id = 1,
                    itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                    model = "ክላሽ ጠብመንጃ",
                    serialNo = "serial 1",
                    type = "ክላሽ ጠብመንጃ",
                    storeNo = "No. 1",
                    shelfNo = "No. 1",
                    quantity = 10,
                    availableQuantity = 10,
                    availability = true,
                    storeHeaderId = 1
                },
                new StoreItem
                {
                    id = 2,
                    itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                    model = "ክላሽ ጠብመንጃ ካርታ",
                    serialNo = "serial 2",
                    type = "ክላሽ ጠብመንጃ ካርታ",
                    storeNo = "No. 1",
                    shelfNo = "No 2",
                    quantity = 10,
                    availableQuantity = 10,
                    availability = true,
                    storeHeaderId = 1
                },
                 new StoreItem
                 {
                     id = 3,
                     itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                     model = "የፒኬአም መተረየስ",
                     serialNo = "serial 3",
                     type = "የፒኬአም መተረየስ",
                     storeNo = "N0 2",
                     shelfNo = "No. 1",
                     quantity = 10,
                     availableQuantity = 10,
                     availability = true,
                     storeHeaderId = 2
                 },
                  new StoreItem
                  {
                      id = 4,
                      itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                      model = "ክላሽ ጠብመንጃ AK-47",
                      serialNo = "serial 4",
                      type = "ክላሽ ጠብመንጃ",
                      storeNo = "No. 1",
                      shelfNo = "No 2",
                      quantity = 10,
                      availableQuantity = 10,
                      availability = true,
                      storeHeaderId = 1
                  },
                 new StoreItem
                 {
                     id = 5,
                     itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                     model = "ካኑኒ ኤስ ሽጉጥ",
                     serialNo = "serial 5",
                     type = "ካኑኒ ኤስ ሽጉጥ",
                     storeNo = "N0 2",
                     shelfNo = "No. 1",
                     quantity = 10,
                     availableQuantity = 10,
                     availability = true,
                     storeHeaderId = 2
                 },
                   new StoreItem
                   {
                       id = 6,
                       itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                       model = "ካኑኒ ኤስ ሽጉጥ",
                       serialNo = "serial 6",
                       type = "ካኑኒ ኤስ ሽጉጥ",
                       storeNo = "N0 2",
                       shelfNo = "No. 1",
                       quantity = 10,
                       availableQuantity = 10,
                       availability = true,
                       storeHeaderId = 1
                   }
            );
        }
    }
}
