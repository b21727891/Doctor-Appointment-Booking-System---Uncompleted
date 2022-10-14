$(document).ready(function () {
    $('#calendar').fullCalendar({
        header:
        {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonText: {
            today: 'today',
            month: 'month',
            week: 'week',
            day: 'day'
        },

        events: function (start, end, timezone, callback) {
            $.ajax({
                url: '/Home/GetCalendarData',
                type: "GET",
                dataType: "JSON",

                success: function (result) {
                    var events = [];
                    console.log(result);
                    $.each(result, function (i, datas) {
                        console.log(datas);
                        console.log(datas.Complaint);
                        console.log(datas.DoctorName);
                        console.log(datas.UserName);
                        console.log(datas.StartDate);
                        console.log(datas.EndDate);
                        console.log(moment(datas.StartDate).format('YYYY-MM-DD'));
                        console.log(moment(datas.EndDate).format('YYYY-MM-DD'));
                        events.push(
                            {
                                complaint: datas.Complaint,
                                doctor: datas.DoctorName,
                                user: datas.UserName,
                                start: moment(datas.StartDate).format('YYYY-MM-DD'),
                                end: moment(datas.EndDate).format('YYYY-MM-DD'),
                                backgroundColor: "#9501fc",
                                borderColor: "#fc0101"
                            });
                    });

                    callback(events);
                }
            });
        },

        eventRender: function (event, element) {
            element.qtip(
                {
                    content: event.description
                });
        },

        editable: false
    });
});