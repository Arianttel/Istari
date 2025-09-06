var builder = DistributedApplication.CreateBuilder(args);

var postgreServer = builder
	.AddPostgres("postgreserver", port: 15000)
	.WithPgAdmin();
var sauronDb = postgreServer.AddDatabase("saurondb");

var sauronDbMigrator = builder
	.AddProject<Projects.Sauron_DbMigrator>("saurondbmigrator")
	.WithReference(sauronDb, "Sauron")
	.WaitFor(sauronDb);

var sauron = builder
	.AddProject<Projects.Sauron_IdentityWebApp>("sauron")
	.WithReference(sauronDb, "Sauron")
	.WaitFor(sauronDb);

builder.Build().Run();