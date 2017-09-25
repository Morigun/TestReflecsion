/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 01/27/2017
 * Время: 11:49
 */
using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using TestReflecsion.Assets.Scripts;

namespace TestReflecsion
{	
	class Program
	{
		public static string[] ClassNames;
		public const string BaseClassName = "MainClass";
		public const string StartFunctionName = "Start";
		public const string UpdateFunctionName = "Update";
		public const string StopThreadString = "STOP";
		public const string IntType = "System.Int32";
		
		private static List<Object> poolObjects;
		
		public delegate void MethodContainerOnStartGenerate();
		public static event MethodContainerOnStartGenerate onStartGenerate;
		public delegate void MethodContainerOnUpdateGenerate();
		public static event MethodContainerOnUpdateGenerate onUpdateGenerate;
		
		public static void Main(string[] args)
		{
			IntPtr ptr = WinAPI.FindWindow(null, "CORE");
			Console.WriteLine(ptr.ToString());
			if(ptr.ToInt32() != 0){
				IntPtr chld = WinAPI.GetWindow(ptr, WinAPI.GetWindowType.GW_CHILD);
				StringBuilder title = new StringBuilder();
				WinAPI.SendMessage(chld, Convert.ToInt32(WinAPI.GetWindowType.WM_GETTEXT), (IntPtr)20,title);
				Console.WriteLine(chld.ToString() + " " + title.ToString());
			}
			setObjectName();
			Console.WriteLine(ReflectionMethods.getAssembltInfo(Type.GetType(ClassNames[0])).ToString());
			Console.WriteLine(ReflectionMethods.getConstructorInfo(Type.GetType(ClassNames[0])));
			poolObjects = new List<object>();
			Thread th = new Thread(Update);
			CreateMoreObjects(ClassNames[0], (new[] {Type.GetType(IntType)}));
			for(int i = 0; i < poolObjects.First().GetType().GetMethods().Length; i++){
				Console.WriteLine(poolObjects.First().GetType().GetMethods()[i].ToString());
			}
			if(poolObjects.First().GetType().BaseType.Name == BaseClassName){
				/*onStartGenerate();
				th.Start();*/
			}
			if(Console.ReadLine().ToUpper() == StopThreadString){
				th.Abort();
			}
			if(Console.ReadLine().ToUpper() == UpdateFunctionName.ToUpper()){
				onUpdateGenerate();
			}
			Console.Read();	
		}
		
		private static void Update(){
			int cnt = 0;
			while(true){
				try{
					double tmp = (GetDeltaTime()/1000);
					if(tmp > 0){
						onUpdateGenerate();
						Console.WriteLine(tmp.ToString() + " " + cnt++);
					}
				}catch(ThreadInterruptedException ex){
					Console.WriteLine(ex.Message);
					break;
				}catch(ThreadAbortException ex){
					Console.WriteLine(ex.Message);
					break;
				}				
			}
		}
		
		private static void CreateMoreObjects(string ObjectClassName, Type[] types){
			int numName = 0;
			for(int i = 0; i < 100; i++){
				CreateObject(ClassNames[numName], types, i);
				numName++;
				if(numName > 3)
					numName = 0;
			}
		}
		
		/// <summary>
		/// Функция создает объект объект и добавляет его в пул объектов
		/// </summary>
		/// <param name="ObjectClassName">Полное имя класса объекта</param>
		/// <param name="types">Тип принимаемых параметров в конструкторе</param>
		private static void CreateObject(string ObjectClassName, Type[] types, int val){
			Type t = Type.GetType(ObjectClassName, false, true);
			ConstructorInfo ct = t.GetConstructor(types);
			Object obj = ct.Invoke(new Object[]{val});
			if(obj.GetType().GetMethod(StartFunctionName) != null)
				onStartGenerate += () => obj.GetType().GetMethod(StartFunctionName).Invoke(obj,new Object[]{});
			if(obj.GetType().GetMethod(UpdateFunctionName) != null)
				onUpdateGenerate += () => obj.GetType().GetMethod(UpdateFunctionName).Invoke(obj,new Object[]{});
			poolObjects.Add(obj);
		}
		
		private static void setObjectName(){
			ClassNames = new string[5];
			ClassNames[0] = "TestReflecsion.Assets.Scripts.TestClass";
			ClassNames[1] = "TestReflecsion.Assets.Scripts.TestClass2";
			ClassNames[2] = "TestReflecsion.Assets.Scripts.TestClass3";
			ClassNames[3] = "TestReflecsion.Assets.Scripts.TestClass4";
		}
		
		static long lastTime = 0;
		static double GetDeltaTime(){
			long now = DateTime.Now.Ticks;
			double dt = (now - lastTime);
			lastTime = now;
			return dt;
		}
	}
}