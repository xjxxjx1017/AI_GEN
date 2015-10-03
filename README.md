## Auto Game Configuration Tester & Generator (C#)
This is a auto testing tool for game developers. It automatically test and suggest best configurations for games.<br>
**The C# version has stopped updating, check [Python version](https://github.com/xjxxjx1017/ai_gen_py) for new updates !**

### Current Flow
1. Run main.py to start
2. A console pops up
3. The user types in a command
4. The console runs the "Survival Game" simulation with randomly generated configuration for multiple times
5. The console give out a summary, a list of reports
6. The user can type in an integer to check details of a report and the configuration that runs the simulation
7. Return to step 3

### Command List
````
////////////// HELP //////////////////
help                For help
quit                Quit the console
start               Run a standard test
filter x x x x      Run a filter test, only record the test we wanted
                        p1: min years
                        p2: max years
                        p3: min creatures
                        p4: max creatures
single x x          Run series of tests for a single configuration generated
                    by a certain seed
                        p1: a fixed seed for the simulation
                        p2: number of times for the simulation
r (x)               Redo the last 'n' command
                        p1 (=1): the previous 'n' test that you want to execute
[integer]           If the input is an integer, print the detail of a test has
                    the same ID as the integer
//////////////////////////////////////
````
	
### Development Route Map
The C# version has stopped updating, future work will be put on [Python version](https://github.com/xjxxjx1017/ai_gen_py)
#####Thanks!
