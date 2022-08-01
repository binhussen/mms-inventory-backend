using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class RequestItemConfiguration : IEntityTypeConfiguration<RequestItem>
    {
        public void Configure(EntityTypeBuilder<RequestItem> builder)
        {
            builder.HasData
            (
                new RequestItem
                {
                    id = 1,
                    name = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                    model = "ክላሽ ጠብመንጃ",
                    type = "ክላሽ ጠብመንጃ",
                    status = "Pending",
                    approvedQuantity = 0,
                    requestedQuantity = 10,
                    attachments = "Upload your Attachment",
                    requestHeaderId = 1
                },
                new RequestItem
                {
                    id = 2,
                    name = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                    model = "ክላሽ ጠብመንጃ ካርታ",
                    type = "ክላሽ ጠብመንጃ ካርታ",
                    status = "Pending",
                    approvedQuantity = 0,
                    requestedQuantity = 5,
                    attachments = "Upload your Attachment",
                    requestHeaderId = 1
                },
                 new RequestItem
                 {
                     id = 3,
                     name = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                     model = "የፒኬአም መተረየስ",
                     type = "የፒኬአም መተረየስ",
                     status = "Pending",
                     approvedQuantity = 0,
                     requestedQuantity = 10,
                     attachments = "Upload your Attachment",
                     requestHeaderId = 1
                 },
                  new RequestItem
                  {
                      id = 4,
                      name = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                      model = "ክላሽ ጠብመንጃ AK-47",
                      type = "ክላሽ ጠብመንጃ",
                      status = "Pending",
                      approvedQuantity = 0,
                      requestedQuantity = 10,
                      attachments = "Upload your Attachment",
                      requestHeaderId = 2
                  },
                 new RequestItem
                 {
                     id = 5,
                     name = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                     model = "ካኑኒ ኤስ ሽጉጥ",
                     type = "ካኑኒ ኤስ ሽጉጥ",
                     status = "Pending",
                     approvedQuantity = 0,
                     requestedQuantity = 10,
                     attachments = "Upload your Attachment",
                     requestHeaderId = 2
                 },
                   new RequestItem
                   {
                       id = 6,
                       name = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                       model = "ካኑኒ ኤስ ሽጉጥ",
                       type = "ካኑኒ ኤስ ሽጉጥ",
                       status = "Pending",
                       approvedQuantity = 0,
                       requestedQuantity = 5,
                       attachments = "Upload your Attachment",
                       requestHeaderId = 2
                   }
            );
        }
    }
}
