// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  DS-PC
// DateTime: 07.03.2018 19:04:55
// UserName: ???????
// Input file <SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using ProgramTree;

namespace SimpleParser
{
public enum Tokens {error=63,EOF=64,BEGIN=65,END=66,
    CYCLE=67,ASSIGN=68,SEMICOLON=69,EQUALS=70,IF=71,ELSE=72,
    AND=73,OR=74,NOT=75,LE=76,GE=77,UNEQUALS=78,
    PRINT=79,FOR=80,IN=81,READ=82,INUM=83,RNUM=84,
    ID=85};

public struct ValueType
{ 
		  public int intT;
		  public double doubleT;
		  public string stringT;
		  public StatementNode StatementN;
          public AssignNode AssignN;
          public CycleNode CycleN;
          public ExprNode ExprN;
          public IdNode IdN;
          public BinaryOpNode BinaryOpN;
          public BlockNode BlockN; 
          public WriteNode WriteN;
          public ReadNode ReadN;
          public IntNumNode IntNumN;
          public IfNode IfN;
          public ForCycleNode ForN;

       }
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from SimpleYacc.y
    public BlockNode root; // �?о�?невой �?зел син�?акси�?еского де�?ева 
    public Parser(AbstractScanner<ValueType, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[45];
  private static State[] states = new State[84];
  private static string[] nonTerms = new string[] {
      "ariphm", "ident", "mult", "term", "expr", "boolexpr", "assign", "statement", 
      "cycle", "empty", "if", "write", "forcycle", "reads", "stlist", "block", 
      "progr", "$accept", };

  static Parser() {
    states[0] = new State(new int[]{65,4},new int[]{-17,1,-16,3});
    states[1] = new State(new int[]{64,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{65,4,85,23,67,55,71,59,79,65,82,68,80,72,66,-16,69,-16},new int[]{-15,5,-8,83,-16,9,-7,10,-2,11,-9,54,-11,58,-12,64,-14,67,-10,70,-13,71});
    states[5] = new State(new int[]{66,6,69,7});
    states[6] = new State(-42);
    states[7] = new State(new int[]{65,4,85,23,67,55,71,59,79,65,82,68,80,72,66,-16,69,-16},new int[]{-8,8,-16,9,-7,10,-2,11,-9,54,-11,58,-12,64,-14,67,-10,70,-13,71});
    states[8] = new State(-4);
    states[9] = new State(-5);
    states[10] = new State(-6);
    states[11] = new State(new int[]{68,12});
    states[12] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,13,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[13] = new State(new int[]{74,14,73,28,66,-18,69,-18,72,-18});
    states[14] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-6,15,-1,50,-3,37,-4,36,-2,22});
    states[15] = new State(new int[]{60,16,62,30,70,42,78,44,77,46,76,48,74,-21,73,-21,66,-21,69,-21,72,-21,41,-21,65,-21,85,-21,67,-21,71,-21,79,-21,82,-21,80,-21,44,-21});
    states[16] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-1,17,-3,37,-4,36,-2,22});
    states[17] = new State(new int[]{43,18,45,32,60,-25,62,-25,70,-25,78,-25,77,-25,76,-25,74,-25,73,-25,66,-25,69,-25,72,-25,41,-25,65,-25,85,-25,67,-25,71,-25,79,-25,82,-25,80,-25,44,-25});
    states[18] = new State(new int[]{85,23,83,24,40,25},new int[]{-3,19,-4,36,-2,22});
    states[19] = new State(new int[]{42,20,47,34,43,-34,45,-34,60,-34,62,-34,70,-34,78,-34,77,-34,76,-34,74,-34,73,-34,66,-34,69,-34,72,-34,41,-34,65,-34,85,-34,67,-34,71,-34,79,-34,82,-34,80,-34,44,-34});
    states[20] = new State(new int[]{85,23,83,24,40,25},new int[]{-4,21,-2,22});
    states[21] = new State(-37);
    states[22] = new State(-39);
    states[23] = new State(-17);
    states[24] = new State(-40);
    states[25] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,26,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[26] = new State(new int[]{41,27,74,14,73,28});
    states[27] = new State(-41);
    states[28] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-6,29,-1,50,-3,37,-4,36,-2,22});
    states[29] = new State(new int[]{60,16,62,30,70,42,78,44,77,46,76,48,74,-22,73,-22,66,-22,69,-22,72,-22,41,-22,65,-22,85,-22,67,-22,71,-22,79,-22,82,-22,80,-22,44,-22});
    states[30] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-1,31,-3,37,-4,36,-2,22});
    states[31] = new State(new int[]{43,18,45,32,60,-26,62,-26,70,-26,78,-26,77,-26,76,-26,74,-26,73,-26,66,-26,69,-26,72,-26,41,-26,65,-26,85,-26,67,-26,71,-26,79,-26,82,-26,80,-26,44,-26});
    states[32] = new State(new int[]{85,23,83,24,40,25},new int[]{-3,33,-4,36,-2,22});
    states[33] = new State(new int[]{42,20,47,34,43,-35,45,-35,60,-35,62,-35,70,-35,78,-35,77,-35,76,-35,74,-35,73,-35,66,-35,69,-35,72,-35,41,-35,65,-35,85,-35,67,-35,71,-35,79,-35,82,-35,80,-35,44,-35});
    states[34] = new State(new int[]{85,23,83,24,40,25},new int[]{-4,35,-2,22});
    states[35] = new State(-38);
    states[36] = new State(-36);
    states[37] = new State(new int[]{42,20,47,34,43,-31,45,-31,60,-31,62,-31,70,-31,78,-31,77,-31,76,-31,74,-31,73,-31,66,-31,69,-31,72,-31,41,-31,65,-31,85,-31,67,-31,71,-31,79,-31,82,-31,80,-31,44,-31});
    states[38] = new State(new int[]{85,23,83,24,40,25},new int[]{-3,39,-4,36,-2,22});
    states[39] = new State(new int[]{42,20,47,34,43,-32,45,-32,60,-32,62,-32,70,-32,78,-32,77,-32,76,-32,74,-32,73,-32,66,-32,69,-32,72,-32,41,-32,65,-32,85,-32,67,-32,71,-32,79,-32,82,-32,80,-32,44,-32});
    states[40] = new State(new int[]{85,23,83,24,40,25},new int[]{-3,41,-4,36,-2,22});
    states[41] = new State(new int[]{42,20,47,34,43,-33,45,-33,60,-33,62,-33,70,-33,78,-33,77,-33,76,-33,74,-33,73,-33,66,-33,69,-33,72,-33,41,-33,65,-33,85,-33,67,-33,71,-33,79,-33,82,-33,80,-33,44,-33});
    states[42] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-1,43,-3,37,-4,36,-2,22});
    states[43] = new State(new int[]{43,18,45,32,60,-27,62,-27,70,-27,78,-27,77,-27,76,-27,74,-27,73,-27,66,-27,69,-27,72,-27,41,-27,65,-27,85,-27,67,-27,71,-27,79,-27,82,-27,80,-27,44,-27});
    states[44] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-1,45,-3,37,-4,36,-2,22});
    states[45] = new State(new int[]{43,18,45,32,60,-28,62,-28,70,-28,78,-28,77,-28,76,-28,74,-28,73,-28,66,-28,69,-28,72,-28,41,-28,65,-28,85,-28,67,-28,71,-28,79,-28,82,-28,80,-28,44,-28});
    states[46] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-1,47,-3,37,-4,36,-2,22});
    states[47] = new State(new int[]{43,18,45,32,60,-29,62,-29,70,-29,78,-29,77,-29,76,-29,74,-29,73,-29,66,-29,69,-29,72,-29,41,-29,65,-29,85,-29,67,-29,71,-29,79,-29,82,-29,80,-29,44,-29});
    states[48] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-1,49,-3,37,-4,36,-2,22});
    states[49] = new State(new int[]{43,18,45,32,60,-30,62,-30,70,-30,78,-30,77,-30,76,-30,74,-30,73,-30,66,-30,69,-30,72,-30,41,-30,65,-30,85,-30,67,-30,71,-30,79,-30,82,-30,80,-30,44,-30});
    states[50] = new State(new int[]{43,18,45,32,60,-24,62,-24,70,-24,78,-24,77,-24,76,-24,74,-24,73,-24,66,-24,69,-24,72,-24,41,-24,65,-24,85,-24,67,-24,71,-24,79,-24,82,-24,80,-24,44,-24});
    states[51] = new State(new int[]{60,16,62,30,70,42,78,44,77,46,76,48,74,-19,73,-19,66,-19,69,-19,72,-19,41,-19,65,-19,85,-19,67,-19,71,-19,79,-19,82,-19,80,-19,44,-19});
    states[52] = new State(new int[]{85,23,83,24,40,25,43,38,45,40},new int[]{-6,53,-1,50,-3,37,-4,36,-2,22});
    states[53] = new State(new int[]{60,16,62,30,70,42,78,44,77,46,76,48,74,-20,73,-20,66,-20,69,-20,72,-20,41,-20,65,-20,85,-20,67,-20,71,-20,79,-20,82,-20,80,-20,44,-20});
    states[54] = new State(-7);
    states[55] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,56,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[56] = new State(new int[]{74,14,73,28,65,4,85,23,67,55,71,59,79,65,82,68,80,72,66,-16,69,-16,72,-16},new int[]{-8,57,-16,9,-7,10,-2,11,-9,54,-11,58,-12,64,-14,67,-10,70,-13,71});
    states[57] = new State(-43);
    states[58] = new State(-8);
    states[59] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,60,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[60] = new State(new int[]{74,14,73,28,65,4,85,23,67,55,71,59,79,65,82,68,80,72,66,-16,69,-16,72,-16},new int[]{-8,61,-16,9,-7,10,-2,11,-9,54,-11,58,-12,64,-14,67,-10,70,-13,71});
    states[61] = new State(new int[]{72,62,66,-14,69,-14});
    states[62] = new State(new int[]{65,4,85,23,67,55,71,59,79,65,82,68,80,72,66,-16,69,-16,72,-16},new int[]{-8,63,-16,9,-7,10,-2,11,-9,54,-11,58,-12,64,-14,67,-10,70,-13,71});
    states[63] = new State(-15);
    states[64] = new State(-9);
    states[65] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,66,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[66] = new State(new int[]{74,14,73,28,66,-23,69,-23,72,-23});
    states[67] = new State(-10);
    states[68] = new State(new int[]{85,23},new int[]{-2,69});
    states[69] = new State(-13);
    states[70] = new State(-11);
    states[71] = new State(-12);
    states[72] = new State(new int[]{85,23},new int[]{-2,73});
    states[73] = new State(new int[]{81,74});
    states[74] = new State(new int[]{40,75});
    states[75] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,76,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[76] = new State(new int[]{44,77,74,14,73,28});
    states[77] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,78,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[78] = new State(new int[]{44,79,74,14,73,28});
    states[79] = new State(new int[]{85,23,83,24,40,25,43,38,45,40,75,52},new int[]{-5,80,-6,51,-1,50,-3,37,-4,36,-2,22});
    states[80] = new State(new int[]{41,81,74,14,73,28});
    states[81] = new State(new int[]{65,4,85,23,67,55,71,59,79,65,82,68,80,72,66,-16,69,-16,72,-16},new int[]{-8,82,-16,9,-7,10,-2,11,-9,54,-11,58,-12,64,-14,67,-10,70,-13,71});
    states[82] = new State(-44);
    states[83] = new State(-3);

    rules[1] = new Rule(-18, new int[]{-17,64});
    rules[2] = new Rule(-17, new int[]{-16});
    rules[3] = new Rule(-15, new int[]{-8});
    rules[4] = new Rule(-15, new int[]{-15,69,-8});
    rules[5] = new Rule(-8, new int[]{-16});
    rules[6] = new Rule(-8, new int[]{-7});
    rules[7] = new Rule(-8, new int[]{-9});
    rules[8] = new Rule(-8, new int[]{-11});
    rules[9] = new Rule(-8, new int[]{-12});
    rules[10] = new Rule(-8, new int[]{-14});
    rules[11] = new Rule(-8, new int[]{-10});
    rules[12] = new Rule(-8, new int[]{-13});
    rules[13] = new Rule(-14, new int[]{82,-2});
    rules[14] = new Rule(-11, new int[]{71,-5,-8});
    rules[15] = new Rule(-11, new int[]{71,-5,-8,72,-8});
    rules[16] = new Rule(-10, new int[]{});
    rules[17] = new Rule(-2, new int[]{85});
    rules[18] = new Rule(-7, new int[]{-2,68,-5});
    rules[19] = new Rule(-5, new int[]{-6});
    rules[20] = new Rule(-5, new int[]{75,-6});
    rules[21] = new Rule(-5, new int[]{-5,74,-6});
    rules[22] = new Rule(-5, new int[]{-5,73,-6});
    rules[23] = new Rule(-12, new int[]{79,-5});
    rules[24] = new Rule(-6, new int[]{-1});
    rules[25] = new Rule(-6, new int[]{-6,60,-1});
    rules[26] = new Rule(-6, new int[]{-6,62,-1});
    rules[27] = new Rule(-6, new int[]{-6,70,-1});
    rules[28] = new Rule(-6, new int[]{-6,78,-1});
    rules[29] = new Rule(-6, new int[]{-6,77,-1});
    rules[30] = new Rule(-6, new int[]{-6,76,-1});
    rules[31] = new Rule(-1, new int[]{-3});
    rules[32] = new Rule(-1, new int[]{43,-3});
    rules[33] = new Rule(-1, new int[]{45,-3});
    rules[34] = new Rule(-1, new int[]{-1,43,-3});
    rules[35] = new Rule(-1, new int[]{-1,45,-3});
    rules[36] = new Rule(-3, new int[]{-4});
    rules[37] = new Rule(-3, new int[]{-3,42,-4});
    rules[38] = new Rule(-3, new int[]{-3,47,-4});
    rules[39] = new Rule(-4, new int[]{-2});
    rules[40] = new Rule(-4, new int[]{83});
    rules[41] = new Rule(-4, new int[]{40,-5,41});
    rules[42] = new Rule(-16, new int[]{65,-15,66});
    rules[43] = new Rule(-9, new int[]{67,-5,-8});
    rules[44] = new Rule(-13, new int[]{80,-2,81,40,-5,44,-5,44,-5,41,-8});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
      case 2: // progr -> block
{root = ValueStack[ValueStack.Depth-1].BlockN;}
        break;
      case 3: // stlist -> statement
{ CurrentSemanticValue.BlockN = new BlockNode(ValueStack[ValueStack.Depth-1].StatementN); }
        break;
      case 4: // stlist -> stlist, SEMICOLON, statement
{ ValueStack[ValueStack.Depth-3].BlockN.Add(ValueStack[ValueStack.Depth-1].StatementN); CurrentSemanticValue.BlockN = ValueStack[ValueStack.Depth-3].BlockN;}
        break;
      case 5: // statement -> block
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].BlockN;}
        break;
      case 6: // statement -> assign
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 7: // statement -> cycle
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 8: // statement -> if
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 9: // statement -> write
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 10: // statement -> reads
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 11: // statement -> empty
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 12: // statement -> forcycle
{CurrentSemanticValue.StatementN = ValueStack[ValueStack.Depth-1].StatementN;}
        break;
      case 13: // reads -> READ, ident
{ CurrentSemanticValue.StatementN = new ReadNode(ValueStack[ValueStack.Depth-1].ExprN as IdNode); }
        break;
      case 14: // if -> IF, expr, statement
{ CurrentSemanticValue.StatementN = new IfNode(ValueStack[ValueStack.Depth-2].ExprN, ValueStack[ValueStack.Depth-1].StatementN); }
        break;
      case 15: // if -> IF, expr, statement, ELSE, statement
{ CurrentSemanticValue.StatementN = new IfNode(ValueStack[ValueStack.Depth-4].ExprN, ValueStack[ValueStack.Depth-3].StatementN, ValueStack[ValueStack.Depth-1].StatementN); }
        break;
      case 16: // empty -> /* empty */
{CurrentSemanticValue.StatementN = null; }
        break;
      case 17: // ident -> ID
{ CurrentSemanticValue.ExprN = new IdNode(ValueStack[ValueStack.Depth-1].stringT); }
        break;
      case 18: // assign -> ident, ASSIGN, expr
{ CurrentSemanticValue.StatementN = new AssignNode(ValueStack[ValueStack.Depth-3].ExprN as IdNode, ValueStack[ValueStack.Depth-1].ExprN); }
        break;
      case 20: // expr -> NOT, boolexpr
{ CurrentSemanticValue.ExprN = new BinaryOpNode(null, BinaryOpType.Not, ValueStack[ValueStack.Depth-1].ExprN); }
        break;
      case 21: // expr -> expr, OR, boolexpr
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Or, ValueStack[ValueStack.Depth-1].ExprN);  }
        break;
      case 22: // expr -> expr, AND, boolexpr
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.And, ValueStack[ValueStack.Depth-1].ExprN); }
        break;
      case 23: // write -> PRINT, expr
{ CurrentSemanticValue.StatementN = new WriteNode(ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 25: // boolexpr -> boolexpr, '<', ariphm
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Less, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 26: // boolexpr -> boolexpr, '>', ariphm
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Greater, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 27: // boolexpr -> boolexpr, EQUALS, ariphm
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Equals, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 28: // boolexpr -> boolexpr, UNEQUALS, ariphm
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.UnEquals, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 29: // boolexpr -> boolexpr, GE, ariphm
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.GreaterOrEquals, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 30: // boolexpr -> boolexpr, LE, ariphm
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.LessOrEquals, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 32: // ariphm -> '+', mult
{CurrentSemanticValue.ExprN = ValueStack[ValueStack.Depth-1].ExprN;}
        break;
      case 33: // ariphm -> '-', mult
{CurrentSemanticValue.ExprN = new BinaryOpNode(null, BinaryOpType.Minus, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 34: // ariphm -> ariphm, '+', mult
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Plus, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 35: // ariphm -> ariphm, '-', mult
{ CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Minus, ValueStack[ValueStack.Depth-1].ExprN); }
        break;
      case 37: // mult -> mult, '*', term
{CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Multiplies, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 38: // mult -> mult, '/', term
{CurrentSemanticValue.ExprN = new BinaryOpNode(ValueStack[ValueStack.Depth-3].ExprN, BinaryOpType.Divides, ValueStack[ValueStack.Depth-1].ExprN);}
        break;
      case 40: // term -> INUM
{CurrentSemanticValue.ExprN = new IntNumNode(ValueStack[ValueStack.Depth-1].intT); }
        break;
      case 41: // term -> '(', expr, ')'
{ CurrentSemanticValue.ExprN = ValueStack[ValueStack.Depth-2].ExprN; }
        break;
      case 42: // block -> BEGIN, stlist, END
{ CurrentSemanticValue.BlockN = ValueStack[ValueStack.Depth-2].BlockN; }
        break;
      case 43: // cycle -> CYCLE, expr, statement
{CurrentSemanticValue.StatementN = new CycleNode(ValueStack[ValueStack.Depth-2].ExprN, ValueStack[ValueStack.Depth-1].StatementN);}
        break;
      case 44: // forcycle -> FOR, ident, IN, '(', expr, ',', expr, ',', expr, ')', statement
{ CurrentSemanticValue.StatementN = new ForCycleNode(ValueStack[ValueStack.Depth-10].ExprN as IdNode, ValueStack[ValueStack.Depth-7].ExprN, ValueStack[ValueStack.Depth-5].ExprN, ValueStack[ValueStack.Depth-3].ExprN, ValueStack[ValueStack.Depth-1].StatementN);}
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
