'use strict';
app.controller('logAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$q', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $q) {
    $scope.isEditable = false;
    $scope.isLockVisible = false;
     

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
    $scope.updateServerNew = function (inline) {
        if (!inline)
            $scope.loadingVisible = true;
        flightService.epSaveLogNew($scope.dto).then(function (response) {
            if (!inline)
                $scope.loadingVisible = false;

            if (response.IsSuccess) {
                if (!inline) {
                    General.ShowNotify(Config.Text_SavedOk, 'success');
                    $rootScope.$broadcast('onFlightLocgSaved', response.Data);
                    $scope.popup_add_visible = false;
                }
            }
        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    $scope.updateLocalNew = function (inline) {
        $scope.dto.Server = false;
        if (!inline)
        $scope.loadingVisible = true;
        flightService.epSaveLogNew($scope.dto).then(function (response) {
            $scope.loadingVisible = false;

            if (response.IsSuccess) {
                if (!inline) {
                    General.ShowNotify(Config.Text_SavedOk, 'success');
                    $rootScope.$broadcast('onFlightLocgSaved', response.Data);
                    $scope.popup_add_visible = false;
                }
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
    var momentUtcNowStringSecond = function () {
        return moment.utc().format('YYYYMMDDHHmmss');
    };
    $scope.popup_add_visible = false;
    $scope.popup_add_title = 'New';
    $scope.popup_instance = null;
    $scope.popup_width = 500;
    $scope.popup_height = 700;
    $scope.dto = null;
    $scope.proccessTimes = function () {
        if ($scope.blockOff) {
            var str = $scope.blockOff.toString();
            if (str.length > 20) {
                $scope.blockOff = moment($scope.blockOff).format('YYYY-MM-DDTHH:mm:ss');
                 
            }
        }

        if ($scope.blockOn) {
            var str = $scope.blockOn.toString();
            if (str.length > 20) {
                $scope.blockOn = moment($scope.blockOn).format('YYYY-MM-DDTHH:mm:ss');

            }
        }

        if ($scope.takeOff) {
            var str = $scope.takeOff.toString();
            if (str.length > 20) {
                $scope.takeOff = moment($scope.takeOff).format('YYYY-MM-DDTHH:mm:ss');

            }
        }

        if ($scope.landing) {
            var str = $scope.landing.toString();
            if (str.length > 20) {
                $scope.landing = moment($scope.landing).format('YYYY-MM-DDTHH:mm:ss');

            }
        }
        
    };
    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

            //{
            //    widget: 'dxButton', location: 'after', options: {
            //        type: 'default', visible: false, text: 'Local Save', icon: 'check', validationGroup: 'logadd'

            //        , onClick: function (e) {
            //            //var result = e.validationGroup.validate();

            //            // if (!result.isValid) {
            //            //     General.ShowNotify(Config.Text_FillRequired, 'error');
            //            //     return;
            //            // }
            //            $scope.dto = { Server: true };
            //            $scope.dto.FlightId = $scope.entity.FlightId;
            //            $scope.dto.CrewId = $scope.entity.CrewId;
            //            $scope.dto.DelayBlockOff = null;
            //            $scope.dto.BlockTime = null;
            //            $scope.dto.FlightTime = null;
            //            if ($scope.blockOff) {
            //                $scope.dto.BlockOffDate = momentFromatFroServerUTC((new Date($scope.blockOff)).combineDate(new Date($scope.entity.STDDay), $scope.blockOffD));
            //                $scope.dto.DelayBlockOff = getMinutesDiff($scope.entity.STD, $scope.blockOff);
            //            }
            //            if ($scope.blockOn)
            //                $scope.dto.BlockOnDate = momentFromatFroServerUTC((new Date($scope.blockOn)).combineDate(new Date($scope.entity.STDDay), $scope.blockOnD));
            //            if ($scope.takeOff)
            //                $scope.dto.TakeOffDate = momentFromatFroServerUTC((new Date($scope.takeOff)).combineDate(new Date($scope.entity.STDDay), $scope.takeOffD));
            //            if ($scope.landing)
            //                $scope.dto.LandingDate = momentFromatFroServerUTC((new Date($scope.landing)).combineDate(new Date($scope.entity.STDDay), $scope.landingD));

            //            if ($scope.blockOff && $scope.blockOn) {
            //                $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
            //            }
            //            if ($scope.takeOff && $scope.landing) {
            //                $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
            //            }

            //            $scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
            //            $scope.dto.FuelUplift = $scope.entity.FuelUplift;
            //            $scope.dto.FuelUsed = $scope.entity.FuelUsed;
            //            $scope.dto.FuelDensity = $scope.entity.FuelDensity;
            //            $scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift:null;

            //            $scope.dto.PaxAdult = $scope.entity.PaxAdult;
            //            $scope.dto.PaxChild = $scope.entity.PaxChild;
            //            $scope.dto.PaxInfant = $scope.entity.PaxInfant;
            //            $scope.dto.PaxTotal = $scope.entity.PaxTotal; 

            //            $scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
            //            $scope.dto.CargoWeight = $scope.entity.CargoWeight;

            //            $scope.dto.SerialNo = $scope.entity.SerialNo;
            //            $scope.dto.LTR = $scope.entity.LTR;
            //            $scope.dto.PF = $scope.entity.PF;

            //            $scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
            //            $scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
            //            $scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;

            //            $scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
            //            $scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
            //            $scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;

            //            $scope.dto.CommanderNote = $scope.entity.CommanderNote;
            //            $scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
            //            $scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;

            //            $scope.dto.JLDate = momentUtcNow();
            //            $scope.dto.JLUserId = $scope.entity.CrewId;
            //            $scope.dto.Version = $scope.entity.Version + 1;

            //             $scope.updateLocal();




            //        }
            //    }, toolbar: 'bottom'
            //},
            {
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Sign', icon: 'fas fa-signature', onClick: function (e) {
                        if ($rootScope.getOnlineStatus()) {
                            //$scope.entity.Id
                            var data = { FlightId: $scope.entity.Id, documentType: 'log' };

                            $rootScope.$broadcast('InitSignAdd', data);
                        }
                        else {
                            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                        }

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'logadd', onClick: function (e) {
                        //magu
                        $scope.proccessTimes();
                        var changed = false;
                        $scope.dto = { Server: true };
                        $scope.dto.FlightId = $scope.entity.FlightId;
                        $scope.dto.CrewId = $scope.entity.CrewId;
                        $scope.dto.DelayBlockOff = null;
                        $scope.dto.BlockTime = null;
                        $scope.dto.FlightTime = null;
                        var nowstring = momentUtcNowStringSecond();
                        try {
                             
                            if ($scope.blockOff) {
                                //if ($rootScope.employeeId == 3529 && ($scope.entity.FlightNumber == '0048' || $scope.entity.FlightNumber == '6919')) {

                                //    alert($scope.blockOff
                                //        + "    M2 " + CreateDate($scope.blockOff)
                                //        + "    M3 " + momentFromatFroServerUTC(CreateDate($scope.blockOff))
                                //        + "    M4 " + momentFromatFroServerUTC(CreateDate($scope.blockOff).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOffD))

                                //    );
                                    
                                    
                                //}
                               // var t = new Date();
                               // alert(t);
                               // alert(momentFromatFroServerUTC(t));
                                
                                var boff1 = /*momentFromatFroServerUTC*/(CreateDate($scope.blockOff).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOffD));
                                var boff2 = /*momentFromatFroServerUTC*/(CreateDate($scope.entity.BlockOff));
                                if ($scope.blockOff && boff1 != boff2) {
                                    changed = true;
                                    
                                    //goodi 
                                     
                                    var boffdt = momentFromatFroServerUTCObj(CreateDate($scope.blockOff).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOffD));
                                     
                                    $scope.dto.BlockOffDate = boffdt.result;
                                    if ($scope.dto.BlockOffDate) {

                                        $scope.dto.BlockOffDateDt = nowstring;
                                        $scope.dto.DelayBlockOff = getMinutesDiff($scope.entity.STD, $scope.blockOff);
                                    }
                                    else {
                                        alert('Error in converting BLOCKOFF date. Please report the error value to the application administrator. ERROR VALUE: ' + boffdt.err);
                                    }
                                   
                                }
                            }
                             


                            //if ($scope.blockOn)
                            //    $scope.dto.BlockOnDate = momentFromatFroServerUTC((new Date($scope.blockOn)).combineDate(new Date($scope.entity.STDDay), $scope.blockOnD));
                            if ($scope.blockOn) {
                                var bon1 = /*momentFromatFroServerUTC*/(CreateDate($scope.blockOn).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOnD));
                                var bon2 = /*momentFromatFroServerUTC*/(CreateDate($scope.entity.BlockOn));
                                if ($scope.blockOn && bon1 != bon2) {
                                    changed = true;
                                    var boffdt = momentFromatFroServerUTCObj(CreateDate($scope.blockOn).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOnD)); 

                                    $scope.dto.BlockOnDate = boffdt.result;
                                    if ($scope.dto.BlockOnDate) {

                                        $scope.dto.BlockOnDateDt = nowstring;
                                        
                                    }
                                    else {
                                        alert('Error in converting BLOCKON date. Please report the error value to the application administrator. ERROR VALUE: ' + boffdt.err);
                                    }


                                  //  $scope.dto.BlockOnDateDt = nowstring;
                                  //  $scope.dto.BlockOnDate = momentFromatFroServerUTC(CreateDate($scope.blockOn).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOnD));
                                  

                                }
                            }


                            //if ($scope.takeOff)
                            //    $scope.dto.TakeOffDate = momentFromatFroServerUTC((new Date($scope.takeOff)).combineDate(new Date($scope.entity.STDDay), $scope.takeOffD));
                            if ($scope.takeOff) {
                                var bto1 = /*momentFromatFroServerUTC*/(CreateDate($scope.takeOff).combineDate(CreateDate($scope.entity.STDDay), $scope.takeOffD));
                                var bto2 = /*momentFromatFroServerUTC*/(CreateDate($scope.entity.TakeOff));
                                if ($scope.takeOff && bto1 != bto2) {
                                    changed = true;
                                    var boffdt = momentFromatFroServerUTCObj(CreateDate($scope.takeOff).combineDate(CreateDate($scope.entity.STDDay), $scope.takeOffD));

                                    $scope.dto.TakeOffDate = boffdt.result;
                                    if ($scope.dto.TakeOffDate) {

                                        $scope.dto.TakeOffDateDt = nowstring;

                                    }
                                    else {
                                        alert('Error in converting TAKEOFF date. Please report the error value to the application administrator. ERROR VALUE: ' + boffdt.err);
                                    }


                                    //$scope.dto.TakeOffDateDt = nowstring;
                                    //$scope.dto.TakeOffDate = momentFromatFroServerUTC(CreateDate($scope.takeOff).combineDate(CreateDate($scope.entity.STDDay), $scope.takeOffD));

                                }
                            }
                             

                            //if ($scope.landing)
                            //    $scope.dto.LandingDate = momentFromatFroServerUTC((new Date($scope.landing)).combineDate(new Date($scope.entity.STDDay), $scope.landingD));

                            if ($scope.landing) {
                                var bla1 = /*momentFromatFroServerUTC*/(CreateDate($scope.landing).combineDate(CreateDate($scope.entity.STDDay), $scope.landingD));
                                var bla2 = /*momentFromatFroServerUTC*/(CreateDate($scope.entity.Landing));
                                if ($scope.landing && bla1 != bla2) {
                                    changed = true;
                                    var boffdt = momentFromatFroServerUTCObj(CreateDate($scope.landing).combineDate(CreateDate($scope.entity.STDDay), $scope.landingD));

                                    $scope.dto.LandingDate = boffdt.result;
                                    if ($scope.dto.LandingDate) {

                                        $scope.dto.LandingDateDt = nowstring;

                                    }
                                    else {
                                        alert('Error in converting LANDING date. Please report the error value to the application administrator. ERROR VALUE: ' + boffdt.err);
                                    } 

                                    //$scope.dto.LandingDateDt = nowstring;
                                    //$scope.dto.LandingDate = momentFromatFroServerUTC(CreateDate($scope.landing).combineDate(CreateDate($scope.entity.STDDay), $scope.landingD));

                                }
                            }

                            if ($scope.blockOff && $scope.blockOn) {
                                $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
                            }
                            if ($scope.takeOff && $scope.landing) {
                                $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
                            }
                            //boz
                            //$scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
                            if (($scope.entity.FuelRemaining || $scope.entity.FuelRemaining === 0) && $scope.entity.FuelRemaining != $scope.org.FuelRemaining) {
                                changed = true;
                                $scope.dto.FuelRemainingDt = nowstring;
                                $scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
                            }
                            //$scope.dto.FuelUplift = $scope.entity.FuelUplift;
                            if (($scope.entity.FuelUplift || $scope.entity.FuelUplift === 0) && $scope.entity.FuelUplift != $scope.org.FuelUplift) {
                                changed = true;
                                $scope.dto.FuelUpliftDt = nowstring;
                                $scope.dto.FuelUplift = $scope.entity.FuelUplift;
                            }
                            //$scope.dto.FuelUsed = $scope.entity.FuelUsed;

                            if (($scope.entity.FuelUsed || $scope.entity.FuelUsed === 0) && $scope.entity.FuelUsed != $scope.org.FuelUsed) {
                                changed = true;
                                $scope.dto.FuelUsedDt = nowstring;
                                $scope.dto.FuelUsed = $scope.entity.FuelUsed;
                            }

                            //$scope.dto.FuelDensity = $scope.entity.FuelDensity;
                            if ($scope.entity.FuelDensity && $scope.entity.FuelDensity != $scope.org.FuelDensity) {
                                changed = true;
                                $scope.dto.FuelDensityDt = nowstring;
                                $scope.dto.FuelDensity = $scope.entity.FuelDensity;
                            }
                            $scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift : null;

                            //$scope.dto.PaxAdult = $scope.entity.PaxAdult;
                            if (($scope.entity.PaxAdult || $scope.entity.PaxAdult === 0) && $scope.entity.PaxAdult != $scope.org.PaxAdult) {
                                changed = true;
                                $scope.dto.PaxAdultDt = nowstring;
                                $scope.dto.PaxAdult = $scope.entity.PaxAdult;
                            }
                            //$scope.dto.PaxChild = $scope.entity.PaxChild;
                            if (($scope.entity.PaxChild || $scope.entity.PaxChild === 0) && $scope.entity.PaxChild != $scope.org.PaxChild) {
                                changed = true;
                                $scope.dto.PaxChildDt = nowstring;
                                $scope.dto.PaxChild = $scope.entity.PaxChild;
                            }
                            //$scope.dto.PaxInfant = $scope.entity.PaxInfant;
                            if (($scope.entity.PaxInfant || $scope.entity.PaxInfant === 0) && $scope.entity.PaxInfant != $scope.org.PaxInfant) {
                                changed = true;
                                $scope.dto.PaxInfantDt = nowstring;
                                $scope.dto.PaxInfant = $scope.entity.PaxInfant;
                            }
                            $scope.dto.PaxTotal = $scope.entity.PaxTotal;

                            //$scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
                            if (($scope.entity.BaggageWeight || $scope.entity.BaggageWeight === 0) && $scope.entity.BaggageWeight != $scope.org.BaggageWeight) {
                                changed = true;
                                $scope.dto.BaggageWeightDt = nowstring;
                                $scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
                            }
                            //$scope.dto.CargoWeight = $scope.entity.CargoWeight;
                            if (($scope.entity.CargoWeight || $scope.entity.CargoWeight === 0) && $scope.entity.CargoWeight != $scope.org.CargoWeight) {
                                changed = true;
                                $scope.dto.CargoWeightDt = nowstring;
                                $scope.dto.CargoWeight = $scope.entity.CargoWeight;
                            }

                            //$scope.dto.SerialNo = $scope.entity.SerialNo;
                            if ($scope.entity.SerialNo && $scope.entity.SerialNo != $scope.org.SerialNo) {
                                changed = true;
                                $scope.dto.SerialNoDt = nowstring;
                                $scope.dto.SerialNo = $scope.entity.SerialNo;
                            }
                            //$scope.dto.LTR = $scope.entity.LTR;
                            if ($scope.entity.LTR && $scope.entity.LTR != $scope.org.LTR) {
                                changed = true;
                                $scope.dto.LTRDt = nowstring;
                                $scope.dto.LTR = $scope.entity.LTR;
                            }
                            //$scope.dto.PF = $scope.entity.PF;
                            if ($scope.entity.PF && $scope.entity.PF != $scope.org.PF) {
                                changed = true;
                                $scope.dto.PFDt = nowstring;
                                $scope.dto.PF = $scope.entity.PF;
                            }

                            //$scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
                            if ($scope.entity.RVSM_GND_CPT && $scope.entity.RVSM_GND_CPT != $scope.org.RVSM_GND_CPT) {
                                changed = true;
                                $scope.dto.RVSM_GND_CPTDt = nowstring;
                                $scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
                            }
                            //$scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
                            if ($scope.entity.RVSM_GND_STBY && $scope.entity.RVSM_GND_STBY != $scope.org.RVSM_GND_STBY) {
                                changed = true;
                                $scope.dto.RVSM_GND_STBYDt = nowstring;
                                $scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
                            }
                            //$scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;
                            if ($scope.entity.RVSM_GND_FO && $scope.entity.RVSM_GND_FO != $scope.org.RVSM_GND_FO) {
                                changed = true;
                                $scope.dto.RVSM_GND_FODt = nowstring;
                                $scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;
                            }

                            //$scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
                            if ($scope.entity.RVSM_FLT_CPT && $scope.entity.RVSM_FLT_CPT != $scope.org.RVSM_FLT_CPT) {
                                changed = true;
                                $scope.dto.RVSM_FLT_CPTDt = nowstring;
                                $scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
                            }
                            //$scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
                            if ($scope.entity.RVSM_FLT_STBY && $scope.entity.RVSM_FLT_STBY != $scope.org.RVSM_FLT_STBY) {
                                changed = true;
                                $scope.dto.RVSM_FLT_STBYDt = nowstring;
                                $scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
                            }
                            //$scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;
                            if ($scope.entity.RVSM_FLT_FO && $scope.entity.RVSM_FLT_FO != $scope.org.RVSM_FLT_FO) {
                                changed = true;
                                $scope.dto.RVSM_FLT_FODt = nowstring;
                                $scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;
                            }

                            //$scope.dto.CommanderNote = $scope.entity.CommanderNote; 
                            if ($scope.entity.CommanderNote && $scope.entity.CommanderNote != $scope.org.CommanderNote) {
                                changed = true;
                                $scope.dto.CommanderNoteDt = nowstring;
                                $scope.dto.CommanderNote = $scope.entity.CommanderNote;
                            }
                            //$scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
                            if ($scope.entity.AttRepositioning1 != $scope.org.AttRepositioning1) {
                                changed = true;
                                $scope.dto.AttRepositioning1Dt = nowstring;
                                $scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
                            }
                            //$scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;
                            if ($scope.entity.AttRepositioning2 != $scope.org.AttRepositioning2) {
                                changed = true;
                                $scope.dto.AttRepositioning2Dt = nowstring;
                                $scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;
                            }

                            $scope.dto.JLDate = momentUtcNow();

                            $scope.dto.Version = $scope.entity.Version + 1;


                            if (changed) {
                                if ($rootScope.getOnlineStatus()) {
                                    $scope.updateServerNew();
                                }
                                else {
                                    $scope.dto.JLUserId = $scope.entity.CrewId;
                                    $scope.updateLocalNew();
                                }
                            }
                            else
                                $scope.popup_add_visible = false;
                        }
                        catch (e) {
                            alert(e);
                        }
                        ////////////////////////////////
                        ////////////////////////////////
                        ////////////////////////////////
                        //$scope.dto = {Server:true};
                        //$scope.dto.FlightId = $scope.entity.FlightId;
                        //$scope.dto.CrewId = $scope.entity.CrewId;

                        //$scope.dto.DelayBlockOff = null;
                        //$scope.dto.BlockTime = null;
                        //$scope.dto.FlightTime = null;
                        //if ($scope.blockOff) {
                        //    $scope.dto.BlockOffDate = momentFromatFroServerUTC((new Date($scope.blockOff)).combineDate(new Date($scope.entity.STDDay), $scope.blockOffD));

                        //    $scope.dto.DelayBlockOff = getMinutesDiff($scope.entity.STD, $scope.blockOff);
                        //}
                        //if ($scope.blockOn)
                        //    $scope.dto.BlockOnDate = momentFromatFroServerUTC((new Date($scope.blockOn)).combineDate(new Date($scope.entity.STDDay), $scope.blockOnD));
                        //if ($scope.takeOff)
                        //    $scope.dto.TakeOffDate = momentFromatFroServerUTC((new Date($scope.takeOff)).combineDate(new Date($scope.entity.STDDay), $scope.takeOffD));
                        //if ($scope.landing)
                        //    $scope.dto.LandingDate = momentFromatFroServerUTC((new Date($scope.landing)).combineDate(new Date($scope.entity.STDDay), $scope.landingD));

                        //if ($scope.blockOff && $scope.blockOn) {
                        //    $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
                        //}
                        //if ($scope.takeOff && $scope.landing) {
                        //    $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
                        //}

                        //$scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
                        //$scope.dto.FuelUplift = $scope.entity.FuelUplift;
                        //$scope.dto.FuelUsed = $scope.entity.FuelUsed;
                        //$scope.dto.FuelDensity = $scope.entity.FuelDensity;
                        //$scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift : null;

                        //$scope.dto.PaxAdult = $scope.entity.PaxAdult;
                        //$scope.dto.PaxChild = $scope.entity.PaxChild;
                        //$scope.dto.PaxInfant = $scope.entity.PaxInfant;
                        //$scope.dto.PaxTotal = $scope.entity.PaxTotal;

                        //$scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
                        //$scope.dto.CargoWeight = $scope.entity.CargoWeight;

                        //$scope.dto.SerialNo = $scope.entity.SerialNo;
                        //$scope.dto.LTR = $scope.entity.LTR;
                        //$scope.dto.PF = $scope.entity.PF;

                        //$scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
                        //$scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
                        //$scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;

                        //$scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
                        //$scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
                        //$scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;

                        //$scope.dto.CommanderNote = $scope.entity.CommanderNote; 
                        //$scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
                        //$scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;

                        //$scope.dto.JLDate = momentUtcNow();

                        //$scope.dto.Version = $scope.entity.Version + 1;


                        //if ($rootScope.getOnlineStatus()) {
                        //    var dtoCheck = { JLDate: $scope.dto.JLDate, CrewId: $scope.dto.CrewId, FlightId: $scope.dto.FlightId };
                        //    $scope.loadingVisible = true;
                        //    flightService.epCheckLog(dtoCheck,'log').then(function (response) {
                        //        $scope.loadingVisible = false;
                        //        $scope.checkResult = response.Data;


                        //        //if (($scope.checkResult.JLUserId && $scope.checkResult.JLUserId != $scope.entity.JLUserId)
                        //        //    || ($scope.checkResult.JLUserId && getTimeForSync($scope.checkResult.JLDate) > getTimeForSync($scope.entity.JLDate))
                        //        //) {
                        //        //    $scope.checkResult.JLDate2 = moment($scope.checkResult.JLDate).format('YYYY-MMM-DD');
                        //        //    $scope.popup_check_visible = true;
                        //        //}
                        //        //else {
                        //        //    $scope.updateServer();
                        //        //}
                        //        ////////9-29
                        //        $scope.updateServer();
                        //        ///////////////
                        //    }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                        //}
                        //else {
                        //    $scope.dto.JLUserId = $scope.entity.CrewId;
                        //    $scope.updateLocal();
                        //}







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

            if ($scope.isFullScreen)
                //  $scope.scrollHeight = $(window).height() - 230;
                $scope.scrollStyle = { height: ($(window).height() - 230).toString() + 'px' };
            else
                $scope.scrollStyle = { height: ($scope.popup_height - 195).toString() + 'px' };
            //  $scope.scrollHeight = 200;



        },
        onHiding: function () {

            //$scope.clearEntity();
            $rootScope.IsRootSyncEnabled = true;
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
            width: 'popup_width',
            'toolbarItems[1].visible': 'isEditable',
            'toolbarItems[0].visible': 'isLockVisible',

        }
    };


    $scope.scroll_logadd_height = 700 - 200;
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
             
                return;
             
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                
                var boff1 = momentFromatFroServerUTC(CreateDate($scope.blockOff).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOffD));
                var boff2 = momentFromatFroServerUTC(CreateDate($scope.entity.BlockOff));
                 
                if ($scope.blockOff && boff1 != boff2) {
                    changed = true;
                    $scope.dto.BlockOffDateDt = nowstring;
                    $scope.dto.BlockOffDate = momentFromatFroServerUTC(CreateDate($scope.blockOff).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOffD));

                    $scope.dto.DelayBlockOff = getMinutesDiff($scope.entity.STD, $scope.blockOff);
                }
              
                if ($scope.blockOff && $scope.blockOn) {
                    $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
                }
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
            return;
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
              
                var bon1 = momentFromatFroServerUTC(CreateDate($scope.blockOn).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOnD));
                var bon2 = momentFromatFroServerUTC(CreateDate($scope.entity.BlockOn));
                if ($scope.blockOn && bon1 != bon2) {
                    changed = true;
                    $scope.dto.BlockOnDateDt = nowstring;
                    $scope.dto.BlockOnDate = momentFromatFroServerUTC(CreateDate($scope.blockOn).combineDate(CreateDate($scope.entity.STDDay), $scope.blockOnD));

                }
                if ($scope.blockOff && $scope.blockOn) {
                    $scope.dto.BlockTime = getMinutesDiff($scope.blockOff, $scope.blockOn);
                }
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
            return;
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                
                var bto1 = momentFromatFroServerUTC(CreateDate($scope.takeOff).combineDate(CreateDate($scope.entity.STDDay), $scope.takeOffD));
                var bto2 = momentFromatFroServerUTC(CreateDate($scope.entity.TakeOff));
                if ($scope.takeOff && bto1 != bto2) {
                    changed = true;
                    $scope.dto.TakeOffDateDt = nowstring;
                    $scope.dto.TakeOffDate = momentFromatFroServerUTC(CreateDate($scope.takeOff).combineDate(CreateDate($scope.entity.STDDay), $scope.takeOffD));

                }
                if ($scope.takeOff && $scope.landing) {
                    $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
                }
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
            return;
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                
                var bla1 = momentFromatFroServerUTC(CreateDate($scope.landing).combineDate(CreateDate($scope.entity.STDDay), $scope.landingD));
                var bla2 = momentFromatFroServerUTC(CreateDate($scope.entity.Landing));
                if ($scope.landing && bla1 != bla2) {
                    changed = true;
                    $scope.dto.LandingDateDt = nowstring;
                    $scope.dto.LandingDate = momentFromatFroServerUTC(CreateDate($scope.landing).combineDate(CreateDate($scope.entity.STDDay), $scope.landingD));

                }
                if ($scope.takeOff && $scope.landing) {
                    $scope.dto.FlightTime = getMinutesDiff($scope.takeOff, $scope.landing);
                }
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: 'landing',

        }
    };

    $scope.fuel_remaining = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 500,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: false,
        onValueChanged: function (e) {
            $scope.entity.FuelTotal = null;
            if (($scope.entity.FuelUplift || $scope.entity.FuelUplift === 0) && ($scope.entity.FuelRemaining || $scope.entity.FuelRemaining === 0))
                $scope.entity.FuelTotal = $scope.entity.FuelUplift + $scope.entity.FuelRemaining;
            


        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.FuelRemaining || $scope.entity.FuelRemaining === 0) && $scope.entity.FuelRemaining != $scope.org.FuelRemaining) {
                    changed = true;
                    $scope.dto.FuelRemainingDt = nowstring;
                    $scope.dto.FuelRemaining = $scope.entity.FuelRemaining;
                }
                $scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift : null;
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;
                 
                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {
                 
            }


            ///////////////////////
        },
        bindingOptions: {
            value: "entity.FuelRemaining"
        },

    };
    $scope.fuel_uplift = {
        valueChangeEvent: 'keyup',
        showClearButton: false,
        step: 500,
        useLargeSpinButtons: true,
        min: 0,
        showSpinButtons: false,
        onValueChanged: function (e) {
            $scope.entity.FuelTotal = null;
            if (($scope.entity.FuelUplift || $scope.entity.FuelUplift === 0) && ($scope.entity.FuelRemaining || $scope.entity.FuelRemaining === 0))
                $scope.entity.FuelTotal = $scope.entity.FuelUplift + $scope.entity.FuelRemaining;
        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.FuelUplift || $scope.entity.FuelUplift === 0) && $scope.entity.FuelUplift != $scope.org.FuelUplift) {
                    changed = true;
                    $scope.dto.FuelUpliftDt = nowstring;
                    $scope.dto.FuelUplift = $scope.entity.FuelUplift;
                }
                $scope.dto.FuelTotal = $scope.entity.FuelRemaining && $scope.entity.FuelUplift ? $scope.entity.FuelRemaining + $scope.entity.FuelUplift : null;
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {
                
            }


            ///////////////////////
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
        showSpinButtons: false,
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.FuelDensity && $scope.entity.FuelDensity != $scope.org.FuelDensity) {
                    changed = true;
                    $scope.dto.FuelDensityDt = nowstring;
                    $scope.dto.FuelDensity = $scope.entity.FuelDensity;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: "entity.FuelDensity"
        },

    };
    $scope.fuel_total = {
        showClearButton: false,
        readOnly: true,
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
        showSpinButtons: false,
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.FuelUsed || $scope.entity.FuelUsed === 0) && $scope.entity.FuelUsed != $scope.org.FuelUsed) {
                    changed = true;
                    $scope.dto.FuelUsedDt = nowstring;
                    $scope.dto.FuelUsed = $scope.entity.FuelUsed;
                }
               
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {
                
            }


            ///////////////////////
        },
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
        showSpinButtons: false,
        onValueChanged: function (e) {

            $scope.entity.PaxTotal = nullZero($scope.entity.PaxAdult) + nullZero($scope.entity.PaxChild) + nullZero($scope.entity.PaxInfant);
        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.PaxAdult || $scope.entity.PaxAdult === 0) && $scope.entity.PaxAdult != $scope.org.PaxAdult) {
                    changed = true;
                    $scope.dto.PaxAdultDt = nowstring;
                    $scope.dto.PaxAdult = $scope.entity.PaxAdult;
                }
                $scope.dto.PaxTotal = $scope.entity.PaxTotal;
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
        showSpinButtons: false,
        onValueChanged: function (e) {

            $scope.entity.PaxTotal = nullZero($scope.entity.PaxAdult) + nullZero($scope.entity.PaxChild) + nullZero($scope.entity.PaxInfant);
        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.PaxChild || $scope.entity.PaxChild === 0) && $scope.entity.PaxChild != $scope.org.PaxChild) {
                    changed = true;
                    $scope.dto.PaxChildDt = nowstring;
                    $scope.dto.PaxChild = $scope.entity.PaxChild;
                }
                $scope.dto.PaxTotal = $scope.entity.PaxTotal;
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
        showSpinButtons: false,
        onValueChanged: function (e) {

            $scope.entity.PaxTotal = nullZero($scope.entity.PaxAdult) + nullZero($scope.entity.PaxChild) + nullZero($scope.entity.PaxInfant);
        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.PaxInfant || $scope.entity.PaxInfant === 0) && $scope.entity.PaxInfant != $scope.org.PaxInfant) {
                    changed = true;
                    $scope.dto.PaxInfantDt = nowstring;
                    $scope.dto.PaxInfant = $scope.entity.PaxInfant;
                }
                $scope.dto.PaxTotal = $scope.entity.PaxTotal;
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
        showSpinButtons: false,
        onValueChanged: function (e) {

            $scope.entity.Freight = nullZero($scope.entity.CargoWeight) + nullZero($scope.entity.BaggageWeight);
        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.CargoWeight || $scope.entity.CargoWeight === 0) && $scope.entity.CargoWeight != $scope.org.CargoWeight) {
                    changed = true;
                    $scope.dto.CargoWeightDt = nowstring;
                    $scope.dto.CargoWeight = $scope.entity.CargoWeight;
                }
                
                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
        showSpinButtons: false,
        onValueChanged: function (e) {

            $scope.entity.Freight = nullZero($scope.entity.CargoWeight) + nullZero($scope.entity.BaggageWeight);
        },
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if (($scope.entity.BaggageWeight || $scope.entity.BaggageWeight === 0) && $scope.entity.BaggageWeight != $scope.org.BaggageWeight) {
                    changed = true;
                    $scope.dto.BaggageWeightDt = nowstring;
                    $scope.dto.BaggageWeight = $scope.entity.BaggageWeight;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
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
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.RVSM_GND_CPT && $scope.entity.RVSM_GND_CPT != $scope.org.RVSM_GND_CPT) {
                    changed = true;
                    $scope.dto.RVSM_GND_CPTDt = nowstring;
                    $scope.dto.RVSM_GND_CPT = $scope.entity.RVSM_GND_CPT;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
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
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.RVSM_GND_STBY && $scope.entity.RVSM_GND_STBY != $scope.org.RVSM_GND_STBY) {
                    changed = true;
                    $scope.dto.RVSM_GND_STBYDt = nowstring;
                    $scope.dto.RVSM_GND_STBY = $scope.entity.RVSM_GND_STBY;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
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
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.RVSM_GND_FO && $scope.entity.RVSM_GND_FO != $scope.org.RVSM_GND_FO) {
                    changed = true;
                    $scope.dto.RVSM_GND_FODt = nowstring;
                    $scope.dto.RVSM_GND_FO = $scope.entity.RVSM_GND_FO;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
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
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.RVSM_FLT_CPT && $scope.entity.RVSM_FLT_CPT != $scope.org.RVSM_FLT_CPT) {
                    changed = true;
                    $scope.dto.RVSM_FLT_CPTDt = nowstring;
                    $scope.dto.RVSM_FLT_CPT = $scope.entity.RVSM_FLT_CPT;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
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
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.RVSM_FLT_STBY && $scope.entity.RVSM_FLT_STBY != $scope.org.RVSM_FLT_STBY) {
                    changed = true;
                    $scope.dto.RVSM_FLT_STBYDt = nowstring;
                    $scope.dto.RVSM_FLT_STBY = $scope.entity.RVSM_FLT_STBY;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
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
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.RVSM_FLT_FO && $scope.entity.RVSM_FLT_FO != $scope.org.RVSM_FLT_FO) {
                    changed = true;
                    $scope.dto.RVSM_FLT_FODt = nowstring;
                    $scope.dto.RVSM_FLT_FO = $scope.entity.RVSM_FLT_FO;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: "entity.RVSM_FLT_FO"
        },

    };

    $scope.sb_pf = {
        showClearButton: true,
        searchEnabled: false,
        dataSource: ['C', 'F', 'I'],
        onValueChanged: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.PF && $scope.entity.PF != $scope.org.PF) {
                    changed = true;
                    $scope.dto.PFDt = nowstring;
                    $scope.dto.PF = $scope.entity.PF;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: 'entity.PF',


        }
    };

    $scope.serialNo = {
        valueChangeEvent: 'keyup',
        showClearButton: false,

        useLargeSpinButtons: false,

        showSpinButtons: false,
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.SerialNo && $scope.entity.SerialNo != $scope.org.SerialNo) {
                    changed = true;
                    $scope.dto.SerialNoDt = nowstring;
                    $scope.dto.SerialNo = $scope.entity.SerialNo;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: "entity.SerialNo"
        },

    };
    $scope.ltr = {
        valueChangeEvent: 'keyup',
        showClearButton: false,

        useLargeSpinButtons: false,

        showSpinButtons: false,
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.LTR && $scope.entity.LTR != $scope.org.LTR) {
                    changed = true;
                    $scope.dto.LTRDt = nowstring;
                    $scope.dto.LTR = $scope.entity.LTR;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: "entity.LTR"
        },

    };
    $scope.chb_rep1 = {

        text: '',
        onValueChanged: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ( $scope.entity.AttRepositioning1 != $scope.org.AttRepositioning1) {
                    changed = true;
                    $scope.dto.AttRepositioning1Dt = nowstring;
                    $scope.dto.AttRepositioning1 = $scope.entity.AttRepositioning1;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: 'entity.AttRepositioning1',

        }
    };
    $scope.chb_rep2 = {

        text: '',
        onValueChanged: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ( $scope.entity.AttRepositioning2 != $scope.org.AttRepositioning2) {
                    changed = true;
                    $scope.dto.AttRepositioning2Dt = nowstring;
                    $scope.dto.AttRepositioning2 = $scope.entity.AttRepositioning2;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
        bindingOptions: {
            value: 'entity.AttRepositioning2',

        }
    };
    $scope.note = {
        onFocusOut: function (e) {
            /////SAVE//////////////
            try {
                var changed = false;
                $scope.dto = { Server: true };
                $scope.dto.FlightId = $scope.entity.FlightId;
                $scope.dto.CrewId = $scope.entity.CrewId;
                var nowstring = momentUtcNowStringSecond();
                if ($scope.entity.CommanderNote && $scope.entity.CommanderNote != $scope.org.CommanderNote) {
                    changed = true;
                    $scope.dto.CommanderNoteDt = nowstring;
                    $scope.dto.CommanderNote = $scope.entity.CommanderNote;
                }

                $scope.dto.JLDate = momentUtcNow();

                $scope.dto.Version = $scope.entity.Version + 1;

                if (changed) {
                    if ($rootScope.getOnlineStatus()) {
                        $scope.updateServerNew(true);
                    }
                    else {
                        $scope.dto.JLUserId = $scope.entity.CrewId;
                        $scope.updateLocalNew(true);
                    }
                }

            }
            catch (ee) {

            }


            ///////////////////////
        },
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

        //if ($rootScope.getOnlineStatus()) {

        //    flightService.checkLock($scope.entity.Id, 'log').then(function (response) {
        //        $scope.isLockVisible = false;
        //        if (response.IsSuccess && response.Data.canLock) {
        //            $scope.isLockVisible = true;
        //        }
        //    }, function (err) { });
        //}


        $scope.loadingVisible = true;
        flightService.epGetFlightLocal($scope.entity.Id).then(function (response) {
            //moment.utc()


            var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;
            $scope.isEditable = (diff <= 48);
            if (response.Data.JLSignedBy) {
                //$scope.isEditable = false;
                $scope.url_sign = signFiles + response.Data.PICId + ".jpg";
                $scope.PIC = response.Data.PIC;
                $scope.signDate = moment(new Date(response.Data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
            }


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
                $scope.org = JSON.parse(JSON.stringify($scope.entity));

               
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

                if ($scope.remFuel)
                    $scope.entity.FuelRemaining = $scope.remFuel;
                //alert($scope.entity.FuelRemaining);

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
    $scope.$on('onSign', function (event, prms) {

        if (prms.doc == 'log')
            flightService.signDocLocal(prms, prms.doc).then(function (response) {
                //alert('log signed');
                //$scope.isEditable = false;
                // $scope.isLockVisible = false; 
                $scope.url_sign = signFiles + prms.PICId + ".jpg";
                $scope.PIC = prms.PIC;
                $scope.signDate = moment(new Date(prms.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    });
    $scope.remFuel = null;
    $scope.$on('InitLogAdd', function (event, prms) {


        $scope.tempData = null;

        if (!prms.Id) {

            $scope.isNew = true;

            $scope.popup_add_title = 'Log (2.5)';

        }

        else {

            $scope.popup_add_title = 'Log (2.5)';
            $scope.tempData = prms;
            $scope.remFuel = prms.remFuel;
            $scope.entity.Id = prms.Id;

        }

        $scope.popup_add_visible = true;

    });
    //////////////////////////////

}]);

'use strict';
app.controller('asrAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window) {
    $scope.isNew = true;
    $scope.isEditable = false;
    $scope.isLockVisible = false;
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
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Sign', icon: 'fas fa-signature', onClick: function (e) {
                        if ($rootScope.getOnlineStatus()) {
                            $rootScope.checkInternet(function (st) {
                                if (st) {
                                    var data = { FlightId: $scope.entity.FlightId, documentType: 'asr' };

                                    $rootScope.$broadcast('InitSignAdd', data);
                                }
                                else {
                                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                                }
                            });

                        }
                        else {
                            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                        }

                    }
                }, toolbar: 'bottom'
            },

            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'asradd', onClick: function (e) {

                        var result = e.validationGroup.validate();

                        if (!result.isValid) {
                            General.ShowNotify(Config.Text_FillRequired, 'error');
                            return;
                        }
                        //alert($scope.entity.Id);
                        //db.getCount('ASRs', function (n) {
                        //    n = n + 1;
                        //    n = -1 * n;
                        //    $scope.entity.Id = n;

                        //});
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
            $rootScope.IsRootSyncEnabled = true;
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
            width: 'popup_width',
            'toolbarItems[0].visible': 'isLockVisible',
            'toolbarItems[1].visible': 'isEditable',

        }
    };

    /////////////////////////////////


    /////////////////////////////////
    $scope.flight = null;
    $scope.fill = function (data) {
        $scope.entity = data;
    };
    $scope.isLockVisible = false;
    $scope.bind = function () {
        $scope.entity.FlightId = $scope.tempData.FlightId;



        if ($rootScope.getOnlineStatus()) {
            $rootScope.checkInternet(function (st) {
                if (st) {
                    flightService.checkLock($scope.entity.FlightId, 'asr').then(function (response) {
                        $scope.isLockVisible = false;
                        if (response.IsSuccess && response.Data.canLock) {
                            $scope.isLockVisible = true;
                        }
                    }, function (err) { });
                }
                else {
                    General.ShowNotifyBottom("The application cannot connect to the Server. Please check your internet connection.", 'error');
                }
            });

        }


        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;

            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetASRByFlight($scope.entity.FlightId).then(function (response2) {

                $scope.loadingVisible = false;
                $scope.isEditable = (diff <= 24);


                if (!response2.Data) {
                    $scope.entity.Id = -1;
                    $scope.isNew = true;


                }
                else {
                    if (response2.Data.JLSignedBy) {
                        //$scope.isEditable = false;
                        $scope.url_sign = signFiles + response.Data.PICId + ".jpg";
                        $scope.PIC = response.Data.PIC;
                        $scope.signDate = moment(new Date(response.Data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                    }
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
    $scope.$on('onSign', function (event, prms) {

        if (prms.doc == 'asr')
            flightService.signDocLocal(prms, prms.doc).then(function (response) {
                // $scope.isEditable = false;
                // $scope.isLockVisible = false;
                $scope.url_sign = signFiles + prms.PICId + ".jpg";
                $scope.PIC = prms.PIC;
                $scope.signDate = moment(new Date(prms.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

    });
    $scope.$on('InitAsrAdd', function (event, prms) {


        $scope.tempData = null;




        $scope.tempData = prms;


        $scope.popup_add_visible = true;

    });

}]);


'use strict';
app.controller('vrAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$http', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $http) {
    $scope.isNew = true;
    $scope.isEditable = false;
    $scope.isLockVisible = false;
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
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Sign', icon: 'fas fa-signature', onClick: function (e) {
                        if ($rootScope.getOnlineStatus()) {
                            $rootScope.checkInternet(function (st) {
                                if (st) {
                                    var data = { FlightId: $scope.entity.FlightId, documentType: 'vr' };

                                    $rootScope.$broadcast('InitSignAdd', data);
                                }
                                else {
                                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                                }
                            });


                        }
                        else {
                            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                        }

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'logadd', onClick: function (e) {

                        $scope.entity.EFBFlightIrregularities = [];
                        $scope.entity.EFBReasons = [];
                        $scope.entity.Irregularities = [];
                        if ($scope.irr_100111) {
                            $scope.entity.Irregularities.push(100111);
                            $scope.entity.EFBFlightIrregularities.push({ IrrId: 100111 });
                        }
                        if ($scope.irr_100112) {
                            $scope.entity.Irregularities.push(100112);
                            $scope.entity.EFBFlightIrregularities.push({ IrrId: 100112 });
                        }
                        if ($scope.irr_100113) {
                            $scope.entity.Irregularities.push(100113);
                            $scope.entity.EFBFlightIrregularities.push({ IrrId: 100113 });
                        }
                        if ($scope.irr_100114) {
                            $scope.entity.Irregularities.push(100114);
                            $scope.entity.EFBFlightIrregularities.push({ IrrId: 100114 });
                        }
                        if ($scope.irr_100115) {
                            $scope.entity.Irregularities.push(100115);
                            $scope.entity.EFBFlightIrregularities.push({ IrrId: 100115 });
                        }
                        $scope.entity.Reasons = [];
                        if ($scope.re_100119) {
                            $scope.entity.Reasons.push(100119);
                            $scope.entity.EFBReasons.push({ ReasonId: 100119 });
                        }

                        if ($scope.re_100120) {
                            $scope.entity.Reasons.push(100120);
                            $scope.entity.EFBReasons.push({ ReasonId: 100120 });
                        }

                        if ($scope.re_100121) {
                            $scope.entity.Reasons.push(100121);
                            $scope.entity.EFBReasons.push({ ReasonId: 100121 });
                        }

                        if ($scope.re_100122) {
                            $scope.entity.Reasons.push(100122);
                            $scope.entity.EFBReasons.push({ ReasonId: 100122 });
                        }

                        if ($scope.re_100123) {
                            $scope.entity.Reasons.push(100123);
                            $scope.entity.EFBReasons.push({ ReasonId: 100123 });
                        }

                        if ($scope.re_100124) {
                            $scope.entity.Reasons.push(100124);
                            $scope.entity.EFBReasons.push({ ReasonId: 100124 });
                        }

                        if ($scope.re_100125) {
                            $scope.entity.Reasons.push(100125);
                            $scope.entity.EFBReasons.push({ ReasonId: 100125 });
                        }

                        if ($scope.re_100126) {
                            $scope.entity.Reasons.push(100126);
                            $scope.entity.EFBReasons.push({ ReasonId: 100126 });
                        }

                        if ($scope.re_100127) {
                            $scope.entity.Reasons.push(100127);
                            $scope.entity.EFBReasons.push({ ReasonId: 100127 });
                        }

                        if ($scope.re_100128) {
                            $scope.entity.Reasons.push(100128);
                            $scope.entity.EFBReasons.push({ ReasonId: 100128 });
                        }



                        //flightService.saveVoyageReport($scope.entity).then(function (res) {
                        //    $scope.popup_add_visible = false;
                        //})
                        $scope.entity.User = $rootScope.userTitle;
                        $scope.loadingVisible = true;
                        flightService.saveVR($scope.entity).then(function (response2) {
                            $scope.loadingVisible = false;

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
            $rootScope.IsRootSyncEnabled = true;
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
            fullScreen: 'isFullScreen',
            title: 'popup_add_title',
            height: 'popup_height',
            width: 'popup_width',
            'toolbarItems[1].visible': 'isEditable',
            'toolbarItems[0].visible': 'isLockVisible',

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
            var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;

            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetVRByFlight($scope.entity.FlightId).then(function (response2) {
                $scope.isEditable = (diff <= 24);
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
    $scope.isLockVisible = false;
    $scope.bind = function () {
        $scope.entity.FlightId = $scope.tempData.FlightId;
        if ($rootScope.getOnlineStatus()) {
            $rootScope.checkInternet(function (st) {
                if (st) {
                    flightService.checkLock($scope.entity.FlightId, 'vr').then(function (response) {
                        $scope.isLockVisible = false;
                        if (response.IsSuccess && response.Data.canLock) {
                            $scope.isLockVisible = true;
                        }
                    }, function (err) { });
                }
                else {
                    General.ShowNotifyBottom("The application cannot connect to the Server. Please check your internet connection.", 'error');
                }
            });

        }



        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;
            $scope.isEditable = (diff <= 24);
            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetVRByFlight($scope.entity.FlightId).then(function (response2) {

                $scope.loadingVisible = false;
                if (!response2.Data) {
                    $scope.entity.Id = -1;
                    $scope.isNew = true;


                }
                else {
                    if (response2.Data.JLSignedBy) {
                        // $scope.isEditable = false;
                        $scope.url_sign = signFiles + response.Data.PICId + ".jpg";
                        $scope.PIC = response.Data.PIC;
                        $scope.signDate = moment(new Date(response.Data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                    }
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
    $scope.scroll_vradd_height = $(window).height() - 130;
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
    $scope.$on('onSign', function (event, prms) {

        if (prms.doc == 'vr')
            flightService.signDocLocal(prms, prms.doc).then(function (response) {
                // $scope.isEditable = false;
                //   $scope.isLockVisible = false;
                $scope.url_sign = signFiles + prms.PICId + ".jpg";
                $scope.PIC = prms.PIC;
                $scope.signDate = moment(new Date(prms.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

    });
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



 
'use strict';
app.controller('drAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window) {
    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = true;
    $scope.isEditable = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;

    $scope.entity = {
        Id: -1,
        ActualWXDSP: false,
        ActualWXCPT: false,
        WXForcastDSP: false,

        WXForcastCPT: false,
        SigxWXDSP: false,
        SigxWXCPT: false,
        WindChartDSP: false,
        WindChartCPT: false,
        NotamDSP: false,
        NotamCPT: false,
        ComputedFligthPlanDSP: false,
        ComputedFligthPlanCPT: false,
        ATCFlightPlanDSP: false,
        ATCFlightPlanCPT: false,
        PermissionsDSP: false,
        PermissionsCPT: false,
        JeppesenAirwayManualDSP: false,
        JeppesenAirwayManualCPT: false,
        MinFuelRequiredDSP: false,
        MinFuelRequiredCPT: false,
        GeneralDeclarationDSP: false,
        GeneralDeclarationCPT: false,
        FlightReportDSP: false,
        FlightReportCPT: false,
        TOLndCardsDSP: false,
        TOLndCardsCPT: false,
        LoadSheetDSP: false,
        LoadSheetCPT: false,
        FlightSafetyReportDSP: false,
        FlightSafetyReportCPT: false,
        AVSECIncidentReportDSP: false,
        AVSECIncidentReportCPT: false,
        OperationEngineeringDSP: false,
        OperationEngineeringCPT: false,
        VoyageReportDSP: false,
        VoyageReportCPT: false,
        PIFDSP: false,
        PIFCPT: false,
        GoodDeclarationDSP: false,
        GoodDeclarationCPT: false,
        IPADDSP: false,
        IPADCPT: false,
    };

    $scope.chb_ActualWXDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.ActualWXDSP',
        }
    };

    $scope.chb_ActualWXCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.ActualWXCPT',
        }
    };

    $scope.txt_ActualWXCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.ActualWXCPTRemark',
        }
    };

    $scope.chb_WXForcastDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.WXForcastDSP',
        }
    };

    $scope.chb_WXForcastCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.WXForcastCPT',
        }
    };

    $scope.txt_WXForcastCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.WXForcastCPTRemark',
        }
    };

    $scope.chb_SigxWXDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.SigxWXDSP',
        }
    };

    $scope.chb_SigxWXCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.SigxWXCPT',
        }
    };

    $scope.txt_SigxWXCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.SigxWXCPTRemark',
        }
    };

    $scope.chb_WindChartDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.WindChartDSP',
        }
    };

    $scope.chb_WindChartCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.WindChartCPT',
        }
    };

    $scope.txt_WindChartCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.WindChartCPTRemark',
        }
    };

    $scope.chb_NotamDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.NotamDSP',
        }
    };

    $scope.chb_NotamCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.NotamCPT',
        }
    };

    $scope.txt_NotamCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.NotamCPTRemark',
        }
    };

    $scope.chb_ComputedFligthPlanDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.ComputedFligthPlanDSP',
        }
    };

    $scope.chb_ComputedFligthPlanCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.ComputedFligthPlanCPT',
        }
    };

    $scope.txt_ComputedFligthPlanCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.ComputedFligthPlanCPTRemark',
        }
    };

    $scope.chb_ATCFlightPlanDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.ATCFlightPlanDSP',
        }
    };

    $scope.chb_ATCFlightPlanCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.ATCFlightPlanCPT',
        }
    };

    $scope.txt_ATCFlightPlanCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.ATCFlightPlanCPTRemark',
        }
    };

    $scope.chb_PermissionsDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.PermissionsDSP',
        }
    };

    $scope.chb_PermissionsCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.PermissionsCPT',
        }
    };

    $scope.txt_PermissionsCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.PermissionsCPTRemark',
        }
    };

    $scope.chb_JeppesenAirwayManualDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.JeppesenAirwayManualDSP',
        }
    };

    $scope.chb_JeppesenAirwayManualCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.JeppesenAirwayManualCPT',
        }
    };

    $scope.txt_JeppesenAirwayManualCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.JeppesenAirwayManualCPTRemark',
        }
    };

    $scope.chb_MinFuelRequiredDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.MinFuelRequiredDSP',
        }
    };

    $scope.chb_MinFuelRequiredCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.MinFuelRequiredCPT',
        }
    };
    //dool
    $scope.txt_MinFuelRequiredCFP = {
        min: 0,
        bindingOptions: {
            value: 'entity.MinFuelRequiredCFP',
        }
    };

    $scope.txt_MinFuelRequiredPilotReq = {
        min: 0,
        bindingOptions: {
            value: 'entity.MinFuelRequiredPilotReq',
        }
    };

    $scope.chb_GeneralDeclarationDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.GeneralDeclarationDSP',
        }
    };

    $scope.chb_GeneralDeclarationCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.GeneralDeclarationCPT',
        }
    };

    $scope.txt_GeneralDeclarationCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.GeneralDeclarationCPTRemark',
        }
    };

    $scope.chb_FlightReportDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.FlightReportDSP',
        }
    };

    $scope.chb_FlightReportCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.FlightReportCPT',
        }
    };

    $scope.txt_FlightReportCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.FlightReportCPTRemark',
        }
    };

    $scope.chb_TOLndCardsDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.TOLndCardsDSP',
        }
    };

    $scope.chb_TOLndCardsCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.TOLndCardsCPT',
        }
    };

    $scope.txt_TOLndCardsCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.TOLndCardsCPTRemark',
        }
    };

    $scope.chb_LoadSheetDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.LoadSheetDSP',
        }
    };

    $scope.chb_LoadSheetCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.LoadSheetCPT',
        }
    };

    $scope.txt_LoadSheetCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.LoadSheetCPTRemark',
        }
    };

    $scope.chb_FlightSafetyReportDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.FlightSafetyReportDSP',
        }
    };

    $scope.chb_FlightSafetyReportCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.FlightSafetyReportCPT',
        }
    };

    $scope.txt_FlightSafetyReportCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.FlightSafetyReportCPTRemark',
        }
    };


    $scope.chb_AVSECIncidentReportDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.AVSECIncidentReportDSP',
        }
    };

    $scope.chb_AVSECIncidentReportCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.AVSECIncidentReportCPT',
        }
    };

    $scope.txt_AVSECIncidentReportCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.AVSECIncidentReportCPTRemark',
        }
    };

    $scope.chb_OperationEngineeringDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.OperationEngineeringDSP',
        }
    };

    $scope.chb_OperationEngineeringCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.OperationEngineeringCPT',
        }
    };

    $scope.txt_OperationEngineeringCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.OperationEngineeringCPTRemark',
        }
    };

    $scope.chb_VoyageReportDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.VoyageReportDSP',
        }
    };

    $scope.chb_VoyageReportCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.VoyageReportCPT',
        }
    };

    $scope.txt_VoyageReportCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.VoyageReportCPTRemark',
        }
    };

    $scope.chb_PIFDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.PIFDSP',
        }
    };

    $scope.chb_PIFCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.PIFCPT',
        }
    };

    $scope.txt_PIFCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.PIFCPTRemark',
        }
    };

    $scope.txt_GoodDeclarationCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.GoodDeclarationCPTRemark',
        }
    };

    $scope.chb_GoodDeclarationDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.GoodDeclarationDSP',
        }
    };

    $scope.chb_GoodDeclarationCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.GoodDeclarationCPT',
        }
    };

    $scope.GoodDeclarationCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.GoodDeclarationCPTRemark',
        }
    };

    $scope.chb_IPADDSP = {
        text: '',
        readOnly: true,
        bindingOptions: {
            value: 'entity.IPADDSP',
        }
    };

    $scope.chb_IPADCPT = {
        text: '',
        bindingOptions: {
            value: 'entity.IPADCPT',
        }
    };

    $scope.txt_IPADCPTRemark = {
        text: '',
        bindingOptions: {
            value: 'entity.IPADCPTRemark',
        }
    };



    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_height = '100%';
    $scope.popup_width = '100%';
    $scope.popup_add_title = 'Dispatch Release';
    $scope.popup_instance = null;

    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [
            {
                widget: 'dxButton', location: 'before', options: {
                    type: 'default', text: 'Sign', icon: 'fas fa-signature', onClick: function (e) {
                        if ($rootScope.getOnlineStatus()) {
                            $rootScope.checkInternet(function (st) {
                                if (st) {
                                    var data = { FlightId: $scope.entity.FlightId, documentType: 'dr' };

                                    $rootScope.$broadcast('InitSignAdd', data);
                                }
                                else {
                                    General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                                }
                            });
                            //$scope.entity.Id

                        }
                        else {
                            General.ShowNotify("You are OFFLINE.Please check your internet connection", 'error');
                        }

                    }
                }, toolbar: 'bottom'
            },
            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', validationGroup: 'dradd', onClick: function (e) {

                        $scope.entity.User = $rootScope.userTitle;

                        $scope.loadingVisible = true;
                        flightService.saveDR($scope.entity).then(function (response2) {
                            $scope.loadingVisible = false;
                            if (response2.IsSuccess) {
                                General.ShowNotify(Config.Text_SavedOk, 'success');
                                console.log('DR', response2.Data);
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
            $rootScope.$broadcast('onDrAddHide', null);
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
            'toolbarItems[0].visible': 'isLockVisible',
            'toolbarItems[1].visible': 'isEditable',

        }
    };



    /////////////////////////////////

    $scope.flight = null;
    $scope.fill = function (data) {
        $scope.entity = data;

        $scope.entity.ActualWXDSP = true;

        $scope.entity.WXForcastDSP = true;


        $scope.entity.SigxWXDSP = true;

        $scope.entity.WindChartDSP = true;

        $scope.entity.NotamDSP = true;

        $scope.entity.ComputedFligthPlanDSP = true;

        $scope.entity.ATCFlightPlanDSP = true;

        $scope.entity.PermissionsDSP = true;

        $scope.entity.JeppesenAirwayManualDSP = true;

        $scope.entity.MinFuelRequiredDSP = true;

        $scope.entity.GeneralDeclarationDSP = true;

        $scope.entity.FlightReportDSP = true;

        $scope.entity.TOLndCardsDSP = true;

        $scope.entity.LoadSheetDSP = true;

        $scope.entity.FlightSafetyReportDSP = true;

        $scope.entity.AVSECIncidentReportDSP = true;

        $scope.entity.OperationEngineeringDSP = true;

        $scope.entity.VoyageReportDSP = true;

        $scope.entity.PIFDSP = true;

        $scope.entity.GoodDeclarationDSP = true;

        $scope.entity.IPADDSP = true;


    };
    $scope.isLockVisible = false;
    $scope.bind = function () {
        $scope.entity.FlightId = $scope.tempData.FlightId;

        if ($rootScope.getOnlineStatus()) {
            $rootScope.checkInternet(function (st) {
                if (st) {
                    flightService.checkLock($scope.entity.FlightId, 'dr').then(function (response) {
                        $scope.isLockVisible = false;
                        if (response.IsSuccess && response.Data.canLock) {
                            $scope.isLockVisible = true;
                        }
                    }, function (err) { });
                }
                else {
                    General.ShowNotifyBottom("The application cannot connect to the Server. Please check your internet connection.", 'error');
                }
            });

        }

        $scope.loadingVisible = true;

        flightService.epGetFlightLocal($scope.entity.FlightId).then(function (response) {

            $scope.loadingVisible = false;
            var diff = Math.abs((new Date()).getTime() - (new Date(response.Data.STALocal)).getTime()) / 3600000;

            $scope.flight = response.Data;

            $scope.loadingVisible = true;

            flightService.epGetDRByFlight($scope.entity.FlightId).then(function (response2) {

                $scope.loadingVisible = false;

                $scope.isEditable = (diff <= 24);

                if (!response2.Data) {

                    $scope.isNew = true;
                    $scope.entity = {
                        Id: -1,
                        ActualWXDSP: true,
                        ActualWXCPT: false,
                        WXForcastDSP: true,

                        WXForcastCPT: false,
                        SigxWXDSP: true,
                        SigxWXCPT: false,
                        WindChartDSP: true,
                        WindChartCPT: false,
                        NotamDSP: true,
                        NotamCPT: false,
                        ComputedFligthPlanDSP: true,
                        ComputedFligthPlanCPT: false,
                        ATCFlightPlanDSP: true,
                        ATCFlightPlanCPT: false,
                        PermissionsDSP: true,
                        PermissionsCPT: false,
                        JeppesenAirwayManualDSP: true,
                        JeppesenAirwayManualCPT: false,
                        MinFuelRequiredDSP: true,
                        MinFuelRequiredCPT: false,
                        GeneralDeclarationDSP: true,
                        GeneralDeclarationCPT: false,
                        FlightReportDSP: true,
                        FlightReportCPT: false,
                        TOLndCardsDSP: true,
                        TOLndCardsCPT: false,
                        LoadSheetDSP: true,
                        LoadSheetCPT: false,
                        FlightSafetyReportDSP: true,
                        FlightSafetyReportCPT: false,
                        AVSECIncidentReportDSP: true,
                        AVSECIncidentReportCPT: false,
                        OperationEngineeringDSP: true,
                        OperationEngineeringCPT: false,
                        VoyageReportDSP: true,
                        VoyageReportCPT: false,
                        PIFDSP: true,
                        PIFCPT: false,
                        GoodDeclarationDSP: true,
                        GoodDeclarationCPT: false,
                        IPADDSP: true,
                        IPADCPT: false,
                    };
                    $scope.entity.FlightId = $scope.tempData.FlightId;

                }
                else {
                    if (response2.Data.JLSignedBy) {
                        //$scope.isEditable = false;

                        $scope.url_sign = signFiles + response.Data.PICId + ".jpg";
                        $scope.PIC = response2.Data.PIC;
                        $scope.signDate = moment(new Date(response2.Data.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
                    }
                    if (response2.Data.Alert) {
                        General.Confirm("The document updated by " + response2.Data.Alert + ". Would you like to get edited report?", function (res) {
                            if (res) {

                                //var dto = { Id: $scope.ati_flight.ID, };
                                $scope.loadingVisible = true;
                                flightService.epReplaceDR(response2.Data.server).then(function (res) {

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





        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
    };
    ////////////////////////////////
    $scope.scroll_dradd_height = '100%';
    $scope.scroll_dradd = {
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
            height: 'scroll_dradd_height'
        }

    };
    /////////////////////////////////
    $scope.tempData = null;
    $scope.$on('onSign', function (event, prms) {

        if (prms.doc == 'dr')
            flightService.signDocLocal(prms, prms.doc).then(function (response) {
                // $scope.isEditable = false;
                // $scope.isLockVisible = false;
                $scope.url_sign = signFiles + prms.PICId + ".jpg";
                $scope.PIC = prms.PIC;
                $scope.signDate = moment(new Date(prms.JLDatePICApproved)).format('YYYY-MM-DD HH:mm');
            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

    });
    $scope.$on('InitDrAdd', function (event, prms) {



        $scope.tempData = null;

        $scope.tempData = prms;


        $scope.popup_add_visible = true;

    });

}]);