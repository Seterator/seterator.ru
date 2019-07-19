using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.ViewModels
{
    public class PoemModel
    {
        [Required(ErrorMessage = "Пустое произведение")]
        [DataType(DataType.Text)]
        [DisplayName("Текст")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Укажите название")]
        [DataType(DataType.Text)]
        [DisplayName("Название")]
        public string Title { get; set; }
    }
}
