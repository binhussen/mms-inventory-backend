using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class NotifyHeaderConfiguration : IEntityTypeConfiguration<NotifyHeader>
    {
        public void Configure(EntityTypeBuilder<NotifyHeader> builder)
        {
            builder.HasData
            (
                new NotifyHeader
                {
                    id = 1,
                    itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                    attachments = "Upload your Attachment"
                },
                new NotifyHeader
                {
                    id = 2,
                    itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                    attachments = "Upload your Attachment"
                }
            );
        }
    }
}
