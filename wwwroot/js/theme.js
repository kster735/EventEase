

function getCurrentTheme() {
    const root = document.documentElement;
    let current = root.getAttribute("data-bs-theme");

    // In data-bs-theme attribute we should only have light or dark.
    // Auto or system don't make sense to bootstrap which 'wants' to choose between light or dark,
    // except if we have defined a custom theme.
    // If localStorage has a user defined choice as auto or system the our program should
    // handle the logic to check what is the system theme light or dark? Then we should set the 
    // current theme in data-bs-theme as light or dark. Localstorage remains auto or system.
    if (!(['light', 'dark'].includes(current))) {
        current = "light"
        setUserDefinedTheme(current);
    }

    return current;
}

function getUserDefinedTheme() {
    let userDefinedTheme = localStorage.getItem('theme');
    if (!['light', 'dark', 'auto'].includes(userDefinedTheme)) {
        // Initialize theme if there is no theme defined
        setUserDefinedTheme("auto");
        setTheme(getSystemTheme());
    }
    return userDefinedTheme;
}


function setTheme(theme) {
    document.documentElement.setAttribute('data-bs-theme', theme);
}

function setUserDefinedTheme(theme) {
    localStorage.setItem('theme', theme);
}

function getSystemTheme() {
    try {
        if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
            return 'dark';
        } else {
            return 'light';
        }
    } catch (error) {
        return getCurrentTheme();
    }
}

window.applyTheme = function (theme) {
    setUserDefinedTheme(theme);
    if (theme === "auto") {
        setTheme(getSystemTheme());
    } else {
        setTheme(theme);
    }
}


function handleAuto() {
    if (getUserDefinedTheme() !== "auto")
        return;
    setTheme(getSystemTheme());
}

function initializeTheme() {
    const user = getUserDefinedTheme();

    if (user === "auto") {
        setTheme(getSystemTheme());
        return;
    }

    if (user !== null) {
        setTheme(user);
    }

}

window.addEventListener('load', initializeTheme);

window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', handleAuto);

