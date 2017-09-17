var writedata = function(db, name){
    db.ref('users'+name).set({
        user: name
    });
    return true;
}

var deletedata = function(db, name){
    db.ref('users'+name).remove();
    return true;
}

module.exports.writedata = writedata;
module.exports.deletedata = deletedata;