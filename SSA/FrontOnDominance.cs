using System;
using ThreeAddr;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SimpleLang.Optimizations;

namespace SimpleLang.SSA
{
    class FrontOnDominance
    {

        public List<HashSet<int>> DFs = new List<HashSet<int>>();
        HashSet<string> globals = new HashSet<string>();


        public void phiAccommodation(ControlFlowGraph CFG, HashSet<string> globals)
        {

            for (int boxIndex = 0; boxIndex < CFG.getCountNodes(); boxIndex++) // По все узлам графа
            {
                var B = CFG._bblocks[boxIndex];
                foreach (var line in B.Code.ToArray()) // По всем строкам блока узла
                {
                    var variable = line.Accum;
                    if (!globals.Contains(variable) || variable == null) { continue; }

                    foreach (var DF in DFs[boxIndex]) // По фронту доминирования блока узла 
                    {
                        if (CFG._bblocks[DF].AddPhi(variable)) {
                            // Изменяем индексирование всех последующих блоков, и ранних GOTO
                            CFG.incrBblocksFor(DF);
                        }






                    }
                }
            }
        }

        public void calcGlobals(ControlFlowGraph CFG)
        {
            var joindCode = CFG.getJoinCode();

            // Variables
            List<string> variables = new List<string>();
            foreach(var line in joindCode)
            {
                if (line.OpType != "ifgoto" && line.OpType != "goto")
                {
                    variables.Add(line.Accum);
                }
               
            }

            foreach (var x in variables)
            {
                for (int boxIndex = 0; boxIndex < CFG.getCountNodes(); boxIndex++)
                {
                    var B = CFG._bblocks[boxIndex];
                    var defB = new HashSet<string>();

                    foreach (var i in B.Code) // i - instruction
                    {
                        if (i.IsNoGoto()) {

                            var y = i.LeftOp;
                            var z = i.RightOp;

                            if (i.IsVariable(y))
                            {
                                if (!defB.Contains(y)) globals.Add(y);
                            }

                            if (i.IsVariable(z))
                            {
                                if (!defB.Contains(z)) globals.Add(z);
                            }

                            defB.Add(x);

                        }
                    }

                }

            }
        }

        public void calcDFs(ControlFlowGraph CFG)
        {
            int countNodes = CFG.getCountNodes();
            var nodes = Enumerable.Range(0, countNodes);
            var dommTree = CFG.CalcDommTree();
            var lineToIdBlock = CFG.getLineToIdBlock();

            foreach (var n in nodes)
            {
                DFs.Add(new HashSet<int>());
            }

            foreach (var n in nodes)
            {
                var preds = CFG.Prev.Values.ElementAt(n);

                if (preds.Count > 1)
                {
                    foreach (var p in preds)
                    {
                        var r = lineToIdBlock[p];

                        while (r != dommTree[n])
                        {

                            DFs[r].Add(n);
                            r = dommTree[r];
                        }

                    }
                }
            }
        }


        public FrontOnDominance(ControlFlowGraph CFG)
        {
            calcDFs(CFG);
            calcGlobals(CFG);
            phiAccommodation(CFG, globals);
        }


        public string globalsToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("Globals");
            foreach (var g in globals)
            {
                builder.AppendLine(g);
            }
            builder.AppendLine();
            return builder.ToString();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("DF");

            var i = 0;
            foreach (var DF in DFs)
            {
                builder.Append(i++);
                builder.Append(": ");
                foreach (var front in DF)
                {
                    builder.Append(front);
                    builder.Append(' ');
                }
                builder.AppendLine();


            }

            builder.AppendLine();
            return builder.ToString();
        }

    }
}
