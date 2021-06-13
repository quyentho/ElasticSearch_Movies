using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Nest;

namespace MoviesSearch.Domain
{
	public static class MoviesSearchConfiguration
	{

		public static ElasticClient GetClient() => new ElasticClient(_connectionSettings);

		static MoviesSearchConfiguration()
		{
			_connectionSettings = new ConnectionSettings(CreateUri(9200))
				.DefaultIndex("movies")
				.DefaultMappingFor<Movie>(i => i
					.IndexName("movies")
				);
		}
		private static readonly ConnectionSettings _connectionSettings;

		public static Uri CreateUri(int port)
		{
			var host = Process.GetProcessesByName("fiddler").Any() 
				? "ipv4.fiddler"
				: "localhost";

			return new Uri($"http://{host}:{port}");
		}
	}
}
