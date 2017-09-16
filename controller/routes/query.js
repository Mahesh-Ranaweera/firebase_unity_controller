var writedata = function(db, user, name){
    db.ref('users/'+appdata).set({
        LR: name,
        FB: user,
        DIR: ,
        ACC: ,
        ACCWG ,
        ROTATION: 
    });
    return true;
}

module.exports.writedata = writedata;