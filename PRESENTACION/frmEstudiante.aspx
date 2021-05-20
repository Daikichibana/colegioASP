<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstudiante.aspx.cs" Inherits="PRESENTACION.estudiante" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center>
        <a href="frmApoderado.aspx">Apoderado</a>&nbsp;
        <a href="frmEstudiante.aspx">Estudiante</a>&nbsp;
        <a href="frmInscripcion.aspx">Inscripcion</a>&nbsp;
        <a href="consultasWS.aspx">Consultas web services</a>&nbsp;
        <h3>GESTION DE ESTUDIANTES</h3>
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdestudiante" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Nombre</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Apellido</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Direccion</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Fecha</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtFecha" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Telefono</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>&nbsp; 
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/><br /><br />
                <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <label>Listado de Estudiantes</label><br />
                <asp:TextBox ID="txtBuscar" runat="server" Width="90px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click"/>
                <br />
                <br />
                <asp:GridView ID="gvEstudiante" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvEstudiante_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="codigo" HeaderText="codigo"/>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                        <asp:BoundField DataField="apellido" HeaderText="Apellido"/>
                        <asp:BoundField DataField="direccion" HeaderText="Direccion"/>
                        <asp:BoundField DataField="fechaNacimiento" HeaderText="FechaNacimiento"/>
                        <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Seleccionar"/>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </center>
</body>
</html>

