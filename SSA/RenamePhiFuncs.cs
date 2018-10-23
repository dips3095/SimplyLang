using System;
using ThreeAddr;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SimpleLang.Optimizations;
using SimpleLang.SSA;

namespace SimpleLang.RenamePhiFuncs
{
    class RenamePhiFuncs
    {
        Dictionary<string,int> counters;
        Dictionary<string,Stack<string>> stacks;
      

        public void initCountersAndStacks(FrontOnDominance Fod)
        {
            foreach(string i in Fod.globals)
            {
                counters.Add(i, 0);
                stacks.Add(i, new Stack<string>());
            }
            

        }
        public string NewName(string n)
        {
            var i = counters[n];
            counters[n] += 1;
            var ni = counters[n].ToString();
            stacks[n].Push(ni);
            return ni;

        }


        public void Rename(int B, ControlFlowGraph CFG, List<int> dommTree)
        {
            foreach (var line in CFG._bblocks[dommTree[B]].Code.ToArray()) // По всем строкам блока узла
            {
                if (line.IsPhiPhunc())
                {
                    line.Accum = NewName(line.Accum);
                }
                else
                {
                    line.LeftOp = stacks[line.LeftOp].Peek();
                    line.RightOp = stacks[line.RightOp].Peek();
                    line.Accum = NewName(line.Accum);
                }
            }

            var succesor_list_cfg = CFG.Next;
            foreach(var bl in succesor_list_cfg[B]) {
            }

            var dom_blocks_cfg = CFG.FindDommBlocks();


            foreach (var line in CFG._bblocks[dommTree[B]].Code.ToArray())
            {
                if (line.IsPhiPhunc())
                {
                    stacks[line.Accum].Pop();
                }
                else
                {
                    stacks[line.Accum].Pop();
                }
            }

        }


        public RenamePhiFuncs(FrontOnDominance Fod, ControlFlowGraph CFG)
        {
            initCountersAndStacks(Fod);
            var dommTree = CFG.CalcDommTree();
            var blocks = CFG._bblocks[dommTree[0]];
            var B = CFG._bblocks[dommTree[0]];
        }

    }
}
