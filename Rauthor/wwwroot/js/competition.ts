document.addEventListener("readystatechange", () => {
    let form = document.getElementById("main-form") as HTMLFormElement;
    form.addEventListener("submit", create) 
});

class Competition {
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


async function removeButtonClick(sender: any): Promise<void> {
    let guid = getCurrentGuid();
    await fetch(`/api/competition/${guid}`,
        {
            method: "delete"
        });
}

function getCurrentGuid(): string {
    return window.location.pathname.split(new RegExp("/|\\?"))[3];
}

async function create(event: Event) {
    //let form = document.getElementById("main-form") as any;
    event.preventDefault();
    let competition = new Competition(
        this.title.value,
        this.startDate.value,
        this.endDate.value,
        this.description.value,
        this.prizes.value,
    );
    await fetch('/api/competition', {
        body: JSON.stringify(competition),
        method: "POST",
        headers: [
            ["Content-Type", "application/json"]
        ]
    });
    return false;
}