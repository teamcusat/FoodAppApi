// Handles Timelisting based on user timezone for blurb scheduling

function RenderTimeOptions() {
    Date.prototype.goToMidNight = function() {
        this.setHours(0);
        this.setMinutes(0);
        this.setMilliseconds(0);
        this.setSeconds(0);
    };

    var now = new Date();

    $.ajax({
        url: '/Account/UserCurrentTime',
        type: 'GET',
        datatype: 'json',
        cache: false,
        async: false,
        success: function(result) {
            now = new Date(result.userdatetime);           
        },
        error: function(result) {
            now = new Date();
            console.log(result.responseText);
        }
    });

    var slotList = [
        ['POST NOW', 0],
        ['UNSCHEDULE', -1],
        ['POST TODAY AT', -2]
    ];
    var appendHours = 1;
    var hour = now.getHours();
    if (now.getMinutes() > 55)
        appendHours++;
    hour = hour + appendHours;
    tempDate = new Date();
    tempDate.goToMidNight();
    var noOfSlots = 23 - hour; //avoid 12:00 AM   


    for (var counter = 0; counter <= noOfSlots; counter++) {
        tempDate.setHours(hour);
        var temp = ['TEMP', 0];
        temp[0] = getDisplayTime(tempDate);
        temp[1] = getDisplayTime(tempDate);
        // temp[1] = tempDate.getTime();
        hour++;
        slotList.push(temp);
    }
    var a = $('.blurbpublishlist');

    $('.blurbpublishlist').each(function() {
        if (!$(this).data('optionGenerated')) {
            var buttonElement = $('#' + $(this).attr('blurbid')+ $(this).attr('provider') + 'Button');
            var flag = 0;
            buttonElement.children('.label').each(function() {
                var newDisp = new Date($(this).html());
                if ((newDisp.getHours() >= 0) && (newDisp.getHours() <= 24)) {
                    var display = getDisplayTime(newDisp);
                    $(this).html(display);
                    flag = 1;
                } else {
                    $(this).hide();
                }
            });
            for (var index = 0; index < slotList.length; index++) {

                var listElement = $('<li/>');
                if (index != 2) {
                    var linkElement = $('<a/>');
                    linkElement.html(slotList[index][0]);
                    listElement.append(linkElement);
                    listElement.data('epochTime', slotList[index][1]);
                    listElement.data('blurbId', $(this).attr('blurbid'));
                    listElement.data('enterpriseBlurbId', $(this).attr('enterpriseBlurbId'));
                    listElement.data('providerName', $(this).attr('provider'));
                    if (index != 2)
                        listElement.click(function() {
                            Publish($(this).data('blurbId'), $(this).data('enterpriseBlurbId'), $(this).data('providerName'), $(this).data('epochTime'));
                        });
                } else if (index == 2 && slotList.length > 3) {
                    listElement.html(slotList[index][0]).addClass("label-align text-center");
                }

                $(this).append(listElement);
                if (index == 0) {
                    var divider = $('<li/>', {
                        'class': 'divider'
                    });
                    $(this).append(divider);
                }

                if (slotList[index][1] == -1) {
                    listElement.addClass('removeSchedule');
                    var divider = $('<li/>', {
                        'class': 'divider removeSchedule'
                    });
                    $(this).append(divider);
                    if (flag == 0) {
                        listElement.hide();
                        divider.hide();
                    }
                }
            }
            $(this).data('optionGenerated', true);
        }
    });
    
};

function getDisplayTime(time) {
    var hour = time.getHours();
    var temp = "";
    if (hour > 12) {
        temp = (hour - 12) + ':00 PM';
    } else if (hour == 12) {
        temp = (hour) + ':00 PM';
    } else {
        temp = (hour) + ':00 AM';
    }

    return temp;
}