// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorWasmTutorial.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/home")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "D:\Work\Dev\C# DotNet\Web Apps\Blazor Tutorial\BlazorWasmTutorial\Pages\Index.razor"
      
    public string Token { get; set; }

    protected async override Task OnInitializedAsync()
    {
        this.Token = await storageSerivice.GetItemAsync<string>("token");

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.LocalStorage.ILocalStorageService storageSerivice { get; set; }
    }
}
#pragma warning restore 1591
