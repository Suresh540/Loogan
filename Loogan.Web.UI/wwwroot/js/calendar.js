function fnCalendarLoad(schedules) {
    var calendarEl = document.getElementById('calendar');
    var events = [];
    let iDate = new Date();
    if (schedules != null && schedules.length > 0) {
        iDate = new Date(schedules[0].courseStartDate);
        for (var item of schedules) {
            let sDate = new Date(item.courseStartDate);
            let eDate = new Date(item.courseCompletedDate);
            events.push({
                title: item.courseName,
                start: sDate,
                end: eDate
            });
        }
    }
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridYear,dayGridMonth,timeGridWeek'
        },
        initialView: 'dayGridYear',
        initialDate: iDate,
        editable: true,
        selectable: true,
        dayMaxEvents: true, // allow "more" link when too many events
        // businessHours: true,
        // weekends: false,
        events: events
    });
    calendar.render();
}