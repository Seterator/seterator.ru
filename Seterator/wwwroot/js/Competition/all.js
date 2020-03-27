var Competition;
(function (Competition) {
    async function removeButtonClick(sender) {
        let guid = Core.Utils.getCurrentGuid();
        await fetch(`/api/competition/${guid}`, {
            method: "delete"
        });
    }
})(Competition || (Competition = {}));
//# sourceMappingURL=all.js.map