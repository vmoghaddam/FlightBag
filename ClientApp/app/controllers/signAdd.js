'use strict';
app.controller('signAddController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window) {
    $scope.isNew = true;
    $scope.isContentVisible = false;
    $scope.isFullScreen = false;
    var detector = new MobileDetect(window.navigator.userAgent);

    if (detector.mobile() && !detector.tablet())
        $scope.isFullScreen = true;



    ////////////////////////
    $scope.popup_add_visible = false;
    $scope.popup_height = '560';
    $scope.popup_width = '400';
    $scope.popup_add_title = 'Sign & Approve (1.1)';
    $scope.popup_instance = null;

    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

            {
                widget: 'dxButton', location: 'after', options: {
                    type: 'default', text: 'Save', icon: 'check', onClick: function (e) {
                        //$scope.tempData.FlightId;
                        General.Confirm('Are you sure?', function (res) {
                            if (res) {
                                
                                if ($scope.documentType == 'jlog') {
                                    var dto = {
                                        flightId: $scope.tempData.FlightId.join('_'),
                                        doc: $scope.documentType,
                                        pic: $scope.commander.CrewId,
                                        picStr: $scope.commander.Name,
                                        user: $rootScope.employeeId,
                                    };
                                    $scope.loadingVisible = true;
                                    flightService.signDocJL(dto).then(function (response2) {
                                        $scope.loadingVisible = false;
                                        if (response2.IsSuccess) {
                                            flightService.signDocLocalJL(response2.Data).then(function (response) {
                                                General.ShowNotify(Config.Text_SavedOk, 'success');

                                                $scope.popup_add_visible = false;
                                            }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
                                           
                                        }


                                    }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

                                   
                                }
                                else if ($scope.documentType == 'ofpsall') {
                                    $scope.loadingVisible = true;
                                    $.each($scope.tempData.FlightId, function (_i, _fid) {
                                        
                                        var dto = {
                                            flightId: _fid,
                                            doc: 'ofp',
                                            pic: $scope.commander.CrewId,
                                            picStr: $scope.commander.Name,
                                            user: $rootScope.employeeId,
                                        };
                                       
                                        flightService.signDoc(dto).then(function (response2) {
                                            $scope.loadingVisible = false;
                                            if (response2.IsSuccess) {
                                               // console.log('OFP SIGNNED   '+_fid, response2.Data);
                                              //  response2.Data.doc = $scope.documentType;
                                              //  $rootScope.$broadcast('onSign', response2.Data);
                                              //  $scope.popup_add_visible = false;
                                            }


                                        }, function (err) { });
                                        /////////////// 
                                    });
                                    General.ShowNotify(Config.Text_SavedOk, 'success');
                                    $scope.loadingVisible = false;
                                    $scope.popup_add_visible = false;
                                     

                                }
                                else {
                                    var dto = {
                                        flightId: $scope.entity.FlightId,
                                        doc: $scope.documentType,
                                        pic: $scope.commander.CrewId,
                                        picStr: $scope.commander.Name,
                                        user: $rootScope.employeeId,
                                    };
                                    $scope.loadingVisible = true;
                                    flightService.signDoc(dto).then(function (response2) {
                                        $scope.loadingVisible = false;
                                        if (response2.IsSuccess) {
                                            General.ShowNotify(Config.Text_SavedOk, 'success');
                                            response2.Data.doc = $scope.documentType;
                                            $rootScope.$broadcast('onSign', response2.Data);
                                            $scope.popup_add_visible = false;
                                        }


                                    }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });
                                }
                                
                            }
                        });
                        



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

            $scope.popup_add_visible = false;
            $rootScope.$broadcast('onSignAddHide', null);
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

     
    $scope.scroll_signadd = {
        width: '100%',
        height: 320,
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
        

    };


    /////////////////////////////////
    $scope.entity = {};
    $scope.flight = null;
    $scope.commander = null;
    $scope.commanders = null;
    $scope.bind = function () {
        $scope.documentType = $scope.tempData.documentType;
        var fid = $scope.tempData.FlightId;

        $scope.entity.FlightId = $scope.tempData.FlightId;
        if ($scope.documentType == 'jlog' || $scope.documentType == 'ofpsall') {
            fid = $scope.tempData.FlightId[0];
            $scope.entity.FlightId = $scope.tempData.FlightId[0];
        }
        
        $scope.loadingVisible = true;

        flightService.epGetFlightCommanders(fid).then(function (response) {

            $scope.loadingVisible = false;
            if (response.IsSuccess && response.Data) {
                console.log('commanders', response.Data);
                $scope.commander = response.Data.commander;
                $scope.commanders = response.Data.commanders;
                $scope.url_sign = signFiles + $scope.commander.CrewId + ".jpg";

            }

        }, function (err) { $scope.loadingVisible = false; General.ShowNotify(err.message, 'error'); });

    };
    /////////////////////////////////
    $scope.tempData = null;
    $scope.$on('InitSignAdd', function (event, prms) {



        $scope.tempData = null;

        $scope.tempData = prms;


        $scope.popup_add_visible = true;

    });

}]);