'use strict';
app.controller('epLogBookController', ['$scope', '$location', '$routeParams', '$rootScope', 'flightService', 'authService', 'notificationService', '$route', '$window', function ($scope, $location, $routeParams, $rootScope, flightService, authService, notificationService, $route, $window) {

    // var m1=moment().format();     // 2013-02-04T10:35:24-08:00
    // var m2 = moment.utc().format(); // 2013-02-04T18:35:24+00:00
    // console.log(m1);
    // console.log(m2);
    
    if (!authService.isAuthorized()) {

        authService.redirectToLogin();
    }
    else {
        
    }
    $scope.prms = $routeParams.prms;

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
    $scope.btn_search = {
        //text: 'Filter',
        type: 'default',
        icon: 'search',
        width: '100%', //37,
        //height: 30,
        onClick: function (e) {
            //$scope.popup_filter_visible = true;
            $scope.bind();
        }
    };
    //$scope.dt_from = new Date(2021, 3, 6);
    //$scope.dt_to = new Date(2021, 3, 9);
    $scope.dt_from = (new Date());//.addDays(-2);
    $scope.dt_to = (new Date($scope.dt_from)).addDays(0);
    $scope.date_from = {
        displayFormat: "yy MMM dd",
        adaptivityEnabled: true,
        type: "date",
        pickerType: "rollers",
        useMaskBehavior: true,
        bindingOptions: {
            value: 'dt_from'
        }
    };
    $scope.date_to = {
        displayFormat: "yy MMM dd",
        adaptivityEnabled: true,
        type: "date",
        pickerType: "rollers",
        useMaskBehavior: true,
        bindingOptions: {
            value: 'dt_to'
        }
    };
    $scope.IsLegLocked = false;
    $scope.btn_jlog = {
        text: 'Log',
        type: 'default',
        //icon: 'search',
        width: '100%', //37,

        onClick: function (e) {

            var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId };

            $rootScope.$broadcast('InitLogAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.leftHeight = $(window).height() - 135;
    $scope.scroll_left = {
        width: '100%',
        bounceEnabled: false,
        showScrollbar: 'never',
        pulledDownText: '',
        pullingDownText: '',
        useNative: true,
        refreshingText: 'Updating...',
        onPullDown: function (options) {

            options.component.release();

        },
        onInitialized: function (e) {


        },
        bindingOptions: {
            height: 'leftHeight'
        }

    };
    $scope.rightHeight = $(window).height() - 135 - 45;
    $scope.scroll_right = {
        width: '100%',
        bounceEnabled: false,
        showScrollbar: 'never',
        pulledDownText: '',
        pullingDownText: '',
        useNative: true,
        refreshingText: 'Updating...',
        onPullDown: function (options) {

            options.component.release();

        },
        onInitialized: function (e) {


        },
        bindingOptions: {
            height: 'rightHeight'
        }

    };
    $scope.clickDate = function (n) {
        var dt1 = new Date();
        var dt2 = (new Date()).addDays(n);
        $scope.dt_from = dt2;
        $scope.dt_to = dt1;
        $scope.bind();
    };
    $scope.clickDay = function (n) {
        var dt = (new Date()).addDays(n);
        $scope.dt_from = dt;
        $scope.dt_to = dt;
        $scope.bind();
    };
    $scope.clickCalendar = function () {
        var data = { initDate: $scope.dt_from };

        $rootScope.$broadcast('InitCalendar', data);
    };
    $scope.selectedFlight = null;
    $scope.showFlight = function (item, n, $event) {
        $scope.selectedFlight = item;
        
        if (item.DutyType == 1165)
            $scope.bindCrews($scope.selectedFlight.FlightId);

        //if (!detector.tablet()) {
        //    $scope.flight = item;
        //    $scope.popup_flight_visible = true;
        //}
        //else {
        //    if (n == 0) {
        //        $('.today-tile').removeClass('selected');
        //        $scope.flightToday = item;
        //    }
        //    if (n == 1) {
        //        $('.tomorrow-tile').removeClass('selected');
        //        $scope.flightTomorrow = item;
        //    }
        //    if (n == 2) {
        //        $('.day-tile').removeClass('selected');
        //        $scope.flightDay = item;
        //    }
        //    var tile = $($event.currentTarget);
        //    tile.addClass('selected');

        //    $scope.getCrewAbs(item.FlightId, n);
        //}
    };
    ///////////////////////////
    $scope.overwriteLocal = function () {
        $scope.loadingVisible = true;
        flightService.epSyncFlight($scope.checkResult).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);

            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.overwriteServer = function () {
        console.log('overwriteServer', $scope.syncedFlight);
        $scope.dto = { Server: true };
        $scope.dto.FlightId = $scope.syncedFlight.FlightId;
        $scope.dto.CrewId = $scope.syncedFlight.CrewId;
        $scope.dto.DelayBlockOff = null;
        $scope.dto.BlockTime = null;
        $scope.dto.FlightTime = null;
        if ($scope.syncedFlight.BlockOff)
            $scope.dto.BlockOffDate = momentFromatFroServerUTC($scope.syncedFlight.BlockOff);
        if ($scope.syncedFlight.BlockOn)
            $scope.dto.BlockOnDate = momentFromatFroServerUTC($scope.syncedFlight.BlockOn);
        if ($scope.syncedFlight.TakeOff)
            $scope.dto.TakeOffDate = momentFromatFroServerUTC($scope.syncedFlight.TakeOff);
        if ($scope.syncedFlight.Landing)
            $scope.dto.LandingDate = momentFromatFroServerUTC($scope.syncedFlight.Landing);

        $scope.dto.FuelRemaining = $scope.syncedFlight.FuelRemaining;
        $scope.dto.FuelUplift = $scope.syncedFlight.FuelUplift;
        $scope.dto.FuelUsed = $scope.syncedFlight.FuelUsed;
        $scope.dto.FuelDensity = $scope.syncedFlight.FuelDensity;
        $scope.dto.FuelTotal = $scope.syncedFlight.FuelTotal;
        ////////////
        $scope.dto.PaxAdult = $scope.syncedFlight.PaxAdult;
        $scope.dto.PaxChild = $scope.syncedFlight.PaxChild;
        $scope.dto.PaxInfant = $scope.syncedFlight.PaxInfant;
        $scope.dto.PaxTotal = $scope.syncedFlight.PaxTotal;

        $scope.dto.BaggageWeight = $scope.syncedFlight.BaggageWeight;
        $scope.dto.CargoWeight = $scope.syncedFlight.CargoWeight;

        $scope.dto.SerialNo = $scope.syncedFlight.SerialNo;
        $scope.dto.LTR = $scope.syncedFlight.LTR;
        $scope.dto.PF = $scope.syncedFlight.PF;

        $scope.dto.RVSM_GND_CPT = $scope.syncedFlight.RVSM_GND_CPT;
        $scope.dto.RVSM_GND_STBY = $scope.syncedFlight.RVSM_GND_STBY;
        $scope.dto.RVSM_GND_FO = $scope.syncedFlight.RVSM_GND_FO;

        $scope.dto.RVSM_FLT_CPT = $scope.syncedFlight.RVSM_FLT_CPT;
        $scope.dto.RVSM_FLT_STBY = $scope.syncedFlight.RVSM_FLT_STBY;
        $scope.dto.RVSM_FLT_FO = $scope.syncedFlight.RVSM_FLT_FO;

        $scope.dto.CommanderNote = $scope.syncedFlight.CommanderNote;


        ///////////////
        //sook
        $scope.dto.JLUserId = $scope.syncedFlight.CrewId;
        $scope.dto.JLDate = momentUtcNow();
        $scope.dto.Version = $scope.syncedFlight.Version;
        $scope.loadingVisible = true;
        flightService.epSaveLogOverwriteServer($scope.dto).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);

            }
            else {
                General.ShowNotify(response.Data, 'error');
            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.popup_check2_visible = false;
    $scope.popup_check2 = {
        height: 200,
        width: 400,
        title: 'Alert',
        showTitle: true,

        toolbarItems: [



            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update Server', onClick: function (e) {
                        $scope.overwriteServer();
                        $scope.popup_check2_visible = false;

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update Local', onClick: function (e) {

                        $scope.overwriteLocal();
                        $scope.popup_check2_visible = false;
                    }
                }, toolbar: 'bottom'
            },

        ],

        visible: false,
        dragEnabled: true,
        closeOnOutsideClick: false,
        onShowing: function (e) {

        },
        onShown: function (e) {

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_check2_visible = false;

        },
        onContentReady: function (e) {

        },
        bindingOptions: {
            visible: 'popup_check2_visible',


        }
    };
    ////////////////////////////
    $scope.syncedFlight = null;
    //doolmah
    $scope.syncFlight = function (item) {
        if (!$rootScope.getOnlineStatus()) {
            alert('offline');
            return;
        }
        var fid = item.FlightId;
        flightService.epGetFlightLocal(fid).then(function (response) {
            if (response.IsSuccess) {
                $scope.syncedFlight = response.Data;
                var dtoCheck = { JLDate: $scope.syncedFlight.JLDate, CrewId: $scope.syncedFlight.CrewId, FlightId: $scope.syncedFlight.FlightId };
                $scope.loadingVisible = true;
                flightService.epCheckLog(dtoCheck).then(function (response) {
                    $scope.loadingVisible = false;
                    $scope.checkResult = response.Data;

                    if (($scope.checkResult.JLUserId && $scope.checkResult.JLUserId != $scope.syncedFlight.JLUserId)
                        || ($scope.checkResult.JLUserId && getTimeForSync($scope.checkResult.JLDate) > getTimeForSync($scope.syncedFlight.JLDate))
                    ) {
                        $scope.checkResult.JLDate2 = moment($scope.checkResult.JLDate).format('YYYY-MMM-DD HH:mm');
                        $scope.popup_check2_visible = true;
                    }
                    else {
                        
                        $scope.overwriteServer();
                    }
                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

            }

        }, function (err) { });
    };
    $scope.getDutyType = function (flt) {
        if (!flt)
            return "";
        return flt.DutyTypeTitle;

    };
    $scope.getTimeDuration = function (x) {
        var str1 = $rootScope.getTimeHHMM2(x, 'DutyStart');
        var str2 = $rootScope.getTimeHHMM2(x, 'DutyEnd');
        if (str1 == str2 && str1 == '0000')
            return 'all-day';
        return str1 + ' - ' + str2;
    };
    $scope.flights = null;
    $scope.groupedFlights = null;
    $scope.bind = function (show) {
        if (!authService.isAuthorized())
            return;
        var _d1 = moment($scope.dt_from).format('YYYY-MM-DDTHH:mm:ss');

        var _d2 = moment($scope.dt_to).format('YYYY-MM-DDTHH:mm:ss');
        $scope.loadingVisible = true;
        flightService.epGetCrewFlights(_d1, _d2).then(function (response) {
            console.log('epGetCrewFlightsXXXX', response.Data);
            $scope.loadingVisible = false;

            if (response.IsSuccess) {

                flightService.epGetCrewDuties(GlobalUserId, _d1, _d2).then(function (response2) {
                    if (response2.IsSuccess) {
                        console.log('data data', response2.Data);
                        $.each(response2.Data, function (_k, _dty) {
                            response.Data.push(_dty);
                        });
                        //response.Data = Enumerable.From(response.Data).OrderBy(function(x) { return DateTimeToNumber(x.IStart);}).ToArray(); 
                    }

                    $scope.flights = response.Data;
                    $scope.groupedFlights = Enumerable.From(response.Data)

                        .GroupBy(function (item) { return item.FDPId + '_' + item.DutyTypeTitle; }, null, (key, g) => {
                            var _item = {
                                FDPId: Number(key.split('_')[0]),
                                DutyTypeTitle: key.split('_')[1],
                                items: Enumerable.From(g.source).OrderBy(function (x) {
                                    return x.DutyType == 1165 ? DateTimeToNumber(new Date(x.STD)) : 1;
                                }).ToArray(),


                            };
                            _item.IStart = (_item.items[0].DutyType == 1165) ? _item.items[0].STD : _item.items[0].IStart;
                            return _item;
                        }).OrderBy(function (x) {
                            console.log('ordered', x.DutyTypeTitle + '   ' + DateTimeToNumber(x.IStart) + '   ' + x.IStart);
                            return DateTimeToNumber(x.IStart);

                        }).ToArray(); 
                    if ($scope.groupedFlights && $scope.groupedFlights.length > 0) {
                        // $.each($scope.groupedFlights, function (_i, _d) {
                        //     _d.IStart = (_d.items[0].DutyType == 1165) ? _d.items[0].STD : _d.items[0].IStart;
                        // });
                        // $scope.groupedFlights = Enumerable.From($scope.groupedFlights).OrderBy(function (x) { return DateTimeToNumber(x.IStart); }).ToArray();

                        $scope.showFlight($scope.groupedFlights[0].items[0]);
                    }
                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.selectedFlightCrews = [];
    $scope.bindCrews = function (flightId) {

        //$scope.loadingVisible = true;
        flightService.epGetFlightCrews(flightId).then(function (response) {
            //$scope.loadingVisible = false;
            console.log(response);
            if (response.IsSuccess) {
                $scope.selectedFlightCrews = response.Data;

            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };



    $scope.getFlightClass = function (flt) {
       // var prop = 'FlightId';
       // if (flt.DutyType != 1165)
        //    prop = 'Id';
        if (!$scope.selectedFlight || $scope.selectedFlight.Id != flt.Id)
            return "lib-flight main-bkcolor2-light-imp";
        else
            return "lib-flight main-bkcolor2-light-imp selected";
        //return flt.FlightStatus.toLowerCase();
    }
    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        //alert('w: '+$(window).width());

        $scope.$apply(function () {
            $scope.leftHeight = $(window).height() - 135;
            $scope.rightHeight = $(window).height() - 135 - 45;
        });
    });


    // $rootScope.$broadcast('AppLibraryLoaded', null);
    $rootScope.$broadcast('ActiveFooterItem', 'footerflightcalendar');
    $scope.$on('$viewContentLoaded', function () {

        $scope.bind();
    });
    $scope.$on('onFlightLocgSaved', function (evt,data) {

        // flightService.epGetFlightLocal(fid).then(function (response) {
        //    if (response.IsSuccess) {
        //        //var grp = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + response.Data.FDPId).FirstOrDefault();
        //        //if (grp) {
        //        //    var gf = Enumerable.From(grp.items).Where('$.FlightId==' + fid).FirstOrDefault();
        //        //    gf = response;
        //        //}
        //    }

        //}, function (err) {  });    });
        
        var grp = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + data.FDPId).FirstOrDefault();
        if (grp) {
            var gf = Enumerable.From(grp.items).Where('$.FlightId==' + data.FlightId).FirstOrDefault();
           // gf.FlightNumber = 'kir'; //JSON.parse(JSON.stringify( data));
            JSON.copy(data, gf);
            if ($scope.selectedFlight)
                $scope.showFlight($scope.selectedFlight);
        }
    });

    $scope.$on('onCalendarSelected', function (evt, data) {
        var _d = new Date(data);
        var date = new Date(_d.getFullYear(),_d.getMonth(),_d.getDate());
        $scope.dt_from =date;
        $scope.dt_to = date;
       
        $scope.bind();
    });

}]);