using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Web.Framework
{


    public class CustomizationViewLocationExpander : IViewLocationExpander

    {

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)

        {

            if (context.AreaName?.Equals(AreaNames.Admin) ?? false)
            {
                viewLocations = new[]
                    {
                    $"/Areas/Admin/Customization/Views/{{1}}/{{0}}.cshtml",

                    $"/Areas/Admin/Customization/Views/Shared/{{0}}.cshtml",

                }

                    .Concat(viewLocations);

            }

            viewLocations = new[]

                {

                $"/Customization/Views/{{1}}/{{0}}.cshtml",

                $"/Customization/Views/Shared/{{0}}.cshtml",

            }

                .Concat(viewLocations);

            return viewLocations;

        }

        public void PopulateValues(ViewLocationExpanderContext context)

        {

        }

    }

}
