// var inputText = document.getElementById("inputText").value;
function relocateForm() {
  location.href = "form.html";
}

$("#engBtn").click(function() {
  $(this).data('clicked', true);
  document.getElementById("loriResp1").innerHTML += "Great Jordan. To start let’s see where you are currently in the process. Have you already decided on a home?";
  $("#loriResp1").toggleClass('loriResp');
  console.log("working");
});

function loadXMLDoc() {

}


$("#sendText").click(function() {

  // $("#loriResp1").toggleClass('myresp');
  var model = {

  }

  model.name = 'Jordan';
  model.language = 1;
  model.businessEventId = 1;

    $.ajax({
        url: 'http://localhost:27692/api/conversations/',
        type: 'POST',
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            debugger;
            $("#loriResp2").toggleClass('myresp');
            $('#loriResp2').text(result.displayText);
        }
    });
    // xmlhttp.onreadystatechange = function() {
    //   if (xmlhttp.readyState == XMLHttpRequest.DONE) { // XMLHttpRequest.DONE == 4
    //     if (xmlhttp.status == 1) {
    //       document.getElementById("loriResp2").innerHTML = xmlhttp.responseText;
    //     } else if (xmlhttp.status == 2) {
    //       console.log('There was an error 400');
    //     } else {
    //       console.log('something else other than 200 was returned');
    //     }
    //   }
    // };

    // if (a === "No") {
    //   $(this).data('clicked', true);
    //   document.getElementById("loriResp2").json;
    //   $("#loriResp2").toggleClass('myresp');
    // }
    // if (a === ) {
    //
    // }


    // $(this).data('clicked', true);
    // document.getElementById("loriResp2").innerHTML += "No, still looking but I'm curious to see how much I can borrow";


});
