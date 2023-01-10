"use strict";

var dataTable;

$(document).ready(() => {
    configureMasks();

    configureDataTable();

    $("#formEdit").on("submit", editCustomer);
});

function startEditing(id) {
    $.ajax({ url: `https://localhost:7100/api/v1/customer/id?id=${id}` })
        .done(({ data }) => {
            $("#idEdit").val(data.id);
            $("#cpfEdit").val(data.cpf);
            $("#nameEdit").val(data.name);
            $("#birthdayEdit").val(data.birthday.split("T")[0]);

            let isMale = data.gender == "M";
            $("#genderMEdit").prop("checked", isMale);
            $("#genderFEdit").prop("checked", !isMale);

            $("#addressEdit").val(data.address);
            $("#stateEdit").val(data.state);
            $("#cityEdit").val(data.city);

            $("#modalEdit").addClass("shown");
        })
        .catch((ex) => {
            console.log(ex);
        });
}

function startDeleting(id) {
    $.ajax({ url: `https://localhost:7100/api/v1/customer/id?id=${id}` })
        .done(({ data }) => {
            $("#deleteName").text(data.name);

            $("#deleteButton").attr("onclick", `deleteCustomer(${id})`);
            console.log($("#deleteButton")[0]);

            $("#modalDelete").addClass("shown");
        })
        .catch((ex) => {
            console.log(ex);
        });
}

function editCustomer(evt) {
    let json = {
        id: parseInt($("#idEdit").val()),
        cpf: $("#cpfEdit").val(),
        name: $("#nameEdit").val(),
        birthday: $("#birthdayEdit").val(),
        gender: $("#genderMEdit").prop("checked") ? "M" : "F",
        address: $("#addressEdit").val(),
        state: $("#stateEdit").val(),
        city: $("#cityEdit").val(),
    };

    $.ajax({
        url: "https://localhost:7100/api/v1/customer",
        type: "PATCH",
        data: JSON.stringify(json),
        contentType: "application/json"
    })
        .done(() => {
            $(".modal").removeClass("shown");
            dataTable.ajax.reload();
        })
        .catch((ex) => {
            alert(`Erro ${ex.status} ao atualizar o cliente!`);
            console.error(ex);
            console.error(ex.responseJSON);
        });

    evt.preventDefault();
}

function deleteCustomer(id) {
    $.ajax({
        url: `https://localhost:7100/api/v1/customer?id=${id}`,
        type: "DELETE",
    })
        .done((res) => {
            $(".modal").removeClass("shown");
            dataTable.ajax.reload();
        })
        .catch((ex) => {
            console.log(ex);
        });
}

function closeModal() {
    $(".modal").removeClass("shown");
}

function configureMasks() {
    $(".cpf").mask("000.000.000-00");
}

function configureDataTable() {
    dataTable = $("#listTable").DataTable({
        id: "listTable",
        ajax: {
            url: "https://localhost:7100/api/v1/customer",
            type: "GET",
            dataSrc: ({ success, data }) => {
                return data;
            },
        },
        dom: "ftpl",
        language: ptBr,
        columns: [
            { data: "" },
            { data: "" },
            { data: "name" },
            { data: "cpf" },
            { data: "birthday" },
            { data: "state" },
            { data: "city" },
            { data: "gender" },
        ],
        columnDefs: [
            {
                targets: 0,
                render: (data, type, row) => {
                    return `
          <button class="btn btn-success" onclick="startEditing(${row.id})">
            <i class="fa fa-fw fa-pen"></i>
            Editar
          </button>`;
                },
            },
            {
                targets: 1,
                render: (data, type, row) => {
                    return `
            <button class="btn btn-danger" onclick="startDeleting(${row.id})">
              <i class="fa fa-fw fa-trash"></i>
              Excluir
            </button>`;
                },
            },
            {
                targets: 4,
                render: (data, type, row) => {
                    return row.birthday.toString().replace(/^(\d{4})-(\d{2})-(\d{2})(.*)/, "$3/$2/$1");
                },
            },
            {
                targets: 7,
                render: (data, type, row) => {
                    var icon = row.gender == "M" ? "fa-mars" : "fa-venus";

                    return `<i class="fa fa-fw ${icon}"></i>`;
                },
            },
        ],
    });
}
