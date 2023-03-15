using Microsoft.AspNetCore.Mvc;
using PaginationMasPartial.Repositories;

namespace PaginationMasPartial.ViewComponents
{
    public class ApartadoLogeadoViewComponent : ViewComponent
    {
        //AQUI PODRIAMOS TENER CUALQUIER METODO DE UNA CLASE
        //LA PETICION SE REALIZA MEDIANTE EL METODO InvokeAsync
        //ES OBLIGATORIO TENERLO
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
