$(document).ready(function (){

 $(".ball-container").addEventListener('click', function(event) {
    console.log("clickde");
      navigator.bluetooth.requestDevice({ filters: [{ services: ['877408dcf87210b3c5e0466120fea339'] }] })
      .then(server => {
        // Getting Battery Service...
        console.log(server.getPrimaryService('battery_service'));
      })
      .then(service => {
        // Getting Battery Level Characteristic...
        console.log(service.getCharacteristic('battery_level'));
      })
      .then(characteristic => {
        // Reading Battery Level...
        console.log(characteristic.readValue());
      })
      .then(value => {
        console.log('Battery percentage is ' + value.getUint8(0));
      })
      .catch(error => { console.log(error); });
    });

});