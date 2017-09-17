var writedata = function(db, name){
    db.ref('users').set({
        user: name
    });
    return true;
}

module.exports.writedata = writedata;