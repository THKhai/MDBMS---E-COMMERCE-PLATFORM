using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MDBMS___E_COMMERCE_PLATFORM.repository.Entity
{
    public class SaleDto
    {
        [BsonElement("percent")]
        public decimal Percent { get; set; }
        [BsonElement("start_date")]
        public DateTime StartDate { get; set; }
        [BsonElement("end_date")]
        public DateTime EndDate { get; set; }

        public SaleDto(decimal percent, DateTime startDate, DateTime endDate)
        {
            Percent = percent;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static bool IsValidSaleInfo(decimal percent, DateTime startDate, DateTime endDate)
        {
            if (percent < 0 || percent > 100)
            {
                return false;
            }
            if (startDate >=  endDate)
            {
                return false;
            }
            var currentDate = DateTime.Now;
            return endDate >= currentDate;
        }
    }
}