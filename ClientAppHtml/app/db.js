const dbName = "CrewPocketDb";
 
var _db = new Dexie(dbName);
db = {};
db.getDb = function () {
    return _db;
};
db.Init = function () {
    _db.version(19).stores({
        AppCrewFlights: "Id,FlightId,CrewId,FDPId,FDPItemId,DutyType,IsPositioning,PositionId,Position,FlightNumber,STDDay,FlightStatusId,Register,RegisterId,FromAirportIATA,ToAirportIATA,STD,STA,BlockOff,BlockOn,TakeOff,Landing,IStart,IsSynced",
        FlightCrews: "[CrewId+FlightId],FDPItemId,FDPId",
        Calendar: "[Id+Date],DateStart,Legs,Sectors,DutyType,DutyTypeTitle,Year,Month,Day",
        Duties: "[Id+Date],DateStart,DutyType,DutyTypeTitle,Year,Month,Day,DateConfirmed,UPD,ConfirmedBy,UserName,IStart,IsSynced,GroupId",
        Auth:"UserName,Password"
         
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