﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInscripcion.aspx.cs" Inherits="PRESENTACION.frmInscripcion" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style>
        .modalBackground{
            background-color: black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 !important;
            z-index:20;
        }
        .modalPopup{
            padding:20px 0px 24px 10px;
            position: relative;
            width:550px;
            height:300px;
            background-color:white;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <center> 
        <a href="frmApoderado.aspx">Apoderado</a>&nbsp;
        <a href="frmEstudiante.aspx">Estudiante</a>&nbsp;
        <a href="frmInscripcion.aspx">Inscripcion</a>&nbsp;
        <h3>GESTION DE INSCRIPCION</h3>
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdInscripcion" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Codigo Gestion</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtcocGestion" runat="server"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Button ID="btnCurso" runat="server" OnClick="btnBuscarCurso" Text="Buscar Curso" /></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Fecha</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtFec" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Codigo Estudiante</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtcodEst" runat="server" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />

                &nbsp;
                
                <asp:Button ID="btnModalApoderado" runat="server" OnClick="Button1_Click" Text="Agregar Apoderado" />
                <asp:Button ID="btnModalCalificacion" runat="server" OnClick="mostrarCalificaion" Text="Ver Calificacion" />
               
        
                <br />
                <br />
                <asp:GridView ID="gvApoderado" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvApoderado_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="codigo" HeaderText="Codigo"/>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                        <asp:BoundField DataField="apellido" HeaderText="Apellido"/>
                        <asp:BoundField DataField="telefono" HeaderText="Telefono"/>  
                           <asp:BoundField DataField="fechaNacimiento" HeaderText="FechaNacimiento"/> 
                           <asp:BoundField DataField="direccion" HeaderText="Direccion"/>  
                         <asp:BoundField DataField="relacion" HeaderText="Relacion"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Seleccionar"/>
                    </Columns>

                </asp:GridView>
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>&nbsp; 
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/><br /><br />
                <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <label>Listado de Inscripcion</label><br />
                <asp:TextBox ID="txtBuscar" runat="server" Width="90px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre de estudiante" OnClick="btnBuscar_Click"/>
                <br />
                <br />
                <asp:GridView ID="gvInscripcion" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvInscripcion_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="codigo" HeaderText="Id"/>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha"/>
                        <asp:BoundField DataField="codigoEstudiante" HeaderText="id estudiante"/>
                        <asp:BoundField DataField="nombre" HeaderText="nombre"/>
                        <asp:BoundField DataField="apellido" HeaderText="apellido"/>
                        <asp:BoundField DataField="codigoCursoGestion" HeaderText="id cursoGestion"/>
                        <asp:BoundField DataField="curso" HeaderText="curso estudiante"/>      
                        <asp:BoundField DataField="año" HeaderText="año"/>   
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Seleccionar"/>
                    </Columns>
                </asp:GridView>
 
            </div>
            <!--   

            <div id="mApoderado" class="modalPopup">
                 <div id="Header" class="header" >
                     Busqueda de Apoderado
                     <br />
                     <br />
                 </div>
                 <div id="main" class="main">
                    <asp:TextBox ID="txtBuscarAp" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarAp" runat="server" Text="Buscar por Nombre" OnClick="btnBuscarApModal"/>
                    <br />
                    <br />
                    <asp:GridView ID="gvApoderadoModal" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="codigo" HeaderText="Codigo"/>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                            <asp:BoundField DataField="apellido" HeaderText="Apellido"/>
                            <asp:BoundField DataField="telefono" HeaderText="Telefono"/>  
                            <asp:BoundField DataField="fechaNacimiento" HeaderText="FechaNacimiento"/> 
                            <asp:BoundField DataField="direccion" HeaderText="Direccion"/>  
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>

                 </div><a href="{71B7402C-C5F6-4B38-9BEF-475BA12F1FBD}|NEGOCIO\NEGOCIO.csproj|c:\users\andre\source\repos\colegio\negocio\apoderado.cs">{71B7402C-C5F6-4B38-9BEF-475BA12F1FBD}|NEGOCIO\NEGOCIO.csproj|c:\users\andre\source\repos\colegio\negocio\apoderado.cs</a>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarAp" runat="server" text="Cerrar" OnClick="btnCerrarApModal" />
                 </div>
            </div>
-->
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--Inicio modal buscar curso--%>
            <asp:Label ID="lblCurso" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="modalCurso" runat="server" TargetControlID="lblCurso" PopupControlID="modalCursoControl" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            <div id="modalCursoControl" class="modalPopup">
                 <div id="Header2" class="header" >
                     Buscar Curso
                     <br />
                     <br />
                 </div>
                 <div id="main2" class="main">
                    <asp:TextBox ID="txtBuscarCurso" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="bBuscarCurso" runat="server" Text="Buscar" OnClick="btnBuscarCusos"/><br />
                     <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="gvCurso" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCurso_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="idCursoGestion" HeaderText="Id"/>
                            <asp:BoundField DataField="nCurso" HeaderText="Curso"/>
                            <asp:BoundField DataField="nGestion" HeaderText="Gestion"/>
                            <asp:BoundField DataField="nParalelo" HeaderText="Paralelo"/>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>
                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarP" runat="server" text="Cerrar" OnClick="btnCerrarCurso" />
                 </div>
            </div>
            <%--Fin modal buscar curso--%> 

            <%--Inicio modal Calificaciones--%>
            <asp:Label ID="lblCali" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="modalCalificacion" runat="server" TargetControlID="lblCali" PopupControlID="modalCalificacionControl" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            <div id="modalCalificacionControl" class="modalPopup">
                <div id="Header3" class="header" >
                     Busqueda de Notas
                     <br />
                     <br />
                 </div>
                <div id="main3" class="main">
                    <asp:TextBox ID="txtNombreEstudiante" runat="server"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtApellidosEstudiante" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarCalificacion" runat="server" Text="Buscar Calificacion" OnClick="btnBuscarEstudiante"/><br />
                     <asp:Label ID="lblErrorCali" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="gvCalificacion" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCalificac<a href="{7E9FEB70-E720-49CD-B749-71FF1A365CEE}|DATOS\DATOS.csproj|c:\users\andre\source\repos\colegio\datos\conexion.cs">{7E9FEB70-E720-49CD-B749-71FF1A365CEE}|DATOS\DATOS.csproj|c:\users\andre\source\repos\colegio\datos\conexion.cs</a>ion_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="nCurso" HeaderText="Curso"/>
                            <asp:BoundField DataField="nMateria" HeaderText="Materia"/>
                            <asp:BoundField DataField="nSer" HeaderText="Nota Ser"/>
                            <asp:BoundField DataField="nSaber" HeaderText="Nota Saber"/>
                            <asp:BoundField DataField="nHacer" HeaderText="Nota Hacer"/>
                            <asp:BoundField DataField="nDecidir" HeaderText="Nota Decidir"/>
                            <asp:BoundField DataField="nPromedio" HeaderText="Nota Total"/>
                            <asp:BoundField DataField="nGestion" HeaderText="Gestion"/>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>
                 </div>
                <div id="cerrarModalCali">
                     <br />
                      <asp:Button id="Button2" runat="server" text="Cerrar" OnClick="btnCerrarCalificacion" />
                 </div>
            </div>
            <%--Fin modal buscar Calificaciones--%> 
        </form>
    </center>

    

</body>
</html>