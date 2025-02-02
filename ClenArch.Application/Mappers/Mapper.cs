﻿using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Domain.DTOs.Choferes;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Mappers
{
	public class Mapper : Profile
	{

		public Mapper()
		{
			//CreateMap<User, LoginUser>()
			//	.ForMember(m => m.Password, o => o.MapFrom(e => e.Password))
			//	.ForMember(m => m.Email, o => o.MapFrom(e => e.Email))
			//	.ReverseMap();
			CreateMap<Example, ExampleModel>();
			CreateMap<ExampleModel, Example>();

			CreateMap<Chofer, ChoferDto>();
			CreateMap<ChoferDto, Chofer>().ReverseMap();

			//CreateMap<Example, ExampleModel>()
			//    .ForMember(m=>m.IdExample ,o=>o.MapFrom(e =>e.IdExample))
			//    .ForMember(m => m.CreatedBy, o => o.MapFrom(e => e.CreatedBy))
			//    .ForMember(m => m.CreatedAt, o => o.MapFrom(e => e.CreatedAt))
			//    .ForMember(m => m.PriceExample, o => o.MapFrom(e => e.PriceExample))
			//    .ForMember(m => m.NameExample, o => o.MapFrom(e => e.NameExample))
			//    .ForMember(m => m.ModifiedAt, o => o.MapFrom(e => e.ModifiedAt))
			//    .ForMember(m => m.ModifiedBy, o => o.MapFrom(e => e.ModifiedBy))
			//.ReverseMap();




		}

		//public Mapper()
		//{
		//    CreateMap<KnowUndocumentMail, KnowUndocumentMailModel>()
		//        .ForMember(M => M.MailingDate, O => O.MapFrom(E => E.MailingDate))
		//        .ForMember(M => M.KULCategoryName, O => O.MapFrom(E => E.KULCategory.Name))
		//        .ForMember(M => M.DescriptionId, O => O.MapFrom(E => E.DescriptionId))
		//        .ForMember(M => M.Description, O => O.MapFrom(E => E.DescriptionKum.Description))
		//        .ForMember(M => M.KnowUndocumentMailStatusId, O => O.MapFrom(E => E.KnowUndocumentMailStatusId))
		//        .ForMember(M => M.KnowUndocumentMailStatus, O => O.MapFrom(E => E.KnowUndocumentMailStatus.Name))
		//        .ReverseMap()
		//        .ForMember(x => x.KnowUndocumentMailStatus, o => o.Ignore());



	}
}
