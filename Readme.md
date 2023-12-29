<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to delete nodes recursively via one delete statement


<p>The ASPxTreeList doesn't allow you to remove nodes recursively in batch mode. When the delete button is clicked, the ASPxTreeList removes nested nodes one-by-one.<br />
This example demonstrates how this approach can be changed: all keys that should be deleted are collected, and then can be removed from the datasource using one delete statement (or query).</p>

<br/>


