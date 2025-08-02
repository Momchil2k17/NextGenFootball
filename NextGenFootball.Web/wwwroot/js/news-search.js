let currentPage = 1;
let pageSize = 9;

function renderNews(newsList) {
    if (newsList.length === 0) {
        $('#news-results').html('<div class="alert alert-info">No news available.</div>');
        return;
    }
    let html = '<div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">';
    for (const news of newsList) {
        html += `<div class="col">
            <div class="card h-100 shadow-sm">
                ${news.imageUrl ? `<img src="${news.imageUrl}" class="card-img-top" alt="${news.title}" style="object-fit:cover; max-height:180px;">` : ""}
                <div class="card-body d-flex flex-column">
                    <h5 class="card-title">${news.title}</h5>
                    <p class="card-text text-muted">${formatDate(news.publishedOn)} by ${news.author}</p>
                    <p class="card-text flex-grow-1">${truncate(news.content, 140)}</p>
                    <a href="/News/Details/${news.id}" class="btn btn-primary mt-auto">Read More</a>
                </div>
            </div>
        </div>`;
    }
    html += '</div>';
    $('#news-results').html(html);
}

function renderPagination(current, total) {
    if (total <= 1) {
        $('#news-pagination').html('');
        return;
    }

    let delta = 2;
    let range = [];
    let rangeWithDots = [];
    let l;

    // Always show first, last, and +/-delta around current
    for (let i = 1; i <= total; i++) {
        if (i === 1 || i === total || (i >= current - delta && i <= current + delta)) {
            range.push(i);
        }
    }
    for (let i of range) {
        if (l) {
            if (i - l === 2) {
                rangeWithDots.push(l + 1);
            } else if (i - l > 2) {
                rangeWithDots.push('...');
            }
        }
        rangeWithDots.push(i);
        l = i;
    }

    let html = '<ul class="pagination justify-content-center">';

    // Previous button
    html += `<li class="page-item${current === 1 ? ' disabled' : ''}">
        <a class="page-link" href="#" aria-label="Previous" onclick="if(${current}>1)loadNews(${current - 1}); return false;">&lt;</a>
    </li>`;

    // Page numbers and dots
    for (let i of rangeWithDots) {
        if (i === '...') {
            html += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
        } else {
            html += `<li class="page-item${i === current ? ' active' : ''}">
                <a class="page-link" href="#" onclick="loadNews(${i}); return false;">${i}</a>
            </li>`;
        }
    }

    // Next button
    html += `<li class="page-item${current === total ? ' disabled' : ''}">
        <a class="page-link" href="#" aria-label="Next" onclick="if(${current}<${total})loadNews(${current + 1}); return false;">&gt;</a>
    </li>`;

    html += '</ul>';
    $('#news-pagination').html(html);
}

function formatDate(dateStr) {
    const date = new Date(dateStr);
    return date.toLocaleDateString("en-GB", { day: '2-digit', month: 'short', year: 'numeric' });
}

function truncate(text, maxLen) {
    return text.length > maxLen ? text.substring(0, maxLen) + '...' : text;
}

function loadNews(page = 1) {
    currentPage = page;
    const searchTerm = $('#news-search-box').val();

    $('#news-loader').show();
    $('#news-results').addClass('loading-results');

    const startTime = Date.now();

    $.get('/News/Search', { searchTerm: searchTerm, page: page, pageSize: pageSize }, function (data) {
        const elapsed = Date.now() - startTime;
        const minDuration = 300; 

        function finishLoading() {
            renderNews(data.items);
            renderPagination(data.currentPage, data.totalPages);
            $('#news-loader').hide();
            $('#news-results').removeClass('loading-results');
            $('#news-results').show();
        }

        if (elapsed < minDuration) {
            setTimeout(finishLoading, minDuration - elapsed);
        } else {
            finishLoading();
        }
    });
}

$(document).ready(function () {
    loadNews();

    $('#news-search-box').on('input', function () {
        loadNews(1);
    });
});