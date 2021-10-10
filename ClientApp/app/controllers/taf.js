'use strict';
app.controller('tafController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$q', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $q) {
    $scope.isFullScreen = true;
    $scope.isContentVisible = true;

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

    $scope.popup_add_visible = false;
    $scope.popup_add_title = 'TAF';
    $scope.popup_instance = null;
    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [

 

    {
        widget: 'dxButton', location: 'after', options: {
            type: 'default', text: 'Update', icon: 'check', validationGroup: 'metarupdate', onClick: function (e) {

                if (!$rootScope.getOnlineStatus()) {
                    alert('You are OFFLINE.Please check your internet connection.');
                    return;
                }
                $scope.loadingVisible = true;
                flightService.updateTAFs($scope.fdp.FDPId).then(function (response) {
                    $scope.loadingVisible = false;
                    $scope.tempData.TAF = response.Data;
                    $scope.fdp.TAF = response.Data;


                    $scope.filtered = Enumerable.From($scope.fdp.TAF)
                        .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                        .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                            return Number(moment(new Date(x.IssueTime)).format('YYMMDDHHmm'));

                        }).ToArray();



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

        if ($scope.isFullScreen)
            //  $scope.scrollHeight = $(window).height() - 230;
            $scope.scrollStyle = { height: ($(window).height() - 230).toString() + 'px' };
        else
            $scope.scrollStyle = { height: ($scope.popup_height - 195).toString() + 'px' };
        //  $scope.scrollHeight = 200;



    },
    onHiding: function () {

        //$scope.clearEntity();

        $scope.popup_add_visible = false;
        $rootScope.$broadcast('onTAFHide', null);
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


$scope.scroll_left_height = $(window).height() - 200;
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
        height: 'scroll_left_height'
    }

};

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
        height: 'scroll_left_height'
    }

};
$scope.stations = [];
$scope.selectedStations = [];
$scope.getStationClass = function (x) {
    var index = $scope.selectedStations.indexOf(x);
    if (index != -1)
        return "station selected";
    else
        return "station";
};
$scope.stationClick = function (x) {
    var index = $scope.selectedStations.indexOf(x);
    if (index != -1)
        $scope.selectedStations.splice(index, 1);
    else
        $scope.selectedStations.push(x);

    $scope.filtered = Enumerable.From($scope.fdp.TAF)
        .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
        .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
            return Number(moment(new Date(x.IssueTime)).format('YYMMDDHHmm'));

        }).ToArray();

};


$scope.selectedObj = null;
$scope.showObj = function (item, n, $event) {

    $scope.selectedObj = item;


};
$scope.getObjClass = function (flt) {

    if (!$scope.selectedObj || $scope.selectedObj.Id != flt.Id)
        return "";
    else
        return "selected-obj";
    //return flt.FlightStatus.toLowerCase();
}

$scope.filtered = [];
$scope.bind = function () {
    $scope.fdp = $scope.tempData;
    $scope.stations = [];
    $.each($scope.fdp.items, function (_i, _d) {
        $scope.stations.push(_d.FromAirportIATA);
        $scope.stations.push(_d.ToAirportIATA);
        if (_d.ALT1)
            $scope.stations.push(_d.ALT1);
        if (_d.ALT2)
            $scope.stations.push(_d.ALT2);

    });
    $scope.stations = Enumerable.From($scope.stations).Distinct().ToArray();
    $scope.selectedStations = Enumerable.From($scope.stations).ToArray();
    $scope.filtered = Enumerable.From($scope.fdp.TAF).OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
        return Number(moment(new Date(x.IssueTime)).format('YYMMDDHHmm'));

    }).ToArray();

    //////////////////////
    //////////////////////
    if ($rootScope.getOnlineStatus()) {
        flightService.updateTAFs($scope.fdp.FDPId).then(function (response) {

            $scope.tempData.TAF = response.Data;
            $scope.fdp.TAF = response.Data;


            $scope.filtered = Enumerable.From($scope.fdp.TAF)
                .Where(function (x) { return $scope.selectedStations.indexOf(x.StationId) != -1; })
                .OrderBy(function (x) { return $scope.stations.indexOf(x.StationId); }).ThenByDescending(function (x) {
                    return Number(moment(new Date(x.IssueTime)).format('YYMMDDHHmm'));

                }).ToArray();



        }, function (err) { });
    }
    
    ////////////////////
    //////////////////////

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
$scope.$on('InitTAF', function (event, prms) {


    $scope.tempData = prms;

    $scope.popup_add_visible = true;

});
    //////////////////////////////

}]);  
