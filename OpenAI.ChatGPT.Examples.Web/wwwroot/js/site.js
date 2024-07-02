
var language = '';

function LanguageSelected(languageIN) {
  language = languageIN;
  $('#lblLang').html(language + ' selected');
  $('#btnSubmit').prop("disabled", false);
}

function GetCSharpModel() {

  var systemPrompt = "Create the appropriate C# classes to contain the follwoing JSON object.";
  var userPrompt = $('#inputText').val();

  var promptsToSend = new Array();
  promptsToSend.push(systemPrompt);
  promptsToSend.push(userPrompt);

  const jsonData = {
    prompts: promptsToSend
  };

  ShowOverlay('Wait...');

  fetch('Home/GetPromptResponse', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(jsonData.prompts)
  })
    .then(res => res.json())
    .then(function (data) {
      HideOverlay();
      $('#outputText').html(data);
    });
}

function GetJobCoverLetter() {

  var systemPrompt = "Given the following CV and job description provide a job cover letter";
  var userPrompt = $('#inputText').val();

  var promptsToSend = new Array();
  promptsToSend.push(systemPrompt);
  promptsToSend.push(userPrompt);

  const jsonData = {
    prompts: promptsToSend
  };

  ShowOverlay('Wait...');

  fetch('JobCoverLetter/GetJobCoverLetter', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(jsonData.prompts)
  })
    .then(res => res.json())
    .then(function (data) {
      HideOverlay();
      $('#outputText').html(data);
    });
}

function GetSQLQuery() {

  var systemPrompt = $('#inputText1').val();
  var userPrompt = $('#inputText2').val();

  var promptsToSend = new Array();
  promptsToSend.push(systemPrompt);
  promptsToSend.push(userPrompt);

  const jsonData = {
    prompts: promptsToSend
  };

  ShowOverlay('Wait...');

  fetch('Home/GetPromptResponse', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(jsonData.prompts)
   })
    .then(res => res.json())
    .then(function (data) {
      HideOverlay();
      $('#outputText').html(data);
    });
}

function GetExplanation() {
  var systemPrompt = 'Explain a complicated piece of code';
  var userPrompt = $('#inputText').val();

  var promptsToSend = new Array();
  promptsToSend.push(systemPrompt);
  promptsToSend.push(userPrompt);

  const jsonData = {
    prompts: promptsToSend
  };

  ShowOverlay('Wait...');

  fetch('Home/GetPromptResponse', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(jsonData.prompts)
  })
  .then(res => res.json())
  .then(function (data) {
    HideOverlay();
    $('#outputText').html(data);
  });
}

function ShowOverlay(message) {
  $("#divOverlay").LoadingOverlay("show", {
    text: message,
    background: "rgba(39, 43, 48, 0.8)",
    textColor: "rgba(128, 128, 128, 1)",
  });
}

function HideOverlay() {
  $("#divOverlay").LoadingOverlay("hide");
}

function GetTranslation() {

  var systemPrompt = 'You will be provided with a sentence in English, and your task is to translate it into ' + language;
  var userPrompt = $('#inputText').val();

  var promptsToSend = new Array();
  promptsToSend.push(systemPrompt);
  promptsToSend.push(userPrompt);

  const jsonData = {
    prompts: promptsToSend
  };

  ShowOverlay('Wait...');

  fetch('Home/GetPromptResponse', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(jsonData.prompts)
  })
  .then(res => res.json())
  .then(function (data) {
    HideOverlay();
    $('#outputText').html(data);
  });
}

$(function () {
  $('#examplesBtn').on("click", (function () {
    $('#examplesDD').toggleClass('show');
  }));
  $('#langBtn').on("click", (function () {
    $('#langDD').toggleClass('show');
  }));
});