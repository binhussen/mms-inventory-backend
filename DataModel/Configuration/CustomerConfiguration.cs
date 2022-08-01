using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
            (
                new Customer
                {
                    id = 1,
                    name = "የሱፍ",
                    homeNumber = "+251923531946",
                    birthPlace = "ብቸና ከተማ",
                    sex = "ወንድ",
                    birthDate = DateTime.Now,
                    timeLimit = DateTime.Now,
                    region = "አማራ",
                    subCity = "ንፋስ ስልክ ላፍቶ",
                    woreda = "02",
                    occupation = "ጀማሪ የሶፍትዌር ባለሙያ",
                    phoneNumber = "+251923531946",
                    hrId = 1
                },
                new Customer
                {
                    id = 2,
                    name = "ሙሀመድ",
                    homeNumber = "+251923531946",
                    birthPlace = "ባቲ ከተማ",
                    sex = "ወንድ",
                    birthDate = DateTime.Now,
                    timeLimit = DateTime.Now,
                    region = "አማራ",
                    subCity = "ቦሌ",
                    woreda = "02",
                    occupation = "ጀማሪ የሶፍትዌር ባለሙያ",
                    phoneNumber = "+251923531946",
                    hrId = 1
                },
                 new Customer
                 {
                     id = 3,
                     name = "ሁንዴ",
                     homeNumber = "+251923531946",
                     birthPlace = "ጊንጪ ከተማ",
                     sex = "ወንድ",
                     birthDate = DateTime.Now,
                     timeLimit = DateTime.Now,
                     region = "ኦሮሚያ",
                     subCity = "ንፋስ ስልክ ላፍቶ",
                     woreda = "02",
                     occupation = "ጀማሪ የሶፍትዌር ባለሙያ",
                     phoneNumber = "+251923531946",
                     hrId = 2
                 },
                  new Customer
                  {
                      id = 4,
                      name = "ሰማይነህ",
                      homeNumber = "+251923531946",
                      birthPlace = "ብቸና ከተማ",
                      sex = "ወንድ",
                      birthDate = DateTime.Now,
                      timeLimit = DateTime.Now,
                      region = "አማራ",
                      subCity = "ንፋስ ስልክ ላፍቶ",
                      woreda = "02",
                      occupation = "ጀማሪ የሶፍትዌር ባለሙያ",
                      phoneNumber = "+251923531946",
                      hrId = 1
                  },
                 new Customer
                 {
                     id = 5,
                     name = "የሱፍ",
                     homeNumber = "+251923531946",
                     birthPlace = "ብቸና ከተማ",
                     sex = "ወንድ",
                     birthDate = DateTime.Now,
                     timeLimit = DateTime.Now,
                     region = "አማራ",
                     subCity = "ንፋስ ስልክ ላፍቶ",
                     woreda = "02",
                     occupation = "ጀማሪ የሶፍትዌር ባለሙያ",
                     phoneNumber = "+251923531946",
                     hrId = 1
                 }
            );
        }
    }
}
