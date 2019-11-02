var Core;
(function (Core) {
    var Utils;
    (function (Utils) {
        function getCurrentGuid() {
            return window.location.pathname.split(new RegExp("/|\\?"))[3];
        }
        Utils.getCurrentGuid = getCurrentGuid;
    })(Utils = Core.Utils || (Core.Utils = {}));
})(Core || (Core = {}));
//# sourceMappingURL=utils.js.map