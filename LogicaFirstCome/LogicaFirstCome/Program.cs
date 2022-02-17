using LogicaFirstCome;

// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

EstadoEjecucion estadoEjecucion = new EstadoEjecucion();
BloqueControl bloqueControl = new BloqueControl();


//foreach (var item in EstadoInicial.ProcesosListos)
//{
//    Console.WriteLine("Proceso Inicio " + item.Name + " " + item.TiempoLlegada + " Rafaga "+ item.Rafaga);
//}

bloqueControl.IniciarOperacion();

//Proceso proceso = EstadoInicial.ProcesosListos.Dequeue();
//estadoEjecucion.Ejecutar(proceso);

//var services = new ServiceCollection();

//services.AddSingleton<EstadoInicial>();

/*using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<EstadoInicial>()
        .AddScoped<EstadoBloqueo>()
            .AddScoped<EstadoEjecucion>())

    .Build();

ExemplifyScoping(host.Services);



await host.RunAsync();

static void ExemplifyScoping(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    BloqueControl mando = provider.GetRequiredService<BloqueControl>();
    //ogger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

    mando.AgregarProceso();
    Console.WriteLine("...");

    
}*/