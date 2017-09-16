var writedata = function(db, user, name){
    db.ref('users/'+user).set({
        username: name,
        id: user
    });
    return true;
}

module.exports.writedata = writedata;