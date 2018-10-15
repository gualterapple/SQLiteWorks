﻿using System;
using SQLite;
using System.IO;

namespace SQLiteXDocs2.Models
{
    [Table("Items")]
    public class Stock
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
    }
}

