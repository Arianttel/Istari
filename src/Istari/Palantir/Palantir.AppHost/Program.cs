var builder = DistributedApplication.CreateBuilder(args);

var postgreServer = builder
	.AddPostgres("postgreserver", port: 15000)
	.WithPgAdmin()
	.WithDataVolume();
var sauronDb = postgreServer.AddDatabase("saurondb");

var sauronDbMigratorEf = builder
	.AddProject<Projects.Sauron_DbMigrator_EfCore>("saurondbmigratoref")
	.WithReference(sauronDb, "Sauron")
	.WaitFor(sauronDb)
	.WithExplicitStart();

var sauron = builder
	.AddProject<Projects.Sauron_IdentityWebApp>("sauron")
	.WithReference(sauronDb, "Sauron")
	.WaitFor(sauronDb);

var sauronDbMigrator = builder
	.AddProject<Projects.Sauron_DbMigrator_DbUp>("saurondbmigrator")
	.WithReference(sauronDb, "Default")
	.WaitFor(sauronDb)
	.WithExplicitStart();

builder.Build().Run();