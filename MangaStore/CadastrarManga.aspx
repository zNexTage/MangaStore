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
                    <div class="row">
                        <div class="col-lg-1">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                ISBN:
                            </label>
                        </div>
                        <div class="col-lg-3">
                            <input type="text" id="txtISBN" class="form-control" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Titulo:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txtTitulo" class="form-control" />
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
                            <select id="cboEditora" class="form-control">
                                <option value="500">TESTE</option>
                            </select>
                        </div>
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Genêro:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <select id="cboGenero" class="form-control">
                                <option value="1">TESTE</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Idioma:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <select id="cboIdioma" class="form-control">
                                <option value="1">TESTE</option>
                            </select>
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
                        <div class="col-lg-4">
                            <input type="text" id="txtDtPublicacao" class="form-control" />
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
        </div>
    </div>
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-migrate.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jQueryMask/dist/jquery.mask.min.js"></script>

    <script>
        $(document).ready(function ($) {
            $('#txtPreco').mask('000.000.000.000.000,00', { reverse: true });
            $('#txtISBN').mask('000-00-000-0000-0');
            $('#txtDtPublicacao').datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
            });
        })
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
            var txtISBN = $('#txtISBN').val();
            var txtTitulo = $('#txtTitulo').val();
            var txtAutor = $('#txtAutor').val();
            var cboEditora = $("#cboEditora option:selected").val();
            var cboGenero = $("#cboGenero option:selected").val();
            var cboIdioma = $("#cboIdioma option:selected").val();
            var txtPreco = $('#txtPreco').val();
            var txtQtdPaginas = $('#txtQtdPagina').val();
            var txtDtPublicacao = $('#txtDtPublicacao').val()+" 00:00:00";
            var imgCapa = $("#imgCapa").attr("src");
            var txtQuantidade = $('#txtQuantidade').val();
            var txtDescricao = $('#txtDescrição').val();
            alert(txtDtPublicacao);

            var jData =
            {
                Isbn: txtISBN,
                Titulo: txtTitulo,
                Autor: txtAutor,
                CdEditora: cboEditora,
                CdGenero: cboGenero,
                CdIdioma: cboIdioma,
                Preco: txtPreco,
                QtdPaginas: txtQtdPaginas,
                GetData: txtDtPublicacao,
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
                success: function (data)
                {
                    alert(data.d);
                },
                error: function (err)
                {
                    alert(err.d);
                }
            })
        }
    </script>
</asp:Content>
