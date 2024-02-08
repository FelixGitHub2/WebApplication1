using WebApplication1;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/", GetSomething);
app.MapGet("/hello", () => "Goodbye!");
app.MapGet("/teachers/{number}", GetTeacher);

app.Run();
app.Urls.Add("http://*:7232");static string GetSomething()
{
    return "Hello TE21A";
}

static IResult GetTeacher(int number)
{
    List<Teacher> teachers = new() {
    new Teacher() {Name = "Micke", HitPoints = 100},
    new Teacher() {Name = "Martin", HitPoints = 3},
    new Teacher() {Name = "Lena", HitPoints = 3000},
  };

    if (number < 0 || number >= teachers.Count)
    {
        return Results.NotFound();
    }

    return Results.Ok(teachers[number]);
}