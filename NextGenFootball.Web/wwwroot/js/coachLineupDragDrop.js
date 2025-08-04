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

let lineupAssignments = {}; // { posIndex: playerId }
let draggingPlayerId = null;

function renderPlayerList() {
    const assignedIds = Object.values(lineupAssignments);
    const playerListDiv = document.getElementById("playerList");
    playerListDiv.innerHTML = "";

    getPlayers().forEach((player) => {
        // If already assigned, don't show in list
        if (assignedIds.includes(player.Id)) return;
        const card = document.createElement("div");
        card.className = "player-card";
        card.setAttribute("draggable", "true");
        card.setAttribute("data-player-id", player.Id);

        // Use player image if available, else icon
        let imgHtml = player.ImageUrl
            ? `<img src="${player.ImageUrl}" alt="Player" />`
            : `<i class="bi bi-person-fill"></i>`;

        card.innerHTML = `
            ${imgHtml}
            <div class="player-info">
                <span class="player-name">${player.FirstName} ${player.LastName}</span>
            </div>
        `;
        card.addEventListener("dragstart", function (e) {
            draggingPlayerId = player.Id;
            card.classList.add("dragging");
        });
        card.addEventListener("dragend", function (e) {
            draggingPlayerId = null;
            card.classList.remove("dragging");
        });
        playerListDiv.appendChild(card);
    });
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
        div.setAttribute("data-pos-index", i);

        // Drag-and-drop events
        div.addEventListener("dragover", function (e) {
            e.preventDefault();
            div.classList.add("drag-over");
        });
        div.addEventListener("dragleave", function (e) {
            div.classList.remove("drag-over");
        });
        div.addEventListener("drop", function (e) {
            e.preventDefault();
            div.classList.remove("drag-over");
            if (draggingPlayerId) {
                assignPlayer(i, draggingPlayerId);
            }
        });

        let assignedPlayerId = lineupAssignments[i];
        let assignedPlayer = assignedPlayerId ? getPlayers().find(p => p.Id === assignedPlayerId) : null;

        // Position label: hidden if player assigned, visible otherwise
        div.innerHTML = `
            <span class="pitch-label${assignedPlayer ? ' hidden' : ''}">
                <i class="bi bi-people"></i> ${pos.DisplayLabel}
            </span>
            <div class="pitch-player-card" ${assignedPlayer ? '' : 'style="display:none;"'}>
                ${assignedPlayer
                ? (
                    assignedPlayer.ImageUrl
                        ? `<img src="${assignedPlayer.ImageUrl}" alt="Player" />`
                        : `<i class="bi bi-person-circle"></i>`
                ) +
                ` ${assignedPlayer.FirstName} ${assignedPlayer.LastName}
                            <button type="button" class="pitch-remove-btn" title="Remove" onclick="removePlayer(${i})"><i class="bi bi-x-circle-fill"></i></button>`
                : ""
            }
            </div>
        `;
        pitch.appendChild(div);
    }
    updateLineupInputs();
    renderPlayerList();
}

function assignPlayer(posIndex, playerId) {
    // Prevent player from being assigned twice
    if (Object.values(lineupAssignments).includes(playerId)) return;

    lineupAssignments[posIndex] = playerId;
    renderPitch();
}

function removePlayer(posIndex) {
    delete lineupAssignments[posIndex];
    renderPitch();
}

function updateFormation() {
    const select = document.getElementById("formationSelect");
    window.selectedFormationName = select.value;
    document.getElementById("SelectedFormationName").value = select.value;
    lineupAssignments = {};
    renderPitch();
}

function updateLineupInputs() {
    const lineupInputs = document.getElementById("lineupInputs");
    lineupInputs.innerHTML = "";
    Object.keys(lineupAssignments).forEach((posIndex) => {
        const playerId = lineupAssignments[posIndex];
        const posName = getSelectedFormation().Positions[posIndex].PositionName;
        const inputPlayer = document.createElement("input");
        inputPlayer.type = "hidden";
        inputPlayer.name = `SelectedPlayers[${posIndex}]`;
        inputPlayer.value = playerId;
        lineupInputs.appendChild(inputPlayer);

        const inputPos = document.createElement("input");
        inputPos.type = "hidden";
        inputPos.name = `SelectedPositions[${posIndex}]`;
        inputPos.value = posName;
        lineupInputs.appendChild(inputPos);
    });
}

document.addEventListener("DOMContentLoaded", function () {
    renderPitch();
    document.getElementById("formationSelect").addEventListener("change", updateFormation);
});