using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpOnline
{
    public class Monaco
    {
        //https://www.strathweb.com/2019/06/building-a-c-interactive-shell-in-a-browser-with-blazor-webassembly-and-roslyn/

        private readonly IJSInProcessRuntime runtime;

        public Monaco(IJSRuntime runtime)
        {
            this.runtime = runtime as IJSInProcessRuntime;
        }

        public void Initialize(string elementId, string initialCode, string language) => runtime.Invoke<object>("monacoInterop.initialize", elementId, initialCode, language);

        public string GetCode(string elementId) => runtime.Invoke<string>("monacoInterop.getCode", elementId);

        public void SetCode(string elementId, string code) => runtime.Invoke<object>("monacoInterop.setCode", elementId, code);
    }
}
