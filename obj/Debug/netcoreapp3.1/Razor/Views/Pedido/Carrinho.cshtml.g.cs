#pragma checksum "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f03e0eb39d45328593d4028040644ec7df05a58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_Carrinho), @"mvc.1.0.view", @"/Views/Pedido/Carrinho.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\_ViewImports.cshtml"
using DeliveryApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\_ViewImports.cshtml"
using DeliveryApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f03e0eb39d45328593d4028040644ec7df05a58", @"/Views/Pedido/Carrinho.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8c17bd6bc47298a47a1f0d59f587625e92904df", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_Carrinho : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Produto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

  <h2 class=""text-danger"">Carrinho</h2>
  <table class=""table"" style=""margin-top: 20px;"">
    <thead>
      <tr>
       <th>Imagem</th>
        <th>Nome</th>
        <th>Descrição</th>
        <th>Valor</th>
        <th>Ações</th>
      </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 16 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
     foreach(var produto in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("      <tr class=\"text-danger\">\r\n       <td><img");
            BeginWriteAttribute("src", " src=\"", 390, "\"", 424, 2);
            WriteAttributeValue("", 396, "/imagens/", 396, 9, true);
#nullable restore
#line 18 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
WriteAttributeValue("", 405, produto.NomeImagem, 405, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 60px;\"></td>\r\n        <td>");
#nullable restore
#line 19 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
       Write(produto.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 20 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
       Write(produto.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 21 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
       Write(produto.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td><a");
            BeginWriteAttribute("href", " href=\"", 570, "\"", 613, 2);
            WriteAttributeValue("", 577, "/Produto/removercarrinho/", 577, 25, true);
#nullable restore
#line 22 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
WriteAttributeValue("", 602, produto.Id, 602, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Excluir</a> </td>\r\n      </tr>\r\n");
#nullable restore
#line 24 "C:\Users\jucie\OneDrive\Documentos\pos\C#\deliveryApp\Views\Pedido\Carrinho.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n  </table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Produto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
