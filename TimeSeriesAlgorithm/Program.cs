using RDotNet;
using RDotNet.NativeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> data = new List<double>();

            for(int i = 0; i < 6; i++)
            {
                data.Add(2.0);
                data.Add(0.0);
                data.Add(0.0);
                data.Add(2.0);
                data.Add(0.0);
                data.Add(1.0);
                data.Add(0.0);
            }

            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
            NumericVector dataVector = engine.CreateNumericVector(data.ToArray());
            engine.SetSymbol("dataVector", dataVector);
            engine.Evaluate("graphObj <- ts(dataVector, frequency=1, start=c(1, 1, 1))");
            engine.Evaluate("library(\"forecast\")");
            engine.Evaluate("arimaFit <- arima(graphObj,order=c(2,2,2))");
            engine.Evaluate("fcast <- forecast(arimaFit, h=1)");
            engine.Evaluate("result <- as.numeric(fcast$mean)");
            NumericVector forecastResult = engine.GetSymbol("result").AsNumeric();
            double result = forecastResult.First();

            if (result >= 1)
            {
                Console.WriteLine("Go buy milk today");
            }
            else
            {
                Console.WriteLine("Dont buy milk today");
            }

            Console.WriteLine("Result = " + result);


            Console.ReadKey();
            engine.Dispose();

        }
    }
}
