﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.ReviewQuaries
{
    public class GetReviewByCarIdQuery:IRequest<List<GetReviewByCarIdQueryResult>>
    {
        public GetReviewByCarIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
