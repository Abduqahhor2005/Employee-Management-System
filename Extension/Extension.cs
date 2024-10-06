using Exam9.Service;

namespace Exam9.Extension;

public static class Extension
{
    public static void AddService(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
    }
}