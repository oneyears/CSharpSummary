using System;

namespace CsharpDay04_05_18
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/*
			for(int i = 0 ; i < 100; i++)
				Console.Write("{0} ",i);
			Console.Write ("\n");
			for (int i = 0; i <= 100; i = i + 2)
				Console.Write ("{0} ", i);
			Console.Write ("\n");

			//用double 来定义，100的阶乘 可以把超出的数以科学表示法表示，但是小数点后的精度可能会丢失
			int a = int.Parse (Console.ReadLine ());
			int sum = 1;
			for (int i = 1; i <= a; i++) {
				sum *= i; 
			}
			Console.WriteLine (sum);

			//当 直接定义 字符串 String = s = "abc" 这里sizeof = 4  ，而初始化 char[]  = {1，2,3,4,5} 这里sizeof = 5

			//反转输入 i = 12345  54321 
			// x = i % 10  , sum = 0  sum = sum*10 + x   i = i /10
			*/
			/*//九九乘法表
			for (int i = 1; i < 10; i++) {
				for (int j = 1; j <= i; j++)
					Console.Write ("{0} * {1} = {2}\t", j, i, j * i);
				Console.Write ("\n");
			}
			*/
			//快速遍历方式 foreach 遍历容器时使用
			/*
			 * 1、foreach 遍历过程中不能修改数组中的元素
			 * 2、遍历次数根据数组的长度进行遍历
			 * 
			 */
			/*
			int[] a = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			foreach (int item in a)
				Console.Write ("{0} ",item);
			//如果定义了空间范围，但有些没去赋值，它就默认打印为0
			//所以使用foreach时，需要注意数组中有没有初始化的元素，如果有没初始化的，会出现问题
			string [] arr = new string[]{"sada","123","sdasjdaskc\n","qqq"};
			foreach (string s in arr) {
				if (s!= null) {
					Console.WriteLine (s+":)");
				}
			}
			char [] arr2 = new char[4];
			arr2[3] = 'a';
			arr2[1] = 'b';
			arr2 [2] = 'b';
			foreach(char s in arr2)
					Console.WriteLine (s+":)");//char 类型的默认值为空

			int b = 1;
			while (b < 10) {
				int i = 1;
				printf("%d %d",&i,i);//地址打印一样，说明每次循环定义的内存都是同样的
				i = i+b;
				b++;
			}
			// int i 
			//在while循环定义的 i 在外面不能使用，说明 i 已经释放掉了。
			*/


			//t1 1.使用while输出1-1000所有既能被5整除又能被3整除的数
			/*
			int i = 1000;
			while (i > 0) {
				if (i % 5 == 0 && i % 3 == 0)
					Console.Write ("{0} ", i);
				i--;
			}
			*/

			/*
			//t2 2..输出100-10000之间所有的回文数
			for (int i = 100; i <= 1000; i++) {
				int sum = 0, n = i;
				while (n != 0) {
					int x = n % 10;
					sum = sum*10 + x;
					n /= 10;
				}
				if (i == sum)
					Console.Write ("{0}", i);
			}
			*/
			/*
			//t3 3.输入任意10个数，输出其中最大的数和最小的数
			int max = -999999,min = 999999;
			for (int i = 0; i < 10; i++) {
				int a = int.Parse (Console.ReadLine ());
				if (max < a)
					max = a;
				if (min > a)
					min = a;
			}
			Console.Write ("max = {0}, min = {1} ", max, min);
			*/

			/*
			//t4 3025这个数具有一种独特的性质，将它平分为两段，即30和25，使之相加后求平方，即（30+25）*（30+25），恰好等于3025本身，请求出具有这样性质的全部四位数
			
			int n = 9999;
			while (n >= 1000) {
			
				int R = n % 100;
				int L = n / 100;
				if((L+R) *(L+R) == n)
					Console.Write("{0} ",n);
				n--;
			}
			*/

			/*
			//t5 打印出100~1000所有的水仙花数（如153，每一位上的数字的三次方之和等于153 即水仙花数 1*1*1+5*5*5+3*3*3=153）

			int n = 100;
			while (n <= 1000) {
				int a = n % 10;
				int b = n / 10 % 10;
				int c = n / 100;
				if ((a * a * a) + (b * b * b) + (c * c * c) == n) {
					Console.Write ("{0} ", n);
				}
				n++;
			}
			*/

			/*
			//t6 6.任意输入10个数，用冒泡排序进行排序后输出
			int[] arr = new int[10];
			for (int i = 0; i < arr.Length; i++)
				arr[i] = int.Parse (Console.ReadLine ());
			for (int i = 0; i < 10; i++)
				for (int j = 0; j < 10 - i - 1; j++) {
					if (arr [j] > arr [j + 1]) {
						int t = arr [j + 1];
						arr [j+1] = arr [j];
						arr [j] = t;
					}
				}
			for (int i = 0; i < arr.Length; i++)
				Console.Write ("{0} ", arr [i]);
			*/


			/*
			//t7 输出1900年后至今所有的闰年

			for(int i = 1900; i !=2018;i++) {
				if (i % 4 == 0 && i % 100 != 0 || i % 400 == 0)
					Console.Write ("{0} ", i);
			}
			*/

			/*
			//t8 输入年月日，计算这一天是这一年中的第几天
			int[] month = new int[13]{0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
	
			Console.WriteLine ("请输入年月日：");

			int year = int.Parse (Console.ReadLine ());
			int mth = int.Parse(Console.ReadLine());
			int day = int.Parse(Console.ReadLine());
			int sum = 0;
			if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
				month [2]++;
			
			for (int i = 0; i < mth; i++)
				sum += month [i];
			sum += day;
			Console.Write ("{0} ", sum);
			*/
		}
	}
}
