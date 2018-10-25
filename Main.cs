using System;
using System.IO;
using System.Collections.Generic;
using SimpleScanner;
using ProgramTree;
using SimpleParser;
using SimpleLang.Visitors;
using ThreeAddr;
using SimpleLang.Optimizations;
using SimpleLang.Utility;
using System.Linq;
using CommandLine;
using SimpleLang.SSA;

namespace SimpleCompiler
{
    public class CapitalizerVisitor : AutoVisitor
    {
        public override void VisitIdNode(IdNode id)
        {
            id.Name = id.Name[0].ToString().ToUpper() + id.Name.Substring(1);
        }
    }


    public class Options
    {
        [Option('w', "write", Required = false, Default = "a.out",
                HelpText = "Output file")]
        public string OutputFile { get; set; }

        [Option("binary", Default = false)]
        public bool OutBinary { get; set; }

        [Value(0, MetaName = "input", HelpText = "File to Compile", Default = "../../test.txt")]
        public String InputFile { get; set; }
    }


    public class SimpleCompilerMain
    {

        public static void Optimize(List<BaseBlock> codeBlocks)
        {
            Console.WriteLine("Optimize");
            var bboptimizator = new BaseBlockOptimizator();
            bboptimizator.AddOptimization(new NopDeleteOptimization());
            bboptimizator.AddOptimization(new TemporaryExprPropagation());
            bboptimizator.AddOptimization(new ConstantsOptimization());
            bboptimizator.AddOptimization(new AlgebraIdentity());
            bboptimizator.AddOptimization(new ExprCanon());
            bboptimizator.AddOptimization(new IfGotoOptimization());
            //bboptimizator.AddOptimization(new CopyPropagationOptimization());
            //bboptimizator.AddOptimization(new DeadCodeOptimization());
            //bboptimizator.AddOptimization(new CommonSubexpressionOptimization());


            var cboptimizator = new CrossBlocksOptimizator();
            cboptimizator.AddOptimization(new IsNotInitVariable());
            cboptimizator.AddOptimization(new AliveBlocksOptimization());
            //cboptimizator.AddOptimization(new CrossBlocksDeadCodeOptimization());
            //cboptimizator.AddOptimization(new CrossBlockConstantPropagation());
            //cboptimizator.AddOptimization(new GlobalCommonSubexpressionsOptimization());

            while (bboptimizator.Optimize(codeBlocks) || cboptimizator.Optimize(codeBlocks) ) {};


        }

        public static void Compile(BlockNode prog, Options opt)
        {
            var threeAddressGenerationVisitor = new ThreeAddressGenerationVisitor();
            prog.Visit(threeAddressGenerationVisitor);


            var code = threeAddressGenerationVisitor.Data;
            var codeSz = code.Count;

            var codeBlocks = BaseBlockHelper.GenBaseBlocks(threeAddressGenerationVisitor.Data);
                
            foreach (var block in codeBlocks)
                Console.Write(block);


            codeBlocks = BaseBlockHelper.GenBaseBlocks(code);
            Optimize(codeBlocks);

            var JoindCode = BaseBlockHelper.JoinBaseBlocks(codeBlocks);

            CodeIO CP = new CodeIO(opt.OutputFile, opt.OutBinary);
            CP.Write(JoindCode);

            // Блоки с нумерацией
            Console.WriteLine();
            Console.WriteLine();


            // SSA


            var CFG = new ControlFlowGraph(codeBlocks);

            Console.WriteLine("Original");
            Console.Write(CFG);
            Console.Write(CFG.FindDommBlocks());
            var tmp = CFG.FindDommBlocks();
            for(var i=0;i<tmp.Count;++i) { 
                Console.Write(i);
                Console.Write(' ');
                foreach (var j in tmp[i])
                    Console.Write(j);

                Console.WriteLine();
            }
            
            /*
            var FOD = new FrontOnDominance(CFG); // Модифицирует CFG
            Console.Write(FOD);
            Console.Write(FOD.globalsToString());

            Console.WriteLine("Phi");
            Console.Write(CFG);
            */

            Console.ReadLine();


            
        }


        public static void CompileMain(Options opt){
            var varRenamerVisitor = new VariableIdUnificationVisitor();

            try
            {
                string Text = File.ReadAllText(opt.InputFile);

                Scanner scanner = new Scanner();
                scanner.SetSource(Text, 0);


                SimpleParser.Parser parser = new SimpleParser.Parser(scanner);


                var b = parser.Parse();
                if (!b)
                    Console.WriteLine("Ошибка");
                else
                {
                    parser.root.Visit(varRenamerVisitor);
                    Console.WriteLine("Программа распознана");
                    Compile(parser.root, opt);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл {0} не найден", opt.InputFile);
            }
            catch (LexException e)
            {
                Console.WriteLine("Лексическая ошибка. " + e.Message);
            }
            catch (SyntaxException e)
            {
                Console.WriteLine("Синтаксическая ошибка. " + e.Message);
            }
            catch (NotInitVariableException e)
            {
                foreach (var i in e.VarList)
                    Console.WriteLine("Переменная {0} -> {1} не инициализирована", i, varRenamerVisitor.IDDict.First(a => i == "v" + a.Value).Key);
            }
        }


        public static void Main(String[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                               .WithNotParsed((ers)=>Console.WriteLine("Wrong command args"))
                               .WithParsed(opts => CompileMain(opts) );



            

        }
    }
}
