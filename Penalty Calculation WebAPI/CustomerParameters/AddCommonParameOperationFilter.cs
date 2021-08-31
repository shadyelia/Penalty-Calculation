using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

public class AddCommonParameOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

        var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

        if (descriptor != null && descriptor.ControllerName.StartsWith("Penalty"))
        {
            foreach(var parameter in operation.Parameters)
            {
                if(parameter.Name == "start")
                {
                    parameter.Description = "mm/dd/yyyy";
                    parameter.Required = true;
                } 
                else if (parameter.Name == "end")
                {
                    parameter.Description = "mm/dd/yyyy";
                    parameter.Required = true;
                }
                else if (parameter.Name == "name")
                {
                    parameter.Description = "ex. Egypt, or check countries names from the other controller";
                    parameter.Required = true;
                }
            }
        }
    }
}