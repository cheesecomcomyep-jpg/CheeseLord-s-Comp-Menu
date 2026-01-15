using System;
using Xenon.Mods;
using XENONTEMP.Classes;
using XENONTEMP.Mods;

namespace XENONTEMP.Menu
{
	// Token: 0x0200001F RID: 31
	internal class Buttons
	{
		// Token: 0x040000F0 RID: 240
		public static ButtonInfo[][] buttons = new ButtonInfo[][]
		{
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Movement",
					method = delegate()
					{
						SettingsMods.Movement();
					},
					isTogglable = false,
					toolTip = "Opens the Movement page for the menu."
				},
				new ButtonInfo
				{
					buttonText = "Arms",
					method = delegate()
					{
						SettingsMods.advanteges();
					},
					isTogglable = false,
					toolTip = "Opens the Advantage page for the menu."
				},
				new ButtonInfo
				{
					buttonText = "Visuals",
					method = delegate()
					{
						SettingsMods.Visuals();
					},
					isTogglable = false,
					toolTip = "Opens the Visuals page for the menu."
				},
				new ButtonInfo
				{
					buttonText = "Safety",
					method = delegate()
					{
						SettingsMods.Safety();
					},
					isTogglable = false,
					toolTip = "Opens the Safety page for the menu."
				}
			},
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Right Hand Menu",
					enableMethod = delegate()
					{
						SettingsMods.RightHand();
					},
					disableMethod = delegate()
					{
						SettingsMods.LeftHand();
					},
					toolTip = "Puts the menu on your right hand."
				},
				new ButtonInfo
				{
					buttonText = "Notifications",
					enableMethod = delegate()
					{
						SettingsMods.EnableNotifications();
					},
					disableMethod = delegate()
					{
						SettingsMods.DisableNotifications();
					},
					enabled = !Settings.disableNotifications,
					toolTip = "Toggles the notifications."
				},
				new ButtonInfo
				{
					buttonText = "Animate Name",
					enableMethod = delegate()
					{
						Main.shouldAnimate = true;
					},
					disableMethod = delegate()
					{
						Main.shouldAnimate = false;
					},
					enabled = Main.shouldAnimate,
					toolTip = "Toggles the animated name."
				},
				new ButtonInfo
				{
					buttonText = "Outline Menu",
					enableMethod = delegate()
					{
						SettingsMods.EnableOutline();
					},
					disableMethod = delegate()
					{
						SettingsMods.DisableOutline();
					},
					enabled = true,
					toolTip = "Toggles the outline."
				},
				new ButtonInfo
				{
					buttonText = "Menu Rounding",
					enableMethod = delegate()
					{
						SettingsMods.noround();
					},
					disableMethod = delegate()
					{
						SettingsMods.yesround();
					},
					enabled = true,
					toolTip = "Makes Menu less smooth."
				},
				new ButtonInfo
				{
					buttonText = "FPS Counter",
					enableMethod = delegate()
					{
						SettingsMods.EnableFPSCounter();
					},
					disableMethod = delegate()
					{
						SettingsMods.DisableFPSCounter();
					},
					enabled = Settings.fpsCounter,
					toolTip = "Toggles the FPS counter."
				}
			},
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "gun test",
					method = delegate()
					{
						Global.Gun();
					},
					toolTip = "Opens the Projectile page for the menu."
				}
			},
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Faster Speed Boost",
					method = delegate()
					{
						Movement.FasterSpeedBoost();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Fasterer Speed Boost",
					method = delegate()
					{
						Movement.FastererSpeedBoost();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Fastererer Speed Boost",
					method = delegate()
					{
						Movement.FasterererSpeedBoost();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Slow Speed",
					method = delegate()
					{
						Movement.SlowSpeed();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Even Slower Speed",
					method = delegate()
					{
						Movement.EvenSlowerSpeed();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Change Custom Speed -1",
					method = delegate()
					{
						Movement.ChangeSpeedBoostNegitve();
					},
					isTogglable = false,
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Change Custom Speed +1",
					method = delegate()
					{
						Movement.ChangeSpeedBoostPlus();
					},
					isTogglable = false,
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Custom Speed Boost",
					method = delegate()
					{
						Movement.CustomSpeedBoost();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Mosa Speed Boost",
					method = delegate()
					{
						Movement.MosaSpeed();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "TTT Speed Boost",
					method = delegate()
					{
						Movement.TTTSpeed();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Pull Mod",
					method = delegate()
					{
						Movement.PullMod();
					},
					enabled = false,
					toolTip = "SpeedBoost"
				},
				new ButtonInfo
				{
					buttonText = "Platforms",
					method = delegate()
					{
						Movement.Platform();
					},
					enabled = false,
					toolTip = "Platforms"
				},
				new ButtonInfo
				{
					buttonText = "Wall Walk",
					method = delegate()
					{
						Movement.WallWalk();
					},
					enabled = false,
					toolTip = "WallWalk"
				},
				new ButtonInfo
				{
					buttonText = "No Clip",
					method = delegate()
					{
						Movement.Noclip();
					},
					enabled = false,
					toolTip = "No Clip"
				},
				new ButtonInfo
				{
					buttonText = "Air Strike Gun",
					method = delegate()
					{
						Movement.AirStrikeGun();
					},
					enabled = false,
					toolTip = "Gun"
				},
				new ButtonInfo
				{
					buttonText = "Fast Swim",
					method = delegate()
					{
						Movement.FastSwim();
					},
					enabled = false,
					toolTip = "Fast Swim"
				},
				new ButtonInfo
				{
					buttonText = "High Gravity",
					method = delegate()
					{
						Movement.HighGravity();
					},
					enabled = false,
					toolTip = "Gravity"
				},
				new ButtonInfo
				{
					buttonText = "No Gravity",
					method = delegate()
					{
						Movement.NoGravity();
					},
					enabled = false,
					toolTip = "Gravity"
				},
				new ButtonInfo
				{
					buttonText = "Fix Gravity",
					method = delegate()
					{
						Movement.FixGrav();
					},
					enabled = false,
					toolTip = "Gravity"
				}
			},
			new ButtonInfo[0],
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Background Music",
					method = delegate()
					{
						Main.PlayBackGroundMusic();
					},
					toolTip = "Plays background music for 1-2 mins."
				},
				new ButtonInfo
				{
					buttonText = "Cube ESP",
					method = delegate()
					{
						Visual.CubeESP();
					},
					toolTip = "Makes cubed shapes around all players."
				},
				new ButtonInfo
				{
					buttonText = "Tracer V1",
					method = delegate()
					{
						Visual.Tracers1();
					},
					toolTip = "Makes a line to all players."
				},
				new ButtonInfo
				{
					buttonText = "Tracer V2",
					method = delegate()
					{
						Visual.Tracers2();
					},
					toolTip = "Makes a line to all players."
				},
				new ButtonInfo
				{
					buttonText = "Tracer V3",
					method = delegate()
					{
						Visual.Tracers3();
					},
					toolTip = "Makes a line to all players."
				},
				new ButtonInfo
				{
					buttonText = "Sphere ESP",
					method = delegate()
					{
						Visual.SphereESP();
					},
					toolTip = "Makes a ball around all players."
				}
			},
			new ButtonInfo[0],
			new ButtonInfo[0],
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Name Tag",
					method = delegate()
					{
						Main.CustomNameTag();
					},
					enabled = true,
					toolTip = "Not shown on buttons"
				}
			},
			new ButtonInfo[0],
			new ButtonInfo[0],
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Long Arms",
					method = delegate()
					{
						Arms.LongArms();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Steam Long Arms",
					method = delegate()
					{
						Arms.SteamArms();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Too Long Arms",
					method = delegate()
					{
						Arms.ToLongArms();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Very Very Long Arms",
					method = delegate()
					{
						Arms.VeryVeryLongArms();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Short Arms",
					method = delegate()
					{
						Arms.ShortArms();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "No Arms",
					method = delegate()
					{
						Arms.NoArms();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Change Custom Arms -1",
					method = delegate()
					{
						Arms.CustomArmsNegitive();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Change Custom Arms +1",
					method = delegate()
					{
						Arms.CustomArmsPlus();
					},
					toolTip = "Arms"
				},
				new ButtonInfo
				{
					buttonText = "Custom Arms",
					method = delegate()
					{
						Arms.CustomArms();
					},
					toolTip = "Arms"
				}
			},
			new ButtonInfo[0],
			new ButtonInfo[]
			{
				new ButtonInfo
				{
					buttonText = "Disconnect",
					method = delegate()
					{
						Global.idkthethefuckimdoingthis();
					},
					isTogglable = false,
					toolTip = "Disconnects you from the lobby."
				},
				new ButtonInfo
				{
					buttonText = "Home3",
					method = delegate()
					{
						Global.ReturnHome();
					},
					isTogglable = false,
					toolTip = "HOME."
				}
			}
		};
	}
}
