'use strict';
app.controller('imageviewerController', ['$scope', '$location', 'flightService', 'authService', '$routeParams', '$rootScope', '$window', '$q', '$sce', function ($scope, $location, flightService, authService, $routeParams, $rootScope, $window, $q, $sce) {
    $scope.isFullScreen = true;
    $scope.cWidth = $(window).width() - 100;
    $scope.scroll_height = $(window).height() - 100;

    $scope.url = "https://localhost:5001/Upload/Weather/SIGWX/ADDS/SIGWX_ADDS_20210819_2105.png";
    $scope.scroll_width = '100%';
    $scope.scroll_view = {
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
            height: 'scroll_height',
            width: 'scroll_width'
        }

    };

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
    $scope.popup_add_title = 'Viewer';
    $scope.popup_instance = null;
    $scope.popup_add = {


        showTitle: true,

        toolbarItems: [


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
            $('#frame').height($(window).height() - 120);
            //https://apoc.ir/download/2021-08-01.pdf
            var url = ('https://apoc.ir/download/2021-08-01.pdf');
            $scope._url = $sce.trustAsResourceUrl('pdfjsmodule/viewer.html?file=' + url);

            //var $images = $('.docs-pictures');

            //$images.viewer({
            //    //inline: false,
            //    //viewed: function () {
            //    //    $image.viewer('zoomTo', 1);
            //    //}
            //});
            ////var $img = $("#image").imgViewer();

        },
        onHiding: function () {

            //$scope.clearEntity();

            $scope.popup_add_visible = false;

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

    ////////////////////////////
    var appWindow = angular.element($window);
    appWindow.bind('resize', function () {
        $scope.$apply(function () {
            // $scope.leftHeight = $(window).height() - 135;
            // $scope.rightHeight = $(window).height() - 135 - 45;
        });
    });
    $scope.tempData = null;
    $scope.$on('InitImageViewer', function (event, prms) {


        $scope.tempData = prms;

        $scope.popup_add_visible = true;

    });
    //////////////////////////////

}]);


