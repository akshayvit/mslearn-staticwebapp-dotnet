using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;


namespace Api;

public class ProductsGet {
    public readonly ProductData pd;

    public ProductsGet(ProductData p) {
        this.pd=p;
    }
    [FunctionName("ProductsGet")]
    public async Task<ProductData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
    {
        var obj=await pd.getProducts();
        return new OkObjectResult(obj);
    }
}