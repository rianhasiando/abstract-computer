using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace abstractcomputer
{
    // NAND is the "main" logic gate
    // the implementation is straight (doesn't depend on other gates)
    public class NAND
    {
        // input wire 1
        public int input1;

        // input wire 2
        public int input2;

        // output wire
        public int output;

        // Calc() calculates the output value
        // based on CURRENT value on input wires
        // and doesn't store it in output wire
        public bool Calc()
        {
            return !(Board.wires[input1].value && Board.wires[input2].value);
        }

        public NAND(int i1, int i2, int o1)
        {
            input1 = i1;
            input2 = i2;
            output = o1;
        }
    }

    // the wire abstraction
    public class Wire
    {
        // the default value is false
        // (no electricity)
        public bool value = false;

        // every wire can be connected to many gates
        // so the index of gates need to be remembered
        public List<int> endGate = new List<int>();
    }

    // the "motherboard"
    public static class Board
    {
        // a board consists of wires and gates
        public static List<Wire> wires = new List<Wire>();
        public static List<NAND> gates = new List<NAND>();

        // only used to cascade-update the wires value
        private static Queue<int> wireToUpdate = new Queue<int>();

        // native implementation to create a NAND gate
        // with the specified input wires and output wire
        // the return value is the index of gate
        public static int CreateNAND(int wIn1, int wIn2, int wOut)
        {
            NAND newNAND = new NAND(wIn1, wIn2, wOut);
            gates.Add(newNAND);

            // index of the currently added gates (through gates.Add())
            // is just the list size - 1
            int idx = gates.Count - 1;

            // add the gate index into the input wires
            // check if the gate index is already present
            if (!wires[wIn1].endGate.Contains(idx))
                wires[wIn1].endGate.Add(idx);
            if (!wires[wIn2].endGate.Contains(idx))
                wires[wIn2].endGate.Add(idx);

            // calculate for the first time
            wires[wOut].value = newNAND.Calc();
            return idx;
        }

        // create a new wire, return the index of the currently added wire
        public static int CreateWire()
        {
            wires.Add(new Wire());
            return wires.Count-1;
        }

        // to change the wire value, 
        // based on the wire index, and the new value
        public static void ChangeWireValue(int wire, bool newValue)
        {
            wireToUpdate = new Queue<int>();
            
            // if the value isn't changed then nothing to do
            if (wires[wire].value != newValue)
            {
                // first, get all the impacted gates by this wire
                // then update every output wire of those gates

                Debug.WriteLine("Changing wire {0} to {1}", wire, newValue);
                wires[wire].value = newValue;

                // lookup the end gates connected to this wire
                foreach (int g in wires[wire].endGate)
                {
                    int wireIndex = gates[g].output;

                    Debug.WriteLine(
                        "Wire {0} is connected to gate {1} which has output wire of {2}", 
                        wire, g, wireIndex
                    );

                    // calculate the new value
                    bool v = gates[g].Calc();

                    // if the value is just the same, skip
                    if (wires[wireIndex].value != v)
                    {
                        // update the value
                        wires[wireIndex].value = v;
                        Debug.WriteLine(
                            "Value of gate {0} is updated to {1}, affecting output wire {2}", 
                            g, v, wireIndex
                        );

                        // add the wire index to the queue
                        if (!wireToUpdate.Contains(wireIndex))
                            wireToUpdate.Enqueue(wireIndex);

                        Debug.WriteLine("Updated wireToUpdate:");
                        foreach (int w in wireToUpdate)
                        {
                            Debug.WriteLine(w);
                        }
                    }
                }
                
                while (wireToUpdate.Count > 0)
                {
                    Debug.WriteLine(
                        "Looping wire {0}",
                        wireToUpdate.Peek()
                    );
                    // the left most wire
                    Wire currentWire = wires[wireToUpdate.Peek()];

                    // check which gates this wire is connected to,
                    // then update the value
                    foreach (int g in currentWire.endGate)
                    {
                        int wireIndex = gates[g].output;

                        Debug.WriteLine(
                            "Wire {0} is connected to gate {1}, which has output wire of {2}",
                            wireToUpdate.Peek(), g, wireIndex
                        );

                        bool v = gates[g].Calc();

                        // skip if the value doesn't change
                        if (wires[wireIndex].value != v)
                        {
                            wires[wireIndex].value = v;
                            Debug.WriteLine(
                                "Value of gate {0} is updated to {1}, affecting output wire {2}",
                                g, v, wireIndex
                            );

                            // add to the queue to be updated
                            if (!wireToUpdate.Contains(wireIndex))
                                wireToUpdate.Enqueue(wireIndex);

                            Debug.WriteLine("Updated wireToUpdate:");
                            foreach (int w in wireToUpdate)
                            {
                                Debug.WriteLine(w);
                            }
                        }
                    }
                    // remove this wire from queue
                    wireToUpdate.Dequeue();
                    Debug.WriteLine("Updated wireToUpdate:");
                    foreach (int w in wireToUpdate)
                    {
                        Debug.WriteLine(w);
                    }
                }
            }
            Debug.WriteLine("-------------");
        }

    }

}
