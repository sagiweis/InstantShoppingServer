using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingDataAccess;
using InstantShoppingCommon;

namespace InstantShoppingBL
{
    public class SuperMarketsOrderBL
    {
        public static void addNewProductOrder(string id, string after,List<string> before)
        {
            for(int i=0; i< before.Count; i++)
            {
                ProductOrder productOrder = new ProductOrder(id, before[i], after );
                SuperMarketsOrderDataAccess.GetInstance().addNewProductOrder(productOrder);
            }
            
        }
    }
}
