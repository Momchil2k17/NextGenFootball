window.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('referee-calendar');
    if (calendarEl) {
        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            headerToolbar: {
                left: 'prev,next',
                center: 'title',
                right: 'today' // today button on the right
            },
            height: 600,
            events: [
                // Demo event
                { title: 'Match vs City', start: new Date().toISOString().slice(0, 10), color: '#198754' }
            ],
            selectable: true,
            select: function (info) {
                alert('Selected date: ' + info.startStr);
            }
        });
        calendar.render();
    }
});