<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadastrarManga.aspx.cs" Inherits="MangaStore.CadastrarManga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-12">
            <section class="bgCadastrarManga">
                <h1 class="fontPatrick titlePages">Cadastrar novo mangá</h1>
            </section>
        </div>
    </div>
    <br />
    <div class="row" style="justify-content: center; width: 100%;">
        <div class="col-10">
            <div class="card text-center">
                <div class="card-header">
                    <ul class="nav nav-tabs card-header-tabs">
                        <li class="nav-item">
                            <a class="nav-link active" href="#">Adicionar</a>
                        </li>
                    </ul>
                </div>
                <div class="card-body">
                    <div class="col-lg-1 col-sm-12">
                        <label class="fontPatrick" style="display: flex; font-size: 25px;">
                            Titulo:
                        </label>
                    </div>
                    <div class="col-lg-5">
                        <input type="text" id="txtTitulo" onfocusout="FindBook();" class="form-control" />
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                ISBN:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtISBN" class="form-control" />
                        </div>

                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Autor:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtAutor" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Editora:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtEditora" class="form-control" />
                        </div>
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Genêro:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtGenero" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Idioma:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtIdioma" class="form-control" />
                        </div>
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Preço:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtPreco" class="form-control" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg-2 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">N° de páginas: </label>
                        </div>
                        <div class="col-lg-4">
                            <input type="number" id="txtQtdPagina" class="form-control" />
                        </div>
                        <div class="col-lg-2 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">Data Publicação: </label>
                        </div>
                        <div class="col-lg-2">
                            <asp:DropDownList runat="server" ID="cboMes" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <asp:DropDownList runat="server" ID="cboAno" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">Quantidade: </label>
                        </div>
                        <div class="col-lg-4">
                            <input type="number" id="txtQuantidade" class="form-control" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">Capa: </label>
                        </div>
                        <div class="col-lg-2 col-sm-6">
                            <img src="Imagem/Icon/iconAdd.jpg" onclick="abrirUpload();" id="imgCapa" class="rounded float-left" alt="..." style="width: 40px; cursor: pointer;">
                            <button class="btn btn-danger form-control" id="btnRemoverImagem" style="display: none;" onclick="removerImagem();return false;">Remover Imagem</button>
                            <input type="file" id="uplCapa" style="opacity: 0; width: 0; height: 0px;" onchange="loadImageFileAsURL();" />
                        </div>
                        <div class="col-lg-9 col-sm-6">
                            <textarea id="txtDescrição" placeholder="Resumo" class="form-control" style="height: 253.41px;"></textarea>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-6" style="margin: auto;">
                                <button id="btnCadastrar" onclick="cadastrarLivro();return false;" class="btn btn-success form-control">Cadastrar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </div>

    <div class="modal fade" id="modalLivros" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Escolha o seu livro para preencher os campos automaticamente. Caso não encontre clique em Sair.</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div id="modal-livro-body" style="height: 580px; overflow-y: scroll;" class="modal-body">
                    <table id="tblLivros" class="table table-hover" style="width: 100%"></table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="$('#tblLivros').DataTable().clear().destroy();">Sair</button>
                </div>
            </div>
        </div>
    </div>
    <style>
        tr {
            cursor: pointer;
        }

        @media (min-width: 1200px) {
            .modal-xl {
                max-width: 1400px !important;
            }
        }
    </style>
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-migrate.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jQueryMask/dist/jquery.mask.min.js"></script>

    <script>

        $(document).ready(function ($) {
            $('#txtPreco').mask('000.000.000.000.000,00', { reverse: true });
            //$('#txtISBN').mask('000-00-000-0000-0');
        })


        function convertImgToBase64URL(url) {
            var teste = url.split(':');
            teste[0] += "s:";
            var httpsUrl = teste[0] + teste[1];
            console.log(httpsUrl);

            var x = new XMLHttpRequest();
            x.open('GET', 'https://cors-anywhere.herokuapp.com/' + httpsUrl);
            // I put "XMLHttpRequest" here, but you can use anything you want.
            x.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
            x.responseType = 'blob';
            x.onload = function () {
                console.log(x.response);
                //var urlCreator = window.URL || window.webkitURL;
                //var imageUrl = urlCreator.createObjectURL(x.response);

                var reader = new FileReader();
                reader.readAsDataURL(x.response);
                reader.onloadend = function () {
                    $('#imgCapa').attr("src", reader.result);
                }
                $('#imgCapa').attr('class', "rounded float-left img-thumbnail");
                $('#imgCapa').attr('style', "cursor:pointer;min-width:182.96px;min-height:206.42px;max-width:182.96px;max-height:206.42px;object-fit: cover;margin-bottom:10px;");
                $('#btnRemoverImagem').css({ "display": "block" });
                $('#imgCapa').removeAttr("onclick");
            };
            x.send();
        }

        //Procura o livro pelo seu titulo
        function FindBook() {
            var txtTitulo = $('#txtTitulo').val().trim();

            if (txtTitulo.length > 0) {

                if ($.fn.DataTable.isDataTable('#tblLivros')) {
                    $('#tblLivros').DataTable().destroy();
                }

                $('#tblLivros thead').empty();
                $('#tblLivros tbody').empty();


                $.ajax({
                    type: "GET",
                    url: "https://www.googleapis.com/books/v1/volumes?q=" + txtTitulo,
                    success: function (data) {
                        if (data.totalItems > 0) {
                            var DataOption = data.items;
                            var CreateData = [];

                            $.each(DataOption, function (key, value) {
                                var Titulo = '-';
                                //var Descrição = '-';
                                var Autores = '-';
                                var Isbn = '-';
                                var Editora = '-';
                                var auxIsbn = '-';
                                var aux = [];
                                var Genero = '-';
                                var Idioma = '-';
                                var NumeroPaginas = '-';
                                var DataPublicacao = '-';
                                var Capa = '';

                                try {
                                    if (typeof (value.volumeInfo.title) != "undefined") { Titulo = value.volumeInfo.title; }
                                } catch { Titulo = '-'; }
                                //try {
                                //    if (typeof (value.volumeInfo.description) != "undefined") { Descrição = value.volumeInfo.description; }
                                //} catch { Descrição = '-'; }
                                try {
                                    if (typeof (value.volumeInfo.authors) != "undefined") { Autores = value.volumeInfo.authors; }
                                } catch { Autores = '-'; }
                                try {
                                    if (typeof (value.volumeInfo.industryIdentifiers) != "undefined") {
                                        Isbn = value.volumeInfo.industryIdentifiers;

                                        auxIsbn = Isbn[key].identifier;
                                    }
                                }
                                catch
                                {
                                    auxIsbn = '-';
                                }
                                try {
                                    if (typeof (value.volumeInfo.publisher) != "undefined") {
                                        Editora = value.volumeInfo.publisher;
                                    }
                                } catch { Editora = '-'; }
                                try { if (typeof (value.volumeInfo.categories) != "undefined") Genero = value.volumeInfo.categories; }
                                catch{
                                    Genero = '';
                                }
                                try {
                                    if (typeof (value.volumeInfo.language) != "undefined") {
                                        Idioma = value.volumeInfo.language;
                                    }
                                }
                                catch{ Idioma = '-'; }
                                try {
                                    if (typeof (value.volumeInfo.pageCount) != "undefined") {
                                        NumeroPaginas = value.volumeInfo.pageCount;
                                    }
                                } catch { NumeroPaginas = '-'; }
                                try {
                                    if (typeof (value.volumeInfo.publishedDate) != "undefined") {
                                        DataPublicacao = value.volumeInfo.publishedDate;
                                    }
                                } catch { DataPublicacao = '-'; }
                                try {
                                    if (typeof (value.volumeInfo.imageLinks.thumbnail) != "undefined") {
                                        Capa = "<img  id='" + key + "' src='" + value.volumeInfo.imageLinks.thumbnail + "'/ >";
                                    }
                                } catch{ Capa = '-'; }

                                aux = ["" + key + "", "" + Capa + "", "" + Titulo + "", "" + auxIsbn + "", "" + Autores + "", "" + Editora + "", "" + Genero + "", "" + Idioma.toUpperCase() + "", "" + NumeroPaginas + "", "" + DataPublicacao + ""];

                                CreateData.push(aux);
                            });

                            $(document).ready(function () {

                                var table = $('#tblLivros').DataTable({
                                    "language": {
                                        "sEmptyTable": "Nenhum registro encontrado",
                                        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                                        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                                        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                                        "sInfoPostFix": "",
                                        "sInfoThousands": ".",
                                        "sLengthMenu": "_MENU_ Resultados por página",
                                        "sLoadingRecords": "Carregando...",
                                        "sProcessing": "Processando...",
                                        "sZeroRecords": "Nenhum registro encontrado",
                                        "sSearch": "Pesquisar",
                                        "oPaginate": {
                                            "sNext": "Próximo",
                                            "sPrevious": "Anterior",
                                            "sFirst": "Primeiro",
                                            "sLast": "Último"
                                        }
                                    },
                                    data: CreateData,
                                    columns: [
                                        { title: "Key", visible: false },
                                        { title: "Capa" },
                                        { title: "Titulo" },
                                        { title: "ISBN" },
                                        { title: "Autores" },
                                        { title: "Editora" },
                                        { title: "Gênero" },
                                        { title: "Idioma" },
                                        { title: "Número de páginas" },
                                        { title: "Data de publicação" }
                                    ],
                                    autoWidth: true
                                });

                                $('#modalLivros').modal('show');

                                //Evento de click na linha do datatable
                                $('#tblLivros tbody').on('click', 'tr', function () {

                                    var data = table.row(this).data();

                                    console.log(data);

                                    var Index;
                                    var image;
                                    var BaseImage;
                                    var Title;
                                    var Isbn;
                                    var Autores;
                                    var Editora;
                                    var Genero;
                                    var Idioma;
                                    var NumPaginas;
                                    var DtPublicacao;

                                    //Adquiri a posição da linha que foi clicada
                                    Index = data[0];

                                    //Adquiri a imagem pelo ID
                                    image = document.getElementById(Index);

                                    //Recebe os valores da linha clicada no datatable
                                    Title = data[2];
                                    Isbn = data[3];
                                    Autores = data[4];
                                    Editora = data[5];
                                    Genero = data[6];
                                    Idioma = data[7];
                                    NumPaginas = data[8];
                                    DtPublicacao = data[9];

                                    $('#txtTitulo').val(Title);
                                    $('#txtISBN').val(Isbn);
                                    $('#txtAutor').val(Autores);
                                    $('#txtIdioma').val(Idioma);
                                    $('#txtQtdPagina').val(NumPaginas);

                                   convertImgToBase64URL(image.src);

                                    $('#modalLivros').modal('hide');

                                    $('#tblLivros').DataTable().clear().destroy();
                                });
                            });
                        }
                    },
                    error: function () {
                        alert('erro');
                    }
                })
            }
        }

        //Adiciona a imagem upada no componente Image.
        function loadImageFileAsURL() {
            var filesSelected = document.getElementById("uplCapa").files;
            var fileName = filesSelected[0].name;
            $('#fileName').text('Filename: ' + fileName);
            if (filesSelected.length > 0) {
                var fileToLoad = filesSelected[0];


                var fileReader = new FileReader();

                fileReader.onload = function (fileLoadedEvent) {
                    var textAreaFileContents = document.getElementById
                        (
                            "textAreaFileContents"
                        );

                    $('#imgCapa').attr('src', fileLoadedEvent.target.result);
                    $('#imgCapa').attr('class', "rounded float-left img-thumbnail");
                    $('#imgCapa').attr('style', "cursor:pointer;min-width:182.96px;min-height:206.42px;max-width:182.96px;max-height:206.42px;object-fit: cover;margin-bottom:10px;");
                    $('#btnRemoverImagem').css({ "display": "block" });
                    $('#imgCapa').removeAttr("onclick");
                    $('#uplCapa').val('');
                };

                fileReader.readAsDataURL(fileToLoad);
            }
        }

        //Abre o uploader
        function abrirUpload() {
            document.getElementById("uplCapa").click();
        }

        //Remove a imagem atual e coloca a padrão no lugar
        function removerImagem() {
            $('#imgCapa').attr('src', "Imagem/Icon/iconAdd.jpg");
            $('#imgCapa').attr('class', "rounded float-left");
            $('#imgCapa').attr('onclick', "abrirUpload();");
            $('#imgCapa').removeAttr('style');
            $('#imgCapa').css({ 'width': '40px', 'cursor': 'pointer' });
            $("#btnRemoverImagem").css({ "display": "none" });
        }
    </script>
    <script>
        //Manda as informações para o serviço e cadastra o livro
        function cadastrarLivro() {
            //Recupera os valores
            var txtISBN = $('#txtISBN').val();
            var txtTitulo = $('#txtTitulo').val();
            var txtAutor = $('#txtAutor').val();
            var txtEditora = $("#txtEditora").val();
            var txtGenero = $("#txtGenero").val();
            var txtIdioma = $("#txtIdioma").val();
            var txtPreco = $('#txtPreco').val();
            var txtQtdPaginas = $('#txtQtdPagina').val();
            var txtDtPublicacao = $("#<%=cboMes.ClientID%> option:selected").val() + "/" + $("#<%= cboAno.ClientID%> option:selected").val();
            var imgCapa = $("#imgCapa").attr("src");
            var txtQuantidade = $('#txtQuantidade').val();
            var txtDescricao = $('#txtDescrição').val();

            //Verifica se o source do componente image é o padrão
            if (imgCapa == "Imagem/Icon/iconAdd.jpg") {
                /*Define a variavel como null. 
                Faço isso para quando for mandado no servidor eu poder validar. No caso como esta a imagem padrão
                significa que o usuario não escolheu uma imagem
                */
                imgCapa = null;
            }
            else {
                /*Caso o usuario tenha escolhido uma imagem, eu removo do base64 da imagem o data:image;base64... para poder mandar
                para o servidor e converter para bytes
                */
                imgCapa = imgCapa.replace(/^data:image\/[a-z]+;base64,/, "");
            }

            //Verifica se o usuário não colocou uma data
            if (txtDtPublicacao.toString().trim() == "-1/-1") {
                /*
                 * Se ele não colocou uma data eu defino o valor da variavel com o valor minimo do datetime
                 */
                txtDtPublicacao = '<%= DateTime.MinValue.Date%>';
            }
            else {
                //Como o campo de data é somente mes e ano, eu realiza a concatenação de um dia padrão, para evitar erros quando os dados forem enviados para o servidor
                var aux = "01/" + txtDtPublicacao;
                txtDtPublicacao = aux;
                txtDtPublicacao += " 00:00:00";
            }

            //Cria um objeto para poder mandar para o servidor
            var jData =
            {
                Isbn: txtISBN,
                Titulo: txtTitulo,
                Autor: txtAutor,
                Editora: txtEditora,
                Genero: txtGenero,
                Idioma: txtIdioma,
                Preco: txtPreco,
                QtdPaginas: txtQtdPaginas,
                DataPublicacao: txtDtPublicacao,
                BaseImage: imgCapa,
                QuantidadeLivros: txtQuantidade,
                Descricao: txtDescricao
            }

            $.ajax({
                type: "POST",
                url: "Comunicacao/cadastranovolivro.ashx",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(jData),
                success: function (data) {
                    //Separo as mensagens retornadas do servidor
                    var message = data.split(':');

                    //Demonstro a mensagem retornada
                    modalMessage("Atenção!", message[0]);

                    //Verifico se houve exito na inserção do livro
                    if (message[1] == '<%= MangaStore.Util.Messages.Ok%>') {
                        //Limpo os campos caso tenha ocorrido com sucesso
                        LimparCampos();
                    }
                }
            })
        }

        //Limpa os campos
        function LimparCampos() {
            $('#txtISBN').val('');
            $('#txtTitulo').val('');
            $('#txtAutor').val('');
            $("#txtEditora").val('');
            $("#txtGenero").val('');
            $("#txtIdioma").val('');
            $('#txtPreco').val('');
            $('#txtQtdPagina').val('');
            $('#<%=cboMes.ClientID%>').prop('selectedIndex', 0);
            $('#<%=cboAno.ClientID%>').prop('selectedIndex', 0);
            $("#imgCapa").attr("src");
            $('#txtQuantidade').val('');
            $('#txtDescrição').val('');
            removerImagem();
        }
    </script>
</asp:Content>
