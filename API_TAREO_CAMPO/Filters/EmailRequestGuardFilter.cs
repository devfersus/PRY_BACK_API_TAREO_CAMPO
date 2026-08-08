using API_TAREO_CAMPO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SEGURIDAD.Usuario_.Web.Aplicacion.DTOs;

namespace API_TAREO_CAMPO.Filters
{
    public class EmailRequestGuardFilter(IRequestGuard guard) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext ctx, ActionExecutionDelegate next)
        {
            var email = ctx.ActionArguments.Values
                .OfType<AgregarUsuarioDTO>()
                .FirstOrDefault()?.Email;

            if (email is null)
            {
                await next();
                return;
            }

            if (!await guard.IntentarAdquirirBloqueoAsync(email, ctx.HttpContext.RequestAborted))
            {
                ctx.Result = new ConflictObjectResult(new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title  = "Solicitud duplicada",
                    Detail = "Ya existe una solicitud en proceso para este email."
                });
                return;
            }

            try
            {
                await next();
            }
            finally
            {
                await guard.LiberarBloqueoAsync(email);
            }
        }
    }
}
