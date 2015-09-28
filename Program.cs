using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GEN
{
	class Program
	{

		static void Main( string[] args )
		{
			// * Config params for testing
			List<Universe> uList = new List<Universe>( );
			int universeMax = 30;
			// * Run test
			for ( int i = 1; i <= universeMax; i++ )
			{
				Universe u = new Universe( );
				uList.Add( u );
				u.run( i );
			}
			// [] Print results
			Console.Clear( );
			foreach ( Universe u in uList )
			{
				Console.WriteLine( "Seed: " + u.seed +
					"\t\tEnd year: " + u.rlt_endYear +
					"\t\tShip count: " + u.rlt_shipCount );
			}
			// * Prevent the console from shutting down.
			string command = "";
			while ( command.Equals( "quit" ) == false )
			{
				command = Console.ReadLine( );
				try
				{
					// * If the input is an integer, print the config id
					int id = Convert.ToInt32( command );
					if ( id > 0 )
					{
						string config;
						config = DynamicConfig.generate( id ).ToString( );
						Console.WriteLine( config );
						Console.WriteLine( uList[id - 1].ToStringLimit( 10 ) );
					}
				}
				catch( Exception e )
				{
				}
			}
		}
	}
}
