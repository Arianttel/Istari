using DbUp;

var connectionString = args.First();

var upgrader = DeployChanges.To
	.PostgresqlDatabase(connectionString);