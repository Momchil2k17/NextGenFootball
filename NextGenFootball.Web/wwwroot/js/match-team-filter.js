function filterTeams(changed, toFilter) {
    var selectedValue = document.getElementById(changed).value;
    var toFilterDropdown = document.getElementById(toFilter);
    for (var i = 0; i < toFilterDropdown.options.length; i++) {
        toFilterDropdown.options[i].disabled = false;
        if (toFilterDropdown.options[i].value === selectedValue && selectedValue !== "") {
            toFilterDropdown.options[i].disabled = true;
        }
    }
    if (toFilterDropdown.value === selectedValue) {
        toFilterDropdown.value = "";
    }
}

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('homeTeam').addEventListener('change', function () {
        filterTeams('homeTeam', 'awayTeam');
    });
    document.getElementById('awayTeam').addEventListener('change', function () {
        filterTeams('awayTeam', 'homeTeam');
    });
    filterTeams('homeTeam', 'awayTeam');
    filterTeams('awayTeam', 'homeTeam');
});