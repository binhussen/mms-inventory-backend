using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class NotifyItemConfiguration : IEntityTypeConfiguration<NotifyItem>
    {
        public void Configure(EntityTypeBuilder<NotifyItem> builder)
        {
            builder.HasData
            (
                new NotifyItem
                {
                    id = 1,
                    type = "ክላሽ ጠብመንጃ",
                    name = "ክላሽ ጠብመንጃ",
                    model = "ክላሽ ጠብመንጃ",
                    quantity = 10,
                    notifyHeaderId = 1,
                },
                new NotifyItem
                {
                    id = 2,
                    type = "ክላሽ ጠብመንጃ ካርታ",
                    name = "ክላሽ ጠብመንጃ ካርታ",
                    model = "ክላሽ ጠብመንጃ ካርታ",
                    quantity = 10,
                    notifyHeaderId = 2,
                },
                new NotifyItem
                {
                    id = 3,
                    type = "የፒኬአም መተረየስ",
                    name = "የፒኬአም መተረየስ",
                    model = "የፒኬአም መተረየስ",
                    quantity = 10,
                    notifyHeaderId = 1,
                },
                new NotifyItem
                {
                    id = 4,
                    type = "ካኑኒ ኤስ ሽጉጥ",
                    name = "ካኑኒ ኤስ ሽጉጥ",
                    model = "ካኑኒ ኤስ ሽጉጥ",
                    quantity = 10,
                    notifyHeaderId = 2,
                },
                 new NotifyItem
                 {
                     id = 5,
                     type = "ክላሽ ጠብመንጃ",
                     name = "ክላሽ ጠብመንጃ AK-47",
                     model = "ጠብመንጃ AK-47",
                     quantity = 10,
                     notifyHeaderId = 2,
                 }
            );
        }
    }
}
