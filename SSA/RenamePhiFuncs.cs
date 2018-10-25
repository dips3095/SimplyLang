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
        List<int> Idom;
        Dictionary<int, List<int>> succesor_list_cfg;
        Dictionary<int, List<int>> succesor_list_dom;
        ControlFlowGraph CFG_ins;
        List<HashSet<int>> Dom;

        public void initCountersAndStacks(FrontOnDominance Fod, ControlFlowGraph CFG)
        {
            foreach(string i in Fod.globals)
            {
                counters.Add(i, 0);
                stacks.Add(i, new Stack<string>());
            }
            CFG_ins = CFG;
            Idom = CFG.CalcDommTree();
            succesor_list_cfg = CFG.Next;
            Dom = CFG_ins.FindDommBlocks();
            int countNodes = CFG.getCountNodes();
            var nodes = Enumerable.Range(0, countNodes);
            foreach (var n in nodes)
            {
                var tmp_list = new List<int>();
                for (int boxIndex = 0; boxIndex < CFG.getCountNodes(); boxIndex++)
                {

                    if (boxIndex == n) { continue; }
                    if (Idom[boxIndex] == n) { tmp_list.Add(boxIndex); }
                }
                succesor_list_dom.Add(n, tmp_list);
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


        public void Rename(int B)
        {

            foreach (var line in CFG_ins._bblocks[B].Code) // По всем строкам блока узла
            {
                if (line.IsPhiPhunc())
                {
                    line.Accum = NewName(line.Accum);
                }
                else if(line.IsNoGoto())
                {
                    line.LeftOp = stacks[line.LeftOp].Peek();
                    line.RightOp = stacks[line.RightOp].Peek();
                    line.Accum = NewName(line.Accum);
                }
            }


            
            foreach(var bl in succesor_list_cfg[B]) {
                var tmp_block = CFG_ins._bblocks[bl].Code;
                    /*уточнить*/
            }

            foreach (var bl in succesor_list_dom[B])
            {
                Rename(B + 1);
            }





            foreach (var line in CFG_ins._bblocks[B].Code)
            {
                if (line.IsPhiPhunc())
                {
                    stacks[line.Accum].Pop();
                }
                else if (line.IsNoGoto())
                {
                    stacks[line.Accum].Pop();
                }
            }

        }


        public RenamePhiFuncs(FrontOnDominance Fod, ControlFlowGraph CFG)
        {
            initCountersAndStacks(Fod, CFG);
            /*var blocks = CFG._bblocks[Idom[0]];*/
            var B = Idom[0];
            Rename(B);
        }

    }
}
