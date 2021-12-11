using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace abstractcomputer
{
    class NAND
    {
        public int input1; // input wire 1
        public int input2; // input wire 2
        public int output; // output wire

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

    class Wire
    {
        public bool value = false;
        // list index gate berikutnya
        public List<int> endGate = new List<int>();
    }

    static class Board
    {
        public static List<Wire> wires = new List<Wire>();
        public static List<NAND> gates = new List<NAND>();

        // hanya digunakan untuk mencatat tiap update
        private static Queue<int> wireToUpdate = new Queue<int>();

        // native implementation, membuat native gate NAND
        public static int CreateNAND(int wIn1, int wIn2, int wOut1)
        {
            NAND newNAND = new NAND(wIn1, wIn2, wOut1);
            gates.Add(newNAND);
            // index gate yang baru dibuat
            int idx = gates.Count - 1;
            // pasangkan tiap ujung kabel input ke gate NAND ini
            // dan menghindari output ke 2 gate yang sama
            if (!wires[wIn1].endGate.Contains(idx))
                wires[wIn1].endGate.Add(idx);
            if (!wires[wIn2].endGate.Contains(idx))
                wires[wIn2].endGate.Add(idx);

            wires[wOut1].value = newNAND.Calc();
            return idx;
        }

        public static int CreateWire()
        {
            wires.Add(new Wire());
            return wires.Count-1;
        }

        public static void ChangeWireValue(int wire, bool newValue)
        {
            wireToUpdate = new Queue<int>();
            
            // kalau value sama saja, tidak ada yang perlu dilakukan
            if (wires[wire].value != newValue)
            {
                Debug.WriteLine("Changing wire {0} to {1}", wire, newValue);
                wires[wire].value = newValue;
                foreach (int g in wires[wire].endGate)
                {
                    int wireIndex = gates[g].output;
                    Debug.WriteLine(
                        "Wire {0} is connected to gate {1} which has output wire of {2}", 
                        wire, g, wireIndex
                    );
                    bool v = gates[g].Calc();
                    if (wires[wireIndex].value != v)
                    {
                        wires[wireIndex].value = v;
                        Debug.WriteLine(
                            "Value of gate {0} is updated to {1}, affecting output wire {2}", 
                            g, v, wireIndex
                        );
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
                    Wire currentWire = wires[wireToUpdate.Peek()];
                    // cek wire ini terhubung ke gate mana saja, lalu loop tiap gate tsb
                    foreach (int g in currentWire.endGate)
                    {
                        int wireIndex = gates[g].output;
                        Debug.WriteLine(
                            "Wire {0} is connected to gate {1}, which has output wire of {2}",
                            wireToUpdate.Peek(), g, wireIndex
                        );
                        bool v = gates[g].Calc();
                        if (wires[wireIndex].value != v)
                        {
                            wires[wireIndex].value = v;
                            Debug.WriteLine(
                                "Value of gate {0} is updated to {1}, affecting output wire {2}",
                                g, v, wireIndex
                            );
                            if (!wireToUpdate.Contains(wireIndex))
                                wireToUpdate.Enqueue(wireIndex);
                            Debug.WriteLine("Updated wireToUpdate:");
                            foreach (int w in wireToUpdate)
                            {
                                Debug.WriteLine(w);
                            }
                        }
                    }
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
