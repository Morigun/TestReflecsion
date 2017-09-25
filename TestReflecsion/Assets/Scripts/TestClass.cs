/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 01/27/2017
 * Время: 11:51
 */
using System;

namespace TestReflecsion.Assets.Scripts
{
	/// <summary>
	/// Description of TestClass.
	/// </summary>
	public class TestClass : MainClass
	{
		private int numberObject;
		public TestClass()
		{
			this.numberObject = 0;
		}
		
		public TestClass(int tI){
			this.numberObject = tI;
		}
		
		public override string ToString()
		{
			return string.Format("[TestClass NumberObject={0}]", numberObject);
		}

		
		/*public void Start(){
			Console.WriteLine("Start {0} {1}", this.numberObject, this.ToString());
		}*/
		
		public void Update(){
			Console.WriteLine("Update {0} {1}", this.numberObject, this.ToString());
		}
	}
}
