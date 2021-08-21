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
               
               
                if ($rootScope.isServerMode)
                    deferred.resolve(response.data);
                else if (response.data.IsSuccess)
                    db.sync.SyncAppCrewFlightsByDateRange(df, dt, response.data.Data, function (syncResult) {
                         

                        deferred.resolve(syncResult);
                    });
                   // deferred.resolve(response.data);



            }, function (err, status) {

                deferred.reject(Exceptions.getMessage(err));
            });
        }
        else if (!$rootScope.isServerMode) {
            db.GetAppCrewFlightsByDates(df, dt, function (results) {

                var response = {};
                response.Data = results;
                response.IsSuccess = 1;
                console.log('fetch offline-flights', response);
                deferred.resolve(response);
            });
        }
        else {
            deferred.resolve({ Data: [], IsSuccess: 0 });
        }


        return deferred.promise;





    };

    var _epGetCrewCalendar = function (cid, from, to) {

        var deferred = $q.defer();
        if ($rootScope.online) {
            $http.get($rootScope.apiUrl + 'crew/calendar/' + cid + '/' + from + '/' + to /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                //alert('y');

                if ($rootScope.isServerMode)
                    deferred.resolve(response.data);
                else if (response.data.IsSuccess)
                    db.sync.SyncCalendar(from, to, response.data.Data, function (syncResult) {

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
            $http.post($rootScope.apiUrl + 'flight/log/check', dto).then(function (response) {
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
            JLUserId: $rootScope.employeeId,
            IsSynced: 1,
        };
        if ($rootScope.getOnlineStatus()) {
            $http.post($rootScope.apiUrl + 'flight/log/save', entity).then(function (response) {
                changes.JLDate = momentFromatLocalUTC(response.data.Data);
               // alert(entity.FlightId);
                 
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

            FuelRemaining: entity.FuelRemaining,
            FuelUplift: entity.FuelUplift,
            FuelUsed: entity.FuelUsed,
            FuelDensity: entity.FuelDensity,
            FuelTotal: entity.FuelTotal,

            PaxAdult: entity.PaxAdult,
            PaxChild: entity.PaxChild,
            PaxInfant: entity.PaxInfant,
            PaxTotal: entity.PaxTotal,

            BaggageWeight: entity.BaggageWeight,
            CargoWeight: entity.CargoWeight,

            SerialNo: entity.SerialNo,
            LTR: entity.LTR,
            PF: entity.PF,

            RVSM_GND_CPT: entity.RVSM_GND_CPT,
            RVSM_GND_STBY: entity.RVSM_GND_STBY,
            RVSM_GND_FO: entity.RVSM_GND_FO,

            RVSM_FLT_CPT: entity.RVSM_FLT_CPT,
            RVSM_FLT_STBY: entity.RVSM_FLT_STBY,
            RVSM_FLT_FO: entity.RVSM_FLT_FO,

            CommanderNote: entity.CommanderNote,

            AttRepositioning1: entity.AttRepositioning1,
            AttRepositioning2: entity.AttRepositioning2,

            Version: entity.Version,
            JLDate: momentFromatLocalUTC(entity.JLDate),

            DelayBlockOff: entity.DelayBlockOff,
            BlockTime: entity.BlockTime,
            FlightTime: entity.FlightTime,
            IsSynced: 1,

            JLUserId: $rootScope.employeeId,
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

    var _updateTAFs = function (fdpId) {
        var deferred = $q.defer();
        $http.get($rootScope.apiUrlExt + 'weather/taf/adds/FDP/' + fdpId).then(function (response) {
            if (!response.data.IsSuccess) { deferred.reject("TAF ERROR"); alert('error2'); }
            db.sync.SyncTAF(fdpId, response.data.Data, function (dbData) {
                deferred.resolve(dbData);
            });

        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });
        return deferred.promise;
    };
    var _updateMETARs = function (fdpId) {
        var deferred = $q.defer();
        $http.get($rootScope.apiUrlExt + 'weather/metar/adds/FDP/' + fdpId).then(function (response) {
            if (!response.data.IsSuccess)
                deferred.reject("METAR ERROR");
            db.sync.SyncMETAR(fdpId, response.data.Data, function (dbData) {
                deferred.resolve(dbData);
            });

        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });
        return deferred.promise;
    };
    var _updateNOTAMs = function (fdpId) {
        var deferred = $q.defer();
        $http.get($rootScope.apiUrlExt + 'airport/notam/FDP/' + fdpId).then(function (response) {
            if (!response.data.IsSuccess)
                deferred.reject("NOTAM ERROR");
            db.sync.SyncNOTAM(fdpId, response.data.Data, function (dbData) {
                deferred.resolve(dbData);
            });

        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });
        return deferred.promise;
    };
    var _getTAFs = function (fdpId, flag) {
        var deferred = $q.defer();
        db.GetTAFs(fdpId, function (data) {

            var result = { IsSuccess: 1, Data: data };
            if ((!data || data.length == 0) && flag) {
                result.IsSuccess = 0;

                if ($rootScope.getOnlineStatus()) {
                    $http.get($rootScope.apiUrlExt + 'weather/taf/adds/FDP/' + fdpId).then(function (response) {
                        if (!response.data.IsSuccess) { deferred.reject("TAF ERROR"); alert('error2'); }
                        db.sync.SyncTAF(fdpId, response.data.Data, function (dbData) {
                            deferred.resolve(dbData);
                        });

                    }, function (err, status) {

                        deferred.reject(Exceptions.getMessage(err));
                    });
                }
                else
                    deferred.resolve(result);



            }
            else {

                deferred.resolve(result);
            }

        });
        return deferred.promise;

    };


    var _getMETARs = function (fdpId, flag) {
        var deferred = $q.defer();
        db.GetMETARs(fdpId, function (data) {
            var result = { IsSuccess: 1, Data: data };
            if ((!data || data.length == 0) && flag) {
                result.IsSuccess = 0;

                if ($rootScope.getOnlineStatus()) {
                    $http.get($rootScope.apiUrlExt + 'weather/metar/adds/FDP/' + fdpId).then(function (response) {
                        if (!response.data.IsSuccess)
                            deferred.reject("METAR ERROR");
                        db.sync.SyncMETAR(fdpId, response.data.Data, function (dbData) {
                            deferred.resolve(dbData);
                        });

                    }, function (err, status) {

                        deferred.reject(Exceptions.getMessage(err));
                    });
                }
                else
                    deferred.resolve(result);


            }
            else {

                deferred.resolve(result);
            }

        });
        return deferred.promise;
        //var deferred = $q.defer();
        //$http.get($rootScope.apiUrl + 'weather/metar/adds/FDP/' + fdpId).then(function (response) {
        //    if (!response.data.IsSuccess)
        //        deferred.reject("METAR ERROR");
        //    db.sync.SyncMETAR(fdpId, response.data.Data, function (dbData) {
        //        deferred.resolve(dbData);
        //    });

        //}, function (err, status) {

        //    deferred.reject(Exceptions.getMessage(err));
        //});

        //return deferred.promise;
    };


    var _getNOTAMs = function (fdpId, flag) {
        var deferred = $q.defer();
        db.GetNOTAMs(fdpId, function (data) {
            var result = { IsSuccess: 1, Data: data };
            if ((!data || data.length == 0) && flag) {
                result.IsSuccess = 0;

                if ($rootScope.getOnlineStatus()) {
                    $http.get($rootScope.apiUrlExt + 'airport/notam/FDP/' + fdpId).then(function (response) {
                        if (!response.data.IsSuccess)
                            deferred.reject("NOTAM ERROR");
                        db.sync.SyncNOTAM(fdpId, response.data.Data, function (dbData) {
                            deferred.resolve(dbData);
                        });

                    }, function (err, status) {

                        deferred.reject(Exceptions.getMessage(err));
                    });
                }
                else
                    deferred.resolve(result);



            }
            else {

                deferred.resolve(result);
            }

        });
        return deferred.promise;
        //var deferred = $q.defer();


        //return deferred.promise;
    };

    var _epReplaceASR = function (item) {
        var deferred = $q.defer();
        db.Clear("ASRs", function () {
            item.IsSynced = 1;
            item.Alert = null;
            item.server = null;
            db.Put('ASRs', item.Id, item, function (dbitem) {
                deferred.resolve(dbitem);
            });
        });
        return deferred.promise;
    };
    var _epGetASRByFlight = function (flightId) {
        var deferred = $q.defer();
        db.GetASRsByFlightId(flightId, function (_dbitem) {
            var dbitem = _dbitem && _dbitem.length > 0 ? _dbitem[0] : null;
            if ($rootScope.getOnlineStatus()) {

                $http.get($rootScope.apiUrl + 'asr/flight/' + flightId /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                    if (response.data.IsSuccess && response.data.Data) {
                        var _dbdate = !dbitem?0: Number(dbitem.DateUpdate);
                        var _serverdate = Number(response.data.Data.DateUpdate);
                         
                        if (!dbitem || (dbitem.IsSynced == 1 && _serverdate >= _dbdate) ) {
                            //update local

                            db.Clear("ASRs", function () {
                                response.data.Data.IsSynced = 1;
                                db.Put('ASRs', response.data.Data.Id, response.data.Data, function (dbitem) {
                                    deferred.resolve(response.data);
                                });
                            });
                        }
                        else if (dbitem.IsSynced == 0 && _serverdate > _dbdate) {
                            dbitem.Alert = response.data.Data.User;
                            dbitem.server = response.data.Data;
                            deferred.resolve({ IsSuccess: 1, Data: dbitem });
                        }
                        else if (dbitem.IsSynced == 0 && _serverdate <= _dbdate){
                            deferred.resolve({ IsSuccess: 1, Data: dbitem });
                        }
                        else {

                            deferred.resolve({ IsSuccess: 1, Data: dbitem });
                        }
                        //alert(_dbdate + '    ' + _serverdate);
                        //deferred.resolve({ IsSuccess: 1, Data: dbitem });
                    }
                    else
                        deferred.resolve({ IsSuccess: 1, Data: dbitem });
                });



            }
            else {
                var data = { IsSuccess: 1, Data: dbitem };
               
                deferred.resolve(data);
            }
        });

        return deferred.promise;
    };
    var _epGetASRByFlight2 = function (flightId) {
        var deferred = $q.defer();
        db.GetASRsByFlightId(flightId, function (_dbitem) {
            var dbitem = _dbitem && _dbitem.length > 0 ? _dbitem[0] : null;
            console.log('asr get bd', dbitem);
            if ((dbitem && dbitem.IsSynced == 0) || !$rootScope.getOnlineStatus()) {
                var data = { IsSuccess: 1, Data: dbitem  };
                console.log('asr local',data);
                deferred.resolve(data);
            }
            else {
                if ($rootScope.getOnlineStatus()) {
                    $http.get($rootScope.apiUrl + 'asr/flight/' + flightId /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                        if (response.data.IsSuccess && response.data.Data) {
                            db.Clear("ASRs", function () {
                                response.data.Data.IsSynced = 1;
                                db.Put('ASRs', response.data.Data.Id, response.data.Data, function (dbitem) {
                                    deferred.resolve(response.data);
                                });
                            });
                        }
                        else
                            deferred.resolve(response.data);
                        
                        
                    }, function (err, status) {

                        deferred.reject(Exceptions.getMessage(err));
                    });
                }
                else {
                    var data = { IsSuccess: 1, Data: dbitem };
                    deferred.resolve(data);
                }
               
            }
        });
     
       

        return deferred.promise;
    };

    var _saveASR = function (entity) {
        var pk = entity.Id;
        var deferred = $q.defer();
        entity.IsSynced = 1;
        db.Put('ASRs', entity.Id, entity, function (row) {
            if ($rootScope.getOnlineStatus()) {
                 entity.OccurrenceDate = moment(new Date( entity.OccurrenceDate)).format('YYYY-MM-DD-HH-mm');
                $http.post($rootScope.apiUrl + 'asr/save', entity).then(function (response) {
                    if (response.data.IsSuccess) {
                        //deferred.resolve(response.data);
                        var item = response.data.Data;
                        item.IsSynced = 1;
                        db.Delete('ASRs', pk, function () {
                            db.Put('ASRs', item.Id, item, function (dbitem) {
                                deferred.resolve({Data: dbitem, IsSuccess: 1 });
                            });
                        });

                    }
                    else
                        deferred.resolve(response.data);
                    
                }, function (err, status) {

                    deferred.reject(Exceptions.getMessage(err));
                });
            }
            else {
                row.IsSynced = 0;
                db.deSyncedItem('ASRs', entity.Id, function () {
                    deferred.resolve({ Data: row, IsSuccess: 1 });
                });
            }
        });
        return deferred.promise;

        //var deferred = $q.defer();
        //$http.post($rootScope.apiUrl + 'asr/save', entity).then(function (response) {
        //    deferred.resolve(response.data);
        //}, function (err, status) {

        //    deferred.reject(Exceptions.getMessage(err));
        //});

        //return deferred.promise;
    };
    ////////////////////////////////////////
    var _epReplaceVR = function (item) {
        var deferred = $q.defer();
        db.Clear("VRs", function () {
            item.IsSynced = 1;
            item.Alert = null;
            item.server = null;
            db.Put('VRs', item.Id, item, function (dbitem) {
                deferred.resolve(dbitem);
            });
        });
        return deferred.promise;
    };
    var _epGetVRByFlight = function (flightId) {
        var deferred = $q.defer();
        db.GetVRsByFlightId(flightId, function (_dbitem) {
           
            var dbitem = _dbitem && _dbitem.length > 0 ? _dbitem[0] : null;
            if ($rootScope.getOnlineStatus()) {

                $http.get($rootScope.apiUrl + 'voyage/flight/' + flightId /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
                    if (response.data.IsSuccess && response.data.Data) {
                        var _dbdate = !dbitem ? 0 : Number(dbitem.DateUpdate);
                        var _serverdate = Number(response.data.Data.DateUpdate);
                        
                        if (!dbitem || (dbitem.IsSynced == 1 && _serverdate >= _dbdate)) {
                            //update local
                           
                            db.Clear("VRs", function () {
                                response.data.Data.IsSynced = 1;
                                db.Put('VRs', response.data.Data.Id, response.data.Data, function (dbitem) {
                                    deferred.resolve(response.data);
                                });
                            });
                        }
                        else if (dbitem.IsSynced == 0 && _serverdate > _dbdate) {
                           
                            dbitem.Alert = response.data.Data.User;
                            dbitem.server = response.data.Data;
                            deferred.resolve({ IsSuccess: 1, Data: dbitem });
                        }
                        else if (dbitem.IsSynced == 0 && _serverdate <= _dbdate) {
                             
                            deferred.resolve({ IsSuccess: 1, Data: dbitem });
                        }
                        else {
                           
                            deferred.resolve({ IsSuccess: 1, Data: dbitem });
                        }

                        //alert(_dbdate + '    ' + _serverdate);
                        //deferred.resolve({ IsSuccess: 1, Data: dbitem });
                    }
                    else
                        deferred.resolve({ IsSuccess: 1, Data: dbitem });
                });



            }
            else {
                var data = { IsSuccess: 1, Data: dbitem };

                deferred.resolve(data);
            }
        });

        return deferred.promise;
    };
    var _saveVR = function (entity) {
        var pk = entity.Id;
        var deferred = $q.defer();
        entity.IsSynced = 1;
        db.Put('VRs', entity.Id, entity, function (row) {
            if ($rootScope.getOnlineStatus()) {
                //entity.OccurrenceDate = moment(new Date(entity.OccurrenceDate)).format('YYYY-MM-DD-HH-mm');
                $http.post($rootScope.apiUrl + 'voyage/save', entity).then(function (response) {
                    if (response.data.IsSuccess) {
                        //deferred.resolve(response.data);
                        var item = response.data.Data;
                        item.IsSynced = 1;
                        db.Delete('VRs', pk, function () {
                            db.Put('VRs', item.Id, item, function (dbitem) {
                                deferred.resolve({ Data: dbitem, IsSuccess: 1 });
                            });
                        });

                    }
                    else
                        deferred.resolve(response.data);

                }, function (err, status) {

                    deferred.reject(Exceptions.getMessage(err));
                });
            }
            else {
                row.IsSynced = 0;
                db.deSyncedItem('VRs', entity.Id, function () {
                    deferred.resolve({ Data: row, IsSuccess: 1 });
                });
            }
        });
        return deferred.promise;

        
    };
    //////////////////////////////////
      
    var _epGetVRByFlight2 = function (flightId) {

        var deferred = $q.defer();
        $http.get($rootScope.apiUrl + 'voyage/flight/' + flightId /*+ '?from=' + _df + '&to=' + _dt*/).then(function (response) {
            deferred.resolve(response.data);
        }, function (err, status) {

            deferred.reject(Exceptions.getMessage(err));
        });

        return deferred.promise;
    };

    var _saveVR2 = function (entity) {
        var pk = entity.Id;
        var deferred = $q.defer();
        entity.IsSynced = 1;
        db.Put('VRs', entity.Id, entity, function (row) {
            if ($rootScope.getOnlineStatus()  ) {
                $http.post($rootScope.apiUrl + 'voyage/save', entity).then(function (response) {
                    if (response.data.IsSuccess) {
                        //deferred.resolve(response.data);
                        var item = response.data.Data;
                        db.Delete('VRs', pk, function () {
                            db.Put('VRs', item.Id, item, function (dbitem) {
                                deferred.resolve({ Data: dbitem, IsSuccess: 1 });
                            });
                        });

                    }
                    else
                        deferred.resolve(response.data);

                }, function (err, status) {

                    deferred.reject(Exceptions.getMessage(err));
                });
            }
            else {
                row.IsSynced = 0;
                db.deSyncedItem('VRs', entity.Id, function () {
                    deferred.resolve({ Data: row, IsSuccess: 1 });
                });
            }
        });
        return deferred.promise;
        //var deferred = $q.defer();
        //$http.post($rootScope.apiUrl + 'voyage/save', entity).then(function (response) {
        //    deferred.resolve(response.data);
        //}, function (err, status) {

        //    deferred.reject(Exceptions.getMessage(err));
        //});

        //return deferred.promise;
    };
    //////////////////////////////////
    serviceFactory.epGetASRByFlight = _epGetASRByFlight;
    serviceFactory.saveASR = _saveASR;
    serviceFactory.epGetVRByFlight = _epGetVRByFlight;
    serviceFactory.saveVR = _saveVR;
    serviceFactory.epReplaceASR = _epReplaceASR;
    serviceFactory.epReplaceVR = _epReplaceVR;


    serviceFactory.updateTAFs = _updateTAFs;
    serviceFactory.updateMETARs = _updateMETARs;
    serviceFactory.updateNOTAMs = _updateNOTAMs;
    serviceFactory.getTAFs = _getTAFs;
    serviceFactory.getMETARs = _getMETARs;
    serviceFactory.getNOTAMs = _getNOTAMs;
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