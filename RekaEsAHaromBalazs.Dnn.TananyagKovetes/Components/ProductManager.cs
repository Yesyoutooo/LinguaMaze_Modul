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
using DotNetNuke.UI.Modules;
using System.Collections.Generic;
using TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Models;

namespace TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Components
{
    internal interface IProductManager
    {
        bool IsCourse(string bvin);
        IEnumerable<hcc_Product> GetItems(int moduleId);
        hcc_Product GetOrder(string orderId);

        
    }

    internal class ProductManager : ServiceLocator<IProductManager, ProductManager>, IProductManager
    {
        public bool IsCourse(string bvin)
        {
            hcc_Product t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<hcc_Product>();
                t = rep.GetById(bvin);
            }
            if (t == null)
            {
                return false;
            }
            else if (t.IsCourse == false)
            {
                return false;
            }
            else 
            { 
                return true; 
            }
        }
        public IEnumerable<hcc_Product> GetItems(int moduleId)
        {
            IEnumerable<hcc_Product> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<hcc_Product>();
                t = rep.Get();
            }
            return t;
        }

        public hcc_Product GetOrder(string orderId)
        {
            hcc_Product t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<hcc_Product>();
                t = rep.GetById(orderId);
            }
            return t;
        }

        protected override System.Func<IProductManager> GetFactory()
        {
            return () => new ProductManager();
        }
    }
}
