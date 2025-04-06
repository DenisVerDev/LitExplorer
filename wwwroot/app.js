window.toggleTheme = (isDarkTheme) => {
    if (isDarkTheme) {
        document.body.classList.add("dark-theme");
    }
    else {
        document.body.classList.remove("dark-theme");
    }
};