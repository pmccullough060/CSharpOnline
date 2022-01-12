using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpOnline.Pages
{
    public partial class Index
    {
        public string Output = "";

        public const string DefaultCode = @"using System;

        class Program
        {
        public static void Main()
            {
                Console.WriteLine(""Hello World"");
            }   
        }";

        [Inject]
        private HttpClient Client { get; set; }

        [Inject]
        private Monaco Monaco { get; set; }

        protected override Task OnInitializedAsync()
        {
            Compiler.InitializeMetadataReferences(Client);
            return base.OnInitializedAsync();
        }

        /// <summary>
        /// Invoked each time the component is rendered.
        /// 
        /// </summary>
        /// <param name="firstRender"></param>
        protected override void OnAfterRender(bool firstRender)
        {

            //Calling the base implementation of this method:
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                Monaco.Initialize("container", DefaultCode, "csharp");
                var result = Run();
            }

        }

        public Task Run()
        {
            return Compiler.WhenReady(RunInternal);
        }

        async Task RunInternal()
        {

        }
    }
}
