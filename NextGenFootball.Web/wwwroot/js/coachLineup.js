function getPlayers() {
    return window.lineupPlayers || [];
}

function getFormations() {
    return window.formations || [];
}

function getSelectedFormation() {
    const name = window.selectedFormationName || (getFormations()[0]?.Name);
    return getFormations().find(f => f.Name === name) || getFormations()[0];
}

function renderPitch() {
    const pitch = document.getElementById("footballPitch");
    pitch.innerHTML = "";
    const positions = getSelectedFormation().Positions;
    for (let i = 0; i < positions.length; i++) {
        const pos = positions[i];
        const div = document.createElement("div");
        div.className = "pitch-position";
        div.style.left = pos.X + "%";
        div.style.top = pos.Y + "%";
        const options = getPlayers().map(p =>
            `<option value="${p.Id}">${p.FirstName} ${p.LastName} (${p.Position})</option>`
        ).join("");
        div.innerHTML = `
            <div class="pitch-label">${pos.DisplayLabel}</div>
            <select class="player-select" name="Players[${i}]" data-pos="${pos.PositionName}">
                <option value="">-- Choose --</option>
                ${options}
            </select>
        `;
        pitch.appendChild(div);
    }
    updateLineupInputs();
    Array.from(document.getElementsByClassName("player-select")).forEach(sel => {
        sel.addEventListener("change", updateLineupInputs);
    });
}

function updateFormation() {
    const select = document.getElementById("formationSelect");
    window.selectedFormationName = select.value;
    document.getElementById("SelectedFormationName").value = select.value;
    renderPitch();
}

function updateLineupInputs() {
    const lineupInputs = document.getElementById("lineupInputs");
    lineupInputs.innerHTML = "";
    Array.from(document.getElementsByClassName("player-select")).forEach((sel, i) => {
        if (sel.value) {
            const input = document.createElement("input");
            input.type = "hidden";
            input.name = `SelectedPlayers[${i}]`;
            input.value = sel.value;
            lineupInputs.appendChild(input);

            const posInput = document.createElement("input");
            posInput.type = "hidden";
            posInput.name = `SelectedPositions[${i}]`;
            posInput.value = sel.getAttribute("data-pos");
            lineupInputs.appendChild(posInput);
        }
    });
}

document.addEventListener("DOMContentLoaded", function () {
    renderPitch();
    document.getElementById("formationSelect").addEventListener("change", updateFormation);
});