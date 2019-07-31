﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public enum MenuItemType
    {
        Treminal,
        Brands,
        ProducedBrands,
        DeliveredBrands
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}