<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LivrosDisponiveis.aspx.cs" Inherits="MangaStore.LivrosDisponiveis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <link href="Content/CSS/LivrosDisponiveis.css" rel="stylesheet" />
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
                            <input type="text" id="txtISBN" class="form-control" />
                        </div>
                        <div class="col-12">
                            <label class="fontPatrick" style="font-size: 25px;">Titulo: </label>
                        </div>
                        <div class="col-12">
                            <input type="text" id="txtTitulo" class="form-control" />
                        </div>
                        <div class="col-12">
                            <label class="fontPatrick" style="font-size: 25px;">Autor: </label>
                        </div>
                        <div class="col-12">
                            <input type="text" id="txtAutor" class="form-control" />
                        </div>
                        <div class="col-12">
                            <label class="fontPatrick" style="font-size: 25px;">Editora: </label>
                        </div>
                        <div class="col-12">
                            <input type="text" id="txtEditora" class="form-control" />
                        </div>
                        <div class="col-12">
                            <label class="fontPatrick" style="font-size: 25px;">Genero: </label>
                        </div>
                        <div class="col-12">
                            <input type="text" id="txtGenero" class="form-control" />
                        </div>
                        <div class="col-12">
                            <label class="fontPatrick" style="font-size: 25px;">Preco: </label>
                        </div>
                        <div class="col-12">
                            <div class="slidercontainer">                                
                                <input runat="server" type="range" value="0" min="0" class="slider" id="rgPreco">  <!--MIN/MAX/VALUE--->                              
                                <asp:Label runat="server" ID="lblRangePosition" style="text-align:center;" Text="R$ 0"></asp:Label>
                                <asp:Label runat="server" ID="lblPrecoMax" style="float:right;"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="col-12" style="display:flex">
                            <div class="col-6">
                                <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-info form-control" />
                            </div>
                            <div class="col-6">
                                <asp:Button runat="server" ID="btnRemoverFiltro" Text="Remover Filtro" CssClass="btn btn-danger form-control" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-6">
                <asp:UpdatePanel runat="server" ID="uptLivros" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row list-unstyled">
                            <asp:Repeater runat="server" ID="rptLivrosDiponiveis">
                                <ItemTemplate>
                                    <div class="col-lg-6 col-sm-12">
                                        <li class="media my-4">
                                            <div class="col-lg-6 col-sm-4" style="padding-left: 0;">
                                                <img class="mr-3 img-thumbnail" style="width: 170px; height: 240px; object-fit: cover;" src="Comunicacao/RetornaCapaLivro.ashx?CD_LIVRO=<%# DataBinder.Eval(Container.DataItem, "CdLivro")%>" alt="Generic placeholder image">
                                            </div>
                                            <div class="col-lg-6 col-sm-8 truncateText" style="padding-left: 0">
                                                <div class="media-body truncateText">
                                                    <h5 class="mt-0 mb-1 truncateText"><%# DataBinder.Eval(Container.DataItem, "Titulo")%></h5>
                                                    <p><%# DataBinder.Eval(Container.DataItem, "PrecoConvertido")%></p>
                                                    <label class="descriptionTruncate"><%# DataBinder.Eval(Container.DataItem, "Descricao")%></label>
                                                </div>
                                            </div>
                                        </li>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" ID="uptPaginacao" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row" style="justify-content: center;">
                            <div style="padding: 15px">
                                <asp:Button ID="btnAnterior" CssClass="btn btn-danger" OnClick="btnAnterior_Click" runat="server" Text="Anterior" />
                            </div>
                            <div style="padding: 15px">
                                <asp:Button ID="btnProximo" CssClass="btn btn-info" OnClick="btnProximo_Click" runat="server" Text="Próximo" />
                            </div>
                        </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAnterior" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnProximo" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script>
        var pgPreco = document.getElementById("<%=rgPreco.ClientID%>"),
            lblRangePosition = document.getElementById("<%=lblRangePosition.ClientID%>");

        $(document).ready(function () {
            $("#<%=lblRangePosition.ClientID%>").text(`$${pgPreco.value}`);
        })

        pgPreco.addEventListener("input", function () {
            lblRangePosition.innerHTML = `R$ ${pgPreco.value}`;
        }, false); 
    </script>
</asp:Content>
