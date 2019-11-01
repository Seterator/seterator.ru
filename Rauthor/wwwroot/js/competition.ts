async function removeButtonClick(sender: any): Promise<void> {
    let guid: string = window.location.pathname.split(new RegExp("/|\\?"))[3];
    await fetch(`/api/competition/${guid}`,
        {
            method: "delete"
        });
}
