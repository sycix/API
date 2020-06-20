﻿using ApiSample.DTOs.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.DAL
{
   public interface IServiceExample
    {
        string Test();
        ICollection<GuestResponseDto> GetGuestsCollection(string lastName);
        GuestResponseDto GetGuestById(int idGuest);
        bool AddGuest(GuestRequestDto newGuest);
        bool UpdateGuest(int id, GuestRequestDto updateGuest);
        bool DeleteGuest(int id);
    }
}
