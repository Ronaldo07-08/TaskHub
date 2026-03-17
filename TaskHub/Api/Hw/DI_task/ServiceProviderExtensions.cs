namespace Api.Hw.DI_task
{
    public static class ServiceProviderExtensions
    {
        public static void TestResolve<TService>(this IServiceProvider serviceProvider)
            where TService : IHasInstanceId
        {
            Console.WriteLine();
            Console.WriteLine("TestResolve");

            var first = serviceProvider.GetRequiredService<TService>();
            var second = serviceProvider.GetRequiredService<TService>();

            Console.WriteLine($"{typeof(TService).Name} IID1->{first.InstanceId}, IID2->{second.InstanceId}");

            bool isSame = object.ReferenceEquals(first, second);

            Console.WriteLine($"Объект один и тот же?->{isSame}");
        }
    }
}
