'use strict';
app.controller('jlController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window) {
    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = true;
    $scope.isEditable = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;

    ///////////////////////
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
    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_height = '100%';
    $scope.popup_width = '100%';
    $scope.popup_add_title = 'JOURNEY LOG';
    $scope.popup_instance = null;

    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [
             
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'dradd', onClick: function (e) {

                        

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
            $rootScope.IsRootSyncEnabled = false;
            $scope.popup_instance.repaint();


        },
        onShown: function (e) {

            if ($scope.isNew) {
                $scope.isContentVisible = true;
            }
            if ($scope.tempData != null)
                $scope.bind();





        },
        onHiding: function () {

            //$scope.clearEntity();
            $rootScope.IsRootSyncEnabled = true;
            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onJLHide', null);
        },
        onContentReady: function (e) {
            if (!$scope.popup_instance)
                $scope.popup_instance = e.component;

        },
        bindingOptions: {
            visible: 'popup_add_visible',
            fullScreen: 'isFullScreen',
            title: 'popup_add_title',
            height: 'popup_height',
            width: 'popup_width',
            

        }
    };



    /////////////////////////////////
    $scope.scroll_jl_height = '100%';
    $scope.scroll_jl = {
        width: '100%',
        direction:'both',
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
            height: 'scroll_jl_height'
        }

    };

    /////////////////////////
    $scope.formatTime = function (dt) {
        if (!dt) return "";
        return moment(new Date(dt)).format('HH:mm').toUpperCase();
    };
    $scope.formatMinutes = function (mm) {
        if (!mm)
            return "";
        return pad(Math.floor(mm / 60)).toString() + ':' + pad(mm % 60).toString();
    };
    $scope.fillRVSM = function (n, legs) {
        var obj = { leg: n };
        if (legs.length >= n) {
            var leg = legs[n - 1];
            obj.RVSM_GND_CPT = leg.RVSM_GND_CPT;
            obj.RVSM_GND_STBY = leg.RVSM_GND_STBY;
            obj.RVSM_GND_FO = leg.RVSM_GND_FO;
            obj.RVSM_FLT_CPT = leg.RVSM_FLT_CPT;
            obj.RVSM_FLT_STBY = leg.RVSM_FLT_STBY;
            obj.RVSM_FLT_FO = leg.RVSM_FLT_FO;
        }
        return obj;
    };
    $scope.jlObj = null;
    $scope.jl = { asr: false, vr: false, pos1: false, pos2: false, sign: '' };
    $scope.bind = function () {
        var fid = $scope.FlightId;
        $scope.jl = { asr: false, vr: false, pos1: false, pos2: false, sign: '' };
        //jl.ReportingTime
        $scope.jl.StartTime=
        $scope.loadingVisible = true;

        flightService.getJL(fid).then(function (response) {
            $scope.loadingVisible = false;
            //_d.BlockTime2 = $scope.formatMinutes(_d.BlockTime);
            //if (_d.JLSignedBy) {
            //    //$scope.isEditable = false;
            //    _d.url_sign = signFiles + _d.PICId + ".jpg";
            //    _d.PIC2 = _d.PIC;
            //    _d.signDate = moment(new Date(_d.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
            //}

            $scope.jlObj = response;
            $scope.jl = response;
            if (response.legs[0].JLSignedBy)
                $scope.jl.sign = signFiles + response.legs[0].JLSignedBy + ".jpg";
            console.log($scope.jlObj);


            $scope.jl.sectors = [];
            for (var i = 0; i < 6; i++) {
                var s = i + 1;
                var sec = { sector: s };
                if (response.legs.length >= s) {
                    var flight = response.legs[i];
                    sec.from = flight.FromAirportIATA;
                    sec.to = flight.ToAirportIATA;
                    sec.no = flight.FlightNumber;
                    sec.mm = moment(new Date(flight.STD)).format('MM');
                    sec.dd = moment(new Date(flight.STD)).format('DD');
                    sec.leg = flight;
                }

                $scope.jl.sectors.push(sec);
            }
            var cockpit = Enumerable.From(response.crew).Where('$.JobGroupCode.startsWith("00101")').OrderBy('$.IsPositioning').ThenBy('$.GroupOrder').ThenBy('$.Name').ToArray();
            var cabin = Enumerable.From(response.crew).Where('$.JobGroupCode.startsWith("00102")').OrderBy('$.IsPositioning').ThenBy('$.GroupOrder').ThenBy('$.Name').ToArray();

            $scope.jl.cockpit = [];
            $scope.jl.cabin = [];
            var n = 0;
            var j = cabin.length;
            if (cockpit.length > j)
                j = cockpit.length;
            if (8 > j) j = 8;
            $scope.jl.crews = [];
            //bahrami-6-2
            $scope.jl.crewscockpit = [];
            $scope.jl.crewscabin = [];
            //console.log(cockpit);
            $.each(cockpit, function (_i, co) {
                if (co.Position == "Captain")
                    co.Position = "CPT";
                if (co.IsPositioning)
                    co.Position = 'DH';
                $scope.jl.crewscockpit.push(co);

            });
            $.each(cabin, function (_i, co) {
                if (co.IsPositioning)
                    co.Position = 'DH';
                if (co.Position && co.Position == 'Purser')
                    co.Position = 'SCCM';
                if (co.Position && co.Position == 'FA')
                    co.Position = 'CCM';
                if (co.JobGroup == "ISCCM")
                    co.Position = "ISCCM";
                $scope.jl.crewscabin.push(co);
            });

            if ($scope.jl.crewscockpit.length < 7)
                for (var i = $scope.jl.crewscockpit.length; i < 7; i++) {
                    $scope.jl.crewscockpit.push({ Position: ' ', Name: ' ' });

                }


            if ($scope.jl.crewscabin.length < 7)
                for (var i = $scope.jl.crewscabin.length; i < 7; i++) {
                    $scope.jl.crewscabin.push({ Position: ' ', Name: ' ' });
                }


            ///////////////////////////
            for (var i = 0; i < j; i++) {
                var ca = {};
                if (cabin.length > i)
                    ca = cabin[i];

                var co = {};
                if (cockpit.length > i)
                    co = cockpit[i];

                //////////////////////////////////
                if (co.Position == "Captain")
                    co.Position = "CPT";
                // if (co.JobGroup == "TRE" || co.JobGroup == "TRI" || co.JobGroup == "LTC")

                // co.Position = 'IP';
                if (co.IsPositioning)
                    co.Position = 'DH';
                //////////////////////////////////


                if (ca.Position && ca.Position == 'Purser')
                    ca.Position = 'SCCM';
                if (ca.Position && ca.Position == 'FA')
                    ca.Position = 'CCM';
                if (ca.JobGroup == "ISCCM")
                    ca.Position = "ISCCM";

                if (ca.IsPositioning)
                    ca.Position = 'DH';

                // bahrami-6-2
                if (!ca.Name) { ca.Name = ''; ca.Position = ''; }
                if (!co.Name) { co.Name = ''; co.Position = ''; }
                $scope.jl.crews.push({ cabin: ca, cockpit: co });


            }

            $scope.jl.rvsm1 = [];
            $scope.jl.rvsm1.push($scope.fillRVSM(1, response.legs));
            $scope.jl.rvsm1.push($scope.fillRVSM(2, response.legs));
            $scope.jl.rvsm1.push($scope.fillRVSM(3, response.legs));
            $scope.jl.rvsm2 = [];
            $scope.jl.rvsm2.push($scope.fillRVSM(4, response.legs));
            $scope.jl.rvsm2.push($scope.fillRVSM(5, response.legs));
            $scope.jl.rvsm2.push($scope.fillRVSM(6, response.legs));

            $('#pos1').prop('checked', $scope.jl.pos1);

            $('#pos2').prop('checked', $scope.jl.pos2);
            $('#vr').prop('checked', $scope.jl.vr);
            $('#asr').prop('checked', $scope.jl.asr);
            if ($scope.jl.sign)
                $("#_jlsign").attr('src', $scope.jl.sign);


        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });



    };

    ////////////////////////
    $scope.FlightId = -1;
    $scope.airline_logo = staticFiles + "logo.png";
    $scope.$on('InitJLAdd', function (event, prms) {

      

        $scope.tempData = null;

        $scope.tempData = prms;

        $scope.FlightId=(prms.FlightId);
        $scope.popup_add_visible = true;

    });

}]);