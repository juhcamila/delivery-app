#pragma checksum "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74fbf4c8eb1164c67aa28d8a86717eee90a2c181"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_ShowProduto), @"mvc.1.0.view", @"/Views/Produto/ShowProduto.cshtml")]
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
#line 1 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\_ViewImports.cshtml"
using DeliveryApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\_ViewImports.cshtml"
using DeliveryApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74fbf4c8eb1164c67aa28d8a86717eee90a2c181", @"/Views/Produto/ShowProduto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8c17bd6bc47298a47a1f0d59f587625e92904df", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_ShowProduto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Produto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n   <h2 class=\"text-danger\">Produtos</h2>\r\n<br>\r\n  <div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
   foreach(var prod in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("  <div class=\"card col-sm-4\" style=\"width: 30rem; margin: 5px;\">\r\n    <div class=\"card-body text-center\">\r\n      \r\n     <img");
            BeginWriteAttribute("src", " src=\"", 321, "\"", 352, 2);
            WriteAttributeValue("", 327, "/imagens/", 327, 9, true);
#nullable restore
#line 16 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
WriteAttributeValue("", 336, prod.NomeImagem, 336, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 60px;\">\r\n      <h5 class=\"card-title text-danger\">Produto: ");
#nullable restore
#line 17 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
                                             Write(prod.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n      <h6 class=\"card-subtitle mb-2 text-muted\">Descricao: ");
#nullable restore
#line 18 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
                                                      Write(prod.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n      <h6 class=\"card-subtitle mb-2 text-muted\">Empresa: ");
#nullable restore
#line 19 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
                                                    Write(prod.Empresa.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n      <h6 class=\"card-subtitle mb-2 text-muted\">Valor: ");
#nullable restore
#line 20 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
                                                  Write(prod.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 692, "\"", 734, 2);
            WriteAttributeValue("", 699, "/produto/adicionarcarrinho/", 699, 27, true);
#nullable restore
#line 22 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
WriteAttributeValue("", 726, prod.Id, 726, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >Comprar</a> \r\n    </div>\r\n  </div>\r\n");
#nullable restore
#line 25 "C:\Users\COBMAX\Desktop\facul\trabalho\delivery-app\Views\Produto\ShowProduto.cshtml"
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("   </div>");
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
