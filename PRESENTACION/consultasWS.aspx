<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultasWS.aspx.cs" Inherits="PRESENTACION.consultasWS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <a href="frmApoderado.aspx">Apoderado</a>&nbsp;
    <a href="frmEstudiante.aspx">Estudiante</a>&nbsp;
    <a href="frmInscripcion.aspx">Inscripcion</a>&nbsp;
    <a href="consultasWS.aspx">Consultas web services</a>&nbsp;
    <form id="form1" runat="server">
       <h3>CONSULTAS</h3>
        <div>
            <div>
                <h4>BUSCAR CURSO POR NOMBRE</h4>
                <div>
                    Curso<br />
                    <asp:TextBox ID="txtBuscarCur" runat="server" OnTextChanged="txtBuscarCur_TextChanged"></asp:TextBox>             
                    <asp:Button ID="btnBuscarCur" runat="server" Text="Buscar Curso por nombre" OnClick="btnBuscarCurso_Click" style="height: 29px" />
                    <br />
                    <br />
                    <asp:GridView ID="gdvCurso" runat="server">
                    </asp:GridView>
                    <br />
                </div>
                
                <h4>BUSCAR INSCRIPCION POR NOMBRE DE ESTUDIANTE</h4>
                <div>
                    Inscripcion<br />
                    <asp:TextBox ID="txtBuscarInsc" runat="server" OnTextChanged="txtBuscarInsc_TextChanged"></asp:TextBox>             
                    <asp:Button ID="btnBuscarInsc" runat="server" Text="Buscar Inscripcion por nombre estudiante" OnClick="btnBuscarInsc_Click" style="height: 29px" />
                    <br />
                    <br />
                    <asp:GridView ID="gdvInscripcion" runat="server">
                    </asp:GridView>
                    <br />
                </div>
              
            </div>
        </div>
    </form>
</body>
</html>
