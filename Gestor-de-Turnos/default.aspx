<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gestor_de_Turnos._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <!-- PRIMER SECCION -->
        <section id="PrimerSeccion">
            <!-- IMAGEN DEL LUGAR, NO TAN GRANDE -->
            <figure>
                <img src="https://pilar.gov.ar/wp-content/uploads/2020/12/30DF0E6E-70CE-4860-B066-77E7122BBB39-1-1.jpeg" alt="ImagenClinica" width="900px"/>
            </figure>

            <!-- BREVE DESCRIPCIÓN DEL LUGAR -->
            <figcaption>Clinica [Nombre de Clinica]</figcaption>
        </section>

        <!-- SEGUNDA SECCION -->
        <section id="SegundaSeccion">
            <!-- DEL LADO DERECHO UNA IMAGEN DE MEDICO O ESTUDIO QUE SE REALIZA-->
            <aside>
                <img src="https://oncologiapergamino.org.ar/wp-content/uploads/2021/12/LR-_Resonancia_COP_Equipo_A.jpg" alt="Resonografo" width="600px" />
            </aside>

            <!-- DEL LADO IZQUIERDO DESCRIPCIÓN -->
            <div>
                <pre>
                    Lorem ipsum dolor sit amet,
                    consectetur adipiscing elit,
                    sed do eiusmod tempor incididunt
                    ut labore et dolore magna aliqua.
                    Ut enim ad minim veniam, quis
                    nostrud exercitation ullamco
                    laboris nisi ut aliquip ex ea
                    commodo consequat. Duis aute irure
                    dolor in reprehenderit in voluptate
                    velit esse cillum dolore eu fugiat
                    nulla pariatur.
                </pre>
            </div>
        </section>

        <!-- TERCERA SECCION -->
        <section id="TerceraSeccion">
        <!-- CARROUSEL DE IMAGENES DEL LUGAR Y EQUIPAMIENTO PARA ESTUDIOS -->

        </section>

        <!-- CUARTA SECCION -->
        <section id="CuartaSeccion">
            <!-- COBERTURAS CON ICONO O LOGO CON NOMBRE -->
            <asp:GridView>

            </asp:GridView>

            <div>
                <!-- MAPA CON SUCURSALES, CONSULTORIOS EXTERNOS, ETC -->
            </div>
        </section>
    </div>
    
</asp:Content>
