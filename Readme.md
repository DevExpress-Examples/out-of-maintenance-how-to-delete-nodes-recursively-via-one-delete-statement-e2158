<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2158)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to delete nodes recursively via one delete statement
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2158/)**
<!-- run online end -->


<p>The ASPxTreeList doesn't allow you to remove nodes recursively in batch mode. When the delete button is clicked, the ASPxTreeList removes nested nodes one-by-one.<br />
This example demonstrates how this approach can be changed: all keys that should be deleted are collected, and then can be removed from the datasource using one delete statement (or query).</p>


<h3>Description</h3>

<p>You can&#39;t set the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebDataASPxDataDeletingEventArgsMembersTopicAll">e.Cancel</a> property equal to false when performing a custom deleting. When the ASPxTreeList is notified that deleting is canceled, it stops the operation. To cancel the ASPxTreeList deleting mechanism, it should be interrupted with any exception.</p><p>Because the example uses the <i>DataTable</i>, the following exception is raised internally:<br />
<strong>NotSupportedException - &quot;Specified method is not supported.&quot;</strong></p><p>If you use other datasource, you can simply omit the <i>DeleteCommand</i> property declaration, and you&#39;ll get a similar exception that can also be handled by the ASPxTreeList.</p><p>If the exception isn&#39;t handled in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListASPxTreeList_NodeDeletedtopic">ASPxTreeList.NodeDeleted</a> event handler, the treelist will warn you with an alert.</p><p>All deleted keys are collected in a list in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListASPxTreeList_NodeDeletingtopic">ASPxTreeList.NodeDeleting</a> event handler. The ASPxTreeList removes its nodes starting from the most nested one. When deleting ends, the ASPxTreeList binds itself with the refreshed datasource.<br />
We should remove nodes using the collected keys before binding them: <i>ASPxTreeList.DataBinding</i> event handler is most suitable for this purpose.</p>

<br/>


