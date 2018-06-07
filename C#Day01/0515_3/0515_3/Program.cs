using System;

namespace _3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//变量的作用：保存数值
			//数值都是有类型的，int表示整数
			//创建了一个int类型的变量a
			int a = 5;//int 表示数据类型 int代表整数
					  //a 通过变量名来访问这个数值，a就是变量名
					  //= 通过赋值符号将5保存进a变量中
					  //访问数值时直接通过变量名来访问

			Console.WriteLine(a);//访问变量中保存的数值

			//1字节=8位二进制数据 
			//一个整数占4个字节空间
			//00000000 00000000 00000000 00000101
			//11111111 11111111 11111111 11111111 不考虑符号2^32-1
			//考虑符号：-2^31 ~ +2^31-1

			float b = 1000.123f;//创建一个浮点类型的变量，保存浮点数5.5f
								//float 4字节
								//所有的浮点数值都不是绝对精确的
			double c = 5.5d;
			//double双精度浮点型，float单精度浮点型
			//double 8字节
			//double可以保存一个整型保存不下的天文数字
			//f表示数值是float类型的，d表示数值是double类型的，不写默认是double


			//signed 表示有符号的
			//unsigned 表示无符号的
			//int uint  byte sbyte

			char d = 'a';//创建一个char类型的变量，保存字符值，由单引号引
			//起来的单个字母或符号就是字符
		}
	}
}
