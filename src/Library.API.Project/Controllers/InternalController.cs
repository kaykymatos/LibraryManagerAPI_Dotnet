using Microsoft.AspNetCore.Mvc;

namespace Library.Project.API.Controllers
{
    public class InternalController : ControllerBase
    {

        internal static bool IsResponseNull(object model)
        {
            if (model == null)
                return true;

            return false;
        }
    }
}
