using System;

namespace sisop_trab1
{
    public class SO
    {
        public VM vm;

        public SO()
        {
            vm = new VM();
        }

        static public void test1(VM vm)
        {
            Word[] p = Program.fibonacci10;
            Utils.carga(p, vm.m);
            vm.cpu.setContext(0);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 33);
            Console.WriteLine("---------------------------------- após execucao ");
            vm.cpu.run();
            Utils.dump(vm.m, 0, 33);
        }

        static public void test2(VM vm)
        {
            Word[] p = Program.progMinimo;
            Utils.carga(p, vm.m);
            vm.cpu.setContext(0);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            Console.WriteLine("---------------------------------- após execucao ");
            vm.cpu.run();
            Utils.dump(vm.m, 0, 15);
        }

        static public void test3(VM vm)
        {
            Word[] p = Program.P3;
            Utils.carga(p, vm.m);
            vm.cpu.setContext(0);
            Console.WriteLine("---------------------------------- programa carregado ");
            Utils.dump(vm.m, 0, 15);
            Console.WriteLine("---------------------------------- após execucao ");
            vm.cpu.run();
            Utils.dump(vm.m, 0, 15);
        }
    }

}
