using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpOnline
{
    public class Monaco
    {
        private readonly IJSInProcessRuntime runtime;

        public Monaco(IJSRuntime runtime)
        {
            runtime = runtime as IJSInProcessRuntime;
        }

        public void Initialize(string elementId, string initialCode, string language) => runtime.Invoke<object>("monacoInterop.initialize", elementId, initialCode, language);

        public string GetCode(string elementId) => runtime.Invoke<string>("monacoInterop.getCode", elementId);

        public void SetCode(string elementId, string code) => runtime.Invoke<object>("monacoInterop.setCode", elementId, code);
    }
}
