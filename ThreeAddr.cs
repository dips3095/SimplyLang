﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ThreeAddr
{
    public static class ThreeAddrOpType
    {
        public const string Plus = "+";
        public const string Minus = "-";
        public const string Mul = "*";
        public const string Div = "/";
        public const string Assign = "assign";
        public const string Less = "<";
        public const string Greater = ">";
        public const string LessOrEq = "<=";
        public const string GreaterOrEq = ">=";
        public const string Eq = "==";
        public const string UnEq = "!=";
        public const string Goto = "goto";
        public const string IfGoto = "ifgoto";
        public const string Nop = "nop";
        public const string Not = "not";
        public const string Or = "or";
        public const string And = "and";
        public const string Write = "write";
        public const string Read = "read";

        public static bool IsGoto(String opType)
        {
            return opType == Goto || opType == IfGoto;
        }

        public static List<String> Computable = new List<string>{
            Plus, Minus, Div, Mul, Less, Greater, LessOrEq, GreaterOrEq, Eq, UnEq, Not, Or, And
        };

        public static bool IsDefinition(string opType)
        {
            return opType != Nop && opType != Write && opType != Goto && opType != IfGoto;
        }

    }

    [Serializable]
    public class ThreeAddrLine
    {
        public string Label { get; set; }
        public string Accum { get; set; }
        public string LeftOp { get; set; }
        public string RightOp { get; set; }
        public string OpType { get; set; }
        public List<string> parameters { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(Label) &&
                   string.IsNullOrEmpty(Accum) &&
                   string.IsNullOrEmpty(LeftOp) &&
                   string.IsNullOrEmpty(RightOp) &&
                   string.IsNullOrEmpty(OpType);
        }

        public bool IsVariable(string str)
        {
            if (str != null && (str[0] == 'v')) return true;
            else return false;
        }
        public bool IsNoGoto()
        {
            if (OpType != "ifgoto" && OpType != "goto") return true;
            else return false;
        }

        public override String ToString()
        {
            return $"{Label}: {Accum} = {LeftOp} {OpType} {RightOp}";
        }

        public  virtual bool IsPhiPhunc()
        {
            return false;
        }

    }

    public class PhiFunc : ThreeAddrLine
    {
        public List<string> parameters { get; set; }

        public PhiFunc(string accum, string label)
        {
            Label = label;
            Accum = accum;
            parameters = new List<string>();

            parameters.Add(Accum);

        }



        public  override bool IsPhiPhunc()
        {
            return true;
        }


        public override String ToString()
        {

            string output = $"{Label}: {Accum} = phi(";
            foreach (var param in parameters)
            {
                output += param + ", ";
            }
            output += ")";

            return output;
        }

    }



    public class BaseBlock
    {
        public List<ThreeAddrLine> Code { get; set; }

        public BaseBlock() { Code = new List<ThreeAddrLine>(); }

        public int StartLabel { get { return int.Parse(Code[0].Label); } }
        public int EndLabel { get { return int.Parse(Code[Code.Count - 1].Label); } }

        public ThreeAddrLine LastLine { get { return Code[Code.Count - 1]; } }


        public HashSet<string> phiVar = new HashSet<string>();


        public bool AddPhi(string accum)
        {
            if (!phiVar.Contains(accum))
            {
                phiVar.Add(accum);

                var newCode = new List<ThreeAddrLine>();

                newCode.Add(new PhiFunc(accum, Code[0].Label));

                // Переиндексация
                for (var i = 0; i < Code.Count; i++)
                {
                    var newLine = Code[i];
                    var label = 0;
                    Int32.TryParse(newLine.Label, out label);
                    label++;

                    if (!newLine.IsNoGoto())
                    {
                        string goto_val = newLine.RightOp;
                        int goto_val_int = 0;
                        Int32.TryParse(goto_val, out goto_val_int);

                        newLine.RightOp = (goto_val_int + 1).ToString();
                    }


                    newLine.Label = label.ToString();
                    newCode.Add(newLine);
                }

                Code = newCode;
                return true;
            }
            else
            {
                return false;
            }


        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("BLOCK START");
            foreach (var line in Code)
            {
                if (line.IsEmpty())
                {
                    continue;
                }
                builder.AppendLine(line.ToString());
            }
            builder.AppendLine("BLOCK END");
            return builder.ToString();
        }
    }


    public static class BaseBlockHelper
    {
        public static List<ThreeAddrLine> JoinBaseBlocks(List<BaseBlock> bblocks)
        {
            return bblocks.SelectMany(block => block.Code).ToList();
        }

        public static void FixLabelsNumeration(List<ThreeAddrLine> code)
        {
            int count = 0;
            Dictionary<String, int> convert = new Dictionary<string, int>();
            foreach (var line in code)
            {
                if (line.Label == null)
                {
                    line.Label = (count++).ToString();
                }
                else
                {
                    convert[line.Label] = count++;
                    line.Label = convert[line.Label].ToString();
                }
            }

            foreach (var line in code)
            {
                if (ThreeAddrOpType.IsGoto(line.OpType))
                {
                    line.RightOp = convert[line.RightOp].ToString();
                }
            }

        }

        public static List<BaseBlock> GenBaseBlocks(List<ThreeAddrLine> code)
        {

            var _isNewBlock = new bool[code.Count + 1];
            _isNewBlock.Initialize();
            _isNewBlock[0] = true;
            for (int i = 0; i < code.Count; ++i)
                if (ThreeAddrOpType.IsGoto(code[i].OpType))
                {
                    // replace useless goto on Nop
                    if ((Int32.Parse(code[i].Label) + 1) == Int32.Parse(code[i].RightOp))
                    {
                        code[i].OpType = ThreeAddrOpType.Nop;
                        continue;
                    }

                    _isNewBlock[i + 1] = true;
                    int dst = int.Parse(code[i].RightOp);
                    _isNewBlock[dst] = true;
                }

            var baseBlocks = new List<BaseBlock>();

            for (int i = 0; i < code.Count; ++i)
            {
                if (_isNewBlock[i])
                    baseBlocks.Add(new BaseBlock());
                baseBlocks[baseBlocks.Count - 1].Code.Add(code[i]);



            }

            return baseBlocks;
        }

    }



}