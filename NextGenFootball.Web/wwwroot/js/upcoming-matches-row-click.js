document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll("tr.upcoming-match-row").forEach(function (row) {
        row.addEventListener("click", function (e) {
            // Prevent link click inside cell from triggering row click
            if (e.target.tagName === 'A') return;
            window.location.href = row.getAttribute("data-href");
        });
        row.addEventListener("keydown", function (e) {
            if (e.key === "Enter" || e.key === " ") {
                window.location.href = row.getAttribute("data-href");
            }
        });
        row.setAttribute("tabindex", "0");
        row.setAttribute("role", "button");
        row.setAttribute("aria-label", "View match details");
    });
});