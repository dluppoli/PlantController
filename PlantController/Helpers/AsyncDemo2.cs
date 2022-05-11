using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantController.Helpers
{
    public static class AsyncDemo2
    {
        public async static Task<string> Start()
        {
            return await a();
        }
        async static Task<string> a()
        {
            return await b();
        }

        async static Task<string> b()
        {
            return await c();
        }

        async static Task<string> c()
        {
            string s = null;
            return await Task.FromResult(s.ToLower());
        }
    }
}
