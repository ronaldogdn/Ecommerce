#pragma checksum "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6bd9f2a14d0cf35e3f1f8fd8528f448097390c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_Alterar), @"mvc.1.0.view", @"/Views/Produto/Alterar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produto/Alterar.cshtml", typeof(AspNetCore.Views_Produto_Alterar))]
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
#line 1 "C:\Ronaldo\Ecommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce;

#line default
#line hidden
#line 2 "C:\Ronaldo\Ecommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6bd9f2a14d0cf35e3f1f8fd8528f448097390c5", @"/Views/Produto/Alterar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbcd7c65731fc074a835809e73fcf2cf9014c29", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_Alterar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Alterar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
  
     
    Produto produto = ViewBag.Produto;

#line default
#line hidden
            BeginContext(54, 38, true);
            WriteLiteral("    <div class=\"container \">\r\n        ");
            EndContext();
            BeginContext(92, 1598, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a298f3d737c4a1f999de5c4ce8ebfb3", async() => {
                BeginContext(133, 158, true);
                WriteLiteral("\r\n            <fieldset>\r\n                <legend>Alterar produto</legend>\r\n                <div class=\"form-group\">\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 291, "\"", 317, 1);
#line 10 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
WriteAttributeValue("", 299, produto.ProdutoId, 299, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(318, 224, true);
                WriteLiteral(" name=\"hdnID\" id=\"hdnID\" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"Id\">Id:</label>\r\n                    <input type=\"text\" class=\"form-control\" name=\"txtId\" id=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 542, "\"", 568, 1);
#line 14 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
WriteAttributeValue("", 550, produto.ProdutoId, 550, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(569, 218, true);
                WriteLiteral(" readonly=\"\" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Nome:</label>\r\n                    <input type=\"text\" class=\"form-control\" required name=\"txtNome\" id=\"nome\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 787, "\"", 808, 1);
#line 18 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
WriteAttributeValue("", 795, produto.Nome, 795, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(809, 221, true);
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Descrição:</label>\r\n                    <input type=\"text\" class=\"form-control\" required name=\"txtDescricao\" id=\"descricao\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1030, "\"", 1056, 1);
#line 22 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
WriteAttributeValue("", 1038, produto.Descricao, 1038, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1057, 209, true);
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Preço:</label>\r\n                    <input type=\"text\" class=\"form-control\" required name=\"txtPreco\" id=\"preco\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1266, "\"", 1288, 1);
#line 26 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
WriteAttributeValue("", 1274, produto.Preco, 1274, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1289, 224, true);
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label>Quantidade:</label>\r\n                    <input type=\"text\" class=\"form-control\" required name=\"txtQuantidade\" id=\"quantidade\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1513, "\"", 1540, 1);
#line 30 "C:\Ronaldo\Ecommerce\Ecommerce\Views\Produto\Alterar.cshtml"
WriteAttributeValue("", 1521, produto.Quantidade, 1521, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1541, 142, true);
                WriteLiteral(" />\r\n                </div>\r\n                <input type=\"submit\" class=\"btn btn-primary\" value=\"Salvar\" />\r\n            </fieldset>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1690, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
