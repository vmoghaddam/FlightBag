'use strict';
app.controller('calendarController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window) {

    $scope.isCalVisible = false;
    $scope.isfullScreen = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;
    $scope.caption = "";
    $scope.date = new Date();
    $scope.month = null;
    $scope.year = null;
    $scope.calendar = [];
    //alert($scope.month + '   ' + $scope.year);
    $scope.build = function (_date) {
        $scope.calendar = [];
        try {
            var today = moment(new Date()).format('YYYY-MM-DD');
            $('.day-wrapper').html('');
            $('.day-wrapper').hide();
            $scope.date = new Date(_date);
            $scope.month = $scope.date.getMonth();
            $scope.year = $scope.date.getFullYear();
            $scope.caption = General.GMonthDataSource[$scope.month].Title + ' ' + $scope.year;
            var day = new Date($scope.year, $scope.month, 1);
            var lastDay = (new Date($scope.year, $scope.month + 1, 0)).getDate();
            var dayWeek = day.getDay();
            var dayIndex = dayWeek;
            var dayMonth = day.getDate();

            var c = dayIndex - 1;
            var inactiveBack = (new Date($scope.year, $scope.month, 0)).getDate();
            var inactiveBackYear = (new Date($scope.year, $scope.month, 0)).getFullYear();
            var inactiveBackMonth = (new Date($scope.year, $scope.month, 0)).getMonth();
            var inactiveForward = (new Date($scope.year, $scope.month + 1, 1)).getDate();
            var inactiveForwardYear = (new Date($scope.year, $scope.month + 1, 1)).getFullYear();
            var inactiveForwardMonth = (new Date($scope.year, $scope.month + 1, 1)).getMonth();

            while (c >= 0) {
                var data_date = inactiveBackYear + '-' + pad(Number(inactiveBackMonth) + 1) + '-' + pad(Number(inactiveBack));
                var isToday = data_date == today ? ' today' : '';
                var html = "<div class='day-wrapper" + isToday + "' data-date='" + data_date + "'>"
                    + "<div class='day-caption inactive'>" + inactiveBack + "</div>"
                    + "</div>";
                $('#d' + c).html(html);
                $scope.calendar.push({ cell: 'd' + c, date: data_date });
                inactiveBack--;
                c--;
            }

            while (dayMonth <= lastDay) {

                var data_date = $scope.year + '-' + pad(Number($scope.month) + 1) + '-' + pad(Number(dayMonth));
                var isToday = data_date == today ? ' today' : '';

                var html = "<div class='day-wrapper" + isToday + "' data-date='" + data_date + "'>"
                    + "<div class='day-caption'>" + dayMonth + "</div>"
                    //+ "<div class='event flight'><i class='fas fa-plane'></i><span>4<span></div>"
                    //+ "<div class='event office'><span>OFFICE<span></div>"
                    + "</div>";
                //if (dayMonth == 12)
                //    html = "<div class='day-wrapper'>"
                //        + "<div class='day-caption'>" + dayMonth + "</div>"
                //        + "<div class='event flight'><i class='fas fa-plane'></i><span>4<span></div>"
                //        + "<div class='event office'><span>OFFICE<span></div>"
                //        + "</div>";
                $scope.calendar.push({ cell: 'd' + dayIndex, date: data_date });
                $('#d' + dayIndex).html(html);

                dayMonth++;
                dayIndex++;
            }

            while (dayIndex <= 41) {
                var data_date = inactiveForwardYear + '-' + pad(Number(inactiveForwardMonth) + 1) + '-' + pad(Number(inactiveForward));
                var isToday = data_date == today ? ' today' : '';
                var html = "<div class='day-wrapper" + isToday + "' data-date='" + data_date + "'>"
                    + "<div class='day-caption inactive'>" + inactiveForward + "</div>"
                    + "</div>";
                $('#d' + dayIndex).html(html);
                $scope.calendar.push({ cell: 'd' + dayIndex, date: data_date });
                dayIndex++;
                inactiveForward++;
            }
            $scope.isCalVisible = true;
            $('.day-wrapper').show();
            
            $scope.fill();

        }
        catch (e) { alert(e); }



    };
    $scope.events = [
        { date: new Date(), type: 1165, legs: 4 },
        { date: (new Date()).addDays(-6), type: 1164, },
    ];

    $scope.fill = function () {
        var _min = (new Date(Enumerable.From($scope.calendar).Where('$.cell=="d0"').FirstOrDefault().date)).setHours(0, 0, 0);
        var min = moment(_min).format('YYYY-MM-DDTHH:mm:ss');
       
        var _max = (new Date(Enumerable.From($scope.calendar).Where('$.cell=="d41"').FirstOrDefault().date)).setHours(0, 0, 0);
        var max = moment(_max).format('YYYY-MM-DDTHH:mm:ss');
      //  alert(min);
      //  alert(max);
        $scope.loadingVisible = true;
        flightService.epGetCrewCalendar($rootScope.employeeId, /*$scope.year, $scope.month + 1*/min,max).then(function (response) {
            console.log('calendar', response.Data);
            $scope.loadingVisible = false;
            if (response.IsSuccess)
                $.each(response.Data, function (_i, _d) {
                    var element = '<div class="event"></div>';
                    switch (_d.DutyType) {
                        case 1165:
                            element = "<div class='event d" + _d.DutyType+"'><i class='fas fa-plane'></i><span>" + _d.Legs + "<span></div>";
                            break;
                        case 10000:
                            element = "<div class='event d" + _d.DutyType +"'><span>OFF<span></div>";
                            break;
                        default:

                            break;
                    };
                    var cell = Enumerable.From($scope.calendar).Where(function (x) { return x.date == moment(_d.Date).format('YYYY-MM-DD'); }).FirstOrDefault();
                    if (cell) {
                        $('#' + cell.cell).find('.day-wrapper').append(element);
                    }
                });

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
        //$.each($scope.events, function (_i, _d) {

        //    var element = '<div class="event"></div>';
        //    switch (_d.type) {
        //        case 1165:
        //            element = "<div class='event flight'><i class='fas fa-plane'></i><span>"+_d.legs+"<span></div>";
        //            break;
        //        case 1164:
        //            element = "<div class='event office'><span>OFFICE<span></div>";
        //            break;
        //        default:

        //            break;
        //    };
        //    var cell = Enumerable.From($scope.calendar).Where(function (x) { return x.date == moment(_d.date).format('YYYY-MM-DD'); }).FirstOrDefault();
        //    if (cell) {
        //        $('#' + cell.cell).find('.day-wrapper').append(element);
        //    }


        //});
    };

    $scope.nextMonth = function (n) {
        $scope.date = $scope.date.addMonths(n);
        $scope.build($scope.date);
    };

    $scope.click = function (date) {
        $rootScope.$broadcast('onCalendarSelected', new Date(date));
    };

    ////////////////////////
    $scope.loadingVisible = false;
    $scope.loadPanel = {
        message: 'Please wait...',

        showIndicator: true,
        showPane: true,
        shading: true,
        closeOnOutsideClick: false,
        shadingColor: "rgba(0,0,0,0.4)",
        // position: { of: "body" },
        onShown: function () {

        },
        onHidden: function () {

        },
        bindingOptions: {
            visible: 'loadingVisible'
        }
    };
    ///////////////////////// 
    $scope.popup_add_visible = false;
    $scope.popup_add_title = 'New';
    $scope.popup_instance = null;
    $scope.popup_width = 600;
    $scope.popup_height = 630;
    $scope.dto = null;
    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

            {
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Today', icon: 'fas fa-calendar-day', onClick: function (e) {
                        $scope.build(new Date());
                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'danger', text: 'Close', icon: 'remove', onClick: function (e) {
                        $scope.popup_add_visible = false;
                    }
                }, toolbar: 'bottom'
            }
        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {
            $scope.popup_instance.repaint();


        },
        onShown: function (e) {
            $('._cal').on('click', '.day-wrapper', function (event) {
                $scope.click($(this).data('date'));
            });

            $scope.build($scope.initDate);

            if ($scope.isFullScreen)

                $scope.scrollStyle = { height: ($(window).height() - 230).toString() + 'px' };
            else
                $scope.scrollStyle = { height: ($scope.popup_height - 190).toString() + 'px' };




        },
        onHiding: function () {

            //$scope.clearEntity();
            // $(".day-wrapper").off("click");
            $('._cal').off('click', '.day-wrapper');
            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onCalendarHide', null);
        },
        onContentReady: function (e) {
            if (!$scope.popup_instance)
                $scope.popup_instance = e.component;

        },
        bindingOptions: {
            visible: 'popup_add_visible',
            fullScreen: 'isfullScreen',
            // title: 'popup_add_title',
            height: 'popup_height',
            width: 'popup_width'

        }
    };
    ///////////////////////////


    $scope.$on('InitCalendar', function (event, prms) {

        //new Date(2021, 3, 1)
        $scope.initDate = new Date();
        if (prms.initDate)
            $scope.initDate = new Date(prms.initDate);
        $scope.popup_add_visible = true;

    });
    //////////////////////////////

}]);  
