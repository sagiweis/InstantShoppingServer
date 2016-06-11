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

        public static Dictionary<string,double> GetRecommendations(string groupObjectId)
        {
            return GetProductFriquency(groupObjectId);
        }
        private static double GetRecomendedQuntity(List<double> countList)
        {
            List<double> data = new List<double>();
        
            for (int i = 0; i < countList.Count; i++)
            {
                data.Add(countList[i]);

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
            Console.ReadKey();
            engine.Dispose();
            return result;
        }

        private static Dictionary<string,double> GetProductFriquency(string groupObjectId)
        {
            // Move list to history and gets the group
            Group group = GroupsDataAccess.GetInstance().GetGroup(groupObjectId);
            Dictionary<string, double> dic = new Dictionary<string, double>();

            // If there is at least 10 history lists
            if (group.HistoryLists.Count >= 1)
            {
                DateTime firstListDate = DateTime.Now; ;
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
                        for(int i=0; i<=(DateTime.Now - firstListDate).Days; i++)
                        {
                            bool found = false;
                            foreach(HistoryProduct hisPro in curProducts)
                            {
                                if((hisPro.ShopDate-firstListDate).Days == i)
                                {
                                    countPro.Add(hisPro.Amount);
                                    found = true;
                                } 
                            }
                            if (!found)
                            {
                                countPro.Add(0);
                            }
                        }
                        dic.Add(curProducts[0].ProductName, GetRecomendedQuntity(countPro));
                    } 
                    // delete the current products          
                    int count = Allproducts.Count;
                    for (int index =0; index < count; index++)
                    {
                        if (Allproducts[index].ProductName == curProducts[0].ProductName)
                        {
                            Allproducts.Remove(Allproducts[index]);
                            count--;
                        }
                    }
                }

            }

            return dic;
        }
    }
}
