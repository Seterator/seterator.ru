using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.ViewModels
{

    //название конкурса
    //члены жюри
    //описание, партнёры, ссылки на соцсети и сайт
    //список участников(автор - название произведения)
    //кнопка участвовать
    //\если уже участвует
    //вместо "участвовать" так же, как блок в списке заявок, его заявка и кнопки поделиться в соцсетях
    //поиск
    public class CompetitionDetailsViewModel
    {
        public string Title { get; set; }
        public List<string> Jury { get; set; }
        public string Description { get; set; }

    }
}
