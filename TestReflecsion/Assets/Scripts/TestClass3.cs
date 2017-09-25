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
	/// Description of TestClass3.
	/// </summary>
	public class TestClass3 : MainClass
	{
		private int numberObject;
		public TestClass3()
		{
			this.numberObject = 0;
		}
		
		public TestClass3(int tI){
			this.numberObject = tI;
		}
		
		public override string ToString()
		{
			return string.Format("[TestClass3 NumberObject={0}]", numberObject);
		}

		
		public void Start(){
			Console.WriteLine("Start {0} {1}", this.numberObject, this.ToString());
		}
		
		public void Update(){
			Console.WriteLine("Update {0} {1}", this.numberObject, this.ToString());
		}
	}
}
