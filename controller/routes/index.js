var express = require('express');
var router = express.Router();
const firebase = require('firebase');
var  appdb = require('./config');

//initialized the session
app.use(session({
  secret: 'HV3U00lcMahc84050VxX62xoMS67NhS4',
  resave: true,
  saveUninitialized: true,
  path: '/'
}));

//set the firebase
var config = {
  apiKey: appdb.configdata.apiKey,
  authDomain: appdb.configdata.authDomain,
  databaseURL: appdb.configdata.databaseURL,
  projectId: appdb.configdata.projectId,
  storageBucket: appdb.configdata.storageBucket,
  messagingSenderId: appdb.configdata.messagingSenderId
};
const conn = firebase.initializeApp(config);
var db = firebase.database();

//create the user
var query = require('./query');

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Index' });
});

router.get('/api', function(req, res, next) {
  res.render('mobile', { 
    title: 'API', 
    user: req.query.name
  });
});


//create the user onlogin
router.post('/join', function(req, res, next){
  var name = Date.now();

  if(query.writedata(db, name)){
    res.redirect('/api?name=' + name);
  }else{
    res.redirect('/');
  }
});


// router.get('/write', function(req, res, next) {
//   var user = Math.floor(Date.now());
//   var name = 'Mahesh Ranaweera';
//   if(query.writedata(db, user, name)){
//       // res.redirect('/');
//       //getdata(db, res);
//   }else{
//       res.render('index',{
//           title: "Error"
//       })
//   }
// });


///read data
function getdata(db, res){
  var childdata;

  var data = db.ref('/users')
  data.on('value', function(user){
      user.forEach(function(child){
          var collection = {
              name: child.val().username,
              id : child.val().id
          }
          childdata += JSON.stringify(collection)
          //console.log(childdata)
      })
      res.render('index',{
          title: childdata
      })
  })
}


module.exports = router;
