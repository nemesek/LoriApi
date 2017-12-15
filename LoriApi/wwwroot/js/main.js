var currentModel = {};

function relocateForm() {
    location.href = "form.html";
}

$('#status_message').on("keypress", function (e) {
    if (e.keyCode === 13) {
        getNextSentence(); 
        return false; // prevent the button click from happening
    }
});

$("#engBtn").click(function () {
    var name = $('#nameInput').val();
    var languageId = 1;
    beginInterview(name, languageId, 1);
});

$("#spBtn").click(function () {
    var name = $('#nameInput').val();
    var languageId = 2;
    beginInterview(name, languageId, 1);
});

function beginInterview(name, languageId, businessEventId) {
    var createConversationModel = {
        "businessEventId": businessEventId,
        "name": name,
        "language": languageId
    }
    $.ajax({
        url: 'http://localhost:27692/api/conversations/',
        type: 'POST',
        data: JSON.stringify(createConversationModel),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#loriResp1').text(result.displayText);
            currentModel.sentenceId = result.sentenceId;
            currentModel.displayText = result.displayText;
            currentModel.name = result.name;
            currentModel.language = result.language;

            $('#beginMessage').hide();

        }
    });
}



function showFileUploadModal(div) {
    //$('#fileUploader').show();
    $('#' + div).show();
}

$("#sendText").click(function () { getNextSentence(); });

function bindFileUploadChange() {
    $('#w2InfoFile').change(function () {
        $('#spinner').show();
        $('#fileUploader').hide();
        setTimeout(function () {
            $('#spinner').hide();
            beginInterview(currentModel.name, currentModel.language, 2);
        }, 5000);

    });

    $('#w2InfoFile2').change(function () {
        $('#spinner').show();
        $('#fileUploader2').hide();
        setTimeout(function () {
            $('#spinner').hide();
            beginInterview(currentModel.name, currentModel.language, 3);
        }, 5000);

    });
}

function getNextSentence() {

    currentModel.userResponse = $('#status_message').val();

    $.ajax({
        url: 'http://localhost:27692/api/conversations/1',
        type: 'PUT',
        data: JSON.stringify(currentModel),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#loriResp1').text(result.displayText);
            currentModel.sentenceId = result.sentenceId;
            currentModel.displayText = result.displayText;
            currentModel.name = result.name;
            currentModel.language = result.language;

            if (currentModel.sentenceId === 7 ) {
                showFileUploadModal('fileUploader');
            }

            if (currentModel.sentenceId === 15) {
                showFileUploadModal('fileUploader2');
            }

            setTimeout(function() { $('#status_message').val(''); }, 1000);

            if (result.isAssertion) {
                setTimeout(function () {
                    getNextSentence();
                }, 2000);
            }

            var progress = result.sentenceId * 3;

            $('#progressBar').css('width', progress + '%');
            $('#progressBar').text(progress + '%');
        }
    });
}

