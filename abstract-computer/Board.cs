using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace abstractcomputer
{
	// the "motherboard"
	public static class Board
	{
		private static bool debug = false; // change this to toggle the debug mode

		// change this value to configure the maximum number of 
		// gates and wires that can be contained
		private static readonly int numMaxWires = 100000000;
		private static readonly int numMaxGates = 100000000;

		// a board consists of wires and gates
		public static int currentIdxWires = -1;
		public static BitArray wVal = new BitArray(numMaxWires);
		public static List<int>[] wEndGates = new List<int>[numMaxWires];

		public static int currentIdxGates = -1;
		public static int[] gInputWire1 = new int[numMaxGates];
		public static int[] gInputWire2 = new int[numMaxGates];
		public static int[] gOutputWire = new int[numMaxGates];

		// only used to update the wires value sequentially
		private static Queue<int> wireToUpdate = new Queue<int>();

		// native implementation to create a NAND gate
		// with the specified input wires and output wire
		// the return value is the index of gate
		public static int CreateNAND(int wIn1, int wIn2, int wOut)
		{
			// index of the currently added gates
			int gIdx = ++currentIdxGates;

			gInputWire1[gIdx] = wIn1;
			gInputWire2[gIdx] = wIn2;
			gOutputWire[gIdx] = wOut;

			wEndGates[wIn1].Add(gIdx);
			wEndGates[wIn2].Add(gIdx);

			// update wire value
			ChangeWireValue(wOut, !(wVal[wIn1] && wVal[wIn2]));
			
			return gIdx;
		}

		// create a new wire, return the index of the currently added wire
		public static int CreateWire()
		{
			int wIdx = ++currentIdxWires;
			wVal[wIdx] = false;
			wEndGates[wIdx] = new List<int>();
			return wIdx;
		}

		public static int[] CreateWires(int size)
		{
			int[] result = new int[size];
			for(int i = 0; i < size; i++)
			{
				result[i] = CreateWire();
			}
			return result;
		}

		// to change the wire value
		// based on the wire index, and the new value
		// also propagates the changes to other wires if connected
		public static void ChangeWireValue(int wire, bool newValue)
		{
			// if the value isn't changed then nothing to do
			if (wVal[wire] != newValue)
			{
				// first, get all the impacted gates by this wire
				// then update every output wire of those gates
				wVal[wire] = newValue;

				// lookup the end gates connected to this wire
				CheckChangedGates(wire);
				
				while (wireToUpdate.Count > 0)
				{
					CheckChangedGates(wireToUpdate.Dequeue());
				}
			}
		}

		// check which gates this wire is connected to,
		// then update the value
		private static void CheckChangedGates(int wIdx)
		{
			foreach (int gIdx in wEndGates[wIdx])
			{
				int wOut = gOutputWire[gIdx];

				// calculate the new value
				bool v = !(wVal[gInputWire1[gIdx]] && wVal[gInputWire2[gIdx]]);

				// if the value is just the same, skip
				if (wVal[wOut] != v)
				{
					// update the value
					wVal[wOut] = v;

					// add the wire index to the queue end
					wireToUpdate.Enqueue(wOut);
				}
			}
		}

		public static void Reset()
		{
			debug = false;

			wVal.SetAll(false);
			Array.Clear(wEndGates, 0, wEndGates.Length);
			currentIdxWires = -1;

			Array.Clear(gInputWire1, 0, gInputWire1.Length);
			Array.Clear(gInputWire2, 0, gInputWire2.Length);
			Array.Clear(gOutputWire, 0, gOutputWire.Length);
			currentIdxGates = -1;

			wireToUpdate.Clear();
		}

	}
}
