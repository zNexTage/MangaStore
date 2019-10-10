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
                            <asp:DropDownList runat="server" ID="cboEditora" CssClass="form-control"></asp:DropDownList>                            
                        </div>
                        <div class="col-lg-1 col-sm-12">
                            <label class="fontPatrick" style="display: flex; font-size: 25px;">
                                Genêro:
                            </label>
                        </div>
                        <div class="col-lg-5">
                            <select id="cboGenero" class="form-control">
                                <option value="-1"></option>
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
                            <asp:DropDownList runat="server" ID="cboIdioma" CssClass="form-control"></asp:DropDownList>                            
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
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-migrate.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jQueryMask/dist/jquery.mask.min.js"></script>

    <script>
        function maskField(id)
        {
            var component = document.getElementById(id);
            //alert(component.value.length);
            if (component.length == 7)
            {
                alert('oi');
            }
        }

        $(document).ready(function ($) {
            $('#txtPreco').mask('000.000.000.000.000,00', { reverse: true });
            $('#txtISBN').mask('000-00-000-0000-0');
            
            $('#txtDtPublicacao').datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                dateFormat: 'MM yy',
                yearRange: "-100:+0",
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                onClose: function (dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    month = parseInt(month) + parseInt(1);
                    if (month <= 9) {
                        month = "0" + month;
                    }
                    $(this).val(month+ "/" + year);
                }
                //changeMonth: true,
                //changeYear: true,
                //showButtonPanel: true,
                //dateFormat: 'dd/mm/yy',

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
            //Recupera os valores
            var txtISBN = $('#txtISBN').val();
            var txtTitulo = $('#txtTitulo').val();
            var txtAutor = $('#txtAutor').val();
            var cboEditora = $("#<%=cboEditora.ClientID%> option:selected").val();
            var cboGenero = $("#cboGenero option:selected").val();
            var cboIdioma = $("#<%= cboIdioma.ClientID%> option:selected").val();
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
            if (txtDtPublicacao.toString().trim() == "") {
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
                FkEditora: cboEditora,
                FkGenero: cboGenero,
                FkIdioma: cboIdioma,
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
            $("#cboEditora#elem").prop('selectedIndex', 0);
            $("#cboGenero#elem").prop('selectedIndex', 0);
            $("#<%=cboIdioma.ClientID%>#elem").prop('selectedIndex', 0);
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
