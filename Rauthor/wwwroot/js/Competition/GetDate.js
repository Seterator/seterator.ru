let guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
window.fetch(`/api/competition/${guid}`).then(response => response.json()).then(competition => SetDate(competition));

//{
//    "Guid": "429bdb43-8eca-e911-a3f6-0af517f0072e",
//        "Title": "литературная начитка",
//        "StartDate": "2019-11-08T00:00:00",
//        "EndDate": "2019-11-09T00:00:00",
//        "Description": "присылайте свои видео ютуб",
//        "Prizes": "null",
//        "Participants": [{
                            //            "Guid": "3bc47dc2-0290-4474-8377-cc8a1483f3b1",
                            //            "CompetitionGuid": "429bdb43-8eca-e911-a3f6-0af517f0072e",
                            //            "UserGuid": "da31b641-8c73-43a7-a9ee-b00b46eacb51",
                                        //"Status": 2,
                                        //"CreateDate": "1972-01-01T00:00:00",
                            //            "Nickname": null,
                            //            "Approved": false,
                            //            "Poems": null,
                            //            "Competition": null,
                            //            "User": null
                            //    }, {
                            //        "Guid": "3386eb10-e59d-43d6-b49e-6243dcb59dd4",
                            //                "CompetitionGuid": "429bdb43-8eca-e911-a3f6-0af517f0072e",
                            //                "UserGuid": "12e61f66-52b8-47a0-9c3e-5636835b0b46",
                            //                "Status": 1, "CreateDate": "1972-01-01T00:00:00",
                            //                "Nickname": null, "Approved": true,
                            //                "Poems": null, "Competition": null,
                            //                "User": null
                            //        }, {
                            //            "Guid": "8fd29398-bf2b-48c4-91fa-716140444286",
                            //                "CompetitionGuid": "429bdb43-8eca-e911-a3f6-0af517f0072e",
                            //                "UserGuid": "56e1a5b1-4c2d-4a15-b17b-29b4b1ff0e39",
                            //                "Status": 2, "CreateDate": "0001-01-01T00:00:00",
                            //                "Nickname": null,
                            //                "Approved": false,
                            //                "Poems": null,
                            //                "Competition": null,
                            //                "User": null
                            //        }, {
                            //            "Guid": "c67c9b06-7680-4a25-9001-309027f79385",
                            //                "CompetitionGuid": "429bdb43-8eca-e911-a3f6-0af517f0072e",
                            //                "UserGuid": "3c0120eb-016b-417f-8446-9969cb1c62fb",
                            //                "Status": 2, "CreateDate": "0001-01-01T00:00:00",
                            //                "Nickname": null,
                            //                "Approved": false,
                            //                "Poems": null,
                            //                "Competition": null,
                            //                "User": null
//        }], 
//        "Categories": [],
//        "Constraints": null,
//            "Jury": null
//}


function SetDate(comp) {
        let competition = new Core.Models.Competition(
        comp.Title,
        comp.StartDate,
        comp.EndDate,
        comp.Description,
        comp.Prizes
    );

    document.querySelector(".banner h2").textContent = competition.Title;
    document.querySelector(".banner p").textContent = competition.Description;
    document.querySelector(".timer").textContent = competition.EndDate;
    document.querySelector(".full-description").textContent = competition.Description;
    document.querySelector(".prizes ul").textContent = competition.Prizes;

    let jury_ul = document.querySelector(".jury ul");
    Append_jury_li(jury_ul, comp.Jury);
}

function Append_jury_li(ul, jury) {
    let li = document.createElement('li');

    let li_div = document.createElement('div');

    let div_avatar = document.createElement('div');
    div_avatar.className = 'avatar';

    let span_name = document.createElement('span');
    span_name.className = 'name';
    //span_name.textContent = jury.Nickname;
    span_name.textContent = "Здесь ник жюри";

    let p_about = document.createElement('p');
    p_about.className = 'about';
    p_about.textContent = "Здесь описание жюри";

    li_div.append(div_avatar, span_name);
    li.append(li_div, p_about);
    ul.append(li);
}