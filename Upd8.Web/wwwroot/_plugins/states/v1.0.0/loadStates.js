"use strict";

$(document).ready(() => {
  var html = "";

  for (var { region, states: stateList } of states) {
    html += `<optgroup label="${region}">`;

    for (var { uf, name } of stateList) {
      html += `<option value="${uf}">${name}</option>`;
    }

    html += `</optgroup>`;
  }

  $("select.stateList").append(html);
});
