<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LivrosDisponiveis.aspx.cs" Inherits="MangaStore.LivrosDisponiveis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/CSS/LivrosDisponiveis.css" rel="stylesheet" />
    <div class="row">
        <div class="col-12">
            <section class="bgLivrosDisponiveis">
                <h1 class="fontPatrick titlePages">Livros disponíveis</h1>
            </section>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-6 col-sm-12">
            <div class="card" style="margin: 0px 15px;">
                <div class="card-body">
                    <div class="col-12">
                        <label class="fontPatrick" style="font-size: 25px;">ISBN: </label>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <input type="text" id="txtISBN" class="form-control" />
                    </div>
                    <div class="col-12">
                        <label class="fontPatrick" style="font-size: 25px;">Titulo: </label>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <input type="text" id="txtTitulo" class="form-control" />
                    </div>
                    <div class="col-12">
                        <label class="fontPatrick" style="font-size: 25px;">Autor: </label>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <input type="text" id="txtAutor" class="form-control" />
                    </div>
                    <div class="col-12">
                        <label class="fontPatrick" style="font-size: 25px;">Editora: </label>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <input type="text" id="txtEditora" class="form-control" />
                    </div>
                    <div class="col-12">
                        <label class="fontPatrick" style="font-size: 25px;">Genero: </label>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <input type="text" id="txtGenero" class="form-control" />
                    </div>
                    <div class="col-12">
                        <label class="fontPatrick" style="font-size: 25px;">Preco: </label>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <div class="slidercontainer">
                            <input type="range" min="1" max="100" value="50" class="slider" id="rgPreco">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-sm-12">
            <div class="col-12">
                <ul class="list-unstyled">
                    <asp:Repeater runat="server" ID="rptLivrosDiponiveis">                        
                        <ItemTemplate>
                            <li class="media my-4">
                                <img class="mr-3 img-thumbnail" style="width: 106.97px;height: 150px;object-fit:cover;" src="Comunicacao/RetornaCapaLivro.ashx?CD_LIVRO=<%# DataBinder.Eval(Container.DataItem, "CdLivro")%>" alt="Generic placeholder image">
                                <div class="media-body">
                                    <h5 class="mt-0 mb-1"><%# DataBinder.Eval(Container.DataItem, "Titulo")%></h5>
                                    <%# DataBinder.Eval(Container.DataItem, "Descricao")%>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
