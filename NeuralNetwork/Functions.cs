using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    static class Functions
    {
        public static double SumInput(List<Synapse> synapses , double err = 0)
        {
            double sum = 0;
            foreach (var syn in synapses)
            {
                sum += syn.GetOutput();
            }
            return (sum +err);
        }

        public static double SigmoidFunction(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }

        public static double SigmoidFunctionDeriative(double input)
        {
            return SigmoidFunction(input) * (1 - SigmoidFunction(input));
        }

        public static double CalculateError(List<double> outputs, int row , double[][] ExceptedResults)
        {
            double err = 0;
            for (int i = 0; i < outputs.Count; i++)
            {
                err += Math.Pow(outputs[i] - ExceptedResults[row][i], 2);
            }
            return err;
        }

        public static double BipolarLinearFunction(double input) // funkcja aktywacji: liniowa bipolarna
            => (1 - Math.Pow(Math.E, -0.5 * input)) / (1 + Math.Pow(Math.E, -0.5 * input));

        public static double BipolarDifferential(double input) // pochodna funkcji aktywacji: liniowej bipolarnej
            => (2 * 0.5 * Math.Pow(Math.E, -0.5 * input)) / (Math.Pow(1 + Math.Pow(Math.E, -0.5 * input), 2));
    }
}
