using Games.Api.Controllers;
using Games.Core;
using System.Text.Json;

namespace Games.Api.Middlewear
{
    public class ValidCategory
    {
        private readonly RequestDelegate next;
        public ValidCategory(RequestDelegate _next)
        {
            next = _next;
        }
        //בדיקהת קוד קטגוריה עבור פונקציית הוספת מוצר
        public async Task InvokeAsync(HttpContext context)
        {
            // בדיקת סוג הבקשה
            if (context.Request.Method == HttpMethods.Post && context.Request.Path == "/api/products")
            {


                // קריאת גוף הבקשה
                context.Request.EnableBuffering(); // מאפשר קריאה חוזרת של הגוף
                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0; // איפוס הזרם לקריאה מחדש
                // ניסיון לקרוא את גוף הבקשה כ-JSON
                ProductDTO requestData = JsonSerializer.Deserialize<ProductDTO>(requestBody)!;



                // בדיקה אם קוד הקטגוריה תקין (לדוגמה: מספר חיובי בלבד)
                if (requestData == null || requestData.CategoryId <= 0)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid category code.");
                    return;
                }
            }

            // העברת הבקשה הלאה ב-pipeline
            await next(context);
        }
    }
}
