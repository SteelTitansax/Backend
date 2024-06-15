using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Normal Implementation
//builder.Services.AddSingleton<IPeopleService, People2Service>();
//Implementation KeyValue

builder.Services.AddKeyedSingleton<IPeopleService,PeopleService>("peopleService") ;
builder.Services.AddKeyedSingleton < IPeopleService,People2Service>("people2Service") ;

// Types of dependency injection examples
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");


// DTOs Example

builder.Services.AddScoped<IPostsService, PostsService>();

//HTTP Client injection example

builder.Services.AddHttpClient<IPostsService,PostsService>(c =>

{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
