using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Configuration
{
    public class HrConfiguration : IEntityTypeConfiguration<HR>
    {
        public void Configure(EntityTypeBuilder<HR> builder)
        {
            builder.HasData
            (
                new HR
                {
                    id = 1,
                    fpId = "26505157",
                    firstName = "የሱፍ",
                    middleName = "ፈንታ",
                    LastName = "አለሙ",
                    gender = "ወንድ",
                    birthDate = DateTime.Now,
                    higherDate = DateTime.Now,
                    occpation = "ጀማሪ የሶፍትዌር ባለሙያ",
                    rank = "J_V / ጀማሪ",
                    reponsibilty = "የሲቪል ሰራተኛ",
                },
                new HR
                {
                    id = 2,
                    fpId = "26505152",
                    firstName = "ሙሀመድ",
                    middleName = "ሁሴን",
                    LastName = "አሊ",
                    gender = "ወንድ",
                    birthDate = DateTime.Now,
                    higherDate = DateTime.Now,
                    occpation = "ጀማሪ የሶፍትዌር ባለሙያ",
                    rank = "J_V / ጀማሪ",
                    reponsibilty = "የሲቪል ሰራተኛ",
                },
                 new HR
                 {
                     id = 3,
                     fpId = "26505156",
                     firstName = "ሁንዴ",
                     middleName = "ረጋሳ",
                     LastName = "ኦርጌሳ",
                     gender = "ወንድ",
                     birthDate = DateTime.Now,
                     higherDate = DateTime.Now,
                     occpation = "ጀማሪ የሶፍትዌር ባለሙያ",
                     rank = "J_V / ጀማሪ",
                     reponsibilty = "የሲቪል ሰራተኛ",
                 },
                  new HR
                  {
                      id = 4,
                      fpId = "26505155",
                      firstName = "ሰማይነህ",
                      middleName = "ከበደ",
                      LastName = "ታደሰ",
                      gender = "ወንድ",
                      birthDate = DateTime.Now,
                      higherDate = DateTime.Now,
                      occpation = "ጀማሪ የዌብሳይት አስተዳደር ባለሙያ",
                      rank = "J_V / ጀማሪ",
                      reponsibilty = "የሲቪል ሰራተኛ",
                  },
                 new HR
                 {
                     id = 5,
                     fpId = "fp2650",
                     firstName = "ተረፈ",
                     middleName = "በከለ",
                     LastName = "ተንኮሉ",
                     gender = "ወንድ",
                     birthDate = DateTime.Now,
                     higherDate = DateTime.Now,
                     occpation = "ዋና ክፍል ሀላፊ",
                     rank = "ዋና ክፍል",
                     reponsibilty = "ዋና ክፍል",
                 }
            );
        }
    }
}
