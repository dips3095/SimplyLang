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


        public void Rename(BaseBlock B)
        {
            foreach (var line in B.Code.ToArray()) // По всем строкам блока узла
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
        }


        public RenamePhiFuncs(FrontOnDominance Fod, ControlFlowGraph CFG)
        {
            initCountersAndStacks(Fod);
            var dommTree = CFG.CalcDommTree();
            var B = CFG._bblocks[dommTree[0]];
        }

    }
}
