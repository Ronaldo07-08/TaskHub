namespace Api.Hw.DI_task
{

    public abstract class DisposedService<TService> : IDisposable, IHasInstanceId
    {
        public Guid InstanceId { get; }
        private bool _isDisposed = false;

        public DisposedService()
        {
            InstanceId = Guid.NewGuid();
            Console.WriteLine($"[Created] Name->{typeof(TService).Name}, InstanceId->{this.InstanceId}");
        }


        public virtual void Dispose()
        {
            if (_isDisposed)
                return;

            Console.WriteLine($"[Disposed] Name->{typeof(TService).Name}, InstanceId->{InstanceId}");

            _isDisposed = true;
        }

    }

    public interface ITransient1 : IHasInstanceId { }
    public interface ITransient2 : IHasInstanceId { }
    public interface IScoped1 : IHasInstanceId { }
    public interface IScoped2 : IHasInstanceId { }
    public interface ISingleton1 : IHasInstanceId { }
    public interface ISingleton2 : IHasInstanceId { }
    public class FirstServiceT : DisposedService<FirstServiceT>, ITransient1 { }
    public class SecondServiceT : DisposedService<SecondServiceT>, ITransient2 { }

    public class FirstServiceSc : DisposedService<FirstServiceSc>, IScoped1 { }
    public class SecondServiceSc : DisposedService<SecondServiceSc>, IScoped2 { }

    public class FirstServiceS : DisposedService<FirstServiceS>, ISingleton1 { }
    public class SecondServiceS : DisposedService<SecondServiceS>, ISingleton2 { }
}

