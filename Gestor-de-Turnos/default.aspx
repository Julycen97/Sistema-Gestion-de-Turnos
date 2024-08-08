<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gestor_de_Turnos._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <!-- PRIMER SECCION -->
        <section id="PrimerSeccion">
            <!-- IMAGEN DEL LUGAR, NO TAN GRANDE -->
            <figure id="IMGInicio-A">
                <img src="https://pilar.gov.ar/wp-content/uploads/2020/12/30DF0E6E-70CE-4860-B066-77E7122BBB39-1-1.jpeg" alt="ImagenClinica" width="900px"/>
                <!-- BREVE DESCRIPCIÓN DEL LUGAR -->
            </figure>
            <figcaption id="TXT-IMGInicio-A">
                Hospital Central de Pilar
            </figcaption>
        </section>

        <!-- SEGUNDA SECCION -->
        <section id="SegundaSeccion">
            <!-- DEL LADO DERECHO UNA IMAGEN DE MEDICO O ESTUDIO QUE SE REALIZA-->
            <aside>
                <figure id="IMGInicio-B">
                    <img src="https://oncologiapergamino.org.ar/wp-content/uploads/2021/12/LR-_Resonancia_COP_Equipo_A.jpg" alt="Resonografo" width="600px" />
                    
                    <!-- DEL LADO IZQUIERDO DESCRIPCIÓN -->
                    <figcaption id="TXT-IMGInicio-B">
                        <p>
                            Lorem ipsum dolor sit amet,<br />
                            consectetur adipiscing elit, <br />
                            sed do eiusmod tempor incididunt <br />
                            ut labore et dolore magna aliqua. <br />
                            Ut enim ad minim veniam, quis <br />
                            nostrud exercitation ullamco <br />
                            laboris nisi ut aliquip ex ea <br />
                            commodo consequat. Duis aute irure <br />
                            dolor in reprehenderit in voluptate. <br />
                        </p>
                    </figcaption>
                </figure>
            </aside>

            <!-- COLOCAR AL LADO DE ASIDE CON LISTA "TIRANDO FLORES"-->
            <article id="ART-A-">
                <dl>
                    <dt>Marcando la Diferencia</dt>
                    <dd>
                        Marcamos la diferencia en todos los sentidos.
                    </dd>
                    <dt>Servicio de Calidad</dt>
                    <dd>
                        Ofrecemos servicio de total calidad.
                    </dd>
                </dl>
            </article>
            
        </section>

        <!-- TERCERA SECCION -->
        <section id="TerceraSeccion">
        <!-- CARROUSEL DE IMAGENES DEL LUGAR Y EQUIPAMIENTO PARA ESTUDIOS -->

        </section>

        <!-- CUARTA SECCION -->
        <section id="CuartaSeccion">
            <!-- COBERTURAS CON ICONO O LOGO CON NOMBRE -->

            <div>
                <!-- MAPA CON SUCURSALES, CONSULTORIOS EXTERNOS, ETC -->
            </div>
        </section>
    </div>
    
</asp:Content>
