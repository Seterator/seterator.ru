using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.ViewModels
{
    public class PoemModel
    {
        [Required(ErrorMessage = "Пустое произведение")]
        [DataType(DataType.Text)]
        public string Text { get; set; }
    }
}
