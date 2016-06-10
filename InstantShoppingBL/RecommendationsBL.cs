using InstantShoppingCommon;
using InstantShoppingDataAccess;
using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingBL
{
    public class RecommendationsBL
    {

        public static string GetRecommendations(string groupObjectId)
        {
            GetProductFriquency(groupObjectId);
            return "";
        }
        public static double GetRecomendedQuntity(string product, List<double> countList)
        {
            List<double> data = new List<double>();
        
            for (int i = 0; i < 6; i++)
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
            return "";
        }

        public static Dictionary<string,double> GetProductFriquency(string groupObjectId)
        {
            // Move list to history and gets the group
            Group group = GroupsDataAccess.GetInstance().GetGroup(groupObjectId);
            Dictionary<string, double> dic = new Dictionary<string, double>();

            // If there is at least 10 history lists
            if (group.HistoryLists.Count >= 10)
            {
                DateTime firstListDate = new DateTime(); ;
                // Get all the lists from the last 3 monthes
                List<HistoryShoppingList> lists = group.HistoryLists.Where(p => p.ShopDate > (DateTime.Today.AddMonths(-3))).ToList();

                List<HistoryProduct> Allproducts = new List<HistoryProduct>();
                foreach(HistoryShoppingList list in lists)
                {
                    if(list.ShopDate.CompareTo(firstListDate) < 0)
                    {
                        firstListDate = list.ShopDate;
                    }
                    list.ProductsList.Distinct().ToList();
                    foreach (Product product in list.ProductsList)
                    {
                        Allproducts.Add(new HistoryProduct(product, list.ShopDate));

                    }

                }

               while (Allproducts.Count > 0)
                {
                    List<HistoryProduct> curProducts = Allproducts.Where(p => p.ProductName == Allproducts[0].ProductName).ToList();
                    List<double> countPro = new List<double>();
                    
                    if (curProducts.Count > 2)
                    {
                        for(int i=0; i<(DateTime.Now - firstListDate).Days; i++)
                        {
                            foreach(HistoryProduct hisPro in curProducts)
                            {
                                if((hisPro.ShopDate-firstListDate).Days == i)
                                {
                                    countPro.Add(hisPro.Amount);
                                }
                            }
                        }
                          
                    }
                    dic.Add(curProducts[0].ProductName, GetRecomendedQuntity(curProducts[0].ProductName, countPro));
                    Allproducts.RemoveAll(p => p.ProductName == Allproducts[0].ProductName);
                }

            }

            return dic;
        }
    }
}
