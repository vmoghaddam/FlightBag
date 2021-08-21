'use strict';
app.factory('flightService', ['$http', '$q', 'ngAuthSettings', '$rootScope', function ($http, $q, ngAuthSettings, $rootScope) {
    var serviceFactory = {};

    //"odata/fdp/crew/dates"
    var _getCrewFDPs = function (id, df, dt) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/fdp/crew/dates/' + id + '?from=' + _df + '&to=' + _dt).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getCrewFDPsDuties = function (id, df, dt) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/duties/crew/dates/' + id + '?from=' + _df + '&to=' + _dt).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getCrewFDPsFlights = function (id, df, dt) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/flights/crew/dates/' + id + '?from=' + _df + '&to=' + _dt).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getCrewFDPsFTL = function (id, df, dt) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/ftl/crew/dates/' + id + '?from=' + _df + '&to=' + _dt).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getCrewFDP = function (id) {

        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/fdp/crew/single/' + id).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };


    var _getCrewFlights = function (id, df, dt) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/crew/flights/app/' + id + '?from=' + _df + '&to=' + _dt).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    //[Route("odata/crew/flights/crew/fdp/{crewid}/{fdpid}")]
    var _getCrewFlightsByFDP = function (cid, fid) {

        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/crew/flights/crew/fdp/' + cid + '/' + fid).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getCrewFlightsReport = function (id, df, dt, airline, fromapt, toapt, status) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        //public async Task<IHttpActionResult> GetCrewFlightsReportApp2(DateTime from, DateTime to, int id,int? airline=null,int? status=null,int? fromAirport=null,int? toAirport=null)
        var deferred = $q.defer();
        var url = serviceBase + 'odata/crew/report/flights/app2/' + id + '?from=' + _df + '&to=' + _dt;
        if (airline)
            url += '&airline=' + airline;
        if (status)
            url += '&status=' + status;
        if (fromapt)
            url += '&fromAirport=' + fromapt;
        if (toapt)
            url += '&toAirport=' + toapt;
        $http.get(url).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getCrewFlightsGrouped = function (id) {

        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/crew/report/flights/app/grouped/' + id).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getFlightCrews = function (id) {

        var deferred = $q.defer();
        $http.get(serviceBase + 'odata/flight/crews/new/' + id).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _saveFDP = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/create', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _saveDuty = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/duty/create', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _addFlightToFDP = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/flight/add', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _updateCPFDP = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/update', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _updateFlightFDP = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/flight/update', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _updateFlightFDPDirect = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/flight/update/direct', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _removeFlightFromFDP = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/flight/remove', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _updateFlightStatus = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/flight/status', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _updateFDPTimes = function (entity) {
        var deferred = $q.defer();
        $http.post($rootScope.serviceUrl + 'odata/cp/fdp/rt', entity).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _getFlight = function (id) {
        var offset = -1 * (new Date()).getTimezoneOffset();
        var url = serviceBase + 'odata/cp/flight/' + id + '/' + offset;

        var deferred = $q.defer();
        $http.get(url).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };


    var _getSun = function () {
        var offset = -1 * (new Date()).getTimezoneOffset();
        var url = 'https://api.sunrise-sunset.org/json?lat=35.715298&lng=51.404343';

        var deferred = $q.defer();
        $http.get(url).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _getSunFlight = function (df, dt, fid, tid) {
        var _df = moment(df).format('YYYY-MM-DDTHH:mm:ss');
        var _dt = moment(dt).format('YYYY-MM-DDTHH:mm:ss');
        //public async Task<IHttpActionResult> GetCrewFlightsReportApp2(DateTime from, DateTime to, int id,int? airline=null,int? status=null,int? fromAirport=null,int? toAirport=null)
        var deferred = $q.defer();
        var url = serviceBase + 'odata/time/sunflight/' + '?dep=' + _df + '&arr=' + _dt + '&fid=' + fid + '&tid=' + tid;
        //public async Task<IHttpActionResult> GetSunFlight (DateTime dep, DateTime arr,string fid,string tid)
        $http.get(url).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    ///////////////////////////////
    var _epGetCrewFlights = function (df, dt) {

        var deferred = $q.defer();
        if ($rootScope.online) {
            $http.get($rootScope.apiUrl + 'crew/flights/' + df + '/' + dt /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                //alert('y');
               
                if ($rootScope.isServerMode)
                    deferred.resolve(response.data);
                else if (response.data.IsSuccess)
                    db.sync.SyncAppCrewFlightsByDateRange(df, dt, response.data.Data, function (syncResult) {
                        //alert('x');
                         
                        deferred.resolve(syncResult);
                    });



            }, function (err, status) {

                deferred.reject(Exceptions.getMessage(err));
            });
        }
        else if (!$rootScope.isServerMode) {
            db.GetAppCrewFlightsByDates(df, dt, function (results) {
               
                var response = {};
                response.Data = results;
                response.IsSuccess = 1;
                console.log('fetch offline-flights',response);
                deferred.resolve(response);
            });
        }
        else {
            deferred.resolve({ Data: [], IsSuccess: 0 });
        }


        return deferred.promise;





    };

    var _epGetCrewCalendar = function (cid,from,to) {

        var deferred = $q.defer();
        if ($rootScope.online) {
            $http.get($rootScope.apiUrl + 'crew/calendar/' + cid + '/' + from+'/'+to /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                //alert('y');
                
                if ($rootScope.isServerMode)
                    deferred.resolve(response.data);
                else if (response.data.IsSuccess)
                    db.sync.SyncCalendar(from,to,response.data.Data, function (syncResult) {
                         
                        deferred.resolve(syncResult);
                    });



            }, function (err, status) {

                deferred.reject(Exceptions.getMessage(err));
            });
        }
        else if (!$rootScope.isServerMode) {
            db.GetCalendar(from, to, function (results) {
                console.log('fetch offline');
                var response = {};
                response.Data = results;
                response.IsSuccess = 1;
                deferred.resolve(response);
            });
        }
        else {
            deferred.resolve({ Data: [], IsSuccess: 0 });
        }


        return deferred.promise;





    };

    var _epGetCrewDuties = function (cid, from, to) {

        var deferred = $q.defer();
        if ($rootScope.online) {
            $http.get($rootScope.apiUrl + 'crew/duties/' + cid + '/' + from + '/' + to + '/1' /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                //alert('y');

                if ($rootScope.isServerMode)
                    deferred.resolve(response.data);
                else if (response.data.IsSuccess)
                    db.sync.SyncDuties(from, to, response.data.Data, function (syncResult) {

                        deferred.resolve(syncResult);
                    });



            }, function (err, status) {

                deferred.reject(Exceptions.getMessage(err));
            });
        }
        else if (!$rootScope.isServerMode) {
            db.GetDuties(from, to, function (results) {
                console.log('fetch offline');
                var response = {};
                response.Data = results;
                response.IsSuccess = 1;
                deferred.resolve(response);
            });
        }
        else {
            deferred.resolve({ Data: [], IsSuccess: 0 });
        }


        return deferred.promise;





    };


    var _epGetFlightCrews = function (flightId) {
        //db.sync.SyncFlightCrews
        var deferred = $q.defer();
        //$http.get($rootScope.apiUrl + 'flight/crews/' + flightId ).then(function (response) {
        //    deferred.resolve(response.data);
        //}, function (err, status) {

        //    deferred.reject(Exceptions.getMessage(err));
        //});

        if ($rootScope.online) {
            $http.get($rootScope.apiUrl + 'flight/crews/' + flightId).then(function (response) {
                if ($rootScope.isServerMode)
                    deferred.resolve(response.data);
                else if (response.data.IsSuccess)
                    db.sync.SyncFlightCrews(flightId, response.data.Data, function (syncResult) {

                        deferred.resolve(syncResult);
                    });



            }, function (err, status) {

                deferred.reject(Exceptions.getMessage(err));
            });
        }
        else if (!$rootScope.isServerMode) {
            db.GetFlightCrews(flightId, function (results) {
                console.log('_epGetFlightCrews', 'fetch offline');
                var response = {};
                response.Data = results;
                response.IsSuccess = 1;
                deferred.resolve(response);
            });
        }
        else {
            deferred.resolve({ Data: [], IsSuccess: 0 });
        }

        return deferred.promise;
    };

    var _epGetFlight = function (flightId) {

        var deferred = $q.defer();
        $http.get($rootScope.apiUrl + 'flight/' + flightId /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };
    var _epGetFlightLocal = function (flightId) {

        var deferred = $q.defer();
        db.GetAppFlightCrew(flightId).then(function (flt) {
            var data = {};
            data.IsSuccess = 0;
            if (flt)
                data.IsSuccess = 1;
            data.Data = flt;
            
            deferred.resolve(data);
        });


        return deferred.promise;
    };

    var _calculateFlight = function (flt) {
        flt.BlockTime = null;
        flt.FlightTime = null;
        flt.DelayBlockOff = null;
        if (flt.BlockOff && flt.BlockOn)
            flt.BlockTime = getMinutesDiff(flt.BlockOff, flt.BlockOn);
        if (flt.TakeOff && flt.Landing)
            flt.FlightTime = getMinutesDiff(flt.TakeOff, flt.Landing);
        if (flt.BlockOff)
            flt.DelayBlockOff = getMinutesDiff(flt.STD, flt.BlockOff);

    };
    var _epGetFlightDelays = function (flightId) {

        var deferred = $q.defer();
        $http.get($rootScope.apiUrl + 'flight/delays/' + flightId /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _epCheckLog = function (dto) {
        var deferred = $q.defer();
        if ($rootScope.getOnlineStatus()) {
            $http.post($rootScope.apiUrl + 'flight/log/check',dto).then(function (response) {
                deferred.resolve(response.data);
            }, function (err, status) {

                //deferred.reject(Exceptions.getMessage(err));
                deferred.resolve(dto);
            });
        }
        else {
            deferred.resolve(dto);
        }
        return deferred.promise;
    };
    var _epSaveLogOverwriteServer = function (entity) {
        var deferred = $q.defer();
        var changes = {
             
            JLDate: momentFromatLocalUTC(entity.JLDate),
            JLUserId:   $rootScope.employeeId,
             IsSynced: 1,
        };
        if ($rootScope.getOnlineStatus()) {
            $http.post($rootScope.apiUrl + 'flight/log/save', entity).then(function (response) {
                changes.JLDate = momentFromatLocalUTC(response.data.Data);
                db.Update('AppCrewFlights', entity.FlightId, changes, function (row2) {
                    deferred.resolve({ Data: row2, IsSuccess: 1 });
                });
               
            }, function (err, status) {
                    deferred.resolve({ Data: err, IsSuccess: 0 });

            });
        }
        else {
            deferred.resolve({ Data: 'Operation Failed. Check your Network Connection.', IsSuccess: 0 });
        }
         
        return deferred.promise;


    };
    var _epSaveLog = function (entity) {
        var deferred = $q.defer();
        var changes = {
            //BlockOff: toIsoDateTime(entity.BlockOff),
            //BlockOn: toIsoDateTime(entity.BlockOn),
            //TakeOff: toIsoDateTime(entity.TakeOff),
            //Landing: toIsoDateTime(entity.Landing),
            BlockOff: momentFromatLocalUTC(entity.BlockOffDate),
            BlockOn: momentFromatLocalUTC(entity.BlockOnDate),
            TakeOff: momentFromatLocalUTC(entity.TakeOffDate),
            Landing: momentFromatLocalUTC(entity.LandingDate),

            FuelRemaining : entity.FuelRemaining,
            FuelUplift : entity.FuelUplift,
            FuelUsed : entity.FuelUsed,
            FuelDensity: entity.FuelDensity,
            FuelTotal: entity.FuelTotal,

            PaxAdult: entity.PaxAdult,
            PaxChild: entity.PaxChild,
            PaxInfant: entity.PaxInfant,
            PaxTotal: entity.PaxTotal,

            BaggageWeight : entity.BaggageWeight,
            CargoWeight : entity.CargoWeight,

            SerialNo : entity.SerialNo,
            LTR : entity.LTR,
            PF : entity.PF,

            RVSM_GND_CPT : entity.RVSM_GND_CPT,
            RVSM_GND_STBY : entity.RVSM_GND_STBY,
            RVSM_GND_FO : entity.RVSM_GND_FO,

            RVSM_FLT_CPT : entity.RVSM_FLT_CPT,
            RVSM_FLT_STBY : entity.RVSM_FLT_STBY,
            RVSM_FLT_FO : entity.RVSM_FLT_FO,

            CommanderNote : entity.CommanderNote,



            Version: entity.Version,
            JLDate: momentFromatLocalUTC(entity.JLDate),
           
            DelayBlockOff: entity.DelayBlockOff,
            BlockTime: entity.BlockTime,
            FlightTime: entity.FlightTime,
            IsSynced: 1,

            JLUserId:$rootScope.employeeId,
        };
        //var row = db.Update('AppCrewFlights', entity.FlightId, changes, function () { });
        //console.log('row',row);
        db.Update('AppCrewFlights', entity.FlightId, changes, function (row) {
           // _calculateFlight(row);

            if ($rootScope.getOnlineStatus() && entity.Server) {
                $http.post($rootScope.apiUrl + 'flight/log/save', entity).then(function (response) {

                    var dateChanges = { JLDate: momentFromatLocalUTC(response.data.Data) };
                    db.Update('AppCrewFlights', entity.FlightId, dateChanges, function (row2) {
                        deferred.resolve({ Data: row2, IsSuccess: 1 });
                    });
                   
                }, function (err, status) {
                    //desynced
                    row.IsSynced = 0;
                    db.deSyncedItem('AppCrewFlights', entity.FlightId, function () {
                        deferred.resolve({ Data: row, IsSuccess: 1 });
                    });

                });
            }
            else {
                //desynced
                row.IsSynced = 0;
                db.deSyncedItem('AppCrewFlights', entity.FlightId, function () {
                    deferred.resolve({ Data: row, IsSuccess: 1 });
                });

            }
        });





        return deferred.promise;
    };

    var _epSyncFlight = function (entity) {
        entity.IsSynced = 1;
        var deferred = $q.defer();
        entity.JLDate = momentFromatLocalUTC(entity.JLDate);
        db.sync.SyncCrewFlight(entity, function (row) {
            deferred.resolve({ Data: row, IsSuccess: 1 });
        });
        return deferred.promise;
    };
    //////////////////////////////////
    serviceFactory.epGetCrewFlights = _epGetCrewFlights;

    serviceFactory.epGetFlightCrews = _epGetFlightCrews;
    serviceFactory.epGetFlight = _epGetFlight;
    serviceFactory.epGetFlightLocal = _epGetFlightLocal;
    serviceFactory.epGetFlightDelays = _epGetFlightDelays; 
    serviceFactory.epSaveLog = _epSaveLog;
    serviceFactory.epCheckLog = _epCheckLog;
    serviceFactory.epSyncFlight = _epSyncFlight;
    serviceFactory.epSaveLogOverwriteServer = _epSaveLogOverwriteServer;

    serviceFactory.epGetCrewCalendar = _epGetCrewCalendar;
    serviceFactory.epGetCrewDuties = _epGetCrewDuties;

    ///////////////////////////////////

    serviceFactory.getSun = _getSun;
    serviceFactory.getSunFlight = _getSunFlight;
    serviceFactory.getFlight = _getFlight;
    serviceFactory.updateFDPTimes = _updateFDPTimes;
    serviceFactory.removeFlightFromFDP = _removeFlightFromFDP;
    serviceFactory.updateFlightStatus = _updateFlightStatus;
    serviceFactory.getCrewFDPs = _getCrewFDPs;
    serviceFactory.getCrewFDP = _getCrewFDP;
    serviceFactory.getCrewFlights = _getCrewFlights;
    serviceFactory.getCrewFlightsByFDP = _getCrewFlightsByFDP;
    serviceFactory.getCrewFlightsReport = _getCrewFlightsReport;
    serviceFactory.getCrewFlightsGrouped = _getCrewFlightsGrouped;
    serviceFactory.getFlightCrews = _getFlightCrews;
    serviceFactory.addFlightToFDP = _addFlightToFDP;
    serviceFactory.updateCPFDP = _updateCPFDP;
    serviceFactory.updateFlightFDP = _updateFlightFDP;
    serviceFactory.updateFlightFDPDirect = _updateFlightFDPDirect;
    serviceFactory.saveFDP = _saveFDP;
    serviceFactory.saveDuty = _saveDuty;
    serviceFactory.getCrewFDPsFTL = _getCrewFDPsFTL;
    serviceFactory.getCrewFDPsFlights = _getCrewFDPsFlights;
    serviceFactory.getCrewFDPsDuties = _getCrewFDPsDuties;
    return serviceFactory;

}]);