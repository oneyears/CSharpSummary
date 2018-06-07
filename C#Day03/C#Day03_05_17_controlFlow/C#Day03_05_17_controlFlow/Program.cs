using System;

namespace CDay03_05_17_controlFlow
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//====================================
			/*
			int a = 10;
			double b = 3;
			Console.WriteLine (a / b);//3.33333333333333   //15位有效位数
			//操作数 ，当操作符为取余符号，操作数不能为浮点型

			 a++;
			Console.WriteLine (a++);//输出11  ，输出的是一个表达式
			int c = 5;
			//左移 ==>  * 2   末尾补 0 移x位 就乘 2^(x)倍
			//右移 ==>   / 2 
			*/

			/*
			bool t = true;
			bool f = false;
			Console.WriteLine (t.ToString ());
			Console.WriteLine (Convert.ToInt64(t));// 1
			Console.WriteLine (Convert.ToInt32 (f));// 0

			//闰年判断1、 x  能够整除4但不能 整除100
			// 2、x 能整除400

			//C# 的switch 里， break 不能省略，且后面表达式的值可以是整形，字符的ASCLL码，枚举、字符串
			*/
			/*
			//t1
			int a = int.Parse (Console.ReadLine ());
			int b = int.Parse (Console.ReadLine ());
			Console.WriteLine ("max = {0}\n",(int)a > b ? a : b);
			*/

			/*
			//t2
			int[] arr = new int[5];
			for (int i = 0; i < 5; i++) {
				arr [i] = int.Parse (Console.ReadLine ());
			}
			for (int i = 0; i < 5; i++)
				for (int j = 0; j < 5 - i-1; j++) {
					if (arr [j] > arr [j+1]) {
						int t = arr [j + 1];
						arr [j + 1] = arr [j];
						arr [j] = t;
					}
				}
			for (int i = 0; i < 5; i++)
				Console.Write ("{0} ",arr[i]);
			*/
		}
	}
}
