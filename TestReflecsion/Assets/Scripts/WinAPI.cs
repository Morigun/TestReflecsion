/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 01/30/2017
 * Время: 15:40
 */
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TestReflecsion.Assets.Scripts
{
	/// <summary>
	/// Description of WinAPI.
	/// </summary>
	public static class WinAPI
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowType uCmd);
		
		[DllImport("user32.dll", CharSet= CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, [Out] StringBuilder IParam);
		
		public enum GetWindowType : uint{
			GW_HWNDFIRST = 0,
			GW_HWNDLAST = 1,
			GW_HWNDNEXT = 2, 
			GW_HWNDPREV = 3,
			GW_OWNER = 4,
			GW_CHILD = 5,
			GW_ENABLEDPOPUP = 6,
			WM_GETTEXT = 0x000D
		}
	}
}
