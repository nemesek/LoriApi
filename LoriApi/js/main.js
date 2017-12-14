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


$("#sendText").click(function() {

  // if (a === "No") {
  //   $(this).data('clicked', true);
  //   document.getElementById("loriResp2").json;
  //   $("#loriResp2").toggleClass('myresp');
  // }
  // if (a === ) {
  //
  // }
  $(this).data('clicked', true);
  document.getElementById("loriResp2").innerHTML += "No, still looking but I'm curious to see how much I can borrow";
  $("#loriResp2").toggleClass('myresp');

});
