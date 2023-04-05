﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SeznamUkonu.Models
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress(ErrorMessage = "Neplatná emailová adresa")]
		public string Email { get; set; } = "";
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Heslo")]
		public string Password { get; set; } = "";
		[Display(Name = "Pamatuj si mě")]
		public bool RememberMe { get; set; }
	}
}
