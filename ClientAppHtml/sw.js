const cacheName = 'cache-v1001';
const assets = [
    '/',
     '/pwa.js',
   // '/offline.html',
    '/index.html',
    'manifest.json',
     
    'app/views/calendar.html?vx=2',
    'app/views/logAdd.html?vx=2',
     'app/views/flights.html?vx=2' ,
    'app/views/header.html?vx=2',
    'app/views/menu.html?vx=2',
    '/app/views/login.html?vx=2',
    '/app/views/home.html?vx=2',
    //'app/views/logAdd.html',
    'app/views/footer.html?vx=2',
    '/app/app.js?vx=2',
    '/app/db.js?vx=2',
    '/content/css/bootstrap.css',
    '/content/css/w3.css',
    '/content/css/ionicons.css',
    '/content/css/dx.common.css',
    '/content/css/dx.material.material-teal-dark.css',
    '/content/css/fontawsome2.css',
   
    '/content/css/loading-bar.css',
    '/content/css/social-buttons.css',
    '/content/css/persian-datepicker.min.css',
    '/content/css/main.css?vx=2',
    '/content/css/core-ui.css',
    '/content/css/dx-hack.css?vx=2',
    '/content/css/icons/dxiconsmaterial.woff2',
    '/content/css/fonts/Roboto-400.woff2',
    '/content/css/fonts/Roboto-300.woff2',
    '/content/css/fonts/Roboto-300.woff',
    '/content/css/fonts/Roboto-300.ttf',
    '/scripts/jquery-3.1.0.js',

    '/scripts/jszip.min.js',
    '/scripts/angular-1.7.2.js',
    '/scripts/angularjs-sanitize.js',
    '/scripts/angular-route-1.7.2.js',
    '/scripts/angular-animate.js',
    '/scripts/angular-local-storage.min.js',
    '/scripts/loading-bar.min.js',
    '/scripts/linq.min.js',
    '/scripts/moment-with-locales.min.js',
    '/scripts/persian-date.min.js',
    '/scripts/persian-datepicker.min.js',
    '/scripts/dx.all.js',
    '/scripts/mobile-detect.min.js',
    '/scripts/custom-tooltip.js',
    '/scripts/config.js?vx=2',
    '/scripts/core.js?vx=2',
    '/scripts/kit.fontawsome.js',
    '/scripts/dexie.js',
    '/app/services/authInterceptorService.js?vx=2',
    '/app/services/authService.js?vx=2',
    '/app/services/activityService.js?vx=2',

    '/app/services/testService.js?vx=2',
    '/app/services/tokensManagerService.js?vx=2',
    '/app/services/generalService.js?vx=2',
    '/app/services/notificationService.js?vx=2',
    '/app/services/libraryService.js?vx=2',
    '/app/services/flightService.js?vx=2',
    '/app/controllers/indexController.js?vx=2',
    //'/app/controllers/appsController.js',
     '/app/controllers/footerController.js?vx=2',
     '/app/controllers/homeController.js?vx=2',
    '/app/controllers/loginController.js?vx=2',
   // '/app/controllers/signupController.js',

   // '/app/controllers/filterController.js',



    //'/app/controllers/refreshController.js',
    //'/app/controllers/tokensManagerController.js',
    //'/app/controllers/associateController.js',

    //'/app/controllers/appLibraryController.js',
    //'/app/controllers/appLibraryItemController.js',

    //'/app/controllers/appCertificateController.js',
    //'/app/controllers/fdpsController.js',
    //'/app/controllers/fdpController.js',
    //'/app/controllers/appCourseController.js',

    //'/app/controllers/appMessageItemController.js',
    //'/app/controllers/appMessageController.js',

    //'/app/controllers/appDocumentItemController.js',
    //'/app/controllers/appDocumentController.js',
    //'/app/controllers/appDocumentOtherController.js',
    //'/app/controllers/flightController.js',
    //'/app/controllers/flightStatsController.js',
    //'/app/controllers/flightLogBookController.js',

    //'/app/controllers/flightNewController.js',

    //'/app/controllers/passwordChangeController.js',
    //'/app/controllers/register1Controller.js',
    //'/app/controllers/register0Controller.js',
    //'/app/controllers/profileController.js',
     '/app/controllers/logAdd.js?vx=2',
    //'/app/controllers/reports.js',
    //'/app/controllers/docViewer.js',

    '/app/controllers/epLogBook.js?vx=2', 
    '/app/controllers/calendarController.js?vx=2', 
    

    //'/app/controllers/pdfViewer.js',
    //'/app/controllers/reportViewer.js',
    
    '/content/css/free-v4-font-face.min.css',
    '/content/css/free.min.css',
    '/content/css/free-v4-shims.min.css',
    '/content/css/css_roboto_300_400_500_700.css',
   // 'https://fonts.googleapis.com/earlyaccess/notokufiarabic.css',
    '/content/css/free-fa-solid-900.woff2',
    '/content/css/free-fa-regular-400.woff2',
    '/content/css/KFOlCnqEu92Fr1MmEU9fBBc4.woff2',
    '/content/css/KFOmCnqEu92Fr1Mu4mxK.woff2',
    '/content/css/KFOlCnqEu92Fr1MmWUlfBBc4.woff2',
    '/content/css/KFOlCnqEu92Fr1MmSU5fBBc4.woff2',

    '/content/webfonts/fa-solid-900.woff2',
    '/content/webfonts/fa-regular-400.woff2',
    '/content/webfonts/fa-solid-900.woff',
    '/content/webfonts/fa-regular-400.woff',
    '/content/webfonts/fa-solid-900.ttf',
    '/content/webfonts/fa-regular-400.ttf',
    
     
    '/images/icons/icon-72x72.png',
    '/images/icons/icon-96x96.png',
    '/images/icons/icon-128x128.png',
    '/images/icons/icon-144x144.png',
    '/images/icons/icon-152x152.png',
    '/images/icons/icon-192x192.png',
    '/images/icons/icon-384x384.png',
    '/images/icons/icon-512x512.png',
    '/content/images/logo-white.png',


   
    
];

self.addEventListener('install', e => {
    self.skipWaiting();
    e.waitUntil(
        caches.open(cacheName).then(cache => {
           // console.log('cache assets');
            cache.addAll(assets);
            
        })
    ); 
    
    
}); 

//activate eve
self.addEventListener('activate', evt => {
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== cacheName)
                .map(key => caches.delete(key))
            )
        })
    );
});

self.addEventListener('fetch', function (event) {
    // either respond with the cached object or go ahead and fetch the actual url
    event.respondWith(
        caches.match(event.request).then(function (response) {
            if (response) {
                // retrieve from cache
                //console.log('cache', response);
                return response;
            }
            // fetch as normal
            return fetch(event.request);
        })
    );
});