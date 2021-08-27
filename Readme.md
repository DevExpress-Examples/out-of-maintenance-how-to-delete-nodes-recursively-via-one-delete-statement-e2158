<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128548561/13.1.4%2B)
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

<br/>


