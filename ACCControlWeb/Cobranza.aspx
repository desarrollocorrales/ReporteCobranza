<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAcc.Master" AutoEventWireup="true" CodeBehind="Cobranza.aspx.cs" Inherits="ACCControlWeb.Cobranza" %>
<%@ MasterType virtualPath="~/ControlAcc.master"%>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v10.2.Export, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid.Export" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2.Export, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Styles/navegacion.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDataArea" runat="server">         
    <div style="margin:1em;">            
            <table>
            <tr>
                <td><dx:ASPxLabel ID="ASPxLabel1" runat="server" 
                        ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" 
                        CssPostfix="Office2010Blue" Text="Pronostico de Cobranza al: ">
                    </dx:ASPxLabel>
                </td>
                <td><dx:ASPxDateEdit ID="calFechaPronostico" runat="server" 
                    ondatechanged="calFechaPronostico_DateChanged" AutoPostBack="True" 
                        ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" 
                        CssPostfix="Office2010Blue" EditFormat="Custom" EditFormatString="dd-MMM-yyyy" 
                        Spacing="0" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                    <CalendarProperties>
                        <HeaderStyle Spacing="1px" />
                    </CalendarProperties>
                    <ButtonStyle Width="13px">
                    </ButtonStyle>
                </dx:ASPxDateEdit>
                </td>
                <td>&nbsp;</td>
            </tr>
            </table>
    </div>          
                
    <dx:ASPxPivotGrid ID="grcDatos" Width="100%" runat="server" ClientIDMode="AutoID">
      <OptionsView ShowHorizontalScrollBar="true" />
      <Fields>
                <dx:pivotgridfield ID="fieldCLIENTE" Area="RowArea" AreaIndex="0" 
                    Caption="Cliente" FieldName="CLIENTE">
                    <ValueStyle CssClass="aspxpvCliente">
                    </ValueStyle>
                </dx:pivotgridfield>
                <dx:pivotgridfield ID="fieldFOLIO" Area="RowArea" AreaIndex="1" Caption="Folio" 
                    FieldName="FOLIO">
                </dx:pivotgridfield>
                <dx:pivotgridfield ID="fieldFECHAVENCIMIENTO" Area="ColumnArea" AreaIndex="0" 
                    Caption="Fecha Vencimiento" FieldName="FECHA_VENCIMIENTO" 
                    ValueFormat-FormatString="ddd -  dd" ValueFormat-FormatType="DateTime" 
                    Width="150">
                    <ValueStyle CssClass="aspxpvVence">
                    </ValueStyle>
                </dx:pivotgridfield>
                <dx:pivotgridfield ID="fieldIMPORTE" Area="RowArea" AreaIndex="2" 
                    Caption="Importe" FieldName="IMPORTE" ValueFormat-FormatString="{0:C4}" 
                    ValueFormat-FormatType="Numeric">
                </dx:pivotgridfield>
                <dx:pivotgridfield ID="fieldFECHAVENCIMIENTO1" Area="RowArea" AreaIndex="3" 
                    Caption="Vence" FieldName="FECHA_VENCIMIENTO" 
                    ValueFormat-FormatString="dd-MMM-yyyy" ValueFormat-FormatType="DateTime">
                    <ValueStyle CssClass="aspxpvVence">
                    </ValueStyle>
                </dx:pivotgridfield>
                <dx:pivotgridfield ID="fieldSALDO" Area="DataArea" AreaIndex="0" 
                    Caption="Saldo" FieldName="SALDO" ValueFormat-FormatString="{0:C4}" 
                    ValueFormat-FormatType="Numeric">
                </dx:pivotgridfield>
                <dx:PivotGridField ID="fielddocumentorecuperado" AllowedAreas="DataArea" 
                    Area="DataArea" AreaIndex="1" Caption="Documento recuperado" EmptyCellText=" " 
                    FieldName="documento_recuperado">
                </dx:PivotGridField>
            </Fields>
            <OptionsView ShowColumnGrandTotals="False" ShowRowTotals="False" 
                ShowHorizontalScrollBar="True" ShowFilterHeaders="False" />
            <OptionsPager RowsPerPage="50">
            </OptionsPager>
            <OptionsLoadingPanel>
                <Image Url="~/App_Themes/Office2010Blue/PivotGrid/Loading.gif">
                </Image>
                <Style ImageSpacing="5px">
                </Style>
            </OptionsLoadingPanel>
            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                <CustomizationFieldsBackground Url="~/App_Themes/Office2010Blue/PivotGrid/pcHBack.png">
                </CustomizationFieldsBackground>
                <LoadingPanel Url="~/App_Themes/Office2010Blue/PivotGrid/Loading.gif">
                </LoadingPanel>
            </Images>
            <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" 
                CssPostfix="Office2010Blue">
                <LoadingPanel ImageSpacing="5px">
                </LoadingPanel>
            </Styles>
            <StylesPager>
                <PageNumber ForeColor="#3E4846">
                </PageNumber>
                <Summary ForeColor="#1E395B">
                </Summary>
            </StylesPager>
            <StylesEditors ButtonEditCellSpacing="0">
            </StylesEditors>
    </dx:ASPxPivotGrid>
    <dx:ASPxPivotGridExporter ID="exporter" runat="server" ASPxPivotGridID="grcDatos" ViewStateMode="Enabled"></dx:ASPxPivotGridExporter>
    <table style="margin-top: 1em;">
        <tr>
            <td><dx:ASPxButton Text="Excel 2007" ID="btnExportar" ToolTip="Exportar tabla a excel" runat="server" ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue" onclick="btnExportar_Click" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"></dx:ASPxButton></td>
            <td><dx:ASPxButton Text="Excel 2003" ID="btnExportar2003" ToolTip="Exportar tabla a excel" runat="server" ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue" onclick="btnExportar2003_Click" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"></dx:ASPxButton></td>                        
        </tr>
    </table>
</asp:Content>
