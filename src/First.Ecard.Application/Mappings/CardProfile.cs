using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.Ecard.Application.Dtos;
using First.Ecard.Application.Features.Cards.Commands;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Mappings
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardCreateDto, Card>();
            CreateMap<CreateCardCommand, Card>();
            CreateMap<Card, CardDto>();
            CreateMap<CardUpdateDto, Card>();
        }
    }
}