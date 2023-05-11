USE [master]
GO
/****** Object:  Database [GuessThatPokemon]    Script Date: 5/7/2023 8:57:24 PM ******/
CREATE DATABASE [GuessThatPokemon]
 
GO
ALTER DATABASE [GuessThatPokemon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GuessThatPokemon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GuessThatPokemon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET ARITHABORT OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GuessThatPokemon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GuessThatPokemon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GuessThatPokemon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GuessThatPokemon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GuessThatPokemon] SET  MULTI_USER 
GO
ALTER DATABASE [GuessThatPokemon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GuessThatPokemon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GuessThatPokemon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GuessThatPokemon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GuessThatPokemon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GuessThatPokemon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GuessThatPokemon] SET QUERY_STORE = OFF
GO
USE [GuessThatPokemon]
GO
/****** Object:  Table [dbo].[Abilities]    Script Date: 5/7/2023 8:57:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abilities](
	[id_abi] [int] IDENTITY(1,1) NOT NULL,
	[abi_name] [nchar](50) NOT NULL,
	[abi_effect] [nchar](250) NOT NULL,
 CONSTRAINT [PK_Abilities] PRIMARY KEY CLUSTERED 
(
	[id_abi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encounters]    Script Date: 5/7/2023 8:57:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encounters](
	[id] [uniqueidentifier] NOT NULL,
	[dex_num] [int] NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[type_1] [nvarchar](25) NOT NULL,
	[type_2] [nvarchar](25) NULL,
	[ability] [nvarchar](25) NOT NULL,
	[ability_desc] [nvarchar](150) NOT NULL,
	[location] [nvarchar](50) NOT NULL,
	[sprite_path] [nvarchar](150) NOT NULL,
	[caught] [bit] NOT NULL,
 CONSTRAINT [PK_Encounters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 5/7/2023 8:57:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[id] [uniqueidentifier] NOT NULL,
	[player_id] [uniqueidentifier] NOT NULL,
	[pokemon_encounter_id] [uniqueidentifier] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[completed] [bit] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 5/7/2023 8:57:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[id_location] [int] IDENTITY(1,1) NOT NULL,
	[location_name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[id_location] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogLevel] [nvarchar](10) NOT NULL,
	[LogMessage] [nvarchar](max) NOT NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pokemon]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pokemon](
	[dex_number] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[type_1_id] [int] NOT NULL,
	[type_2_id] [int] NULL,
	[ability_id] [int] NOT NULL,
	[sprites_id] [int] NOT NULL,
 CONSTRAINT [PK_Pokemon] PRIMARY KEY CLUSTERED 
(
	[dex_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pokemon_Locations]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pokemon_Locations](
	[id_pkmn_spawn] [int] IDENTITY(1,1) NOT NULL,
	[pokemon_id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
 CONSTRAINT [PK_Pokemon_Locations] PRIMARY KEY CLUSTERED 
(
	[id_pkmn_spawn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sprites]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprites](
	[id_sprite] [int] IDENTITY(1,1) NOT NULL,
	[sprite_path] [nvarchar](50) NOT NULL,
	[shape_path] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sprites] PRIMARY KEY CLUSTERED 
(
	[id_sprite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[id_type] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[id_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersTable]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersTable](
	[id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[salt] [nvarchar](max) NOT NULL,
	[signup_time] [datetime] NOT NULL,
 CONSTRAINT [PK_UsersTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Abilities] ON 

INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (1, N'Overgrow                                          ', N'Powers up Grass-type moves in a pinch.                                                                                                                                                                                                                    ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (2, N'Blaze                                             ', N'Powers up Fire-type moves in a pinch.                                                                                                                                                                                                                     ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (3, N'Torrent                                           ', N'Powers up Water-type moves in a pinch.                                                                                                                                                                                                                    ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (4, N'Shield Dust                                       ', N'Blocks the added effects of attacks taken.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (5, N'Shed Skin                                         ', N'The Pokémon may heal its own status problems.                                                                                                                                                                                                             ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (6, N'Compound Eyes                                     ', N'The Pokémon''s accuracy is boosted.                                                                                                                                                                                                                        ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (7, N'Swarm                                             ', N'Powers up Bug-type moves in a pinch.                                                                                                                                                                                                                      ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (8, N'Keen Eye                                          ', N'Prevents other Pokémon from lowering accuracy.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (9, N'Run Away                                          ', N'Enables a sure getaway from wild Pokémon.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (10, N'Tangled Feet                                      ', N'Raises evasion if the Pokémon is confused.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (11, N'Guts                                              ', N'Boosts Attack if there is a status problem.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (12, N'Intimidate                                        ', N'Lowers the foe''s Attack stat.                                                                                                                                                                                                                             ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (13, N'Big Pecks                                         ', N'Protects the Pokémon from Defense-lowering attacks.                                                                                                                                                                                                       ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (14, N'Static                                            ', N'Contact with the Pokémon may cause paralysis.                                                                                                                                                                                                             ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (15, N'Sand Veil                                         ', N'Boosts the Pokémon''s evasion in a sandstorm.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (16, N'Poison Point                                      ', N'Contact with the Pokémon may poison the attacker.                                                                                                                                                                                                         ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (17, N'Rivalry                                           ', N'Deals more damage to a Pokémon of same gender.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (18, N'Cute Charm                                        ', N'Contact with the Pokémon may cause infatuation.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (19, N'Magic Guard                                       ', N'Protects the Pokémon from indirect damage.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (20, N'Flash Fire                                        ', N'It powers up Fire-type moves if it''s hit by one.                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (21, N'Inner Focus                                       ', N'The Pokémon is protected from flinching.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (22, N'Chlorophyll                                       ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                                                                                                                                   ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (23, N'Unnerve                                           ', N'Makes the foe nervous and unable to eat Berries.                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (24, N'Sand Rush                                         ', N'Boosts the Pokémon''s Speed in a sandstorm.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (25, N'Sheer Force                                       ', N'Removes added effects to increase move damage.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (26, N'Effect Spore                                      ', N'Contact may poison or cause paralysis or sleep.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (27, N'Dry Skin                                          ', N'Reduces HP if it is hot. Water restores HP.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (28, N'Lightning Rod                                     ', N'Draws in all Electric-type moves to up Sp. Attack.                                                                                                                                                                                                        ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (29, N'Sniper                                            ', N'Powers up moves if they become critical hits.                                                                                                                                                                                                             ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (30, N'Hustle                                            ', N'Boosts the Attack stat, but lowers accuracy.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (31, N'Unaware                                           ', N'Ignores any stat changes in the Pokémon.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (32, N'Drought                                           ', N'Turns the sunlight harsh when the Pokémon enters a battle.                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (33, N'Friend Guard                                      ', N'Friend Guard                                                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (34, N'Frisk                                             ', N'The Pokémon can check a foe''s held item.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (35, N'Pickup                                            ', N'The Pokémon may pick up items.                                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (36, N'Limber                                            ', N'The Pokémon is protected from paralysis.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (37, N'Damp                                              ', N'Prevents the use of self-destructing moves.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (38, N'Infiltrator                                       ', N'Passes through the foe''s barrier and strikes.                                                                                                                                                                                                             ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (39, N'Vital Spirit                                      ', N'Prevents the Pokémon from falling asleep.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (40, N'Tinted Lens                                       ', N'Powers up “not very effective” moves.                                                                                                                                                                                                                     ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (41, N'Arena Trap                                        ', N'Prevents the foe from fleeing.                                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (42, N'Technician                                        ', N'Powers up the Pokémon''s weaker moves.                                                                                                                                                                                                                     ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (43, N'Water Absorb                                      ', N'Restores HP if hit by a Water-type move.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (44, N'Cloud Nine                                        ', N'Eliminates the effects of weather.                                                                                                                                                                                                                        ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (45, N'Anger Point                                       ', N'Maxes Attack after taking a critical hit.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (46, N'Synchronize                                       ', N'Passes a burn, poison, or paralysis to the foe.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (47, N'Clear Body                                        ', N'Prevents other Pokémon from lowering its stats.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (48, N'Rock Head                                         ', N'Protects the Pokémon from recoil damage.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (49, N'Wonder Skin                                       ', N'Makes status-changing moves more likely to miss.                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (50, N'No Guard                                          ', N'Ensures attacks by or against the Pokémon land.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (51, N'Oblivious                                         ', N'Prevents it from becoming infatuated.                                                                                                                                                                                                                     ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (52, N'Sand Force                                        ', N'Boosts certain moves'' power in a sandstorm.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (53, N'Magnet Pull                                       ', N'Prevents Steel-type Pokémon from escaping.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (54, N'Liquid Ooze                                       ', N'Damages attackers using any draining move.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (55, N'Sturdy                                            ', N'It cannot be knocked out with one hit.                                                                                                                                                                                                                    ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (56, N'Defiant                                           ', N'Sharply raises Attack when the Pokémon''s stats are lowered.                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (57, N'Justified                                         ', N'Raises Attack when hit by a Dark-type move.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (58, N'Thick Fat                                         ', N'Ups resistance to Fire- and Ice-type moves.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (59, N'Steadfast                                         ', N'Raises Speed each time the Pokémon flinches.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (60, N'Stench                                            ', N'The stench may cause the target to flinch.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (61, N'Gluttony                                          ', N'Encourages the early use of a held Berry.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (62, N'Shell Armor                                       ', N'The Pokémon is protected against critical hits.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (63, N'Hydration                                         ', N'Heals status problems if it is raining.                                                                                                                                                                                                                   ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (64, N'Levitate                                          ', N'Gives immunity to Ground type moves.                                                                                                                                                                                                                      ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (65, N'Sticky Hold                                       ', N'Protects the Pokémon from item theft.                                                                                                                                                                                                                     ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (66, N'Skill Link                                        ', N'Increases the frequency of multi-strike moves.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (67, N'Forewarn                                          ', N'Determines what moves a foe has.                                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (68, N'Regenerator                                       ', N'Restores a little HP when withdrawn from battle.                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (69, N'Insomnia                                          ', N'Prevents the Pokémon from falling asleep.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (70, N'Hyper Cutter                                      ', N'Prevents other Pokémon from lowering Attack stat.                                                                                                                                                                                                         ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (71, N'Analytic                                          ', N'Boosts move power when the Pokémon moves last.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (72, N'Soundproof                                        ', N'Gives immunity to sound-based moves.                                                                                                                                                                                                                      ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (73, N'Own Tempo                                         ', N'Prevents the Pokémon from becoming confused.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (74, N'Natural Cure                                      ', N'All status problems heal when it switches out.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (75, N'Early Bird                                        ', N'The Pokémon awakens quickly from sleep.                                                                                                                                                                                                                   ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (76, N'Swift Swim                                        ', N'Boosts the Pokémon''s Speed in rain.                                                                                                                                                                                                                       ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (77, N'Ice Body                                          ', N'The Pokémon gradually regains HP in a hailstorm.                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (78, N'Illuminate                                        ', N'Raises the likelihood of meeting wild Pokémon.                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (79, N'Poison Touch                                      ', N'May poison targets when a Pokémon makes contact.                                                                                                                                                                                                          ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (80, N'Overcoat                                          ', N'Protects the Pokémon from weather damage.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (81, N'Reckless                                          ', N'Powers up moves that have recoil damage.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (82, N'Iron Fist                                         ', N'Boosts the power of punching moves.                                                                                                                                                                                                                       ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (83, N'Weak Armor                                        ', N'Physical attacks lower Defense and raise Speed.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (84, N'Serene Grace                                      ', N'Boosts the likelihood of added effects appearing.                                                                                                                                                                                                         ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (85, N'Leaf Guard                                        ', N'Prevents problems with status in sunny weather.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (86, N'Scrappy                                           ', N'Enables moves to hit Ghost-type Pokémon.                                                                                                                                                                                                                  ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (87, N'Flame Body                                        ', N'Contact with the Pokémon may burn the attacker.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (88, N'Mold Breaker                                      ', N'Moves can be used regardless of Abilities.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (89, N'Harvest                                           ', N'May create another Berry after one is used.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (90, N'Unburden                                          ', N'Raises Speed if a held item is used.                                                                                                                                                                                                                      ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (91, N'Water Veil                                        ', N'Prevents the Pokémon from getting a burn.                                                                                                                                                                                                                 ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (92, N'Filter                                            ', N'Reduces damage from super-effective attacks.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (93, N'Volt Absorb                                       ', N'Restores HP if hit by an Electric-type move.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (94, N'Healer                                            ', N'May heal an ally''s status conditions.                                                                                                                                                                                                                     ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (95, N'Trace                                             ', N'The Pokémon copies a foe''s Ability.                                                                                                                                                                                                                       ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (96, N'Adaptability                                      ', N'Powers up moves of the same type.                                                                                                                                                                                                                         ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (97, N'Download                                          ', N'Adjusts power according to a foe''s defenses.                                                                                                                                                                                                              ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (98, N'Battle Armor                                      ', N'The Pokémon is protected against critical hits.                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (99, N'Moxie                                             ', N'Boosts Attack after knocking out any Pokémon.                                                                                                                                                                                                             ')
GO
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (100, N'Rattled                                           ', N'Bug, Ghost or Dark type moves scare it and boost its Speed.                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (101, N'Immunity                                          ', N'Prevents the Pokémon from getting poisoned.                                                                                                                                                                                                               ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (102, N'Pressure                                          ', N'The Pokémon raises the foe''s PP usage.                                                                                                                                                                                                                    ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (103, N'Snow Cloak                                        ', N'Raises evasion in a hailstorm.                                                                                                                                                                                                                            ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (104, N'Quick Feet                                        ', N'Boosts Speed if there is a status problem.                                                                                                                                                                                                                ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (105, N'Anticipation                                      ', N'Senses a foe''s dangerous moves.                                                                                                                                                                                                                           ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (106, N'Imposter                                          ', N'It transforms itself into the Pokémon it is facing.                                                                                                                                                                                                       ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (107, N'Solar Power                                       ', N'In sunshine, Sp. Atk is boosted but HP decreases.                                                                                                                                                                                                         ')
INSERT [dbo].[Abilities] ([id_abi], [abi_name], [abi_effect]) VALUES (108, N'Rain Dish                                         ', N'The Pokémon gradually regains HP in rain.                                                                                                                                                                                                                 ')
SET IDENTITY_INSERT [dbo].[Abilities] OFF
GO
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'bd6d8509-b538-4ac8-a68c-00784d822b3e', 56, N'Mankey', N'Fighting            ', N'', N'Vital Spirit             ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Route 7                                           ', N'./css/sprites/56.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'f57633ad-94f4-41a4-a3fd-0170512c543e', 117, N'Seadra', N'Water               ', N'', N'Poison Point             ', N'Contact with the Pokémon may poison the attacker.                                                                                                     ', N'Seafoam Islands                                   ', N'./css/sprites/117.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'69ab06fd-f10d-4f16-8f9e-02471b108d44', 71, N'Victreebel', N'Grass               ', N'Poison              ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Evolution', N'./css/sprites/71.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'4b92ffcf-5682-4d48-b8e0-031230439ada', 1, N'Bulbasaur', N'Grass               ', N'Poison              ', N'Overgrow                 ', N'Powers up Grass-type moves in a pinch.                                                                                                                ', N'Pallet Town                                       ', N'./css/sprites/1.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'1680c904-2d13-4d04-8b56-03a747200b4c', 66, N'Machop', N'Fighting            ', N'', N'Guts                     ', N'Boosts Attack if there is a status problem.                                                                                                           ', N'Rock Tunnel                                       ', N'./css/sprites/66.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'6daf8bb9-eb94-4d92-a319-060eeb940837', 54, N'Psyduck', N'Water               ', N'', N'Damp                     ', N'Prevents the use of self-destructing moves.                                                                                                           ', N'Route 24                                          ', N'./css/sprites/54.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'a0fd0380-0e87-4647-94ec-08b003baadc6', 5, N'Charmeleon', N'Fire                ', N'', N'Blaze                    ', N'Powers up Fire-type moves in a pinch.                                                                                                                 ', N'Evolution', N'./css/sprites/5.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'451a25ac-42b7-4742-b317-0a6494e862ad', 64, N'Kadabra', N'Psychic             ', N'', N'Synchronize              ', N'Passes a burn, poison, or paralysis to the foe.                                                                                                       ', N'Cerulean Cave                                     ', N'./css/sprites/64.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'fb25c93b-7ab5-4eca-b588-0ad73e937ff2', 79, N'Slowpoke', N'Water               ', N'Psychic             ', N'Oblivious                ', N'Prevents it from becoming infatuated.                                                                                                                 ', N'Kanto Safari Zone                                 ', N'./css/sprites/79.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'139063ff-4ee2-4e40-9616-0fa62dc28245', 12, N'Butterfree', N'Bug                 ', N'Flying              ', N'Compound Eyes            ', N'The Pokémon''s accuracy is boosted.                                                                                                                    ', N'Evolution', N'./css/sprites/12.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3fbf43b6-5848-46f6-bc01-10af1ef44464', 49, N'Venomoth', N'Bug                 ', N'Poison              ', N'Shield Dust              ', N'Blocks the added effects of attacks taken.                                                                                                            ', N'Cerulean Cave                                     ', N'./css/sprites/49.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'514c5c67-e490-41e7-85b6-119ac53994dd', 95, N'Onix', N'Rock                ', N'Ground              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Victory Road (Kanto)                              ', N'./css/sprites/95.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9a8bc280-0347-4b0b-a378-178ec85b811b', 64, N'Kadabra', N'Psychic             ', N'', N'Synchronize              ', N'Passes a burn, poison, or paralysis to the foe.                                                                                                       ', N'Cerulean Cave                                     ', N'./css/sprites/64.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'99d14234-cbc2-4712-8ee9-1d0cd8b634f7', 43, N'Oddish', N'Grass               ', N'Poison              ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Route 12                                          ', N'./css/sprites/43.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b5946a4a-1998-4255-b460-207c9d050392', 142, N'Aerodactyl', N'Rock                ', N'Flying              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Cinnabar Island                                   ', N'./css/sprites/142.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'1238ee56-1a15-4f2d-97b8-22df05d960cc', 51, N'Dugtrio', N'Ground              ', N'', N'Sand Veil                ', N'Boosts the Pokémon''s evasion in a sandstorm.                                                                                                          ', N'Diglett''s Cave                                    ', N'./css/sprites/51.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'e3cc3ca6-e71f-42ec-8cde-248dcb81e11b', 33, N'Nidorino', N'Poison              ', N'', N'Poison Point             ', N'Contact with the Pokémon may poison the attacker.                                                                                                     ', N'Kanto Safari Zone                                 ', N'./css/sprites/33.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'2159b411-292a-4620-adb8-29f62bde38ed', 98, N'Krabby', N'Water               ', N'', N'Hyper Cutter             ', N'Prevents other Pokémon from lowering Attack stat.                                                                                                     ', N'Route 24                                          ', N'./css/sprites/98.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'd3c57355-eee8-4614-a304-29f89f0f4a3e', 134, N'Vaporeon', N'Water               ', N'', N'Water Absorb             ', N'Restores HP if hit by a Water-type move.                                                                                                              ', N'Evolution', N'./css/sprites/134.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'34ff1105-b617-48ae-a44a-2b70fa6cdf67', 22, N'Fearow', N'Normal              ', N'Flying              ', N'Keen Eye                 ', N'Prevents other Pokémon from lowering accuracy.                                                                                                        ', N'Route 23                                          ', N'./css/sprites/22.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3c4b7e3b-2f42-4af0-98ef-2bd30895fd93', 142, N'Aerodactyl', N'Rock                ', N'Flying              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Cinnabar Island                                   ', N'./css/sprites/142.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'bbcd2491-41aa-4ac0-8c99-2c1ebc0a1d19', 59, N'Arcanine', N'Fire                ', N'', N'Intimidate               ', N'Lowers the foe''s Attack stat.                                                                                                                         ', N'Evolution', N'./css/sprites/59.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'7169d42a-56ee-4277-bd20-2e59a4fe6978', 102, N'Exeggcute', N'Grass               ', N'Psychic             ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Kanto Safari Zone                                 ', N'./css/sprites/102.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'59401ad8-7675-48df-9b48-2ffcf6671275', 101, N'Electrode', N'Electric            ', N'', N'Soundproof               ', N'Gives immunity to sound-based moves.                                                                                                                  ', N'Cinnabar Island                                   ', N'./css/sprites/101.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b2ead802-e9c3-4c79-9234-30e83b271ed6', 57, N'Primeape', N'Fighting            ', N'', N'Vital Spirit             ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Evolution', N'./css/sprites/57.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'f0fefc9c-e68b-426e-a160-3166d8c41020', 95, N'Onix', N'Rock                ', N'Ground              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Victory Road (Kanto)                              ', N'./css/sprites/95.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'36074fa0-9618-46de-a604-325ef9541fb3', 99, N'Kingler', N'Water               ', N'', N'Hyper Cutter             ', N'Prevents other Pokémon from lowering Attack stat.                                                                                                     ', N'Route 23                                          ', N'./css/sprites/99.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'05a4078f-1f26-4fea-a268-394ef56f3aaf', 63, N'Abra', N'Psychic             ', N'', N'Synchronize              ', N'Passes a burn, poison, or paralysis to the foe.                                                                                                       ', N'Route 24                                          ', N'./css/sprites/63.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9dd82c1f-ff52-4505-b9c3-3ea792d43ffd', 5, N'Charmeleon', N'Fire                ', N'', N'Blaze                    ', N'Powers up Fire-type moves in a pinch.                                                                                                                 ', N'Evolution', N'./css/sprites/5.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'ca78b4d2-5bbd-45a0-931e-3ec3ace4fc88', 81, N'Magnemite', N'Electric            ', N'Steel               ', N'Magnet Pull              ', N'Prevents Steel-type Pokémon from escaping.                                                                                                            ', N'Kanto Power Plant                                 ', N'./css/sprites/81.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3f86e58d-fe71-4910-bcd4-4401cde53d93', 45, N'Vileplume', N'Grass               ', N'Poison              ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Evolution', N'./css/sprites/45.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9d5a830e-dfd3-4bc4-b0ce-47b8f9b359ad', 118, N'Goldeen', N'Water               ', N'', N'Swift Swim               ', N'Boosts the Pokémon''s Speed in rain.                                                                                                                   ', N'Cinnabar Island                                   ', N'./css/sprites/118.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'f6ebcb8e-a4b1-4b12-a066-491975fb4ea7', 97, N'Hypno', N'Psychic             ', N'', N'Insomnia                 ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Cerulean Cave                                     ', N'./css/sprites/97.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b8d429d1-4add-4a89-8825-49c1e98a6de1', 47, N'Parasect', N'Bug                 ', N'Grass               ', N'Effect Spore             ', N'Contact may poison or cause paralysis or sleep.                                                                                                       ', N'Cerulean Cave                                     ', N'./css/sprites/47.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'237181dc-2c75-482c-b428-4a229f7c0ba8', 1, N'Bulbasaur', N'Grass               ', N'Poison              ', N'Overgrow                 ', N'Powers up Grass-type moves in a pinch.                                                                                                                ', N'Pallet Town                                       ', N'./css/sprites/1.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'2831e3a5-34da-4a51-8fdd-4a5ad7896baa', 122, N'Mr. Mime', N'Psychic             ', N'', N'Soundproof               ', N'Gives immunity to sound-based moves.                                                                                                                  ', N'Route 2                                           ', N'./css/sprites/122.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'73722746-b194-47fa-8433-4bbaf79493c5', 102, N'Exeggcute', N'Grass               ', N'Psychic             ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Kanto Safari Zone                                 ', N'./css/sprites/102.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'6c4f8db5-0f55-4361-adde-4f5e02bbe78f', 129, N'Magikarp', N'Water               ', N'', N'Swift Swim               ', N'Boosts the Pokémon''s Speed in rain.                                                                                                                   ', N'Route 6                                           ', N'./css/sprites/129.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'5c740d18-c5a5-4d09-800e-5720b40e2496', 120, N'Staryu', N'Water               ', N'', N'Illuminate               ', N'Raises the likelihood of meeting wild Pokémon.                                                                                                        ', N'Cinnabar Island                                   ', N'./css/sprites/120.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'2c7d823e-dd6f-47ad-8019-572be245272c', 12, N'Butterfree', N'Bug                 ', N'Flying              ', N'Compound Eyes            ', N'The Pokémon''s accuracy is boosted.                                                                                                                    ', N'Evolution', N'./css/sprites/12.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'dd34e8e4-9691-4edb-b2ab-58a7e1ad150e', 123, N'Scyther', N'Bug                 ', N'Flying              ', N'Swarm                    ', N'Powers up Bug-type moves in a pinch.                                                                                                                  ', N'Kanto Safari Zone                                 ', N'./css/sprites/123.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'a11facab-20d2-471d-bcd9-5f1caeea29d0', 1, N'Bulbasaur', N'Grass               ', N'Poison              ', N'Overgrow                 ', N'Powers up Grass-type moves in a pinch.                                                                                                                ', N'Pallet Town                                       ', N'./css/sprites/1.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'd41c8f91-eea3-4f1a-a1db-625a7be17ea1', 54, N'Psyduck', N'Water               ', N'', N'Damp                     ', N'Prevents the use of self-destructing moves.                                                                                                           ', N'Kanto Safari Zone                                 ', N'./css/sprites/54.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'2fc2345e-39b9-4368-9747-62e3c54db7ee', 95, N'Onix', N'Rock                ', N'Ground              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Victory Road (Kanto)                              ', N'./css/sprites/95.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'a10b7eb5-41a0-4102-ab36-636fd2966cb8', 136, N'Flareon', N'Fire                ', N'', N'Flash Fire               ', N'It powers up Fire-type moves if it''s hit by one.                                                                                                      ', N'Evolution', N'./css/sprites/136.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b75441ea-04ae-4a11-b475-66c817a2548d', 49, N'Venomoth', N'Bug                 ', N'Poison              ', N'Shield Dust              ', N'Blocks the added effects of attacks taken.                                                                                                            ', N'Kanto Safari Zone                                 ', N'./css/sprites/49.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'bff5378c-a971-40d8-9816-67d3d2b0d3b9', 67, N'Machoke', N'Fighting            ', N'', N'Guts                     ', N'Boosts Attack if there is a status problem.                                                                                                           ', N'Victory Road (Kanto)                              ', N'./css/sprites/67.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9eb47bcc-a3d8-49be-aa74-68d642af67c0', 1, N'Bulbasaur', N'Grass               ', N'Poison              ', N'Overgrow                 ', N'Powers up Grass-type moves in a pinch.                                                                                                                ', N'Pallet Town                                       ', N'./css/sprites/1.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'58f8942c-380f-49cc-a906-69f0b63f029f', 116, N'Horsea', N'Water               ', N'', N'Swift Swim               ', N'Boosts the Pokémon''s Speed in rain.                                                                                                                   ', N'Route 20                                          ', N'./css/sprites/116.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3d9ae28b-cf37-40c5-82bc-6b2e192ac8f5', 73, N'Tentacruel', N'Water               ', N'Poison              ', N'Clear Body               ', N'Prevents other Pokémon from lowering its stats.                                                                                                       ', N'Evolution', N'./css/sprites/73.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'236b9507-b607-491f-b810-6b7e9f2f9812', 113, N'Chansey', N'Normal              ', N'', N'Natural Cure             ', N'All status problems heal when it switches out.                                                                                                        ', N'Kanto Safari Zone                                 ', N'./css/sprites/113.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'402c395c-99e8-410b-b7ed-6cb19c51fe0b', 77, N'Ponyta', N'Fire                ', N'', N'Run Away                 ', N'Enables a sure getaway from wild Pokémon.                                                                                                             ', N'Pokémon Mansion (Kanto)                           ', N'./css/sprites/77.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'466df0cf-73ee-4c9f-a00e-6cc50d667edb', 59, N'Arcanine', N'Fire                ', N'', N'Intimidate               ', N'Lowers the foe''s Attack stat.                                                                                                                         ', N'Evolution', N'./css/sprites/59.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'11b69c78-72c0-43e4-8843-6fa638523fe9', 104, N'Cubone', N'Ground              ', N'', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Pokémon Tower                                     ', N'./css/sprites/104.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'bba060ab-f959-443d-a7b4-70e144639b5c', 77, N'Ponyta', N'Fire                ', N'', N'Run Away                 ', N'Enables a sure getaway from wild Pokémon.                                                                                                             ', N'Pokémon Mansion (Kanto)                           ', N'./css/sprites/77.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'1277df2f-29f7-4cfb-a2d4-71040aa5543b', 15, N'Beedrill', N'Bug                 ', N'Poison              ', N'Swarm                    ', N'Powers up Bug-type moves in a pinch.                                                                                                                  ', N'Evolution', N'./css/sprites/15.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'ab6141c1-7c0d-4a4c-86b3-73ef989a3406', 23, N'Ekans', N'Poison              ', N'', N'Intimidate               ', N'Lowers the foe''s Attack stat.                                                                                                                         ', N'Route 8                                           ', N'./css/sprites/23.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b950068b-5a78-458d-ada0-74516ec4cef5', 43, N'Oddish', N'Grass               ', N'Poison              ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Route 14                                          ', N'./css/sprites/43.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'f1261858-c4db-44e7-b6fd-7922fde63f16', 39, N'Jigglypuff', N'Normal              ', N'', N'Cute Charm               ', N'Contact with the Pokémon may cause infatuation.                                                                                                       ', N'Route 3                                           ', N'./css/sprites/39.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'a52f8552-3b68-4bc8-b101-7948cb87dc1c', 41, N'Zubat', N'Poison              ', N'Flying              ', N'Inner Focus              ', N'The Pokémon is protected from flinching.                                                                                                              ', N'Rock Tunnel                                       ', N'./css/sprites/41.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'd8b57e8d-1195-44ca-ba6e-79f25c4d554d', 75, N'Graveler', N'Rock                ', N'Ground              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Victory Road (Kanto)                              ', N'./css/sprites/75.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'1bdc98f4-f0a2-4df7-9098-7c88bf0788d7', 125, N'Electabuzz', N'Electric            ', N'', N'Static                   ', N'Contact with the Pokémon may cause paralysis.                                                                                                         ', N'Kanto Power Plant                                 ', N'./css/sprites/125.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'848a4755-2e33-4e2b-89e7-7d1e4b23b499', 26, N'Raichu', N'Electric            ', N'', N'Static                   ', N'Contact with the Pokémon may cause paralysis.                                                                                                         ', N'Cerulean Cave                                     ', N'./css/sprites/26.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'ee4cedc9-4b17-4b1a-b7e4-8be680cdf5fa', 33, N'Nidorino', N'Poison              ', N'', N'Poison Point             ', N'Contact with the Pokémon may poison the attacker.                                                                                                     ', N'Kanto Safari Zone                                 ', N'./css/sprites/33.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'26d546f8-b636-42a5-a8f0-8f6daef76388', 114, N'Tangela', N'Grass               ', N'', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Cinnabar Island                                   ', N'./css/sprites/114.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'82b25f18-36f0-437a-8199-91f42a05e4b1', 97, N'Hypno', N'Psychic             ', N'', N'Insomnia                 ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Cerulean Cave                                     ', N'./css/sprites/97.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'c85f4904-d9df-4286-b030-9c4b7680ca4e', 112, N'Rhydon', N'Ground              ', N'Rock                ', N'Lightning Rod            ', N'Draws in all Electric-type moves to up Sp. Attack.                                                                                                    ', N'Cerulean Cave                                     ', N'./css/sprites/112.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'ae5acc7c-9e5d-47da-aeaa-a6191667e2e6', 16, N'Pidgey', N'Normal              ', N'Flying              ', N'Keen Eye                 ', N'Prevents other Pokémon from lowering accuracy.                                                                                                        ', N'Route 12                                          ', N'./css/sprites/16.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'463f2790-c999-4de4-9ffa-a9071acc41c2', 131, N'Lapras', N'Water               ', N'Ice                 ', N'Water Absorb             ', N'Restores HP if hit by a Water-type move.                                                                                                              ', N'Silph Co.                                         ', N'./css/sprites/131.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'91197d14-4899-4511-90e1-a93fbb87a49a', 90, N'Shellder', N'Water               ', N'', N'Shell Armor              ', N'The Pokémon is protected against critical hits.                                                                                                       ', N'Route 19                                          ', N'./css/sprites/90.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3e8071b4-844a-4c51-9e7c-aa0a9eeb9cff', 123, N'Scyther', N'Bug                 ', N'Flying              ', N'Swarm                    ', N'Powers up Bug-type moves in a pinch.                                                                                                                  ', N'Kanto Safari Zone                                 ', N'./css/sprites/123.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'ca9e11c8-442d-4392-bb4a-b0a2e2779cef', 55, N'Golduck', N'Water               ', N'', N'Damp                     ', N'Prevents the use of self-destructing moves.                                                                                                           ', N'Seafoam Islands                                   ', N'./css/sprites/55.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9e12ccc9-70d9-4a9b-84bc-b73a59176b3a', 48, N'Venonat', N'Bug                 ', N'Poison              ', N'Compound Eyes            ', N'The Pokémon''s accuracy is boosted.                                                                                                                    ', N'Route 12                                          ', N'./css/sprites/48.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'731f6796-0b8b-430b-93b5-ba2d07cf29dd', 74, N'Geodude', N'Rock                ', N'Ground              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Victory Road (Kanto)                              ', N'./css/sprites/74.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'01e1b171-d7d7-4bf3-9b5e-bad48d57c896', 29, N'Nidoran♀', N'Poison              ', N'', N'Poison Point             ', N'Contact with the Pokémon may poison the attacker.                                                                                                     ', N'Route 22                                          ', N'./css/sprites/29.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'd7b19752-a833-4553-8c77-be8866ddc6f1', 76, N'Golem', N'Rock                ', N'Ground              ', N'Rock Head                ', N'Protects the Pokémon from recoil damage.                                                                                                              ', N'Evolution', N'./css/sprites/76.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b547edaf-16ba-4cae-b554-c1620582fdd7', 148, N'Dragonair', N'Dragon              ', N'', N'Shed Skin                ', N'The Pokémon may heal its own status problems.                                                                                                         ', N'Evolution', N'./css/sprites/148.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'fa46ed22-ce3b-4c3c-a202-c3276f641cca', 69, N'Bellsprout', N'Grass               ', N'Poison              ', N'Chlorophyll              ', N'Boosts the Pokémon''s Speed in sunshine.                                                                                                               ', N'Route 12                                          ', N'./css/sprites/69.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'8886428f-b0c9-4bf9-9e56-c77ac4bcc80e', 1, N'Bulbasaur', N'Grass               ', N'Poison              ', N'Overgrow                 ', N'Powers up Grass-type moves in a pinch.                                                                                                                ', N'Pallet Town                                       ', N'./css/sprites/1.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'baaa576a-f2a8-4c2c-b94c-ca30746b47a5', 57, N'Primeape', N'Fighting            ', N'', N'Vital Spirit             ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Evolution', N'./css/sprites/57.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'7d74602b-0a8b-41df-8881-cb6507285381', 80, N'Slowbro', N'Water               ', N'Psychic             ', N'Oblivious                ', N'Prevents it from becoming infatuated.                                                                                                                 ', N'Seafoam Islands                                   ', N'./css/sprites/80.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3c8ec9ce-b9b6-4657-92ce-cd8e1fc4a632', 138, N'Omanyte', N'Rock                ', N'Water               ', N'Swift Swim               ', N'Boosts the Pokémon''s Speed in rain.                                                                                                                   ', N'Cinnabar Island                                   ', N'./css/sprites/138.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'cb50e61f-92ae-429a-930e-d0795cf7f1b3', 123, N'Scyther', N'Bug                 ', N'Flying              ', N'Swarm                    ', N'Powers up Bug-type moves in a pinch.                                                                                                                  ', N'Kanto Safari Zone                                 ', N'./css/sprites/123.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'6ec831d2-1a02-4af5-990a-d2425450a1a2', 26, N'Raichu', N'Electric            ', N'', N'Static                   ', N'Contact with the Pokémon may cause paralysis.                                                                                                         ', N'Kanto Power Plant                                 ', N'./css/sprites/26.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'2f7ebda6-38dd-4032-bfee-d4e2a7d80696', 127, N'Pinsir', N'Bug                 ', N'', N'Hyper Cutter             ', N'Prevents other Pokémon from lowering Attack stat.                                                                                                     ', N'Kanto Safari Zone                                 ', N'./css/sprites/127.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'1e97f8ba-ef7d-40ba-93d2-d7afcf0b4a03', 57, N'Primeape', N'Fighting            ', N'', N'Vital Spirit             ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Evolution', N'./css/sprites/57.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'dbe314ac-4c6c-450b-9076-d818b5327601', 120, N'Staryu', N'Water               ', N'', N'Illuminate               ', N'Raises the likelihood of meeting wild Pokémon.                                                                                                        ', N'Route 21                                          ', N'./css/sprites/120.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9ff376f4-467d-493b-9c41-dcf51092df9b', 77, N'Ponyta', N'Fire                ', N'', N'Run Away                 ', N'Enables a sure getaway from wild Pokémon.                                                                                                             ', N'Pokémon Mansion (Kanto)                           ', N'./css/sprites/77.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'ec400550-e141-40fe-a5fd-dd61af8579aa', 97, N'Hypno', N'Psychic             ', N'', N'Insomnia                 ', N'Prevents the Pokémon from falling asleep.                                                                                                             ', N'Cerulean Cave                                     ', N'./css/sprites/97.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'4eb2609b-9d56-40eb-8e7f-ddf2f11031ab', 146, N'Moltres', N'Fire                ', N'Flying              ', N'Pressure                 ', N'The Pokémon raises the foe''s PP usage.                                                                                                                ', N'Victory Road (Kanto)                              ', N'./css/sprites/146.png', 1)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'e9081add-38de-49ba-aa43-de09cffc406a', 31, N'Nidoqueen', N'Poison              ', N'Ground              ', N'Poison Point             ', N'Contact with the Pokémon may poison the attacker.                                                                                                     ', N'Evolution', N'./css/sprites/31.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'0d4a8a2a-971f-4056-b3d4-e04bf4575ac5', 131, N'Lapras', N'Water               ', N'Ice                 ', N'Water Absorb             ', N'Restores HP if hit by a Water-type move.                                                                                                              ', N'Silph Co.                                         ', N'./css/sprites/131.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'a049594c-abd9-4548-ba69-e12b64f5afc2', 30, N'Nidorina', N'Poison              ', N'', N'Poison Point             ', N'Contact with the Pokémon may poison the attacker.                                                                                                     ', N'Kanto Safari Zone                                 ', N'./css/sprites/30.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'5fc31522-5072-4b75-bb34-e2e323521694', 8, N'Wartortle', N'Water               ', N'', N'Torrent                  ', N'Powers up Water-type moves in a pinch.                                                                                                                ', N'Evolution', N'./css/sprites/8.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b5defd14-fa14-41bd-89e0-e8876c2446ea', 116, N'Horsea', N'Water               ', N'', N'Swift Swim               ', N'Boosts the Pokémon''s Speed in rain.                                                                                                                   ', N'Route 19                                          ', N'./css/sprites/116.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'04b14b63-ad9a-46ec-919e-eaed44d6cf41', 39, N'Jigglypuff', N'Normal              ', N'', N'Cute Charm               ', N'Contact with the Pokémon may cause infatuation.                                                                                                       ', N'Route 3                                           ', N'./css/sprites/39.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'5ef20f8e-2a1c-40cd-aa6e-edccbdcab282', 91, N'Cloyster', N'Water               ', N'Ice                 ', N'Shell Armor              ', N'The Pokémon is protected against critical hits.                                                                                                       ', N'Evolution', N'./css/sprites/91.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'bcd0fb83-7290-44c7-a4b0-ee337e516cb6', 94, N'Gengar', N'Ghost               ', N'Poison              ', N'Levitate                 ', N'Gives immunity to Ground type moves.                                                                                                                  ', N'Evolution', N'./css/sprites/94.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'd50293b2-9083-40e7-8959-ef6b4dc3d046', 122, N'Mr. Mime', N'Psychic             ', N'', N'Soundproof               ', N'Gives immunity to sound-based moves.                                                                                                                  ', N'Route 2                                           ', N'./css/sprites/122.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'3323099e-f0d1-43fd-8c49-f1e0acdafcfd', 107, N'Hitmonchan', N'Fighting            ', N'', N'Swarm                    ', N'Powers up Bug-type moves in a pinch.                                                                                                                  ', N'Saffron City                                      ', N'./css/sprites/107.png', 0)
GO
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'931ac2ce-a6b2-4ae1-badb-f6759b422e40', 18, N'Pidgeot', N'Normal              ', N'Flying              ', N'Keen Eye                 ', N'Prevents other Pokémon from lowering accuracy.                                                                                                        ', N'Evolution', N'./css/sprites/18.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'b656c4ab-d7ac-4129-b627-fa35bf0c7cff', 109, N'Koffing', N'Poison              ', N'', N'Levitate                 ', N'Gives immunity to Ground type moves.                                                                                                                  ', N'Pokémon Mansion (Kanto)                           ', N'./css/sprites/109.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'65041066-2eba-49a0-a9f0-fb312e93f9dc', 25, N'Pikachu', N'Electric            ', N'', N'Static                   ', N'Contact with the Pokémon may cause paralysis.                                                                                                         ', N'Kanto Power Plant                                 ', N'./css/sprites/25.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'c594e57f-197c-4e9e-bf78-fcf2ae66bfe3', 82, N'Magneton', N'Electric            ', N'Steel               ', N'Magnet Pull              ', N'Prevents Steel-type Pokémon from escaping.                                                                                                            ', N'Kanto Power Plant                                 ', N'./css/sprites/82.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9643206a-6a9a-4c33-9f51-fd7a607c64e5', 87, N'Dewgong', N'Water               ', N'Ice                 ', N'Thick Fat                ', N'Ups resistance to Fire- and Ice-type moves.                                                                                                           ', N'Seafoam Islands                                   ', N'./css/sprites/87.png', 0)
INSERT [dbo].[Encounters] ([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught]) VALUES (N'9281be96-6089-4904-a61d-ffbe2c808a08', 106, N'Hitmonlee', N'Fighting            ', N'', N'Limber                   ', N'The Pokémon is protected from paralysis.                                                                                                              ', N'Saffron City                                      ', N'./css/sprites/106.png', 1)
GO
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'e09108ea-2ff3-4d64-9701-01c95c9f8eb9', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'1bdc98f4-f0a2-4df7-9098-7c88bf0788d7', CAST(N'2023-05-06T16:21:04.967' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'99d549b3-1d72-4c64-8d29-038078717f24', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b2ead802-e9c3-4c79-9234-30e83b271ed6', CAST(N'2023-05-06T16:24:45.237' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'5d8ff98a-30ca-4678-935c-05b73a4bb9a7', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'f57633ad-94f4-41a4-a3fd-0170512c543e', CAST(N'2023-05-06T16:43:53.590' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f23438d1-5b2e-42ec-8a54-07ce6d33bdef', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'73722746-b194-47fa-8433-4bbaf79493c5', CAST(N'2023-05-06T17:01:04.763' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'4966e1f2-dc57-4a41-87c8-0c1ac0dbd30f', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9d5a830e-dfd3-4bc4-b0ce-47b8f9b359ad', CAST(N'2023-05-06T16:22:31.713' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'2edaf562-32d2-45ec-bc4f-0c976df672f5', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b547edaf-16ba-4cae-b554-c1620582fdd7', CAST(N'2023-05-06T16:35:35.147' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'e8b380b2-239b-4e2e-9897-10833512ae6a', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'82b25f18-36f0-437a-8199-91f42a05e4b1', CAST(N'2023-05-06T16:38:37.827' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'37a888b0-b8a4-4565-8f93-1274c295b477', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9ff376f4-467d-493b-9c41-dcf51092df9b', CAST(N'2023-05-06T16:22:51.170' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'264c2adb-9255-45f1-b137-1453bc244fb3', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'fb25c93b-7ab5-4eca-b588-0ad73e937ff2', CAST(N'2023-05-06T16:49:50.230' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'185252a7-2186-45e7-a086-19c968615adc', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9e12ccc9-70d9-4a9b-84bc-b73a59176b3a', CAST(N'2023-05-06T16:42:08.287' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'7d38a417-34fa-4b59-9ce8-1c6072a7911a', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'3d9ae28b-cf37-40c5-82bc-6b2e192ac8f5', CAST(N'2023-05-06T16:50:01.567' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'ee03b7c5-51a1-44bc-930c-1d00d2f3c1fb', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b5946a4a-1998-4255-b460-207c9d050392', CAST(N'2023-05-06T16:22:30.413' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'a60dd391-ab24-4f2a-8d72-1d564d231f20', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'bcd0fb83-7290-44c7-a4b0-ee337e516cb6', CAST(N'2023-05-06T16:44:00.923' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'133f7928-4e31-43ef-9d76-1e4051884efd', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9eb47bcc-a3d8-49be-aa74-68d642af67c0', CAST(N'2023-05-07T17:42:25.023' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'180f8dba-0124-494c-8a31-1edb240a426b', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'04b14b63-ad9a-46ec-919e-eaed44d6cf41', CAST(N'2023-05-06T16:34:41.210' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'26de4e78-9626-440f-b01d-2100da630a31', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'3323099e-f0d1-43fd-8c49-f1e0acdafcfd', CAST(N'2023-05-06T16:26:48.520' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f5c58adc-b1ec-4eac-b1c9-24000969b2f0', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'466df0cf-73ee-4c9f-a00e-6cc50d667edb', CAST(N'2023-05-06T16:49:53.463' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'68337eab-24d0-4e0b-b361-2ab69c628a14', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'dd34e8e4-9691-4edb-b2ab-58a7e1ad150e', CAST(N'2023-05-06T17:00:25.380' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'6e58ec4f-086e-4f9e-8424-408a8e741458', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9a8bc280-0347-4b0b-a378-178ec85b811b', CAST(N'2023-05-06T16:13:53.427' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'6b1f6d54-5928-4518-8c4c-423dd1e5ffe8', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'5ef20f8e-2a1c-40cd-aa6e-edccbdcab282', CAST(N'2023-05-06T16:40:18.570' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'cf609ec4-8edc-4250-9d87-4273a1c1d2be', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'c594e57f-197c-4e9e-bf78-fcf2ae66bfe3', CAST(N'2023-05-06T16:40:44.250' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'11c81ba4-1914-42b8-bb8d-451bb0e16225', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'451a25ac-42b7-4742-b317-0a6494e862ad', CAST(N'2023-05-06T16:17:26.980' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'c5a46f7f-0e99-4349-8ee8-45d5db4fb59c', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'2831e3a5-34da-4a51-8fdd-4a5ad7896baa', CAST(N'2023-05-06T13:47:11.373' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'ba004dd8-122c-4f3c-b85f-4936af84089b', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'34ff1105-b617-48ae-a44a-2b70fa6cdf67', CAST(N'2023-05-06T16:22:02.130' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'9d2d1672-e725-4c61-bf76-49fcb6b75496', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'731f6796-0b8b-430b-93b5-ba2d07cf29dd', CAST(N'2023-05-06T16:24:06.333' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'416ac94c-1bab-42d9-880a-529b583c9a20', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'26d546f8-b636-42a5-a8f0-8f6daef76388', CAST(N'2023-05-06T16:20:42.347' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'952fa25a-03d8-4eb7-9683-58327a1c35b2', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'99d14234-cbc2-4712-8ee9-1d0cd8b634f7', CAST(N'2023-05-06T15:06:42.000' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'e87a113c-353c-4846-9ca2-5899e910314b', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'ca78b4d2-5bbd-45a0-931e-3ec3ace4fc88', CAST(N'2023-05-06T16:35:40.477' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'125184ea-e4ed-4ee0-ad47-5a043d298387', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'fa46ed22-ce3b-4c3c-a202-c3276f641cca', CAST(N'2023-05-06T16:18:38.637' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'77276df2-f840-4d99-86c3-616a03b1ebe8', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'bd6d8509-b538-4ac8-a68c-00784d822b3e', CAST(N'2023-05-06T16:53:57.287' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'a7a2c63a-809e-44bf-8a51-6b0762ad06f0', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'a049594c-abd9-4548-ba69-e12b64f5afc2', CAST(N'2023-05-06T16:25:23.120' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'b03200c5-cda7-4482-a24f-6e93d01e11d1', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b656c4ab-d7ac-4129-b627-fa35bf0c7cff', CAST(N'2023-05-06T17:00:41.177' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'cfde7752-e2c9-4d6d-88c5-7055ba4fd289', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'6ec831d2-1a02-4af5-990a-d2425450a1a2', CAST(N'2023-05-06T16:56:21.650' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'19863594-2483-4f56-985e-70912a0a4309', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'6daf8bb9-eb94-4d92-a319-060eeb940837', CAST(N'2023-05-06T16:41:57.963' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'acd30ee8-8ddb-4585-bc00-710a42e21eee', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'dbe314ac-4c6c-450b-9076-d818b5327601', CAST(N'2023-05-06T16:17:28.110' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'0bd01e39-8448-4dee-8b5a-73b489ca0066', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'236b9507-b607-491f-b810-6b7e9f2f9812', CAST(N'2023-05-06T16:28:01.143' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'9a04aeaf-bc83-4196-ab92-75b57f5b4f75', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9643206a-6a9a-4c33-9f51-fd7a607c64e5', CAST(N'2023-05-06T16:39:24.093' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'9670930f-d302-4a44-a3e3-772433148972', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'3e8071b4-844a-4c51-9e7c-aa0a9eeb9cff', CAST(N'2023-05-06T16:18:37.730' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'7f2c0cad-bf7e-4132-9f80-7d5c08f2e775', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'bff5378c-a971-40d8-9816-67d3d2b0d3b9', CAST(N'2023-05-06T16:10:37.303' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f57708ec-213f-47c5-a195-7ebdd3461a67', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'e3cc3ca6-e71f-42ec-8cde-248dcb81e11b', CAST(N'2023-05-06T16:30:57.030' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f58bce5d-8995-41f8-9ab5-7ec76050bb09', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'402c395c-99e8-410b-b7ed-6cb19c51fe0b', CAST(N'2023-05-06T16:38:41.117' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'5a766b90-76e0-4082-9051-80405159f0cb', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'5fc31522-5072-4b75-bb34-e2e323521694', CAST(N'2023-05-06T16:36:56.443' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'3a17defc-1bd3-40f8-96a8-821050150228', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'd50293b2-9083-40e7-8959-ef6b4dc3d046', CAST(N'2023-05-06T16:42:54.040' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'58e263d5-951d-4925-9856-8234adfc3f70', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'36074fa0-9618-46de-a604-325ef9541fb3', CAST(N'2023-05-06T16:27:17.343' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'e53378a8-f5b9-4b19-912d-84d5a5e3987d', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'ee4cedc9-4b17-4b1a-b7e4-8be680cdf5fa', CAST(N'2023-05-06T16:22:00.963' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'202c5892-e379-4fe4-bcee-86281591f592', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'01e1b171-d7d7-4bf3-9b5e-bad48d57c896', CAST(N'2023-05-06T16:32:39.473' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'6edda543-a912-495e-b596-89f517f70c90', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'463f2790-c999-4de4-9ffa-a9071acc41c2', CAST(N'2023-05-06T16:51:36.807' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'af830f6f-7276-409c-809c-8a07df9c5a0e', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'd3c57355-eee8-4614-a304-29f89f0f4a3e', CAST(N'2023-05-06T16:52:51.773' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'6ff0ce06-05f9-4aed-ae25-8c9e67ef51f6', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'3c8ec9ce-b9b6-4657-92ce-cd8e1fc4a632', CAST(N'2023-05-06T16:41:46.093' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'759033a2-8f44-45e9-8b7b-8fa2a2334d75', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'f1261858-c4db-44e7-b6fd-7922fde63f16', CAST(N'2023-05-06T16:36:15.200' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'b2fab4c7-218e-4369-ac7d-90195c586b5e', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'baaa576a-f2a8-4c2c-b94c-ca30746b47a5', CAST(N'2023-05-06T16:30:36.667' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'd67fc06f-3e44-4cc9-a334-93a0794ea23f', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'3c4b7e3b-2f42-4af0-98ef-2bd30895fd93', CAST(N'2023-05-06T17:03:37.273' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'4e294340-5445-4079-9acb-94101f9099d5', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'2159b411-292a-4620-adb8-29f62bde38ed', CAST(N'2023-05-06T16:44:20.363' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'9c43722f-acf1-4f0c-a8c7-9421764f1e9a', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'05a4078f-1f26-4fea-a268-394ef56f3aaf', CAST(N'2023-05-06T16:30:32.767' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'd85a4849-fc56-49a3-baeb-9680508e54cd', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'2c7d823e-dd6f-47ad-8019-572be245272c', CAST(N'2023-05-06T16:35:25.433' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'36a9eb03-e031-4cf2-ab09-980046d68324', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'c85f4904-d9df-4286-b030-9c4b7680ca4e', CAST(N'2023-05-06T16:41:34.970' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'e893968d-d0f5-443d-8e78-982eb2b0c59e', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'ab6141c1-7c0d-4a4c-86b3-73ef989a3406', CAST(N'2023-05-06T16:16:24.860' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f1f9f641-6b93-42a8-8edd-98f6c6e03fc7', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'91197d14-4899-4511-90e1-a93fbb87a49a', CAST(N'2023-05-06T16:41:11.380' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'cc077d3c-a635-4a46-88a1-993d56a1c1ae', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'69ab06fd-f10d-4f16-8f9e-02471b108d44', CAST(N'2023-05-06T16:52:14.933' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'4020999b-449c-44f5-b749-9a9d6d632241', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'0d4a8a2a-971f-4056-b3d4-e04bf4575ac5', CAST(N'2023-05-06T16:48:08.253' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'65af238e-95e6-4c2d-b2bf-a1cf9b956bf2', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'ca9e11c8-442d-4392-bb4a-b0a2e2779cef', CAST(N'2023-05-06T16:59:03.177' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'3e328e73-68fc-42e8-b3c3-a2338ba5b0fe', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'a10b7eb5-41a0-4102-ab36-636fd2966cb8', CAST(N'2023-05-06T16:40:56.460' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'1bcd4a54-5dd5-441e-bb4d-a36124b32ed0', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b5defd14-fa14-41bd-89e0-e8876c2446ea', CAST(N'2023-05-06T16:51:07.733' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'7350f53d-1029-4a51-8d7b-ab6d467d3051', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'59401ad8-7675-48df-9b48-2ffcf6671275', CAST(N'2023-05-06T16:34:06.267' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'10f3b0a1-e0ce-49d1-8172-add3bca1144a', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b950068b-5a78-458d-ada0-74516ec4cef5', CAST(N'2023-05-06T16:33:52.107' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'1b03283e-0aa7-4718-9f39-af207e96a982', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'1680c904-2d13-4d04-8b56-03a747200b4c', CAST(N'2023-05-06T15:12:00.787' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'40d7719d-4057-4466-b0b1-af23d6709aa4', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'58f8942c-380f-49cc-a906-69f0b63f029f', CAST(N'2023-05-07T17:44:25.563' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'5cbc5b93-3bc9-4254-ab26-af3fa61e354a', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'ae5acc7c-9e5d-47da-aeaa-a6191667e2e6', CAST(N'2023-05-06T16:23:03.117' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'8249cfc8-caaa-4307-923b-b537da1a7efb', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'11b69c78-72c0-43e4-8843-6fa638523fe9', CAST(N'2023-05-06T16:26:42.423' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'5128cdc0-964a-48cc-91ed-b57061b5e3ef', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'931ac2ce-a6b2-4ae1-badb-f6759b422e40', CAST(N'2023-05-06T16:21:38.877' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'a8e8885a-04c7-4e25-a777-b699e0c75d24', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'237181dc-2c75-482c-b428-4a229f7c0ba8', CAST(N'2023-05-06T16:37:54.347' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'd2c9b63c-30b4-42df-90ae-b7ed8d038b0b', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'139063ff-4ee2-4e40-9616-0fa62dc28245', CAST(N'2023-05-06T16:30:35.567' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'8ad5be73-8e70-4047-91bc-b7f58802f0ff', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'2f7ebda6-38dd-4032-bfee-d4e2a7d80696', CAST(N'2023-05-06T13:55:23.997' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f17772c4-f637-4739-8ce4-b99b360c943a', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'2fc2345e-39b9-4368-9747-62e3c54db7ee', CAST(N'2023-05-06T16:22:52.497' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'acec674f-54a2-4f46-b4a0-bc8caada7906', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'7169d42a-56ee-4277-bd20-2e59a4fe6978', CAST(N'2023-05-06T16:22:05.267' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'a8ae3a3b-25f7-4e48-9452-bcd9eb892caf', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'a52f8552-3b68-4bc8-b101-7948cb87dc1c', CAST(N'2023-05-06T17:00:23.977' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'e3fb20c6-11f7-4da2-8b1d-c115abb7b04d', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'a11facab-20d2-471d-bcd9-5f1caeea29d0', CAST(N'2023-05-06T16:41:24.157' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'87500b68-5763-4d2d-af6c-c23526eebbca', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'514c5c67-e490-41e7-85b6-119ac53994dd', CAST(N'2023-05-06T15:05:09.370' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'25b94a1a-84a9-4030-8f02-c71c372fcb43', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'65041066-2eba-49a0-a9f0-fb312e93f9dc', CAST(N'2023-05-06T17:04:50.370' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f5787406-f017-4e93-bb8c-c783c82b97aa', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'5c740d18-c5a5-4d09-800e-5720b40e2496', CAST(N'2023-05-06T16:27:38.853' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'0b092f35-5462-4e54-801f-d0cd052ea3d0', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'd8b57e8d-1195-44ca-ba6e-79f25c4d554d', CAST(N'2023-05-06T16:24:34.490' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'3439a55c-4912-4352-a244-d1fb27f447ea', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'bba060ab-f959-443d-a7b4-70e144639b5c', CAST(N'2023-05-06T16:51:05.430' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'84c43c31-372e-423d-97ca-d3728059531e', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'4eb2609b-9d56-40eb-8e7f-ddf2f11031ab', CAST(N'2023-05-06T16:08:41.643' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'1717412e-db65-4212-8c09-d887cde436cd', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'3fbf43b6-5848-46f6-bc01-10af1ef44464', CAST(N'2023-05-06T16:26:59.867' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'b7d2c114-fea0-46e9-a966-d8f15d7d9bfd', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b8d429d1-4add-4a89-8825-49c1e98a6de1', CAST(N'2023-05-06T16:20:51.947' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'859207f9-0b3c-4efb-9e5e-da82164fbf57', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'a0fd0380-0e87-4647-94ec-08b003baadc6', CAST(N'2023-05-06T16:45:09.453' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'96da7337-7d06-440b-b1eb-dca2ad7df149', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'cb50e61f-92ae-429a-930e-d0795cf7f1b3', CAST(N'2023-05-06T16:27:20.087' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'3ba17278-5392-406a-9721-dd0b0a368c41', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'6c4f8db5-0f55-4361-adde-4f5e02bbe78f', CAST(N'2023-05-06T16:18:40.137' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'b859f76b-7ead-4989-b2ac-dd44f83c23ea', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'1277df2f-29f7-4cfb-a2d4-71040aa5543b', CAST(N'2023-05-06T16:37:27.090' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'fd6a3339-c4d1-443f-9599-dee1f52c85c1', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9281be96-6089-4904-a61d-ffbe2c808a08', CAST(N'2023-05-06T16:11:30.593' AS DateTime), 1)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'3fc1badc-3644-48a9-aba7-df2ff24d6d80', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'f6ebcb8e-a4b1-4b12-a066-491975fb4ea7', CAST(N'2023-05-06T16:40:32.513' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'572aea76-6cb9-458b-8507-e02cddfa22d1', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'1e97f8ba-ef7d-40ba-93d2-d7afcf0b4a03', CAST(N'2023-05-06T16:50:15.857' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'd3f52edf-cb42-4951-958e-e34b803d672c', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'848a4755-2e33-4e2b-89e7-7d1e4b23b499', CAST(N'2023-05-06T13:45:05.237' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'6a9cfecb-82ea-4044-a65d-e3630b33e1c5', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'9dd82c1f-ff52-4505-b9c3-3ea792d43ffd', CAST(N'2023-05-06T16:44:53.600' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'32316cf6-dc04-4e3f-84b7-e6c0d8ca3dd7', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'b75441ea-04ae-4a11-b475-66c817a2548d', CAST(N'2023-05-06T16:50:47.303' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'1dbf836f-90f6-411b-af7e-e73b7ebc3aaf', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'7d74602b-0a8b-41df-8881-cb6507285381', CAST(N'2023-05-06T16:34:25.443' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'a40250df-5691-48a4-9bf8-ea3e03cbdf67', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'f0fefc9c-e68b-426e-a160-3166d8c41020', CAST(N'2023-05-06T16:24:35.517' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'8597669f-52da-4d25-8b42-eef8c733364c', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'bbcd2491-41aa-4ac0-8c99-2c1ebc0a1d19', CAST(N'2023-05-06T16:42:20.477' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'9e9ead5a-1f35-4cd9-8633-f2d8c81a9358', N'547c49ab-ce90-46a8-b965-d681a3e1ebe5', N'3f86e58d-fe71-4910-bcd4-4401cde53d93', CAST(N'2023-05-06T12:39:00.100' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'f5c31151-1d3b-44eb-85b2-f50244058f23', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'e9081add-38de-49ba-aa43-de09cffc406a', CAST(N'2023-05-06T16:40:26.227' AS DateTime), 0)
GO
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'90ca478a-c058-4ccb-a998-f578e9664b65', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'd41c8f91-eea3-4f1a-a1db-625a7be17ea1', CAST(N'2023-05-06T13:43:55.687' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'cdf3a0db-97c5-4f4b-9217-fcc72b51902d', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'ec400550-e141-40fe-a5fd-dd61af8579aa', CAST(N'2023-05-06T16:38:12.620' AS DateTime), 0)
INSERT [dbo].[Games] ([id], [player_id], [pokemon_encounter_id], [timestamp], [completed]) VALUES (N'aed48dbc-e36d-457d-86fc-fd9aad829f97', N'1bc99f42-c650-4f70-89b2-111607ce6848', N'1238ee56-1a15-4f2d-97b8-22df05d960cc', CAST(N'2023-05-06T16:42:27.730' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (1, N'Route 1                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (2, N'Route 2                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (3, N'Route 3                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (4, N'Route 4                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (5, N'Route 5                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (6, N'Route 6                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (7, N'Route 7                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (8, N'Route 8                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (9, N'Route 9                                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (10, N'Route 10                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (11, N'Route 11                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (12, N'Route 12                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (13, N'Route 13                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (14, N'Route 14                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (15, N'Route 15                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (16, N'Route 16                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (17, N'Route 17                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (18, N'Route 18                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (19, N'Route 19                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (20, N'Route 20                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (21, N'Route 21                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (22, N'Route 22                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (23, N'Route 23                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (24, N'Route 24                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (25, N'Route 25                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (26, N'Celadon City                                      ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (27, N'Cerulean Cave                                     ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (28, N'Cerulean City                                     ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (29, N'Cinnabar Island                                   ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (30, N'Diglett''s Cave                                    ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (31, N'Fuchsia City                                      ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (32, N'Kanto Power Plant                                 ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (33, N'Kanto Safari Zone                                 ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (34, N'Mt. Moon                                          ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (35, N'Pallet Town                                       ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (36, N'Pokémon Mansion (Kanto)                           ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (37, N'Pokémon Tower                                     ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (38, N'Saffron City                                      ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (39, N'Seafoam Islands                                   ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (40, N'Silph Co.                                         ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (41, N'Vermilion City                                    ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (42, N'Victory Road (Kanto)                              ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (43, N'Viridian City                                     ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (44, N'Viridian Forest                                   ')
INSERT [dbo].[Locations] ([id_location], [location_name]) VALUES (45, N'Rock Tunnel                                       ')
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (1, N'Warning', N'Failed login attempt from ::1', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (2, N'Warning', N'Sucessful login by NEisner at 5/5/2023 8:28:31 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (3, N'Warning', N'Sucessful login by NEisner at 5/5/2023 8:31:39 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (4, N'Warning', N'Sucessful login by NEisner at 5/5/2023 8:47:12 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (5, N'Warning', N'Sucessful login by NEisner at 5/5/2023 8:50:50 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (6, N'Warning', N'Sucessful login by NEisner at 5/5/2023 8:54:05 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (7, N'Warning', N'Sucessful login by NEisner at 5/5/2023 8:59:20 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (8, N'Error', N'Exception thrown by Guess()', N'System.Exception: UHOH
   at APIService.Data_Access_Layers.GameDAL.GetGameById(Guid id) in C:\workspace\src\prog455\Final\APIService\DALs\GameDAL.cs:line 140
   at APIService.GameService.GetGameById(Guid id) in C:\workspace\src\prog455\Final\APIService\GameService.cs:line 58
   at API.Controllers.GameController.Guess(GameRequestModel model) in C:\workspace\src\prog455\Final\API\Controllers\GameController.cs:line 67')
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (9, N'Info', N'Sucessful login by NEisner at 5/6/2023 11:02:37 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (10, N'Info', N'Sucessful login by NEisner at 5/6/2023 11:15:49 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (11, N'Info', N'Sucessful login by NEisner at 5/6/2023 11:17:41 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (12, N'Info', N'Sucessful login by NEisner at 5/6/2023 11:34:10 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (13, N'Info', N'Sucessful login by NEisner at 5/6/2023 11:36:32 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (14, N'Info', N'New user sign up successful. c592de0b-77af-40f4-9739-f6eebece60bd registered at 5/6/2023 11:49:14 AM.', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (15, N'Warning', N'Failed login attempt to account T3amR0cket at 5/6/2023 11:49:42 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (16, N'Info', N'Sucessful login by T3amR0cket at 5/6/2023 11:49:54 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (17, N'Info', N'Sucessful login by T3amR0cket at 5/6/2023 11:51:57 AM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (18, N'Info', N'New user sign up successful. 1bc99f42-c650-4f70-89b2-111607ce6848 registered at 5/6/2023 12:33:26 PM.', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (19, N'Info', N'Sucessful login by NEisner at 5/6/2023 12:33:52 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (20, N'Info', N'New user sign up successful. 547c49ab-ce90-46a8-b965-d681a3e1ebe5 registered at 5/6/2023 12:35:45 PM.', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (21, N'Info', N'Sucessful login by NEisner at 5/6/2023 1:43:35 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (22, N'Info', N'Sucessful login by NEisner at 5/6/2023 1:44:31 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (23, N'Info', N'Sucessful login by NEisner at 5/6/2023 1:47:06 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (24, N'Info', N'Sucessful login by NEisner at 5/6/2023 1:55:20 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (25, N'Warning', N'Failed login attempt to account NEisner at 5/6/2023 3:05:01 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (26, N'Info', N'Sucessful login by NEisner at 5/6/2023 3:05:07 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (27, N'Info', N'Sucessful login by NEisner at 5/6/2023 3:06:40 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (28, N'Info', N'Sucessful login by NEisner at 5/6/2023 3:09:28 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (29, N'Info', N'Sucessful login by NEisner at 5/6/2023 3:11:08 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (30, N'Info', N'Sucessful login by NEisner at 5/6/2023 3:11:56 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (31, N'Info', N'Sucessful login by NEisner at 5/6/2023 4:08:40 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (32, N'Info', N'Sucessful login by NEisner at 5/6/2023 4:10:11 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (33, N'Info', N'Sucessful login by NEisner at 5/6/2023 4:10:36 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (34, N'Info', N'Sucessful login by NEisner at 5/6/2023 4:11:29 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (35, N'Info', N'Sucessful login by NEisner at 5/6/2023 4:13:52 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (36, N'Info', N'Sucessful login by NEisner at 5/6/2023 4:16:22 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (37, N'Info', N'Sucessful login by NEisner at 5/6/2023 5:08:24 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (38, N'Info', N'Sucessful login by NEisner at 5/6/2023 5:09:29 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (39, N'Info', N'Sucessful login by NEisner at 5/6/2023 7:57:11 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (1002, N'Info', N'Sucessful login by NEisner at 5/6/2023 9:38:03 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (1003, N'Info', N'An execption was thrown by EcounterHistory Index()', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (1004, N'Info', N'Sucessful login by NEisner at 5/6/2023 9:43:13 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (1005, N'Info', N'An execption was thrown by EcounterHistory Index()', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (1006, N'Info', N'An execption was thrown by EcounterHistory Index()', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (2002, N'Info', N'Sucessful login by NEisner at 5/7/2023 5:42:23 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (2003, N'Info', N'New user sign up successful. 908e5083-7c23-4368-8eba-7868b72051f5 registered at 5/7/2023 5:43:58 PM.', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (2004, N'Info', N'Failed login attempt to account NEisner at 5/7/2023 5:44:19 PM', NULL)
INSERT [dbo].[Log] ([id], [LogLevel], [LogMessage], [Exception]) VALUES (2005, N'Info', N'Sucessful login by NEisner at 5/7/2023 5:44:23 PM', NULL)
SET IDENTITY_INSERT [dbo].[Log] OFF
GO
SET IDENTITY_INSERT [dbo].[Pokemon] ON 

INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (1, N'Bulbasaur', 2, 13, 1, 1)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (2, N'Ivysaur', 2, 13, 1, 2)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (3, N'Venusaur', 2, 13, 1, 3)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (4, N'Charmander', 1, 0, 2, 4)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (5, N'Charmeleon', 1, 0, 2, 5)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (6, N'Charizard', 1, 8, 2, 6)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (7, N'Squirtle', 3, 0, 3, 7)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (8, N'Wartortle', 3, 0, 3, 8)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (9, N'Blastoise', 3, 0, 3, 9)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (10, N'Caterpie', 4, 0, 4, 10)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (11, N'Metapod', 4, 0, 5, 11)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (12, N'Butterfree', 4, 8, 6, 12)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (13, N'Weedle', 4, 13, 4, 13)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (14, N'Kakuna', 4, 13, 5, 14)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (15, N'Beedrill', 4, 13, 7, 15)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (16, N'Pidgey', 12, 8, 8, 16)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (17, N'Pidgeotto', 12, 8, 8, 17)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (18, N'Pidgeot', 12, 8, 8, 18)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (19, N'Rattata', 12, 0, 9, 19)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (20, N'Raticate', 12, 0, 9, 20)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (21, N'Spearow', 12, 8, 8, 21)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (22, N'Fearow', 12, 8, 8, 22)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (23, N'Ekans', 13, 0, 12, 23)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (24, N'Arbok', 13, 0, 12, 24)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (25, N'Pikachu', 6, 0, 14, 25)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (26, N'Raichu', 6, 0, 14, 26)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (27, N'Sandshrew', 10, 0, 15, 27)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (28, N'Sandslash', 10, 0, 15, 28)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (29, N'Nidoran♀', 13, 0, 16, 29)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (30, N'Nidorina', 13, 0, 16, 30)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (31, N'Nidoqueen', 13, 10, 16, 31)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (32, N'Nidoran♂', 13, 0, 16, 32)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (33, N'Nidorino', 13, 0, 16, 33)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (34, N'Nidoking', 13, 10, 16, 34)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (35, N'Clefairy', 12, 0, 18, 35)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (36, N'Clefable', 12, 0, 18, 36)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (37, N'Vulpix', 1, 0, 20, 37)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (38, N'Ninetales', 1, 0, 20, 38)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (39, N'Jigglypuff', 12, 0, 18, 39)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (40, N'Wigglytuff', 12, 0, 18, 40)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (41, N'Zubat', 13, 8, 21, 41)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (42, N'Golbat', 13, 8, 21, 42)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (43, N'Oddish', 2, 13, 22, 43)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (44, N'Gloom', 2, 13, 22, 44)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (45, N'Vileplume', 2, 13, 22, 45)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (46, N'Paras', 4, 2, 26, 46)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (47, N'Parasect', 4, 2, 26, 47)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (48, N'Venonat', 4, 13, 6, 48)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (49, N'Venomoth', 4, 13, 4, 49)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (50, N'Diglett', 10, 0, 15, 50)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (51, N'Dugtrio', 10, 0, 15, 51)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (52, N'Meowth', 12, 0, 35, 52)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (53, N'Persian', 12, 0, 36, 53)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (54, N'Psyduck', 3, 0, 37, 54)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (55, N'Golduck', 3, 0, 37, 55)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (56, N'Mankey', 7, 0, 39, 56)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (57, N'Primeape', 7, 0, 39, 57)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (58, N'Growlithe', 1, 0, 12, 58)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (59, N'Arcanine', 1, 0, 12, 59)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (60, N'Poliwag', 3, 0, 43, 60)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (61, N'Poliwhirl', 3, 0, 43, 61)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (62, N'Poliwrath', 3, 0, 43, 62)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (63, N'Abra', 14, 0, 46, 63)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (64, N'Kadabra', 14, 0, 46, 64)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (65, N'Alakazam', 14, 0, 46, 65)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (66, N'Machop', 7, 0, 11, 66)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (67, N'Machoke', 7, 0, 11, 67)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (68, N'Machamp', 7, 0, 11, 68)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (69, N'Bellsprout', 2, 13, 22, 69)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (70, N'Weepinbell', 2, 13, 22, 70)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (71, N'Victreebel', 2, 13, 22, 71)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (72, N'Tentacool', 3, 13, 47, 72)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (73, N'Tentacruel', 3, 13, 47, 73)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (74, N'Geodude', 15, 10, 48, 74)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (75, N'Graveler', 15, 10, 48, 75)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (76, N'Golem', 15, 10, 48, 76)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (77, N'Ponyta', 1, 0, 9, 77)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (78, N'Rapidash', 1, 0, 9, 78)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (79, N'Slowpoke', 3, 14, 51, 79)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (80, N'Slowbro', 3, 14, 51, 80)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (81, N'Magnemite', 6, 16, 53, 81)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (82, N'Magneton', 6, 16, 53, 82)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (83, N'Farfetch''d', 12, 8, 8, 83)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (84, N'Doduo', 12, 8, 9, 84)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (85, N'Dodrio', 12, 8, 9, 85)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (86, N'Seel', 3, 0, 58, 86)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (87, N'Dewgong', 3, 11, 58, 87)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (88, N'Grimer', 13, 0, 60, 88)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (89, N'Muk', 13, 0, 60, 89)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (90, N'Shellder', 3, 0, 62, 90)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (91, N'Cloyster', 3, 11, 62, 91)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (92, N'Gastly', 9, 13, 64, 92)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (93, N'Haunter', 9, 13, 64, 93)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (94, N'Gengar', 9, 13, 64, 94)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (95, N'Onix', 15, 10, 48, 95)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (96, N'Drowzee', 14, 0, 69, 96)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (97, N'Hypno', 14, 0, 69, 97)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (98, N'Krabby', 3, 0, 70, 98)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (99, N'Kingler', 3, 0, 70, 99)
GO
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (100, N'Voltorb', 6, 0, 72, 100)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (101, N'Electrode', 6, 0, 72, 101)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (102, N'Exeggcute', 2, 14, 22, 102)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (103, N'Exeggutor', 2, 14, 22, 103)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (104, N'Cubone', 10, 0, 48, 104)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (105, N'Marowak', 10, 0, 48, 105)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (106, N'Hitmonlee', 7, 0, 36, 106)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (107, N'Hitmonchan', 7, 0, 7, 107)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (108, N'Lickitung', 12, 0, 73, 108)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (109, N'Koffing', 13, 0, 64, 109)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (110, N'Weezing', 13, 0, 64, 110)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (111, N'Rhyhorn', 10, 15, 28, 111)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (112, N'Rhydon', 10, 15, 28, 112)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (113, N'Chansey', 12, 0, 74, 113)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (114, N'Tangela', 2, 0, 22, 114)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (115, N'Kangaskhan', 12, 0, 75, 115)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (116, N'Horsea', 3, 0, 76, 116)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (117, N'Seadra', 3, 0, 16, 117)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (118, N'Goldeen', 3, 0, 76, 118)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (119, N'Seaking', 3, 0, 76, 119)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (120, N'Staryu', 3, 0, 78, 120)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (121, N'Starmie', 3, 14, 78, 121)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (122, N'Mr. Mime', 14, 0, 72, 122)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (123, N'Scyther', 4, 8, 7, 123)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (124, N'Jynx', 11, 14, 51, 124)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (125, N'Electabuzz', 6, 0, 14, 125)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (126, N'Magmar', 1, 0, 87, 126)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (127, N'Pinsir', 4, 0, 70, 127)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (128, N'Tauros', 12, 0, 12, 128)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (129, N'Magikarp', 3, 0, 76, 129)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (130, N'Gyarados', 3, 8, 12, 130)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (131, N'Lapras', 3, 11, 43, 131)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (132, N'Ditto', 12, 0, 36, 132)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (133, N'Eevee', 12, 0, 9, 133)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (134, N'Vaporeon', 3, 0, 43, 134)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (135, N'Jolteon', 6, 0, 93, 135)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (136, N'Flareon', 1, 0, 20, 136)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (137, N'Porygon', 12, 0, 95, 137)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (138, N'Omanyte', 15, 3, 76, 138)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (139, N'Omastar', 15, 3, 76, 139)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (140, N'Kabuto', 15, 3, 76, 140)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (141, N'Kabutops', 15, 3, 76, 141)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (142, N'Aerodactyl', 15, 8, 48, 142)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (143, N'Snorlax', 12, 0, 101, 143)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (144, N'Articuno', 11, 8, 102, 144)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (145, N'Zapdos', 6, 8, 102, 145)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (146, N'Moltres', 1, 8, 102, 146)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (147, N'Dratini', 5, 0, 5, 147)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (148, N'Dragonair', 5, 0, 5, 148)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (149, N'Dragonite', 5, 8, 21, 149)
INSERT [dbo].[Pokemon] ([dex_number], [name], [type_1_id], [type_2_id], [ability_id], [sprites_id]) VALUES (150, N'Mewtwo', 14, 0, 102, 150)
SET IDENTITY_INSERT [dbo].[Pokemon] OFF
GO
SET IDENTITY_INSERT [dbo].[Pokemon_Locations] ON 

INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (1, 16, 1)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (2, 19, 1)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (3, 19, 2)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (4, 16, 2)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (5, 13, 2)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (6, 122, 2)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (7, 10, 2)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (8, 16, 3)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (9, 21, 3)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (10, 39, 3)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (11, 19, 4)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (12, 21, 4)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (13, 23, 4)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (14, 129, 4)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (15, 43, 5)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (16, 69, 5)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (17, 16, 5)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (18, 56, 5)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (19, 52, 5)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (20, 29, 5)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (21, 16, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (22, 43, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (23, 52, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (24, 56, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (25, 69, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (26, 129, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (27, 60, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (28, 118, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (29, 90, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (30, 98, 6)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (31, 16, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (32, 43, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (33, 69, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (34, 56, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (35, 52, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (36, 58, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (37, 37, 7)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (38, 16, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (39, 23, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (40, 27, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (41, 37, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (42, 56, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (43, 52, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (44, 58, 8)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (45, 19, 9)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (46, 21, 9)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (47, 23, 9)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (48, 27, 9)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (49, 100, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (50, 21, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (51, 23, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (52, 27, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (53, 129, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (54, 60, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (55, 118, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (56, 61, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (57, 79, 10)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (58, 23, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (59, 27, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (60, 21, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (61, 96, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (62, 129, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (63, 60, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (64, 118, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (65, 90, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (66, 98, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (67, 30, 11)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (68, 43, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (69, 69, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (70, 16, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (71, 48, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (72, 44, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (73, 70, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (74, 129, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (75, 60, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (76, 118, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (77, 72, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (78, 98, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (79, 143, 12)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (80, 43, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (81, 69, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (82, 16, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (83, 48, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (84, 44, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (85, 70, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (86, 132, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (87, 129, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (88, 60, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (89, 118, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (90, 72, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (91, 98, 13)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (92, 43, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (93, 69, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (94, 48, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (95, 16, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (96, 132, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (97, 17, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (98, 44, 14)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (99, 70, 14)
GO
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (100, 43, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (101, 69, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (102, 48, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (103, 16, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (104, 132, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (105, 17, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (106, 44, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (107, 70, 15)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (108, 21, 16)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (109, 19, 16)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (110, 84, 16)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (111, 20, 16)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (112, 143, 16)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (113, 21, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (114, 20, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (115, 84, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (116, 22, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (117, 129, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (118, 60, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (119, 118, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (120, 72, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (121, 98, 17)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (122, 21, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (123, 84, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (124, 20, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (125, 22, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (126, 129, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (127, 60, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (128, 118, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (129, 72, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (130, 98, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (131, 72, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (132, 129, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (133, 60, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (134, 118, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (135, 90, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (136, 116, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (137, 120, 19)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (138, 72, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (139, 129, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (140, 60, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (141, 118, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (142, 90, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (143, 116, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (144, 120, 20)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (145, 19, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (146, 16, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (147, 17, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (148, 20, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (149, 114, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (150, 72, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (151, 129, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (152, 60, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (153, 118, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (154, 90, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (155, 116, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (156, 120, 21)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (157, 19, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (158, 32, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (159, 29, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (160, 21, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (161, 129, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (162, 60, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (163, 118, 22)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (164, 132, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (165, 22, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (166, 23, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (167, 27, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (168, 21, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (169, 24, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (170, 28, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (171, 129, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (172, 60, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (173, 118, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (174, 80, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (175, 99, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (176, 117, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (177, 119, 23)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (178, 13, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (179, 10, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (180, 43, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (181, 69, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (182, 16, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (183, 14, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (184, 11, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (185, 63, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (186, 129, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (187, 60, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (188, 118, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (189, 54, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (190, 98, 24)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (191, 13, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (192, 10, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (193, 43, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (194, 69, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (195, 14, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (196, 11, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (197, 16, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (198, 63, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (199, 129, 25)
GO
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (200, 60, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (201, 118, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (202, 54, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (203, 98, 25)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (204, 42, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (205, 82, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (206, 97, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (207, 24, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (208, 28, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (209, 49, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (210, 85, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (211, 47, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (212, 64, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (213, 26, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (214, 132, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (215, 101, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (216, 105, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (217, 112, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (218, 40, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (219, 113, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (220, 129, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (221, 60, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (222, 118, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (223, 80, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (224, 98, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (225, 117, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (226, 119, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (227, 150, 27)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (228, 129, 28)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (229, 60, 28)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (230, 118, 28)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (231, 54, 28)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (232, 98, 28)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (233, 124, 28)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (234, 129, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (235, 60, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (236, 118, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (237, 90, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (238, 116, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (239, 120, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (240, 138, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (241, 140, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (242, 142, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (243, 101, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (244, 86, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (245, 114, 29)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (246, 50, 30)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (247, 51, 30)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (248, 129, 31)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (249, 60, 31)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (250, 118, 31)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (251, 98, 31)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (252, 119, 31)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (253, 100, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (254, 25, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (255, 81, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (256, 82, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (257, 125, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (258, 26, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (259, 101, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (260, 145, 32)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (261, 32, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (262, 29, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (263, 102, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (264, 111, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (265, 48, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (266, 33, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (267, 30, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (268, 47, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (269, 123, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (270, 127, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (271, 113, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (272, 46, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (273, 84, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (274, 115, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (275, 128, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (276, 49, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (277, 129, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (278, 60, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (279, 118, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (280, 54, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (281, 79, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (282, 98, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (283, 147, 33)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (284, 41, 34)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (285, 74, 34)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (286, 46, 34)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (287, 35, 34)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (288, 4, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (289, 1, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (290, 7, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (291, 129, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (292, 60, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (293, 118, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (294, 72, 35)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (295, 77, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (296, 109, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (297, 58, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (298, 37, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (299, 88, 36)
GO
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (300, 110, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (301, 89, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (302, 126, 36)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (303, 92, 37)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (304, 104, 37)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (305, 93, 37)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (306, 106, 38)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (307, 107, 38)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (308, 86, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (309, 116, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (310, 98, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (311, 90, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (312, 120, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (313, 79, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (314, 41, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (315, 54, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (316, 55, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (317, 80, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (318, 42, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (319, 87, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (320, 117, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (321, 99, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (322, 129, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (323, 60, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (324, 118, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (325, 144, 39)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (326, 131, 40)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (327, 129, 41)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (328, 60, 41)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (329, 118, 41)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (330, 90, 41)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (331, 98, 41)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (332, 83, 41)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (333, 95, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (334, 66, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (335, 41, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (336, 74, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (337, 42, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (338, 67, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (339, 105, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (340, 75, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (341, 49, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (342, 146, 42)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (343, 129, 43)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (344, 60, 43)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (345, 118, 43)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (346, 72, 43)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (347, 13, 44)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (348, 10, 44)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (349, 14, 44)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (350, 11, 44)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (351, 25, 44)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (352, 41, 45)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (353, 74, 45)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (354, 66, 45)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (355, 95, 45)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (356, 108, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (357, 108, 18)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (358, 133, 26)
INSERT [dbo].[Pokemon_Locations] ([id_pkmn_spawn], [pokemon_id], [location_id]) VALUES (359, 137, 26)
SET IDENTITY_INSERT [dbo].[Pokemon_Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[Sprites] ON 

INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (1, N'./css/sprites/1.png', N'./css/sprites/1_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (2, N'./css/sprites/2.png', N'./css/sprites/2_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (3, N'./css/sprites/3.png', N'./css/sprites/3_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (4, N'./css/sprites/4.png', N'./css/sprites/4_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (5, N'./css/sprites/5.png', N'./css/sprites/5_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (6, N'./css/sprites/6.png', N'./css/sprites/6_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (7, N'./css/sprites/7.png', N'./css/sprites/7_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (8, N'./css/sprites/8.png', N'./css/sprites/8_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (9, N'./css/sprites/9.png', N'./css/sprites/9_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (10, N'./css/sprites/10.png', N'./css/sprites/10_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (11, N'./css/sprites/11.png', N'./css/sprites/11_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (12, N'./css/sprites/12.png', N'./css/sprites/12_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (13, N'./css/sprites/13.png', N'./css/sprites/13_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (14, N'./css/sprites/14.png', N'./css/sprites/14_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (15, N'./css/sprites/15.png', N'./css/sprites/15_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (16, N'./css/sprites/16.png', N'./css/sprites/16_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (17, N'./css/sprites/17.png', N'./css/sprites/17_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (18, N'./css/sprites/18.png', N'./css/sprites/18_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (19, N'./css/sprites/19.png', N'./css/sprites/19_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (20, N'./css/sprites/20.png', N'./css/sprites/20_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (21, N'./css/sprites/21.png', N'./css/sprites/21_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (22, N'./css/sprites/22.png', N'./css/sprites/22_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (23, N'./css/sprites/23.png', N'./css/sprites/23_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (24, N'./css/sprites/24.png', N'./css/sprites/24_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (25, N'./css/sprites/25.png', N'./css/sprites/25_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (26, N'./css/sprites/26.png', N'./css/sprites/26_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (27, N'./css/sprites/27.png', N'./css/sprites/27_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (28, N'./css/sprites/28.png', N'./css/sprites/28_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (29, N'./css/sprites/29.png', N'./css/sprites/29_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (30, N'./css/sprites/30.png', N'./css/sprites/30_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (31, N'./css/sprites/31.png', N'./css/sprites/31_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (32, N'./css/sprites/32.png', N'./css/sprites/32_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (33, N'./css/sprites/33.png', N'./css/sprites/33_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (34, N'./css/sprites/34.png', N'./css/sprites/34_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (35, N'./css/sprites/35.png', N'./css/sprites/35_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (36, N'./css/sprites/36.png', N'./css/sprites/36_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (37, N'./css/sprites/37.png', N'./css/sprites/37_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (38, N'./css/sprites/38.png', N'./css/sprites/38_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (39, N'./css/sprites/39.png', N'./css/sprites/39_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (40, N'./css/sprites/40.png', N'./css/sprites/40_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (41, N'./css/sprites/41.png', N'./css/sprites/41_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (42, N'./css/sprites/42.png', N'./css/sprites/42_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (43, N'./css/sprites/43.png', N'./css/sprites/43_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (44, N'./css/sprites/44.png', N'./css/sprites/44_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (45, N'./css/sprites/45.png', N'./css/sprites/45_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (46, N'./css/sprites/46.png', N'./css/sprites/46_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (47, N'./css/sprites/47.png', N'./css/sprites/47_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (48, N'./css/sprites/48.png', N'./css/sprites/48_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (49, N'./css/sprites/49.png', N'./css/sprites/49_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (50, N'./css/sprites/50.png', N'./css/sprites/50_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (51, N'./css/sprites/51.png', N'./css/sprites/51_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (52, N'./css/sprites/52.png', N'./css/sprites/52_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (53, N'./css/sprites/53.png', N'./css/sprites/53_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (54, N'./css/sprites/54.png', N'./css/sprites/54_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (55, N'./css/sprites/55.png', N'./css/sprites/55_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (56, N'./css/sprites/56.png', N'./css/sprites/56_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (57, N'./css/sprites/57.png', N'./css/sprites/57_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (58, N'./css/sprites/58.png', N'./css/sprites/58_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (59, N'./css/sprites/59.png', N'./css/sprites/59_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (60, N'./css/sprites/60.png', N'./css/sprites/60_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (61, N'./css/sprites/61.png', N'./css/sprites/61_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (62, N'./css/sprites/62.png', N'./css/sprites/62_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (63, N'./css/sprites/63.png', N'./css/sprites/63_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (64, N'./css/sprites/64.png', N'./css/sprites/64_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (65, N'./css/sprites/65.png', N'./css/sprites/65_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (66, N'./css/sprites/66.png', N'./css/sprites/66_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (67, N'./css/sprites/67.png', N'./css/sprites/67_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (68, N'./css/sprites/68.png', N'./css/sprites/68_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (69, N'./css/sprites/69.png', N'./css/sprites/69_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (70, N'./css/sprites/70.png', N'./css/sprites/70_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (71, N'./css/sprites/71.png', N'./css/sprites/71_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (72, N'./css/sprites/72.png', N'./css/sprites/72_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (73, N'./css/sprites/73.png', N'./css/sprites/73_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (74, N'./css/sprites/74.png', N'./css/sprites/74_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (75, N'./css/sprites/75.png', N'./css/sprites/75_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (76, N'./css/sprites/76.png', N'./css/sprites/76_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (77, N'./css/sprites/77.png', N'./css/sprites/77_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (78, N'./css/sprites/78.png', N'./css/sprites/78_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (79, N'./css/sprites/79.png', N'./css/sprites/79_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (80, N'./css/sprites/80.png', N'./css/sprites/80_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (81, N'./css/sprites/81.png', N'./css/sprites/81_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (82, N'./css/sprites/82.png', N'./css/sprites/82_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (83, N'./css/sprites/83.png', N'./css/sprites/83_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (84, N'./css/sprites/84.png', N'./css/sprites/84_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (85, N'./css/sprites/85.png', N'./css/sprites/85_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (86, N'./css/sprites/86.png', N'./css/sprites/86_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (87, N'./css/sprites/87.png', N'./css/sprites/87_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (88, N'./css/sprites/88.png', N'./css/sprites/88_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (89, N'./css/sprites/89.png', N'./css/sprites/89_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (90, N'./css/sprites/90.png', N'./css/sprites/90_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (91, N'./css/sprites/91.png', N'./css/sprites/91_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (92, N'./css/sprites/92.png', N'./css/sprites/92_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (93, N'./css/sprites/93.png', N'./css/sprites/93_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (94, N'./css/sprites/94.png', N'./css/sprites/94_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (95, N'./css/sprites/95.png', N'./css/sprites/95_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (96, N'./css/sprites/96.png', N'./css/sprites/96_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (97, N'./css/sprites/97.png', N'./css/sprites/97_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (98, N'./css/sprites/98.png', N'./css/sprites/98_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (99, N'./css/sprites/99.png', N'./css/sprites/99_shape.png')
GO
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (100, N'./css/sprites/100.png', N'./css/sprites/100_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (101, N'./css/sprites/101.png', N'./css/sprites/101_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (102, N'./css/sprites/102.png', N'./css/sprites/102_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (103, N'./css/sprites/103.png', N'./css/sprites/103_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (104, N'./css/sprites/104.png', N'./css/sprites/104_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (105, N'./css/sprites/105.png', N'./css/sprites/105_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (106, N'./css/sprites/106.png', N'./css/sprites/106_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (107, N'./css/sprites/107.png', N'./css/sprites/107_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (108, N'./css/sprites/108.png', N'./css/sprites/108_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (109, N'./css/sprites/109.png', N'./css/sprites/109_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (110, N'./css/sprites/110.png', N'./css/sprites/110_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (111, N'./css/sprites/111.png', N'./css/sprites/111_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (112, N'./css/sprites/112.png', N'./css/sprites/112_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (113, N'./css/sprites/113.png', N'./css/sprites/113_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (114, N'./css/sprites/114.png', N'./css/sprites/114_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (115, N'./css/sprites/115.png', N'./css/sprites/115_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (116, N'./css/sprites/116.png', N'./css/sprites/116_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (117, N'./css/sprites/117.png', N'./css/sprites/117_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (118, N'./css/sprites/118.png', N'./css/sprites/118_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (119, N'./css/sprites/119.png', N'./css/sprites/119_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (120, N'./css/sprites/120.png', N'./css/sprites/120_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (121, N'./css/sprites/121.png', N'./css/sprites/121_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (122, N'./css/sprites/122.png', N'./css/sprites/122_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (123, N'./css/sprites/123.png', N'./css/sprites/123_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (124, N'./css/sprites/124.png', N'./css/sprites/124_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (125, N'./css/sprites/125.png', N'./css/sprites/125_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (126, N'./css/sprites/126.png', N'./css/sprites/126_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (127, N'./css/sprites/127.png', N'./css/sprites/127_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (128, N'./css/sprites/128.png', N'./css/sprites/128_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (129, N'./css/sprites/129.png', N'./css/sprites/129_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (130, N'./css/sprites/130.png', N'./css/sprites/130_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (131, N'./css/sprites/131.png', N'./css/sprites/131_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (132, N'./css/sprites/132.png', N'./css/sprites/132_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (133, N'./css/sprites/133.png', N'./css/sprites/133_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (134, N'./css/sprites/134.png', N'./css/sprites/134_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (135, N'./css/sprites/135.png', N'./css/sprites/135_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (136, N'./css/sprites/136.png', N'./css/sprites/136_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (137, N'./css/sprites/137.png', N'./css/sprites/137_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (138, N'./css/sprites/138.png', N'./css/sprites/138_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (139, N'./css/sprites/139.png', N'./css/sprites/139_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (140, N'./css/sprites/140.png', N'./css/sprites/140_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (141, N'./css/sprites/141.png', N'./css/sprites/141_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (142, N'./css/sprites/142.png', N'./css/sprites/142_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (143, N'./css/sprites/143.png', N'./css/sprites/143_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (144, N'./css/sprites/144.png', N'./css/sprites/144_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (145, N'./css/sprites/145.png', N'./css/sprites/145_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (146, N'./css/sprites/146.png', N'./css/sprites/146_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (147, N'./css/sprites/147.png', N'./css/sprites/147_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (148, N'./css/sprites/148.png', N'./css/sprites/148_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (149, N'./css/sprites/149.png', N'./css/sprites/149_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (150, N'./css/sprites/150.png', N'./css/sprites/150_shape.png')
INSERT [dbo].[Sprites] ([id_sprite], [sprite_path], [shape_path]) VALUES (151, N'./css/sprites/151.png', N'./css/sprites/151_shape.png')
SET IDENTITY_INSERT [dbo].[Sprites] OFF
GO
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (1, N'Fire                ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (2, N'Grass               ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (3, N'Water               ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (4, N'Bug                 ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (5, N'Dragon              ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (6, N'Electric            ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (7, N'Fighting            ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (8, N'Flying              ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (9, N'Ghost               ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (10, N'Ground              ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (11, N'Ice                 ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (12, N'Normal              ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (13, N'Poison              ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (14, N'Psychic             ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (15, N'Rock                ')
INSERT [dbo].[Types] ([id_type], [type_name]) VALUES (16, N'Steel               ')
SET IDENTITY_INSERT [dbo].[Types] OFF
GO
INSERT [dbo].[UsersTable] ([id], [username], [password], [salt], [signup_time]) VALUES (N'1bc99f42-c650-4f70-89b2-111607ce6848', N'NEisner', N'c917f29a1e32c2091b75b53ecde88aed38bd70c6e281cd39a04644c6c01823b60f23aef21f4a8e637395baa74c240adfd884dca5f8974fdf9f078138373b8c45', N'hKeqEsYQTKCX40mtJi6CqUW4XtmepcX7Dm1WQWrq1vitdR1a7C0iWHPq6hwDxLl8', CAST(N'2023-05-06T12:32:50.213' AS DateTime))
INSERT [dbo].[UsersTable] ([id], [username], [password], [salt], [signup_time]) VALUES (N'908e5083-7c23-4368-8eba-7868b72051f5', N'JohnDoe', N'f49e0c1ad711ec3ca201e6b29aa9b83970c347e3349b8056bc3241a5f0fbc50e7a0135c52cb4296970d05f0e6275757d2aecdc4fad3f2ee2f284195d8a200344', N'XMJa8WbO2RoC7mFErkXKmPgoH0Q4HsNduyvY6wFhmNEaxj67GE9gZp1gVSKEZNgG', CAST(N'2023-05-07T17:43:57.903' AS DateTime))
INSERT [dbo].[UsersTable] ([id], [username], [password], [salt], [signup_time]) VALUES (N'547c49ab-ce90-46a8-b965-d681a3e1ebe5', N'TeamRocket', N'b424faae44bf62fbe7a1de5aeb1a33a38c03974d864e4ef9ee1d5cf159cdc5ac5c2c6c2468fdd588b0fdc3d498d13f8aaa7f635096831ac116af6517ff7abf63', N'HXBv6Ye3NZYo8HYKtWDoRjIVIEM27n8mbz7lMjak52fzjKmrNRyLdqw2C0bxh5yW', CAST(N'2023-05-06T12:35:45.523' AS DateTime))
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Encounters] FOREIGN KEY([pokemon_encounter_id])
REFERENCES [dbo].[Encounters] ([id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Encounters]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_UsersTable] FOREIGN KEY([player_id])
REFERENCES [dbo].[UsersTable] ([id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_UsersTable]
GO
ALTER TABLE [dbo].[Types]  WITH CHECK ADD  CONSTRAINT [FK_Types_Types] FOREIGN KEY([id_type])
REFERENCES [dbo].[Types] ([id_type])
GO
ALTER TABLE [dbo].[Types] CHECK CONSTRAINT [FK_Types_Types]
GO
/****** Object:  StoredProcedure [dbo].[AbilitiesInsertRecord]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 4/29/23
-- Description:	Inserts passed in ability name and effect in the abilities table
-- =============================================
CREATE PROCEDURE [dbo].[AbilitiesInsertRecord] 
	@Name nchar(50),
	@Effect nchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Abilities]([abi_name],[abi_effect])
	VALUES(@Name,@Effect);
END
GO
/****** Object:  StoredProcedure [dbo].[EncountersGetAllByUserId]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EncountersGetAllByUserId]
	-- Add the parameters for the stored procedure here
	@UserId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * FROM Encounters
	INNER JOIN Games ON pokemon_encounter_id = Encounters.id 
	WHERE Games.player_id = @UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[EncountersGetRecordById]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EncountersGetRecordById] 
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Encounters WHERE id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[EncountersInsertRecord]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	Insert record into Encounters table
-- =============================================
CREATE PROCEDURE [dbo].[EncountersInsertRecord]
	-- Add the parameters for the stored procedure here
	@DexNum int,
	@Name nvarchar(25),
	@Type1 nvarchar(25),
	@Type2 nvarchar(25),
	@Ability nvarchar(25),
	@AbilDesc nvarchar(150),
	@Location nvarchar (50),
	@Sprite nvarchar(150),
	@Caught bit,
	@ReturnValue uniqueidentifier OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SET @ReturnValue = NEWID()

	INSERT INTO Encounters([id], [dex_num], [name], [type_1], [type_2], [ability], [ability_desc], [location], [sprite_path], [caught])
	VALUES(@ReturnValue, @DexNum, @Name, @Type1, @Type2, @Ability, @AbilDesc, @Location, @Sprite, @Caught);

END
GO
/****** Object:  StoredProcedure [dbo].[EncountersUpdateRecordById]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[EncountersUpdateRecordById]
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier,
	@DexNum int,
	@Name nvarchar(25),
	@Type1 nvarchar(25),
	@Type2 nvarchar(25),
	@Ability nvarchar(25),
	@AbilDesc nvarchar(150),
	@Location nvarchar (50),
	@Sprite nvarchar(150),
	@Caught bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE Encounters Set dex_num = @DexNum, type_1 = @Type1, type_2 = @Type2, ability = @Ability, ability_desc = @AbilDesc, location = @Location, sprite_path = @Sprite, caught = @Caught
	Where id = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[GamesGetRecordById]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GamesGetRecordById]
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Games WHERE id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[GamesInsertRecord]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GamesInsertRecord]
	-- Add the parameters for the stored procedure here
	@PlayerId uniqueidentifier,
	@EncounterId uniqueidentifier,
	@Timestemp datetime,
	@Completed bit,
	@ReturnValue uniqueidentifier OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @ReturnValue = NEWID()

	INSERT INTO Games([id],[player_id],[pokemon_encounter_id],[timestamp],[completed])
	VALUES(@ReturnValue, @PlayerId, @EncounterId, @Timestemp, @Completed);
END
GO
/****** Object:  StoredProcedure [dbo].[GamesUpdateRecordById]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	Updates the record matching the id
-- =============================================
CREATE PROCEDURE [dbo].[GamesUpdateRecordById]
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier, 
	@PlayerId uniqueidentifier,
	@EncounterId uniqueidentifier,
	@Timestemp datetime,
	@Completed bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Games Set player_id = @PlayerId, pokemon_encounter_id = @EncounterId, timestamp = @Timestemp, completed = @Completed WHERE id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPokemonRecordById]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 4/30/23
-- Description:	Gets pokemon from db
-- =============================================
CREATE PROCEDURE [dbo].[GetPokemonRecordById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	* 
	FROM Pokemon
	LEFT JOIN Types as T1 ON Pokemon.type_1_id = T1.id_type
	LEFT JOIN Types as T2 ON Pokemon.type_2_id = T2.id_type
	LEFT JOIN Abilities on Pokemon.ability_id = Abilities.id_abi
	LEFT JOIN Sprites on Pokemon.sprites_id = Sprites.id_sprite
	Where Pokemon.dex_number = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertPokemon]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPokemon]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Type_1_id int,
	@Type_2_id int,
	@Abil_id int,
	@sprite_Id int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT into Pokemon([name],[type_1_id],[type_2_id],[ability_id],[sprites_id])
	VALUES(@Name, @Type_1_id, @Type_2_id,@Abil_id, @sprite_Id);
END
GO
/****** Object:  StoredProcedure [dbo].[PokemonLocationInsertRecord]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/2/23
-- Description:	Insert Pokemon Location record into DB
-- =============================================
CREATE PROCEDURE [dbo].[PokemonLocationInsertRecord]
	-- Add the parameters for the stored procedure here
	@PokemonId int,
	@LocationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Pokemon_Locations([pokemon_id],[location_id])
	VALUES(@PokemonId, @LocationId);
END
GO
/****** Object:  StoredProcedure [dbo].[PokemonLocationsGetById]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/3/23
-- Description:	Get all location for specified pokemono
-- =============================================
CREATE PROCEDURE [dbo].[PokemonLocationsGetById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Pokemon_Locations 
	INNER JOIN Locations ON location_id = Locations.id_location
	WHERE pokemon_id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SpritesInsertRecord]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 4/29/23
-- Description:	Takes in a filepath string for the normal and outline sprite and inserts them into the sprite table
-- =============================================
CREATE PROCEDURE [dbo].[SpritesInsertRecord]
-- Add the parameters for the stored procedure here
	@Id int,
	@Sprite_File_Path nvarchar(50),
	@Shape_File_Path nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Sprites Set sprite_path = @Sprite_File_Path, shape_path = @Shape_File_Path WHERE id_sprite = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersGetByUsername]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nick Eisner
-- Create date: 5/2/23
-- Description:	Gets users matching the username parameter
-- =============================================
CREATE PROCEDURE [dbo].[UsersGetByUsername]
	@Username nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

    
	SELECT * FROM UsersTable WHERE username = @Username;
END
GO
/****** Object:  StoredProcedure [dbo].[UsersInsertRecord]    Script Date: 5/7/2023 8:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		nick Eisner
-- Create date: 5/2/23
-- Description:	Inserts a user into the database
-- =============================================
CREATE PROCEDURE [dbo].[UsersInsertRecord]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(max),
	@Password nvarchar(max),
	@SignupTime datetime,
	@Salt nvarchar(max),
	@ReturnValue uniqueidentifier OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @ReturnValue = NEWID()

	INSERT INTO UsersTable([id],[username],[password],[salt],[signup_time])
	VALUES(@ReturnValue, @Username, @Password,@Salt,@SignupTime);

	
END
GO
USE [master]
GO
ALTER DATABASE [GuessThatPokemon] SET  READ_WRITE 
GO
