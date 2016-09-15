using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace RegexSearch
{
	class Program
	{
		static void Main(string[] args)
		{

			if( args.Count() < 2 )
			{
				Console.WriteLine("Incorrect parameters! Par1 = file, Par2 = expression" );
				return;
			}
			string file = args[0];
			string expression = args[1];

			TextReader inFile = new StreamReader(file,Encoding.UTF7);

			string line;

			while( (line = inFile.ReadLine() ) != null )
			{
				DumpLine(expression, line);
			}

			inFile.Close();
		}


		private static void DumpLine( string expression, string inputString)
		{
			Match m;

			m = Regex.Match(inputString, expression, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			if (m.Success)
			{
				while (m.Success)
				{
					Console.Write(m.Groups[0] + ";");
					m = m.NextMatch();
				}
				Console.WriteLine("");
			}
		}

	}
}
