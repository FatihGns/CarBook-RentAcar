﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public RemoveBannerCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
