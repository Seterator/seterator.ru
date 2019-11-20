var Core;
(function (Core) {
    var Models;
    (function (Models) {
        class Competition {
            constructor(title, startDate, endDate, description, prizes) {
                this.Title = title;
                this.StartDate = startDate;
                this.EndDate = endDate;
                this.Description = description;
                this.Prizes = prizes;
            }
        }
        Models.Competition = Competition;
    })(Models = Core.Models || (Core.Models = {}));
})(Core || (Core = {}));
//# sourceMappingURL=models.js.map