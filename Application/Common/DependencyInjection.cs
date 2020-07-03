using System.Reflection;

namespace Application.Common
{
    public static class DependencyInjection
    {
        public static Assembly GetAssembly => Assembly.GetExecutingAssembly();
    }
}