/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 01/30/2017
 * Время: 11:14
 */
using System;

namespace TestReflecsion.Assets.Scripts
{
	/// <summary>
	/// Description of TestClass4.
	/// </summary>
	public class TestClass4 : MainClass
	{
		private int numberObject;
		public TestClass4()
		{
			this.numberObject = 0;
		}
		
		public TestClass4(int tI){
			this.numberObject = tI;
		}
		
		public override string ToString()
		{
			return string.Format("[TestClass4 NumberObject={0}]", numberObject);
		}

		
		public void Start(){
			Console.WriteLine("Start {0} {1}", this.numberObject, this.ToString());
		}
		
		/*public void Update(){
			Console.WriteLine("Update {0} {1}", this.numberObject, this.ToString());
		}*/
	}
}
