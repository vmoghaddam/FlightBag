const dbName = "CrewPocketDb";
 
var _db = new Dexie(dbName);
db = {};
db.getDb = function () {
    return _db;
};
db.Init = function () {
    _db.version(61).stores({
        AppCrewFlights: "Id,FlightId,CrewId,FDPId,FDPItemId,DutyType,IsPositioning,PositionId,Position,FlightNumber,STDDay,FlightStatusId,Register,RegisterId,FromAirportIATA,ToAirportIATA,STD,STA,BlockOff,BlockOn,TakeOff,Landing,IStart,IsSynced",
        FlightCrews: "[CrewId+FlightId],FDPItemId,FDPId",
        Calendar: "[Id+Date],DateStart,Legs,Sectors,DutyType,DutyTypeTitle,Year,Month,Day",
        Duties: "[Id+Date],DateStart,DutyType,DutyTypeTitle,Year,Month,Day,DateConfirmed,UPD,ConfirmedBy,UserName,IStart,IsSynced,GroupId",
        Auth: "UserName,Password",
        TAFs: "Id,StationId,FDPId,DateDay",
        METARs: "Id,StationId,FDPId,DateDay",
        NOTAMs: "Id,StationId,FDPId,DateDay",
        ASRsX: "Id,FlightId,IsSynced",
        ASRs: "Id,FlightId,IsSynced",
        ASR:"FlightId,IsSynced",
        VRs: "Id,FlightId,IsSynced",
        VR: "FlightId,IsSynced",
        DR: "FlightId,IsSynced",
         
    });
    _db.open();
};
db.GetCalendarCollection = function (from, to) {
    var _from = DateToNumber(from);
    var _to = DateToNumber(to);
    var collection = _db.Calendar
        .filter(function (rec) {
            //return true;

            //return rec.Year==year && rec.Month==month;
            
            //return   new Date(rec.DateStart).getTime() >= new Date(from).getTime()  && new Date(rec.DateStart).getTime() <= new Date(to).getTime();
            return DateToNumber(new Date(rec.DateStart)) >= _from && DateToNumber(new Date(rec.DateStart)) <= _to;
        });

    return collection;
};
db.GetDutiesCollection = function (from, to) {
    var _from = DateToNumber(from);
    var _to = DateToNumber(to);
    var collection = _db.Duties
        .filter(function (rec) {
             return DateToNumber(new Date(rec.DateStart)) >= _from && DateToNumber(new Date(rec.DateStart)) <= _to;
        });

    return collection;
};
////rec.ConfirmedBy != GlobalUserId;
db.GetDutiesUserDefinedCollection = function (from, to) { 
    var _from = DateToNumber(from);
    var _to = DateToNumber(to);
    var collection = _db.Duties
        .filter(function (rec) {
            return DateToNumber(new Date(rec.DateStart)) >= _from && DateToNumber(new Date(rec.DateStart)) <= _to && rec.ConfirmedBy == GlobalUserId;
        });

    return collection;
};
db.GetDutiesOperatorDefinedCollection = function (from, to) {
    var _from = DateToNumber(from);
    var _to = DateToNumber(to);
    var collection = _db.Duties
        .filter(function (rec) {
            return DateToNumber(new Date(rec.DateStart)) >= _from && DateToNumber(new Date(rec.DateStart)) <= _to && rec.ConfirmedBy != GlobalUserId;
        });

    return collection;
};

db.GetTAFCollection = function (fdpId) {
    
    var collection = _db.TAFs
        .filter(function (rec) {
            return rec.FDPId==fdpId;
        });

    return collection;
};
db.GetMETARCollection = function (fdpId) {

    var collection = _db.METARs
        .filter(function (rec) {
            return rec.FDPId == fdpId;
        });

    return collection;
};
db.GetNOTAMCollection = function (fdpId) {

    var collection = _db.NOTAMs
        .filter(function (rec) {
            return rec.FDPId == fdpId;
        });

    return collection;
};




db.GetTAFs = function (fdpId, callback) {
    var collection = db.GetTAFCollection(fdpId);
    collection.toArray().then(function (arg) {
        

        callback(arg);
    });
};
db.GetMETARs = function (fdpId, callback) {
    var collection = db.GetMETARCollection(fdpId);
    collection.toArray().then(function (arg) {


        callback(arg);
    });
};
db.GetNOTAMs = function (fdpId, callback) {
    var collection = db.GetNOTAMCollection(fdpId);
    collection.toArray().then(function (arg) {


        callback(arg);
    });
};

db.GetASRByFlightCollection = function (flightId) {

    var collection = _db.ASR
        .filter(function (rec) {
            return rec.FlightId == flightId;
        });

    return collection;
};
db.GetDRByFlightCollection = function (flightId) {

    var collection = _db.DR
        .filter(function (rec) {
            return rec.FlightId == flightId;
        });

    return collection;
};

db.GetASRsByFlightId = function (flightId, callback) {
    var collection = db.GetASRByFlightCollection(flightId);
    collection.toArray().then(function (arg) {


        callback(arg);
    });
};

db.GetDRsByFlightId = function (flightId, callback) {
    var collection = db.GetDRByFlightCollection(flightId);
    collection.toArray().then(function (arg) {


        callback(arg);
    });
};


db.GetVRByFlightCollection = function (flightId) {

    var collection = _db.VR
        .filter(function (rec) {
            return rec.FlightId == flightId;
        });

    return collection;
};

db.GetVRsByFlightId = function (flightId, callback) {
    var collection = db.GetVRByFlightCollection(flightId);
    collection.toArray().then(function (arg) {


        callback(arg);
    });
};


db.GetDuties = function (from, to, callback) {
    var collection = db.GetDutiesCollection(from, to);
    collection.toArray().then(function (arg) {
        console.log('caltable', arg);

        callback(arg);
    });
};

db.GetCalendar = function (from, to, callback) {
    var collection = db.GetCalendarCollection(from,to);
    collection.toArray().then(function (arg) {
        console.log('caltable',arg);

        callback(arg);
    });
};
db.DateToNumber = function (dt) {
    var str = moment(new Date(dt)).format('YYYYMMDD');
    return Number(str);
};
db.DateTimeToNumber = function (dt) {
    var str = moment(new Date(dt)).format('YYMMDDHHmmss');
    return Number(str);
};
db.GetAppCrewFlightsByDatesCollection = function (df, dt) {
    var collection= _db.AppCrewFlights
        .filter(function (flight) {
            //return true;
            
            // return (new Date(flight.STDDay).getTime() >= new Date(df).getTime()) && new Date(flight.STDDay).getTime() <= new Date(dt).getTime();
            return db.DateToNumber(flight.STDDay) >= db.DateToNumber(df) && db.DateToNumber(flight.STDDay) <= db.DateToNumber(dt);
        });
     
    return collection;
};
db.GetFlightCrewsCollection = function (fid) {
    var collection = _db.FlightCrews.filter(function (row) { return row.FlightId == fid; });
    return collection;
};
db.GetFlightCrews = function (fid,callback) {
    var collection = _db.FlightCrews.filter(function (row) { return row.FlightId == fid; });
    collection.toArray().then(function (arg) { callback(arg); });
};


////// AppCrewFlights
db.GetAppFlightCrew =   function (fid) {
    //_db.FlightCrews.filter(function (row) { return row.FlightId == fid; });
    //collection.toArray().then(function (arg) { callback(arg); });
    return _db.AppCrewFlights.get(fid);
     //   .then(function (arg) {
     //   callback(arg);
     //});
   
};
db.GetAppCrewFlightsByDates = function (df, dt,callback) {
    var collection = db.GetAppCrewFlightsByDatesCollection(df, dt);
    collection.toArray().then(function (arg) { callback(arg); });
};

db.DeleteAppCrewFlightsByDates = function (df, dt, callback) {
    var collection = db.GetAppCrewFlightsByDatesCollection(df, dt);
    collection
        .delete()
        .then(function (deleteCount) {
            console.log("Deleted " + deleteCount + " objects");
            callback(deleteCount);
        }).catch(function (err) { });
};
//db.AddBulkAppCrewFlights = function (items, callback) {
//    _db.AppCrewFlights.bulkAdd(items).then(function (lastKey) {
//        console.log("Done adding 100,000 raindrops all over the place");
//        console.log("Last raindrop's id was: " + lastKey); // Will be 100000.
//        callback();
//    }).catch(Dexie.BulkError, function (e) {
        
//        console.error('AddBulkAppCrewFlights Error',e);
//    });
//};
db.AddBulkAppCrewFlights =async  function (items) {
    var lastKey = await _db.AppCrewFlights.bulkAdd(items);
    return lastKey;
};
db._deSynced = async function (table, items) {
    items.forEach(function (item, index) {
            _db[table].update(item, { IsSynced: 0 });
    });
    
     
};
db.deSyncedItem = async function (table, key,callback) {

    _db[table].update(key, { IsSynced: 0 }).then(function (upd) { callback(); });
    

};
db.getCount = function (table, callback) {
    return _db[table].count(function (e) { callback(e); });
};
db.Update =  function (table, key, changes, callback) {
    //db.friends.update(2, { name: "Number 2" }).then(function (updated) {
    //    if (updated)
    //        console.log("Friend number 2 was renamed to Number 2");
    //    else
    //        console.log("Nothing was updated - there were no friend with primary key: 2");
    //});
   // var updated = await _db[table].update(key, changes);
   // var row = await _db[table].get(key);
   // return row;
    _db[table].update(key, changes).then(function (upd) {
        _db[table].get(key).then(function (row) {
           
            if (callback)
                callback(row);
        });
    });
};

db.Put = function (table, key, item, callback) {
     
    _db[table].put(item,key).then(function (upd) {
        _db[table].get(key).then(function (row) {
            if (callback)
                callback(row);
        });
    });
};
db.Delete = function (table, key, callback) {
    _db[table].delete(key).then(function (e) { callback(e); });
};

db.Clear = function (table, callback) {
    _db[table].clear().then(function (e) { callback(e);});
};
db.DeleteAsr = function (key, callback) {
    _db['ASR'].delete(key).then(res => {   callback(); }, rej => {   callback(); });
};
db.DeleteDr = function (key, callback) {
    _db['DR'].delete(key).then(res => { callback(); }, rej => { callback(); });
};
db.DeleteVr = function (key, callback) {
    _db['VR'].delete(key).then(res => { callback(); }, rej => { callback(); });
};

db.auth = {};
db.auth.update = function (userName, password,userData,authData, callback) {
   
    _db.Auth.clear().then(function (e) {
        
        _db.Auth.add({ UserName: userName, Password: password,UserData:userData, AuthData:authData }).then(function (e2) {
            
            if (callback)
                callback();
        });
    });
};
db.auth.getUser = function (userName,callback) {
    _db.Auth.get(userName).then(function (user) {
         
        callback(user);
    });
};


db.sync = {};

db.sync.SyncCalendar = async function (from, to, serverData, callback) {
    var deleted = await db.GetCalendarCollection(from, to).keys();
    console.log('sync cal', deleted);
    await _db.Calendar.bulkDelete(deleted);
    var pts = await _db.Calendar.bulkPut(serverData);
    var data = await db.GetCalendarCollection(from, to).toArray();
     
    callback({ Data: data, IsSuccess: 1 });
     
};
//alert(GlobalUserId);
db.sync.SyncDuties = async function (from, to, serverData, callback) {
    var collection = db.GetDutiesCollection(from, to);
     
    var userDefinedCollection = db.GetDutiesUserDefinedCollection(from, to);
    var operatorCollection = db.GetDutiesOperatorDefinedCollection(from, to);
    var deletedOperator = await operatorCollection.keys();
   
   await _db.Duties.bulkDelete(deletedOperator);

    var operatorServer = Enumerable.From(serverData).Where('$.ConfirmedBy!=' + GlobalUserId).ToArray();

    var operatorPts = await _db.Duties.bulkPut(operatorServer);
    var data = await db.GetDutiesCollection(from, to).toArray();
    //data = Enumerable.From(data).OrderBy(function (x) { }).ToArray();

    callback({ Data: data, IsSuccess: 1 });

};

db.sync.SyncTAF = async function (fdpId, serverData, callback) {
    var collection = db.GetTAFCollection(fdpId);
    var deleted = await collection.keys();
    if (deleted && deleted.length > 0) {
        await _db.TAFs.bulkDelete(deleted);
    }
    var puts = [];
    $.each(serverData, function (_i, _s) {
        _s.FDPId = fdpId;
        _s.DateCreate = momentFromatLocalUTC(_s.DateCreate);
        puts.push(_s);
    });
    var pts = await _db.TAFs.bulkAdd(puts);
    

    db.GetTAFs(fdpId, function (data) {
        callback({ Data: data, IsSuccess: 1 });
    });

   

};



db.sync.SyncMETAR = async function (fdpId, serverData, callback) {
    var collection = db.GetMETARCollection(fdpId);
    var deleted = await collection.keys();
    if (deleted && deleted.length > 0) {
        await _db.METARs.bulkDelete(deleted);
    }
    var puts = [];
    $.each(serverData, function (_i, _s) {
        _s.FDPId = fdpId;
        _s.DateCreate = momentFromatLocalUTC(_s.DateCreate);
        puts.push(_s);
    });
    var pts = await _db.METARs.bulkAdd(puts);
   

    db.GetMETARs(fdpId, function (data) {
        callback({ Data: data, IsSuccess: 1 });
    });



};


db.sync.SyncNOTAM = async function (fdpId, serverData, callback) {
    var collection = db.GetNOTAMCollection(fdpId);
    var deleted = await collection.keys();
    if (deleted && deleted.length > 0) {
        await _db.NOTAMs.bulkDelete(deleted);
    }
    var puts = [];
    $.each(serverData, function (_i, _s) {
        _s.FDPId = fdpId;
        _s.DateCreate = momentFromatLocalUTC(_s.DateCreate);
        puts.push(_s);
    });
    var pts = await _db.NOTAMs.bulkAdd(puts);


    db.GetNOTAMs(fdpId, function (data) {
        callback({ Data: data, IsSuccess: 1 });
    });



};

db.sync.SyncASR = async function (flightId, serverData, callback) {
    var collection = db.GetASRByFlightCollection(flightId);
    var allRows = await collection.toArray();
    var serverIds = Enumerable.From(serverData).Select('Number($.Id)').ToArray();
    var deleted = await collection.filter(function (asr) {
        return asr.IsSynced == 1; /*serverIds.indexOf(Number(asr.Id)) == -1;*/

    }).keys();
    if (deleted && deleted.length > 0) {
        await _db.ASR.bulkDelete(deleted);
    }
    var puts = [];
    $.each(serverData, function (_i, _s) {
        var local = Enumerable.From(allRows).Where('$.Id==' + _s.Id).FirstOrDefault();
        if (!local) {
            _s.IsSynced = 1;
            puts.push(_s);
        }
    });

    var pts = await _db.ASR.bulkAdd(puts);




    db.GetASRsByFlightId(flightId, function (data) {
        callback({ Data: data, IsSuccess: 1 });
    });



};

db.sync.SyncVR = async function (flightId, serverData, callback) {
    var collection = db.GetVRByFlightCollection(flightId);
    var allRows = await collection.toArray();
    var serverIds = Enumerable.From(serverData).Select('Number($.Id)').ToArray();
    var deleted = await collection.filter(function (vr) {
        return vr.IsSynced == 1; /*serverIds.indexOf(Number(asr.Id)) == -1;*/

    }).keys();
    if (deleted && deleted.length > 0) {
        await _db.VR.bulkDelete(deleted);
    }
    var puts = [];
    $.each(serverData, function (_i, _s) {
        var local = Enumerable.From(allRows).Where('$.Id==' + _s.Id).FirstOrDefault();
        if (!local) {
            _s.IsSynced = 1;
            puts.push(_s);
        }
    });

    var pts = await _db.VR.bulkAdd(puts);




    db.GetVRsByFlightId(flightId, function (data) {
        callback({ Data: data, IsSuccess: 1 });
    });



};


db.sync.SyncAppCrewFlightsByDateRange = async function (df, dt, serverData, callback) {
     
   // _db.AppCrewFlights.update(62205, { Version: 2 }).then(function (arg) { alert(arg); });
   // return;
    var collection = db.GetAppCrewFlightsByDatesCollection(df, dt);
    var allRows = await collection.toArray();
    var allFids = Enumerable.From(allRows).Select('Number($.Id)').ToArray();
    var serverIds = Enumerable.From(serverData).Select('Number($.Id)').ToArray();
      

    var deleted = await collection.filter(function (flight) { return serverIds.indexOf(Number(flight.Id)) == -1; }).keys();
    if (deleted && deleted.length > 0) {
        await _db.AppCrewFlights.bulkDelete(deleted);
    }

    var puts = [];
    var upds = [];
    
    $.each(serverData, function (_i, _s) {
        var local = Enumerable.From(allRows).Where('$.Id==' + _s.Id).FirstOrDefault();
        if (!local || (getTimeForSync(_s.JLDate) >= getTimeForSync(local.JLDate) && local.IsSynced==1)) {
            _s.IsSynced = 1;
            _s.JLDate = momentFromatLocalUTC(_s.JLDate);
            puts.push(_s);
        }
        else if (local /*&& getTimeForSync(_s.JLDate) < getTimeForSync(local.JLDate) && local.IsSynced*/) {
            //update
            //var upd = await _db.AppCrewFlights.update(local.Id, { IsSynced: 0 });
            //console.log('upd',upd);
            
            upds.push(local.Id);
        }
    });
    if (upds && upds.length > 0) {
        
        await db._deSynced('AppCrewFlights', upds);
    }
    if (puts && puts.length > 0) {
        var pts = await _db.AppCrewFlights.bulkPut(puts);
        console.log('puts', pts);
    }
   

    //var news = Enumerable.From(serverData).Where(function (x) { return allFids.indexOf(x.Id) == -1; }).ToArray();
    //var newsLastKey = await db.AddBulkAppCrewFlights(news);


    
   // var rows = await collection.toArray();
    //alert(rows.length);
    // console.log(rows);
    var data = await db.GetAppCrewFlightsByDatesCollection(df, dt).toArray();

    callback({Data:data,IsSuccess:1});
};
db.sync.SyncFlightCrews = async function (fid, serverData, callback) {
    //await _db.FlightCrews.clear();
    await db.GetFlightCrewsCollection(fid).delete();
    var pts = await _db.FlightCrews.bulkPut(serverData);
   
    var data = serverData; //await db.GetAppCrewFlightsByDatesCollection(df, dt).toArray();

    callback({ Data: data, IsSuccess: 1 });
};
db.sync.SyncCrewFlight = async function (flight, callback) {
    _db.AppCrewFlights.put(flight).then(function (upd) {
        _db.AppCrewFlights.get(flight.FlightId).then(function (row) {
            if (callback)
                callback(row);
        });
    });
}
//naz
db.sync.SyncAuto = async function (callback) {
    //var allRows = await collection.toArray();
    var flights = await _db.AppCrewFlights
        .filter(function (flight) {
            
            return flight.IsSynced==0;
        }).toArray();

    callback(flights);
};