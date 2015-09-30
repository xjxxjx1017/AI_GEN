using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GEN
{
    class FogShip
    {
		static public int attribute_count = 8;
		static public int attribute_rank_count = 6;
		// * Ship attributes ( it's magic... )
        public float energy;
        public float attack;
        public float reproduction;
        public float speed;
        public float size;
        public float aggressive;
		public float energy_gain;
		public float energy_capacity;
		// * Ship's core testing features: gens, names, and is-alive
        public float[] gen;
        public bool isAlive;
		public String name;		// A B C D E F by gen, 100-90, 90-80, 80-60, 60-40, 40-20, 20-0
		// * Configuration for ships
		static public DynamicConfig config;

        static public FogShip createFromGen( float[] gen, DynamicConfig config )
        {
			FogShip rlt = new FogShip( );
			rlt.isAlive = true;
			// * Create ship attributes from gens
			// # A gens varies from 0 to 99
            rlt.energy = gen[0];
            rlt.attack = gen[1];
            rlt.reproduction = gen[2];
            rlt.speed = gen[3];
            rlt.size = gen[4];
            rlt.aggressive = gen[5];
			rlt.energy_gain = gen[6];
			rlt.energy_capacity = gen[7];
			// * Save the gen and config.
			rlt.gen = gen;
			FogShip.config = config;
			// * Create a name of the ship according to its gen
			// # Each name letter represents a gen approximate value
			// # A name letter varies from A to F
			rlt.name = "";
			foreach ( float g in gen )
				rlt.name += generateNameChar( g );
            return rlt;
        }

        static public int encounter(FogShip a, FogShip b)
        {
			// ? Check whether the ship A and B are still alive
			if ( a.isAlive == false || b.isAlive == false )
				return 0;

			int aWin = 0;
			// ? Check how the encounter will happened
			if ( a.aggressive >= config.chance_of_aggressive_limit_0_100_a &&
				b.aggressive >= config.chance_of_aggressive_limit_0_100_b )
			{
				// ? Check winner
				aWin = a.attack > b.attack * config.scale_log_e_of_1_100_attack_success ? 1 : -1;
				// * Both units lost energy
				b.energy -= a.attack * config.scale_demi_of_01_2_energy_drain_a;
				a.energy -= b.attack * config.scale_demi_of_01_2_energy_drain_b;
			}
			else if ( a.aggressive > config.chance_of_aggressive_limit_0_100_a )
			{
				aWin = 1;
			}
			else if ( b.aggressive > config.chance_of_aggressive_limit_0_100_b )
			{
				aWin = -1;
			}
			// ? Check the winner
			if ( aWin == 1 )
			{
				// * Winner gains energy
				a.energy += b.energy > 0 ? b.energy * config.scale_demi_of_01_1_energy_gain : 0;
				b.isAlive = false;
				// [] Show the battle in the console
				Console.WriteLine( "Encounter: " + a.name + " > " + b.name + " +" + ( b.energy > 0 ? b.energy : 0 ) );
			}
			else if ( aWin == -1 )
			{
				// * Winner gains energy
				b.energy += a.energy > 0 ? a.energy * config.scale_demi_of_01_1_energy_gain : 0;
				a.isAlive = false;
				// [] Show the battle in the console
				Console.WriteLine( "Encounter: " + a.name + " > " + b.name + " +" + ( a.energy > 0 ? a.energy : 0 ) );
			}
            return aWin;
        }

        static public FogShip reproduce(FogShip a, FogShip b)
		{
			// ? Check whether the ship A and B are still alive
			if ( a.isAlive == false || b.isAlive == false )
				return null;
			// ? Check whether both ship want to reproduce
			if ( RandomEx.r.Next( 100 ) * config.scale_demi_of_01_1_reproduce_intent_a < a.reproduction ||
				RandomEx.r.Next( 100 ) * config.scale_demi_of_01_1_reproduce_intent_a < b.reproduction )
				return null;

			// * Create a new ship by gen mixing
			FogShip rlt;
			float[] gen = { 0, 0, 0, 0, 0, 0, 0, 0 };
			for ( int i = 0; i < a.gen.Length; i++ )
			{
				gen[i] = RandomEx.r.Next( 100 ) > 49 * config.scale_demi_of_01_1_chance_gen_of_a ? 
					a.gen[i] : b.gen[i];
			}
			rlt = createFromGen( gen, config );
			// rlt.energy = a.reproduction + b.reproduction;

			a.energy -= rlt.energy * 0.5f * config.scale_demi_of_01_1_percentage_genergy_cost_a;
			b.energy -= rlt.energy * 0.5f * config.scale_demi_of_01_1_percentage_genergy_cost_b;

			Console.WriteLine( "Reproduce: " + a.name + " + " + b.name + " = " + rlt.name );
			return rlt;
		}

        static public int wandering(FogShip a)
        {
			// Console.Write( a.name + ": " + a.energy + ", " );
			a.energy += a.energy_gain * config.scale_log_e_of_0_100_wandering_gain;
            return 0;
        }

        static public int timePass(FogShip a)
        {
			// ? Check whether the ship will lost some energy
			if ( RandomEx.r.Next( 100 ) > config.chance_of_0_100_pass_lost )
				a.energy -= 1;
            return 0;
        }

		static public char generateNameChar( float gen )
		{
			if ( gen > 90 )
				return 'A';
			if ( gen > 80 )
				return 'B';
			if ( gen > 60 )
				return 'C';
			if ( gen > 40 )
				return 'D';
			if ( gen > 20 )
				return 'E';
			return 'F';
		}
    }
}
