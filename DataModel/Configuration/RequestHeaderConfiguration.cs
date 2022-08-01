using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class RequestHeaderConfiguration : IEntityTypeConfiguration<RequestHeader>
    {
        public void Configure(EntityTypeBuilder<RequestHeader> builder)
        {
            builder.HasData
            (
                new RequestHeader
                {
                    id = 1,
                    description = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                    attachments = "Upload your Attachment",
                    hrId = 1
                },
                new RequestHeader
                {
                    id = 2,
                    description = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                    attachments = "Upload your Attachment",
                    hrId = 2
                }
            );
        }
    }
}
