$(document).ready(function ($) {
    //Adiciona mascara de dinheiro no campo
    $('#txtPreco').mask('000.000.000.000.000,00', { reverse: true });
})

//Converte a imagem vinda da API da google para base64.
function convertImgToBase64URL(url) {
    //Separa o HTTP do resto do link
    var urlApi = url.split(':');

    //Verifica se o link utiliza protocolo HTTP
    if (urlApi[0] == "http") {
        //Se utilizar acrescento o s para alterar para o protocolo HTTPS
        urlApi[0] += "s:";
    }

    //Monta o link da API.
    var httpsUrl = urlApi[0] + urlApi[1];

    //Cria o objeto de requisição
    var request = new XMLHttpRequest();

    //MOnta o metodo e o link a serem utilizados na requisição
    request.open('GET', 'https://cors-anywhere.herokuapp.com/' + httpsUrl);

    //Monta o cabeçalho
    request.setRequestHeader('X-Requested-With', 'XMLHttpRequest');

    //Define o tipo da resposta como blob, pois irá ser retornado uma imagem
    request.responseType = 'blob';

    request.onload = function () {
        //Cria um novo leitor de arquivos
        var reader = new FileReader();

        //Realiza a leitura da imagem
        reader.readAsDataURL(request.response);

        reader.onloadend = function () {
            //Atribui o base64 da imagem no componente img
            $('#imgCapa').attr("src", reader.result);
        }

        //Altera os atributos do componente img
        $('#imgCapa').attr('class', "rounded float-left img-thumbnail");
        $('#imgCapa').attr('style', "cursor:pointer;min-width:182.96px;min-height:206.42px;max-width:182.96px;max-height:206.42px;object-fit: cover;margin-bottom:10px;");
        $('#btnRemoverImagem').css({ "display": "block" });
        $('#imgCapa').removeAttr("onclick");
    };

    //Envia a requisição
    request.send();
}

//Adiciona a imagem upada no componente Image.
function loadImageFileAsURL() {
    //Recebe o uploader
    var filesSelected = document.getElementById("uplCapa").files;

    //Verifica se há arquivo no fileuploader
    if (filesSelected.length > 0) {
        //Recebe o arquivo 
        var fileToLoad = filesSelected[0];

        //Cria um novo leitor de arquivos
        var fileReader = new FileReader();

        //Faz a leiutura leitura do arquivo
        fileReader.readAsDataURL(fileToLoad);

        //Ao finalizar a leitura atribuo ela ao componente IMG
        fileReader.onload = function (fileLoadedEvent) {
            //Atribui a imagem em base64 no componente img
            $('#imgCapa').attr('src', fileLoadedEvent.target.result);

            //Altera o css do elemento IMG
            $('#imgCapa').attr('class', "rounded float-left img-thumbnail");
            $('#imgCapa').attr('style', "cursor:pointer;min-width:182.96px;min-height:206.42px;max-width:182.96px;max-height:206.42px;object-fit: cover;margin-bottom:10px;");
            //Altera o css do botão de remover a imagem
            $('#btnRemoverImagem').css({ "display": "block" });

            //Remove o evento de click do componente IMG
            $('#imgCapa').removeAttr("onclick");

            //Limpa o fileuploader
            $('#uplCapa').val('');
        };
    }
}

//Abre o uploader
function abrirUpload() {
    //Força o click do FileUploader
    document.getElementById("uplCapa").click();
}

//Remove a imagem atual e coloca a padrão no lugar
function removerImagem() {
    //Reseta os componentes
    $('#imgCapa').attr('src', "Imagem/Icon/iconAdd.jpg");
    $('#imgCapa').attr('class', "rounded float-left");
    $('#imgCapa').attr('onclick', "abrirUpload();");
    $('#imgCapa').removeAttr('style');
    $('#imgCapa').css({ 'width': '40px', 'cursor': 'pointer' });
    $("#btnRemoverImagem").css({ "display": "none" });
}