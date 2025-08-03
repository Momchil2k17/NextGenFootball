$(function () {
    const $input = $('#mainSearchBar');
    const $dropdown = $('#searchResultsDropdown');

    // Hide dropdown
    function hideDropdown() {
        $dropdown.hide();
        $dropdown.empty();
    }

    // Render results
    function renderAutocompleteResults(results) {
        $dropdown.empty();
        if (!results || results.length === 0) {
            hideDropdown();
            return;
        }
        results.forEach(item => {
            let imgTag = `<img src="${item.imageUrl}" alt="" class="rounded me-2" style="width:32px;height:32px;object-fit:cover;">`;
            $dropdown.append(
                `<a href="${item.url}" class="list-group-item list-group-item-action d-flex align-items-center" style="font-size:1.05rem;">
                    ${imgTag}
                    <span>${item.name}</span>
                </a>`
            );
        });
        $dropdown.show();
    }

    // Fetch autocomplete data
    $input.on('input', function () {
        const query = $(this).val();
        if (!query || query.length < 2) {
            hideDropdown();
            return;
        }
        $.getJSON('/Search/Autocomplete', { q: query }, function (results) {
            renderAutocompleteResults(results);
        });
    });

    // Keyboard navigation and blur
    $input.on('blur', function () {
        setTimeout(hideDropdown, 200);
    });

    // Optional: handle clicking on a dropdown item to navigate
    $dropdown.on('mousedown', 'a', function (e) {
        window.location.href = $(this).attr('href');
    });

    // Optional: position dropdown (already handled with position-absolute in layout)
});