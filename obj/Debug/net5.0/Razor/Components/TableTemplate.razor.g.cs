#pragma checksum "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Components\TableTemplate.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd088c260792566baa876def4182e9744b92a5c1"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorWasmTutorial.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using BlazorWasmTutorial;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using BlazorWasmTutorial.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using BlazorWasmTutorial.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using BlazorWasmTutorial.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\_Imports.razor"
using BlazorWasmTutorial.Data.API;

#line default
#line hidden
#nullable disable
    public partial class TableTemplate<TItem> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "table");
            __builder.AddAttribute(1, "class", "table");
            __builder.OpenElement(2, "thead");
            __builder.AddAttribute(3, "class", "thead-dark");
            __builder.OpenElement(4, "tr");
            __builder.AddContent(5, 
#nullable restore
#line 6 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Components\TableTemplate.razor"
             TableHeader

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.OpenElement(7, "tbody");
#nullable restore
#line 10 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Components\TableTemplate.razor"
         foreach (var item in Items)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "tr");
            __builder.AddContent(9, 
#nullable restore
#line 13 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Components\TableTemplate.razor"
                 RowTemplate(item)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 15 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Components\TableTemplate.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Components\TableTemplate.razor"
       
    [Parameter]
    public RenderFragment TableHeader { get; set; }

    [Parameter]
    public RenderFragment<TItem> RowTemplate { get; set; }

    [Parameter]
    public List<TItem> Items { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
