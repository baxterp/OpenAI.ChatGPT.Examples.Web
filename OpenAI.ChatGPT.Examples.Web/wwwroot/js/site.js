
function ShowOverlay(message) {
  $("#divOverlay").LoadingOverlay("show", {
    text: message,
  });
}

function HideOverlay() {
  $("#divOverlay").LoadingOverlay("hide");
}

function GetTranslation() {

  var systemPrompt = 'You will be provided with a sentence in English, and your task is to translate it into French';
  console.log('systemPrompt: ' + systemPrompt);
  var userPrompt = $('#inputText').val();
  console.log('userPrompt: ' + userPrompt);

  var promptsToSend = new Array();
  promptsToSend.push(systemPrompt);
  promptsToSend.push(userPrompt);

  const jsonData = {
    prompts: promptsToSend
  };

  ShowOverlay('Wait...');

  fetch('NaturalLanguageTranslator/GetTranslation', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(jsonData.prompts)
  })
  .then(res => res.json())
  .then(function (data) {
    console.log('data from server');
    console.log(data);
    HideOverlay();
    $('#outputText').html(data);
  });
}

$(function () {
  $('.dropdown').on("click", (function () {
    $('.dropdown-menu').toggleClass('show');
  }));
  //GetTranslation();
});