<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInscripcion.aspx.cs" Inherits="PRESENTACION.frmInscripcion" %>


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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:ModalPopupExtender ID="modalApoderado" runat="server" TargetControlID="btnModalApoderado" PopupControlID="mApoderado"></ajaxToolkit:ModalPopupExtender>
     

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

                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarAp" runat="server" text="Cerrar" OnClick="btnCerrarApModal" />
                 </div>
            </div>

                -->  
        </form>
    </center>

    

</body>
</html>