
const statTypes = ["Goal", "Assist", "Yellow Card", "Red Card", "Own Goal"];

function addEventRow(section, min, max, players) {
    var table = document.getElementById(section + "Table").getElementsByTagName('tbody')[0];
    if (table.rows.length > 0) {
        var lastRow = table.rows[table.rows.length - 1];
        var inputs = lastRow.querySelectorAll("input,select");
        for (var input of inputs) {
            if (input.value === "" || input.value === null) {
                input.classList.add("is-invalid");
                input.focus();
                return;
            } else {
                input.classList.remove("is-invalid");
            }
        }
    }
    var idx = table.rows.length;
    let playerOptions = '<option value="">-- Select --</option>';
    players.forEach(function (player) {
        playerOptions += `<option value="${player.PlayerId}">${player.PlayerName}</option>`;
    });
    let statOptions = '<option value="">-- Select --</option>';
    statTypes.forEach(function (stat) {
        statOptions += `<option value="${stat}">${stat}</option>`;
    });
    let row = table.insertRow();
    row.innerHTML = `
        <td>
            <input name="${section}[${idx}].Minute" type="number" class="form-control event-minute" min="${min}" max="${max}" />
        </td>
        <td>
            <select name="${section}[${idx}].PlayerId" class="form-select event-player">
                ${playerOptions}
            </select>
        </td>
        <td>
            <select name="${section}[${idx}].StatType" class="form-select event-stat">
                ${statOptions}
            </select>
        </td>
        <td>
            <button type="button" class="btn btn-danger btn-sm" onclick="removeRow(this, '${section}')">-</button>
        </td>
    `;
    updateScores();
    detectSecondYellow();
}

window.removeRow = function (btn, section) {
    var row = btn.closest('tr');
    var table = row.parentNode;
    row.remove();
    // reindex
    Array.from(table.rows).forEach((r, i) => {
        r.querySelectorAll('input,select').forEach(input => {
            input.name = input.name.replace(new RegExp(section + "\\[\\d+\\]"), section + "[" + i + "]");
        });
    });
    updateScores();
    detectSecondYellow();
};

function updateScores() {
    let homeScore = 0, awayScore = 0;
    // Home events
    document.querySelectorAll("#FirstHalfHomeEventsTable tbody tr, #SecondHalfHomeEventsTable tbody tr").forEach(row => {
        const stat = row.querySelector('.event-stat')?.value;
        if (stat === "Goal") homeScore++;
        if (stat === "Own Goal") awayScore++;
    });
    // Away events
    document.querySelectorAll("#FirstHalfAwayEventsTable tbody tr, #SecondHalfAwayEventsTable tbody tr").forEach(row => {
        const stat = row.querySelector('.event-stat')?.value;
        if (stat === "Goal") awayScore++;
        if (stat === "Own Goal") homeScore++;
    });
    // Only update score fields if they are not focused (so manual input isn't overwritten)
    const homeScoreInput = document.getElementById('HomeScore');
    const awayScoreInput = document.getElementById('AwayScore');
    if (document.activeElement !== homeScoreInput) {
        homeScoreInput.value = homeScore;
    }
    if (document.activeElement !== awayScoreInput) {
        awayScoreInput.value = awayScore;
    }
}

function detectSecondYellow() {
    const yellowCardMap = {};
    let warningMsg = "";
    // For home team
    document.querySelectorAll("#FirstHalfHomeEventsTable tbody tr, #SecondHalfHomeEventsTable tbody tr").forEach(row => {
        const playerId = row.querySelector('.event-player')?.value;
        const stat = row.querySelector('.event-stat')?.value;
        if (playerId && stat === "Yellow Card") {
            const key = "Home_" + playerId;
            yellowCardMap[key] = (yellowCardMap[key] || 0) + 1;
            if (yellowCardMap[key] === 2) {
                const playerName = row.querySelector('.event-player').selectedOptions[0].textContent;
                warningMsg += `Player <b>${playerName}</b> (Home) received a SECOND YELLOW CARD.<br/>`;
            }
        }
    });
    // For away team
    document.querySelectorAll("#FirstHalfAwayEventsTable tbody tr, #SecondHalfAwayEventsTable tbody tr").forEach(row => {
        const playerId = row.querySelector('.event-player')?.value;
        const stat = row.querySelector('.event-stat')?.value;
        if (playerId && stat === "Yellow Card") {
            const key = "Away_" + playerId;
            yellowCardMap[key] = (yellowCardMap[key] || 0) + 1;
            if (yellowCardMap[key] === 2) {
                const playerName = row.querySelector('.event-player').selectedOptions[0].textContent;
                warningMsg += `Player <b>${playerName}</b> (Away) received a SECOND YELLOW CARD.<br/>`;
            }
        }
    });
    const warnDiv = document.getElementById("yellowCardWarning");
    if (warningMsg) {
        warnDiv.innerHTML = warningMsg;
        warnDiv.classList.remove("d-none");
    } else {
        warnDiv.innerHTML = "";
        warnDiv.classList.add("d-none");
    }
}

// Update scores and detect yellow on any change
document.addEventListener('change', function (e) {
    if (e.target.classList.contains('event-stat') || e.target.classList.contains('event-player')) {
        updateScores();
        detectSecondYellow();
    }
});

// Initial update on page load
window.addEventListener('DOMContentLoaded', () => {
    updateScores();
    detectSecondYellow();
});