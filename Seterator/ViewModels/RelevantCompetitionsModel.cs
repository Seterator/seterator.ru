using Seterator.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.ViewModels
{
    /// <summary>
    /// Представляет конкурсы, которые пользователю выгодно увидеть сейчас
    /// </summary>
    public class RelevantCompetitionsModel
    {
        /// <summary>
        /// Конкурсы, результат которых скоро будет опубликован
        /// </summary>
        public IEnumerable<Competition> IncomingResultCompetitions { get; set; }
        /// <summary>
        /// Конкурсы, на которые скоро будет закрыта регистрация
        /// </summary>
        public IEnumerable<Competition> ClosingApplyCompetitions { get; set; }
    }
}
