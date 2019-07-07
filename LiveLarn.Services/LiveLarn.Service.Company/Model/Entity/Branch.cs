using LiveLarn.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Company.Model.Entity
{
    public class Branch : EntityBase<Int64>
    {
        [StringLength(4)]
        public string Code { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [StringLength(250)]
        public string AddressLine1 { get; set; }
        [StringLength(250)]
        public string AddressLine2 { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
