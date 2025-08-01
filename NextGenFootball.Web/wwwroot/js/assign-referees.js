document.addEventListener('DOMContentLoaded', function () {
    const selects = document.querySelectorAll('.referee-select');
    const form = document.getElementById('refereeAssignmentForm');
    const errorDiv = document.getElementById('referee-error-message');

    function checkDuplicates() {
        const values = Array.from(selects).map(sel => sel.value).filter(val => val !== "");
        const hasDuplicates = (new Set(values)).size !== values.length;
        if (hasDuplicates) {
            errorDiv.textContent = "You cannot select the same referee for multiple positions.";
            errorDiv.style.display = 'block';
        } else {
            errorDiv.textContent = "";
            errorDiv.style.display = 'none';
        }
        return !hasDuplicates;
    }

    selects.forEach(sel => {
        sel.addEventListener('change', checkDuplicates);
    });

    if (form) {
        form.addEventListener('submit', function (e) {
            if (!checkDuplicates()) {
                e.preventDefault();
            }
        });
    }
});