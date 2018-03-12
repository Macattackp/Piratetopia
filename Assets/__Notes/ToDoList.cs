/*
 * *****CHARACTER*******   
 * 
 *      1. CharacterCreation
 *            Gender
 *              Male
 *              Female
 *            BodySize
 *              Kid
 *              Whimpy
 *              Average
 *              Fat
 *              Herculian
 *              Giant
 *            Head
 *              Head Shape
 *              Hair
 *              Hair Color
 *            Eyes
 *              Eye Shape
 *              Eye Color
 *            Legs
 *            Arms  
 *     2. Character States
 *          Healthy (Average State)
 *          Desperate (Near Death, may act different)
 *          Enraged (When High Reputation Person Is Injured)
 *          Knocked Out (Unconscious, can be rescued)
 *          Dead        (No longer in world, reputation still stands)  
 *              
 * 
 * ----PLAYER----- 
 *       1. Make Character Move
 *              Make Character Jump (bound to space)
 *              Make Character Run (bound to shift)
 *       2. Combat Types
 *           Brawl punch (bound to 1)
 *           Melee Weapon (bound to 2)
 *           Ranged Weapon (bound to 3)
 *          Grappling Hook (Ctrl Target)
 *       4. Inventory
 *           Equipment
 *           Ships
 *           Crew
 *           Bounty
 *              Any Pirate Hunter Will React for Any Bounty
 *              Navy Bounty
 *                  Any Navy Member Will React
 *              Pirate Bounty
 *                  Any Pirates Will React
 *              Local Bounty
 *                  Only Affects Local Island
 *           Treasure
 *       5. Stats
 *              Name
 *              Level
 *              Health
 *              Skills
 *                  Brawling
 *                  Melee Weapons
 *                  Ranged Weapons
 *                  Cursed Medalions
 *                      Brawl Powers
 *                          Light Hit       getinput.leftmouse
 *                          Charged Hit     hold left mouse
 *                          AOE             hold left mouse
 *                          Channeled       hold left mouse
 *                      Ranged Shots
 *                      Weapon Enchants
 *                      Grappling
 *          
 *------AI--------
 *      1. Movement
 *      2. Reputation
 *      3. Preferences
 *      4. Rank     int rank= 11
 *          Mob (Easy to destroy, come in large groups)
 *          Basic
 *          Sergeant
 *          Lietenant
 *          Vice Captain
 *          Captain
 *          Vice Admiral
 *          Admiral
 *          Top Tier
 *          Emperor
 *          Behemeath
 * 
 * 
 * ~~~~~PIRATES~~~~
 * 
 * 
 * ~~~~~PIRATE HUNTERS~~~~~
 * 
 * 
 * ~~~~~NAVY~~~~~~
 * 
 * 
 * ~~~~~~VILLAGERS~~~~~~
 * 
 *          
 * *****WORLD*****
 * 
 * --------ISLANDS--------
 * 
 *      1. Biomes
 *          Jungle
 *          Desert
 *          Forest
 *          City
 *          Shanty
 *          Mountain
 *      2. Sizes
 * 
 * 
 * -------SEA--------
 *      
 *      1. Currents
 *      2. Phenomenon
 * 
 * 
 * -------VILLAGES------
 * 
 * 
 * 
 * ------NAVY-------
 * 
 *      1. Camp
 *      2. Outpost
 *      3. Base
 *      4. Fortress
 *      5. Prison
 *      6. Research Facility
 *      7. Warehouse
 *      8. Headquarters
 *      
 * -------PIRATE HUNTERS------
 * 
 *      1. Bounty Office 
 * 
 * -------PIRATE BASES-------
 * 
 * 
 * *****SHIP******
 * 
 * --------MODULES----------
 * 
 *      1. Propulsion
 *          Sails
 *          Steamship
 *          Cannon (only good for short bursts)
 *      2. Weapons
 *          Cannon
 *          Grappling Launcher
 *          Ram
 *      3. Training
 *          Shooting Range
 *      4. Armor
 *      5. Services
 *          Medical Bay
 *          Weapons Workshop
 *          Carpentry Shop
 * 
 * -------MOVEMENT---------
 * 
 *      1. Wind
 *      2. Currents
 *      3. Steering
 *      4. Propulsion
 * 
 * 
 * -------STATS---------
 * 
 * 
 * ***********ITEMS****************
 * 
 * ------------WEAPONS-------------------
 *      1. If you parry a weapon which is stronger/heavier than yours, your weapon might break
 *      2. Wood dagger vs Iron cleaver = dagger breaks
 *      3. Wood Cleaver vs iron dagger = parry no break
 * 
 * -----------Melee Weapons------------
 * 
 *      1. Daggers (low damage high speed)
 *      2. Swords (Average damage average speed)
 *      3. Hammers (low damage high knock back, Non Lethal)
 *      4. Axes
 *      5. Two Handed Swords (Low speed high damage)
 *      6. Halbard (Below Average Speed, Slightly Higher Damage, Bit of Knockback)
 *      7. Two Handed Axe (Low Speed, High Damage)
 *      8. Two Handed Hammer (Slow Speed, High Knockback)
 *      9. Buster Swords (Slowest Speed, High Knockback, Strong Block)
 * 
 * 
 * ----------Ranged Weapons------------
 * 
 *      1. Pistol (Low Damage, Fast Time Between Shots)
 *      2. Slingshot (Low Damage, Non Lethal)
 *      3. Rifle (Medium Reload, long range, high damage)
 *      4. Cannon (Slow Reload, Slow Movement, AOE Damage, Knockback)
 *      5. Boomarang (Low Damage Non Lethal)
 * 
 * 
 * 
 * ----------Costume Pieces------------
 *      1. Head
 *      2. Eyes
 *          Left
 *          Right
 *      3. Nose
 *      4. Mask
 *      5. Neck
 *      6. Shoulders
 *      7. Chest
 *      8. Back
 *      9. Upper Arms
 *          Left
 *          Right
 *      10. Lower Arms
 *          Left
 *          Right
 *      11. Hands
 *          Left
 *          Right
 *      12. Waist
 *      13. Hips
 *          Left
 *          Right
 *      14. Legs
 *          Left
 *          Right
 *      15. Feet
 *          Left
 *          Right
 *      
 *      
 * 
 * 
 * ---------Cursed Medalions----------
 * 
 *      int 0<R>10 Power Ranking In World
 *          R1=Mostly For Show
 *          R2=Annoyance in battle
 *          R3=Light Damage
 *          R4=Average Damage
 *          R5=Flexable Average Damage
 *          R6=Strong
 *          R7=Threat
 *          R8=Powerful
 *          R9=Nigh Unstoppable
 *          R10=Godly
 *      Medalion Identifiers
 *          Shape
 *          Design
 *          Detail
 * 
 *~~~~~~~~~~Types~~~~~~~~~~~~~~
 *      1. Projection (Ability to Project or Manipulate an Element)
 *          Air          R4 ****
 *          Cosmic       R10**********
 *          Dark         R9 *********
 *          Earth        R5 *****
 *          Electricity  R5 *****
 *          Explosion    R6 ******
 *          Fire         R5 *****
 *          Hair         R2 **
 *          Ice          R4 ****  
 *          Ink          R1 *
 *          Light        R9 *********
 *          Magma        R8 ********
 *          Rope         R2 **
 *          Sand         R5 *****
 *          Snow         R3 ***
 *          Storm        R6 ******
 *          Swamp        R2 **
 *          Tremor       R8 ********
 *          Water        R5 *****
 *          Nature       R4 ****
 *      2. Summon (Ability to Summon Swarms of Creatures)
 *          Bugs         R3 ***
 *          Birds        R3 ***
 *          Zombies      R5 *****
 *      3. Modify (Ability to Modify Self or Others)
 *          Diamond      R8 ********
 *          Metal        R4 ****
 *          Multi-arms   R4 ****
 *          Multiply     R4 ****
 *          Rock         R2 **
 *          Rubber       R3 ***
 *          Speed        R4 ****
 *          Time         R8 ********
 *          Weight       R2 **
 *          Wood         R1 *
 *      4. Animals (Ability to Transform Into Animal)
 *          Bird         R4 ****
 *          Dragon       R8 ********
 *          Elephant     R6 ******
 *          Tiger        R6 ******
 *          Turtle       R3 ***
 *          Wolf         R4 ****
 *   
 *   -----------RESOURCES------------------
 *      
 *      1. Metal
 *      2. Wood
 *      3. Hide       
 * */