using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Exceptions;

namespace TestProject.Views
{
    public static class ViewMapping
    {

        private static readonly Dictionary<string, Type> viewMappings = new()
        {
            { "BobchosBarHomeView", typeof(BobchosBarHomeView) }
        };

        public static Type GetViewType(string key)
        {
            if (!viewMappings.ContainsKey(key))
            {
                throw new AutomationException($"{key} is not registered");
            }
            return viewMappings[key];
        }
    }
}
