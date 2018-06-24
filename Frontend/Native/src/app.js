var requester = app.requester.load();


$(document).ready(function(){

    requester.get('http://3d933ceb.ngrok.io/api/events')
    .then(function(success){
        console.log(success);
    },function(error){});


});