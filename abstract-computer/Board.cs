using System;
using System.Collections.Generic;
using System.Collections;

namespace abstractcomputer
{
    // the "motherboard"
    public static class Board
    {
		// a board consists of wires and gates
		public static int currentIdxWires = -1;
        public static BitArray wVal = new BitArray(100000000);
		public static List<int>[] wEndGates = new List<int>[100000000];

		public static int currentIdxGates = -1;
		public static int[] gInputWire1 = new int[100000000];
		public static int[] gInputWire2 = new int[100000000];
		public static int[] gOutputWire = new int[100000000];

        // only used to cascade-update the wires value
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

            // add the gate index into the input wires
            // check if the gate index is already present
            if (!wEndGates[wIn1].Contains(gIdx))
				wEndGates[wIn1].Add(gIdx);
			if (!wEndGates[wIn2].Contains(gIdx))
				wEndGates[wIn2].Add(gIdx);

			// calculate for the first time
			wVal[wOut] = !(wVal[wIn1] && wVal[wIn2]);
            return gIdx;
        }

        // create a new wire, return the index of the currently added wire
        public static int CreateWire()
        {
			int wIdx = ++currentIdxWires;
			wEndGates[wIdx] = new List<int>();
			return wIdx;
        }

        // to change the wire value, 
        // based on the wire index, and the new value
        public static void ChangeWireValue(int wire, bool newValue)
        {

			// if the value isn't changed then nothing to do
			if (wVal[wire] != newValue)
            {
                // first, get all the impacted gates by this wire
                // then update every output wire of those gates
                wVal[wire] = newValue;

                // lookup the end gates connected to this wire
                foreach (int gIdx in wEndGates[wire])
                {
                    int wOut = gOutputWire[gIdx];

                    // calculate the new value
                    bool v = !(wVal[gInputWire1[gIdx]] && wVal[gInputWire2[gIdx]]);

                    // if the value is just the same, skip
                    if (wVal[wOut] != v)
                    {
						// update the value
						wVal[wOut] = v;

                        // add the wire index to the queue
                        if (!wireToUpdate.Contains(wOut))
                            wireToUpdate.Enqueue(wOut);
                    }
                }
                
                while (wireToUpdate.Count > 0)
                {
                    // the left most wire
                    int currentWire = wireToUpdate.Peek();

                    // check which gates this wire is connected to,
                    // then update the value
                    foreach (int gIdx in wEndGates[currentWire])
                    {
						int wOut = gOutputWire[gIdx];

						// calculate the new value
						bool v = !(wVal[gInputWire1[gIdx]] && wVal[gInputWire2[gIdx]]);

						// if the value is just the same, skip
						if (wVal[wOut] != v)
						{
							// update the value
							wVal[wOut] = v;

							// add the wire index to the queue
							if (!wireToUpdate.Contains(wOut))
								wireToUpdate.Enqueue(wOut);
						}
					}
                    // remove this wire from queue
                    wireToUpdate.Dequeue();
                }
            }
        }

		public static void Reset()
		{
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
