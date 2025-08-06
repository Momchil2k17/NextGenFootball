document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".clickable-row").forEach(function (row) {
        row.addEventListener("click", function (e) {
            if (e.target.tagName === "A") return;
            window.location = this.dataset.href;
        });
    });
});