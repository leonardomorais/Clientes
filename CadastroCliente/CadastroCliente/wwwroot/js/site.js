function BuscarCep() {
    var cepInformado = $('#Cep').val();

    if (!cepInformado)
        return;

    var url = "https://viacep.com.br/ws/" + cepInformado + "/json/";

    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#Endereco').val(data.logradouro);
            $('#Complemento').val(data.complemento);
            $('#Bairro').val(data.bairro);
            $('#Estado').val(data.uf);
            $('#Cidade').val(data.localidade);
        },
        error: function () {
            alert("Não foi possível pesquisar o CEP informado.");
        }
    });
}

$('#Cep').change(function () {
    BuscarCep();
});

function Excluir(id) {
    var dialogo = confirm("O cliente selecionado será removido.");
    if (dialogo) {
        $.ajax({
            url: "/Cliente/Excluir/" + id,
            success: function () {
                location.reload(true);
            }
        });
    }
};

$('#Numero').keyup(function (e) {
    $(this).val($(this).val().replace(/[^0-9]/g, ''));
});

