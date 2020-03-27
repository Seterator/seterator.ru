function ReturnTime(competitionDate) {
    var difference = new Date(competitionDate) - Date.now();
        
    var days = Math.trunc(difference / (1000 * 3600 * 24));
    var hours = Math.trunc(difference / (1000 * 3600)) - days * 24;
    var min = Math.trunc(difference / (1000 * 60)) - days * 24 * 60 - hours * 60;
    var answ = days + " д " + hours + " ч " + min + " м";
    return answ;
}