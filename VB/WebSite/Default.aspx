<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to delete nodes recursively via one delete statement</title>
	<script type="text/javascript">
	function OnEndCallback (s, e) {
		if (typeof(s.cpKeys) != "undefined")
		{
		   alert("These keys were deleted: " + s.cpKeys);
		   delete s.cpKeys;
		}
	}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxTreeList ID="tree" runat="server" KeyFieldName="id" ParentFieldName="parent_id"
				OnDataBinding="tree_DataBinding" OnNodeDeleted="tree_NodeDeleted" OnNodeDeleting="tree_NodeDeleting" OnCustomJSProperties="tree_CustomJSProperties">
				<Columns>
					<dx:TreeListTextColumn FieldName="id" VisibleIndex="0">
					</dx:TreeListTextColumn>
					<dx:TreeListTextColumn FieldName="parent_id" VisibleIndex="1" Visible="false">
					</dx:TreeListTextColumn>
					<dx:TreeListTextColumn FieldName="text" VisibleIndex="2">
					</dx:TreeListTextColumn>
					<dx:TreeListCommandColumn VisibleIndex="3">
						<DeleteButton Visible="True">
						</DeleteButton>
					</dx:TreeListCommandColumn>
				</Columns>
				<SettingsEditing AllowRecursiveDelete="True" />
				<ClientSideEvents EndCallback="OnEndCallback" />
			</dx:ASPxTreeList>
		</div>
	</form>
</body>
</html>
