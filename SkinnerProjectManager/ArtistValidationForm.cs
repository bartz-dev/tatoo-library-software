using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinnerProjectManager
{
    public class ArtistValidationForm
    {
        [Required, RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Merci d'entrer un nom valide.")]
        public string nom { get; set; }
        [Required, RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Merci d'entrer un prenom valide.")]
        public string prenom { get; set; }
        [Required, RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Merci d'entrer un surnom valide.")]
        public string surnom { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string contact { get; set; }
    }
}
