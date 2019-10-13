﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadastrarManga.aspx.cs" Inherits="MangaStore.CadastrarManga" %>

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
                    <table id="tblLivros" class="table table-striped" style="width: 100%"></table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Sair</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-migrate.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jQueryMask/dist/jquery.mask.min.js"></script>

    <script>

        $(document).ready(function ($) {
            $('#txtPreco').mask('000.000.000.000.000,00', { reverse: true });
            //$('#txtISBN').mask('000-00-000-0000-0');
        })

        //Procura o livro pelo seu titulo
        function FindBook() {
            var txtTitulo = $('#txtTitulo').val();

            $.ajax({
                type: "GET",
                url: "https://www.googleapis.com/books/v1/volumes?q=" + txtTitulo,
                success: function (data) {
                    var DataOption = data.items;
                    var CreateData = [];

                    if ($.fn.DataTable.isDataTable('#tblLivros')) {
                        $('#tblLivros').DataTable().clear().destroy();
                    }

                    $.each(DataOption, function (key, value) {
                        var Titulo = '';
                        var SubTitulo = '';
                        var Autores = '';
                        var Isbn = '';
                        var Editora = '';
                        var auxIsbn = '';
                        var aux = [];
                        var Genero = '';
                        var Idioma = '';
                        var NumeroPaginas = '';
                        var DataPublicacao = '';
                        var Capa = '';

                        try { Titulo = value.volumeInfo.title; } catch { Titulo = '';}
                        try { SubTitulo = value.volumeInfo.subtitle; } catch { SubTitulo = ''; }
                        try { Autores = value.volumeInfo.authors; } catch { Autores = ''; }
                        try {
                            Isbn = value.volumeInfo.industryIdentifiers;

                            auxIsbn = Isbn[key].identifier;
                        }
                        catch
                        {
                            auxIsbn = '';
                        }
                        try { Editora = value.volumeInfo.publisher; } catch { Editora = ''; }
                        try {Idioma = value.volumeInfo.language; }catch{Idioma = '';}
                        try { NumeroPaginas = value.volumeInfo.pageCount; } catch {NumeroPaginas = ''; }
                        try { DataPublicacao = value.volumeInfo.publishedDate; } catch { DataPublicacao = ''; }
                        
                        aux = ["" + Titulo + "", "" + SubTitulo+"","" + auxIsbn + "", "" + Autores + "", "" + Editora + "", "" + Genero + "", "" + Idioma + "", "" + NumeroPaginas + "", "" + DataPublicacao + "", "" + Capa + ""];

                        CreateData.push(aux);
                    });
                    console.log(DataOption);
                    console.log(CreateData);

                    //var i = 0;
                    //var html = ' <div class="row"> ';
                    //while (i <= 20) {
                    //    html += ' <div class="col-lg-6" style="padding:15px;"> ';
                    //    html += ' <div class="card" style="width: 18rem;margin:auto;"> ';
                    //    html += ' <img src="C:\Users\Christian\Pictures\311894.jpg" class="card-img-top" alt="..."> ';
                    //    html += ' <div class="card-body"> ';
                    //    html += ' <h5 class="card-title">Card title</h5> ';
                    //    html += '   </div> ';
                    //    html += '   </div> ';
                    //    html += '   </div> ';
                    //    i++;
                    //}

                    //html += ' </div> ';


                    //$('#modal-livro-body').prepend(html);


                    $('#modalLivros').modal('show');
                },
                error: function () {
                    alert('erro');
                }
            })

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
