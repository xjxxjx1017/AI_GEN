using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GEN
{
	class Universe
	{
		// * A randomly generated config file that can be tracked
		public DynamicConfig config;
		public int seed = 0;
		public Dictionary<String,List<FogShip>> rlt_remainList;
		public int rlt_endYear = 0;
		public int rlt_shipCount = 0;

		public void run( int _seed )
		{
			seed = _seed;
			List<FogShip> shipList = new List<FogShip>( );
			config = DynamicConfig.generate( seed );
			// * Initialize limits
			int timeCount = 1000;
			int shipCount = 1000;
			int shipMax = 10000;
			int scaleSize = 100;
			int currentYear = 0;

			// * Generate ships
			for ( int i = 0; i < shipCount; i++ )
			{
				FogShip newShip = FogShip.createFromGen( new float[] { 
                    RandomEx.r.Next(scaleSize), RandomEx.r.Next(scaleSize), 
                    RandomEx.r.Next(scaleSize), RandomEx.r.Next(scaleSize), 
                    RandomEx.r.Next(scaleSize), RandomEx.r.Next(scaleSize),
                    RandomEx.r.Next(scaleSize), RandomEx.r.Next(scaleSize)
                }, config );
				shipList.Add( newShip );
			}

			// * Run simulation
			for ( int i = 0; i < timeCount; i++ )
			{
				// {} Loop through ships
				foreach ( FogShip ship in shipList )
				{
					// ? Check whether the unit is still alive
					if ( ship.isAlive == false )
						continue;
					// * Chance for an event!
					int dice20 = RandomEx.r.Next( 20 ) + 1;
					// ? Chance for event or wandering
					if ( dice20 >= config.chance_of_0_19_event )
					{
						// * Get a random ship B
						FogShip B = shipList[RandomEx.r.Next( shipList.Count )];
						// ? Chance for encounter or reproduce
						if ( RandomEx.r.Next( 20 ) > config.chance_of_0_19_encounter )	// 50%
							FogShip.encounter( ship, B );
						else
							FogShip.reproduce( ship, B );
					}
					else FogShip.wandering( ship );
					// * Time pass!
					FogShip.timePass( ship );
				}
				// * Remove dead ships
				shipList.RemoveAll( ship => ship.isAlive == false );
				// [] Debug outputs
				Console.Clear( );
				Console.WriteLine( i + "|" + shipList.Count );
				Console.WriteLine( i + "|" + shipList.Count );
				Console.WriteLine( i + "|" + shipList.Count );
				currentYear = i;
				// [] Time to stop debuging
				if ( shipList.Count < 10 || shipList.Count > shipMax )
					break;
			}

			// * A list of ships that still remain on the battle field.
			rlt_remainList = new Dictionary<string, List<FogShip>>( );
			// [] Time to stop debuging
			Console.Clear( );
			Console.WriteLine( "" );
			Console.WriteLine( "" );
			Console.WriteLine( "" );
			Console.WriteLine( "" );
			Console.WriteLine( "" );
			// * Set up the result set
			// {} Loop through remained shiped
			foreach ( FogShip ship in shipList )
			{
				// [] Output remained ship's name and energy.
				Console.Write( ship.name + "|" + ship.energy + ", " );
				// ? Check if it's the same type of ship. 
				if ( rlt_remainList.ContainsKey( ship.name ) )
				{
					// * Add them together, if it is.
					rlt_remainList[ship.name].Add( ship );
				}
				else
				{
					// * Create a new list if it's not
					List<FogShip> newList = new List<FogShip>( );
					newList.Add( ship );
					rlt_remainList.Add( ship.name, newList );
				}
			}
			// * Set up general result information
			rlt_endYear = currentYear;
			rlt_shipCount = shipList.Count;
			// [] Print the end year and total ship count
			Console.WriteLine( "" );
			Console.WriteLine( "" );
			Console.WriteLine( "Year: " + rlt_endYear );
			Console.WriteLine( "Alive: " + rlt_shipCount );
			// [] Print general ship types and counts.
			foreach ( var pair in rlt_remainList )
			{
				Console.Write( pair.Key + "|" + pair.Value.Count + ", " );
			}
		}

		public string ToStringLimit( int limit )
		{
			string rlt = "";
			// [] Print the end year and total ship count
			rlt += "Year: " + rlt_endYear + '\n';
			rlt += "Alive: " + rlt_shipCount + '\n';
			// [] Print general ship types and counts.
			int count = 0; 
			foreach ( var pair in rlt_remainList )
			{
				rlt += pair.Key + "|" + pair.Value.Count + ", ";
				count++;
				if ( count > limit )
					break;
			}
			// [] Create a ship gen summary
			// # 1D: gen category, 2D: gen rank
			List<char> mark = new List<char> {'A', 'B', 'C', 'D', 'E', 'F'};
			int [,] genDiagram2D = new int[FogShip.attribute_count,FogShip.attribute_rank_count];
			foreach ( var pair in rlt_remainList )
			{
				foreach ( FogShip ship in pair.Value )
				{
					// * Get the ship gen summary
					for ( int i = 0; i < ship.gen.Length; i++ )
					{
						// * Find the rank and the sequence
						float value = ship.gen[i];
						char gen = FogShip.generateNameChar( value );
						int rank = mark.IndexOf( gen );
						// * Add the count
						genDiagram2D[i,rank]++;
					}
				}
			}
			// [] Print the ship gen summary
			Console.Write( "Ship attribute summary: \n" );
			Console.Write( "+\tA\tB\tC\tD\tE\tF\n" );
			for ( int i = 0; i < FogShip.attribute_count; i++ )
			{
				Console.Write( "" + i + ": " );
				for ( int j = 0; j < FogShip.attribute_rank_count; j++ )
				{
					Console.Write( "\t" );
					if ( genDiagram2D[i, j] != 0 )
						Console.Write( genDiagram2D[i, j] );
				}
				Console.Write( "\n" );
			}


			rlt += '\n';
			rlt += '\n';
			return rlt;
		}
	}
}
