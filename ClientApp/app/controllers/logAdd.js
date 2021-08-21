﻿'use strict';
app.controller('logAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window','$q', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window,$q) {

    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = false;
    var detector = new MobileDetect(window.navigator.userAgent);
    
    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;
    

    ///////////////////////////
    $scope.updateServer = function () {
        $scope.loadingVisible = true;
        flightService.epSaveLog($scope.dto).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);
                $scope.popup_add_visible = false;
            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.updateLocal = function () {
        $scope.dto.Server = false;
        $scope.loadingVisible = true;
        flightService.epSaveLog($scope.dto).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);
                $scope.popup_add_visible = false;
            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.syncFlight = function () {
        $scope.loadingVisible = true;
        flightService.epSyncFlight($scope.checkResult).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                General.ShowNotify(Config.Text_SavedOk, 'success');
                $rootScope.$broadcast('onFlightLocgSaved', response.Data);
                $scope.popup_add_visible = false;
            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    ///////////////////////
    $scope.scrollStyle = {};

    $scope._saveServer = function () { };
    $scope._saveLocal = function () { };
    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_add_title = 'New';
    $scope.popup_instance = null;
    $scope.popup_width = 400;
    $scope.popup_height = 600;
    $scope.dto = null;
    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default',visible:false, text: 'Local Save', icon: 'check', validationGroup: 'logadd', onClick: function (e) {
                        //var result = e.validationGroup.validate();

                        // if (!result.isValid) {
                        //     General.ShowNotify(Config.Text_FillRequired, 'error');
                        //     return;
                        // }
                        $scope.dto = { Server: true };
                        $scope.dto.FlightId = $scope.entity.FlightId;
                        $scope.dto.CrewId = $scope.entity.CrewId;
                        $scope.dto.DelayBlockOff = null;
                        $scope.dto.BlockTime = null;
                        $scope.dto.FlightTime = null;
                        if ($scope.blockOff) {
                            $scope.dto.BlockOffDate = momentFromatFroServerUTC((new Date($scope.blockOff)).combineDate(new Date($scope.entity.STDDay), $scope.blockOffD));
                            $scope.dto.DelayBlockOff = getMinutesDiff($scope.entity.STD, $scope.blockOff);
                        }
                        if ($scope.blockOn)
                            $scope.dto.BlockOnDate = momentFromatFroServerUTC((new Date($scope.blockOn)).combineDate(new Date($scope.entity.STDDay), $scope.blockOnD));
                        if ($scope.takeOff)
                            $scope.dto.TakeOffDate = momentFromatFroServerUTC((new Date($scope.takeOff)).combineDate(new Date($scope.entity.STDDay), $scope.takeOffD));
                        if ($scope.landing)
                            $scope.dto.LandingDate = momentFromatFroServerUTC((new Date($scope.landing)).combineDate(new Date($scope.entity.STDDay), $scope.landingD));

                        if ($scope.blockOff && $scope.blockOn) {
                            $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
                        }
                        if ($scope.takeOff && $scope.landing) {
                            $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
                        }

                        $scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
                        $scope.dto.FuelUplift = $scope.entity.FuelUplift;
                        $scope.dto.FuelUsed = $scope.entity.FuelUsed;
                        $scope.dto.FuelDensity = $scope.entity.FuelDensity;
                        $scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift:null;

                        $scope.dto.PaxAdult = $scope.entity.PaxAdult;
                        $scope.dto.PaxChild = $scope.entity.PaxChild;
                        $scope.dto.PaxInfant = $scope.entity.PaxInfant;
                        $scope.dto.PaxTotal = $scope.entity.PaxTotal; 

                        $scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
                        $scope.dto.CargoWeight = $scope.entity.CargoWeight;

                        $scope.dto.SerialNo = $scope.entity.SerialNo;
                        $scope.dto.LTR = $scope.entity.LTR;
                        $scope.dto.PF = $scope.entity.PF;

                        $scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
                        $scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
                        $scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;

                        $scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
                        $scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
                        $scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;

                        $scope.dto.CommanderNote = $scope.entity.CommanderNote;
                        $scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
                        $scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;

                        $scope.dto.JLDate = momentUtcNow();
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.dto.Version = $scope.entity.Version + 1;
                         
                         $scope.updateLocal();




                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'logadd', onClick: function (e) {
                        //var result = e.validationGroup.validate();

                        // if (!result.isValid) {
                        //     General.ShowNotify(Config.Text_FillRequired, 'error');
                        //     General.ShowNotify(Config.Text_FillRequired, 'error');
                        //     return;
                        // }
                         
                       
                        $scope.dto = {Server:true};
                        $scope.dto.FlightId = $scope.entity.FlightId;
                        $scope.dto.CrewId = $scope.entity.CrewId;
                       
                        $scope.dto.DelayBlockOff = null;
                        $scope.dto.BlockTime = null;
                        $scope.dto.FlightTime = null;
                        if ($scope.blockOff) {
                            $scope.dto.BlockOffDate = momentFromatFroServerUTC((new Date($scope.blockOff)).combineDate(new Date($scope.entity.STDDay), $scope.blockOffD));
                           
                            $scope.dto.DelayBlockOff = getMinutesDiff($scope.entity.STD, $scope.blockOff);
                        }
                        if ($scope.blockOn)
                            $scope.dto.BlockOnDate = momentFromatFroServerUTC((new Date($scope.blockOn)).combineDate(new Date($scope.entity.STDDay), $scope.blockOnD));
                        if ($scope.takeOff)
                            $scope.dto.TakeOffDate = momentFromatFroServerUTC((new Date($scope.takeOff)).combineDate(new Date($scope.entity.STDDay), $scope.takeOffD));
                        if ($scope.landing)
                            $scope.dto.LandingDate = momentFromatFroServerUTC((new Date($scope.landing)).combineDate(new Date($scope.entity.STDDay), $scope.landingD));

                        if ($scope.blockOff && $scope.blockOn) {
                            $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
                        }
                        if ($scope.takeOff && $scope.landing) {
                            $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
                        }

                        $scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
                        $scope.dto.FuelUplift = $scope.entity.FuelUplift;
                        $scope.dto.FuelUsed = $scope.entity.FuelUsed;
                        $scope.dto.FuelDensity = $scope.entity.FuelDensity;
                        $scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift : null;

                        $scope.dto.PaxAdult = $scope.entity.PaxAdult;
                        $scope.dto.PaxChild = $scope.entity.PaxChild;
                        $scope.dto.PaxInfant = $scope.entity.PaxInfant;
                        $scope.dto.PaxTotal = $scope.entity.PaxTotal;

                        $scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
                        $scope.dto.CargoWeight = $scope.entity.CargoWeight;

                        $scope.dto.SerialNo = $scope.entity.SerialNo;
                        $scope.dto.LTR = $scope.entity.LTR;
                        $scope.dto.PF = $scope.entity.PF;

                        $scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
                        $scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
                        $scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;

                        $scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
                        $scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
                        $scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;

                        $scope.dto.CommanderNote = $scope.entity.CommanderNote; 
                        $scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
                        $scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;

                        $scope.dto.JLDate = momentUtcNow();
                        // $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.dto.Version = $scope.entity.Version + 1;


                        if ($rootScope.getOnlineStatus()) {
                            var dtoCheck = { JLDate: $scope.dto.JLDate, CrewId: $scope.dto.CrewId, FlightId: $scope.dto.FlightId };
                            $scope.loadingVisible = true;
                            flightService.epCheckLog(dtoCheck).then(function (response) {
                                $scope.loadingVisible = false;
                                $scope.checkResult = response.Data;


                                if (($scope.checkResult.JLUserId && $scope.checkResult.JLUserId != $scope.entity.JLUserId)
                                    || ($scope.checkResult.JLUserId && getTimeForSync($scope.checkResult.JLDate) > getTimeForSync($scope.entity.JLDate))
                                ) {
                                    $scope.checkResult.JLDate2 = moment($scope.checkResult.JLDate).format('YYYY-MMM-DD');
                                    $scope.popup_check_visible = true;
                                }
                                else {
                                    $scope.updateServer();
                                }
                            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                        }
                        else {
                            $scope.dto.JLUserId = $scope.entity.CrewId;
                            $scope.updateLocal();
                        }
                        
                       
                       




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

            if ($scope.isNew) {
                $scope.isContentVisible = true;
            }
            if ($scope.tempData != null)
                $scope.bind();
             
            if ($scope.isFullScreen)
                //  $scope.scrollHeight = $(window).height() - 230;
                $scope.scrollStyle = { height: ($(window).height() - 230).toString()+'px'};
            else
                $scope.scrollStyle = { height: ($scope.popup_height - 195).toString()+  'px' };
              //  $scope.scrollHeight = 200;



        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onLogAddHide', null);
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
            width: 'popup_width'

        }
    };


    $scope.scroll_logadd_height = 600-200;
    $scope.scroll_logadd = {
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
            height: 'scroll_logadd_height'
        }

    };
    ///////////////////////////
    $scope.popup_check_visible = false;
    $scope.popup_check = {
        height: 200,
        width: 440,
        title: 'Alert',
        showTitle: true,

        toolbarItems: [


            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update Local', onClick: function (e) {

                        $scope.syncFlight();
                        $scope.popup_check_visible = false;
                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Update Server', onClick: function (e) {
                        $scope.updateServer();
                        $scope.popup_check_visible = false;

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Local Save', onClick: function (e) {

                        $scope.updateLocal();
                        $scope.popup_check_visible = false;
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

            $scope.popup_check_visible = false;

        },
        onContentReady: function (e) {

        },
        bindingOptions: {
            visible: 'popup_check_visible',


        }
    };
    ////////////////////////////
    $scope.entity = {
        Id: -1,
    };
    $scope.blockOff = null;
    $scope.blockOn = null;
    $scope.takeOff = null;
    $scope.landing = null;
    $scope.blockOffD = "D";
    $scope.takeOffD = "D";
    $scope.landingD = "D";
    $scope.blockOnD = "D";
    $scope.time_blockoff = {
        type: "time",
        width: '100%',
        pickerType: "rollers",
        displayFormat: "HHmm",
        interval: 15,
        onValueChanged: function (arg) {

        },
        bindingOptions: {
            value: 'blockOff',

        }
    };
    $scope.time_blockon = {
        type: "time",
        width: '100%',
        pickerType: "rollers",
        displayFormat: "HHmm",
        interval: 15,
        onValueChanged: function (arg) {

        },
        bindingOptions: {
            value: 'blockOn',

        }
    };
    $scope.time_takeoff = {
        type: "time",
        width: '100%',
        pickerType: "rollers",
        displayFormat: "HHmm",
        interval: 15,
        onValueChanged: function (arg) {

        },
        bindingOptions: {
            value: 'takeOff',

        }
    };
    $scope.time_landing = {
        type: "time",
        width: '100%',
        pickerType: "rollers",
        displayFormat: "HHmm",
        interval: 15,
        onValueChanged: function (arg) {

        },
        bindingOptions: {
            value: 'landing',

        }
    };
    
    $scope.fuel_remaining = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 500,
        useLargeSpinButtons:true,
        min: 0,
        showSpinButtons: true,
        onValueChanged: function (e) {
            $scope.entity.FuelTotal = null;
            if ($scope.entity.FuelUplift && $scope.entity.FuelRemaining)
                $scope.entity.FuelTotal = $scope.entity.FuelUplift + $scope.entity.FuelRemaining;
        },
        bindingOptions: {
            value: "entity.FuelRemaining"
        },
         
    };
    $scope.fuel_uplift = {
        valueChangeEvent:'keyup',
        showClearButton: false,
        step: 500,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        onValueChanged: function (e) {
            $scope.entity.FuelTotal = null;
            if ($scope.entity.FuelUplift && $scope.entity.FuelRemaining)
                $scope.entity.FuelTotal = $scope.entity.FuelUplift + $scope.entity.FuelRemaining;
        },
        bindingOptions: {
            value: "entity.FuelUplift"
        },

    };
    $scope.fuel_density = {
        showClearButton: false,
        step: 0.1,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        bindingOptions: {
            value: "entity.FuelDensity"
        },

    };
    $scope.fuel_total = {
        showClearButton: false,
        readOnly:true,
        useLargeSpinButtons: false,
        min: 0,
        showSpinButtons: false,
        bindingOptions: {
            value: "entity.FuelTotal"
        },

    };
    $scope.fuel_used = {
        showClearButton: false,
        step: 500,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        bindingOptions: {
            value: "entity.FuelUsed"
        },

    };
    ///////////////////////////////
    $scope.pass_adult = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 1,
        useLargeSpinButtons: true,
        min: 0, 
        showSpinButtons: true,
        onValueChanged: function (e) {
             
            $scope.entity.PaxTotal = nullZero($scope.entity.PaxAdult) + nullZero($scope.entity.PaxChild) + nullZero($scope.entity.PaxInfant);
        },
        bindingOptions: {
            value: "entity.PaxAdult"
        },

    };
    $scope.pass_child = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 1,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        onValueChanged: function (e) {

            $scope.entity.PaxTotal = nullZero($scope.entity.PaxAdult) + nullZero($scope.entity.PaxChild) + nullZero($scope.entity.PaxInfant);
        },
        bindingOptions: {
            value: "entity.PaxChild"
        },

    };
    $scope.pass_infant = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 1,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        onValueChanged: function (e) {

            $scope.entity.PaxTotal = nullZero($scope.entity.PaxAdult) + nullZero($scope.entity.PaxChild) + nullZero($scope.entity.PaxInfant);
        },
        bindingOptions: {
            value: "entity.PaxInfant"
        },

    };
    $scope.pass_total = {
        showClearButton: false,
        readOnly: true,
        useLargeSpinButtons: false,
        min: 0,
        showSpinButtons: false,
        bindingOptions: {
            value: "entity.PaxTotal"
        },

    };
   ///////////////////////////////////
    $scope.cargo = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        onValueChanged: function (e) {

            $scope.entity.Freight = nullZero($scope.entity.CargoWeight) + nullZero($scope.entity.BaggageWeight)  ;
        },
        bindingOptions: {
            value: "entity.CargoWeight"
        },

    };
    $scope.baggs = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: true,
        onValueChanged: function (e) {

            $scope.entity.Freight = nullZero($scope.entity.CargoWeight) + nullZero($scope.entity.BaggageWeight) ;
        },
        bindingOptions: {
            value: "entity.BaggageWeight"
        },

    };
    
    $scope.freight = {
        showClearButton: false,
        readOnly: true,
        useLargeSpinButtons: false,
        min: 0,
        showSpinButtons: false,
        bindingOptions: {
            value: "entity.Freight"
        },

    };

    ///////////////////////////////
    $scope.gnd_cpt = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: false,
        
        showSpinButtons: false,
       
        bindingOptions: {
            value: "entity.RVSM_GND_CPT"
        },

    };
    $scope.gnd_stby = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: false,
        
        showSpinButtons: false,

        bindingOptions: {
            value: "entity.RVSM_GND_STBY"
        },

    };
    $scope.gnd_fo = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: false,
         
        showSpinButtons: false,

        bindingOptions: {
            value: "entity.RVSM_GND_FO"
        },

    };

    $scope.flt_cpt = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: false,
         
        showSpinButtons: false,

        bindingOptions: {
            value: "entity.RVSM_FLT_CPT"
        },

    };
    $scope.flt_stby = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: false,
         
        showSpinButtons: false,

        bindingOptions: {
            value: "entity.RVSM_FLT_STBY"
        },

    };
    $scope.flt_fo = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 100,
        useLargeSpinButtons: false,
        min: 0,
        showSpinButtons: false,

        bindingOptions: {
            value: "entity.RVSM_FLT_FO"
        },

    };

    $scope.sb_pf = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: ['C','F','I'],
        bindingOptions: {
            value: 'entity.PF',


        }
    };

    $scope.serialNo = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        
        useLargeSpinButtons: false,
        
        showSpinButtons: false,

        bindingOptions: {
            value: "entity.SerialNo"
        },

    };
    $scope.ltr = {
        valueChangeEvent: 'keyup',
        showClearButton: false,

        useLargeSpinButtons: false,

        showSpinButtons: false,

        bindingOptions: {
            value: "entity.LTR"
        },

    };
    $scope.chb_rep1 = {

        text: '',
        bindingOptions: {
            value: 'entity.AttRepositioning1',

        }
    };
    $scope.chb_rep2 = {

        text: '',
        bindingOptions: {
            value: 'entity.AttRepositioning2',

        }
    };
    $scope.note = {
        bindingOptions: {
            value: 'entity.CommanderNote',
            height: '80',
           
        }
    };
    ////////////////////////////////
    $scope.clickD = function (prm) {

        switch ($scope[prm]) {

            case 'D':
                $scope[prm] = '+D';
                break;
            case '+D':
                $scope[prm] = '-D';
                break;
            case '-D':
                $scope[prm] = 'D';
                break;
            default: break;
        }
    };
    $scope.fillTime = function (des, src) {
        $scope[des] = $scope.entity[src];
    };
    var _day = function (dt) {
        return (new Date(dt)).getDate();
    };
     
    $scope.bind = function () {
      
        //db.GetAppFlightCrew($scope.entity.Id, function (flt) {

        //});

        //return;
        $scope.loadingVisible = true;
        flightService.epGetFlightLocal($scope.entity.Id).then(function (response) {

            $scope.loadingVisible = false;

            if (response.IsSuccess) {

                $scope.isContentVisible = true;
                //$scope.entity.FlightNumber = response.Data.FlightNumber;
                //$scope.entity.FromAirportIATA = response.Data.FromAirportIATA;
                //$scope.entity.ToAirportIATA = response.Data.ToAirportIATA;
                //$scope.entity.STDDay = response.Data.STDDay;
                //$scope.entity.STD = response.Data.STD;
                //$scope.entity.STA = response.Data.STA;
                $scope.entity = response.Data;
                 

                $scope.blockOff = $scope.entity.BlockOff;
                $scope.blockOn = $scope.entity.BlockOn;
                $scope.takeOff = $scope.entity.TakeOff;
                $scope.landing = $scope.entity.Landing;

                $scope.blockOffD = "D";
                $scope.takeOffD = "D";
                $scope.blockOnD = "D";
                $scope.landingD = "D";
                if ($scope.entity.BlockOff && _day($scope.entity.BlockOff) > _day($scope.entity.STD))
                    $scope.blockOffD = "+D";
                if ($scope.entity.BlockOff && _day($scope.entity.BlockOff) < _day($scope.entity.STD))
                    $scope.blockOffD = "-D";

                if ($scope.entity.TakeOff && _day($scope.entity.TakeOff) > _day($scope.entity.STD))
                    $scope.takeOffD = "+D";
                if ($scope.entity.TakeOff && _day($scope.entity.TakeOff) < _day($scope.entity.STD))
                    $scope.takeOffD = "-D";

                if ($scope.entity.Landing && _day($scope.entity.Landing) > _day($scope.entity.STA))
                    $scope.landingD = "+D";
                if ($scope.entity.Landing && _day($scope.entity.Landing) < _day($scope.entity.STA))
                    $scope.landingD = "-D";

                if ($scope.entity.BlockOn && _day($scope.entity.BlockOn) > _day($scope.entity.STA))
                    $scope.blockOnD = "+D";
                if ($scope.entity.BlockOn && _day($scope.entity.BlockOn) < _day($scope.entity.STA))
                    $scope.blockOnD = "-D";

                if (!$scope.entity.FuelDensity)
                    $scope.entity.FuelDensity = 0.8;



            }
            else
                $rootScope.processErorrs(response);

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };

    ////////////////////////////
    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        $scope.$apply(function () {
            // $scope.leftHeight = $(window).height() - 135;
            // $scope.rightHeight = $(window).height() - 135 - 45;
        });
    });
    $scope.tempData = null;
    $scope.$on('InitLogAdd', function (event, prms) {


        $scope.tempData = null;

        if (!prms.Id) {

            $scope.isNew = true;

            $scope.popup_add_title = 'Log';

        }

        else {

            $scope.popup_add_title = 'Log';
            $scope.tempData = prms;
            $scope.entity.Id = prms.Id;

        }

        $scope.popup_add_visible = true;

    });
    //////////////////////////////

}]);  


'use strict';
app.controller('asrAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window) {
    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    //if (detector.mobile() && !detector.tablet())
    $scope.isFullScreen = true;



    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_height = $(window).height() - 300;
    $scope.popup_width = $(window).width() - 0;
    $scope.popup_add_title = 'AIR SAFETY REPORT';
    $scope.popup_instance = null;

    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'asradd', onClick: function (e) {

                        var result = e.validationGroup.validate();

                        if (!result.isValid) {
                            General.ShowNotify(Config.Text_FillRequired, 'error');
                            return;
                        }


                        $scope.entity.User = $rootScope.userTitle;
                        $scope.loadingVisible = true;
                        flightService.saveASR($scope.entity).then(function (response2) {
                            $scope.loadingVisible = false;
                            if (response2.IsSuccess) {
                                General.ShowNotify(Config.Text_SavedOk, 'success');
                                console.log('ASR', response2.Data);
                                $scope.popup_add_visible = false;
                            }


                        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


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

            if ($scope.isNew) {
                $scope.isContentVisible = true;
            }
            if ($scope.tempData != null)
                $scope.bind();





        },
        onHiding: function () {

            //$scope.clearEntity();
            $scope.entity = {
                Id: -1,
                IsSecurityEvent: false,
                IsAirproxATC: false,
                IsTCASRA: false,
                IsWakeTur: false,
                IsBirdStrike: false,
                IsOthers: false,

            };
            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onAsrAddHide', null);
        },
        onContentReady: function (e) {
            if (!$scope.popup_instance)
                $scope.popup_instance = e.component;

        },
        // fullScreen:false,
        bindingOptions: {
            visible: 'popup_add_visible',
            fullScreen: 'isFullScreen',
            title: 'popup_add_title',
            height: 'popup_height',
            width: 'popup_width'

        }
    };

    /////////////////////////////////


    /////////////////////////////////
    $scope.flight = null;
    $scope.fill = function (data) {
        $scope.entity = data;
    };
    $scope.bind = function () {
        $scope.entity.FlightId = $scope.tempData.FlightId;

        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetASRByFlight($scope.entity.FlightId).then(function (response2) {

                $scope.loadingVisible = false;



                if (!response2.Data) {
                    $scope.entity.Id = -1;
                    $scope.isNew = true;


                }
                else {

                    if (response2.Data.Alert) {
                        General.Confirm("The report updated by " + response2.Data.Alert + ". Would you like to get edited report?", function (res) {
                            if (res) {

                                //var dto = { Id: $scope.ati_flight.ID, };
                                $scope.loadingVisible = true;
                                flightService.epReplaceASR(response2.Data.server).then(function (res) {

                                    $scope.isNew = false;
                                    $scope.fill(res);
                                    $scope.loadingVisible = false;


                                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                            }
                            else {
                                $scope.$apply(function () {
                                    $scope.isNew = false;


                                    $scope.fill(response2.Data);
                                });

                            }
                        });
                    }
                    else {

                        $scope.isNew = false;
                        $scope.fill(response2.Data);
                    }
                }

                //console.log('ASR',response2.Data);

            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


            //$scope.entity.FlightNo = response.Data.FlightNumber;
            //$scope.entity.Date = new Date(response.Data.STDDay);
            //$scope.entity.ACReg = response.Data.Register;
            //$scope.entity.Route = response.Data.FromAirportIATA + ' - ' + response.Data.ToAirportIATA
            //$scope.entity.FlightNo = response.Data.FlightNumber
            //$scope.FlightNo = {
            //    min: 0,
            //    bindingOptions: {
            //        value: 'entity.FlightNo',
            //    }
            //};

            //$scope.Date = {
            //    min: 0,
            //    bindingOptions: {
            //        value: 'entity.Date',
            //    }
            //};

            //$scope.Route = {
            //    min: 0,
            //    bindingOptions: {
            //        value: 'entity.Route',
            //    }
            //};

            //$scope.ACType = {
            //    min: 0,
            //    bindingOptions: {
            //        value: 'entity.ACType',
            //    }
            //};

            //$scope.ACReg = {
            //    min: 0,
            //    bindingOptions: {
            //        value: 'entity.ACReg',
            //    }
            //};


        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    ////////////////////////////////
    $scope.scroll_asradd_height = $(window).height() - 130;
    $scope.scroll_asradd = {
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
            height: 'scroll_asradd_height'
        }

    };

    /////////////////////////////////
    $scope.entity = {
        Id: -1,
        IsSecurityEvent: false,
        IsAirproxATC: false,
        IsTCASRA: false,
        IsWakeTur: false,
        IsBirdStrike: false,
        IsOthers: false,

    };
    $scope.txt_OccurrenceDate = {
        type: "datetime",
        width: '100%',
        pickerType: "rollers",
        displayFormat: "yyyy-MM-dd HHmm",
        interval: 15,
        onValueChanged: function (arg) {

        },
        bindingOptions: {
            value: 'entity.OccurrenceDate',

        }
    };
    $scope.chb_IsSecurityEvent = {

        text: 'SECURITY EVENT',
        bindingOptions: {
            value: 'entity.IsSecurityEvent',

        }
    };
    $scope.chb_IsAirproxATC = {

        text: 'AIRPROX/ATC',
        bindingOptions: {
            value: 'entity.IsAirproxATC',

        }
    };
    $scope.chb_IsTCASRA = {

        text: 'TCAS RA',
        bindingOptions: {
            value: 'entity.IsTCASRA',

        }
    };
    $scope.chb_IsWakeTur = {

        text: 'WAKE TURB.',
        bindingOptions: {
            value: 'entity.IsWakeTur',

        }
    };
    $scope.chb_IsBirdStrike = {

        text: 'BIRD STRIKE',
        bindingOptions: {
            value: 'entity.IsBirdStrike',

        }
    };
    $scope.chb_IsOthers = {

        text: 'OTHERS',
        bindingOptions: {
            value: 'entity.IsOthers',

        }
    };


    $scope.dsEventType = [
        { id: 100042, title: 'ASR' },
        { id: 100043, title: 'AIRPROX/ATC' },
        { id: 100044, title: 'TCAS RA' },
        { id: 100045, title: 'WAKE TURBULENCE' },
        { id: 100046, title: 'BIRD STRIKE' },

    ];
    $scope.sb_EventType = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsEventType,
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.EventTypeId'

        }
    };
    ///////////////////////////




    $scope.dsDayNightStatus = [
        { id: 100180, title: 'Day' },
        { id: 100181, title: 'Night' },

    ];
    $scope.sb_DayNightStatus = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsDayNightStatus,
        displayExpr: 'title',
        placeholder: 'Day/Night',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.DayNightStatusId'

        }
    };

    $scope.txt_squawk = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.SQUAWK',
        }
    }

    $scope.txt_fuel = {
        hoverStateEnabled: false,
        min: 0,
        bindingOptions: {
            value: 'entity.FuelJettisoned',
        }
    }

    $scope.num_alt = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.Altitude',
        }
    }

    $scope.num_speed = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.Speed',
        }
    }

    $scope.num_mach = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.MachNo',
        }
    }

    $scope.num_acWeight = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACWeight',
        }
    }
    ////////////////////////////
    $scope.num_techLogPage = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.TechLogPageNO',
        }
    }

    $scope.num_item = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.TechLogItemNO',
        }
    }

    /////////////////////////////////
    $scope.dsFlightPhase = [
        { id: 100029, title: 'TOWING' },
        { id: 100030, title: 'PARKING' },
        { id: 100031, title: 'PUSHBACK' },
        { id: 100032, title: 'TAXI OUT' },
        { id: 100033, title: 'TAKEOFF' },
        { id: 100034, title: 'INITIAL CLIMB(BELOW 1500FT)' },
        { id: 100035, title: 'CLIMB' },
        { id: 100036, title: 'CRUISE' },
        { id: 100037, title: 'DESCENT' },
        { id: 100038, title: 'HOLDING' },
        { id: 100039, title: 'APPROACH(BELOW 1500FT)' },
        { id: 100040, title: 'LANDING' },

    ];
    $scope.sb_flightPhase = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsFlightPhase,
        displayExpr: 'title',
        placeholder: 'TOWING/PARKING/...',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.FlightPhaseId'

        }
    };

    ////////////////////////////////



    $scope.txt_airport = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.LOCAirport',

        }
    };

    $scope.txt_stand = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.LOCStand',

        }
    };

    $scope.txt_runway = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.LOCRunway',

        }
    };

    $scope.txt_geoPosAlt = {
        hoverStateEnabled: false,
        placeholder: 'Altitude',
        bindingOptions: {
            value: 'entity.LOCGEOAltitude',

        }
    };

    $scope.txt_geoPosLong = {
        hoverStateEnabled: false,
        placeholder: 'Longtitude',
        bindingOptions: {
            value: 'entity.LOCGEOLongtitude',

        }
    };


    ////////////////////////////////

    $scope.dsMET = [
        { id: 100051, title: 'IMC' },
        { id: 100052, title: 'VMC' },
    ];
    $scope.sb_MET = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsMET,
        displayExpr: 'title',
        placeholder: 'IMC/VMC',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.METId'

        }
    };

    ////////////////////////////////

    $scope.dsSignificantWxType = [
        { id: 100054, title: 'MODERATE' },
        { id: 100055, title: 'SEVERE' },
    ]
    $scope.sb_SignificantWxType = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsSignificantWxType,
        displayExpr: 'title',
        placeholder: 'MODERATE/SEVERE',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.SigxWXTypeId'

        }
    };

    $scope.dsSignificantWx = [
        { id: 100056, title: 'RAIN' },
        { id: 100057, title: 'SNOW' },
        { id: 100058, title: 'ICING' },
        { id: 100059, title: 'TURBULENCE' },
        { id: 100060, title: 'HAIL' },
        { id: 100061, title: 'STANDING - WATER' },
        { id: 100062, title: 'WINDSHEAR' },

    ];
    $scope.sb_SignificantWx = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsSignificantWx,
        displayExpr: 'title',
        placeholder: 'RAIN/SNOW/...',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.SigxWXId'

        }
    };
    ////////////////////////////////

    $scope.ActualWX = {
        bindingOptions: {
            value: 'entity.ActualWX',
            height: '80',

        }
    };

    ////////////////////////////////

    $scope.dsRunwayCondition = [
        { id: 100064, title: 'DRY' },
        { id: 100065, title: 'WET' },
        { id: 100066, title: 'ICE' },
        { id: 100067, title: 'SNOW' },
        { id: 100068, title: 'SLUSH' },

    ];
    $scope.sb_RunwayCondition = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsRunwayCondition,
        displayExpr: 'title',
        placeholder: 'DRY/WET/...',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.RunwayConditionId'

        }
    };

    ////////////////////////////////

    $scope.txt_AP = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACConfigAP',

        }
    };

    $scope.txt_ATHR = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACConfigATHR',

        }
    };

    $scope.txt_GEAR = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACConfigGear',

        }
    };

    $scope.txt_FLAP = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACConfigFlap',

        }
    };

    $scope.txt_SLAT = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACConfigSlat',

        }
    };

    $scope.txt_SPOILERS = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.ACConfigSpoilers',

        }
    };


    ////////////////////////////////

    $scope.Summary = {
        bindingOptions: {
            value: 'entity.Summary',
            height: '80',

        }
    };
    ///////////////////////////////
    $scope.Result = {
        bindingOptions: {
            value: 'entity.Result',
            height: '80',

        }
    };
    //////////////////////////////

    $scope.OthersInfo = {
        bindingOptions: {
            value: 'entity.OthersInfo',
            height: '80',

        }
    };

    ///////////////////////////////

    $scope.dsIncidentType = [
        { id: 100183, title: 'AIRMISS' },
        { id: 100184, title: 'ATC INCIDENT' },
        { id: 100185, title: 'TCAS RA' },

    ];
    $scope.sb_IncidentType = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsIncidentType,
        placeholder: 'AIRMISS/WET/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.IncidentTypeId'

        }
    };

    ///////////////////////////////

    $scope.dsRisk = [
        { id: 100070, title: 'Low' },
        { id: 100071, title: 'Med' },
        { id: 100072, title: 'High' },
    ];
    $scope.sb_Risk = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsRisk,
        placeholder: 'LOW/MED/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.AATRiskId'

        }
    };
    //////////////////////////////////
    $scope.dsAvoidingAction = [
        { value: true, title: 'YES' },
        { value: false, title: 'NO' },
    ];
    $scope.sb_AvoidingAction = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsAvoidingAction,
        placeholder: 'YES/NO',

        displayExpr: 'title',
        valueExpr: 'value',
        bindingOptions: {
            value: 'entity.AATIsActionTaken'

        }
    };
    ///////////////////////////////
    $scope.txt_Reported = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATReportedToATC',

        }
    };
    $scope.txt_ATCInstruction = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATATCInstruction',

        }
    };

    $scope.txt_Frequency = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATFrequency',

        }
    };
    $scope.txt_Heading = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATHeading',

        }
    };
    $scope.txt_MinVertSep = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATMinVerticalSep',

        }
    };
    $scope.txt_MinHorizSep = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATMinHorizontalSep',

        }
    };

    $scope.dsTCASAlert = [
        { id: 100074, title: 'RA' },
        { id: 100075, title: 'TA' },
        { id: 100076, title: 'None' },
    ];
    $scope.sb_TCASAlert = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsTCASAlert,
        placeholder: 'RA/TA/...',

        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.AATTCASAlertId'

        }
    };

    $scope.txt_RAType = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATTypeRA',

        }
    };

    $scope.dsRAFollowed = [
        { value: true, title: 'YES' },
        { value: false, title: 'NO' },
    ];
    $scope.sb_RAFollowed = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsRAFollowed,
        placeholder: 'YES/NO',
        displayExpr: 'title',
        valueExpr: 'value',
        bindingOptions: {
            value: 'entity.AATIsRAFollowed'

        }
    };

    $scope.txt_VerticalDeviation = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATVerticalDeviation',

        }
    };
    $scope.txt_OtherAircraft = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATOtherACType',

        }
    };
    $scope.txt_MarkingColour = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATMarkingColour',

        }
    };
    $scope.txt_CallSign = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATCallSign',

        }
    };
    $scope.txt_ClearedAltitude = {
        min: 0,
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATClearedAltitude',

        }
    };
    $scope.txt_Lighting = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.AATLighting',

        }
    };
    ////////////////////////////////

    $scope.txt_WTHeading = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.WTHeading',

        }
    };
    $scope.txt_BSHeading = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.BSHeading',

        }
    };
    $scope.dsTurning = [
        { id: 100078, title: 'Left' },
        { id: 100079, title: 'Right' },
        { id: 100080, title: 'No' },
    ];
    $scope.sb_Turning = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsTurning,
        placeholder: 'Left/Right/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.WTTurningId'

        }
    };

    $scope.sb_BSTurning = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsTurning,
        placeholder: 'Left/Right/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.BSTurningId'

        }
    };

    $scope.dsGlideSlopePos = [
        { id: 100082, title: 'High' },
        { id: 100083, title: 'Low' },
        { id: 100084, title: 'On' },

    ];
    $scope.sb_GlideSlopePos = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsGlideSlopePos,
        placeholder: 'High/Low/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.WTGlideSlopePosId'

        }
    };

    $scope.dsExtendedCenterlinePos = [
        { id: 100087, title: 'Left' },
        { id: 100088, title: 'Right' },
        { id: 100089, title: 'On' },

    ];
    $scope.sb_ExtendedCenterlinePos = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsExtendedCenterlinePos,
        placeholder: 'Left/Right/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.WTExtendedCenterlinePosId'

        }
    };

    $scope.dsAttitudeChange = [
        { id: 100091, title: 'Pitch' },
        { id: 100092, title: 'Roll' },
        { id: 100093, title: 'Yaw' },

    ];
    $scope.sb_AttitudeChange = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsAttitudeChange,
        placeholder: 'Pitch/Roll/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.WTAttitudeChangeId'

        }
    };
    $scope.txt_Deg = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.WTAttitudeChangeDeg',

        }
    };
    $scope.dsBuffet = [
        { value: true, title: 'YES' },
        { value: false, title: 'NO' },
    ];
    $scope.sb_IsBuffet = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsBuffet,
        placeholder: 'YES/NO',
        displayExpr: 'title',
        valueExpr: 'value',
        bindingOptions: {
            value: 'entity.WTIsBuffet'

        }
    };
    $scope.dsStickShaker = [
        { value: true, title: 'YES' },
        { value: false, title: 'NO' },
    ];
    $scope.sb_StickShaker = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsStickShaker,
        placeholder: 'YES/NO',
        displayExpr: 'title',
        valueExpr: 'value',
        bindingOptions: {
            value: 'entity.WTIsStickShaker'

        }
    };
    $scope.Suspect = {
        bindingOptions: {
            value: 'entity.WTSuspect',
            height: '80',

        }
    };
    $scope.Acceleration = {
        bindingOptions: {
            value: 'entity.WTDescribeVA',
            height: '80',

        }
    };
    $scope.Details = {
        bindingOptions: {
            value: 'entity.WTPrecedingAC',
            height: '80',

        }
    };
    $scope.dsAware = [
        { value: true, title: 'YES' },
        { value: false, title: 'NO' },
    ];
    $scope.sb_Aware = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsAware,
        placeholder: 'YES/NO',
        displayExpr: 'title',
        valueExpr: 'value',
        bindingOptions: {
            value: 'entity.WTIsAware'

        }
    };
    ////////////////////////////////

    $scope.txt_BirdType = {
        hoverStateEnabled: false,
        bindingOptions: {
            value: 'entity.BSBirdType',

        }
    };

    $scope.dsTime = [
        { id: 100104, title: 'Dawn' },
        { id: 100105, title: 'Day' },
        { id: 100106, title: 'Dusk' },
        { id: 100107, title: 'Night' },


    ];
    $scope.sb_Time = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsTime,
        placeholder: 'Dawn/Day/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.BSTimeId'

        }
    };

    $scope.dsNrSeen = [
        { id: 100098, title: '1' },
        { id: 100099, title: '2-10' },
        { id: 100100, title: '11-100' },
        { id: 100101, title: 'More' },

    ];
    $scope.sb_NrSeen = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsNrSeen,
        placeholder: '1/2-10/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.BSNrSeenId'

        }
    };

    $scope.dsNrStruck = [
        { id: 100098, title: '1' },
        { id: 100099, title: '2-10' },
        { id: 100100, title: '11-100' },
        { id: 100101, title: 'More' },

    ];
    $scope.sb_NrStruck = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: $scope.dsNrStruck,
        placeholder: '1/2-10/...',
        displayExpr: 'title',
        valueExpr: 'id',
        bindingOptions: {
            value: 'entity.BSNrStruckId'

        }
    };
    $scope.Impact = {
        bindingOptions: {
            value: 'entity.BSImpactDec',
            height: '80',

        }
    };

    ///////////////////////////////

    $scope.tdWidth = $(window).width() / 31.0;
    $scope.rows = [-100, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10]
    $scope.columns = [-100, -14, -13, -12, -11, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
    $scope.getTdClass = function (c, r) {
        var cls = "";
        if (r == 0 && c == 0) { return "ctd-center ctd"; }
        if (r != -100) {
            if (c == -100) {
                cls = "ctd-empty";
            }
            else {
                cls = "ctd";
            }
        }
        else {
            //if (c != -100) return "ctd-empty";
            //else
            //    return "ctd";
            cls = "ctd-empty";
        }
        if (c == $scope.entity.AATXAbove && r == $scope.entity.AATYAbove) {
            cls += " ctd-selected";
        }

        return cls;

    }
    $scope.tableAboveClicked = function (r, c) {
        $scope.entity.AATXAbove = c;
        $scope.entity.AATYAbove = r;
    }



    $scope.getAsClass = function (c, r) {
        var cls = "";
        if (r == 0 && c == 0) { return "ctd-center ctd"; }
        if (r != -100) {
            if (c == -100) {
                cls = "ctd-empty";
            }
            else {
                cls = "ctd";
            }
        }
        else {
            //if (c != -100) return "ctd-empty";
            //else
            //    return "ctd";
            cls = "ctd-empty";
        }


        if (c == $scope.entity.AATXAstern && r == $scope.entity.AATYAstern) {
            cls += " ctd-selected";
        }
        return cls;

    }
    $scope.tableAsternClicked = function (r, c) {
        $scope.entity.AATXAstern = c;
        $scope.entity.AATYAstern = r;
    }




    ////////////////////////////////
    $scope.tempData = null;
    $scope.$on('InitAsrAdd', function (event, prms) {


        $scope.tempData = null;




        $scope.tempData = prms;


        $scope.popup_add_visible = true;

    });

}]);


'use strict';
app.controller('vrAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$http', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $http) {
    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    //if (detector.mobile() && !detector.tablet())
    $scope.isFullScreen = true;

    //////////////////////////////
    $scope.entity = {
        Id: -1,
    };
    $scope.txt_depdelay = {
        hoverStateEnabled: false,
        min: 0,
        bindingOptions: {
            value: 'entity.DepDelay',
        }
    }
    $scope.restReduction = {
        min: 0,
        bindingOptions: {
            value: 'entity.RestReduction',
        }
    };
    $scope.dutyExtention = {
        min: 0,
        bindingOptions: {
            value: 'entity.DutyExtention',
        }
    };
    $scope.report = {
        min: 0,
        height: 200,
        bindingOptions: {
            value: 'entity.Report',
        }
    };
    //FLIGHT CANCELLATION
    $scope.irr_100111 = false;
    $scope.chb_irr_100111 = {
        text: '',
        bindingOptions: {
            value: 'irr_100111',
        }
    };

    //FLIGHT RETURN
    $scope.irr_100112 = false;
    $scope.chb_irr_100112 = {
        text: '',
        bindingOptions: {
            value: 'irr_100112',
        }
    };

    //DIVERSION
    $scope.irr_100113 = false;
    $scope.chb_irr_100113 = {
        text: '',
        bindingOptions: {
            value: 'irr_100113',
        }
    };

    //ABN./ EMER. EVENT
    $scope.irr_100114 = false;
    $scope.chb_irr_100114 = {
        text: '',
        bindingOptions: {
            value: 'irr_100114',
        }
    };

    //DEP. DELAY > 30 MINUTES
    $scope.re_100115 = false;
    $scope.chb_re_100115 = {
        text: '',
        bindingOptions: {
            value: 're_1001215',
        }
    };

    //TECHNICAL
    $scope.re_100119 = false;
    $scope.chb_re_100119 = {
        text: '',
        bindingOptions: {
            value: 're_100119',
        }
    };

    //ATC
    $scope.re_100120 = false;
    $scope.chb_re_100120 = {
        text: '',
        bindingOptions: {
            value: 're_100120',
        }
    };

    //SECURITY
    $scope.re_100121 = false;
    $scope.chb_re_100121 = {
        text: '',
        bindingOptions: {
            value: 're_100121',
        }
    };

    //FLT. OPS
    $scope.re_100122 = false;
    $scope.chb_re_100122 = {
        text: '',
        bindingOptions: {
            value: 're_100122',
        }
    };

    //A/C LATE ARRIVAL
    $scope.re_100123 = false;
    $scope.chb_re_100123 = {
        text: '',
        bindingOptions: {
            value: 're_100123',
        }
    };

    //PAX HANDELING
    $scope.re_100124 = false;
    $scope.chb_re_100124 = {
        text: '',
        bindingOptions: {
            value: 're_100124',
        }
    };

    //CATERING
    $scope.re_100125 = false;
    $scope.chb_re_100125 = {
        text: '',
        bindingOptions: {
            value: 're_100125',
        }
    };

    //WEATHER
    $scope.re_100126 = false;
    $scope.chb_re_100126 = {
        text: '',
        bindingOptions: {
            value: 're_100126',
        }
    };

    //RAMP HANDLING
    $scope.re_100127 = false;
    $scope.chb_re_100127 = {
        text: '',
        bindingOptions: {
            value: 're_100127',
        }
    };

    //OTHERS
    $scope.re_100128 = false;
    $scope.chb_re_100128 = {
        text: '',
        bindingOptions: {
            value: 're_100128',
        }
    };

    $scope.entity.Route = 'test';
    $scope.entity.Report = 'test';
    $scope.entity.DatePICSignature = '8/12/2021';
    $scope.entity.ActionedById = -1;
    $scope.entity.DateActioned = '8/12/2021';
    $scope.entity.DateConfirmed = '8/12/2021';

    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_height = $(window).height() - 300;
    $scope.popup_width = $(window).width() - 200;
    $scope.popup_add_title = 'VOYAGE REPORT';
    $scope.popup_instance = null;

    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'logadd', onClick: function (e) {

                        $scope.entity.Irregularities = [];
                        if ($scope.irr_100111)
                            $scope.entity.Irregularities.push(100111);
                        if ($scope.irr_100112)
                            $scope.entity.Irregularities.push(100112);
                        if ($scope.irr_100113)
                            $scope.entity.Irregularities.push(100113);
                        if ($scope.irr_100114)
                            $scope.entity.Irregularities.push(100114);
                        if ($scope.irr_100115)
                            $scope.entity.Irregularities.push(100115);
                        $scope.entity.Reasons = [];
                        if ($scope.re_100119)
                            $scope.entity.Reasons.push(100119);

                        if ($scope.re_100120)
                            $scope.entity.Reasons.push(100120);

                        if ($scope.re_100121)
                            $scope.entity.Reasons.push(100121);

                        if ($scope.re_100122)
                            $scope.entity.Reasons.push(100122);

                        if ($scope.re_100123)
                            $scope.entity.Reasons.push(100123);

                        if ($scope.re_100124)
                            $scope.entity.Reasons.push(100124);

                        if ($scope.re_100125)
                            $scope.entity.Reasons.push(100125);

                        if ($scope.re_100126)
                            $scope.entity.Reasons.push(100126);

                        if ($scope.re_100127)
                            $scope.entity.Reasons.push(100127);

                        if ($scope.re_100128)
                            $scope.entity.Reasons.push(100128);



                        //flightService.saveVoyageReport($scope.entity).then(function (res) {
                        //    $scope.popup_add_visible = false;
                        //})
                        $scope.entity.User = $rootScope.userTitle;
                        $scope.loadingVisible = true;
                        flightService.saveVR($scope.entity).then(function (response2) {
                            $scope.loadingVisible = false;
                            console.log('Vr res', response2);
                            if (response2.IsSuccess) {
                                General.ShowNotify(Config.Text_SavedOk, 'success');
                                console.log('Vr', response2.Data);
                                $scope.popup_add_visible = false;
                            }


                        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });


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

            if ($scope.isNew) {
                $scope.isContentVisible = true;
            }
            if ($scope.tempData != null)
                $scope.bind();





        },
        onHiding: function () {

            //$scope.clearEntity();



            $scope.irr_100111 = false;
            $scope.irr_100112 = false;
            $scope.irr_100113 = false;
            $scope.irr_100114 = false;
            $scope.irr_100115 = false;


            $scope.re_100119 = false;
            $scope.re_100120 = false;
            $scope.re_100121 = false;
            $scope.re_100122 = false;
            $scope.re_100123 = false;
            $scope.re_100124 = false;
            $scope.re_100125 = false;
            $scope.re_100126 = false;
            $scope.re_100127 = false;
            $scope.re_100128 = false;
            $scope.entity = {
                Id: -1,


            };

            $scope.popup_add_visible = false;

        },
        onContentReady: function (e) {
            if (!$scope.popup_instance)
                $scope.popup_instance = e.component;

        },
        isFullScreen: false,
        bindingOptions: {
            visible: 'popup_add_visible',
            //fullScreen: 'isFullScreen',
            title: 'popup_add_title',
            height: 'popup_height',
            width: 'popup_width'

        }
    };

    /////////////////////////////////


    /////////////////////////////////
    $scope.entity = {
        Id: -1,
    };

    /////////////////////////////////
    $scope.flight = null;
    $scope.fill = function (data) {
        $scope.entity = data;

        var irregularity = Enumerable.From(data.EFBFlightIrregularities).Select('Number($.IrrId)').ToArray();
        $scope.irr_100111 = irregularity.indexOf(100111) != -1;
        $scope.irr_100112 = irregularity.indexOf(100112) != -1;
        $scope.irr_100113 = irregularity.indexOf(100113) != -1;
        $scope.irr_100114 = irregularity.indexOf(100114) != -1;
        $scope.irr_100115 = irregularity.indexOf(100115) != -1;

        var reason = Enumerable.From(data.EFBReasons).Select('Number($.ReasonId)').ToArray();
        $scope.re_100119 = reason.indexOf(100119) != -1;
        $scope.re_100120 = reason.indexOf(100120) != -1;
        $scope.re_100121 = reason.indexOf(100121) != -1;
        $scope.re_100122 = reason.indexOf(100122) != -1;
        $scope.re_100123 = reason.indexOf(100123) != -1;
        $scope.re_100124 = reason.indexOf(100124) != -1;
        $scope.re_100125 = reason.indexOf(100125) != -1;
        $scope.re_100126 = reason.indexOf(100126) != -1;
        $scope.re_100127 = reason.indexOf(100127) != -1;
        $scope.re_100128 = reason.indexOf(100128) != -1;

    };
    $scope._bind = function () {
        $scope.entity.FlightId = $scope.tempData.FlightId;

        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetVRByFlight($scope.entity.FlightId).then(function (response2) {

                $scope.loadingVisible = false;
                if (!response2.Data) {
                    $scope.entity.Id = -1;
                    $scope.isNew = true;


                }
                else {
                    $scope.isNew = false;
                    $scope.fill(response2.Data);
                }



            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });





        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.bind = function () {
        $scope.entity.FlightId = $scope.tempData.FlightId;

        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetVRByFlight($scope.entity.FlightId).then(function (response2) {
                console.log('GET VR', response2);
                $scope.loadingVisible = false;
                if (!response2.Data) {
                    $scope.entity.Id = -1;
                    $scope.isNew = true;


                }
                else {

                    if (response2.Data.Alert) {
                        General.Confirm("The report updated by " + response2.Data.Alert + ". Would you like to get edited report?", function (res) {
                            if (res) {

                                //var dto = { Id: $scope.ati_flight.ID, };
                                $scope.loadingVisible = true;
                                flightService.epReplaceVR(response2.Data.server).then(function (res) {

                                    $scope.isNew = false;
                                    $scope.fill(res);
                                    $scope.loadingVisible = false;


                                }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                            }
                            else {
                                $scope.$apply(function () {
                                    $scope.isNew = false;


                                    $scope.fill(response2.Data);
                                });

                            }
                        });
                    }
                    else {

                        $scope.isNew = false;
                        $scope.fill(response2.Data);
                    }
                }



            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });





        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    ////////////////////////////////
    $scope.scroll_vradd_height = $(window).height() - 420;
    $scope.scroll_vradd = {
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
            height: 'scroll_vradd_height'
        }

    };
    /////////////////////////////////
    $scope.tempData = null;
    $scope.$on('InitVrAdd', function (event, prms) {
        $scope.tempData = null;




        $scope.tempData = prms;


        $scope.popup_add_visible = true;

        //$scope.tempData = null;
        //$scope.entity.FlightId = prms.FlightId;

        //flightService.epGetFlightLocal(prms.FlightId).then(function (response) {

        //    $scope.loadingVisible = false;


        //    $scope.entity.FlightNo = response.Data.FlightNumber;
        //    $scope.entity.Date = new Date(response.Data.STDDay);
        //    $scope.entity.ACReg = response.Data.Register;
        //    $scope.entity.Route = response.Data.FromAirportIATA + ' - ' + response.Data.ToAirportIATA  
        //    $scope.entity.FlightNo = response.Data.FlightNumber
        //    $scope.FlightNo = {
        //        min: 0,
        //        bindingOptions: {
        //            value: 'entity.FlightNo',
        //        }
        //    };

        //    $scope.Date = {
        //        min: 0,
        //        bindingOptions: {
        //            value: 'entity.Date',
        //        }
        //    };

        //    $scope.Route = {
        //        min: 0,
        //        bindingOptions: {
        //            value: 'entity.Route',
        //        }
        //    };

        //    $scope.ACType = {
        //        min: 0,
        //        bindingOptions: {
        //            value: 'entity.ACType',
        //        }
        //    };

        //    $scope.ACReg = {
        //        min: 0,
        //        bindingOptions: {
        //            value: 'entity.ACReg',
        //        }
        //    };


        //}, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });




        //if (!prms.Id) {

        //    $scope.isNew = true;

        //    $scope.popup_add_title = 'Voyage Report';

        //}

        //else {

        //    $scope.popup_add_title = 'Voyage Report';
        //    $scope.tempData = prms;
        //    $scope.entity.Id = prms.Id;


        //}



    });
    //////////////////////////////

}]);  