using System;
using System.Text.RegularExpressions;

namespace CalculadoraNS
{

    public class Program
    {
        private static void Main()
        {
            Calculadora calculadora = new Calculadora();
            EvaluadorExpresion evaluador = new EvaluadorExpresion();

            Console.WriteLine("Introduzca una expresión mátematica ");


            string valorEntrada = Console.ReadLine();

                ResultadoAnalisis inputEvaluado = evaluador.Parse(valorEntrada);
                long primerArgumentoSalida = (inputEvaluado.PrimerArgumento);
                calculadora.Procesar(inputEvaluado);
                Console.WriteLine("\n{0}\t{1}\t{2}\t= {3}", primerArgumentoSalida, inputEvaluado.Operador, inputEvaluado.SegundoArgumento, calculadora.resultado);

            
        }
    }

    public class Calculadora
    {
        private bool _estaInicializado;
        public long resultado { get; set; }

        public const string MensajeOperacionNoAceptada = "Está operación no está permitida en el calculador.";

        public void Procesar(ResultadoAnalisis entrada)
        {
            if(!this._estaInicializado)
            {
                this.resultado = entrada.PrimerArgumento;
                this._estaInicializado = true;
            }
            switch (entrada.Operador)
            {
                case "+":
                    this.resultado += entrada.SegundoArgumento;
                    break;

                case "-":
                    this.resultado -= entrada.SegundoArgumento;
                    break;

                case "*":
                    this.resultado *= entrada.SegundoArgumento;
                    break;

                case "/":
                    this.resultado /= entrada.SegundoArgumento;
                    break;

                case "%":
                    this.resultado %= entrada.SegundoArgumento;
                    break;

                default:
                    throw new InvalidOperationException(MensajeOperacionNoAceptada);
            }
        }

    }

    public class ResultadoAnalisis
    {
        public long PrimerArgumento { get; set; }

        public string Operador { get; set; }

        public long SegundoArgumento { get; set; }
    }

    public class EvaluadorExpresion
    {
        public ResultadoAnalisis Parse(string entradaRaw)
        {
            long primeroArgumento = 0;
            Match primeraCoincidencia = Regex.Match(entradaRaw, "^\\d+");
            if (primeraCoincidencia.Success)
            {
                primeroArgumento = Convert.ToInt64(primeraCoincidencia.Value);
            }

            string operadorString = Regex.Match(entradaRaw, "\\D+").Value;

            Match segundaCoincidencia = Regex.Match(entradaRaw, "\\d+$");
            long segundoArgumento = Convert.ToInt64(segundaCoincidencia.Value);

            return new ResultadoAnalisis()
            {
                PrimerArgumento = primeroArgumento,
                Operador = operadorString,
                SegundoArgumento = segundoArgumento
            };
        }
    }
}
