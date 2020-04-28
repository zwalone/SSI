using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Network
    {
        static double coefficient = 0.5;
        internal List<Layer> Layers;
        internal double[][] ExpectedResult;
        double[][] differences;

        public Network(int inputNeurons, int hiddenLayers, int hiddenNeurons, int outputNeurons)
        {
            Layers = new List<Layer>();
            AddInputLayer(inputNeurons);


            for (int i = 0; i < hiddenLayers; i++)
            {
                AddLayers(new Layer(hiddenNeurons));
            }
            AddLayers(new Layer(outputNeurons));

            differences = new double[Layers.Count][];

            for (int i = 0; i < Layers.Count; i++)
            {
                differences[i] = new double[Layers[i].neurons.Count];
            }

        }

        public void AddInputLayer(int inputNeurons)
        {
            Layer inputLayer = new Layer(inputNeurons);
            foreach (var neuron in inputLayer.neurons)
            {
                //first neurons don't have synapses
                neuron.AddInputSynapse(0);
            }
            Layers.Add(inputLayer);
        }

        public void AddLayers(Layer toAddLayer)
        {
            Layer lastLayer = Layers[Layers.Count - 1];
            lastLayer.ConnectLayersWithOtherLayers(toAddLayer);
            Layers.Add(toAddLayer);
        }

        public void PushExpectedValue(double[][] data)
        {
            ExpectedResult = data;
        }

        public void PushInputValues(double[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                Layers[0].neurons[i].PushValueOnInput(inputs[i]);
            }
        }

        public List<double> GetOutputs()
        {
            List<double> output = new List<double>();

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].CalculateLayer();
            }
            foreach (var neuron in Layers[Layers.Count - 1].neurons)
            {
                output.Add(neuron.OutputVal);
            }

            return output;
        }




        private void CalculateDifferences(List<double> outputs, int row)
        {
            for (int i = 0; i < Layers[Layers.Count - 1].neurons.Count; i++)
                differences[Layers.Count - 1][i] = (ExpectedResult[row][i] - outputs[i])
                    * Functions.BipolarDifferential(Layers[Layers.Count - 1].neurons[i].InputVal);
            for (int k = Layers.Count - 2; k > 0; k--)
                for (int i = 0; i < Layers[k].neurons.Count; i++)
                {
                    differences[k][i] = 0;
                    for (int j = 0; j < Layers[k + 1].neurons.Count; j++)
                        differences[k][i] += differences[k + 1][j] * Layers[k + 1].neurons[j].Inputs[i].Weight;
                    differences[k][i] *= Functions.BipolarDifferential(Layers[k].neurons[i].InputVal);
                }
        }
        //public void CalculateDiffrences(List<double> outputs, int row)
        //{
        //    for (int i = 0; i < Layers[Layers.Count - 1].neurons.Count; i++)
        //    {
        //        differences[Layers.Count - 1][i] = (ExpectedResult[row][i] - outputs[i]) * 
        //            Functions.BipolarDifferential(Layers[Layers.Count - 1].neurons[i].InputVal);
        //    }

        //    for (int i = Layers.Count - 2; i > 0; i--) 
        //    {
        //        for (int j = 0; j < Layers[i].neurons.Count; j++)
        //        {
        //            differences[i][j] = 0;

        //            for (int k = 0; k < Layers[i + 1].neurons.Count; k++)
        //            {
        //                differences[i][j] += differences[i + 1][k] * Layers[i + 1].neurons[k].Inputs[j].Weight;
        //            }

        //            differences[i][j] *= Functions.BipolarDifferential(Layers[i].neurons[j].InputVal);
        //        }
        //    }
        //}


        //public void ChangeWeights(List<double> outputs, int row)
        //{
        //    CalculateDifferences(outputs, row);

        //    for (int i = Layers.Count - 1; i > 0; i--)
        //    {
        //        for (int j = 0; j < Layers[i].neurons.Count; j++)
        //        {
        //            for (int k = 0; k < Layers[i-1].neurons.Count; k++)
        //            {
        //                Layers[i].neurons[j].Inputs[k].UpdateWeight(
        //                    coefficient * 2  * differences[i][j] * Layers[i - 1].neurons[k].OutputVal);
        //            }
        //        }
        //    }
        //}
        public void ChangeWeights(List<double> outputs, int row)
        {
            CalculateDifferences(outputs, row);
            for (int k = Layers.Count - 1; k > 0; k--)
                for (int i = 0; i < Layers[k].neurons.Count; i++)
                    for (int j = 0; j < Layers[k - 1].neurons.Count; j++)
                        Layers[k].neurons[i].Inputs[j].UpdateWeight(
                            coefficient * 2 * differences[k][i] * Layers[k - 1].neurons[j].OutputVal);
        }




        public void Train(double[][] inputs, double maxErr)
        {
            double error = double.MaxValue;
            while (error/inputs.Length > maxErr)
            {
                error = 0;
                List<double> outputs = new List<double>();

                for (int i = 0; i < inputs.Length; i++)
                {
                    PushInputValues(inputs[i]);
                    outputs = GetOutputs();
                    ChangeWeights(outputs, i);
                    error += Functions.CalculateError(outputs, i, ExpectedResult);
                }
                Console.WriteLine("Actual error: " + (error / inputs.Length).ToString());
            }
            Console.WriteLine(" Sieć nauczona! Średni błąd średniokwadratowy wynosi: " + (Math.Round(error / inputs.Length, 5)).ToString() + "\n");
        }
    }
}
