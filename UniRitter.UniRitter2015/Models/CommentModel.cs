using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniRitter.UniRitter2015.Models
{
    public class CommentModel
    {
        public Guid? id { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Tamanho maximo de 1000 caracteres")]
        public string body { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Tamanho maximo de 50 caracteres")]
        public string title { get; set; }

        public PersonModel author { get; set; }
    }
}