'use strict';
app.controller('epLogBookController', ['$scope', '$location', '$routeParams', '$rootScope', 'flightService', 'authService', 'notificationService', '$route', '$window', '$q','$http', function ($scope, $location, $routeParams, $rootScope, flightService, authService, notificationService, $route, $window, $q,$http) {

    // var m1=moment().format();     // 2013-02-04T10:35:24-08:00
    // var m2 = moment.utc().format(); // 2013-02-04T18:35:24+00:00
    // console.log(m1);
    // console.log(m2);

     $http.get('https://localhost:5001/Upload/Weather/SIGWX/ADDS/SIGWX_ADDS_20210819_2105.png').then(function (response) { console.log('image get'); });

    $scope.image = {
        src: 'https://www.aerotime.aero/upload/files/1250x420/1200px-Ba_b747-400_g-bnle_arp_crop.jpg',
        position: {
            x: -137.5,
            y: -68
        },
        scaling: 2,
        maxScaling: 5,
        scaleStep: 0.11,
        mwScaleStep: 0.09,
        moveStep: 99,
        fitOnload: true,
        showIndicator: true,
        progress: 0
    };
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
   // $scope.dt_from = new Date(2021, 7, 11);
   // $scope.dt_to = new Date(2021, 7, 11);
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


     
    $scope.btn_asr = {
        text: 'ASR',
        type: 'default',
        //icon: 'search',
        width: '100%', //37,

        onClick: function (e) {

         //   var data = { Id: $scope.selectedFlight.FlightId, crewId: $scope.selectedFlight.CrewId };
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId };

            $rootScope.$broadcast('InitAsrAdd', data);

        },
        bindingOptions: {
            disabled: 'IsLegLocked'
        }
    };
    $scope.btn_vr = {
        text: 'Voyage Report',
        type: 'default',
        //icon: 'search',
        width: '100%', //37,

        onClick: function (e) {
            //if (!$rootScope.getOnlineStatus()) {
            //    alert('You are OFFLINE.Please check your internet connection.');
            //    return;
            //}
            var data = { FlightId: $scope.selectedFlight.FlightId  };

            $rootScope.$broadcast('InitVrAdd', data);

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
        
       // var data = { url: 'document.pdf' };

       // $rootScope.$broadcast('InitPdfViewer', data);
       var data = { url: 'document.pdf' };

       $rootScope.$broadcast('InitImageViewer', data);
        return;
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




        //flightService.getMETARs(item.FDPId).then(function (response) {

        //    console.log('TAFS', response);


        //}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


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

        $scope.dto.AttRepositioning1 = $scope.syncedFlight.AttRepositioning1;
        $scope.dto.AttRepositioning1 = $scope.syncedFlight.AttRepositioning1;


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
            alert('You are OFFLINE.Please check your internet connection.'); 
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
    $scope.getInfoClass = function (g, obj) {
        return g[obj] && g[obj].length>0? "hasInfo" : '';
    };
    $scope.formatDateTime = function (dt) {
        return moment(dt).format('YYYY-MM-DD HH:mm');
    };
    //$scope._getTAF = async function (_g) {
    //    var deferred = $q.defer();
    //    flightService.getTAFs(_g.FDPId).then(function (_taf) {

    //       // if (_taf.IsSuccess)
    //       //     _g.TAF = _taf.Data;
    //        deferred.resolve(_taf);
    //    }, function (err) { deferred.reject({ IsSuccess:false }); });
    //    return deferred.promise;

    //};
    //$scope.getTAF = function (_g) {
    //    return $scope._getTAF(_g);
    //};
    var _tafcnt = 0;
    function _getTAF(_g,grps) {
        _g.tafLoading = true;
        
        flightService.getTAFs(_g.FDPId, _g.doInfo).then(function (_taf) {
            
            _g.tafLoading = false;
            _tafcnt++;
            if (_taf.IsSuccess) { _g.TAF = _taf.Data;   }
           
            if (_tafcnt < grps.length) { _getTAF(grps[_tafcnt], grps); }
            else {
                _metarcnt = 0;
                _getMETAR(grps[0], grps);
            }
        }, function (err) {  });
        
    }

    var _metarcnt = 0;
    function _getMETAR(_g, grps) {
        _g.metarLoading = true;
        flightService.getMETARs(_g.FDPId, _g.doInfo).then(function (_taf) {
            _g.metarLoading = false;
            _metarcnt++;
            if (_taf.IsSuccess)
                _g.METAR = _taf.Data;

            if (_metarcnt < grps.length) { _getMETAR(grps[_metarcnt], grps); }
            else {
                _notamcnt = 0;
                _getNOTAM(grps[0], grps);
            }
        }, function (err) { });

    }

    var _notamcnt = 0;
    function _getNOTAM(_g, grps) {
        _g.notamLoading = true;
        flightService.getNOTAMs(_g.FDPId, _g.doInfo).then(function (_taf) {
           
            _g.notamLoading = false;
            _notamcnt++;
            if (_taf.IsSuccess)
                _g.NOTAM = _taf.Data;

            if (_notamcnt < grps.length) { _getNOTAM(grps[_notamcnt], grps); }
            
        }, function (err) { });

    }

    
     

     
    $scope.getTAF = function (_g,callback) {
        //var _g = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + fdpId).FirstOrDefault();
        if (_g) {
            _g.tafLoading = true;
            flightService.getTAFs(_g.FDPId, _g.doInfo).then(function (_taf) {
                _g.tafLoading = false;
               
                if (_taf.IsSuccess) { _g.TAF = _taf.Data; }
                else
                    _g.TAF = null;
                callback();
                 
            }, function (err) { });
        }
        else
            callback();
       
    };
    $scope.getMETAR = function (_g,callback) {
        //var _g = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + fdpId).FirstOrDefault();
        if (_g) {
            _g.metarLoading = true;
            flightService.getMETARs(_g.FDPId, _g.doInfo).then(function (_taf) {
                _g.metarLoading = false;

                if (_taf.IsSuccess) { _g.METAR = _taf.Data; }
                else
                    _g.METAR = null;
                callback();

            }, function (err) { });
        }
        else
            callback();
    };
    $scope.getNOTAM = function (_g,callback) {
        //var _g = Enumerable.From($scope.groupedFlights).Where('$.FDPId==' + fdpId).FirstOrDefault();
        if (_g) {
            _g.notamLoading = true;
            flightService.getNOTAMs(_g.FDPId, _g.doInfo).then(function (_taf) {
                _g.notamLoading = false;

                if (_taf.IsSuccess) { _g.NOTAM = _taf.Data; }
                else
                    _g.NOTAM = null;
                callback();

            }, function (err) { });
        }
        else
            callback();
    };

    $scope.showTAF = function (g) {
        
        $rootScope.$broadcast('InitTAF', g);
    };
    $scope.showMETAR = function (g) {
        $rootScope.$broadcast('InitMETAR', g);
    };
    $scope.showNOTAM = function (g) {
        $rootScope.$broadcast('InitNOTAM', g);
    };
    $scope.infoClick = function (id, type,obj) {
        switch (type) {
            case 'TAF':
                if (obj[type] && obj[type].length > 0) {
                    $scope.showTAF(obj);
                }
                else {
                    obj.doInfo = 1;
                    $scope.getTAF(obj, function () { obj.doInfo = 0; $scope.showTAF(obj); });
                }
                break;
            case 'METAR':
                if (obj[type] && obj[type].length > 0) {
                    $scope.showMETAR(obj);
                }
                else {
                    obj.doInfo = 1;
                    $scope.getMETAR(obj, function () { obj.doInfo = 0; $scope.showMETAR(obj);});
                }
                break;
            case 'NOTAM':
                if (obj[type] && obj[type].length > 0) {
                    $scope.showNOTAM(obj);
                }
                else {
                    obj.doInfo = 1;
                    $scope.getNOTAM(obj, function () { obj.doInfo = 0; $scope.showNOTAM(obj);});
                }
                break;
            default:
                break;
        }
    };
    $scope.bindInfo = function (grps) {
        
        var _grps = [];
        $.each(grps, function (_i, _g) {
            if (_g.DutyType == 1165) {
                var isScheduled = Enumerable.From(_g.items).Where(function (x) {
                    return x.FlightStatusId == 1;
                }).FirstOrDefault();
                var today = moment((new Date())).format('YYYYMMDD');
                var lastSTA = moment(new Date(_g.items[_g.items.length - 1].STADayLocal)).format('YYYYMMDD');
                var firstSTD = moment(new Date(_g.items[0].STADayLocal)).format('YYYYMMDD');
                if (isScheduled && (Number(lastSTA) == Number(today) || Number(firstSTD) == Number(today))) {
                    _g.doInfo = 1;
                    _grps.push(_g);
                }
                else {
                    _g.doInfo = 0;
                    _grps.push(_g);
                }
            }
            
        });
        
        _tafcnt = 0;
        _getTAF(_grps[0], _grps);
        
    };
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

                        .GroupBy(function (item) { return item.FDPId + '_' + item.DutyTypeTitle + '_' + item.DutyType; }, null, (key, g) => {
                            var _item = {
                                FDPId: Number(key.split('_')[0]),
                                DutyTypeTitle: key.split('_')[1],
                                DutyType: Number(key.split('_')[2]),
                                METAR: null,
                                TAF: null,
                                NOTAM: null,
                                tafLoading: false,
                                metarLoading: false,
                                notamLoading: false,
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
                        $scope.bindInfo($scope.groupedFlights);
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
    $scope.$on('onFlightLocgSaved', function (evt, data) {

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
        var date = new Date(_d.getFullYear(), _d.getMonth(), _d.getDate());
        $scope.dt_from = date;
        $scope.dt_to = date;

        $scope.bind();
    });

}]);