﻿/*
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
    internal interface IPassesManager
    {
        IEnumerable<Passes> GetItems(int moduleId);
        Passes GetOrder(string orderId);
        IEnumerable<Passes> GetPassesByUserID(int userID);
    }

    internal class PassesManager : ServiceLocator<IPassesManager, PassesManager>, IPassesManager
    {
        public IEnumerable<Passes> GetItems(int moduleId)
        {
            IEnumerable<Passes> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Passes>();
                t = rep.Get();
            }
            return t;
        }

        public Passes GetOrder(string passId)
        {
            Passes t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Passes>();
                t = rep.GetById(passId);
            }
            return t;
        }

        public IEnumerable<Passes> GetPassesByUserID(int userID)
        {
            IEnumerable<Passes> userPass;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Passes>();
                userPass = rep.Find("WHERE UserID = @0", userID);
            }
            return userPass;
        }

        protected override System.Func<IPassesManager> GetFactory()
        {
            return () => new PassesManager();
        }
    }
}
