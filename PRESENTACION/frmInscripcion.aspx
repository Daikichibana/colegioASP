<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInscripcion.aspx.cs" Inherits="PRESENTACION.frminscripcion" %>

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
        <h3>GESTION DE INSCRIPCION</h3>
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdInscripcion" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>CodigoGestion</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtcocGestion" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Fecha</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtFec" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>CodigoEst</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextcodEst" runat="server" ></asp:TextBox></asp:TableCell>
                      
                      
                    </asp:TableRow>
        
                </asp:Table>
                <br />
                <label>Apoderado</label><br />
                
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
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Inscripcion" OnClick="btnBuscar_Click"/>
                <br />
                <br />
                <asp:GridView ID="gvInscripcion" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvInscripcion_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="idinscripcion" HeaderText="idinscripcion"/>
                        <asp:BoundField DataField="cocgestion" HeaderText="cocGestion"/>
                        <asp:BoundField DataField="fec" HeaderText="Fec"/>
                        <asp:BoundField DataField="codest" HeaderText="codEst"/>                      
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Seleccionar"/>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </center>
</body>
</html>