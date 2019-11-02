namespace Core.Utils {
    export function getCurrentGuid(): string {
        return window.location.pathname.split(new RegExp("/|\\?"))[3];
    }
}