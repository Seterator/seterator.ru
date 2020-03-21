using System;
using System.ComponentModel;

namespace Seterator.ViewModels
{
    public class UserPoemModel
    {
        [DisplayName("Соревнование")]
        public string CompetitionTitle { get; set; }

        [DisplayName("Текст")]
        public string PoemText { get; set; }

        [DisplayName("Автор")]
        public string AuthorName { get; set; }

        public Guid PoemGuid { get; set; }
    }
}
