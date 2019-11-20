namespace Competition {
    async function removeButtonClick(sender: any): Promise<void> {
        let guid = Core.Utils.getCurrentGuid();
        await fetch(`/api/competition/${guid}`,
            {
                method: "delete"
            });
    }
}