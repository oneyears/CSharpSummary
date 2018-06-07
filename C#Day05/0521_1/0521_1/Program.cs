/*using System;

namespace _1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//函数：把一系列相关代码组织到一起形成一个代码块，用来完成某个功能
			int x = add(5, 9);
			Console.WriteLine(x);
		}

		//函数功能：传入两个数，求两个的和
		//函数的名字：add
		public static int add(int a, int b)
		{
			int sum = a + b;
			return sum;//函数的结果，函数最终要给出一个结果，通过return给结果
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//函数结构：
			//函数由函数头和函数体组成；
			//函数头由 修饰符、返回值类型(函数最终结果的类型)、函数名、参数列表(列表列出参数的个数和类型) 组成

		}
		public static int add(int a, int b) //大括号前是函数头，大括号中是函数体
		{
			int sum = a + b;
			return sum;//返回值，
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int x = fun(5);//将函数的返回值赋值给x
			Console.WriteLine(x);

			Console.WriteLine(fun(6));//将函数的返回值直接输出
			//调用函数求阶乘
			//参数是传入的整数
			//返回值是这个整数的阶乘 (返回值就是函数的结果，就是return后边的值)
			//可以将返回值赋值给某个变量，也可以直接用Console.WriteLine输出
		}

		//函数功能：传入一个正整数，求这个数的阶乘
		//函数名字：fun
		//函数参数列表：(int a)
		//函数返回值类型：int
		public static int fun(int a)
		{
			int s = 1;
			while (a>0)
			{
				s *= a;
				a--;
			}
			return s;
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{

		}

		//函数功能：传入一个整数，求这个数倒过来的数12345->54321
		//函数名字：fun
		//函数参数列表：(int n)
		//函数返回值类型：int
		public static int fun(int n)
		{
			int sum = 0;
			while (n > 0)
			{
				int t = n % 10;
				n /= 10;

				sum = sum * 10 + t;
			}
			return sum;
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//Console.WriteLine(fun(153));
			int i;
			for (i = 100; i < 1000; i++)
			{
				if (fun(i))//如果条件为真就是水仙花数
				{
					Console.WriteLine(i);
				}
			}
		}

		//函数功能：传入一个数，判断这个数是否是水仙花数，返回真和假(bool)
		//函数名字：fun
		//函数参数列表：(int n)
		//函数返回值类型：bool
		public static bool fun(int n)
		{
			if (n < 100 || n > 999)
			{
				return false;//如果不是三位数 直接return false
			}
			//153 1*1*1+5*5*5+3*3*3 == 153
			int m = n;
			int sum = 0;
			while (m > 0)
			{
				int t = m % 10;
				sum += t * t * t;
				m /= 10;
			}
			if (sum == n)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//利用fun函数输出1900年至今所有的闰年
			int i;
			for (i = 1900; i <= 2018; i++)
			{
				if (fun(i))
				{
					Console.WriteLine(i);
				}
			}
		}
		//函数功能：输入年份，判断是否是闰年，返回真和假
		//函数名字：fun
		//函数参数列表：(int n)
		//函数返回值类型：bool
		public static bool fun(int n)
		{
			//if ((n % 4 == 0 && n % 100 != 0) || n % 400 == 0)
			//{
			//	return true;
			//}
			//else
			//{
			//	return false;
			//}
			return (n % 4 == 0 && n % 100 != 0) || n % 400 == 0;
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{

		}
		//函数功能：输入年月日，求这一天是这一年中的第几天
		//函数名字：fun
		//函数参数列表：(int y,int m,int d)
		//函数返回值类型：int
		public static int fun(int y, int m, int d)
		{
			int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
			{
				days[1] = 29;
			}
			int sum = 0;
			int i;
			for (i = 0; i < m - 1; i++)//m=10 前九个月的下标是0~8
			{
				sum += days[i];
			}
			sum += d;
			return sum;
		}
	}
}
*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int x = fun(28);//函数只有存在返回值时才可以放在等号右边或者放在Console.WriteLine中输出
			Console.WriteLine(fun(28));
		}

		//函数功能：传入一个正整数，在函数中输出该数所有的因子
		//函数名字：fun
		//函数参数列表：(int n)
		//函数返回值类型：void    
		//一个函数只能返回一个结果，不能返回多个结果
		//返回值类型为void表示没有返回值
		public static void fun(int n)
		{
			if (n < 0)
			{
				return;//返回值类型虽然是void，在函数中也可以通过return提前结束函数
			}
			int i;
			for (i = 1; i <= n; i++)
			{
				if (n % i == 0)
				{
					Console.WriteLine(i);
				}
			}
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int[] a = { 6, 3, 4, 9, 1, 5, 7, 8, 2, 0 };
			fun(a);
			foreach (int t in a)
			{
				Console.WriteLine(t);
			}
		}
		//函数功能：传入一个数组，对数组进行排序
		//函数名字：fun
		//函数参数列表：(int[] n)
		//函数返回值类型：void

		public static void fun(int[] n)
		{
			int m = n.Length - 1;
			for (int i = 0; i < m; i++)//控制9轮循环
			{
				for (int j = 0; j < m - i; j++)//每一轮循环的循环次数
				{
					if (n[j] < n[j + 1])//如果前边的大于后边的进行交换
					{
						int temp = n[j];
						n[j] = n[j + 1];
						n[j + 1] = temp;
					}
				}
			}
		}
		//冒泡排序
		//6349157820

		//3649157820
		//3469157820
		//3469157820
		//3461957820
		//3461597820
		//3461579820
		//3461578920
		//3461578290
		//3461578209

		//3461578209
		//3461578209
		//3416578209
		//3415678209
		//...

	}
}*/
/*using System;
namespace aa
{
	class MainClasss
	{
		public static void Main()
		{
			int a = 5;
			int b = 10;
			exchange(a, b);//调用函数时，将a和b的值传入函数，将a、b的值分别赋值给m和n
			//a和b是实参(实际传入函数的参数)
			//m和n是形参(用于接收实参的值的参数，实参的值的载体)
			//m和n是在函数执行过程中开辟的两块存储空间，和ab的关系是拷贝的关系
			//将a的值拷贝给m，将b的值拷贝给n
			//在函数中修改m和n，不会影响a和b
			Console.WriteLine("a={0},b={1}", a, b);
		}
		//交换两个变量的值
		public static void exchange(int m, int n)
		{
			Console.WriteLine("交换前：m={0},n={1}", m, n);
			int temp = m;
			m = n;
			n = temp;
			Console.WriteLine("交换后：m={0},n={1}", m, n);
		}

		//程序从Main函数开始执行，当调用函数时，跳转到函数中执行，
		//当函数执行结束或碰到return再回到函数调用的位置继续执行后边的代码
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Console.WriteLine(fun(5));
		}
		//函数的递归调用

		//函数功能：求n的阶乘   5! = 5*4!   4!=4*3!
		public static int fun(int n)
		{
			if (n == 1)
				return 1;
			return n * fun(n - 1);
		}
		//在函数中调用函数本身，称为递归调用自己
		//递归调用时要有终止条件
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Console.WriteLine(fun(7));
		}
		//斐波那契数列：1 1 2 3 5 8 13 21 34 55
		//从第3位开始，每一位上的数字是前边两位数字的和

		//函数功能：输入n，求第n位数字是多少
		//函数名字：fun
		//函数参数列表：(int n)
		//函数返回值类型：int
		public static int fun(int n)
		{
			if (n == 1 || n == 2)
			{
				return 1;
			}
			return fun(n - 1) + fun(n - 2);
		}	//第n个数是第n-1和n-2两个数的和
	}
}
*/
using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			string a;
			Console.WriteLine("输入一个字符串");
			a = Console.ReadLine();
			Console.WriteLine(fun(a));

		}//assf23ABVX24.,/.';lsdf
		 //函数功能：提取字符串中的字母和数字组成新的字符串返回出来
		 //函数名字：fun
		 //函数参数列表：(string n)
		 //函数返回值类型：string

		public static string fun(string n)
		{
			string t = "";//创建一个空字符串
			int x = n.Length;//求字符串长度  [下标]字符串中的字符
			for (int i = 0; i < x; i++)
			{
				if ((n[i] >= 'a' && n[i] <= 'z') || (n[i] >= '0' && n[i] <= '9') || (n[i] >= 'A' && n[i] <= 'Z'))
				{
					t += n[i];//拼接字符串
				}
			}
			return t;
		}
	}
}