﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public DateTime CreationDate { get; set; }= DateTime.Now;
        public bool IsDelete { get; set; }

    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
