﻿using System.ComponentModel.DataAnnotations;

namespace WorldApi.DTO.Country
{
    public class createCountryDto
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }

    }
}
