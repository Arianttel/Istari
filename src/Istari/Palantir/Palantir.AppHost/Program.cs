var builder = DistributedApplication.CreateBuilder(args);

var postgreServer = builder
	.AddPostgres("postgreserver")
	.WithPgAdmin();
var sauronDb = postgreServer.AddDatabase("saurondb");

var sauron = builder
	.AddProject<Projects.Sauron_IdentityWebApp>("sauron")
	.WithReference(sauronDb, "Sauron");

builder.Build().Run();