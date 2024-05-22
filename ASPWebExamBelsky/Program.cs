using ASPWebExamBelsky.Storage.DBContext;
using ASPWebExamBelsky.Storage.Service;
using ASPWebExamBelsky.Storage.DBControllers;

var builder = WebApplication.CreateBuilder(args);

//Configuring
builder.Services.AddControllers();
builder.Services.AddDbContext<MainDBContext>();
builder.Services.AddTransient<IOrderService, OrderDBController>();
builder.Services.AddTransient<IProductService, ProductDBController>();


//Starting
var app = builder.Build();

app.MapControllers();

app.Run();
