/*
' Copyright (c) 2024 RekaEsAHaromBalazs
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Models;

namespace TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Components
{
    internal interface IOrderManager
    {
        IEnumerable<hcc_Order> GetItems(int moduleId);
        hcc_Order GetOrder(string orderId);
        IEnumerable<hcc_Order> GetOrderByUser(int userID);
    }

    internal class OrderManager : ServiceLocator<IOrderManager, OrderManager>, IOrderManager
    {
        public IEnumerable<hcc_Order> GetItems(int moduleId)
        {
            IEnumerable<hcc_Order> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<hcc_Order>();
                t = rep.Get();
            }
            return t;
        }

        public hcc_Order GetOrder(string orderId)
        {
            hcc_Order t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<hcc_Order>();
                t = rep.GetById(orderId);
            }
            return t;
        }

        public IEnumerable<hcc_Order> GetOrderByUser(int userID)
        {
            IEnumerable<hcc_Order> order;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<hcc_Order>();
                order = rep.Find("WHERE UserID = @0", userID);
            }
            return order;
        }

        protected override System.Func<IOrderManager> GetFactory()
        {
            return () => new OrderManager();
        }
    }
}
