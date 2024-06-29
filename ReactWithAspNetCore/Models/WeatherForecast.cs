using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactWithAspNetCore.Models
{
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }

        public int? TemperatureC { get; set; }

        [StringLength(100)]
        public string? Summary { get; set; }

    }
}
