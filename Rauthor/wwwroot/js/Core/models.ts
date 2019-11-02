namespace Core.Models {
    export class Competition {
        public Title;
        public StartDate;
        public EndDate;
        public Description;
        public Prizes;

        public constructor(title, startDate, endDate, description, prizes) {
            this.Title = title;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
            this.Prizes = prizes;
        }
    }
}
