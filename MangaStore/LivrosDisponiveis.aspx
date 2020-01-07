<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LivrosDisponiveis.aspx.cs" Inherits="MangaStore.LivrosDisponiveis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <link href="Content/CSS/LivrosDisponiveis.css" rel="stylesheet" />
    <asp:UpdatePanel runat="server" ID="uptGeral" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <section class="bgLivrosDisponiveis">
                        <h1 class="fontPatrick titlePages">Livros disponíveis</h1>
                    </section>
                </div>
            </div>
            <br />
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xl-6" style="margin-top: 24px">
                        <div class="card" style="margin: 0px 15px;">
                            <div class="card-body">
                                <div class="col-12">
                                    <label class="fontPatrick" style="font-size: 25px;">ISBN: </label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox runat="server" ID="txtISBN" CssClass="form-control"></asp:TextBox>
                                    <div style="text-align: center; margin-top: -5px;display:none;">
                                        <input type="checkbox" id="chkIsbn" />
                                        <label for="chkIsbn">ISBN 13</label>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <label class="fontPatrick" style="font-size: 25px;">Titulo: </label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-12">
                                    <label class="fontPatrick" style="font-size: 25px;">Autor: </label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox runat="server" ID="txtAutor" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-12">
                                    <label class="fontPatrick" style="font-size: 25px;">Editora: </label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox runat="server" ID="txtEditora" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-12">
                                    <label class="fontPatrick" style="font-size: 25px;">Genero: </label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox runat="server" ID="txtGenero" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-12">
                                    <label class="fontPatrick" style="font-size: 25px;">Preco: </label>
                                </div>
                                <div class="col-12">
                                    <div class="slidercontainer">
                                        <input runat="server" step="0.01" type="range" value="0" min="0" class="slider" id="rgPreco">
                                        <!--MIN/MAX/VALUE--->
                                        <asp:Label runat="server" ID="lblRangePosition" Style="text-align: center;" Text="R$ 0"></asp:Label>
                                        <asp:Label runat="server" ID="lblPrecoMax" Style="float: right;"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="col-12" style="display: flex">
                                    <div class="col-6">
                                        <asp:Button runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" Text="Filtrar" CssClass="btn btn-info form-control" />
                                    </div>
                                    <div class="col-6">
                                        <asp:Button runat="server" ID="btnRemoverFiltro" Text="Remover Filtro" CssClass="btn btn-danger form-control" OnClick="btnRemoverFiltro_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xl-6">
                        <div class="row list-unstyled">
                            <asp:Repeater runat="server" ID="rptLivrosDiponiveis">
                                <ItemTemplate>
                                    <div class="col-lg-6 col-sm-12">
                                        <li class="media my-4">
                                            <div class="col-lg-6 col-sm-4" style="padding-left: 0;">
                                                <img class="mr-3 img-thumbnail" style="width: 170px; height: 262px; object-fit: cover;" src="Comunicacao/RetornaCapaLivro.ashx?CD_LIVRO=<%# DataBinder.Eval(Container.DataItem, "CdLivro")%>" alt="Generic placeholder image">
                                            </div>
                                            <div class="col-lg-6 col-sm-8 truncateText" style="padding-left: 0">
                                                <div class="media-body truncateText">
                                                    <h5 class="mt-0 mb-1 truncateText"><%# DataBinder.Eval(Container.DataItem, "Titulo")%></h5>
                                                    <p class="truncateText">Preço: <%# DataBinder.Eval(Container.DataItem, "PrecoConvertido")%></p>
                                                    <hr />
                                                    <label class="truncateText" style="display: block; font-weight: bold;">Autor: <%# DataBinder.Eval(Container.DataItem, "Autor")%></label>
                                                    <label class="truncateText" style="display: block; font-weight: bold;">Editora:  <%# DataBinder.Eval(Container.DataItem, "Editora")%></label>
                                                    <label style="display: block; white-space: normal; font-weight: bold;">Quantidades disponíveis: <%# DataBinder.Eval(Container.DataItem, "Quantidade")%></label>
                                                    <label style="display: block; white-space: normal; font-weight: bold;">ISBN: <%# DataBinder.Eval(Container.DataItem, "Isbn")%></label>
                                                </div>
                                            </div>
                                        </li>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="row" style="justify-content: center;">
                            <div style="padding: 15px">
                                <asp:Button ID="btnAnterior" CssClass="btn btn-danger" OnClick="btnAnterior_Click" runat="server" Text="Anterior" />
                            </div>
                            <div style="padding: 15px">
                                <asp:Button ID="btnProximo" CssClass="btn btn-info" OnClick="btnProximo_Click" runat="server" Text="Próximo" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <!--MODAL-->
            <div class="modal fade" id="modalItemNotFound" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalHeader">Atenção!!!</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" runat="server" id="divModalBody">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAnterior" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnProximo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-migrate.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.maskedinput/1.4.1/jquery.maskedinput.min.js"></script>
    <script>
       /* $(document).ready(function ($) {
            $('#').attr("placeholder", "12-3456-789-1");
            $('#').mask("99-9999-999-9");

            $('#chkIsbn').change(function () {
                if ($('#chkIsbn').is(":checked")) {
                    $('#').val('');
                    $('#').attr("placeholder", "123-45-6789-101-1");
                    $('#').mask("999-99-9999-999-9");
                }
                else {
                    $('#').val('');
                    $('#').attr("placeholder", "12-3456-789-1");
                    $('#').mask("99-9999-999-9");
                }
            });
        });*/

        function pageLoad() {
            var pgPreco = document.getElementById("<%=rgPreco.ClientID%>"),
                lblRangePosition = document.getElementById("<%=lblRangePosition.ClientID%>");

            $(document).ready(function () {
                $("#<%=lblRangePosition.ClientID%>").text(`$${pgPreco.value}`);
            });

            pgPreco.addEventListener("input", function () {
                lblRangePosition.innerHTML = `R$ ${pgPreco.value}`;
            }, false);
        }




    </script>
</asp:Content>
