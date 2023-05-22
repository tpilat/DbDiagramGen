using Envelope.Database.PostgreSql;
using System;
using System.IO;
using System.Text;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var connectionString = "Host=localhost;Database=sbs_n_skusky;Username=postgres;Password=postgres";
			var dbName = "sbs_n_skusky";
			var jsonFilePath = @"c:\Code\GitLab\En\nnsk\N_SKUSKY.json";

			try
			{
				var builder = new MetadataBuilder();
				var model = builder.LoadMetadata(connectionString, dbName);
				var json = model.SaveToJson();

				var dir = Path.GetDirectoryName(jsonFilePath);
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);

				File.WriteAllText(jsonFilePath, json, new UTF8Encoding(false));

				Console.WriteLine("DbToJson - OK");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"DbToJson - ERROR: {ex}");
			}

			Console.WriteLine("---END---");
			Console.ReadLine();
		}
	}
}
