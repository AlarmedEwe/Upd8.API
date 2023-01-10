"use strict";

$(document).ready(() => {
    configureMasks();

    $("#formCreate").on("submit", createCustomer);
});

function configureMasks() {
    $(".cpf").mask("000.000.000-00");
}

function createCustomer(evt) {
    let json = {
        cpf: $("#cpf").val(),
        name: $("#name").val(),
        birthday: $("#birthday").val(),
        gender: $("#genderM").prop("checked") ? "M" : "F",
        address: $("#address").val(),
        state: $("#state").val(),
        city: $("#city").val(),
    };

    $.ajax({
        url: "https://localhost:7100/api/v1/customer",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json"
    })
        .done(() => {
            alert("Cliente criado com sucesso!");
        })
        .catch((ex) => {
            alert(`Erro ${ex.status} ao atualizar o cliente!`);
            console.error(ex);
            console.error(ex.responseJSON);
        });

    evt.preventDefault();
}