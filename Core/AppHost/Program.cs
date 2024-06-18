using HotChocolate.Fusion.Aspire;

var builder = DistributedApplication.CreateBuilder(args);

var ActorService = builder.AddProject<Projects.AspirePoC_ActorService>("aspirepoc-actorservice");

var BookService = builder.AddProject<Projects.AspirePoC_BookService>("aspirepoc-bookservice");

builder.AddFusionGateway<Projects.AspirePoC_GatewayService>("aspirepoc-gatewayservice")
        .WithOptions(new FusionCompositionOptions
        {
            EnableGlobalObjectIdentification = true
        })
        .WithSubgraph(ActorService)
        .WithSubgraph(BookService);


builder.Build().Compose().Run();
