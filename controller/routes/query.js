var writedata = function(db, name){
    db.ref('users'+name).set({
        user: name
    });
    return true;
}

module.exports.writedata = writedata;