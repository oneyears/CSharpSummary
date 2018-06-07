using System;

//.Net组成：
//1.FCL 类库
//2.CLR 公共语言运行时
//2_1.CTS 通用类型系统
//2_2.CLS 公共语言规范

namespace _2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!1");//输出一句话
			Console.WriteLine("Hello World!2");
			//Console.WriteLine("Hello World!3");
			Console.WriteLine("Hello World!4");
			Console.WriteLine("Hello World!5");
			Console.WriteLine("Hello World!6");
			Console.WriteLine("Hello World!7");
			Console.WriteLine("Hello World!8");
			//Console.ReadKey();//等待输入任意按键，防止程序自动退出。(windows)
			//1.编译：检查语法结构是否有问题，形成中间代码
			//2.链接：将代码中用到的库中的代码或者其他文件的代码链接到中间代码中，形成可执行文件
			//3.执行：执行第二阶段形成的可执行文件
		}
	}
}

//注释：1.给代码添加解释说明，方便理解代码
//2.屏蔽代码，方便调试，注释掉的代码在编译阶段就被跳过
//注释方式：1.双斜杠 2./* ...... */

//单行注释
/*
  多行注释


 */
