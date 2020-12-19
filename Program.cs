using System.Collections.Concurrent;
using System;

namespace revisaocsharp
{
    class Program
    {
        static void Main(string[] args)
        {
              Aluno[] alunos = new Aluno[5];
              string opcaousuario = ObterOpcaoUsuario();
              var indicealuno = 0;
           while(opcaousuario.ToUpper() != "X"){
               switch(opcaousuario){
                   case "1":
              // To do adicionar aluno
           Console.WriteLine(" Informe o nome do aluno");
            var aluno= new Aluno();
            aluno.Nome = Console.ReadLine();
           Console.WriteLine("Informe a nota do aluno");
           if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
           aluno.Nota = nota;
           }
           else{
               throw new ArgumentException("o valor da nota deve ser decimal");
           }
           alunos[indicealuno]= aluno;
           indicealuno++;
                   break;
                   case "2": 
             // To do listar alunos
                   foreach (var a in alunos)
                   {
                       if(!string.IsNullOrEmpty(a.Nome)){
                       Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                   }}
                   break;

                case "3":
            // To do media alunos
            decimal notatotal=0;
            var nralunos =0;
            for (int i = 0; i < alunos.Length; i++)
            {
            if(!string.IsNullOrEmpty(alunos[i].Nome)){
             notatotal = notatotal + alunos[i].Nota;
             nralunos++;
            }
            }
            var mediatotal = notatotal / nralunos;
            Conceito conceitogeral;
            if(mediatotal < 2){
                conceitogeral = Conceito.E;
            }
            else if (mediatotal < 4)
            {
                conceitogeral = Conceito.D;
            }else if(mediatotal < 6)
            {
                conceitogeral=Conceito.C;
            } else if (mediatotal <8)
            {
                conceitogeral=Conceito.B;
            }else
            {
                conceitogeral=Conceito.A;
            }

            Console.WriteLine($" A media total dos alunos e: {mediatotal} de conceito{conceitogeral}");
                break;
                default: 
                throw new ArgumentOutOfRangeException();
               }
             opcaousuario=ObterOpcaoUsuario();
           }
        }
    private static string ObterOpcaoUsuario()
            {
                Console.WriteLine(" Escolha uma opção:");
                Console.WriteLine("");
                Console.WriteLine(" 1-inserir novo aluno.");
                Console.WriteLine(" 2-listar alunos.");
                Console.WriteLine(" 3-Calcular media geral.");
                Console.WriteLine(" Prescione X para sair.");
                string opcaousuario = Console.ReadLine();
                return opcaousuario;
            }

    }

}
