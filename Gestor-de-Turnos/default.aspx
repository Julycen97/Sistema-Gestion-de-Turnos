<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gestor_de_Turnos._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <!-- IMAGEN DEL LUGAR, NO TAN GRANDE -->
        <figure></figure>

        <!-- BREVE DESCRIPCIÓN DEL LUGAR -->
        <figcaption></figcaption>

        <!-- DEL LADO DERECHO UNA IMAGEN DE MEDIO O ESTUDIO -->
        <aside>
            <image></image>
        </aside>

        <!-- DEL LADO IZQUIERDO DESCRIPCIÓN -->
        <div>
            <p></p>
        </div>

        <!-- CARROUSEL DE IMAGENES DEL LUGAR Y EQUIPAMIENTO PARA ESTUDIOS -->
        <div>

        </div>

        <!-- COBERTURAS CON ICONO O LOGO CON NOMBRE -->
        <asp:GridView></asp:GridView>

        <!-- MAPA CON SUCURSALES, CONSULTORIOS EXTERNOS, ETC -->
        <div>

        </div>
    </div>
    
</asp:Content>
