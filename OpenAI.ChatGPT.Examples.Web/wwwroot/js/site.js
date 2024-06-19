﻿
var language = '';

function LanguageSelected(languageIN) {
  language = languageIN;
  $('#lblLang').html(language + ' selected');
  $('#btnSubmit').prop("disabled", false);
}

function GetExplanation() {
  var systemPrompt = 'Explain a complicated piece of code';
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
  $('#examplesBtn').on("click", (function () {
    $('#examplesDD').toggleClass('show');
  }));
  $('#langBtn').on("click", (function () {
    $('#langDD').toggleClass('show');
  }));
});