using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculadoraNS;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Procesar_Suma()
        {
            string expresionParaEvaluar = "2+3";
            long resultadoEsperado = 5;

            Calculadora calculadora = new Calculadora();
            EvaluadorExpresion evaluador = new EvaluadorExpresion();
            ResultadoAnalisis inputEvaluado = evaluador.Parse(expresionParaEvaluar);
            long primerArgumentoSalida = (inputEvaluado.PrimerArgumento);
            calculadora.Procesar(inputEvaluado);

            Assert.AreEqual(resultadoEsperado, calculadora.resultado, 0.001, "La calculadora ha evaluado incorrectamente la expresión de suma.");
        }

        [TestMethod]
        public void Procesar_Resta()
        {
            string expresionParaEvaluar = "22-5";
            long resultadoEsperado = 17;

            Calculadora calculadora = new Calculadora();
            EvaluadorExpresion evaluador = new EvaluadorExpresion();
            ResultadoAnalisis inputEvaluado = evaluador.Parse(expresionParaEvaluar);
            long primerArgumentoSalida = (inputEvaluado.PrimerArgumento);
            calculadora.Procesar(inputEvaluado);

            Assert.AreEqual(resultadoEsperado, calculadora.resultado, 0.001, "La calculadora ha evaluado incorrectamente la expresión de resta.");
        }

        [TestMethod]
        public void Procesar_Multiplicacion()
        {
            string expresionParaEvaluar = "22*40";
            long resultadoEsperado = 880;

            Calculadora calculadora = new Calculadora();
            EvaluadorExpresion evaluador = new EvaluadorExpresion();
            ResultadoAnalisis inputEvaluado = evaluador.Parse(expresionParaEvaluar);
            long primerArgumentoSalida = (inputEvaluado.PrimerArgumento);
            calculadora.Procesar(inputEvaluado);

            Assert.AreEqual(resultadoEsperado, calculadora.resultado, 0.001, "La calculadora ha evaluado incorrectamente la expresión de multiplicación.");
        }

        [TestMethod]
        public void Procesar_Division()
        {
            string expresionParaEvaluar = "440/7";
            long resultadoEsperado = 62;

            Calculadora calculadora = new Calculadora();
            EvaluadorExpresion evaluador = new EvaluadorExpresion();
            ResultadoAnalisis inputEvaluado = evaluador.Parse(expresionParaEvaluar);
            long primerArgumentoSalida = (inputEvaluado.PrimerArgumento);
            calculadora.Procesar(inputEvaluado);

            Assert.AreEqual(resultadoEsperado, calculadora.resultado, 0.001, "La calculadora ha evaluado incorrectamente la expresión de división.");
        }

        [TestMethod]
        public void Excepcion_ErrorOperacion()
        {
            string expresionParaEvaluar = "440.5 + 4";
            Calculadora calculadora = new Calculadora();
            EvaluadorExpresion evaluador = new EvaluadorExpresion();
            
            try
            {
                ResultadoAnalisis inputEvaluado = evaluador.Parse(expresionParaEvaluar);
                long primerArgumentoSalida = (inputEvaluado.PrimerArgumento);
                calculadora.Procesar(inputEvaluado);
            }
            catch(System.InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, Calculadora.MensajeOperacionNoAceptada);
                return;
            }

            Assert.Fail("La excepción esperada no se ejecutó");
        }
    }
}
