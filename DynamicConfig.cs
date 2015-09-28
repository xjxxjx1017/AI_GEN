using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GEN
{
	class DynamicConfig
	{
		// * Pre-set parameters for random-config-testing
		private int seed = 0;
		public int chance_of_0_19_event = 0;
		public int chance_of_0_19_encounter = 0;
		public int chance_of_aggressive_limit_0_100_a = 0;
		public int chance_of_aggressive_limit_0_100_b = 0;
		public double scale_log_e_of_1_100_attack_success = 0;
		public float scale_demi_of_01_2_energy_drain_a = 0;
		public float scale_demi_of_01_2_energy_drain_b = 0;
		public float scale_demi_of_01_1_energy_gain = 0;
		public float scale_demi_of_01_1_reproduce_intent_a = 0;
		public float scale_demi_of_01_1_reproduce_intent_b = 0;
		public float scale_demi_of_01_1_chance_gen_of_a = 0;
		public float scale_demi_of_01_1_percentage_genergy_cost_a = 0;
		public float scale_demi_of_01_1_percentage_genergy_cost_b = 0;
		public float scale_log_e_of_0_100_wandering_gain = 0;
		public float chance_of_0_100_pass_lost = 0;

		public override string ToString()
		{
			string rlt = "Config:\t\t" + seed + "\n";
			rlt += "chance_of_0_19_event:\t\t" + chance_of_0_19_event + "\n";
			rlt += "chance_of_aggressive_limit_0_100_a:\t\t" + chance_of_aggressive_limit_0_100_a + "\n";
			rlt += "chance_of_aggressive_limit_0_100_b:\t\t" + chance_of_aggressive_limit_0_100_b + "\n";
			rlt += "scale_log_e_of_1_100_attack_success:\t\t" + scale_log_e_of_1_100_attack_success + "\n";
			rlt += "scale_demi_of_01_2_energy_drain_a:\t\t" + scale_demi_of_01_2_energy_drain_a + "\n";
			rlt += "scale_demi_of_01_2_energy_drain_b:\t\t" + scale_demi_of_01_2_energy_drain_b + "\n";
			rlt += "scale_demi_of_01_1_energy_gain:\t\t" + scale_demi_of_01_1_energy_gain + "\n";
			rlt += "scale_demi_of_01_1_reproduce_intent_a:\t\t" + scale_demi_of_01_1_reproduce_intent_a + "\n";
			rlt += "scale_demi_of_01_1_reproduce_intent_b:\t\t" + scale_demi_of_01_1_reproduce_intent_b + "\n";
			rlt += "scale_demi_of_01_1_chance_gen_of_a:\t\t" + scale_demi_of_01_1_chance_gen_of_a + "\n";
			rlt += "scale_demi_of_01_1_percentage_genergy_cost_a:\t\t" + scale_demi_of_01_1_percentage_genergy_cost_a + "\n";
			rlt += "scale_demi_of_01_1_percentage_genergy_cost_b:\t\t" + scale_demi_of_01_1_percentage_genergy_cost_b + "\n";
			rlt += "scale_log_e_of_0_100_wandering_gain:\t\t" + scale_log_e_of_0_100_wandering_gain + "\n";
			rlt += "chance_of_0_100_pass_lost:\t\t" + chance_of_0_100_pass_lost + "\n";
			rlt += "\n";
			return rlt;
		}

		static public DynamicConfig generate( int _seed )
		{
			DynamicConfig config = new DynamicConfig( );
			config.seed = _seed;
			Random r = new Random( config.seed );
			config.chance_of_0_19_event = r.Next( 20 );
			config.chance_of_0_19_encounter = r.Next( 20 );
			config.chance_of_aggressive_limit_0_100_a = r.Next( 101 );
			config.chance_of_aggressive_limit_0_100_b = r.Next( 101 );
			config.scale_log_e_of_1_100_attack_success = Math.Log( r.Next( 100 ) ) + 1;
			config.scale_demi_of_01_2_energy_drain_a = ((float)r.Next( 201 )) / 100.0f;
			config.scale_demi_of_01_2_energy_drain_a = ((float)r.Next( 201 )) / 100.0f;
			config.scale_demi_of_01_1_energy_gain = ((float)r.Next( 101 )) / 100.0f;
			config.scale_demi_of_01_1_reproduce_intent_a = ((float)r.Next( 101 )) / 100.0f;
			config.scale_demi_of_01_1_reproduce_intent_b = ((float)r.Next( 101 )) / 100.0f;
			config.scale_demi_of_01_1_chance_gen_of_a = ((float)r.Next( 101 )) / 100.0f;
			config.scale_demi_of_01_1_percentage_genergy_cost_a = ((float)r.Next( 101 )) / 100.0f;
			config.scale_demi_of_01_1_percentage_genergy_cost_b = 1 - config.scale_demi_of_01_1_percentage_genergy_cost_a;
			config.scale_log_e_of_0_100_wandering_gain = (float)Math.Log( r.Next( 101 ) );
			config.chance_of_0_100_pass_lost = r.Next( 101 );
			return config;
		}

	}
}
