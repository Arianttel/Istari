using DbUp;
using DbUp.Engine;
using DbUp.Support;
using System.Reflection;

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Default");

var upgrader = DeployChanges.To
	.PostgresqlDatabase(connectionString)
	.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => 
		script.Contains(".Pre.Once"),
		new SqlScriptOptions()
		{
			ScriptType = ScriptType.RunOnce,
			RunGroupOrder = 1
		})
	.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script =>
		script.Contains(".Pre.Always"),
		new SqlScriptOptions()
		{
			ScriptType = ScriptType.RunAlways,
			RunGroupOrder = 2
		})
	.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script =>
		script.Contains(".Post.Once"),
		new SqlScriptOptions()
		{
			ScriptType = ScriptType.RunOnce,
			RunGroupOrder = 3
		})
	.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script =>
		script.Contains(".Post.Always"),
		new SqlScriptOptions()
		{
			ScriptType = ScriptType.RunAlways,
			RunGroupOrder = 4
		})
	.LogToConsole()
	.Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine(result.Error);
	Console.ResetColor();
	return;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();