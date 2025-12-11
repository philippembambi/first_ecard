using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Mappings
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardCreateDto, Card>();
            CreateMap<Card, CardDto>();
            CreateMap<CardUpdateDto, Card>();
        }
    }
}