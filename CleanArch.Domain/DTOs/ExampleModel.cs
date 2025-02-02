﻿using Sieve.Attributes;


namespace CleanArch.Application.DTOs
{
    public class ExampleModel
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public long IdExample { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string NameExample { get; set; }  = string.Empty;
        [Sieve(CanFilter = true, CanSort = true)]
        public decimal? PriceExample { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime? CreatedAt { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string CreatedBy { get; set; } = string.Empty;
		[Sieve(CanFilter = true, CanSort = true)]
        public DateTime? ModifiedAt { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string ModifiedBy { get; set; } = string.Empty;
	}
}
