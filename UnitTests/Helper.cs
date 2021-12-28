using abstractcomputer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace UnitTests
{
	public static class Helper
	{
		// return the integer representation of 16 wire
		public static int GetIntRepresentation(int[] w)
		{
			int result = 0;
			int multiplier = 1;
			for (int i = 0; i < w.Length; i++)
			{
				if (Board.wVal[w[i]]) result += multiplier;
				multiplier *= 2;
			}
			return result;
		}

		// return 16 boolean representation of an int
		public static bool[] GetBoolRepresentation(int n, int index = 16)
		{
			bool[] result = new bool[index];
			int multiplier = 1;
			for (int i = 0; i < index; i++)
			{
				result[i] = (multiplier & n) == multiplier;
				multiplier *= 2;
			}
			return result;
		}

		public static void ChangeWireValues(int[] wires, int n)
		{
			bool[] bValues = GetBoolRepresentation(n, wires.Length);
			for (int i = 0; i < wires.Length; i++)
			{
				Board.ChangeWireValue(wires[i], bValues[i]);
			}
		}

		public static int[] CreateWires(int size)
		{
			int[] result = new int[size];
			for (int i = 0; i < size; i++)
			{
				result[i] = Board.CreateWire();
			}
			return result;
		}
	}
}
