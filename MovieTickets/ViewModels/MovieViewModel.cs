using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.ViewModels
{
    public class MovieViewModel
    {

        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Rate")]
        [Required(ErrorMessage = "Rate is required")]
        public int Rate { get; set; }

        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Start date is required")]
        [Remote(action:"StartDate", controller:"Validation", ErrorMessage ="Start Date Should not be before today" )]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "End date is required")]
        [Remote(action: "EndDate", controller: "Validation", AdditionalFields = "StartDate", ErrorMessage = "End Date Should be After Start Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public int Category_Id { get; set; }

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select Cienams")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public List<int> CinemaIds { get; set; }
        public List<int> Quantities { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int Producer_Id { get; set; }
        public byte[] Image { get; set; }
        public string Trailer {get; set; }
    }
}
