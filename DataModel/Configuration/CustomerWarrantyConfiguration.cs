using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class CustomerWarrantyConfiguration : IEntityTypeConfiguration<CustomerWarranty>
    {
        public void Configure(EntityTypeBuilder<CustomerWarranty> builder)
        {
            builder.HasData
            (
                new CustomerWarranty
                {
                    id = 1,
                    warantiyname = "የሱፍ",
                    warantiyAddress = "ብቸና ከተማ",
                    warantiyRegion = "አማራ",
                    warantiySubCity = "ንፋስ ስልክ ላፍቶ",
                    warantiyWoreda = "02",
                    customerId = 1
                },
                new CustomerWarranty
                {
                    id = 2,
                    warantiyname = "ሙሀመድ",
                    warantiyAddress = "ባቲ ከተማ",
                    warantiyRegion = "አማራ",
                    warantiySubCity = "ቦሌ",
                    warantiyWoreda = "02",
                    customerId = 1
                },
                 new CustomerWarranty
                 {
                     id = 3,
                     warantiyname = "ሁንዴ",
                     warantiyAddress = "ጊንጪ ከተማ",
                     warantiyRegion = "ኦሮሚያ",
                     warantiySubCity = "ንፋስ ስልክ ላፍቶ",
                     warantiyWoreda = "02",
                     customerId = 1
                 },
                  new CustomerWarranty
                  {
                      id = 4,
                      warantiyname = "ሰማይነህ",
                      warantiyAddress = "ብቸና ከተማ",
                      warantiyRegion = "አማራ",
                      warantiySubCity = "ንፋስ ስልክ ላፍቶ",
                      warantiyWoreda = "02",
                      customerId = 1
                  }
            );
        }
    }
}

