var currentModel = {};
// var inputText = document.getElementById("inputText").value;
function relocateForm() {
  location.href = "form.html";
}

$("#engBtn").click(function() {
  //$(this).data('clicked', true);
  //document.getElementById("loriResp0").innerHTML += "Great Jordan. To start let’s see where you are currently in the process. Have you already decided on a home?";
  //$("#loriResp0").toggleClass('loriResp');
    var name = $('#nameInput').val();
    var languageId = 1;
    beginInterview(name, languageId);
    debugger;
});

 $("#spBtn").click(function() {
   //$(this).data('clicked', true);
   //document.getElementById("loriResp0").innerHTML += "Great Jordan. To start let’s see where you are currently in the process. Have you already decided on a home?";
   //$("#loriResp0").toggleClass('loriResp');
     var name = $('#nameInput').val();
     var languageId = 2;
     beginInterview(name, languageId);
     debugger;
 });

function beginInterview(name, languageId) {
  var createConversationModel = {
    "businessEventId": 1,
    "name": name,
    "language": languageId
  }
  $.ajax({
    url: 'http://localhost:27692/api/conversations/',
    type: 'POST',
    data: JSON.stringify(createConversationModel),
    contentType: 'application/json; charset=utf-8',
    success: function(result) {

      $('#loriResp1').text(result.displayText);
      // $('#loriResp1').toggleClass('myresp');
      currentModel.sentenceId = result.sentenceId;
      currentModel.displayText = result.displayText;
      currentModel.name = result.name;
      currentModel.language = result.language;
      // currentReply = $('#status_message').val();
      debugger;
    }
  });
}

$("#sendText").click(function() {

  // $("#loriResp1").toggleClass('myresp');
 
  // currentReply = $('#status_message').val();

  // currentStep = currentStep + 1;
    currentModel.userResponse = $('#status_message').val();

  $.ajax({
    url: 'http://localhost:27692/api/conversations/1',
    type: 'PUT',
    data: JSON.stringify(currentModel),
    contentType: 'application/json; charset=utf-8',
    success: function(result) {

        $('#loriResp1').text(result.displayText);
        debugger;
        currentModel.sentenceId = result.sentenceId;
        currentModel.displayText = result.displayText;
        currentModel.name = result.name;
        currentModel.language = result.language;
        // $('#loriResp1').toggleClass('myresp');
    }
  });
});

// if (currentStep === 0) {
//   $('#loriResp1').text(result.displayText);
//   $('#loriResp1').toggleClass('myresp');
// }
