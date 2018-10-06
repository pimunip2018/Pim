function set_dados_form(dados) {
    $('#id_cadastro').val(dados.UsuarioID);
    $('#txt_nome').val(dados.Nome);
    $('#txt_email').val(dados.Email);
    $('#txtDtNasc').val(dados.dtNasc);

}

function set_focus_form() {
    $('#txt_nome').focus();
}

function set_dados_grid(dados) {
    return '<td>' + dados.Nome + '</td>' +
        '<td>' + dados.Email + '</td>';

}

function get_dados_inclusao() {
    return {
        Id: 0,
        Nome: '',
        Email: '',
        dtNasc: ''
        
    };
}

function get_dados_form() {
    return {
        Id: $('#id_cadastro').val(),
        Nome: $('#txt_nome').val(),
        Email: $('#txt_email').val(),
        Login: $('#txtDtNasc').val(),
        dtNasc: $('#txt_senha').val(),

    };
}

function preencher_linha_grid(param, linha) {
    linha
        .eq(0).html(param.Nome).end()
        .eq(1).html(param.Email);
}