using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GEN
{
	class SystemPlus
	{

		static public List<string> splitCommand( string command )
		{
			// * Split the command by special indicators
			string[] s = command.Split( ' ', ',', '.' );
			// * Filter out the empty commands
			List<string> rlt = new List<string>( );
			foreach ( string ss in s )
			{
				if ( ss != "" && ss != " " )
					rlt.Add( ss );
			}
			return rlt;
		}
	}
}
